using System;
using System.Drawing;

namespace CIS4800 {
	
	class MainClass {
		
		public static void Main (string[] args) {

			DrawImage img = new DrawImage (100);

			Vertex st = new Vertex (-0.4, 0.6, -1);
			Vertex en = new Vertex (0.3, 0.7, 0.5);

			GraphicsMath.RasterizeEdge (st, en, img);

		}
	}
}
