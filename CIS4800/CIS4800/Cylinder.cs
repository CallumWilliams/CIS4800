using System;
using System.Collections;

namespace CIS4800 {

	public class Cylinder {

		private const int MAX_RESOLUTION = 20;

		Vertex origin;
		double radius;
		double height;
		int resolution;

		ArrayList edges;

		public Cylinder (Vertex o, double r, double h, int res) {

			origin = o;
			radius = r;
			height = h;
			resolution = res;
			//assert minimum resolution
			if (resolution < MAX_RESOLUTION)
				resolution = MAX_RESOLUTION;

			edges = setupCylinder_Polygon ();

		}

		private ArrayList setupCylinder_Polygon() {

			ArrayList ae = new ArrayList ();

			//top/bottom of cylinder
			for (int i = 0; i <= this.resolution; i++) {

				double angle = 2 * Math.PI / resolution * i;

				Vertex v1 = new Vertex (Math.Cos (angle), Math.Sin (angle), -1);
				Vertex v2;
				if (i == resolution) {
					v2 = new Vertex (Math.Cos (0), Math.Sin (0), -1);
				} else {
					double nextAngle = 2 * Math.PI / resolution * (i + 1);
					v2 = new Vertex (Math.Cos (nextAngle), Math.Sin (nextAngle), -1);
				}
				ae.Add (new Edge (v1, v2));

			}

			return ae;

		}

		public void Draw(ref DrawImage img) {

			ArrayList e = this.edges;

			for (int i = 0; i < e.Count; i++) {
				GraphicsMath.RasterizeEdge ((Edge)e [i], ref img);
			}

		}

	}
}

