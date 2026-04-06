using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsProj.algoFunctions
{
    public class DDA
    {
        public static List<DDAStepData> Draw(int x1, int y1, int x2, int y2, Graphics g)
        {
            Brush pixelBrush = Brushes.Red;
            List<DDAStepData> stepsList = new List<DDAStepData>();

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


            for (int k = 0; k < steps; k++)
            {
                // Draw the pixel on the Graphics object passed from the Form
                g.FillRectangle(pixelBrush, (int)Math.Round(x), (int)Math.Round(y), 5, 5);

                x += xIncrement;
                y += yIncrement;

                stepsList.Add(new DDAStepData 
                { 
                    K = k, 
                    X = x.ToString(), 
                    Y = y.ToString(),
                    RoundedXY = $"({Math.Round(x)}, {Math.Round(y)})"
                });
            }

            return stepsList;
        }
    }
    public class DDAStepData
    {
        public int K { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
        public string RoundedXY { get; set; }
    }
}
