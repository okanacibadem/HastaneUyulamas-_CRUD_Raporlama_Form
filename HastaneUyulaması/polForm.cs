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
    public partial class polForm : Form
    {
        public void mListeler()
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglan;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "ListelePoliklinik";
            SqlDataAdapter goruntule = new SqlDataAdapter(komut);
            DataTable doldur = new DataTable();
            goruntule.Fill(doldur);
            dataGridView1.DataSource = doldur;
        }
        public polForm()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Server=Z29-10\\SA; Database=Hastane;uid=sa;pwd=11072010"); 

        private void EklePersonel_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglan;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "EklePoliklinik";
            komut.Parameters.AddWithValue("poladi", PADI.Text);
            komut.Parameters.AddWithValue("poluzmansayisi", Puzmansıyı.Text);
            komut.Parameters.AddWithValue("polbaskan", Pbaşkanı.Text);
            komut.Parameters.AddWithValue("polbashemsire", pbaşhemsir.Text);
            komut.Parameters.AddWithValue("yataksayısı", yataksauyı.Text);
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
            komut.CommandText = "SilPoliklinik";
            komut.Parameters.AddWithValue("polno", Pno.Text);
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
            komut.CommandText = "YenilePoliklinik";
            komut.Parameters.AddWithValue("polno", Pno.Text);
            komut.Parameters.AddWithValue("poladi", PADI.Text);
            komut.Parameters.AddWithValue("poluzmansayisi", Puzmansıyı.Text);
            komut.Parameters.AddWithValue("polbaskan", Pbaşkanı.Text);
            komut.Parameters.AddWithValue("polbashemsire", pbaşhemsir.Text);
            komut.Parameters.AddWithValue("yataksayısı", yataksauyı.Text);
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
            komut.CommandText = "AramaPoliklinik";
            komut.Parameters.AddWithValue("polno", Pno.Text);
            komut.Parameters.AddWithValue("poladi", PADI.Text);
            komut.Parameters.AddWithValue("poluzmansayisi",Puzmansıyı.Text);
            komut.Parameters.AddWithValue("polbaskan", Pbaşkanı.Text);
            komut.Parameters.AddWithValue("polbashemsire", pbaşhemsir.Text);
            komut.Parameters.AddWithValue("yataksayısı", yataksauyı.Text);
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
            komut.CommandText = "SıralaAZPoliklinik";
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
            komut.CommandText = "SıralaZApoliklinik";
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
            komut.CommandText = "ListelePoliklinik";
            SqlDataAdapter goruntule = new SqlDataAdapter(komut);
            DataTable doldur = new DataTable();
            goruntule.Fill(doldur);
            dataGridView1.DataSource = doldur;
        }       


        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int sectim = dataGridView1.SelectedCells[0].RowIndex;
            string polno = dataGridView1.Rows[sectim].Cells[0].Value.ToString();
            string poladi = dataGridView1.Rows[sectim].Cells[1].Value.ToString();
            string uzmansayı = dataGridView1.Rows[sectim].Cells[2].Value.ToString();
            string polbaşkan = dataGridView1.Rows[sectim].Cells[3].Value.ToString();
            string polhemşire = dataGridView1.Rows[sectim].Cells[4].Value.ToString();
            string yataksayı = dataGridView1.Rows[sectim].Cells[5].Value.ToString();

            Pno.Text = polno;
            PADI.Text = poladi;
            Puzmansıyı.Text = uzmansayı;
            Pbaşkanı.Text = polbaşkan;
            pbaşhemsir.Text = polhemşire;
            yataksauyı.Text = yataksayı;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form1 git = new Form1();
            git.Show();
            this.Hide();
        }

        private void PolUzmanSayiOrtalama_Click(object sender, EventArgs e)
        {           
             

            baglan.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglan;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "PolUzmanSayiOrtalama";
            mListeler();
            komut.ExecuteNonQuery();
            baglan.Close();
            SqlDataAdapter goruntule = new SqlDataAdapter(komut);
            DataTable doldur = new DataTable();
            goruntule.Fill(doldur);
            dataGridView1.DataSource = doldur;
        }

        private void PolYatakSayiAdet_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglan;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "PolYatakSayiAdet";
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
