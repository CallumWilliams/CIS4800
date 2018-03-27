using System;
using System.Drawing;
using System.Collections.Generic;

namespace CIS4800 {
	
	public class Surface {

		private List<Edge> edges;
		private Vector normal;
		private Color colour;

		public Surface (Color c) {

			this.edges = new List<Edge> ();
			this.colour = c;

		}

		public void changeColor(Color c) {
			this.colour = c;
		}

		public Color getColor() {
			return this.colour;
		}

		public void addEdges(Edge e) {
			edges.Add (e);
		}

	}
}

