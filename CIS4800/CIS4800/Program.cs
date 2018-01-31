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

			//Vertex v1 = new Vertex (-1, -1, -1);
			//Vertex v2 = new Vertex (1, 1, -1);
			//GraphicsMath.RasterizeEdge (new Edge (v1, v2), ref img);

			Cube c = new Cube (1, 0, MeshType.Triangle, resolution);
			c.Draw (ref img);
			//GraphicsMath.DrawCube (ref img);
			//GraphicsMath.DrawCube (ref img, MeshType.Triangle, resolution);
			//GraphicsMath.DrawPyramid (ref img, MeshType.Polygon, resolution);

			img.SaveImage ();

		}
	}
}
