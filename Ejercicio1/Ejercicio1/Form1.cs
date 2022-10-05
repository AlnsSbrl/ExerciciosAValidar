namespace Ejercicio1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

            double num1 = Convert.ToDouble(textBox1.Text); 
            double num2 = Convert.ToDouble(textBox2.Text);
            double suma= num1 + num2;
            label1.Text = "= "+suma.ToString();
            }
            catch(Exception ex)
            {
                label1.Text = "Solo sumo números";
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender,e);
            }
        }
    }
}