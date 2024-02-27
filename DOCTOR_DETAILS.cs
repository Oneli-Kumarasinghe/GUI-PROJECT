using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Mail;

namespace HAPPY_PETS
{
    public partial class frmDoctorDetails : Form
    {
        private void btnOTP_Load(object sender, EventArgs e)
        {
        }

        public frmDoctorDetails()
        {
            InitializeComponent();
        }
        int otp;
        String connectionString;
        SqlConnection con;

       
        SqlCommand cmd;

        public SqlConnection dbConnection()
        {
            connectionString = @"Data Source=DESKTOP-SRT2MHC;Initial Catalog=PETS_MANAGEMENT;Integrated Security=True";
            con = new SqlConnection(connectionString);

            con.Open();
            MessageBox.Show("SUCCESS");
            return con;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
        }


        
        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_first.Clear();
            txt_last.Clear();
            txt_nic.Clear();
            txt_address1.Clear();
            txt_address2.Clear();
            txt_no.Clear();
            txtOTP.Clear();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {

        }



        private void btn_otp_Click(object sender, EventArgs e)
        {

        }



        private void btn_save_Click_1(object sender, EventArgs e)
        {

            /*try
            {*/
            //flag for error msg catch
            /*                bool flag = true;
            */
            //Contact Number Regex
            string motif = @"^[0-9]{10}$";

            //first name
            if (string.IsNullOrEmpty(txt_first.Text))
            {
                MessageBox.Show("First Name Cannot Be Blank ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_first.Text.Any(char.IsDigit))
            {
                MessageBox.Show("First Name Cannot Contain Numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //last name
            else if (string.IsNullOrEmpty(txt_last.Text))
            {
                MessageBox.Show("Last Name Cannot Be Blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_last.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Last Name Cannot Have Numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //nic
            else if (string.IsNullOrEmpty(txt_nic.Text))
            {
                MessageBox.Show("NIC Number Cannot Be Blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_nic.Text.Any(char.IsLetter))
            {
                MessageBox.Show("NIC Number Cannot Contain Letters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_nic.TextLength != 12)
            {
                MessageBox.Show("NIC Number Cannot Contain More Than 12 Digits", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //address no
            else if (string.IsNullOrEmpty(txt_address1.Text))
            {
                MessageBox.Show("Address Number Cannot Be Blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //address
            else if (string.IsNullOrEmpty(txt_address2.Text))
            {
                MessageBox.Show("Address Cannot Be Blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_first.Text.Any(char.IsDigit))
            {
                MessageBox.Show("2nd Address Cannot Contain Numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Regex validation For Contact Number
            else if (Regex.IsMatch(txt_no.Text, motif))
            {
                MessageBox.Show("Contact Number Must Contain 10 Numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                String sql = "Insert into DOCTOR (FIRST_NAME,LAST_NAME,NIC,ADDRS1,ADDRS2,CONTACT_NO) values ('" + txt_first.Text + "','" + txt_last.Text + "','" + txt_nic.Text + "','" + txt_address1.Text + "','" + txt_address2.Text + "','" + txt_no.Text + "')";

                /*            cmd = new SqlCommand("", dbConnection());
                */

                cmd = new SqlCommand(sql, dbConnection());
                SqlDataAdapter adapter = new SqlDataAdapter();

                adapter.InsertCommand = new SqlCommand(sql, con);
                int result = adapter.InsertCommand.ExecuteNonQuery();

                if (result == 1)
                {
                    MessageBox.Show("DOCTOR CREATED SUCCESSFULLY", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                cmd.Dispose();

            }

            /*dbConnection();*/





            /* else
             {
                 cmd = new SqlCommand("Insert into DOCTOR (FIRST_NAME,LAST_NAME,NIC,ADDRS1,ADDRS2,CONTACT_NO) values ('" + txt_first.Text + "','" + txt_last.Text + "','" + txt_nic.Text + "','" + txt_address1.Text + "','" + txt_address2.Text + "','" + txt_no.Text + "')", dbConnection());

                 int i = cmd.ExecuteNonQuery();
                 if (i == 1)
                 {
                     MessageBox.Show("Data Save Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 }
                 else
                 {
                     MessageBox.Show("Data cannot Save", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }
                 con.Close();
             }
         }
         catch (Exception)
         {
             MessageBox.Show("Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }*/
        }
        private void btn_exit_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit?", "Are You Sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }
        private void btnVerifyOTP_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtOTP.Text).Equals(otp))
            {
                btn_save.Visible = true;
                MessageBox.Show("Verified Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Please enter a valid OTP", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSendOTP_Click(object sender, EventArgs e)
        {
            //otp
            if (this.VerifyNumber())
            {

                using (var web = new WebClient())
                {
                    Random rd = new Random();
                    int rand_num = rd.Next(1000, 9999);
                    otp = rand_num;
                    
                    String msg = "YOUR OTP: " + otp.ToString();
                    var replacement = msg.Replace(' ', '+');
                    String url = "https://cloud.websms.lk/smsAPI?sendsms&apikey=vyQz40VmpboN8ZUE52N7xser6m0jX02I&apitoken=3MJG1665037564&type=sms&from=DEMO_SMS&to="+txt_no.Text+"&text=" + replacement;
                    _ = web.DownloadString(url);
                    MessageBox.Show("OTP is sent to "+ txt_no.Text, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //check the validation o
                }
                btnVerifyOTP.Enabled = true;
            }
            else
            {
                MessageBox.Show("Please enter a valid number", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
        public bool VerifyNumber()
        {
            if (txt_no.TextLength.Equals(12))
            {
                /*Console.WriteLine("TEXTLENGTH");*/
                if (txt_no.Text[0].Equals('+'))
                {
                   /* Console.WriteLine("+");*/
                    if (txt_no.Text[1].Equals('9'))
                    {
                       /* Console.WriteLine("9");*/
                        if (txt_no.Text[2].Equals('4'))
                        {
                            /*Console.WriteLine("4");*/
                            String number = txt_no.Text.Substring(3);
                            bool success = int.TryParse(number, out _);
                            if (success)
                            {
                               /* Console.WriteLine(number);*/
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {

                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
