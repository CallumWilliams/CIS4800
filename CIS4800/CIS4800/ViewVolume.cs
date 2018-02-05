using System;

namespace CIS4800 {

	public class ViewVolume {

		Vertex viewPoint;//view point (origin)
		double U;//x of view point
		double V;//y of view point
		double N;//z of view point
		double f;//far plane
		double d;//near plane
		double h;//Left/right view range

		public ViewVolume (Vertex vp, double u, double v, double n, double f, double d, double h) {

			viewPoint = vp;
			this.U = u;
			this.V = v;
			this.N = n;
			this.f = f;
			this.d = d;
			this.h = h;

		}

		public Vertex getViewPoint() {
			return this.viewPoint;
		}

		public double getU() {
			return this.U;
		}

		public double getV() {
			return this.V;
		}

		public double getViewDirection() {
			return this.N;
		}

		public double getFarPlane() {
			return this.f;
		}

		public double getNearPlane() {
			return this.d;
		}

		public double getViewRange() {
			return this.h;
		}

	}

}

