using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Atestat
{
    public partial class StartingForm : Form
    {
        public StartingForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Visible = false;
            Form2 f2 = new Form2();
            f2.ShowDialog();
            Visible = true;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void InitializeComponent()
        {
            m_Label_Colegiu = new Label
            {
                AutoSize = true,
                Location = new Point(65, 41),
                Name = "m_Label_Colegiu",
                Size = new Size(284, 13),
                TabIndex = 0,
                Text = "COLEGIUL NATIONAL MIHAIL KOGALNICEANU GALATI"
            };

            m_Label_Titlu = new Label
            {
                AutoSize = true,
                Location = new Point(171, 132),
                Name = "m_Label_Titlu",
                Size = new Size(86, 13),
                TabIndex = 1,
                Text = "Aventura literelor"
            };

            m_Label_Profesor = new Label
            {
                AutoSize = true,
                Location = new Point(32, 238),
                Name = "m_Label_Profesor",
                Size = new Size(105, 26),
                TabIndex = 2,
                Text = "Profesor coordonator\r\nPopescu Madalina\r\n"
            };

            m_Label_Elev = new Label
            {
                AutoSize = true,
                Location = new Point(280, 238),
                Name = "m_Label_Elev",
                Size = new Size(71, 39),
                TabIndex = 3,
                Text = "elev:\r\nIfrim Marius\r\nClasa aXIIa E"
            };

            m_Label_Date = new Label
            {
                AutoSize = true,
                Location = new Point(187, 392),
                Name = "m_Label_Date",
                Size = new Size(50, 13),
                TabIndex = 4,
                Text = "Mai 2016"
            };

            m_Button_Start = new Button
            {
                Location = new Point(35, 338),
                Name = "m_Button_Start",
                Size = new Size(75, 23),
                TabIndex = 5,
                Text = "START",
                UseVisualStyleBackColor = true
            };
            m_Button_Start.Click += new EventHandler(Button1_Click);

            m_Button_Inchide = new Button
            {
                Location = new Point(298, 338),
                Name = "m_Button_Inchide",
                Size = new Size(75, 23),
                TabIndex = 6,
                Text = "INCHIDE",
                UseVisualStyleBackColor = true
            };
            m_Button_Inchide.Click += new EventHandler(Button2_Click);

            SuspendLayout();
          
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(444, 450);
            Controls.Add(m_Button_Inchide);
            Controls.Add(m_Button_Start);
            Controls.Add(m_Label_Date);
            Controls.Add(m_Label_Elev);
            Controls.Add(m_Label_Profesor);
            Controls.Add(m_Label_Titlu);
            Controls.Add(m_Label_Colegiu);
            Name = "StartingForm";
            Text = "Ifrim Marius Atestat Informatica";
            ResumeLayout(false);
            PerformLayout();
        }

        private readonly IContainer components = null;

        /// Clean up any resources being used.
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private Label m_Label_Colegiu;
        private Label m_Label_Titlu;
        private Label m_Label_Profesor;
        private Label m_Label_Elev;
        private Label m_Label_Date;
        private Button m_Button_Start;
        private Button m_Button_Inchide;
    }
}