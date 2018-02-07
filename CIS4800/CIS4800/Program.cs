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
			double[,] matrix = new double[3, 7];
			DrawImage img = new DrawImage (300);//output image dimensions

			WorldSpace w = new WorldSpace (new Vertex (0, 0, 0), 1, 1, 1);
			ViewVolume v = new ViewVolume (new Vertex (0.5, 2, 1), 0.75, 0.25, 0.25);

			Cube s = new Cube (1.5, new Vertex (0, 0, 0), MeshType.Polygon, resolution);
			//Cube s = new Cube (1, new Vertex(0, 0, 0), MeshType.Triangle, resolution);
			//Pyramid s = new Pyramid (new Vertex (0, 0, 0), 2, 2);
			//Cylinder s = new Cylinder (new Vertex (0, 1, 0), 0.5, 1, resolution);

			matrix = GraphicsMath.getViewSpaceCoordinates (new Vertex (0.5, 0.5, 0.5), v, w);

			s.Draw (ref img, matrix);
			img.SaveImage ();

		}
	}
}
