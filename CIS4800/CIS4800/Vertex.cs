using System;

namespace CIS4800 {
	
	public class Vertex {

		double x;
		double y;
		double z;

		public Vertex (double px, double py, double pz) {
			x = px;
			y = py;
			z = pz;
		}

		public double getX() {
			return this.x;
		}

		public double getY() {
			return this.y;
		}

		public double getZ() {
			return this.z;
		}

	}
}

