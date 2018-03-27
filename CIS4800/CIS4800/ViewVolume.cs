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

		public ViewVolume (double dist, double azimuth, double elevation, double d, double f, double h) {

			double retX = dist * Math.Cos (elevation) * Math.Cos (azimuth);
			double retY = dist * Math.Cos (elevation) * Math.Sin (azimuth);
			double retZ = dist * Math.Sin (elevation);

			this.viewPoint = new Vertex (retX, retY, retZ);
			this.d = d;
			this.f = f;
			this.h = h;

		}

		public ViewVolume (Vertex vp, double d, double f, double h) {

			this.viewPoint = vp;
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

			//N x V
			retX = (N.getY () * V.getZ ()) - (V.getY () * N.getZ ());
			retY = (N.getZ () * V.getX ()) - (V.getZ () * N.getX ());
			retZ = (N.getX () * V.getY ()) - (V.getX () * N.getY ());

			Vector v = new Vector (retX, retY, retZ);
			v = GraphicsMath.normalizeVector (v);

			this.U = v;

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

			Vector v = new Vector (retX, retY, retZ);
			v = GraphicsMath.normalizeVector (v);

			this.V = v;

		}

		public void computeN (Vertex p, Vertex q) {

			double retX = q.getX () - p.getX ();
			double retY = q.getY () - p.getY ();
			double retZ = q.getZ () - p.getZ ();

			Vector v = new Vector (retX, retY, retZ);
			v = GraphicsMath.normalizeVector (v);

			this.N = v;

		}

		public Boolean pointInViewVolume(Vertex p) {

			double x, y, z;

			x = p.getX ();
			y = p.getY ();
			z = p.getZ ();

			double div = (double)(this.h / this.d);

			if ((x >= (-1 * div * z)) && (x <= (div * z))) {//fits x

				if ((y >= (-1 * div * z)) && (y <= (div * z))) {//fits y

					//if ((z >= this.d) && (z <= this.f)) {
					//Console.WriteLine(x + ", " + y + ", " + z + " are in the view volume");
						return true;
					//}

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

			_x = (x / z) * this.d;
			_y = (y / z) * this.d;
			_z = this.d;

			return new Vertex (_x, _y, _z);

		}

	}

}

 