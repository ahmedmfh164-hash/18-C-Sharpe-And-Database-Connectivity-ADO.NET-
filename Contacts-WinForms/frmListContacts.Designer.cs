namespace Contacts
{
    partial class frmListContacts
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Button btnAddNewContact;
            this.dgvAllContacts = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGetAllCountries = new System.Windows.Forms.Button();
            this.btnGetAllContacts = new System.Windows.Forms.Button();
            btnAddNewContact = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllContacts)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddNewContact
            // 
            btnAddNewContact.BackColor = System.Drawing.SystemColors.ActiveCaption;
            btnAddNewContact.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            btnAddNewContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnAddNewContact.Location = new System.Drawing.Point(636, 28);
            btnAddNewContact.Name = "btnAddNewContact";
            btnAddNewContact.Size = new System.Drawing.Size(204, 50);
            btnAddNewContact.TabIndex = 1;
            btnAddNewContact.Text = "Add New Contact";
            btnAddNewContact.UseVisualStyleBackColor = false;
            btnAddNewContact.Click += new System.EventHandler(this.btnAddNewContact_Click);
            // 
            // dgvAllContacts
            // 
            this.dgvAllContacts.AllowUserToAddRows = false;
            this.dgvAllContacts.AllowUserToDeleteRows = false;
            this.dgvAllContacts.AllowUserToOrderColumns = true;
            this.dgvAllContacts.AllowUserToResizeRows = false;
            this.dgvAllContacts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvAllContacts.CausesValidation = false;
            this.dgvAllContacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllContacts.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvAllContacts.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvAllContacts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvAllContacts.Location = new System.Drawing.Point(0, 178);
            this.dgvAllContacts.Name = "dgvAllContacts";
            this.dgvAllContacts.ReadOnly = true;
            this.dgvAllContacts.Size = new System.Drawing.Size(960, 322);
            this.dgvAllContacts.TabIndex = 0;
            this.dgvAllContacts.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAllContacts_CellContentDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(108, 48);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // btnGetAllCountries
            // 
            this.btnGetAllCountries.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnGetAllCountries.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGetAllCountries.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetAllCountries.Location = new System.Drawing.Point(22, 26);
            this.btnGetAllCountries.Name = "btnGetAllCountries";
            this.btnGetAllCountries.Size = new System.Drawing.Size(199, 53);
            this.btnGetAllCountries.TabIndex = 2;
            this.btnGetAllCountries.Text = "Get All Countries";
            this.btnGetAllCountries.UseVisualStyleBackColor = false;
            this.btnGetAllCountries.Click += new System.EventHandler(this.btnGetAllCountries_Click);
            // 
            // btnGetAllContacts
            // 
            this.btnGetAllContacts.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnGetAllContacts.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGetAllContacts.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetAllContacts.Location = new System.Drawing.Point(336, 28);
            this.btnGetAllContacts.Name = "btnGetAllContacts";
            this.btnGetAllContacts.Size = new System.Drawing.Size(199, 50);
            this.btnGetAllContacts.TabIndex = 3;
            this.btnGetAllContacts.Text = "Get All Contacts";
            this.btnGetAllContacts.UseVisualStyleBackColor = false;
            this.btnGetAllContacts.Click += new System.EventHandler(this.btnGetAllContacts_Click);
            // 
            // frmListContacts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 500);
            this.Controls.Add(this.btnGetAllContacts);
            this.Controls.Add(this.btnGetAllCountries);
            this.Controls.Add(btnAddNewContact);
            this.Controls.Add(this.dgvAllContacts);
            this.Name = "frmListContacts";
            this.Text = "frmListContacts";
            this.Load += new System.EventHandler(this.frmListContacts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllContacts)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAllContacts;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Button btnGetAllCountries;
        private System.Windows.Forms.Button btnGetAllContacts;
    }
}