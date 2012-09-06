using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

namespace CalDiningOracle
{
	class mangochan
	{
		private static Regex csrf_token = new Regex("_cNoOpConversation id_[0-9A-Za-z_-]+", RegexOptions.Compiled);
		private static Regex entry = new Regex("<tr><td>(?<date>[0-9]{1,2}/[0-9]{1,2}/[0-9]{4} [0-9]{1,2}:[0-9]{1,2}:[0-9]{1,2} (?:PM|AM))</td><td>\\$(?<amount>[0-9.]+)</td><td>(?<location>[^>]+)</td></tr>", RegexOptions.Compiled);
		private string transactionsHTML = "";
		private CookieContainer himitsu = new CookieContainer();

		public bool Authenticate(string username, System.Security.SecureString password)
		{
			// jaka go get me my csrf token.
			HttpWebRequest hwr = WebRequest.Create("https://auth.berkeley.edu/cas/login") as HttpWebRequest;
			HttpWebResponse resp = hwr.GetResponse() as HttpWebResponse;
			string page;
			using (StreamReader sr = new StreamReader(new BufferedStream(resp.GetResponseStream())))
			{
				page = sr.ReadToEnd();
			}
			resp.Close();

			// regex-fu
			string csrf_token = mangochan.csrf_token.Match(page).Groups[0].Value;

			// Do things with SecureString because I'm a masochist.
			IntPtr unmanagedString = IntPtr.Zero;
			string パスワード;
			try
			{
				unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(password);
				パスワード = Marshal.PtrToStringUni(unmanagedString);
			}
			finally
			{
				Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
			}

			// LINQ is best Q.
			string querystring = (
				from a in new[] { Tuple.Create("lt", csrf_token), Tuple.Create("_eventId", "submit"), Tuple.Create("username", username), Tuple.Create("password", "") }
				select a.Item1 + "=" + Uri.EscapeDataString(a.Item2)
			).Aggregate((a, b) => a + "&" + b) + Uri.EscapeDataString(パスワード);

			// post to the CAS.
			hwr = WebRequest.Create("https://auth.berkeley.edu/cas/login") as HttpWebRequest;
			hwr.ContentType = "application/x-www-form-urlencoded";
			hwr.Method = "POST";
			hwr.CookieContainer = himitsu;
			using (StreamWriter w = new StreamWriter(hwr.GetRequestStream()))
			{
				// LINQ is best Q.
				w.Write(querystring);
			}

			// ZzZzZz
			resp = hwr.GetResponse() as HttpWebResponse;
			using (StreamReader sr = new StreamReader(new BufferedStream(resp.GetResponseStream())))
			{
				page = sr.ReadToEnd();
			}

			return resp.Cookies.Count == 2;
		}

		public bool FetchHistory()
		{
			// maybe jaka is useful after all.
			doSimpleGet("https://services.housing.berkeley.edu/c1c/dyn/login.asp");
			doSimpleGet("https://services.housing.berkeley.edu/c1c/dyn/loginc1c.asp");
			doSimpleGet("https://services.housing.berkeley.edu/c1c/dyn/CalNetLogin.asp");

			HttpWebRequest hwr = makeRequest("https://auth.berkeley.edu/cas/login?service=https://services.housing.berkeley.edu/c1c/dyn/CasLogin.asp");
			HttpWebResponse response = hwr.GetResponse() as HttpWebResponse;
			string ticket = "", newurl = "";

			// only time will tell.
			switch (response.StatusCode)
			{
				case HttpStatusCode.Found:
					newurl = response.Headers[HttpResponseHeader.Location];
					int idx = newurl.IndexOf("ticket=");

					if (idx != -1)
					{
						ticket = newurl.Substring(idx + 7);
						Debug.WriteLine("Got ticket ID: {0}", new[] { ticket });
						break;
					}

					throw new Exception("CalNet didn't return a ticket?");

				default:
					throw new Exception(string.Format("Server returned unexpected response code: {0} {1}", response.StatusCode, response.StatusDescription));
			}
			response.Close();

			// lol not following 301 redirects.
			doSimpleGet(newurl);
			doSimpleGet("https://services.housing.berkeley.edu/c1c/dyn/calnetlogincheck.asp");
			doSimpleGet("https://services.housing.berkeley.edu/c1c/dyn/login.asp");

			hwr = makeRequest("https://services.housing.berkeley.edu/c1c/dyn/bals.asp?pln=rh");
			response = hwr.GetResponse() as HttpWebResponse;

			using (StreamReader sr = new StreamReader(new BufferedStream(response.GetResponseStream()), Encoding.GetEncoding("iso-8859-1")))
			{
				transactionsHTML = sr.ReadToEnd().Replace("\r\n", "").Replace("\n", "");
			}
			response.Close();

			return transactionsHTML.Length != 0;
		}

		public IEnumerable<nattoenemies> GetTransactions()
		{
			var nattoenemies = from Match x in entry.Matches(transactionsHTML)
							   select new nattoenemies(DateTime.Parse(x.Groups["date"].Value), decimal.Parse(x.Groups["amount"].Value), x.Groups["location"].Value);

			return from x in nattoenemies
				   orderby x.Date descending
				   group x by x.Date into xx
				   select xx.Aggregate((x, y) => new nattoenemies(x.Date, x.Amount + y.Amount, x.Location));
		}

		private HttpWebRequest makeRequest(string url)
		{
			var hwr = WebRequest.Create(url) as HttpWebRequest;
			hwr.CookieContainer = himitsu;
			hwr.AllowAutoRedirect = false;

			return hwr;
		}
		private void doSimpleGet(string url)
		{
			Debug.WriteLine("GET: {0}", new[] { url });

			var response = makeRequest(url).GetResponse();
			response.Close();
		}
	}

	public class nattoenemies
	{
		public DateTime Date { get; private set; }
		public decimal Amount { get; private set; }
		public string Location { get; private set; }

		public nattoenemies(DateTime d, decimal a, string l)
		{
			Date = d;
			Amount = a;
			Location = l;
		}

		public override string ToString()
		{
			return string.Format("{0}: -${1} @ {2}", Location, Amount, Date);
		}
	}
}
