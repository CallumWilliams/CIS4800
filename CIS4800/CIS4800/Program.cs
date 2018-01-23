using System;
using System.Collections;

namespace CIS4800 {

	public enum MeshType {
		Polygon,
		Triangle
	}

	class MainClass {

		public static void Main (string[] args) {

			int resolution = 4;
			DrawImage img = new DrawImage (200);

			//GraphicsMath.DrawCube (ref img);
			GraphicsMath.DrawCube (ref img, MeshType.Triangle, resolution);
			//GraphicsMath.DrawPyramid (ref img, MeshType.Polygon, resolution);

			img.SaveImage ();

		}
	}
}
