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
			double[,] matrix;
			DrawImage img = new DrawImage (500);//output image dimensions

			WorldSpace w = new WorldSpace (new Vertex (0, 0, 0), 1, 1, 1);
			ViewVolume v = new ViewVolume (new Vertex (0.25, 0.25, 1), 0.25, 0.75, 1);
			//ViewVolume v = new ViewVolume (5, 30, 20, 0.25, 1, 1);

			Cube s = new Cube (1, new Vertex (0, 0, 0), MeshType.Polygon, resolution);
			//Cube s = new Cube (1, new Vertex(0, 0, 0), MeshType.Triangle, resolution);
			//Pyramid s = new Pyramid (new Vertex (0, 0, 0), 0.5, 0.5);
			//Cylinder s = new Cylinder (new Vertex (0, 1, 0), 0.5, 1, resolution);

			matrix = GraphicsMath.getViewSpaceCoordinates (v, w);

			s.Draw (ref img, matrix, v);
			img.SaveImage ();

		}
	}
}
