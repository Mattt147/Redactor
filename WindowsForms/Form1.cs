using ClassLibrary;
namespace WindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Bitmap bmp;
        Bitmap original;
        Bitmap primeBmp;


        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Image |*.jpg; *.png";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                bmp = new Bitmap(fd.FileName);
                primeBmp = new Bitmap(fd.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = bmp;
                original = bmp;

            }
        }
        /// <summary>
        /// Выбор фильтра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bitmap edit = null;
            Editor ed = null;
            if (pictureBox1.Image != null)
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:

                        ed = new Editor(new GrayscaleStrategy());
                        break;
                    case 1:
                        ed = new Editor(new VintageEffectStrategy());
                        break;
                    case 2:
                        ed = new Editor(new NegativeStrategy());
                        break;
                    default:
                        break;
                }
                bmp = ed.Edit(bmp);
                pictureBox1.Image = bmp;
            }
            else
            {
                MessageBox.Show("Сначала выберите фото для редактирования");
                return;
            }
        }
        /// <summary>
        /// отмена изменений
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = original;
            comboBox1.Text = "";
            trackBar1.Value = 5;
            trackBar2.Value = 5;
        }

        /// <summary>
        /// Изменение яркости
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Editor ed = new Editor(new BrigthtnessStrategy(trackBar1.Value));
                Bitmap edit = ed.Edit(bmp);
                pictureBox1.Image = edit;
            }
        }

       
        /// <summary>
        /// Изменение контрастности
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Editor ed = new Editor(new ContrastStrategy(trackBar2.Value));
                Bitmap edit = ed.Edit(bmp);
                pictureBox1.Image = edit;
            }
        }
    }
}