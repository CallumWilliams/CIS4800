using System;
using System.Drawing;

namespace CIS4800 {
	
	class MainClass {
		
		public static void Main (string[] args) {

			DrawImage img = new DrawImage (10);
			img.DrawPixelAt (3, 3, Color.Red);
			img.DrawPixelAt (6, 6, Color.Blue);
			img.SaveImage ();

		}
	}
}
