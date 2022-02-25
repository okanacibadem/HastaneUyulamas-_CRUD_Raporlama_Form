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
    public partial class DoktorUzmanlıkGruplandırma : Form
    {
        public void mListeler()
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglan;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "ListeleDoktor";
            SqlDataAdapter goruntule = new SqlDataAdapter(komut);
            DataTable doldur = new DataTable();
            goruntule.Fill(doldur);
            dataGridView1.DataSource = doldur;
        }
        public DoktorUzmanlıkGruplandırma()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Server=Z29-10\\SA; Database=Hastane;uid=sa;pwd=11072010");

        private void EklePoliklinik_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglan;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "EkleDoktor";

           
            komut.Parameters.AddWithValue("doktoradsoyad", textBox2.Text);
            komut.Parameters.AddWithValue("tc", textBox3.Text);
            komut.Parameters.AddWithValue("uzamanlıkalanı", textBox4.Text);
            komut.Parameters.AddWithValue("unvanı", textBox5.Text);
            komut.Parameters.AddWithValue("telefon", textBox6.Text);
            komut.Parameters.AddWithValue("adres", textBox7.Text);
            komut.Parameters.AddWithValue("dogumtarihi", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("polno", comboBox1.Text);

            komut.ExecuteNonQuery();
            baglan.Close();
            mListeler();
        }

        private void Silpersonel_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglan;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "SilDoktor";
            komut.Parameters.AddWithValue("doktorno", textBox1.Text);
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
            komut.CommandText = "YenileDoktor";
            komut.Parameters.AddWithValue("doktorno", textBox1.Text);
            komut.Parameters.AddWithValue("doktoradsoyad", textBox2.Text);
            komut.Parameters.AddWithValue("tc", textBox3.Text);
            komut.Parameters.AddWithValue("uzamanlıkalanı", textBox4.Text);
            komut.Parameters.AddWithValue("unvanı", textBox5.Text);
            komut.Parameters.AddWithValue("telefon", textBox6.Text);
            komut.Parameters.AddWithValue("adres", textBox7.Text);
            komut.Parameters.AddWithValue("dogumtarihi", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("polno", comboBox1.Text);
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
            komut.CommandText = "AramaDoktor";
            komut.Parameters.AddWithValue("doktorno", textBox1.Text);
            komut.Parameters.AddWithValue("doktoradsoyad", textBox2.Text);
            komut.Parameters.AddWithValue("tc", textBox3.Text);
            komut.Parameters.AddWithValue("uzamanlıkalanı", textBox4.Text);
            komut.Parameters.AddWithValue("unvanı", textBox5.Text);
            komut.Parameters.AddWithValue("telefon", textBox6.Text);
            komut.Parameters.AddWithValue("adres", textBox7.Text);
            komut.Parameters.AddWithValue("dogumtarihi", dateTimePicker1.Value);            
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
            komut.CommandText = "SıralaAZDoktor";
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
            komut.CommandText = "SıralaZADoktor";
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
            komut.CommandText = "ListeleDoktor";
            SqlDataAdapter goruntule = new SqlDataAdapter(komut);
            DataTable doldur = new DataTable();
            goruntule.Fill(doldur);
            dataGridView1.DataSource = doldur;
        }

        private void doktorForm_Load(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand();
            komut.Connection = baglan;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "Getir";

            SqlDataReader dr;
            baglan.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["polno"]);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form1 git = new Form1();
            git.Show();
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int sectim = dataGridView1.SelectedCells[0].RowIndex;
            string doktorno = dataGridView1.Rows[sectim].Cells[0].Value.ToString();
            string doktoradsoyad = dataGridView1.Rows[sectim].Cells[1].Value.ToString();
            string tc = dataGridView1.Rows[sectim].Cells[2].Value.ToString();
            string uzamanlıkalanı = dataGridView1.Rows[sectim].Cells[3].Value.ToString();
            string unvanı = dataGridView1.Rows[sectim].Cells[4].Value.ToString();
            string telefon = dataGridView1.Rows[sectim].Cells[5].Value.ToString();
            string adres = dataGridView1.Rows[sectim].Cells[6].Value.ToString();
            string dogumtarihi = dataGridView1.Rows[sectim].Cells[7].Value.ToString();
            string polno = dataGridView1.Rows[sectim].Cells[8].Value.ToString();

            textBox1.Text = doktorno;
            textBox2.Text = doktoradsoyad;
            textBox3.Text = tc;
            textBox4.Text = uzamanlıkalanı;
            textBox5.Text = unvanı;
            textBox6.Text = telefon;
            textBox7.Text = adres;
            dateTimePicker1.Text= dogumtarihi;
            comboBox1.Text = polno;



        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglan;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "dktuzmn";
            mListeler();
            komut.ExecuteNonQuery();
            baglan.Close();
            SqlDataAdapter goruntule = new SqlDataAdapter(komut);
            DataTable doldur = new DataTable();
            goruntule.Fill(doldur);
            dataGridView1.DataSource = doldur;
            
        }
    }
}
