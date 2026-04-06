using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsProj.algoFunctions
{
    public class Circle
    {
        public static List<CircleResult> Draw(int xCenter, int yCenter, int radius, Graphics g)
        {
            List<CircleResult> stepsList = new List<CircleResult>();
            Brush pixelBrush = Brushes.Red;

            int x = 0;
            int y = radius;
            int p = 1 - radius;
            int stepCounter = 0;

            // 1. Plot the first set of points
            PlotCirclePoints(xCenter, yCenter, x, y, g, pixelBrush);

            // Note: The image shows the loop logic. 
            // To match your table requirements, we log the state INSIDE the loop.
            while (x < y)
            {
                // Capture current P for the table
                int currentP = p;

                x++;
                if (p < 0)
                {
                    p += 2 * x + 1;
                }
                else
                {
                    y--;
                    p += 2 * (x - y) + 1;
                }

                // Plot the 8 symmetric points
                PlotCirclePoints(xCenter, yCenter, x, y, g, pixelBrush);

                // Add to list for the DataGridView
                stepsList.Add(new CircleResult
                {
                    K = stepCounter++,
                    Pk = currentP,
                    X = x,
                    Y = y
                });
            }

            return stepsList;
        }

        // Helper method for 8-way symmetry (matches circlePlotPoints in your image)
        private static void PlotCirclePoints(int xCenter, int yCenter, int x, int y, Graphics g, Brush brush)
        {
            int size = 5; // Size of our "pixel"
            g.FillRectangle(brush, xCenter + x, yCenter + y, size, size);
            g.FillRectangle(brush, xCenter - x, yCenter + y, size, size);
            g.FillRectangle(brush, xCenter + x, yCenter - y, size, size);
            g.FillRectangle(brush, xCenter - x, yCenter - y, size, size);
            g.FillRectangle(brush, xCenter + y, yCenter + x, size, size);
            g.FillRectangle(brush, xCenter - y, yCenter + x, size, size);
            g.FillRectangle(brush, xCenter + y, yCenter - x, size, size);
            g.FillRectangle(brush, xCenter - y, yCenter - x, size, size);
        }
    }

    public class CircleResult
    {
        public int K { get; set; }
        public int Pk { get; set; }

        [Browsable(false)]
        public int X { get; set; }

        [Browsable(false)]
        public int Y { get; set; }


        [DisplayName("(Xₖ₊₁, Yₖ₊₁)")]
        public string XY => $"({X}, {Y})";

        [DisplayName("2Xk+1")]
        public int TwoXNext => 2 * X;

        [DisplayName("2Yk+1")]
        public int TwoYNext => 2 * Y;
    }
}

