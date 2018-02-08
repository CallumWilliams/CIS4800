using System;

namespace CIS4800 {

	public class ViewVolume {

		Vertex viewPoint;//view point (origin)
		Vector U;//vertical vector
		Vector V;//horizontal vector
		Vector N;//viewing direction
		double d;//near plane
		double f;//far plane
		double h;//Left/right view range

		public ViewVolume (double dist, double theta, double omega, double d, double f, double h) {

			double retX, retY, retZ;
			retX = dist * Math.Cos (omega) * Math.Cos (theta);
			retY = dist * Math.Cos (omega) * Math.Sin (theta);
			retZ = dist * Math.Sin (omega);

			this.viewPoint = new Vertex (retX, retY, retZ);
			this.d = d;
			this.f = f;
			this.h = h;

		}

		public ViewVolume (Vertex vp, double d, double f, double h) {

			viewPoint = vp;
			this.d = d;
			this.f = f;
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

			//V x N
			retX = (V.getY () * N.getZ () - N.getY () * V.getZ ());
			retY = (V.getZ () * N.getX () - N.getZ () * V.getX ());
			retZ = (V.getX () * N.getY () - N.getX () * V.getY ());

			this.U = new Vector (retX, retY, retZ);

		}

		public void computeV (Vector k) {

			double retX, retY, retZ;
			Vertex p = this.viewPoint;

			double a, b;

			//generate a and b values
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

			

			this.N = new Vector (retX, retY, retZ);

		}

		public Boolean pointInViewVolume(Vertex p) {

			double x, y, z;

			x = p.getX ();
			y = p.getY ();
			z = p.getZ ();

			double ztmp = z;
			if (z < 0)
				ztmp *= -1;

			double div = this.h / this.d;

			if ((x >= (-1 * div * z)) && (x <= (div * z))) {//fits x

				if ((y >= (-1 * div * z)) && (y <= (div * z))) {//fits y

					if ((z >= this.d) && (z <= this.f)) {
						return true;
					}

				}

			}

			return false;

		}

		public Vertex projectOntoVPWindow(Vertex p) {

			double x, y, z;
			double _x, _y, _z;

			x = p.getX ();
			y = p.getY ();
			z = p.getZ ();
			if (z == 0)
				z = 0.00001;

			_x = (x / z) * this.d;
			_y = (y / z) * this.d;
			_z = this.d;

			Console.WriteLine (x + ", " + y + ", " + z + " to " + _x + ", " + _y + ", " + _z);

			return new Vertex (_x, _y, _z);

		}

	}

}

 