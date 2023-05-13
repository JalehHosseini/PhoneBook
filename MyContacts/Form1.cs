using System;
using System.Windows.Forms;

namespace MyContacts
{
    public partial class Form1 : Form
    {
        IContactRepository repository;

        public Form1()
        {
            InitializeComponent();
            repository = new ContactRepository();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.DataSource = repository.SelectAll();
        }

        //**************************************************************************************
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        //**************************************************************************************

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormAddEdit form = new FormAddEdit();
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                BindGrid();
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow != null)
            {
                string Name = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                string Family = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                string FullName = Name + " " + Family;

                MessageBox.Show($"آیا از حذف{FullName} مطمئن هستید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.None);
                int contactID = int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString());
                repository.Delete(contactID);
                BindGrid();
            }
            else
            {
                MessageBox.Show("لطفا یک مخاطب را انتخاب کنید!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow != null)
            {
                int contactID = int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString());

                FormAddEdit form = new FormAddEdit();
                form.contactID = contactID;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    BindGrid();
                }
            }

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //Not Implemented..!
        }
    }
}
