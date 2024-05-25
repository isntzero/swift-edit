using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace SwiftEdit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ApplyNightVisionTheme();
        }

        private void ApplyNightVisionTheme()
        {
            this.BackColor = Color.FromArgb(30, 30, 30); // Fondo gris oscuro (hex: #1E1E1E)
            menuStrip1.BackColor = Color.FromArgb(45, 45, 45); // Fondo menú gris oscuro (hex: #2D2D2D)
            menuStrip1.ForeColor = Color.FromArgb(204, 204, 204); // Texto gris claro (hex: #CCCCCC)
            richTextBox1.BackColor = Color.FromArgb(30, 30, 30); // Fondo gris oscuro (hex: #1E1E1E)
            richTextBox1.ForeColor = Color.FromArgb(204, 204, 204); // Texto gris claro (hex: #CCCCCC)
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files|*.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, richTextBox1.Text);
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }
    }
}
