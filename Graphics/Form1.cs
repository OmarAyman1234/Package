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
                    LineDDA(x1, y1, x2, y2);
                    break;
                case "Bresenham":
                    MessageBox.Show("Bresenham algorithm selected.");
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

        private void LineDDA(int x1, int y1, int x2, int y2)
        {
            var g = drawPanel.CreateGraphics();
            Brush pixelBrush = Brushes.Red;

            int dx = x2 - x1;
            int dy = y2 - y1;
            int steps;
            float xIncrement, yIncrement, x = x1, y = y1;

            // Determine the number of steps
            if (Math.Abs(dx) > Math.Abs(dy))
                steps = Math.Abs(dx);
            else
                steps = Math.Abs(dy);

            xIncrement = (float)dx / (float)steps;
            yIncrement = (float)dy / (float)steps;

            // Draw the first point
            g.FillRectangle(pixelBrush, (int)Math.Round(x), (int)Math.Round(y), 5, 5);

            for (int k = 0; k < steps; k++)
            {
                x += xIncrement;
                y += yIncrement;
                // FillRectangle with 1x1 size simulates SetPixel
                g.FillRectangle(pixelBrush, (int)Math.Round(x), (int)Math.Round(y), 5, 5);
            }
        }
    }
}
