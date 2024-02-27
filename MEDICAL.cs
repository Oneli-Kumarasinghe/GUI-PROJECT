using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace HAPPY_PETS
{
   // double M;
    public partial class MEDICAL : Form
    {
        double M;
        public MEDICAL()
        {
            InitializeComponent();
            cmb_vaccine.Text = "--Select--";
            
        }

        private void MEDICAL_Load(object sender, EventArgs e)
        {

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            String pet_id = txt_pet.Text;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-SRT2MHC;Initial Catalog=PETS_MANAGEMENT;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "Select NAME,TYPE,EMAIL From PETS Where PET_ID='" + pet_id + "'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                txt_name.Text = ds.Tables[0].Rows[0][0].ToString();
                txt_type.Text = ds.Tables[0].Rows[0][1].ToString();
                toMail.Text = ds.Tables[0].Rows[0][2].ToString();
            }
            else
            {
                txt_name.Clear();
                txt_type.ResetText();
                MessageBox.Show("Invalid PET_ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_search1_Click(object sender, EventArgs e)
        {
            String doc_id = txt_doc.Text;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-SRT2MHC;Initial Catalog=PETS_MANAGEMENT;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "Select FIRST_NAME + LAST_NAME From DOCTOR Where DOC_ID='" + doc_id + "'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                txt_dr.Text = ds.Tables[0].Rows[0][0].ToString();

            }
            else
            {

                txt_dr.Clear();
                txt_doc.Clear();
                MessageBox.Show("Invalid DOC_ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            NetworkCredential networkCredential = new NetworkCredential();
            SmtpClient smtpClient = new SmtpClient();
            MailMessage mailMessage = new MailMessage();

            String username = "happy.pets.lanka@gmail.com";
            String appPassword = "xlxvitmgxslhprha";
            /*"xlxvitmgxslhprha";
            */
            networkCredential = new NetworkCredential(username, appPassword);

            smtpClient = new SmtpClient("smtp.gmail.com");

            smtpClient.Port = 587;

            /*String to = "vidushanmanujaya101@gmail.com";*/

            smtpClient.Credentials = networkCredential;

            mailMessage.From = new MailAddress(username);

            mailMessage.To.Add(toMail.Text);

            smtpClient.EnableSsl = true;

            mailMessage.Subject = "Happy Pets: Customer Receipt";

            /*String doctor = */

            string htmlBodyString = @"<html>
                                      <body>
                                      <p>Dear Customer,</p>
                                      <p>Thank you for choosing Happy Pets. Please find the receipt below:</p>                                      
                                      </body>
                                      </html>";

            string htmlString = @"<html>
                                    <head>
                                    <style>
                                    table, th{
                                        border:3px solid white;                                    
                                        border-collapse:collapse;
                                                                        
                                    }
                                    th{
                                        background-color:#2c2c54;
                                        text-align: left
                                    }
                                    </style>
                                    </head>
                                    <table style='width:100%'>
                                    <tr>
                                        <th style='width:25%;padding-left:10px;color:white;font-family:lato'>Doctor</th>
                                        <th style='width:25%;padding-left:10px;color:white;font-family:lato'>Pet Name</th>
                                        <th style='width:25%;padding-left:10px;color:white;font-family:lato'>Pet Type</th>                                    
                                        <th style='width:25%;padding-left:10px;color:white;font-family:lato'>Vaccine</th>
                                    </tr>                                
                                    </table>
                                    </html>";

            /*string htmlStringInvoice = @"<html>
                                    <head>
                                    <style>
                                    table, th{
                                        border:3px solid white;                                    
                                        border-collapse:collapse;
                                                                        
                                    }
                                    th{
                                        background-color:#f0f1f2;
                                        text-align: center;
                                    }
                                    </style>
                                    </head>
                                    <table style='width:100%'>
                                    <tr>
                                        <th style='width:100%;padding-left:10px;color:black;font-family:lato'>INVOICE</th>                                
                                    </tr>                                
                                    </table>
                                    </html>";*/

            string htmlStringInvoice2 = @"<html>
                                    <head>
                                    <style>
                                    table, th{
                                        border:3px solid white;                                    
                                        border-collapse:collapse;
                                                                        
                                    }
                                    th{
                                        background-color:#2c2c54;
                                        text-align: left
                                    }
                                    </style>
                                    </head>
                                    <table style='width:100%'>
                                    <tr>
                                        <th style='width:33%;padding-left:10px;color:white;font-family:lato'>Vaccine Cost</th>
                                        <th style='width:33%;padding-left:10px;color:white;font-family:lato'>Fees</th>
                                        <th style='width:33%;padding-left:10px;color:white;font-family:lato'>Total</th>                                    
                                    </table>
                                    </html>";
            string htmlStringInvoiceData = @"<html>
                                   <head>
                                   <style>
                                   table, td{                  
                                        border:3px solid white;
                                        border-collapse:collapse;                                        
                                   }
                                   td{
                                        background-color:#d1ccc0;
                                   }
                                   </style>
                                   </head>
                                    <table style='width:100%'>
                                        <tr>
                                            <td style='width:33%;padding-left:10px;font-family:lato'>vac_cost</td>
                                            <td style='width:33%;padding-left:10px;font-family:lato'>fees</td>
                                            <td style='width:33%;padding-left:10px;font-family:lato'>tot</td>                                            
                                        </tr>
                                    </table>
                                    </html>";

            string htmlString2 = @"<html>
                                   <head>
                                   <style>
                                   table, td{                  
                                        border:3px solid white;
                                        border-collapse:collapse;                                        
                                   }
                                   td{
                                        background-color:#d1ccc0;
                                   }
                                   </style>
                                   </head>
                                    <table style='width:100%'>
                                        <tr>
                                            <td style='width:25%;padding-left:10px;font-family:lato'>doc</td>
                                            <td style='width:25%;padding-left:10px;font-family:lato'>pName</td>
                                            <td style='width:25%;padding-left:10px;font-family:lato'>pType</td>                                            
                                            <td style='width:25%;padding-left:10px;font-family:lato'>vaccine</td>
                                        </tr>
                                    </table>
                                    <br>
                                    </html>";

            string htmlStringReplace = htmlString2.Replace("doc", txt_dr.Text).Replace("pName", txt_name.Text).Replace("pType", txt_type.Text).Replace("vaccine", cmb_vaccine.Text);

            string htmlStringReplace2 = htmlStringInvoiceData.Replace("vac_cost", "LKR " + txt_vaccine.Text).Replace("fees", "LKR " + txt_other.Text).Replace("tot", "LKR " + txt_total.Text);


            mailMessage.Body = htmlBodyString + htmlString + htmlStringReplace + "\n<html><h3 style='padding-left:5px'>INVOICE</h3></html>" + htmlStringInvoice2 + htmlStringReplace2;

            mailMessage.BodyEncoding = Encoding.UTF8;

            mailMessage.IsBodyHtml = true;

            mailMessage.Priority = MailPriority.High;

            mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            smtpClient.SendCompleted += new SendCompletedEventHandler(SendCompletedCallBack);

            smtpClient.SendAsync(mailMessage, "Sending...");

            /*if (txt_name.Text != "")
            {
                
                if (MessageBox.Show("Data Will Be Updated! Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "Data Source=DESKTOP-SRT2MHC;Initial Catalog=PETS_MANAGEMENT;Integrated Security=True";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();
                    
                    cmd.CommandText = "Insert into MEDICAL(MEDICAL_DATE ,DOC_ID ,DOC_NAME ,PET_ID ,NAME ,TYPE,VACCINE,VACCINE_COST,OTHER_COST,TOTAL_COST) values('" + DatePicker.Value + "','" + txt_doc.Text + "','" + txt_dr.Text + "','" + txt_pet.Text + "','" + txt_name.Text + "','" + txt_type.Text + "','" + cmb_vaccine.SelectedItem.ToString() + "','" + txt_vaccine.Text + "','" + txt_other.Text + "','" + txt_total.Text + "')";
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                }

                else
                {
                    MessageBox.Show("Data Cannot Be Saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }*/
        }

        private void SendCompletedCallBack(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show(string.Format("{0} send cancelled.", e.UserState), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (e.Error != null)
            {
                MessageBox.Show(string.Format("{0} {1}", e.UserState, e.Error), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Your Message Has Been Sent Successfully.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btn_cal_Click(object sender, EventArgs e)
        {
            double vaccine = Convert.ToDouble(txt_vaccine.Text);

            double other = Convert.ToDouble(txt_other.Text);

            //  txt_total.Text = (vaccine + other).ToString();
            if (vaccine <= 0 || other <= 0)
            {
                MessageBox.Show("please enter valid numbers.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else 
            {
                txt_total.Text = (vaccine + other).ToString();
                M= Convert.ToDouble(txt_total.Text);
            }

        }

        private void btn_clear_Click(object sender, EventArgs e)
        {

            DatePicker.ResetText();
            txt_doc.Clear();
            txt_dr.Clear();
            txt_pet.Clear();
            txt_name.Clear();
            txt_type.Clear();
            cmb_vaccine.ResetText();
            txt_vaccine.Clear();
            txt_other.Clear();
            txt_total.Clear();

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            FrmHappyPets report = new FrmHappyPets();
            report.Show();
            this.Close();
        }

        private void btn_view_Click(object sender, EventArgs e)
        {
            VIEW_MEDICAL obj = new VIEW_MEDICAL();
            obj.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)

            
        {
 
            try
            {
                
                //flag for error msg catch
                bool flag = true;

                if (string.IsNullOrEmpty(txt_doc.Text))
                {
                    MessageBox.Show("Doctor ID Cannot Be Blank ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    flag = false;
                }
                else if (string.IsNullOrEmpty(txt_pet.Text))
                {
                    MessageBox.Show("Pet ID Cannot Be Blank ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    flag = false;
                }
                else if (M<=0)
                {
                    MessageBox.Show("please calculate correctly ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    flag = false;
                }
                else if (string.IsNullOrEmpty(cmb_vaccine.Text))
                {
                    MessageBox.Show("Vaccine Type Cannot Be Blank ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    flag = false;
                }

                else if (string.IsNullOrEmpty(txt_vaccine.Text) || txt_vaccine.Text.Any(char.IsLetter))
                {
                    MessageBox.Show("Vaccine Cost Cannot Be Blank or Cannot Have Letters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    flag = false;
                }

                else if (string.IsNullOrEmpty(txt_other.Text) || txt_other.Text.Any(char.IsLetter))
                {
                    MessageBox.Show("Fee Cannot Be Blank or Cannot Have Letters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    flag = false;
                }

                 if (flag)
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "Data Source=DESKTOP-SRT2MHC;Initial Catalog=PETS_MANAGEMENT;Integrated Security=True";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    con.Open();
                    cmd.CommandText = "Insert into MEDICAL(MEDICAL_DATE ,DOC_ID ,DOC_NAME ,PET_ID ,NAME ,TYPE,VACCINE,VACCINE_COST,OTHER_COST,TOTAL_COST) values('" + DatePicker.Value + "','" + txt_doc.Text + "','" + txt_dr.Text + "','" + txt_pet.Text + "','" + txt_name.Text + "','" + txt_type.Text + "','" + cmb_vaccine.SelectedItem.ToString() + "','" + txt_vaccine.Text + "','" + txt_other.Text + "','" + txt_total.Text + "')";
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    MessageBox.Show("Data Save Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    con.Close();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Database Connection Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Check Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_other_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_total_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
