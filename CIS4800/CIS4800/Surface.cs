using System;
using System.Collections.Generic;

namespace CIS4800 {
	
	public class Surface {

		private List<Edge> edges;
		private Vector normal;

		public Surface (List<Edge> e) {

			edges = new List<Edge> ();
			edges = e;

		}

		public List<Edge> getEdges () {
			return this.edges;
		}

		public void setEdges (List<Edge> e) {
			this.edges = e;
		}

		public void computeNormal () {



		}

	}
}

