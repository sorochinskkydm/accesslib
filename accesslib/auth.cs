using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace accesslib
{
    public partial class auth : Form
    {
        public auth()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            registration regisrtationForm = new registration();
            regisrtationForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String loginUser = textBox1.Text;
            String passUser = textBox2.Text;

            database db = new database();
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `userstable` WHERE `login` = @userLogin AND `password` = @userPassword", db.getConnection());
            command.Parameters.Add("@userLogin", MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@userPassword", MySqlDbType.VarChar).Value = passUser;

            adapter.SelectCommand = command;
            adapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                mainAdmin mainAdminForm = new mainAdmin();
                mainAdminForm.Show();
                this.Hide();
            }
            else MessageBox.Show("Try another login or password");
        }
    }
}
