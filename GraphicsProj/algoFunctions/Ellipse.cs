using System;
using System.Collections.Generic;
using System.Drawing;

namespace GraphicsProj.algoFunctions
{
    public class Ellipse
    {
        public class EllipseResult
        {
            public int K { get; set; }
            public string ParameterType { get; set; } // Displays "P1" or "P2"
            public float P { get; set; }
            public string NextPoint { get; set; }
            public int TwoRy2Xk1 { get; set; }
            public int TwoRx2Yk1 { get; set; }
        }

        public static List<EllipseResult> Draw(int xc, int yc, int rx, int ry, Graphics g)
        {
            var results = new List<EllipseResult>();
            Brush brush = Brushes.Red;
            int size = 5;

            int x = 0;
            int y = ry;
            int k = 0;

            int ry2 = ry * ry;
            int rx2 = rx * rx;
            int twoRy2 = 2 * ry2;
            int twoRx2 = 2 * rx2;

            // Region 1 initial
            float p1 = ry2 - (rx2 * ry) + (0.25f * rx2);
            int dx = twoRy2 * x;
            int dy = twoRx2 * y;

            // Initial plot
            Plot4(g, brush, xc, yc, x, y, size);

            // --- REGION 1 ---
            while (dx < dy)
            {
                float currentP = p1;

                if (p1 < 0)
                {
                    x++;
                    dx += twoRy2;
                    p1 += dx + ry2;
                }
                else
                {
                    x++;
                    y--;
                    dx += twoRy2;
                    dy -= twoRx2;
                    p1 += dx - dy + ry2;
                }

                results.Add(new EllipseResult
                {
                    K = k++,
                    ParameterType = "P1",
                    P = currentP,
                    NextPoint = $"({x}, {y})",
                    TwoRy2Xk1 = dx,
                    TwoRx2Yk1 = dy
                });

                Plot4(g, brush, xc, yc, x, y, size);
            }

            // --- REGION 2 ---
            // Initial p2 calculation
            float p2 = (float)(ry2 * (x + 0.5) * (x + 0.5) + rx2 * (y - 1) * (y - 1) - rx2 * ry2);
            int kRegion2 = 0;

            while (y > 0)
            {
                float currentP = p2;

                y--;
                dy -= twoRx2;

                if (p2 > 0)
                {
                    p2 += rx2 - dy;
                }
                else
                {
                    x++;
                    dx += twoRy2;
                    p2 += dx - dy + rx2;
                }

                results.Add(new EllipseResult
                {
                    K = kRegion2++,
                    ParameterType = "P2",
                    P = currentP,
                    NextPoint = $"({x}, {y})",
                    TwoRy2Xk1 = dx,
                    TwoRx2Yk1 = dy
                });

                Plot4(g, brush, xc, yc, x, y, size);
            }

            return results;
        }

        private static void Plot4(Graphics g, Brush b, int xc, int yc, int x, int y, int size)
        {
            g.FillRectangle(b, xc + x, yc + y, size, size);
            g.FillRectangle(b, xc - x, yc + y, size, size);
            g.FillRectangle(b, xc + x, yc - y, size, size);
            g.FillRectangle(b, xc - x, yc - y, size, size);
        }
    }
}