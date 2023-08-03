using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joy_Slots.Toolbox
{
    public class TransparentPictureBox : PictureBox
    {
        public TransparentPictureBox()
        {
            this.BackColor = Color.Transparent;
        }

        private Image imageOverlay;
        public Image ImageOverlay
        {
            get { return imageOverlay; }
            set
            {
                imageOverlay = value;
                this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Draw the base image
            if (this.Image != null)
            {
                e.Graphics.DrawImage(this.Image, 0, 0, this.Width, this.Height);
            }

            // Draw the overlay image with transparency
            if (this.ImageOverlay != null)
            {
                float transparency = 0.5f; // Set the desired transparency value (0.0 - fully transparent, 1.0 - fully opaque)
                using (ImageAttributes imageAttributes = new ImageAttributes())
                {
                    ColorMatrix colorMatrix = new ColorMatrix();
                    colorMatrix.Matrix33 = transparency; // Set the transparency value in the color matrix
                    imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                    Rectangle destRect = new Rectangle(0, 0, this.Width, this.Height);
                    e.Graphics.DrawImage(this.ImageOverlay, destRect, 0, 0, this.ImageOverlay.Width, this.ImageOverlay.Height, GraphicsUnit.Pixel, imageAttributes);
                }
            }
        }
    }
}
