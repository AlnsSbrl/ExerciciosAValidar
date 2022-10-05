namespace Ejercicio3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random generator = new Random();
            credito = credito - 2;

            int num1=generator.Next(1, 8);
            textBox1.Text = num1.ToString();
            int num2=generator.Next(1, 8);
            textBox2.Text = num2.ToString();
            int num3=generator.Next(1, 8);
            textBox3.Text = num3.ToString();

            if (num1 == num2 && num1== num3)
            {
                label1.Text = "PREMIO GORDO +20€";
                credito = credito + 20;
            }
            else
            {
                if(num1== num2 || num1 == num3 || num2 == num3)
                {
                    label1.Text = "Dous numeros iguais, +5€";
#if DEBUG
                    credito = credito - 5;
#else
                    credito = credito + 5;
#endif
                }
                else
                {
                    label1.Text = "Lástima, intenteo outra vez";
                }
            }
            label2.Text = String.Format("Credito {0} €", credito);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            credito = credito + 10;
            label2.Text = String.Format("Credito {0} €", credito);

        }
    }
}