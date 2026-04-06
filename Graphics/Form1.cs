namespace Graphics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (algosComboBox.SelectedIndex == -1)
                {
                    algosComboBox.SelectedIndex = 0;
                }

                if (string.IsNullOrWhiteSpace(x1Box.Text) || string.IsNullOrWhiteSpace(y1Box.Text) ||
                    string.IsNullOrWhiteSpace(x2Box.Text) || string.IsNullOrWhiteSpace(y2Box.Text))
                {
                    throw new ArgumentException("Please fill in all fields.");
                }

                if (!int.TryParse(x1Box.Text, out int x1))
                    throw new ArgumentException("X1 must be an integer");

                if (!int.TryParse(y1Box.Text, out int y1))
                    throw new ArgumentException("Y1 must be an integer");

                if (!int.TryParse(x2Box.Text, out int x2))
                    throw new ArgumentException("X2 must be an integer");

                if (!int.TryParse(y2Box.Text, out int y2))
                    throw new ArgumentException("Y2 must be an integer");

                Draw(algosComboBox.SelectedItem.ToString(), x1, y1, x2, y2);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in drawing: {ex.Message}");
            }
        }

        private void Draw(string algo, int x1, int y1, int x2, int y2)
        {
            switch (algo)
            {
                case "DDA":
                    UseDDA(x1, y1, x2, y2);
                    break;
                case "Bresenham":
                    UseBresenham(x1, y1, x2, y2);
                    break;
                case "Circle":
                    MessageBox.Show("Circle drawing algorithm selected.");
                    break;
                case "Ellipse":
                    MessageBox.Show("Ellipse drawing algorithm selected.");
                    break;
                default:
                    MessageBox.Show("Unknown algorithm selected.");
                    break;
            }
        }

        private void UseBresenham(int x0, int y0, int xEnd, int yEnd)
        {
            var g = drawPanel.CreateGraphics();
            Brush pixelBrush = Brushes.Red;

            int dx = Math.Abs(xEnd - x0);
            int dy = Math.Abs(yEnd - y0);

            // p is the decision parameter
            int p = 2 * dy - dx;
            int twoDy = 2 * dy;
            int twoDyMinusDx = 2 * (dy - dx);

            int x, y, xLimit;

            /* Determine which endpoint to use as start position 
               based on the logic from your image */
            if (x0 > xEnd)
            {
                x = xEnd;
                y = yEnd;
                xLimit = x0;
            }
            else
            {
                x = x0;
                y = y0;
                xLimit = xEnd;
            }

            // Draw the first point
            g.FillRectangle(pixelBrush, x, y, 5, 5);

            while (x < xLimit)
            {
                x++;

                if (p < 0)
                {
                    p += twoDy;
                }
                else
                {
                    y++;
                    p += twoDyMinusDx;
                }

                // Draw the next point
                g.FillRectangle(pixelBrush, x, y, 5, 5);
            }
        }

    }
}
