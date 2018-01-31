using System;
using System.Collections;

namespace CIS4800 {
	
	public class Cube {

		float origin;
		float length;
		float width;
		float height;

		ArrayList edges;

		public Cube (float len, float orig, MeshType m, int n) {

			length = len;
			width = len;
			height = len;
			origin = orig;

			if (m == MeshType.Polygon)
				edges = setupEdges_Polygon ();
			else
				edges = setupEdges_Triangle (n);
		}

		private ArrayList setupEdges_Polygon() {

			ArrayList ae = new ArrayList ();

			float x = origin + (length / 2);
			float y = origin + (length / 2);
			float z = origin + (length / 2);
			//top surface
			Vertex v1 = new Vertex (x, y, z);
			Vertex v2 = new Vertex (x, y, z - width);
			ae.Add (new Edge (v1, v2));

			v2 = new Vertex (x - length, y, z);
			ae.Add (new Edge (v1, v2));

			v1 = new Vertex (x - length, y, z - width);
			v2 = new Vertex (x, y, z - width);
			ae.Add (new Edge (v1, v2));

			v2 = new Vertex (x - length, y, z);
			ae.Add (new Edge (v1, v2));

			//side surfaces
			v1 = new Vertex(x, y, z);
			v2 = new Vertex (x, y - height, z);
			ae.Add (new Edge (v1, v2));

			v1 = new Vertex (x, y, z - width);
			v2 = new Vertex (x, y - length, z - width);
			ae.Add (new Edge (v1, v2));

			v1 = new Vertex (x - length, y, z);
			v2 = new Vertex (x - length, y - height, z);
			ae.Add (new Edge (v1, v2));

			v1 = new Vertex (x - length, y, z - width);
			v2 = new Vertex (x - length, y - height, z - width);
			ae.Add (new Edge (v1, v2));

			//bottom surface
			v1 = new Vertex(x, y - height, z);
			v2 = new Vertex (x, y - height, z - length);
			ae.Add (new Edge (v1, v2));

			v2 = new Vertex (x - length, y - height, z);
			ae.Add (new Edge (v1, v2));

			v1 = new Vertex (x - length, y - height, z - width);
			v2 = new Vertex (x, y - height, z - length);
			ae.Add (new Edge (v1, v2));

			v2 = new Vertex (x - length, y - height, z);
			ae.Add (new Edge (v1, v2));

			return ae;

		}

		private ArrayList setupEdges_Triangle(int n) {

			ArrayList ae = new ArrayList ();
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

