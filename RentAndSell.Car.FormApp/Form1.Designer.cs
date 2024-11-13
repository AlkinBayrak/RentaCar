namespace RentAndSell.Car.FormApp
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			groupBox1 = new GroupBox();
			btnSil = new Button();
			btnGuncelle = new Button();
			cBoxYil = new ComboBox();
			btnSave = new Button();
			cBoxSanzimanTipi = new ComboBox();
			cBoxMotorTipi = new ComboBox();
			cBoxYakitTuru = new ComboBox();
			txtModel = new TextBox();
			txtMarka = new TextBox();
			nbrUpDownYil = new NumericUpDown();
			txtYili = new TextBox();
			dgvArabaList = new DataGridView();
			idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			markaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			modelDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			motorTipiDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			yakitTuruDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			sanzimanTipiDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			yiliDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
			arabaViewModelBindingSource = new BindingSource(components);
			txtId = new TextBox();
			groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nbrUpDownYil).BeginInit();
			((System.ComponentModel.ISupportInitialize)dgvArabaList).BeginInit();
			((System.ComponentModel.ISupportInitialize)arabaViewModelBindingSource).BeginInit();
			SuspendLayout();
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(txtId);
			groupBox1.Controls.Add(btnSil);
			groupBox1.Controls.Add(btnGuncelle);
			groupBox1.Controls.Add(cBoxYil);
			groupBox1.Controls.Add(btnSave);
			groupBox1.Controls.Add(cBoxSanzimanTipi);
			groupBox1.Controls.Add(cBoxMotorTipi);
			groupBox1.Controls.Add(cBoxYakitTuru);
			groupBox1.Controls.Add(txtModel);
			groupBox1.Controls.Add(txtMarka);
			groupBox1.Location = new Point(12, 12);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(267, 459);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			groupBox1.Text = "YENİ KAYIT";
			// 
			// btnSil
			// 
			btnSil.Location = new Point(182, 221);
			btnSil.Name = "btnSil";
			btnSil.Size = new Size(75, 23);
			btnSil.TabIndex = 10;
			btnSil.Text = "SİL";
			btnSil.UseVisualStyleBackColor = true;
			// 
			// btnGuncelle
			// 
			btnGuncelle.Location = new Point(101, 221);
			btnGuncelle.Name = "btnGuncelle";
			btnGuncelle.Size = new Size(75, 23);
			btnGuncelle.TabIndex = 9;
			btnGuncelle.Text = "GUNCELLE";
			btnGuncelle.UseVisualStyleBackColor = true;
			// 
			// cBoxYil
			// 
			cBoxYil.DropDownStyle = ComboBoxStyle.DropDownList;
			cBoxYil.FormattingEnabled = true;
			cBoxYil.Location = new Point(20, 80);
			cBoxYil.Name = "cBoxYil";
			cBoxYil.Size = new Size(237, 23);
			cBoxYil.TabIndex = 8;
			// 
			// btnSave
			// 
			btnSave.Location = new Point(20, 221);
			btnSave.Name = "btnSave";
			btnSave.Size = new Size(75, 23);
			btnSave.TabIndex = 6;
			btnSave.Text = "KAYDET";
			btnSave.UseVisualStyleBackColor = true;
			btnSave.Click += btnSave_Click;
			// 
			// cBoxSanzimanTipi
			// 
			cBoxSanzimanTipi.DropDownStyle = ComboBoxStyle.DropDownList;
			cBoxSanzimanTipi.FormattingEnabled = true;
			cBoxSanzimanTipi.Location = new Point(21, 179);
			cBoxSanzimanTipi.Name = "cBoxSanzimanTipi";
			cBoxSanzimanTipi.Size = new Size(237, 23);
			cBoxSanzimanTipi.TabIndex = 5;
			// 
			// cBoxMotorTipi
			// 
			cBoxMotorTipi.DropDownStyle = ComboBoxStyle.DropDownList;
			cBoxMotorTipi.FormattingEnabled = true;
			cBoxMotorTipi.Location = new Point(21, 150);
			cBoxMotorTipi.Name = "cBoxMotorTipi";
			cBoxMotorTipi.Size = new Size(237, 23);
			cBoxMotorTipi.TabIndex = 4;
			// 
			// cBoxYakitTuru
			// 
			cBoxYakitTuru.DropDownStyle = ComboBoxStyle.DropDownList;
			cBoxYakitTuru.FormattingEnabled = true;
			cBoxYakitTuru.Location = new Point(20, 121);
			cBoxYakitTuru.Name = "cBoxYakitTuru";
			cBoxYakitTuru.Size = new Size(237, 23);
			cBoxYakitTuru.TabIndex = 3;
			// 
			// txtModel
			// 
			txtModel.Location = new Point(20, 51);
			txtModel.Name = "txtModel";
			txtModel.PlaceholderText = "Model";
			txtModel.Size = new Size(237, 23);
			txtModel.TabIndex = 1;
			// 
			// txtMarka
			// 
			txtMarka.Location = new Point(20, 22);
			txtMarka.Name = "txtMarka";
			txtMarka.PlaceholderText = "Marka";
			txtMarka.Size = new Size(237, 23);
			txtMarka.TabIndex = 0;
			// 
			// nbrUpDownYil
			// 
			nbrUpDownYil.Location = new Point(12, 521);
			nbrUpDownYil.Maximum = new decimal(new int[] { 2024, 0, 0, 0 });
			nbrUpDownYil.Minimum = new decimal(new int[] { 1940, 0, 0, 0 });
			nbrUpDownYil.Name = "nbrUpDownYil";
			nbrUpDownYil.Size = new Size(120, 23);
			nbrUpDownYil.TabIndex = 7;
			nbrUpDownYil.Value = new decimal(new int[] { 1940, 0, 0, 0 });
			nbrUpDownYil.Visible = false;
			// 
			// txtYili
			// 
			txtYili.Location = new Point(12, 492);
			txtYili.Name = "txtYili";
			txtYili.PlaceholderText = "Yıl";
			txtYili.Size = new Size(121, 23);
			txtYili.TabIndex = 2;
			txtYili.Visible = false;
			// 
			// dgvArabaList
			// 
			dgvArabaList.AutoGenerateColumns = false;
			dgvArabaList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvArabaList.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, markaDataGridViewTextBoxColumn, modelDataGridViewTextBoxColumn, motorTipiDataGridViewTextBoxColumn, yakitTuruDataGridViewTextBoxColumn, sanzimanTipiDataGridViewTextBoxColumn, yiliDataGridViewTextBoxColumn });
			dgvArabaList.DataSource = arabaViewModelBindingSource;
			dgvArabaList.Location = new Point(285, 22);
			dgvArabaList.MultiSelect = false;
			dgvArabaList.Name = "dgvArabaList";
			dgvArabaList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvArabaList.Size = new Size(746, 449);
			dgvArabaList.TabIndex = 1;
			dgvArabaList.CellDoubleClick += dgvArabaList_CellDoubleClick;
			// 
			// idDataGridViewTextBoxColumn
			// 
			idDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			idDataGridViewTextBoxColumn.DataPropertyName = "Id";
			idDataGridViewTextBoxColumn.HeaderText = "Id";
			idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
			idDataGridViewTextBoxColumn.Width = 42;
			// 
			// markaDataGridViewTextBoxColumn
			// 
			markaDataGridViewTextBoxColumn.DataPropertyName = "Marka";
			markaDataGridViewTextBoxColumn.HeaderText = "Marka";
			markaDataGridViewTextBoxColumn.Name = "markaDataGridViewTextBoxColumn";
			// 
			// modelDataGridViewTextBoxColumn
			// 
			modelDataGridViewTextBoxColumn.DataPropertyName = "Model";
			modelDataGridViewTextBoxColumn.HeaderText = "Model";
			modelDataGridViewTextBoxColumn.Name = "modelDataGridViewTextBoxColumn";
			// 
			// motorTipiDataGridViewTextBoxColumn
			// 
			motorTipiDataGridViewTextBoxColumn.DataPropertyName = "MotorTipi";
			motorTipiDataGridViewTextBoxColumn.HeaderText = "MotorTipi";
			motorTipiDataGridViewTextBoxColumn.Name = "motorTipiDataGridViewTextBoxColumn";
			// 
			// yakitTuruDataGridViewTextBoxColumn
			// 
			yakitTuruDataGridViewTextBoxColumn.DataPropertyName = "YakitTuru";
			yakitTuruDataGridViewTextBoxColumn.HeaderText = "YakitTuru";
			yakitTuruDataGridViewTextBoxColumn.Name = "yakitTuruDataGridViewTextBoxColumn";
			// 
			// sanzimanTipiDataGridViewTextBoxColumn
			// 
			sanzimanTipiDataGridViewTextBoxColumn.DataPropertyName = "SanzimanTipi";
			sanzimanTipiDataGridViewTextBoxColumn.HeaderText = "SanzimanTipi";
			sanzimanTipiDataGridViewTextBoxColumn.Name = "sanzimanTipiDataGridViewTextBoxColumn";
			// 
			// yiliDataGridViewTextBoxColumn
			// 
			yiliDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
			yiliDataGridViewTextBoxColumn.DataPropertyName = "Yili";
			yiliDataGridViewTextBoxColumn.HeaderText = "Yili";
			yiliDataGridViewTextBoxColumn.Name = "yiliDataGridViewTextBoxColumn";
			yiliDataGridViewTextBoxColumn.Width = 48;
			// 
			// arabaViewModelBindingSource
			// 
			arabaViewModelBindingSource.DataSource = typeof(Models.ArabaViewModel);
			// 
			// txtId
			// 
			txtId.Location = new Point(20, 250);
			txtId.Name = "txtId";
			txtId.PlaceholderText = "Record ID";
			txtId.Size = new Size(100, 23);
			txtId.TabIndex = 11;
			txtId.Visible = false;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1043, 555);
			Controls.Add(dgvArabaList);
			Controls.Add(nbrUpDownYil);
			Controls.Add(groupBox1);
			Controls.Add(txtYili);
			Name = "Form1";
			Text = "Form1";
			Load += Form1_Load;
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nbrUpDownYil).EndInit();
			((System.ComponentModel.ISupportInitialize)dgvArabaList).EndInit();
			((System.ComponentModel.ISupportInitialize)arabaViewModelBindingSource).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private GroupBox groupBox1;
		private DataGridView dgvArabaList;
		private ComboBox cBoxSanzimanTipi;
		private ComboBox cBoxMotorTipi;
		private ComboBox cBoxYakitTuru;
		private TextBox txtYili;
		private TextBox txtModel;
		private TextBox txtMarka;
		private Button btnSave;
		private NumericUpDown nbrUpDownYil;
		private ComboBox cBoxYil;
		private Button btnSil;
		private Button btnGuncelle;
		private BindingSource arabaViewModelBindingSource;
		private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn markaDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn modelDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn motorTipiDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn yakitTuruDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn sanzimanTipiDataGridViewTextBoxColumn;
		private DataGridViewTextBoxColumn yiliDataGridViewTextBoxColumn;
		private TextBox txtId;
	}
}
