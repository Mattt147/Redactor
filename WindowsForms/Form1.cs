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
        Bitmap rotate;
        Error error;
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
        /// ����� �������
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
                comboBox1.Text = "";
                error = new Error("�������� ���� ��� ��������������");
                error.ShowDialog();
                return;
            }
        }
        /// <summary>
        /// ������ ���������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (bmp != null)
            {
                bmp = new Bitmap(original);
                pictureBox1.Image = bmp;
            }
            comboBox1.Text = "";
            trackBar1.Value = 5;
            trackBar2.Value = 5;
            
        }

        /// <summary>
        /// ��������� �������
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
        /// ��������� �������������
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
        /// <summary>
        /// ������� �� 90 �������� �����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                rotate = new Bitmap(bmp);
                rotate.RotateFlip(RotateFlipType.Rotate270FlipNone);
                bmp = rotate;
                pictureBox1.Image = bmp;
            }

        }
        /// <summary>
        /// ������� ������ �� 90 ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                rotate = new Bitmap(bmp);
                rotate.RotateFlip(RotateFlipType.Rotate90FlipNone);
                bmp = rotate;
                pictureBox1.Image = bmp;
            }
        }
        /// <summary>
        /// �������������� 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                rotate = new Bitmap(bmp);
                rotate.RotateFlip(RotateFlipType.RotateNoneFlipX);
                bmp = rotate;
                pictureBox1.Image = bmp;
            }
        }
    }
}