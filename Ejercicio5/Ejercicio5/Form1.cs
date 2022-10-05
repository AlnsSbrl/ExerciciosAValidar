namespace Ejercicio5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult mensaje;
            mensaje = MessageBox.Show(String.Format("¿Quieres poner \"{0}\" como título?", textBox1.Text), "Título", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (mensaje == DialogResult.Yes)
            {
                this.Text=textBox1.Text;
            }
        }
    }
}