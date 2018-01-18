using System;
using System.Drawing;

namespace CIS4800 {

	public class DrawImage {

		private int width;
		private int height;
		private Bitmap bmp;

		/*
		 * public DrawImage()
		 * Parameters: m - dimensions of generated image
		 * Initializes DrawImage object
		 * */
		public DrawImage (int m) {

			this.width = m;
			this.height = m;
			this.bmp = new Bitmap (width, height);

		}

		/*
		 * public void DrawPixelAt()
		 * Parameters: x - horizontal cooordinate on image
		 * 			   y - vertical coordinate on image
		 * 			   r - color of the pixel
		 * Sets pixel to be drawn at coordinates (x, y)
		 * */
		public void DrawPixelAt(int x, int y, Color r) {

			this.bmp.SetPixel (x, y, r);

		}

		/*
		 * public void SaveImage()
		 * Parameters: none
		 * Exports the generated bitmap to a .png file in root directory
		 * */
		public void SaveImage() {

			this.bmp.Save ("../../../output/image.png");

		}

	}
}

