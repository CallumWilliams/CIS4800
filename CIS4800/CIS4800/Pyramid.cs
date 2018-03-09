using System;
using System.Collections.Generic;

namespace CIS4800 {
	
	public class Pyramid : Shape {

		Vertex top_vertex;
		double height;
		double base_width;

		public Pyramid (Vertex top, double h, double w) : base() {

			top_vertex = top;
			height = h;
			base_width = w;

			base.setEdges (setupPyramid_Polygon ());

		}

		private List<Edge> setupPyramid_Polygon () {

			List<Edge> ae = new List<Edge> ();

			double wid = this.base_width / 2;
			double base_x = this.top_vertex.getX ();
			double base_y = this.top_vertex.getY ();
			double base_z = this.top_vertex.getZ ();
			//top vertex
			Vertex t = this.top_vertex;

			//connect top to base
			Vertex b1 = new Vertex (base_x - wid, base_y - height, base_z - wid);
			ae.Add (new Edge (t, b1));
			Vertex b2 = new Vertex (base_x + wid, base_y - height, base_z - wid);
			ae.Add (new Edge (t, b2));
			Vertex b3 = new Vertex (base_x - wid, base_y - height, base_z + wid);
			ae.Add (new Edge (t, b3));
			Vertex b4 = new Vertex (base_x + wid, base_y - height, base_z + wid);
			ae.Add (new Edge (t, b4));

			//build base
			ae.Add (new Edge (b1, b2));
			ae.Add (new Edge (b1, b3));
			ae.Add (new Edge (b4, b2));
			ae.Add (new Edge (b4, b3));

			return ae;

		}

	}
}

