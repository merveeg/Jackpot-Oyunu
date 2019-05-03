using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;   //Directory için eklenen kütüphane
using System.Windows.Forms;
namespace jjackpot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[] resimYolu = Directory.GetFiles(@"C:\resim\", "*.jpg");
     
        int secili = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 50;
            timer2.Interval = 50;
            timer3.Interval = 50;
            oyunuBaslat();
            //var ss = new string[1];
            //ss[0] = resimYolu[0];
          
            //resimYolu = ss;
        }
        private void oyunuBaslat()
        {
            int solTaraf = 30;
            //dinamik 5 buton tanımlansın.
            // 1 i secilirse diğerleri inaktif
            //mesela 10 koydun parayı oyna kazanırsan 10*3
            //kaybedersen tek oyun hak
            int[] butonsecim = new int[5];
            int i;
            MessageBox.Show("oyuna baslamak icin para yatırın(Buton seç):");
            for (i = 0; i < 5; i++)
            {
                Button btn = new Button();
                switch (i)
                {
                    case 0:
                        btn.Text = "10";
                        btn.Name = "buton0";
                        break;
                    case 1:
                        btn.Text = "20";
                        btn.Name = "buton1";
                        break;
                    case 2:
                        btn.Text = "50";
                        btn.Name = "buton2";
                        break;
                    case 3:
                        btn.Text = "100";
                        btn.Name = "buton3";
                        break;
                    case 4:
                        btn.Text = "250";
                        btn.Name = "buton4";
                        break;
                }
                btn.AutoSize = false;
                //btn.Text = "_";
                btn.Top = 50;
                btn.Left = solTaraf;
                btn.Tag = butonsecim[i];
                btn.Width = 45;
                btn.BackColor = Color.Green;
                panel1.BackColor = Color.Black;
                panel1.Controls.Add(btn);
                solTaraf += 50;
                btn.Click += new EventHandler(dinamikMetod);
                btn.Refresh();
            }
        }
        
        //dinamik butonların clicklerini aktif yapmak için metod
        private void dinamikMetod(object sender, EventArgs e)
        {
            //basılan butonu renkli yaptım
            Button btn = (sender as Button);
            btn.BackColor = Color.Yellow;
            MessageBox.Show(btn.Text + "₺ bahis yatırdınız.");
            secili = int.Parse(btn.Text); //butonu tutalim
            //var tutan=Convert.ToInt32(textBox2.Text);
            //textBox2.Text = (tutan-secili).ToString(); 
        }
        private void button1_Click(object sender, EventArgs e)
        {
            sayac = 0;
            timer1.Start();
            timer2.Start();
            timer3.Start();
        }
        int sayac = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Clear();
            sayac++;
            Random rnd = new Random();
            pictureBox1.ImageLocation = resimYolu[rnd.Next(0, resimYolu.Length)];
            pictureBox2.ImageLocation = resimYolu[rnd.Next(0, resimYolu.Length)];
            pictureBox3.ImageLocation = resimYolu[rnd.Next(0, resimYolu.Length)];
            if (sayac >= 130)
                timer1.Stop();
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            sayac++;
            Random rnd = new Random();
            pictureBox1.ImageLocation = resimYolu[rnd.Next(0, resimYolu.Length)];
            pictureBox2.ImageLocation = resimYolu[rnd.Next(0, resimYolu.Length)];
            pictureBox3.ImageLocation = resimYolu[rnd.Next(0, resimYolu.Length)];
            if (sayac >= 230)
                timer2.Stop();
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            sayac++; //her oyun bittiğinde
            Random rnd = new Random();
            pictureBox1.ImageLocation = resimYolu[rnd.Next(0, resimYolu.Length)];
            pictureBox2.ImageLocation = resimYolu[rnd.Next(0, resimYolu.Length)];
            pictureBox3.ImageLocation = resimYolu[rnd.Next(0, resimYolu.Length)];
            if (sayac >= 330)
            {
                timer3.Stop();
                int param = 0; //kontrol eklemelisin.
                if (!Int32.TryParse(textBox2.Text,out param))
                {
                    return;
                }

                var para = Convert.ToInt32(textBox2.Text);
                int katkı = 20;
                if (pictureBox1.ImageLocation == pictureBox2.ImageLocation && pictureBox2.ImageLocation == pictureBox3.ImageLocation )
                {

                    textBox2.Text = (para - secili).ToString();
                    param = katkı * secili;
                    textBox1.Text = param.ToString();
                   
                }
               /* else
                {   var deger = Convert.ToInt32(textBox2.Text);
                    if (deger == 0)
                    {
                        textBox1.Text = "Kaybettiniz";
                    }
                    else
                    {
                        while (deger != 0)
                        {
                            textBox2.Text = (deger - secili).ToString();
                        }
                    }

                }*/
                else
                {
                    textBox2.Text = (param - secili).ToString();
                    var deger = Convert.ToInt32(textBox2.Text);
                    if (deger == 0)
                    {


                        textBox1.Text = "Kaybettiniz ";
                        Form1 frm1 = new Form1();
                        frm1.Show();
                        this.Close();
                    }
                
                  
                }
                

                }

            }

        }
    }

    

