using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace CalDiningOracle
{
	public partial class natto : Form
	{
		private readonly TimeSpan WEEK = TimeSpan.FromDays(7);

		private nattoenemies[] transactions;

		private decimal baseline, perweek;

		public natto(nattoenemies[] transactions, PlanType t)
		{
			this.transactions = transactions;

			baseline = pointPresets[t].Item1;
			perweek = pointPresets[t].Item2;

			InitializeComponent();
		}

		private void natto_Load(object sender, EventArgs e)
		{
			decimal points = baseline;
			foreach (var x in transactions)
				PointsChart.Series["Point History"].Points.AddXY(x.Date, (points -= x.Amount));

			decimal expected = baseline;
			DateTime start = transactions.Min((x) => x.Date), end = transactions.Max((x) => x.Date);
			for (DateTime t = start; t < new DateTime(2012, 12, 15); t += WEEK, expected -= perweek)
				PointsChart.Series["Normal Usage"].Points.AddXY(t, expected);
		}

		private readonly Dictionary<PlanType, Tuple<decimal, decimal>> pointPresets = new Dictionary<PlanType, Tuple<decimal,decimal>> {
			{PlanType.Standard,	Tuple.Create((decimal) 1250, (decimal) 74)},
			{PlanType.Premium,	Tuple.Create((decimal) 1500, (decimal) 88)},
			{PlanType.Blue,		Tuple.Create((decimal) 650,  (decimal) 38)},
			{PlanType.Gold,		Tuple.Create((decimal) 925,  (decimal) 54)},
			{PlanType.Platinum,	Tuple.Create((decimal) 1200, (decimal) 71)},
		};
	}
}
