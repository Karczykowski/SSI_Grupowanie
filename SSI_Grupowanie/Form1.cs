namespace SSI_Grupowanie
{
    public partial class Form1 : Form
    {
        Algorytm algorytm = new Algorytm();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int k = (int)numericUpDown1.Value;
            int iteracje = (int)numericUpDown2.Value;

            algorytm.GlownyProgram(k, iteracje);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
