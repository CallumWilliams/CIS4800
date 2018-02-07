using System;

namespace CIS4800 {

	public class ViewVolume {

		Vertex viewPoint;//view point (origin)
		Vector U;//vertical vector
		Vector V;//horizontal vector
		Vector N;//viewing direction
		double f;//far plane
		double d;//near plane
		double h;//Left/right view range

		public ViewVolume (Vertex vp, double f, double d, double h) {

			viewPoint = vp;
			this.f = f;
			this.d = d;
			this.h = h;

		}

		public Vertex getViewPoint () {
			return this.viewPoint;
		}

		public double getFarPlane () {
			return this.f;
		}

		public double getNearPlane () {
			return this.d;
		}

		public double getViewRange () {
			return this.h;
		}

		public Vector getV () {
			return this.V;
		}

		public Vector getU () {
			return this.U;
		}

		public Vector getN () {
			return this.N;
		}

		public void computeU () {

			double retX, retY, retZ;

			retX = (N.getY () * V.getZ () - N.getZ () * V.getY ());
			retY = (N.getZ () * V.getX () - N.getX () * V.getZ ());
			retZ = (N.getX () * V.getY () - N.getY () * V.getX ());

			this.U = new Vector (retX, retY, retZ);

		}

		public void computeV (Vector k) {

			//generate an arbitrary vector that is not the same as N, and calculate their cross product
			//cross product will give perpendicular vector

			double retX, retY, retZ;
			Vertex p = this.viewPoint;

			double a, b;

			//generate a and b valiues
			b = 1;
			a = -1 * k.getZ ();

			retX = a * N.getX () + b * k.getX ();
			retY = a * N.getY () + b * k.getY ();
			retZ = a * N.getZ () + b * k.getZ ();

			this.V = new Vector (retX, retY, retZ);

		}

		public void computeN (Vertex p, Vertex q) {

			double retX = q.getX () - p.getX ();
			double retY = q.getY () - p.getY ();
			double retZ = q.getZ () - p.getZ ();

			//create as unit vector
			/*if (retX != 0)
				retX = retX / Math.Abs (retX);
			if (retY != 0)
				retY = retY / Math.Abs (retY);
			if (retZ != 0)
				retZ = retZ / Math.Abs (retZ);
			*/
			this.N = new Vector (retX, retY, retZ);

		}

	}

}

