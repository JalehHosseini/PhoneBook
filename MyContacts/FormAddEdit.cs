using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyContacts
{
    public partial class FormAddEdit : Form
    {
        IContactRepository repository;
        public int contactID=0;

        public FormAddEdit()
        {
            InitializeComponent();
            repository = new ContactRepository();
        }
        private void FormAddEdit_Load(object sender, EventArgs e)
        {
            if (contactID == 0)
            {
                this.Text = "افزودن مخاطب جدید";

            }
            else
            {
                this.Text = "ویرایش شخص";
                DataTable dt = repository.SelectRow(contactID);
                txtName.Text = dt.Rows[0][1].ToString();
                txtFamily.Text = dt.Rows[0][2].ToString();
                txtEmail.Text = dt.Rows[0][3].ToString();
                txtAge.Value = int.Parse(dt.Rows[0][4].ToString());
                txtAddress.Text = dt.Rows[0][5].ToString();
                btnSubmit.Text = " ویرایش";


            }
        }

        bool isValid()
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("لطفا نام را وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtFamily.Text == "")
            {
                MessageBox.Show("لطفا نام خانوادگی را وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("لطفا ایمیل را وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtAge.Value == 0)
            {
                MessageBox.Show("لطفا سن را وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtAddress.Text == "")
            {
                MessageBox.Show("لطفا آدرس را وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        } 

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (isValid())
            {

                bool success;
                if (contactID == 0)
                {
                     success = repository.Insert(txtName.Text, txtFamily.Text, txtEmail.Text, (int)txtAge.Value, txtAddress.Text);

                }
                else
                {
                     success = repository.Update(contactID, txtName.Text, txtFamily.Text, txtEmail.Text, (int)txtAge.Value, txtAddress.Text);   
                }
                
              
                if (success==true)
                {
                    MessageBox.Show("عملیات با موفقیت انجام شد", "ثبت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("عملیات با خطا مواجه شد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
