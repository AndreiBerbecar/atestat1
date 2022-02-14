using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Atestat
{
    public partial class FrmInregistrare : Form
    {
       

        public FrmInregistrare()
        {
            InitializeComponent();
        }

        private void lblBack_Click(object sender, EventArgs e)
        {
            new FrmMain().Show();
            this.Hide();
        }

        private void FrmInregistrare_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSterge_Click(object sender, EventArgs e)
        {

        }

        private void btnAdaugare_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection();
                connection.ConnectionString = @"SERVER=localhost; DATABASE=atestat; 
                                                UID=root; PASSWORD=; Allow User Variables=True;";
                connection.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = @"INSERT INTO client(Nume,Parola,Nrtel,AdresaEmail)
                                              VALUES(@nume,@parola,@nrtel,@adresaemail); ";

                cmd.Parameters.AddWithValue("nume", txtNume.Text);
                cmd.Parameters.AddWithValue("parola", txtParola.Text);
                cmd.Parameters.AddWithValue("nrtel", txtTelefon.Text);
                cmd.Parameters.AddWithValue("adresaemail", txtEmail.Text);
                if (cmd.ExecuteNonQuery() != 0)
                {
                    MessageBox.Show("Cont creat!", "Baze de date", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Nu s-a putut crea cont!", "Baze de date", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error", "Baze de date", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
