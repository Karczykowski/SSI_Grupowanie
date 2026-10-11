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
            algorytm.PrzygotowanieDanych();
        }
    }
}
