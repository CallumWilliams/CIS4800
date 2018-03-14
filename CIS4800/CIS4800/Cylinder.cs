using System;
using System.Collections;

namespace CIS4800 {

	public class Cylinder {

		private const int MAX_RESOLUTION = 20;

		Vertex origin;//"origin" in this shape is the top-centre of the 
		double radius;
		double height;
		int resolution;

		public ArrayList edges;

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
				double nextAngle = 2 * Math.PI / resolution * (i + 1);

				Vertex v1 = new Vertex (Math.Cos (angle), origin.getY (), Math.Sin (angle));
				Vertex v2;

				//top
				if (i == resolution) {
					v2 = new Vertex (Math.Cos (0), origin.getY (), Math.Sin (0));
				} else {
					v2 = new Vertex (Math.Cos (nextAngle), origin.getY (), Math.Sin (nextAngle));
				}
				ae.Add (new Edge (v1, v2));
				//bottom
				v1 = new Vertex(Math.Cos (angle), origin.getY () - height, Math.Sin (angle));
				Vertex v3;
				if (i == resolution) {
					v3 = new Vertex (Math.Cos (0), origin.getY () - height, Math.Sin (0));
				} else {
					v3 = new Vertex (Math.Cos (nextAngle), origin.getY () - height, Math.Sin (nextAngle));
				}
				ae.Add (new Edge (v1, v3));
				//add sides
				ae.Add (new Edge (v2, v3));

			}

			return ae;

		}

		public void Draw(ref DrawImage d) {

			//ArrayList e = this.edges;

			//for (int i = 0; i < e.Count; i++) {
			//	GraphicsMath.RasterizeEdge ((Edge)e [i], ref d);
			//}

		}

	}

}

