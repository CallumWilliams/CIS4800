using System;
using System.Drawing;

namespace CIS4800 {
	
	class MainClass {
		
		public static void Main (string[] args) {

			DrawImage img = new DrawImage (100);

			Vertex st = new Vertex (-1, 1, -1);
			Vertex en = new Vertex (1, -1, -1);

			GraphicsMath.RasterizeEdge (st, en, ref img);

			img.SaveImage ();

		}
	}
}
