using System;

namespace CIS4800 {
	
	public class Edge {

		Vertex start;
		Vertex end;

		public Edge (Vertex s, Vertex e) {
			start = s;
			end = e;
		}

		public Vertex getStart() {
			return this.start;
		}

		public Vertex getEnd() {
			return this.end;
		}
	}
}

