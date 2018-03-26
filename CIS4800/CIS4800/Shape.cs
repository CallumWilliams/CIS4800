using System;
using System.Collections.Generic;

namespace CIS4800 {
	
	public class Shape {

		private List<Surface> surfaces;
		private Vector Surface;

		public Shape () {

			surfaces = new List<Surface> ();

		}

		public List<Surface> getSurfaces() {
			return this.surfaces;
		}

		public void setSurfaces(List<Surface> e) {
			this.surfaces = e;
		}

		public void Draw(ref DrawImage d, double[,] matrix, ViewVolume vv) {

			List<Surface> surf = this.surfaces;

			for (int i = 0; i < surfaces.Count; i++) {

				Surface s = surf [i];
				List<Edge> e = s.getEdges ();

				for (int j = 0; j < e.Count; j++) {

					Edge eNew = (Edge)e [j];
					Vertex start = GraphicsMath.convertVertexToViewVolume (matrix, eNew.getStart ());
					Vertex end = GraphicsMath.convertVertexToViewVolume (matrix, eNew.getEnd ());
					if (vv.pointIsInVV (start) && vv.pointIsInVV (end)) {
						start = vv.projectOntoVPWindow (start);
						end = vv.projectOntoVPWindow (end);
						eNew = new Edge (start, end);
						GraphicsMath.RasterizeEdge (eNew, ref d, vv);
					}

				}

			}

		}

	}
}

