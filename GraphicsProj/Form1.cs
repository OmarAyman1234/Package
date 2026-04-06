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
                        MessageBox.Show("Circle drawing algorithm selected.");
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
    }
}
