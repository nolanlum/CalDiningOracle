using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CalDiningOracle
{
	class kedo
	{
		private string username;
		private System.Security.SecureString password;
		private PlanType type;

		[STAThread]
		static void Main()
		{
			new kedo().keod(); // because why not.
		}

		void keod()
		{
			// Do everything in one method? I think so!
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			// jaka give me passwords.
			kedofriends(false);

			// I summon you, jaka's alter ego!
			mangochan mangochan = new mangochan();
			while (!mangochan.Authenticate(username, password))
				kedofriends(true);

			// idk why I used SecureString.
			password.Dispose();

			// Fetch history and parse transaction list.
			mangochan.FetchHistory();
			var x = mangochan.GetTransactions().Reverse().ToArray();

			Application.Run(new natto(x, type));
		}

		void kedofriends(bool retry)
		{
			using (jaka jaka = new jaka())
			{
				jaka.Show();

				if (retry)
				{
					jaka.PasswordWasWrong();
					npkji.Flash(jaka, 3);
				}

				// wait for slow jaka
				while (jaka.Visible)
				{
					Application.DoEvents();

					Thread.Sleep(1);
				}

				// jaka stinx
				if (jaka.WasCancelled || jaka.Username.Length == 0 || jaka.Password.Length == 0)
					Environment.Exit(0);

				username = jaka.Username;
				type = jaka.PlanType;

				password = new System.Security.SecureString();
				foreach (var x in jaka.Password) password.AppendChar(x);
				password.MakeReadOnly();
			}
		}
	}

	public enum PlanType
	{
		Standard,
		Premium,
		Blue,
		Gold,
		Platinum
	}
}
