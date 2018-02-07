using System;

namespace CIS4800 {
	
	public class WorldSpace {

		Vertex O;
		Vector I;//the vector of the X direction
		Vector J;//the vector of the Y direction
		Vector K;//the vector of the Z direction

		public WorldSpace (Vertex o, double i, double j, double k) {

			this.O = o;
			this.I = new Vector (i, 0, 0);
			this.J = new Vector (0, j, 0);
			this.K = new Vector (0, 0, k);

		}

		public Vertex getOrigin() {
			return this.O;
		}

		public Vector getWidth() {
			return this.I;
		}

		public Vector getHeight() {
			return this.K;
		}

		public Vector getDepth() {
			return this.J;
		}

	}
}

