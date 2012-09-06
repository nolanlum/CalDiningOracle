namespace CalDiningOracle
{
	partial class jaka
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtUsername = new System.Windows.Forms.TextBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnLogin = new System.Windows.Forms.Button();
			this.cmbMealPlan = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(35, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Username:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(37, 38);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Password:";
			// 
			// txtUsername
			// 
			this.txtUsername.Location = new System.Drawing.Point(99, 6);
			this.txtUsername.Name = "txtUsername";
			this.txtUsername.Size = new System.Drawing.Size(181, 20);
			this.txtUsername.TabIndex = 2;
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(99, 35);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size(181, 20);
			this.txtPassword.TabIndex = 3;
			this.txtPassword.UseSystemPasswordChar = true;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(48, 88);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnLogin
			// 
			this.btnLogin.Location = new System.Drawing.Point(169, 88);
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new System.Drawing.Size(75, 23);
			this.btnLogin.TabIndex = 5;
			this.btnLogin.Text = "Login";
			this.btnLogin.UseVisualStyleBackColor = true;
			this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
			// 
			// cmbMealPlan
			// 
			this.cmbMealPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbMealPlan.FormattingEnabled = true;
			this.cmbMealPlan.Items.AddRange(new object[] {
            "Standard",
            "Premium",
            "Blue",
            "Gold",
            "Platinum"});
			this.cmbMealPlan.Location = new System.Drawing.Point(99, 61);
			this.cmbMealPlan.Name = "cmbMealPlan";
			this.cmbMealPlan.Size = new System.Drawing.Size(181, 21);
			this.cmbMealPlan.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(84, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Meal Plan Type:";
			// 
			// jaka
			// 
			this.AcceptButton = this.btnLogin;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(292, 123);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cmbMealPlan);
			this.Controls.Add(this.btnLogin);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.txtUsername);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "jaka";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Enter your CalNet Credentials";
			this.Load += new System.EventHandler(this.jaka_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtUsername;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnLogin;
		private System.Windows.Forms.ComboBox cmbMealPlan;
		private System.Windows.Forms.Label label3;
	}
}