namespace Game1
{
    public partial class Form1 : Form
    {
        int click = 1;
        int cash = 0;
        int sec = 0;
        public Form1()
        {
            InitializeComponent();
            FillLbl();
        }

        private void btnClick_Click(object sender, EventArgs e)
        {
            cash += click;
            FillLbl();
        }

        private void FillLbl()
        {
            lblClick.Text = click.ToString();
            lblCash.Text = cash.ToString();
            lblSec.Text = sec.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cash >= 100)
            {
                cash -= 100;
                click++;
                FillLbl();
            }
        }

        private void btnSecond_Click(object sender, EventArgs e)
        {
            if (cash >= 50)
            {
                cash -= 50;
                sec++;
                FillLbl();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}