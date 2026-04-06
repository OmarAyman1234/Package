using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsProj.algoFunctions
{
    public class Bresenham
    {
        public static List<BresenhamStepData> Draw(int x0, int y0, int xEnd, int yEnd, Graphics g)
        {
            Brush pixelBrush = Brushes.Red;
            List<BresenhamStepData> stepsList = new List<BresenhamStepData>();

            int dx = Math.Abs(xEnd - x0);
            int dy = Math.Abs(yEnd - y0);

            // p is the decision parameter
            int p = 2 * dy - dx;
            int twoDy = 2 * dy;
            int twoDyMinusDx = 2 * (dy - dx);

            int x, y, xLimit, stepCounter = 0;

            // Determine the starting point and the limit for x
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

            // Draw the start point and don't add it to the grid
            g.FillRectangle(pixelBrush, x, y, 5, 5);

            while (x < xLimit)
            {
                int currentP = p;
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

                // Add data to the list
                stepsList.Add(new BresenhamStepData
                {
                    K = stepCounter++,
                    Pk = currentP, // This records the current decision parameter
                    X = x,
                    Y = y,
                    XY = $"({x}, {y})"
                });
            }
            return stepsList;
        }
        public class BresenhamStepData {
            public int K { get; set; }
            public int Pk { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
            public string XY { get; set; }
        }
    }
}
