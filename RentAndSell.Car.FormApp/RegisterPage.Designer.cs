namespace RentAndSell.Car.FormApp
{
	partial class RegisterPage
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
			groupBox1 = new GroupBox();
			lblMessage = new Label();
			btnLogin = new Button();
			btnSave = new Button();
			txtPasswordAgain = new TextBox();
			txtPassword = new TextBox();
			txtUserName = new TextBox();
			txtEmail = new TextBox();
			txtSurname = new TextBox();
			txtName = new TextBox();
			groupBox1.SuspendLayout();
			SuspendLayout();
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(lblMessage);
			groupBox1.Controls.Add(btnLogin);
			groupBox1.Controls.Add(btnSave);
			groupBox1.Controls.Add(txtPasswordAgain);
			groupBox1.Controls.Add(txtPassword);
			groupBox1.Controls.Add(txtUserName);
			groupBox1.Controls.Add(txtEmail);
			groupBox1.Controls.Add(txtSurname);
			groupBox1.Controls.Add(txtName);
			groupBox1.Location = new Point(21, 12);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(473, 324);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			groupBox1.Text = "YENİ KAYIT";
			// 
			// lblMessage
			// 
			lblMessage.Location = new Point(226, 31);
			lblMessage.Name = "lblMessage";
			lblMessage.Size = new Size(165, 168);
			lblMessage.TabIndex = 8;
			lblMessage.Text = "Mesajlar";
			// 
			// btnLogin
			// 
			btnLogin.Location = new Point(106, 205);
			btnLogin.Name = "btnLogin";
			btnLogin.Size = new Size(75, 23);
			btnLogin.TabIndex = 7;
			btnLogin.Text = "GİRİŞE GİT";
			btnLogin.UseVisualStyleBackColor = true;
			// 
			// btnSave
			// 
			btnSave.Location = new Point(25, 205);
			btnSave.Name = "btnSave";
			btnSave.Size = new Size(75, 23);
			btnSave.TabIndex = 6;
			btnSave.Text = "KAYDET";
			btnSave.UseVisualStyleBackColor = true;
			// 
			// txtPasswordAgain
			// 
			txtPasswordAgain.Location = new Point(25, 176);
			txtPasswordAgain.Name = "txtPasswordAgain";
			txtPasswordAgain.PasswordChar = '*';
			txtPasswordAgain.PlaceholderText = "Şifre Tekrarı";
			txtPasswordAgain.Size = new Size(156, 23);
			txtPasswordAgain.TabIndex = 5;
			// 
			// txtPassword
			// 
			txtPassword.Location = new Point(25, 147);
			txtPassword.Name = "txtPassword";
			txtPassword.PasswordChar = '*';
			txtPassword.PlaceholderText = "Şifreniz";
			txtPassword.Size = new Size(156, 23);
			txtPassword.TabIndex = 4;
			// 
			// txtUserName
			// 
			txtUserName.Location = new Point(25, 118);
			txtUserName.Name = "txtUserName";
			txtUserName.PlaceholderText = "Kullanıcı Adınız";
			txtUserName.Size = new Size(156, 23);
			txtUserName.TabIndex = 3;
			// 
			// txtEmail
			// 
			txtEmail.Location = new Point(25, 89);
			txtEmail.Name = "txtEmail";
			txtEmail.PlaceholderText = "E-Posta Adresiniz";
			txtEmail.Size = new Size(156, 23);
			txtEmail.TabIndex = 2;
			// 
			// txtSurname
			// 
			txtSurname.Location = new Point(25, 60);
			txtSurname.Name = "txtSurname";
			txtSurname.PlaceholderText = "Soyadınız";
			txtSurname.Size = new Size(156, 23);
			txtSurname.TabIndex = 1;
			// 
			// txtName
			// 
			txtName.Location = new Point(25, 31);
			txtName.Name = "txtName";
			txtName.PlaceholderText = "Adınız";
			txtName.Size = new Size(156, 23);
			txtName.TabIndex = 0;
			// 
			// RegisterPage
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(527, 353);
			Controls.Add(groupBox1);
			Name = "RegisterPage";
			Text = "RegisterPage";
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private GroupBox groupBox1;
		private TextBox txtEmail;
		private TextBox txtSurname;
		private TextBox txtName;
		private TextBox txtPasswordAgain;
		private TextBox txtPassword;
		private TextBox txtUserName;
		private Button btnLogin;
		private Button btnSave;
		private Label lblMessage;
	}
}