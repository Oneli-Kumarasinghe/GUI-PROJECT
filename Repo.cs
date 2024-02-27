using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;

namespace HAPPY_PETS
{
    public partial class rpt : Form
    {
        public rpt()
        {
            InitializeComponent();
        }

        private void btn_load_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-SRT2MHC;Initial Catalog=PETS_MANAGEMENT;Integrated Security=True");
        private void btn_load_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Select * from Medical", con);
            SqlDataAdapter d = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            d.Fill(dt);

            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource source = new ReportDataSource("DataSet1", dt);
            reportViewer1.LocalReport.ReportPath = @"C:\Users\DELL\Desktop\Project - Copy - 2\HAPPY PETS\HAPPY PETS\Report1.rdlc";
            reportViewer1.LocalReport.DataSources.Add(source);
            reportViewer1.RefreshReport();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            FrmHappyPets report = new FrmHappyPets();
            report.Show();
            this.Close();
        }
    }
}
