using System;
using System.Collections;

namespace CIS4800 {
	
	public class Cube {

		Vertex origin;
		double length;

		public ArrayList edges;

		public Cube (double len, Vertex orig, MeshType m, int n) {

			length = len;
			origin = orig;

			if (m == MeshType.Polygon)
				edges = setupEdges_Polygon ();
			else
				edges = setupEdges_Triangle (n);
		}

		private ArrayList setupEdges_Polygon() {

			ArrayList ae = new ArrayList ();

			double x = origin.getX () + (length / 2);
			double y = origin.getY () + (length / 2);
			double z = origin.getZ () + (length / 2);
			//top surface
			Vertex v1 = new Vertex (x, y, z);
			Vertex v2 = new Vertex (x, y, z - length);
			ae.Add (new Edge (v1, v2));

			v2 = new Vertex (x - length, y, z);
			ae.Add (new Edge (v1, v2));

			v1 = new Vertex (x - length, y, z - length);
			v2 = new Vertex (x, y, z - length);
			ae.Add (new Edge (v1, v2));

			v2 = new Vertex (x - length, y, z);
			ae.Add (new Edge (v1, v2));

			//side surfaces
			v1 = new Vertex(x, y, z);
			v2 = new Vertex (x, y - length, z);
			ae.Add (new Edge (v1, v2));

			v1 = new Vertex (x, y, z - length);
			v2 = new Vertex (x, y - length, z - length);
			ae.Add (new Edge (v1, v2));

			v1 = new Vertex (x - length, y, z);
			v2 = new Vertex (x - length, y - length, z);
			ae.Add (new Edge (v1, v2));

			v1 = new Vertex (x - length, y, z - length);
			v2 = new Vertex (x - length, y - length, z - length);
			ae.Add (new Edge (v1, v2));

			//bottom surface
			v1 = new Vertex(x, y - length, z);
			v2 = new Vertex (x, y - length, z - length);
			ae.Add (new Edge (v1, v2));

			v2 = new Vertex (x - length, y - length, z);
			ae.Add (new Edge (v1, v2));

			v1 = new Vertex (x - length, y - length, z - length);
			v2 = new Vertex (x, y - length, z - length);
			ae.Add (new Edge (v1, v2));

			v2 = new Vertex (x - length, y - length, z);
			ae.Add (new Edge (v1, v2));

			return ae;

		}

		private ArrayList setupEdges_Triangle(int n) {

			ArrayList ae = new ArrayList ();
			double[] const_dimen = { origin.getX () - (length / 2), origin.getX () + (length / 2) };

			for (int i = 0; i <= n; i++) {
				for (int j = 0; j <= n; j++) {
					for (int k = 0; k < const_dimen.Length; k++) {
						double icoord = (double)((double)(length / n * i) - (length/2));
						double jcoord = (double)((double)(length / n * j) - (length/2));
						//Front and back
						Vertex v1 = new Vertex ((double)icoord, (double)jcoord, const_dimen[k]);
						Vertex v2 = new Vertex ((double)icoord + (length / n), (double)jcoord, const_dimen [k]);
						ae.Add (new Edge (v1, v2));
						v2 = new Vertex((double)icoord, (double)jcoord + (length / n), const_dimen[k]);
						ae.Add (new Edge (v1, v2));
						v2 = new Vertex ((double)icoord + (length / n), (double)jcoord + (length / n), const_dimen [k]);
						ae.Add (new Edge (v1, v2));
						v1 = new Vertex ((double)icoord + (length / n), (double)jcoord + (length / n), const_dimen [k]);
						v2 = new Vertex ((double)icoord + (length / n), (double)jcoord, const_dimen [k]);
						ae.Add (new Edge (v1, v2));
						v2 = new Vertex ((double)icoord, (double)jcoord + (length / n), const_dimen [k]);
						ae.Add (new Edge (v1, v2));

						//Top and bottom
						v1 = new Vertex((double)icoord, const_dimen[k], (double)jcoord);
						v2 = new Vertex ((double)icoord + (length / n), const_dimen [k], (double)jcoord);
						ae.Add (new Edge (v1, v2));
						v2 = new Vertex ((double)icoord, const_dimen [k], (double)jcoord + (length / n));
						ae.Add (new Edge (v1, v2));
						v2 = new Vertex ((double)icoord + (length / n), const_dimen [k], (double)jcoord + (length / 2));
						ae.Add (new Edge (v1, v2));
						v1 = new Vertex ((double)icoord + (length / n), const_dimen [k], (double)jcoord + (length / n));
						v2 = new Vertex ((double)icoord + (length / n), const_dimen [k], (double)jcoord);
						ae.Add (new Edge (v1, v2));
						v2 = new Vertex ((double)icoord, const_dimen [k], (double)jcoord + (length / n));
						ae.Add (new Edge (v1, v2));

						//Sides
						v1 = new Vertex(const_dimen[k], (double)icoord, (double)jcoord);
						v2 = new Vertex (const_dimen [k], (double)icoord + (length / n), (double)jcoord);
						ae.Add (new Edge (v1, v2));
						v2 = new Vertex (const_dimen [k], (double)icoord, (double)jcoord + (length / n));
						ae.Add (new Edge (v1, v2));
						v2 = new Vertex (const_dimen [k], (double)icoord + (length / n), (double)jcoord + (length / n));
						ae.Add (new Edge (v1, v2));
						v1 = new Vertex (const_dimen [k], (double)icoord + (length / n), (double)jcoord + (length / n));
						v2 = new Vertex (const_dimen [k], (double)icoord + (length / n), (double)jcoord);
						ae.Add (new Edge (v1, v2));
						v2 = new Vertex (const_dimen [k], (double)icoord, (double)jcoord + (length / n));
						ae.Add (new Edge (v1, v2));

					}
				}
			}

			return ae;

		}

		public void Draw(ref DrawImage d, double[,] matrix) {

			ArrayList e = this.edges;

			for (int i = 0; i < e.Count; i++) {
				Edge eNew = (Edge)e [i];
				Vertex start = GraphicsMath.convertVertexToViewPlane (matrix, eNew.getStart ());
				Vertex end = GraphicsMath.convertVertexToViewPlane (matrix, eNew.getEnd ());
				eNew = new Edge (start, end);
				GraphicsMath.RasterizeEdge (eNew, ref d);
			}

		}

	}
}

