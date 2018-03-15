using System;
using System.Collections.Generic;

namespace CIS4800 {
	
	public class Cube : Shape {

		Vertex origin;
		double length;

		public Cube (double len, Vertex orig, MeshType m, int n) : base() {

			length = len;
			origin = orig;

			if (m == MeshType.Polygon)
				base.setSurfaces(setupEdges_Polygon());
			else
				base.setSurfaces(setupEdges_Triangle(n));
		}

		private List<Surface> setupEdges_Polygon() {

			List<Surface> s = new List<Surface> ();
			List<Edge> ae = new List<Edge> ();

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
			s.Add (new Surface (ae));
			ae = new List<Edge> ();

			//side 1
			v1 = new Vertex (x, y, z);
			v2 = new Vertex (x, y - length, z);
			ae.Add (new Edge (v1, v2));

			v2 = new Vertex (x, y, z - length);
			ae.Add (new Edge (v1, v2));

			v1 = new Vertex (x, y - length, z - length);
			ae.Add (new Edge (v1, v2));

			v2 = new Vertex (x, y - length, z);
			ae.Add (new Edge (v1, v2));
			s.Add (new Surface (ae));
			ae = new List<Edge> ();

			//side 2
			v1 = new Vertex (x, y, z);
			v2 = new Vertex (x, y - length, z);
			ae.Add (new Edge (v1, v2));

			v2 = new Vertex (x - length, y, z);
			ae.Add (new Edge (v1, v2));

			v1 = new Vertex (x - length, y - length, z);
			ae.Add (new Edge (v1, v2));

			v2 = new Vertex (x, y - length, z);
			ae.Add (new Edge (v1, v2));
			s.Add (new Surface (ae));
			ae = new List<Edge> ();

			//side 3
			v1 = new Vertex (x - length, y, z - length);
			v2 = new Vertex (x - length, y - length, z - length);
			ae.Add (new Edge (v1, v2));

			v2 = new Vertex (x, y, z - length);
			ae.Add (new Edge (v1, v2));

			v1 = new Vertex (x, y - length, z - length);
			ae.Add (new Edge (v1, v2));

			v2 = new Vertex (x - length, y - length, z - length);
			ae.Add (new Edge (v1, v2));
			s.Add (new Surface (ae));
			ae = new List<Edge> ();

			//side 4
			v1 = new Vertex (x - length, y, z - length);
			v2 = new Vertex (x - length, y - length, z - length);
			ae.Add (new Edge (v1, v2));

			v2 = new Vertex (x - length, y, z);
			ae.Add (new Edge (v1, v2));

			v1 = new Vertex (x - length, y - length, z);
			ae.Add (new Edge (v1, v2));

			v2 = new Vertex (x - length, y - length, z - length);
			ae.Add (new Edge (v1, v2));
			s.Add (new Surface (ae));
			ae = new List<Edge> ();

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
			s.Add (new Surface (ae));

			return s;

		}

		private List<Surface> setupEdges_Triangle(int n) {

			List<Surface> s = new List<Surface> ();
			List<Edge> ae = new List<Edge> ();
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

			return s;

		}

	}
}

