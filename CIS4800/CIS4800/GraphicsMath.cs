using System;
using System.Drawing;
using System.Collections;

namespace CIS4800 {
	
	public class GraphicsMath {

		/*
		 * public double Convert3DToPlane()
		 * Parameters: dimen - dimension of the 2D plane for the particular coordinate
		 * 			   coord - Coordinate position of the 3D vertex
		 * Assumes the assignment-specified 3D view volume (from -1 to 1)
		 * Top-left pixel is represented by (-1, 1, -1) in the view volume,
		 * and the bottom-right pixel is represented by (1, -1, -1).
		 * Converts the position of the 3D pixel to the 2D plane position
		 * */
		public static double[] Convert3DToPlane(int dimen, Vertex coord, ViewVolume v) {
			
			double[] ret = new double[2];
			double h = v.getViewRange ();

			//ret[0] is the row, ret[1] is the column
			ret[0] = (dimen / 2) - (coord.getY() * (dimen / 2)) - 0.5;
			ret[1] = (dimen / 2) + (coord.getX() * (dimen / 2)) -0.5;

			if (ret [0] < 0)
				ret [0] = 0;
			else if (ret [0] >= dimen)
				ret [0] = dimen - 1;

			if (ret [1] < 0)
				ret [1] = 0;
			else if (ret [1] >= dimen)
				ret [1] = dimen - 1;

			Console.WriteLine ("XConverted " + coord.getY () + " to " + ret [0]);
			Console.WriteLine ("YConverted " + coord.getX () + " to " + ret [1]);

			return ret;

		}

		/* public void RasterizeEdge()
		 * Parameters: s - starting Vertex
		 * 			   e - ending Vertex
		 * 			   d - object for drawing the output to an image
		 * Uses Digital Differential Analyzer (DDA) algorithm to rasterize
		 * the line. Simple way to decide which pixels represent an edge.
		 * */
		public static void RasterizeEdge(Edge e, ref DrawImage d, ViewVolume v) {

			int start_x_rast, start_y_rast, end_x_rast, end_y_rast;
			int x_dist, y_dist;
			int line_type;

			double s_x_img, s_y_img, e_x_img, e_y_img;
			double[] s_new, e_new;

			s_new = Convert3DToPlane (d.getHeight (), e.getStart (), v);
			e_new = Convert3DToPlane (d.getHeight (), e.getEnd (), v);

			s_x_img = s_new [1];
			s_y_img = s_new [0];
			e_x_img = e_new [1];
			e_y_img = e_new [0];

			start_x_rast = (int)Math.Round (s_x_img);
			start_y_rast = (int)Math.Round (s_y_img);
			end_x_rast = (int)Math.Round (e_x_img);
			end_y_rast = (int)Math.Round (e_y_img);

			x_dist = end_x_rast - start_x_rast;
			y_dist = end_y_rast - start_y_rast;

			if (Math.Abs(x_dist) <= Math.Abs(y_dist)) {
				line_type = 0;//vertical
			} else {
				line_type = 1;//horizontal
			}
			
			if (line_type == 0) {//vertical
				
				double tmp = start_x_rast;
				double m;
				if (y_dist == 0)
					m = 0; 
				else 
					m = (double)(x_dist)/(double)(y_dist);
				if (end_y_rast > start_y_rast) {
					for (int i = start_y_rast; i <= end_y_rast; i++) {
						d.DrawPixelAt((int)Math.Round(tmp), i, Color.FromArgb(255, 255, 0, 0));
						tmp += m;
					}
				} else {
					for (int i = start_y_rast; i >= end_y_rast; i--) {
						d.DrawPixelAt((int)Math.Round(tmp), i, Color.FromArgb(255, 255, 0, 0));
						tmp -= m;
					}
				}
				
			} else if (line_type == 1) {//horizontal
				
				double tmp = start_y_rast;
				double m;
				if (x_dist == 0)
					m = 0;
				else
					m = (double)(y_dist)/(double)(x_dist);
				if (end_x_rast > start_x_rast) {
					for (int i = start_x_rast; i <= end_x_rast; i++) {
						d.DrawPixelAt(i, (int)Math.Round(tmp), Color.FromArgb(255, 255, 0, 0));
						tmp += m;
					}
				} else {
					for (int i = start_x_rast; i >= end_x_rast; i--) {
						d.DrawPixelAt(i, (int)Math.Round(tmp), Color.FromArgb(255, 255, 0, 0));
						tmp -= m;
					}
				}
				
			}
			
		}

		/* 
		 * public double[,] gaussJordanElimination()
		 * Parameters: m[,] - matrix to be modified
		 * Specifically made for the 3x7 matrix specified below
		 */
		public static double[,] gaussJordanElimination (ref double[,] m) {

			//swap left-most 3x3 matrix diagonal where there are zero elements
			for (int i = 0; i < 3; i++) {

				if (m [i, i] == 0) {//need to have a non-zero value; swap

					//find column to swap
					int swap;
					Boolean found_swap = false;
					for (swap = i; swap < 3; swap++) {
						if (m [swap, i] != 0) {
							found_swap = true;
							break;//take this swap value and swap the rows
						}
					}
					if (!found_swap) {//error, no non-zero found in entire column
						return null;
					} else {//swap m[swap] and m[i]
						double[] tmp = new double[7];
						for (int j = 0; j < 7; j++) {
							tmp[j] = m [swap, j];
							m [swap, j] = m [i, j];
							m [i, j] = tmp [j];
						}
					}

				}

			}

			//Elimination steps for required cells

			double mul1, mul2;
			//matrix[1,0]
			if (m [1, 0] != 0) {

				mul1 = m [0, 0];
				mul2 = m [1, 0];
				for (int i = 0; i < 7; i++) {
					m [1, i] = m [1, i] * mul1 - m [0, i] * mul2;
				}

			}

			//matrix[2,0]
			if (m [2, 0] != 0) {

				mul1 = m [0, 0];
				mul2 = m [2, 0];
				for (int i = 0; i < 7; i++) {
					m [2, i] = m [2, i] * mul1 - m [0, i] * mul2; 
				}

			}

			//matrix[2,1]
			if (m [2, 1] != 0) {

				mul1 = m [1, 1];
				mul2 = m [2, 1];
				for (int i = 0; i < 7; i++) {
					m [2, i] = m [2, i] * mul1 - m [1, i] * mul2;
				}

			}

			//matrix[1,2]
			if (m [1, 2] != 0) {

				mul1 = m [2, 2];
				mul2 = m [1, 2];
				for (int i = 0; i < 7; i++) {
					m [1, i] = m [1, i] * mul1 - m [2, i] * mul2;
				}

			}

			//matrix[0,2]
			if (m [0, 2] != 0) {

				mul1 = m [2, 2];
				mul2 = m [0, 2];
				for (int i = 0; i < 7; i++) {
					m [0, i] = m [0, i] * mul1 - m [2, i] * mul2;
				}

			}

			//matrix[0,1]
			if (m [0, 1] != 0) {

				mul1 = m [1, 1];
				mul2 = m [0, 1];
				for (int i = 0; i < 7; i++) {
					m [0, i] = m [0, i] * mul1 - m [1, i] * mul2;
				}

			}

			//Check to see if diagonal is all = to 1
			for (int i = 0; i < 3; i++) {
				if (m [i, i] != 1) {
					double tmp = m [i, i];
					for (int j = 0; j < 7; j++) {
						m [i, j] = (double)(m [i, j] / tmp);
					}
				}
			}

			return m;

		}

		public static double[,]	getViewSpaceCoordinates(ViewVolume vv, WorldSpace w) {

			/*MATRIX
			 * U, V, N = basis of view volume
			 * W = coords of view volume relative to world
			 *  X  Y  Z  | x y z  1
			 * [Xu Xv Xn | 1 0 0 -Xw]
			 * [Yu Yv Yn | 0 1 0 -Yw]
			 * [Zu Zv Zn | 0 0 1 -Zw]
			*/

			double[,] matrix = new double[3,7] { {0, 0, 0, 1, 0, 0, 0}, {0, 0, 0, 0, 1, 0, 0}, {0, 0, 0, 0, 0, 1, 0} };

			//setup view volume coordinates relative to world space
			matrix [0, 6] = vv.getViewPoint ().getX () * -1;
			matrix [1, 6] = vv.getViewPoint ().getY () * -1;
			matrix [2, 6] = vv.getViewPoint ().getZ () * -1;

			//get normal
			vv.computeN(vv.getViewPoint(), w.getOrigin());
			matrix [0, 2] = vv.getN ().getX ();
			matrix [1, 2] = vv.getN ().getY ();
			matrix [2, 2] = vv.getN ().getZ ();

			vv.computeV (w.getHeight ());
			vv.computeU ();

			matrix [0, 0] = vv.getU ().getX ();
			matrix [1, 0] = vv.getU ().getY ();
			matrix [2, 0] = vv.getU ().getZ ();

			matrix [0, 1] = vv.getV ().getX ();
			matrix [1, 1] = vv.getV ().getY ();
			matrix [2, 1] = vv.getV ().getZ ();

			gaussJordanElimination (ref matrix);

			return matrix;

		}

		public static Vertex convertVertexToViewPlane(double[,] m, Vertex p) {

			double retX, retY, retZ;

			retX = m [0, 3] * p.getX () + m [0, 4] * p.getY () + m [0, 5] * p.getZ () + m [0, 6];
			retY = m [1, 3] * p.getX () + m [1, 4] * p.getY () + m [1, 5] * p.getZ () + m [1, 6];
			retZ = m [2, 3] * p.getX () + m [2, 4] * p.getY () + m [2, 5] * p.getZ () + m [2, 6];

			return new Vertex (retX, retY, retZ);

		}

	}
}

