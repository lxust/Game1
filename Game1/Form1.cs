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

            // Вызов асинхронного метода автообновления lbl денег
            FillLblCashAsync();
            // Вызов асинхронного метода автодобавления денег
            AutoLootingAsync();
        }

        private void btnClick_Click(object sender, EventArgs e)
        {
            cash += click;
            FillOtherLabel(); // Вызываем обновление других label, т.к. деньги обновляются автоматически
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cash >= 100)
            {
                cash -= 100;
                click++;
                FillOtherLabel(); // Вызываем обновление других label, т.к. деньги обновляются автоматически
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
                FillOtherLabel(); // Вызываем обновление других label, т.к. деньги обновляются автоматически
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // АСИНХРОННЫЙ МЕТОД 
        public async void AutoLootingAsync() // async не делает метод асинхронным, он просто показывает что может быть множество выражений с await
        {
            await Task.Run(() => AutoLooting()); // Выполняется асинхронно (await определяет задачу, которая будет работать асинхронно)
        }
        
        public void AutoLooting() // Просто код, который будет выполняться в отдельном потоке
        {
            while (true)
            {
                cash += AutoLootingCash;
                Thread.Sleep(1000); // Ожидаем 1000 мс = 1 сек
            }
                
        }

        public async void FillLblCashAsync() // Та же самая история, только на автозаполнение
        {
            var progress = new Progress<string> (s => lblCash.Text = s); // Нужно, чтобы ты мог обратиться к lblCash в другом потоке, отдельном от основного
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