using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SwiftEdit
{
    public partial class Form1 : Form
    {

        // Declaración de la función externa DwmGetColorizationColor de la biblioteca dwmapi.dll
        [DllImport("dwmapi.dll")]
        private static extern int DwmGetColorizationColor(out int pcrColorization, out bool pfOpaqueBlend);

        public Form1()
        {
            InitializeComponent();
            ApplyNightVisionTheme();
            UpdateStatus();

            // Suscribirse a los eventos de cambio de texto y selección
            richTextBox1.TextChanged += RichTextBox1_TextChanged;


        }

        private void ApplyNightVisionTheme()
        {
            // Colores night vision
            Color backgroundColor = Color.FromArgb(30, 30, 30); // Fondo gris oscuro
            Color menuStripBackgroundColor = Color.FromArgb(45, 45, 45); // Fondo del menú gris oscuro
            Color menuStripTextColor = Color.FromArgb(204, 204, 204); // Texto gris claro
            Color richTextBoxBackgroundColor = Color.FromArgb(30, 30, 30); // Fondo gris oscuro
            Color richTextBoxTextColor = Color.FromArgb(204, 204, 204); // Texto gris claro
            Color statusStripBackgroundColor = Color.FromArgb(45, 45, 45); // Fondo del status strip gris oscuro
            Color statusStripTextColor = Color.FromArgb(204, 204, 204); // Texto gris claro

            // Aplicar colores
            this.BackColor = backgroundColor;
            menuStrip1.BackColor = menuStripBackgroundColor;
            menuStrip1.ForeColor = menuStripTextColor;
            richTextBox1.BackColor = richTextBoxBackgroundColor;
            richTextBox1.ForeColor = richTextBoxTextColor;
            statusStrip1.BackColor = statusStripBackgroundColor;
            toolStripStatusLabel1.ForeColor = statusStripTextColor;
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
                // Mostrar el nombre del archivo en el título del formulario
                this.Text = openFileDialog.SafeFileName;
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ConfigureStatusStrip()
        {
            // Configurar StatusStrip
            statusStrip1.Items.Add(toolStripStatusLabel1);
        }

        private void UpdateStatus()
        {
            int line = richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart) + 1;
            int column = richTextBox1.SelectionStart - richTextBox1.GetFirstCharIndexOfCurrentLine() + 1;
            int totalChars = richTextBox1.Text.Length;

            // Contar las líneas del texto
            int lineCount = richTextBox1.Lines.Length;

            // Calcular el número de la línea actual
            int currentLineNumber = richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart) + 1;

            // Obtener el número total de columnas en la línea actual
            int currentLineLength = 0; // Inicializar la longitud de la línea actual en 0
            if (currentLineNumber <= richTextBox1.Lines.Length)
            {
                currentLineLength = richTextBox1.Lines[currentLineNumber - 1].Length;
            }

            // Actualizar el texto del toolStripStatusLabel1
            toolStripStatusLabel1.Text = $"Lines: {line} Columns: {column} Characters: {totalChars}";
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            UpdateStatus();
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateStatus(); // Actualizar la información en tiempo real
        }


    }
}
