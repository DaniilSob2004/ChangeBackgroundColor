namespace ChangeBGColor
{
    enum MyColor { Black, Red, Yellow, Green, Blue, DarkBlue, Pink, White };

    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();

        static int value = 0;
        static int maxValue = 255;
        static MyColor color = MyColor.Red;

        public Form1()
        {
            InitializeComponent();
            Text = "ChangeColors";
            StartPosition = FormStartPosition.CenterScreen;

            StartTimer();
        }

        private void StartTimer()
        {
            t.Interval = 1;
            t.Tick += T_Tick;
            t.Start();
        }

        private void T_Tick(object? sender, EventArgs e)
        {
            // 0, 0, 0 - black  ->  255, 0, 0 - red
            // 255, 255, 0 - yellow  ->  0, 255, 0 - green
            // 0, 255, 255 - blue  ->  0, 0, 255 - dark blue
            // 255, 255, 255 - white

            // в зависимости к какому цвету переходим, будет плавно менятся цвет
            // Black -> Red -> Yellow -> Green -> Blue -> DarkBlue -> White -> и потом по кругу
            switch (color)
            {
                case MyColor.Red:
                    if (value < maxValue) BackColor = Color.FromArgb(++value, 0, 0);
                    else
                    {
                        value = 0;
                        color = MyColor.Yellow;
                    }
                    break;

                case MyColor.Yellow:
                    if (value < maxValue) BackColor = Color.FromArgb(maxValue, ++value, 0);
                    else color = MyColor.Green;
                    break;

                case MyColor.Green:
                    if (value > 0) BackColor = Color.FromArgb(--value, maxValue, 0);
                    else color = MyColor.Blue;
                    break;

                case MyColor.Blue:
                    if (value < maxValue) BackColor = Color.FromArgb(0, maxValue, ++value);
                    else color = MyColor.DarkBlue;
                    break;

                case MyColor.DarkBlue:
                    if (value > 0) BackColor = Color.FromArgb(0, --value, maxValue);
                    else color = MyColor.White;
                    break;

                case MyColor.White:
                    if (value < maxValue) BackColor = Color.FromArgb(++value, value, maxValue);
                    else color = MyColor.Black;
                    break;

                case MyColor.Black:
                    if (value > 0) BackColor = Color.FromArgb(--value, value, value);
                    else color = MyColor.Red;
                    break;
            }
        }
    }
}