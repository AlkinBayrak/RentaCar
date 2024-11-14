namespace RentAndSell.Car.FormApp
{
	partial class LoginPage
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
			txtUserName = new TextBox();
			txtPassword = new TextBox();
			btnLogin = new Button();
			btnRegister = new Button();
			groupBox1 = new GroupBox();
			lblMessage = new Label();
			groupBox1.SuspendLayout();
			SuspendLayout();
			// 
			// txtUserName
			// 
			txtUserName.Location = new Point(61, 44);
			txtUserName.Name = "txtUserName";
			txtUserName.PlaceholderText = "Kullanıcı Adı";
			txtUserName.Size = new Size(156, 23);
			txtUserName.TabIndex = 0;
			// 
			// txtPassword
			// 
			txtPassword.Location = new Point(61, 85);
			txtPassword.Name = "txtPassword";
			txtPassword.PasswordChar = '*';
			txtPassword.PlaceholderText = "Şifre";
			txtPassword.Size = new Size(156, 23);
			txtPassword.TabIndex = 1;
			// 
			// btnLogin
			// 
			btnLogin.Location = new Point(61, 127);
			btnLogin.Name = "btnLogin";
			btnLogin.Size = new Size(75, 23);
			btnLogin.TabIndex = 2;
			btnLogin.Text = "Giriş";
			btnLogin.UseVisualStyleBackColor = true;
			btnLogin.Click += btnLogin_Click;
			// 
			// btnRegister
			// 
			btnRegister.Location = new Point(142, 127);
			btnRegister.Name = "btnRegister";
			btnRegister.Size = new Size(75, 23);
			btnRegister.TabIndex = 3;
			btnRegister.Text = "Kayıt Ol";
			btnRegister.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(lblMessage);
			groupBox1.Controls.Add(txtUserName);
			groupBox1.Controls.Add(btnRegister);
			groupBox1.Controls.Add(txtPassword);
			groupBox1.Controls.Add(btnLogin);
			groupBox1.Location = new Point(32, 25);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(546, 186);
			groupBox1.TabIndex = 4;
			groupBox1.TabStop = false;
			groupBox1.Text = "YENİ KAYIT";
			// 
			// lblMessage
			// 
			lblMessage.Location = new Point(323, 19);
			lblMessage.Name = "lblMessage";
			lblMessage.Size = new Size(208, 153);
			lblMessage.TabIndex = 5;
			lblMessage.Text = "Mesajlar";
			// 
			// LoginPage
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(590, 249);
			Controls.Add(groupBox1);
			Name = "LoginPage";
			Text = "LoginPage";
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private TextBox txtUserName;
		private TextBox txtPassword;
		private Button btnLogin;
		private Button btnRegister;
		private GroupBox groupBox1;
		private Label lblMessage;
	}
}