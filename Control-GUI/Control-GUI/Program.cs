namespace Control_GUI
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class Contenedor : Form
    {
        private Button boton_izquierda, boton_derecha, boton_pausa;
        private Label label_estado, label_tiempo;
        private PictureBox pictureBox_gif;

        Font customFont = new Font("Arial", 16, FontStyle.Bold);

        public Contenedor()
        {
            this.ClientSize = new Size(580, 480);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Control de Motor GUI";

            label_estado = new Label();
            label_estado.Text = "Estado: Detenido";
            label_estado.Font = customFont;
            label_estado.Location = new Point(160, 30);
            label_estado.Size = new Size(300, 100);
            this.Controls.Add(label_estado);

            pictureBox_gif = new PictureBox();
            pictureBox_gif.Size = new Size(200, 200);
            pictureBox_gif.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_gif.Location = new Point((this.ClientSize.Width - pictureBox_gif.Width) / 2, 150);
            pictureBox_gif.Image = Image.FromFile("img/detenido.gif");
            this.Controls.Add(pictureBox_gif);

            boton_izquierda = new Button();
            boton_izquierda.BackgroundImage = Image.FromFile("img/flecha-izquierda.png");
            boton_izquierda.BackgroundImageLayout = ImageLayout.Stretch;
            boton_izquierda.Location = new Point(160, 400);
            boton_izquierda.Size = new Size(64, 64);
            boton_izquierda.Click += new EventHandler(Button_Click);
            this.Controls.Add(boton_izquierda);

            boton_pausa = new Button();
            boton_pausa.BackgroundImage = Image.FromFile("img/pausa.png");
            boton_pausa.BackgroundImageLayout = ImageLayout.Stretch;
            boton_pausa.Location = new Point(240, 400);
            boton_pausa.Size = new Size(64, 64);
            boton_pausa.Click += new EventHandler(Button_Click);
            this.Controls.Add(boton_pausa);

            boton_derecha = new Button();
            boton_derecha.BackgroundImage = Image.FromFile("img/flecha-correcta.png");
            boton_derecha.BackgroundImageLayout = ImageLayout.Stretch;
            boton_derecha.Location = new Point(320, 400);
            boton_derecha.Size = new Size(64, 64);
            boton_derecha.Click += new EventHandler(Button_Click);
            this.Controls.Add(boton_derecha);

            label_tiempo = new Label();
            label_tiempo.Font = customFont;
            label_tiempo.Location = new Point(450, 400);
            label_tiempo.Size = new Size(100, 100);
            this.Controls.Add(label_tiempo);

            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (sender == boton_izquierda)
            {
                label_estado.Text = "Estado: Girando en sentido antihorario";
                pictureBox_gif.Image = Image.FromFile("img/izquierda.gif");

            }
            else if (sender == boton_pausa)
            {
                label_estado.Text = "Estado: Detenido";
                pictureBox_gif.Image = Image.FromFile("img/detenido.gif");

            }
            else if (sender == boton_derecha)
            {
                label_estado.Text = "Estado: Girando en sentido horario";
                pictureBox_gif.Image = Image.FromFile("img/derecha.gif");
            }
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            label_tiempo.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Contenedor());
        }
    }

}