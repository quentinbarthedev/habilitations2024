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

namespace habilitations2024.view
{
    public partial class FrmHabilitations : Form
    {
        public FrmHabilitations()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Chaîne de connexion à la base de données
            string connectionString = "Server=localhost;Database=habilitations;User Id=habilitations;Password=motdepasseuser;";

            // Requête SQL
            string query = "SELECT nom FROM profil";

            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString);

                connection.Open();

                MySqlCommand command = new MySqlCommand(query, connection);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    lstValeurs.Items.Add(reader["nom"].ToString());
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }
    }
}
