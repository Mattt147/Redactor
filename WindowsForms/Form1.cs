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
                
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bitmap edit = null;
            Editor ed = null;
            switch (comboBox1.SelectedIndex)
            {
                case 0:

                    ed = new Editor(new GrayscaleStrategy());
                    break;
                case 1:
                    ed = new Editor(new VintageEffectStrategy());
                    break;
                case 2:
                    ed = new Editor(new ContrastStrategy(2.7f));
                    break;
                case 3:
                    ed = new Editor(new BrigthtnessStrategy(2));
                    break;
                case 4:
                    ed = new Editor(new NegativeStrategy());
                    break;
                default:
                    break;
            }
            bmp = ed.Edit(bmp);
            pictureBox1.Image = bmp;
        }
    }
}