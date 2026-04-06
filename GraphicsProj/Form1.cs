using GraphicsProj.algoFunctions;

namespace GraphicsProj
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

                if (algosComboBox.SelectedIndex == 2) // Circle
                {
                    if (string.IsNullOrWhiteSpace(x1Box.Text) || string.IsNullOrWhiteSpace(y1Box.Text) ||
                        string.IsNullOrWhiteSpace(x2Box.Text))
                    {
                        throw new ArgumentException("Please fill in all fields for Circle (X1, Y1, Radius).");
                    }
                    if (!int.TryParse(x1Box.Text, out int xCenter))
                        throw new ArgumentException("X1 must be an integer");
                    if (!int.TryParse(y1Box.Text, out int yCenter))
                        throw new ArgumentException("Y1 must be an integer");
                    if (!int.TryParse(x2Box.Text, out int radius))
                        throw new ArgumentException("Radius must be an integer");
                    Draw(algosComboBox.SelectedItem.ToString(), xCenter, yCenter, radius, 0); // Pass 0 for unused Y2

                    return; // Exit after drawing circle
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
            using (Graphics g = drawPanel.CreateGraphics())
            {
                object results = null;
                switch (algo)
                {
                    case "DDA":
                        results = DDA.Draw(x1, y1, x2, y2, g);
                        break;
                    case "Bresenham":
                        results = Bresenham.Draw(x1, y1, x2, y2, g);
                        break;
                    case "Circle":
                        int radius = x2;

                        // Calculate the mathematical center of the panel
                        int centerX = drawPanel.Width / 2;
                        int centerY = drawPanel.Height / 2;
                        results = Circle.Draw(centerX, centerY, radius, g); // Here x2 is used as radius
                        break;
                    case "Ellipse":
                        MessageBox.Show("Ellipse drawing algorithm selected.");
                        break;
                    default:
                        MessageBox.Show("Unknown algorithm selected.");
                        break;
                }
                if (results != null)
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = results; // Auto-generates columns based on the class used
                }
            }
        }

        private void algosComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = algosComboBox.SelectedItem.ToString();

            if (selected == "Circle")
            {
                // 1. Rename X2 label to Radius
                label3.Text = "Radius";

                // 2. Hide Y2 label and textbox
                label4.Visible = false;
                y2Box.Visible = false;
            }
            else
            {
                // Reset for Line algorithms (DDA/Bresenham)
                label3.Text = "X2";
                label4.Visible = true;
                y2Box.Visible = true;
            }
        }
    }
}
