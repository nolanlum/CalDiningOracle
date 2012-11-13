namespace CalDiningOracle
{
	partial class natto
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.PointsChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			((System.ComponentModel.ISupportInitialize)(this.PointsChart)).BeginInit();
			this.SuspendLayout();
			// 
			// PointsChart
			// 
			this.PointsChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			chartArea1.AxisX.Title = "Date";
			chartArea1.AxisY.Crossing = -1.7976931348623157E+308D;
			chartArea1.AxisY.Minimum = 0D;
			chartArea1.AxisY.Title = "Meal Points";
			chartArea1.Name = "PointsVsTime";
			this.PointsChart.ChartAreas.Add(chartArea1);
			legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
			legend1.Name = "Legend1";
			this.PointsChart.Legends.Add(legend1);
			this.PointsChart.Location = new System.Drawing.Point(12, 12);
			this.PointsChart.Name = "PointsChart";
			series1.ChartArea = "PointsVsTime";
			series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series1.Legend = "Legend1";
			series1.MarkerSize = 3;
			series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
			series1.Name = "Point History";
			series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
			series1.YValuesPerPoint = 2;
			series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
			series2.ChartArea = "PointsVsTime";
			series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series2.Legend = "Legend1";
			series2.Name = "Normal Usage";
			series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
			series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
			series3.ChartArea = "PointsVsTime";
			series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
			series3.IsValueShownAsLabel = true;
			series3.IsVisibleInLegend = false;
			series3.Legend = "Legend1";
			series3.MarkerSize = 7;
			series3.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square;
			series3.Name = "Current";
			series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
			series3.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
			this.PointsChart.Series.Add(series1);
			this.PointsChart.Series.Add(series2);
			this.PointsChart.Series.Add(series3);
			this.PointsChart.Size = new System.Drawing.Size(768, 501);
			this.PointsChart.TabIndex = 0;
			this.PointsChart.Text = "PointsChart";
			// 
			// natto
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(792, 525);
			this.Controls.Add(this.PointsChart);
			this.Name = "natto";
			this.Text = "Cal Dining Oracle";
			this.Load += new System.EventHandler(this.natto_Load);
			((System.ComponentModel.ISupportInitialize)(this.PointsChart)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataVisualization.Charting.Chart PointsChart;
	}
}

