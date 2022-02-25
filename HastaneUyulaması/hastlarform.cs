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

namespace HastaneUyulaması
{
    public partial class hastlarform : Form
    {
        public void mListeler()
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglan;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "Listelehastalar";
            SqlDataAdapter goruntule = new SqlDataAdapter(komut);
            DataTable doldur = new DataTable();
            goruntule.Fill(doldur);
            dataGridView1.DataSource = doldur;
        }
        public hastlarform()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Server=Z29-10\\SA; Database=Hastane;uid=sa;pwd=11072010");
            

        private void button8_Click(object sender, EventArgs e)
        {
            Form1 git = new Form1();
            git.Show();
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int sectim = dataGridView1.SelectedCells[0].RowIndex;
            string hastanostr = dataGridView1.Rows[sectim].Cells[0].Value.ToString();
            string hastaadsostr = dataGridView1.Rows[sectim].Cells[1].Value.ToString();
            string tcnostr = dataGridView1.Rows[sectim].Cells[2].Value.ToString();
            string dateTimePicker1str = dataGridView1.Rows[sectim].Cells[3].Value.ToString();
            string boystr = dataGridView1.Rows[sectim].Cells[4].Value.ToString();
            string kilostr = dataGridView1.Rows[sectim].Cells[5].Value.ToString();
            string yasstr = dataGridView1.Rows[sectim].Cells[6].Value.ToString();
            string recetestr = dataGridView1.Rows[sectim].Cells[7].Value.ToString();
            string raporstr = dataGridView1.Rows[sectim].Cells[8].Value.ToString();
            string dateTimePicker2str = dataGridView1.Rows[sectim].Cells[9].Value.ToString();
            string doktorstr = dataGridView1.Rows[sectim].Cells[10].Value.ToString();


            hastano.Text = hastanostr;
            hastaadso.Text = hastaadsostr;
            tcno.Text = tcnostr;
            dateTimePicker1.Text = dateTimePicker1str;
            boy.Text = boystr;
            kilo.Text = kilostr;
            yas.Text = yasstr;
            recete.Text = recetestr;
            rapor.Text = raporstr;
            dateTimePicker2.Text = dateTimePicker2str;
            doktorno.Text = doktorstr;
        }

        private void ekle_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglan;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "EkleHasta";
           
            komut.Parameters.AddWithValue("hastaadsoyad", hastaadso.Text);
            komut.Parameters.AddWithValue("tcno", tcno.Text);
            komut.Parameters.AddWithValue("dogumtarihi", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("boy", boy.Text);
            komut.Parameters.AddWithValue("kilo", kilo.Text);
            komut.Parameters.AddWithValue("yas", yas.Text);
            komut.Parameters.AddWithValue("recete", recete.Text);
            komut.Parameters.AddWithValue("rapordurumu", rapor.Text);
            komut.Parameters.AddWithValue("randevutarih", dateTimePicker2.Value);
            komut.Parameters.AddWithValue("doktorno", doktorno.Text);
            komut.ExecuteNonQuery();
            baglan.Close();
            mListeler();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglan;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "Silhastalar";
            komut.Parameters.AddWithValue("hastano", hastano.Text);
            komut.ExecuteNonQuery();
            baglan.Close();
            mListeler();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglan;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "Yenilehastalar";
            komut.Parameters.AddWithValue("hastano", hastano.Text);
            komut.Parameters.AddWithValue("hastaadsoyad", hastaadso.Text);
            komut.Parameters.AddWithValue("tcno", tcno.Text);
            komut.Parameters.AddWithValue("dogumtarihi", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("boy", boy.Text);
            komut.Parameters.AddWithValue("yas", yas.Text);
            komut.Parameters.AddWithValue("kilo", kilo.Text);
            komut.Parameters.AddWithValue("recete", recete.Text);
            komut.Parameters.AddWithValue("rapordurumu", rapor.Text);
            komut.Parameters.AddWithValue("randevutarih", dateTimePicker2.Value);
            komut.Parameters.AddWithValue("doktorno", doktorno.Text);
            komut.ExecuteNonQuery();
            baglan.Close();
            mListeler();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            baglan.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglan;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "AramaHasta";
            komut.Parameters.AddWithValue("hastano", hastano.Text);
            komut.Parameters.AddWithValue("hastaadsoyad", hastaadso.Text);
            komut.Parameters.AddWithValue("tcno", tcno.Text);
            komut.Parameters.AddWithValue("dogumtarihi", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("boy", boy.Text);
            komut.Parameters.AddWithValue("yas", yas.Text);
            komut.Parameters.AddWithValue("kilo", kilo.Text);
            komut.Parameters.AddWithValue("recete", recete.Text);
            komut.Parameters.AddWithValue("rapordurumu", rapor.Text);
            komut.Parameters.AddWithValue("randevutarih", dateTimePicker2.Value);
            komut.Parameters.AddWithValue("doktorno", doktorno.Text);
            komut.ExecuteNonQuery();
            baglan.Close();
            SqlDataAdapter goruntule = new SqlDataAdapter(komut);
            DataTable doldur = new DataTable();
            goruntule.Fill(doldur);
            dataGridView1.DataSource = doldur;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglan;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "SıralaAZhastalar";
            mListeler();
            komut.ExecuteNonQuery();
            baglan.Close();
            SqlDataAdapter goruntule = new SqlDataAdapter(komut);
            DataTable doldur = new DataTable();
            goruntule.Fill(doldur);
            dataGridView1.DataSource = doldur;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglan;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "SıralaZAhastalar";
            mListeler();
            komut.ExecuteNonQuery();
            baglan.Close();
            SqlDataAdapter goruntule = new SqlDataAdapter(komut);
            DataTable doldur = new DataTable();
            goruntule.Fill(doldur);
            dataGridView1.DataSource = doldur;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglan;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "Listelehastalar";
            SqlDataAdapter goruntule = new SqlDataAdapter(komut);
            DataTable doldur = new DataTable();
            goruntule.Fill(doldur);
            dataGridView1.DataSource = doldur;
        }
    }
}
