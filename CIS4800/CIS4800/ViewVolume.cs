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

		public ViewVolume(double dist, double azimuth, double elevation, double near, double far, double range) {

			double x = dist * Math.Cos (elevation) * Math.Cos (azimuth);
			double y = dist * Math.Cos (elevation) * Math.Sin (azimuth);
			double z = dist * Math.Sin (elevation);

			viewPoint = new Vertex (x, y, z);
			f = far;
			d = near;
			h = range;

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

			Vector v = new Vector (retX, retY, retZ);
			v = GraphicsMath.normalizeVector (v);

			this.U = v;

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

		public Boolean pointIsInVV(Vertex p) {

			double x = p.getX ();
			double y = p.getY ();
			double z = p.getZ ();

			double div = (double)(this.h / this.d);

			if ((x >= (-1 * div * z)) && (x <= (div * z))) {

				if ((y >= (-1 * div * z)) && (y <= (div * z))) {

					return true;

				}

			}

			return false;

		}

		public Vertex projectOntoVPWindow(Vertex p) {

			double x = p.getX ();
			double y = p.getY ();
			double z = p.getZ ();

			double _x = (x / z) * this.d;
			double _y = (y / z) * this.d;
			double _z = this.d;

			return new Vertex (_x, _y, _z);

		}

	}

}

