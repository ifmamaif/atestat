using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atestat
{
    public partial class Form2 : Form
    {
        int size = 30, viteza = 10;
        int n = 20;// maxim 25 ,preferabil 20
        int[,] a = new int[22, 22];
        int npcx, npcy;
        bool sus, jos, dreapta, stanga, miscare, comunicare, taste = true;
        public string moment = "normal", matrice;

        PictureBox[,] pictureBoxpadure1 = new PictureBox[21, 21];
        PictureBox npc;
        int[] v = new int[2];

        public Form2()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
            tabControl1.Enabled = false;
            tabControl1.Top = 0;
            tabControl1.Left = 0;
            tabControl1.SendToBack();
            timer1.Interval = 60;
            timer1.Enabled = true;
            timer1.Stop();
            timer2.Interval = 60;
            timer2.Enabled = true;
            timer2.Stop();
            this.AutoSize = true;

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= n; i++)
                for (int j = 1; j <= n; j++)
                {
                    pictureBoxpadure1[i, j] = new PictureBox();
                    pictureBoxpadure1[i, j].Top = size * (i - 1);
                    pictureBoxpadure1[i, j].Left = size * (j - 1);
                    pictureBoxpadure1[i, j].Height = size;
                    pictureBoxpadure1[i, j].Width = size;
                    pictureBoxpadure1[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                    tabPage3.Controls.Add(pictureBoxpadure1[i, j]);
                    pictureBoxpadure1[i, j].SendToBack();
                    pictureBoxpadure1[i, j].Visible = true;
                    pictureBoxpadure1[i, j].Enabled = false;
                }

            pictureBox2.Top = pictureBox2.Left = 0;
            pictureBox2.Height = pictureBox2.Width = size * n;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.SendToBack();
            pictureBox2.ImageLocation = "Resources/teren01.bmp";
            pictureBox2.Visible = true;
            pictureBox3.Top = pictureBox3.Left = 0;
            pictureBox3.Height = pictureBox3.Width = size * n;
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.SendToBack();
            pictureBox3.ImageLocation = "Resources/tcpc.bmp";
            pictureBox3.Visible = true;

            CitesteFisier("matrice.txt");
            timer1.Start();
            timer2.Start();
            pictureBox1.Visible = true;
        }

        private void CitesteFisier(string matrice)
        {
            System.IO.StreamReader t = new System.IO.StreamReader("Resources/" + matrice);
            var a2 = t.ReadToEnd().Split('\n');
            n = a2.Length; t.Close(); t = null;
            for (int i = 1; i <= n; i++)
            {
                var a3 = a2[i - 1].Split(' ');
                a[i, 1] = 0;
                for (int j = 1; j <= n; j++)
                {
                    a[i, j] = Convert.ToInt32(a3[j - 1]);
                    if (a[i, j] == 13) activJucator(i - 1, j - 1);
                    if (a[i, j] == -11) activnpc(i - 1, j - 1);
                }
                a3 = null;
            }
            a2 = null;
        }

        private void activJucator(int x, int y)
        {
            pictureBox1.Top = size * x;
            pictureBox1.Left = size * y;
            pictureBox1.Height = size;
            pictureBox1.Width = size;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.BringToFront();
            pictureBox1.Visible = true;
            if (moment == "normal") pictureBox1.ImageLocation = "Resources/bd02.bmp";
            else
                pictureBox1.ImageLocation = "Resources/bd22.bmp";
        }

        private void activnpc(int x, int y)
        {
            a[x + 1, y + 1] = -11; a[x, y] = 1;
            npcx = x; npcy = y;
            npc = new PictureBox();
            npc.Top = size * (x);
            npc.Left = size * (y);
            npc.Height = size;
            npc.Width = size;
            npc.SizeMode = PictureBoxSizeMode.StretchImage;
            npc.ImageLocation = "Resources/npcjos.bmp";
            tabPage1.Controls.Add(npc);
            npc.BringToFront();
            npc.Visible = true;
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (taste == true)
                if (e.KeyCode == Keys.Escape)
                {
                    DialogResult dialogResult = MessageBox.Show("Esti sigur ca vrei sa inchizi aplicatie?", "Sistem de iesire", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this.Close();
                        //do something
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        //do something else
                    }
                }
            if (e.KeyCode == Keys.Down)
            {
                timer1.Start();
                jos = true;
                comunicare = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                timer1.Start();
                sus = true;
                comunicare = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                timer1.Start();
                stanga = true;
                comunicare = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                timer1.Start();
                dreapta = true;
                comunicare = true;
            }
        }

        private void Form2_KeyUp(object sender, KeyEventArgs e)
        {
            if (taste == true)
                if (e.KeyCode == Keys.Down)
                {
                    jos = false;
                    if (moment == "normal")
                        pictureBox1.ImageLocation = "Resources/bd02.bmp";
                    else
                        pictureBox1.ImageLocation = "Resources/bd22.bmp";
                }
            if (e.KeyCode == Keys.Up)
            {
                sus = false;
                if (moment == "normal")
                    pictureBox1.ImageLocation = "Resources/bu02.bmp";
                else
                    pictureBox1.ImageLocation = "Resources/bu22.bmp";
            }
            if (e.KeyCode == Keys.Left)
            {
                stanga = false;
                if (moment == "normal")
                    pictureBox1.ImageLocation = "Resources/bl02.bmp";
                else
                    pictureBox1.ImageLocation = "Resources/bl22.bmp";
            }
            if (e.KeyCode == Keys.Right)
            {
                dreapta = false;
                if (moment == "normal")
                    pictureBox1.ImageLocation = "Resources/br02.bmp";
                else
                    pictureBox1.ImageLocation = "Resources/br22.bmp";
            }
        }

        //private void timer2_Tick_1(object sender, EventArgs e)
        //{
        //
        //}

        private void mesaj(string text)
        {
            if (comunicare == true)
            {
                comunicare = false;
                timer1.Stop();
                miscare = stanga = dreapta = sus = jos = false;
                DialogResult d = MessageBox.Show("Ma ajuti ?", "Sofie :", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes) MessageBox.Show("Multumesc !", "Sofie :", MessageBoxButtons.OK);
                else if (d == DialogResult.No) MessageBox.Show("Nu te pot obliga!", "Sofie :", MessageBoxButtons.OK);
                timer1.Start();
            }
        }

        private void copac()
        {
            timer1.Stop();
            tabControl1.SelectedIndex = 1;
            pictureBox1.Visible = false;
            tabPage2.Controls.Add(pictureBox1);
            moment = "copac";
            CitesteFisier("copac.txt");
            pictureBox1.Visible = true;
            timer1.Start();
        }

        private void normal()
        {
            timer1.Stop();
            tabControl1.SelectedIndex = 0;
            pictureBox1.Visible = false;
            tabPage1.Controls.Add(pictureBox1);
            moment = "normal";
            CitesteFisier("matrice.txt");
            activJucator(10, 15);
            pictureBox1.Visible = true;
            timer1.Start();
        }

        private void padure(int poz)
        {
            timer1.Stop();
            taste = false;
            stanga = dreapta = sus = jos = false;
            pictureBox1.Visible = false;
            tabControl1.SelectedIndex = 2;
            tabPage3.Controls.Add(pictureBox1);
            int x; Random nr = new Random();
            for (int i = 1; i <= n; i++)
                for (int j = 1; j <= n; j++)
                {
                    x = nr.Next(1, 4);
                    if (x != 3)
                    {
                        a[i, j] = 1;
                        pictureBoxpadure1[i, j].ImageLocation = "Resources/simple.bmp";
                    }
                    else
                    {
                        a[i, j] = 0;
                        pictureBoxpadure1[i, j].ImageLocation = "Resources/tc.bmp";
                    }
                    if (i == 1 && a[i, j] > 0) a[i, j] = 10;
                    else
                        if (j == 1 && a[i, j] > 0) a[i, j] = 10;
                    else
                        if (i == n && a[i, j] > 0) a[i, j] = 10;
                    else
                        if (j == n && a[i, j] > 0) a[i, j] = 10;
                }
            for (int i = 1; i <= n; i++)
            {
                x = nr.Next(1, n);
                if (poz == 2)
                {
                    if (a[n, x] > 0)
                    {
                        pictureBox1.Top = size * 0;
                        pictureBox1.Left = size * (n - 1); break;
                    }
                }
                else
                    if (poz == 4)
                {
                    if (a[x, 1] > 0)
                    {
                        pictureBox1.Top = size * x;
                        pictureBox1.Left = 0; break;
                    }
                }
                else
                    if (poz == 6)
                {
                    if (a[x, n] > 0)
                    {
                        pictureBox1.Top = size * x;
                        pictureBox1.Left = size * (n - 1); break;
                    }
                }
                else
                    if (poz == 8) { if (a[1, x] > 0) { pictureBox1.Top = 0; pictureBox1.Left = size * x; break; } }
            }
            pictureBox1.BringToFront();
            pictureBox1.Visible = true;
            stanga = dreapta = sus = jos = false;
            taste = true;
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void iesireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void versiuneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Program realizat de Ifrim Marius", "Versiune Program", MessageBoxButtons.OK);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sus == true)
            {
                if (miscare == false)
                {
                    if (moment == "normal")
                        pictureBox1.ImageLocation = "Resources/bu01.bmp";
                    else
                        pictureBox1.ImageLocation = "Resources/bu23.bmp";
                    miscare = true;
                }
                else
                {
                    if (moment == "normal")
                        pictureBox1.ImageLocation = "Resources/bu03.bmp";
                    else
                        pictureBox1.ImageLocation = "Resources/bu23.bmp";
                    miscare = false;
                }
                if ((pictureBox1.Top) / size > 0)
                {
                    if ((pictureBox1.Left) % size == 0)
                    {
                        if (a[(pictureBox1.Top - viteza) / size + 1, (pictureBox1.Left) / size + 1] > 0)
                        {
                            pictureBox1.Top -= viteza;
                        }
                    }
                    else
                        if (a[(pictureBox1.Top - viteza) / size + 1, (pictureBox1.Left) / size + 1] > 0 && a[(pictureBox1.Top - viteza) / size + 1, (pictureBox1.Left) / size + 2] > 0)
                    {
                        pictureBox1.Top -= viteza;
                    }
                }
                if (a[(pictureBox1.Top) / size + 1, (pictureBox1.Left) / size + 1] == 10 && (pictureBox1.Top) / size == 0) padure(2);
            }
            if (jos == true)
            {
                if (miscare == false)
                {
                    if (moment == "normal")
                        pictureBox1.ImageLocation = "Resources/bd01.bmp";
                    else
                        pictureBox1.ImageLocation = "Resources/bd21.bmp";
                    miscare = true;
                }
                else
                {
                    if (moment == "normal")
                        pictureBox1.ImageLocation = "Resources/bd03.bmp";
                    else
                        pictureBox1.ImageLocation = "Resources/bd23.bmp";
                    miscare = false;
                }
                if (pictureBox1.Top / size < n)
                {
                    if ((pictureBox1.Left) % size == 0)
                    {
                        if (a[(pictureBox1.Top) / size + 2, (pictureBox1.Left) / size + 1] > 0)
                        {
                            pictureBox1.Top += viteza;
                        }
                    }
                    else
                        if (a[(pictureBox1.Top) / size + 2, (pictureBox1.Left) / size + 1] > 0 &&
                       a[(pictureBox1.Top) / size + 2, (pictureBox1.Left) / size + 2] > 0)
                    {
                        pictureBox1.Top += viteza;
                    }
                }
                if (a[(pictureBox1.Top) / size + 1, (pictureBox1.Left) / size + 1] == 10 && (pictureBox1.Top) / size == n - 1) padure(8);
            }
            if (dreapta == true)
            {
                if (miscare == false)
                {
                    if (moment == "normal")
                        pictureBox1.ImageLocation = "Resources/br01.bmp";
                    else
                        pictureBox1.ImageLocation = "Resources/br21.bmp";
                    miscare = true;
                }
                else
                {
                    if (moment == "normal")
                        pictureBox1.ImageLocation = "Resources/br03.bmp";
                    else
                        pictureBox1.ImageLocation = "Resources/br23.bmp";
                    miscare = false;
                }
                if ((pictureBox1.Left) / size < n + 1)
                {
                    if ((pictureBox1.Top) % size == 0)
                    {
                        if (a[pictureBox1.Top / size + 1, pictureBox1.Left / size + 2] > 0)
                        {
                            pictureBox1.Left += viteza;
                        }
                    }
                    else
                        if (a[pictureBox1.Top / size + 1, pictureBox1.Left / size + 2] > 0 &&
                        a[pictureBox1.Top / size + 2, pictureBox1.Left / size + 2] > 0)
                    {
                        pictureBox1.Left += viteza;
                    }
                }
                if (a[pictureBox1.Top / size + 1, pictureBox1.Left / size + 1] == 10 &&
                    pictureBox1.Left / size == n - 1) padure(4);
            }
            if (stanga == true)
            {
                if (pictureBox1.Left > 0)
                {
                    if (miscare == false)
                    {
                        if (moment == "normal")
                            pictureBox1.ImageLocation = "Resources/bl01.bmp";
                        else
                            pictureBox1.ImageLocation = "Resources/bl21.bmp";
                    }
                    else
                    {
                        if (moment == "normal")
                            pictureBox1.ImageLocation = "Resources/bl03.bmp";
                        else
                            pictureBox1.ImageLocation = "Resources/bl23.bmp";
                        miscare = false;
                    }
                    if (pictureBox1.Left / size >= 0)
                    {
                        if (pictureBox1.Top % size == 0)
                        {
                            if (a[pictureBox1.Top / size + 1, (pictureBox1.Left - viteza) / size + 1] > 0)
                            {
                                if (pictureBox1.Left != 0) pictureBox1.Left -= viteza;
                            }
                        }
                        else
                            if (a[pictureBox1.Top / size + 1, (pictureBox1.Left - viteza) / size + 1] > 0 &&
                            a[pictureBox1.Top / size + 2, (pictureBox1.Left - viteza) / size + 1] > 0)
                        {
                            pictureBox1.Left -= viteza;
                        }
                    }
                }
                if (a[pictureBox1.Top / size + 1, pictureBox1.Left / size + 1] == 10 && pictureBox1.Left / size == 0) padure(6);
            }
            switch (a[pictureBox1.Top / size + 1, pictureBox1.Left / size + 1])
            {
                case 52: { copac(); break; }
                case 51: { normal(); break; }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
                if ((pictureBox1.Top) / size == npcx && (pictureBox1.Left + size - viteza) / size - 1 == npcy && stanga == true)
                {
                    timer1.Stop();
                    npc.ImageLocation = "Resources/npcdreapta.bmp";
                    mesaj("da");
                    timer1.Start();
                }
                else
                    if ((pictureBox1.Top) / size == npcx && (pictureBox1.Left) / size + 1 == npcy && dreapta == true)
                {
                    timer1.Stop();
                    npc.ImageLocation = "Resources/npcstanga.bmp";
                    mesaj("da");
                    timer1.Start();
                }
                else
                    if ((pictureBox1.Top) / size + 1 == npcx && (pictureBox1.Left) / size == npcy && jos == true)
                {
                    timer1.Stop();
                    npc.ImageLocation = "Resources/npcsus.bmp";
                    mesaj("da");
                    timer1.Start();
                }
                else
                    if ((pictureBox1.Top + size - viteza) / size - 1 == npcx && (pictureBox1.Left) / size == npcy && sus == true)
                {
                    timer1.Stop();
                    npc.ImageLocation = "Resources/npcjos.bmp";
                    mesaj("da");
                    timer1.Start();
                }
        }

    }
}