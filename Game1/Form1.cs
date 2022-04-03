using System.Threading;
using System.Threading.Tasks;

namespace Game1
{
    public partial class Form1 : Form
    {
        int click = 1;
        int cash = 0;
        int sec = 0;
        int AutoLootingCash = 1;
        public Form1()
        {
            InitializeComponent();
            FillOtherLabel();

            // ����� ������������ ������ �������������� lbl �����
            FillLblCashAsync();
            // ����� ������������ ������ �������������� �����
            AutoLootingAsync();
        }

        private void btnClick_Click(object sender, EventArgs e)
        {
            cash += click;
            FillOtherLabel(); // �������� ���������� ������ label, �.�. ������ ����������� �������������
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cash >= 100)
            {
                cash -= 100;
                click++;
                FillOtherLabel(); // �������� ���������� ������ label, �.�. ������ ����������� �������������
            }
        }
        public void FillOtherLabel()
        {
            lblClick.Text = click.ToString();
            lblSec.Text = sec.ToString();
        }
        private void btnSecond_Click(object sender, EventArgs e)
        {
            if (cash >= 50)
            {
                cash -= 50;
                sec++;
                FillOtherLabel(); // �������� ���������� ������ label, �.�. ������ ����������� �������������
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // ����������� ����� 
        public async void AutoLootingAsync() // async �� ������ ����� �����������, �� ������ ���������� ��� ����� ���� ��������� ��������� � await
        {
            await Task.Run(() => AutoLooting()); // ����������� ���������� (await ���������� ������, ������� ����� �������� ����������)
        }
        
        public void AutoLooting() // ������ ���, ������� ����� ����������� � ��������� ������
        {
            while (true)
            {
                cash += AutoLootingCash;
                Thread.Sleep(1000); // ������� 1000 �� = 1 ���
            }
                
        }

        public async void FillLblCashAsync() // �� �� ����� �������, ������ �� ��������������
        {
            var progress = new Progress<string> (s => lblCash.Text = s); // �����, ����� �� ��� ���������� � lblCash � ������ ������, ��������� �� ���������
            await Task.Run(() => FillLblCash(progress));
        }

        public void FillLblCash(IProgress<string> progress)
        {
            while (true)
            {
                progress.Report(cash.ToString());
                Thread.Sleep(200);
            }
                
        }
    }
}