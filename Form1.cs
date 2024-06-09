using Timer = System.Windows.Forms.Timer;

namespace FinalOdevi
{
    public partial class Form1 : Form
    {

        List<string> iconlar = new List<string>()
        {
            "!", ",", "b","k", "v", "w","z","N",
            "!", ",", "b","k", "v", "w","z","N"
        };

        Random random = new Random();
        int index;
        Timer zamanlayici = new Timer();
        Timer zamanlayici2 = new Timer();
        Button ilkTiklama, ikinciTiklama;
        public Form1()
        {
            InitializeComponent();
            zamanlayici.Tick += T_Tick;
            zamanlayici.Start();
            zamanlayici.Interval = 2000;

            zamanlayici2.Tick += T2_Tick;


        }

        private void T2_Tick(object? sender, EventArgs e)
        {
            zamanlayici2.Stop();
            ilkTiklama.ForeColor = ilkTiklama.BackColor;
            ikinciTiklama.ForeColor=ikinciTiklama.BackColor;
            ilkTiklama = null;
            ikinciTiklama = null;
        }

        private void T_Tick(object sender, EventArgs e)
        {
            zamanlayici.Stop();
            foreach (Button i in Controls)
            {

                i.ForeColor = i.BackColor;
            }
        }


        private void Form1_Load_1(object sender, EventArgs e)
        {
            Button buton;
            foreach (Button i in Controls)
            {
                buton = i as Button;
                index = random.Next(iconlar.Count);
                buton.Text = iconlar[index];
                buton.ForeColor = Color.Black;
                iconlar.RemoveAt(index);
            }
        }
        int sayac = 0;

        private void Button_Click(object sender, EventArgs e)
        {
            Button buton= sender as Button; // Hangi butona týklandýysa

            if(ilkTiklama== null)
            {
                ilkTiklama = buton;
                ilkTiklama.ForeColor= Color.Black;
                return;
            }
            ikinciTiklama = buton;
            ikinciTiklama.ForeColor= Color.Black;

            if(ilkTiklama.Text==ikinciTiklama.Text)
            {
                ilkTiklama.ForeColor = Color.Black;
                ikinciTiklama.ForeColor=Color.Black;
                ilkTiklama = null;
                ikinciTiklama = null;
                sayac++;
                if (sayac == 8)
                {
                    Close();
                }
            }
            else
            {
                zamanlayici2.Start();
                zamanlayici2.Interval = 500;
            }
        }
    }
}
