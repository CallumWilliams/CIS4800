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
				return ret;
			} else {//convert y
				double ret = (dimen / 2) - (coord * (dimen / 2)) - 1;
				if (ret < 0)
					return 0;
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
					Console.WriteLine (start_y_rast + " " + end_y_rast);
					for (int i = start_y_rast; i >= end_y_rast; i--) {
						Console.WriteLine ("at " + i);
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

		private static ArrayList SetupCube() {

			ArrayList ae = new ArrayList ();

			//Setup top surface
			Vertex v1 = new Vertex (1, 1, 1);
			Vertex v2 = new Vertex (1, 1, -1);
			ae.Add (new Edge (v1, v2));

			v1 = new Vertex (1, 1, 1);
			v2 = new Vertex (-1, 1, 1);
			ae.Add (new Edge (v1, v2));

			v1 = new Vertex (1, 1, -1);
			v2 = new Vertex (-1, 1, -1);
			ae.Add (new Edge (v1, v2));

			v1 = new Vertex (-1, 1, 1);
			v2 = new Vertex (-1, 1, -1);
			ae.Add (new Edge (v1, v2));

			//Setup side surfaces
			v1 = new Vertex (1, 1, 1);
			v2 = new Vertex (1, -1, 1);
			ae.Add (new Edge (v1, v2));

			v1 = new Vertex (1, 1, -1);
			v2 = new Vertex (1, -1, -1);
			ae.Add (new Edge (v1, v2));

			v1 = new Vertex (-1, 1, 1);
			v2 = new Vertex (-1, -1, 1);
			ae.Add (new Edge (v1, v2));

			v1 = new Vertex (-1, 1, -1);
			v2 = new Vertex (-1, -1, -1);
			ae.Add (new Edge (v1, v2));

			//Setup bottom surface
			v1 = new Vertex (1, -1, 1);
			v2 = new Vertex (1, -1, -1);
			ae.Add (new Edge (v1, v2));

			v1 = new Vertex (1, -1, 1);
			v2 = new Vertex (-1, -1, 1);
			ae.Add (new Edge (v1, v2));

			v1 = new Vertex (1, -1, -1);
			v2 = new Vertex (-1, -1, -1);
			ae.Add (new Edge (v1, v2));

			v1 = new Vertex (-1, -1, 1);
			v2 = new Vertex (-1, -1, -1);
			ae.Add (new Edge (v1, v2));

			return ae;

		}

		public static void DrawCube(ref DrawImage img) {

			ArrayList e = SetupCube ();
			for (int i = 0; i < e.Count; i++) {
				Console.WriteLine (i);
				RasterizeEdge ((Edge)e [i], ref img);
			}

		}

		public static ArrayList setupPyramid() {

			ArrayList ae = new ArrayList ();
			//Top point
			Vertex v1 = new Vertex (0, 1, 0);

			//Connect top point to base
			Vertex v2 = new Vertex (1, -1, 1);
			ae.Add (new Edge (v1, v2));

			v2 = new Vertex (-1, -1, 1);
			ae.Add (new Edge (v1, v2));

			v2 = new Vertex (1, -1, -1);
			ae.Add (new Edge (v1, v2));

			v2 = new Vertex (-1, -1, -1);
			ae.Add (new Edge (v1, v2));

			//Setup base of pyramid
			v1 = new Vertex (-1, -1, -1);
			v2 = new Vertex (1, -1, -1);
			ae.Add (new Edge (v1, v2));

			v1 = new Vertex (-1, -1, -1);
			v2 = new Vertex (-1, -1, 1);
			ae.Add (new Edge (v1, v2));

			v1 = new Vertex (1, -1, 1);
			v2 = new Vertex (-1, -1, 1);
			ae.Add (new Edge (v1, v2));

			v1 = new Vertex (1, -1, 1);
			v2 = new Vertex (1, -1, -1);
			ae.Add (new Edge (v1, v2));

			return ae;

		}

		public static void DrawPyramid(ref DrawImage img) {

			ArrayList e = setupPyramid ();
			for (int i = 0; i < e.Count; i++) {
				RasterizeEdge ((Edge)e [i], ref img);
			}

		}

	}
}

