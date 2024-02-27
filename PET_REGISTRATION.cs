using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace HAPPY_PETS
{
    public partial class PET_REGISTRATION : Form
    {
        public PET_REGISTRATION()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            string gender = "";

            bool isChecked = rbn_female.Checked;

            if (isChecked)
            {
                gender = rbn_female.Text;
            }
            else
            {
                gender = rbn_male.Text;
            }


          /*  try
            {*/
                //flag for error msg catch
                bool flag = true;

                //Contact Number Regex
                string motif = @"^[0-9]{10}$";

                if (string.IsNullOrEmpty(txt_name.Text) || txt_name.Text.Any(char.IsDigit))
                {
                    MessageBox.Show("Pet Name Cannot Be Blank or Name Cannot Have Numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    flag = false;
                }


                else if (string.IsNullOrEmpty(cmb_type.Text) || cmb_type.Text.Any(char.IsDigit))
                {
                    MessageBox.Show("Pet Type Cannot Be Blank or Cannot Have Numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    flag = false;
                }


                else if (string.IsNullOrEmpty(txt_breed.Text) || txt_breed.Text.Any(char.IsDigit))
                {
                    MessageBox.Show("Pet Breed Cannot Be Blank or Cannot Have Numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    flag = false;
                }


                else if (string.IsNullOrEmpty(txt_color.Text) || txt_color.Text.Any(char.IsDigit))
                {
                    MessageBox.Show("Pet Color Cannot Be Blank or Cannot Have Numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    flag = false;
                }


                else if (string.IsNullOrEmpty(gender) || gender.Any(char.IsDigit))
                {
                    MessageBox.Show("Pet Gender Cannot Be Blank or Cannot Have Numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    flag = false;
                }


                else if (string.IsNullOrEmpty(txt_first.Text) || txt_first.Text.Any(char.IsDigit))
                {
                    MessageBox.Show("First Name Cannot Be Blank or First Name Cannot Have Numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    flag = false;
                }


                else if (string.IsNullOrEmpty(txt_last.Text) || txt_last.Text.Any(char.IsDigit))
                {
                    MessageBox.Show("Last Name Cannot Be Blank or Last Name Cannot Have Numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    flag = false;
                }


                else if (string.IsNullOrEmpty(txt_address1.Text))
                {
                    MessageBox.Show("Address Cannot Be Blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    flag = false;
                }


                else if (string.IsNullOrEmpty(txt_address2.Text))
                {
                    MessageBox.Show("Address Cannot Be Blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    flag = false;
                }


                //Regex validation For Contact Number
                else if (txt_no.Text != null)
                {
                    if (Regex.IsMatch(txt_no.Text, motif))
                    {
                        flag = true;
                    }


                    else
                    {
                        MessageBox.Show("Contact Number Must Contain 10 Numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        flag = false;
                    }



                    if (flag)
                    {
                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = "Data Source=DESKTOP-SRT2MHC;Initial Catalog=PETS_MANAGEMENT;Integrated Security=True";
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;

                        con.Open();
                        cmd.CommandText = "Insert into PETS(NAME,TYPE,BREED,COLOR,GENDER,DATE_OF_BIRTH,AGE,OWNER_ID,FIRST_NAME,LAST_NAME,ADDRS1,ADDRS2,CONTACT_NO,EMAIL) values ('" + txt_name.Text + "','" + cmb_type.SelectedItem.ToString() + "','" + txt_breed.Text + "','" + txt_color.Text + "','" + gender + "','" + DOBPicker.Value + "','" + txt_age.Text + "','" + txt_owner.Text + "','" + txt_first.Text + "','" + txt_last.Text + "','" + txt_address1.Text + "','" + txt_address2.Text + "','" + txt_no.Text + "','" + txt_email.Text + "')";
                                                                                                                                                                                                                                                                                         // "Insert into DOCTOR (FIRST_NAME,LAST_NAME,NIC,ADDRS1,ADDRS2,CONTACT_NO) values ('" + txt_first.Text + "','" + txt_last.Text + "','" + txt_nic.Text + "','" + txt_address1.Text + "','" + txt_address2.Text + "','" + txt_no.Text + "')";
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        MessageBox.Show("Data Save Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        con.Close();
                    }
                }
            /*}*/

           /* catch (SqlException)
            {
                MessageBox.Show("Database Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Check Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
                
            
        }

        private void DOBPicker_ValueChanged(object sender, EventArgs e)
        {
            int age = DateTime.Now.Year - DOBPicker.Value.Year;
            txt_age.Text = age.ToString();
        }

        

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_email.Clear();
            txt_name.Clear();
            cmb_type.ResetText();
            txt_breed.Clear();
            txt_color.Clear();
            rbn_female.Checked = false;
            rbn_male.Checked = false;
            DOBPicker.ResetText();
            txt_age.Clear();
            txt_owner.Clear();
            txt_first.Clear();
            txt_last.Clear();
            txt_address1.Clear();
            txt_address2.Clear();
            txt_no.Clear();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit?", "Are You Sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btn_view_Click(object sender, EventArgs e)
        {
            
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_email_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
