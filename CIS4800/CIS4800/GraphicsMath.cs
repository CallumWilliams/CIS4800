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
		public static double Convert3DToPlane(int dimen, double coord, int type) {

			if (type == 0) {//convert x
				double ret = (dimen / 2) + (coord * (dimen / 2)) - 1;
				if (ret < 0)
					return 0;
				if (ret >= dimen)
					return dimen - 1;
				return ret;
			} else {//convert y
				double ret = (dimen / 2) - (coord * (dimen / 2)) - 1;
				if (ret < 0)
					return 0;
				if (ret >= dimen)
					return dimen - 1;
				return ret;
			}


		}

		/* public void RasterizeEdge()
		 * Parameters: s - starting Vertex
		 * 			   e - ending Vertex
		 * 			   d - object for drawing the output to an image
		 * Uses Digital Differential Analyzer (DDA) algorithm to rasterize
		 * the line. Simple way to decide which pixels represent an edge.
		 * */
		public static void RasterizeEdge(Edge e, ref DrawImage d) {

			int start_x_rast, start_y_rast, end_x_rast, end_y_rast;
			int x_dist, y_dist;
			int line_type;

			double s_x_img, s_y_img, e_x_img, e_y_img;

			s_x_img = Convert3DToPlane (d.getWidth (), e.getStart().getX (), 0);
			s_y_img = Convert3DToPlane (d.getHeight (), e.getStart().getY (), 1);
			e_x_img = Convert3DToPlane (d.getWidth (), e.getEnd().getX (), 0);
			e_y_img = Convert3DToPlane (d.getHeight (), e.getEnd().getY (), 1);

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

		public Vector buildVectorFromPoints(Vertex p, Vertex q) {

			double retX = q.getX () - p.getX ();
			double retY = q.getY () - p.getY ();
			double retZ = q.getZ () - p.getZ ();

			return new Vector (retX, retY, retZ);

		}

		public double[,] getViewSpaceCoordinates(Vertex p, ViewVolume vv, WorldSpace w) {

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
			matrix [2, 6] = vv.getViewPoint ().getY () * -1;

			//add p (from world space)

			//get normal
			Vector N = buildVectorFromPoints (v, w);
			matrix [0, 2] = N.getX ();
			matrix [1, 2] = N.getY ();
			matrix [2, 2] = N.getZ ();

			

			Console.WriteLine (matrix);

			return matrix;

		}

	}
}

