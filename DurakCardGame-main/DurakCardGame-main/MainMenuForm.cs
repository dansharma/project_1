using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DurakCardGame
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Play_Btn_Click(object sender, EventArgs e)
        {
            // Create an instance of the new form
            MainForm mainForm = new MainForm();

            // Show the new form
            mainForm.Show();

            // Hide the current form
            this.Hide();
        }
    }
}
