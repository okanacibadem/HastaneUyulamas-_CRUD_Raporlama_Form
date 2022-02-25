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
    public partial class giris : Form
    {
        public giris()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Server=Z29-10\\SA; Database=Hastane;uid=sa;pwd=11072010");
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglan;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "giris";
            komut.Parameters.AddWithValue("kad", textBox1.Text);
            komut.Parameters.AddWithValue("şifre", textBox2.Text);
            baglan.Open();
            SqlDataReader dr;
            dr = komut.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("tebrikler Başarılı şekilde giriş yaptınız ");
                Form1 git = new Form1();
                git.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adını ve şifrenizi kontrol ediniz . ");
                textBox1.Clear();
                textBox2.Clear();
            }
            baglan.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {  baglan.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglan;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "UyeOl";
            komut.Parameters.AddWithValue("kullaniciad", textBox3.Text);
            komut.Parameters.AddWithValue("şifre", textBox4.Text);
            komut.ExecuteNonQuery();
            baglan.Close();           
            MessageBox.Show("tebrikler Başarılı şekilde uye oldunuz ");
        }

        private void label3_Click(object sender, EventArgs e)
        {
            label3.Visible = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            button2.Visible = true;

        }

        private void giris_Load(object sender, EventArgs e)
        {
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            button2.Visible = false;
        }
    }
}
