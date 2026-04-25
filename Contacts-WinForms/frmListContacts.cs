using ContactsBusinessLayer;
using System;
using System.Windows.Forms;
using CountriesBusinessLayer;

namespace Contacts
{
    public partial class frmListContacts : Form
    {
        public frmListContacts()
        {
            InitializeComponent();
        }

        private void _RefreshContactsList()
        {
            dgvAllContacts.DataSource = clsContact.GetAllContacts();
        }

        private void _RefreshCountriesList()
        {
            dgvAllContacts.DataSource = clsCountries.GetAllCountries();
        }

        private void dgvAllContacts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          //  MessageBox.Show(dgvAllContacts.CurrentRow.Cells[0].Value.ToString());
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            frmAddEditContact frm = new frmAddEditContact((int) dgvAllContacts.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            
            _RefreshContactsList();


        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to delete contact [" + dgvAllContacts.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel)==DialogResult.OK)

            {

                //Perform Delele and refresh
                if (clsContact.DeleteContact((int)dgvAllContacts.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Contact Deleted Successfully.");
                    _RefreshContactsList();
                }

                else
                    MessageBox.Show("Contact is not deleted.");

            }

        }

        private void frmListContacts_Load(object sender, EventArgs e)
        {
            btnGetAllContacts.Visible=false;
            _RefreshContactsList();

        }

        private void btnAddNewContact_Click(object sender, EventArgs e)
        {
            frmAddEditContact frm = new frmAddEditContact(-1);
            frm.ShowDialog();
            _RefreshContactsList();
        }

        private void btnGetAllCountries_Click(object sender, EventArgs e)
        {
            _RefreshCountriesList();
            btnGetAllContacts.Visible=true;
            btnGetAllCountries.Visible=false;
        }

        private void btnGetAllContacts_Click(object sender, EventArgs e)
        {
            _RefreshContactsList();
            btnGetAllContacts.Visible=false;
            btnGetAllCountries.Visible=true;
        }
    }
}
