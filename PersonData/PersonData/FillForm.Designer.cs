using System;
using System.Windows.Forms;

namespace People
{
    partial class FillForm
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
            this.btnExit = new System.Windows.Forms.Button();
            this.dgvPeople = new System.Windows.Forms.DataGridView();
            this.personId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.personName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBoxFilterCountries = new System.Windows.Forms.ComboBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnDatabase = new System.Windows.Forms.Button();
            this.labelCountries = new System.Windows.Forms.Label();
            this.comboBoxFilterNames = new System.Windows.Forms.ComboBox();
            this.labelNames = new System.Windows.Forms.Label();
            this.panelDeleteFilter = new System.Windows.Forms.Panel();
            this.labelDeleteFilter = new System.Windows.Forms.Label();
            this.panelUpdate = new System.Windows.Forms.Panel();
            this.btnGetPhoneNumber = new System.Windows.Forms.Button();
            this.labelPhoneNumber = new System.Windows.Forms.Label();
            this.labelGetPhoneNumber = new System.Windows.Forms.Label();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.textBoxPhoneNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelUpdate = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.radioButtonOld = new System.Windows.Forms.RadioButton();
            this.textBoxCurrent = new System.Windows.Forms.TextBox();
            this.textBoxNew = new System.Windows.Forms.TextBox();
            this.textBoxOld = new System.Windows.Forms.TextBox();
            this.radioButtonNew = new System.Windows.Forms.RadioButton();
            this.radioButtonCurrent = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).BeginInit();
            this.panelDeleteFilter.SuspendLayout();
            this.panelUpdate.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(699, 450);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 28);
            this.btnExit.TabIndex = 28;
            this.btnExit.Text = "Kilép";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dgvPeople
            // 
            this.dgvPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeople.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.personId,
            this.personName,
            this.countryID,
            this.countryName,
            this.phoneNumber});
            this.dgvPeople.Location = new System.Drawing.Point(43, 346);
            this.dgvPeople.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPeople.MultiSelect = false;
            this.dgvPeople.Name = "dgvPeople";
            this.dgvPeople.ReadOnly = true;
            this.dgvPeople.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPeople.Size = new System.Drawing.Size(597, 247);
            this.dgvPeople.TabIndex = 26;
            this.dgvPeople.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPeople_CellContentClick);
            // 
            // personId
            // 
            this.personId.HeaderText = "Személyiszám";
            this.personId.Name = "personId";
            this.personId.ReadOnly = true;
            // 
            // personName
            // 
            this.personName.HeaderText = "Név";
            this.personName.Name = "personName";
            this.personName.ReadOnly = true;
            // 
            // countryID
            // 
            this.countryID.HeaderText = "Ország";
            this.countryID.Name = "countryID";
            this.countryID.ReadOnly = true;
            this.countryID.Visible = false;
            // 
            // countryName
            // 
            this.countryName.HeaderText = "Ország";
            this.countryName.Name = "countryName";
            this.countryName.ReadOnly = true;
            // 
            // phoneNumber
            // 
            this.phoneNumber.HeaderText = "Telefonszám";
            this.phoneNumber.Name = "phoneNumber";
            this.phoneNumber.ReadOnly = true;
            // 
            // comboBoxFilterCountries
            // 
            this.comboBoxFilterCountries.Enabled = false;
            this.comboBoxFilterCountries.FormattingEnabled = true;
            this.comboBoxFilterCountries.Location = new System.Drawing.Point(120, 91);
            this.comboBoxFilterCountries.Name = "comboBoxFilterCountries";
            this.comboBoxFilterCountries.Size = new System.Drawing.Size(159, 24);
            this.comboBoxFilterCountries.TabIndex = 29;
            this.comboBoxFilterCountries.SelectedIndexChanged += new System.EventHandler(this.comboBoxFilterCountries_SelectedIndexChanged_1);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(118, 146);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(80, 24);
            this.btnFilter.TabIndex = 32;
            this.btnFilter.Text = "Szűr";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(117, 196);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 24);
            this.btnDelete.TabIndex = 34;
            this.btnDelete.Text = "Töröl";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnDatabase
            // 
            this.btnDatabase.Location = new System.Drawing.Point(663, 392);
            this.btnDatabase.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDatabase.Name = "btnDatabase";
            this.btnDatabase.Size = new System.Drawing.Size(172, 28);
            this.btnDatabase.TabIndex = 37;
            this.btnDatabase.Text = "Adatbázis tartalma";
            this.btnDatabase.UseVisualStyleBackColor = true;
            this.btnDatabase.Click += new System.EventHandler(this.btnDatabase_Click);
            // 
            // labelCountries
            // 
            this.labelCountries.AutoSize = true;
            this.labelCountries.Location = new System.Drawing.Point(22, 93);
            this.labelCountries.Name = "labelCountries";
            this.labelCountries.Size = new System.Drawing.Size(96, 17);
            this.labelCountries.TabIndex = 35;
            this.labelCountries.Text = "Országnevek:";
            // 
            // comboBoxFilterNames
            // 
            this.comboBoxFilterNames.FormattingEnabled = true;
            this.comboBoxFilterNames.Location = new System.Drawing.Point(120, 29);
            this.comboBoxFilterNames.Name = "comboBoxFilterNames";
            this.comboBoxFilterNames.Size = new System.Drawing.Size(159, 24);
            this.comboBoxFilterNames.TabIndex = 33;
            // 
            // labelNames
            // 
            this.labelNames.AutoSize = true;
            this.labelNames.Location = new System.Drawing.Point(15, 32);
            this.labelNames.Name = "labelNames";
            this.labelNames.Size = new System.Drawing.Size(103, 17);
            this.labelNames.TabIndex = 36;
            this.labelNames.Text = "Személynevek:";
            // 
            // panelDeleteFilter
            // 
            this.panelDeleteFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDeleteFilter.Controls.Add(this.labelNames);
            this.panelDeleteFilter.Controls.Add(this.btnDelete);
            this.panelDeleteFilter.Controls.Add(this.labelCountries);
            this.panelDeleteFilter.Controls.Add(this.btnFilter);
            this.panelDeleteFilter.Controls.Add(this.comboBoxFilterNames);
            this.panelDeleteFilter.Controls.Add(this.comboBoxFilterCountries);
            this.panelDeleteFilter.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panelDeleteFilter.Location = new System.Drawing.Point(41, 55);
            this.panelDeleteFilter.Margin = new System.Windows.Forms.Padding(0);
            this.panelDeleteFilter.Name = "panelDeleteFilter";
            this.panelDeleteFilter.Size = new System.Drawing.Size(338, 270);
            this.panelDeleteFilter.TabIndex = 38;
            this.panelDeleteFilter.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // labelDeleteFilter
            // 
            this.labelDeleteFilter.AutoSize = true;
            this.labelDeleteFilter.Location = new System.Drawing.Point(57, 48);
            this.labelDeleteFilter.Name = "labelDeleteFilter";
            this.labelDeleteFilter.Size = new System.Drawing.Size(110, 17);
            this.labelDeleteFilter.TabIndex = 39;
            this.labelDeleteFilter.Text = "Szűrés és törlés";
            this.labelDeleteFilter.Click += new System.EventHandler(this.label1_Click);
            // 
            // panelUpdate
            // 
            this.panelUpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelUpdate.Controls.Add(this.radioButtonCurrent);
            this.panelUpdate.Controls.Add(this.radioButtonNew);
            this.panelUpdate.Controls.Add(this.radioButtonOld);
            this.panelUpdate.Controls.Add(this.buttonSave);
            this.panelUpdate.Controls.Add(this.textBoxCurrent);
            this.panelUpdate.Controls.Add(this.textBoxNew);
            this.panelUpdate.Controls.Add(this.textBoxOld);
            this.panelUpdate.Controls.Add(this.btnGetPhoneNumber);
            this.panelUpdate.Controls.Add(this.labelPhoneNumber);
            this.panelUpdate.Controls.Add(this.labelGetPhoneNumber);
            this.panelUpdate.Controls.Add(this.buttonUpdate);
            this.panelUpdate.Controls.Add(this.textBoxPhoneNumber);
            this.panelUpdate.Controls.Add(this.label1);
            this.panelUpdate.Location = new System.Drawing.Point(401, 55);
            this.panelUpdate.Name = "panelUpdate";
            this.panelUpdate.Size = new System.Drawing.Size(425, 270);
            this.panelUpdate.TabIndex = 40;
            this.panelUpdate.Paint += new System.Windows.Forms.PaintEventHandler(this.panelUpdate_Paint);
            // 
            // btnGetPhoneNumber
            // 
            this.btnGetPhoneNumber.Location = new System.Drawing.Point(15, 93);
            this.btnGetPhoneNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGetPhoneNumber.Name = "btnGetPhoneNumber";
            this.btnGetPhoneNumber.Size = new System.Drawing.Size(80, 24);
            this.btnGetPhoneNumber.TabIndex = 46;
            this.btnGetPhoneNumber.Text = "Mehet";
            this.btnGetPhoneNumber.UseVisualStyleBackColor = true;
            this.btnGetPhoneNumber.Click += new System.EventHandler(this.btnGetPhoneNumber_Click);
            // 
            // labelPhoneNumber
            // 
            this.labelPhoneNumber.AutoSize = true;
            this.labelPhoneNumber.Location = new System.Drawing.Point(236, 73);
            this.labelPhoneNumber.Name = "labelPhoneNumber";
            this.labelPhoneNumber.Size = new System.Drawing.Size(0, 17);
            this.labelPhoneNumber.TabIndex = 45;
            // 
            // labelGetPhoneNumber
            // 
            this.labelGetPhoneNumber.AutoSize = true;
            this.labelGetPhoneNumber.Location = new System.Drawing.Point(12, 67);
            this.labelGetPhoneNumber.Name = "labelGetPhoneNumber";
            this.labelGetPhoneNumber.Size = new System.Drawing.Size(205, 17);
            this.labelGetPhoneNumber.TabIndex = 44;
            this.labelGetPhoneNumber.Text = "Személy aktuális telefonszáma:";
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(325, 25);
            this.buttonUpdate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(80, 23);
            this.buttonUpdate.TabIndex = 37;
            this.buttonUpdate.Text = "Módosít";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // textBoxPhoneNumber
            // 
            this.textBoxPhoneNumber.Location = new System.Drawing.Point(124, 24);
            this.textBoxPhoneNumber.Name = "textBoxPhoneNumber";
            this.textBoxPhoneNumber.Size = new System.Drawing.Size(157, 22);
            this.textBoxPhoneNumber.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 17);
            this.label1.TabIndex = 42;
            this.label1.Text = "Telefonszám:";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // labelUpdate
            // 
            this.labelUpdate.AutoSize = true;
            this.labelUpdate.Location = new System.Drawing.Point(442, 47);
            this.labelUpdate.Name = "labelUpdate";
            this.labelUpdate.Size = new System.Drawing.Size(72, 17);
            this.labelUpdate.TabIndex = 41;
            this.labelUpdate.Text = "Módosítás";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(315, 216);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 51;
            this.buttonSave.Text = "Mentés";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Visible = false;
            this.buttonSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // radioButtonOld
            // 
            this.radioButtonOld.AutoSize = true;
            this.radioButtonOld.Location = new System.Drawing.Point(185, 137);
            this.radioButtonOld.Name = "radioButtonOld";
            this.radioButtonOld.Size = new System.Drawing.Size(94, 21);
            this.radioButtonOld.TabIndex = 52;
            this.radioButtonOld.TabStop = true;
            this.radioButtonOld.Text = "Régi érték";
            this.radioButtonOld.UseVisualStyleBackColor = true;
            this.radioButtonOld.Visible = false;
            // 
            // textBoxCurrent
            // 
            this.textBoxCurrent.Location = new System.Drawing.Point(15, 216);
            this.textBoxCurrent.Name = "textBoxCurrent";
            this.textBoxCurrent.ReadOnly = true;
            this.textBoxCurrent.Size = new System.Drawing.Size(164, 22);
            this.textBoxCurrent.TabIndex = 50;
            this.textBoxCurrent.Visible = false;
            // 
            // textBoxNew
            // 
            this.textBoxNew.Location = new System.Drawing.Point(15, 176);
            this.textBoxNew.Name = "textBoxNew";
            this.textBoxNew.ReadOnly = true;
            this.textBoxNew.Size = new System.Drawing.Size(164, 22);
            this.textBoxNew.TabIndex = 49;
            this.textBoxNew.Visible = false;
            // 
            // textBoxOld
            // 
            this.textBoxOld.Location = new System.Drawing.Point(15, 137);
            this.textBoxOld.Name = "textBoxOld";
            this.textBoxOld.ReadOnly = true;
            this.textBoxOld.Size = new System.Drawing.Size(164, 22);
            this.textBoxOld.TabIndex = 48;
            this.textBoxOld.Visible = false;
            // 
            // radioButtonNew
            // 
            this.radioButtonNew.AutoSize = true;
            this.radioButtonNew.Location = new System.Drawing.Point(185, 177);
            this.radioButtonNew.Name = "radioButtonNew";
            this.radioButtonNew.Size = new System.Drawing.Size(78, 21);
            this.radioButtonNew.TabIndex = 53;
            this.radioButtonNew.TabStop = true;
            this.radioButtonNew.Text = "Új érték";
            this.radioButtonNew.UseVisualStyleBackColor = true;
            this.radioButtonNew.Visible = false;
            this.radioButtonNew.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButtonCurrent
            // 
            this.radioButtonCurrent.AutoSize = true;
            this.radioButtonCurrent.Location = new System.Drawing.Point(185, 216);
            this.radioButtonCurrent.Name = "radioButtonCurrent";
            this.radioButtonCurrent.Size = new System.Drawing.Size(114, 21);
            this.radioButtonCurrent.TabIndex = 54;
            this.radioButtonCurrent.TabStop = true;
            this.radioButtonCurrent.Text = "Aktuális érték";
            this.radioButtonCurrent.UseVisualStyleBackColor = true;
            this.radioButtonCurrent.Visible = false;
            this.radioButtonCurrent.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // FillForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(928, 638);
            this.Controls.Add(this.labelUpdate);
            this.Controls.Add(this.labelDeleteFilter);
            this.Controls.Add(this.btnDatabase);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dgvPeople);
            this.Controls.Add(this.panelDeleteFilter);
            this.Controls.Add(this.panelUpdate);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FillForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FillForm";
            this.Load += new System.EventHandler(this.FillForm_Load);
            this.Shown += new System.EventHandler(this.FillForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).EndInit();
            this.panelDeleteFilter.ResumeLayout(false);
            this.panelDeleteFilter.PerformLayout();
            this.panelUpdate.ResumeLayout(false);
            this.panelUpdate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void label2_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void dgvPeople_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        #endregion
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView dgvPeople;
        private System.Windows.Forms.DataGridViewTextBoxColumn personId;
        private System.Windows.Forms.DataGridViewTextBoxColumn personName;
        private System.Windows.Forms.DataGridViewTextBoxColumn countryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn countryName;
        private System.Windows.Forms.ComboBox comboBoxFilterCountries;
        private System.Windows.Forms.Button btnFilter;
        private DataGridViewTextBoxColumn phoneNumber;
        private Button btnDelete;
        private Button btnDatabase;
        private Label labelCountries;
        private ComboBox comboBoxFilterNames;
        private Label labelNames;
        private Panel panelDeleteFilter;
        private Label labelDeleteFilter;
        private Panel panelUpdate;
        private Label labelUpdate;
        private Button buttonUpdate;
        private TextBox textBoxPhoneNumber;
        private Label label1;
        private System.Windows.Forms.Button btnGetPhoneNumber;
        private Label labelPhoneNumber;
        private System.Windows.Forms.Label labelGetPhoneNumber;
        private Button buttonSave;
        private RadioButton radioButtonOld;
        private TextBox textBoxCurrent;
        private TextBox textBoxNew;
        private TextBox textBoxOld;
        private RadioButton radioButtonCurrent;
        private RadioButton radioButtonNew;
    }
}