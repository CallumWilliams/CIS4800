using System;
using System.Collections.Generic;

namespace CIS4800
{
	public class Shape {

		private List<Edge> edges;

		public Shape () {

			edges = new List<Edge> ();

		}

		public List<Edge> getEdges() {
			return this.edges;
		}

		public void setEdges(List<Edge> e) {
			this.edges = e;
		}

		public void Draw(ref DrawImage d, double[,] matrix, ViewVolume vv) {

			List<Edge> e = this.edges;

			for (int i = 0; i < e.Count; i++) {
				Edge eNew = (Edge)e [i];
				Vertex start = GraphicsMath.convertVertexToViewVolume (matrix, eNew.getStart ());
				Vertex end = GraphicsMath.convertVertexToViewVolume (matrix, eNew.getEnd ());
				if (vv.pointInViewVolume (start) && vv.pointInViewVolume (end)) {
					start = vv.projectOntoVPWindow (start);
					end = vv.projectOntoVPWindow (end);
					eNew = new Edge (start, end);
					GraphicsMath.RasterizeEdge (eNew, ref d, vv);
				}

			}

		}

	}
}

