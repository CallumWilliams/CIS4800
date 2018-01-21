using System;
using System.Collections;

namespace CIS4800 {
	
	class MainClass {
		
		public static void Main (string[] args) {

			DrawImage img = new DrawImage (250);

			//Vertex v1 = new Vertex (-1, -1, -1);
			//Vertex v2 = new Vertex (-1, -1, 1);

			//GraphicsMath.RasterizeEdge (new Edge (v1, v2), ref img);

			//GraphicsMath.DrawCube (ref img);
			GraphicsMath.DrawPyramid (ref img);

			img.SaveImage ();

		}
	}
}
