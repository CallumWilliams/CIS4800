using System;

namespace CIS4800 {
	
	public class Vector {

		double x;
		double y;
		double z;

		public Vector (double x, double y, double z) {
			this.x = x;
			this.y = y;
			this.z = z;
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

