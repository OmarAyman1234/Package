using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsProj
{
    public partial class TransformForm : Form
    {
        private Bitmap originalImage;

        public TransformForm()
        {
            InitializeComponent();

            if (pictureBox.Image != null)
            {
                originalImage = new Bitmap(pictureBox.Image);
            }

            xTrSlider.Scroll += Sliders_Scroll;
            yTrSlider.Scroll += Sliders_Scroll;

            xScSlider.Scroll += Sliders_Scroll;
            yScSlider.Scroll += Sliders_Scroll;

            rotSlider.Scroll += Sliders_Scroll;

            xShSlider.Scroll += Sliders_Scroll;
            yShSlider.Scroll += Sliders_Scroll;
        }

        private void Sliders_Scroll(object sender, EventArgs e)
        {
            ApplyTransformations();
        }

        private void ApplyTransformations()
        {
            if (originalImage == null) return;

            double sx = xScSlider.Value <= 0 ? -1.0 : xScSlider.Value / 10.0;
            double sy = yScSlider.Value <= 0 ? -1.0 : yScSlider.Value / 10.0;
            double rad = rotSlider.Value * Math.PI / 180.0;
            double shx = xShSlider.Value / 10.0;
            double shy = yShSlider.Value / 10.0;
            int dx = xTrSlider.Value;
            int dy = - yTrSlider.Value;

            double cx = originalImage.Width / 2.0;
            double cy = originalImage.Height / 2.0;

            double[,] toCenter = { { 1, 0, -cx }, { 0, 1, -cy }, { 0, 0, 1 } };
            double[,] fromCenter = { { 1, 0, cx + dx }, { 0, 1, cy - dy }, { 0, 0, 1 } };

            double[,] scale = { { sx, 0, 0 }, { 0, sy, 0 }, { 0, 0, 1 } };
            double[,] rot = { { Math.Cos(rad), -Math.Sin(rad), 0 },
                        { Math.Sin(rad),  Math.Cos(rad), 0 },
                        { 0, 0, 1 } };

            // Pure shear matrices — no pivot needed
            double[,] xShear = { { 1, -shx, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };
            double[,] yShear = { { 1, 0, 0 }, { shy, 1, 0 }, { 0, 0, 1 } };

            // Order: fromCenter * xShear * yShear * rot * scale * toCenter
            double[,] combined = MultiplyMatrices(fromCenter, xShear);
            combined = MultiplyMatrices(combined, yShear);
            combined = MultiplyMatrices(combined, rot);
            combined = MultiplyMatrices(combined, scale);
            combined = MultiplyMatrices(combined, toCenter);

            Bitmap transformedImage = ApplyMatrix(originalImage, combined);

            if (pictureBox.Image != null && pictureBox.Image != originalImage)
                pictureBox.Image.Dispose();

            pictureBox.Image = transformedImage;
        }

        private double[,] MultiplyMatrices(double[,] A, double[,] B)
        {
            double[,] result = new double[3, 3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    for (int k = 0; k < 3; k++)
                        result[i, j] += A[i, k] * B[k, j];
            return result;
        }

        private Bitmap ApplyMatrix(Bitmap source, double[,] matrix)
        {
            int width = source.Width;
            int height = source.Height;
            Bitmap result = new Bitmap(width, height, source.PixelFormat);

            double[,] inverse = InvertMatrix(matrix);

            var rect = new Rectangle(0, 0, width, height);
            BitmapData srcData = source.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData dstData = result.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            int bytesPerPixel = 4;
            int stride = srcData.Stride;

            unsafe
            {
                byte* src = (byte*)srcData.Scan0;
                byte* dst = (byte*)dstData.Scan0;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        // Inverse matrix handles everything — no manual center shift
                        double srcX = inverse[0, 0] * x + inverse[0, 1] * y + inverse[0, 2];
                        double srcY = inverse[1, 0] * x + inverse[1, 1] * y + inverse[1, 2];

                        int dstIdx = y * stride + x * bytesPerPixel;
                        int roundedX = (int)Math.Round(srcX);
                        int roundedY = (int)Math.Round(srcY);

                        if (roundedX >= 0 && roundedX < width && roundedY >= 0 && roundedY < height)
                        {
                            int srcIdx = roundedY * stride + roundedX * bytesPerPixel;
                            dst[dstIdx + 0] = src[srcIdx + 0];
                            dst[dstIdx + 1] = src[srcIdx + 1];
                            dst[dstIdx + 2] = src[srcIdx + 2];
                            dst[dstIdx + 3] = src[srcIdx + 3];
                        }
                        else
                        {
                            dst[dstIdx + 0] = 255;
                            dst[dstIdx + 1] = 255;
                            dst[dstIdx + 2] = 255;
                            dst[dstIdx + 3] = 255;
                        }
                    }
                }
            }

            source.UnlockBits(srcData);
            result.UnlockBits(dstData);

            return result;
        }

        private double[,] InvertMatrix(double[,] m)
        {
            // For a 3x3 affine matrix, compute the inverse using determinant
            double det = m[0, 0] * (m[1, 1] * m[2, 2] - m[1, 2] * m[2, 1])
                       - m[0, 1] * (m[1, 0] * m[2, 2] - m[1, 2] * m[2, 0])
                       + m[0, 2] * (m[1, 0] * m[2, 1] - m[1, 1] * m[2, 0]);

            if (Math.Abs(det) < 1e-10) return m; // Singular, return as-is

            double invDet = 1.0 / det;

            return new double[,]
            {
        {
            (m[1,1]*m[2,2] - m[1,2]*m[2,1]) * invDet,
            (m[0,2]*m[2,1] - m[0,1]*m[2,2]) * invDet,
            (m[0,1]*m[1,2] - m[0,2]*m[1,1]) * invDet
        },
        {
            (m[1,2]*m[2,0] - m[1,0]*m[2,2]) * invDet,
            (m[0,0]*m[2,2] - m[0,2]*m[2,0]) * invDet,
            (m[0,2]*m[1,0] - m[0,0]*m[1,2]) * invDet
        },
        {
            (m[1,0]*m[2,1] - m[1,1]*m[2,0]) * invDet,
            (m[0,1]*m[2,0] - m[0,0]*m[2,1]) * invDet,
            (m[0,0]*m[1,1] - m[0,1]*m[1,0]) * invDet
        }
            };
        }
    }
}