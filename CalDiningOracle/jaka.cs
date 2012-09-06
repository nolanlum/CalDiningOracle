using System;
using System.Windows.Forms;

namespace CalDiningOracle
{
	public partial class jaka : Form
	{
		public string Username { get { return txtUsername.Text; } }
		public string Password { get { return txtPassword.Text; } }
		public bool WasCancelled { get; private set; }

		public PlanType PlanType { get { return (PlanType) Enum.Parse(typeof(PlanType), cmbMealPlan.Text); } }

		public jaka()
		{
			InitializeComponent();
		}

		private void jaka_Load(object sender, EventArgs e)
		{
			this.cmbMealPlan.SelectedIndex = 0;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			WasCancelled = true;
			this.Hide();
		}

		private void btnLogin_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		public void PasswordWasWrong()
		{
			this.Text = "Username or password was incorrect!";
		}
	}
}
