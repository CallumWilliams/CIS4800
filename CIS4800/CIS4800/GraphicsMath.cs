using System;
using System.Drawing;

namespace CIS4800 {
	
	public class GraphicsMath {

		/*
		 * public double Convert3DToPlane()
		 * Parameters: dimen - dimension of the 2D plane for the particular coordinate
		 * 			   coord - Coordinate position of the 3D vertex
		 * Assumes the assignment-specified 3D view volume (from -1 to 1)
		 * Converts the position of the 3D pixel to the 2D plane position
		 * */
		public static double Convert3DToPlane(int dimen, double coord) {

			if (coord == -1) {
				return 0;
			} else {
				return (dimen / 2) + (coord * (dimen / 2)) - 1;
			}

		}

		/* public void RasterizeEdge()
		 * Parameters: s - starting Vertex
		 * 			   e - ending Vertex
		 * 			   d - object for drawing the output to an image
		 * Uses Digital Differential Analyzer (DDA) algorithm to rasterize
		 * the line. Simple way to decide which pixels represent an edge.
		 * */
		public static void RasterizeEdge(Vertex s, Vertex e, DrawImage d) {

			int start_x_rast, start_y_rast, end_x_rast, end_y_rast;
			int x_dist, y_dist;
			int line_type;

			double s_x_img, s_y_img, e_x_img, e_y_img;

			s_x_img = Convert3DToPlane (d.getWidth (), s.getX ());
			s_y_img = Convert3DToPlane (d.getHeight (), s.getY ());
			e_x_img = Convert3DToPlane (d.getWidth (), e.getX ());
			e_y_img = Convert3DToPlane (d.getHeight (), e.getY ());

			Console.WriteLine (s_x_img + " " + s_y_img + " " + e_x_img + " " + e_y_img);

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
			
			if (line_type == 0) {
				
				double tmp = start_x_rast;
				double m = (double)(x_dist)/(double)(y_dist);
				if (end_y_rast > start_y_rast) {
					for (int i = start_y_rast; i <= end_y_rast; i++) {
					Console.WriteLine("Coord at " + Math.Round(tmp) + " " + i);
						tmp += m;
					}
				} else {
					for (int i = start_y_rast; i >= end_y_rast; i++) {
						Console.WriteLine("Coord at " + Math.Round(tmp) + " " + i);
						tmp -= m;
					}
				}
				
			} else if (line_type == 1) {
				Console.WriteLine ("Horizontal");
				double tmp = start_y_rast;
				double m = (double)(y_dist)/(double)(x_dist);
				if (end_x_rast > start_x_rast) {
					for (int i = start_x_rast; i <= end_x_rast; i++) {
						Console.WriteLine("Coord at " + i + " " + Math.Round(tmp));
						tmp += m;
					}
				} else {
					for (int i = start_x_rast; i >= end_x_rast; i++) {
						Console.WriteLine("Coord at " + i + " " + Math.Round(tmp));
						tmp -= m;
					}
				}
				
			}
			
		}

	}
}

