using System;
using System.Collections;

namespace CIS4800 {

	public enum MeshType {
		Polygon,
		Triangle
	}

	class MainClass {

		public static void Main (string[] args) {

			int resolution = 6;
			DrawImage img = new DrawImage (300);

			//Cube s = new Cube (2, 0, MeshType.Polygon, resolution);
			//Cube s = new Cube (1, 0, MeshType.Triangle, resolution);
			//Pyramid s = new Pyramid (new Vertex (0, 1, 0), 2, 2);
			Cylinder s = new Cylinder (new Vertex (0, 1, 0), 0.5, 1, resolution);

			s.Draw (ref img);
			img.SaveImage ();

		}
	}
}
