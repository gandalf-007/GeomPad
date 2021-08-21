﻿using OpenTK;
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace GeomPad
{
    public static class StaticHelpers
    {
        public static double ParseDouble(string z)
        {
            return double.Parse(z.Replace(",", "."), CultureInfo.InvariantCulture);
        }
        public static float ParseFloat(string z)
        {
            return float.Parse(z.Replace(",", "."), CultureInfo.InvariantCulture);
        }
        public static double signed_area(PointF[] polygon)
        {
            double area = 0.0;

            int j = 1;
            for (int i = 0; i < polygon.Length; i++, j++)
            {
                j = j % polygon.Length;

                area += (polygon[j].X - polygon[i].X) * (polygon[j].Y + polygon[i].Y);
            }

            return area / 2.0;
        }
        public static double signed_area(SvgPoint[] polygon)
        {
            double area = 0.0;

            int j = 1;
            for (int i = 0; i < polygon.Length; i++, j++)
            {
                j = j % polygon.Length;
                area += (polygon[j].X - polygon[i].X) * (polygon[j].Y + polygon[i].Y);
            }

            return area / 2.0;
        }
        public static bool pnpoly(PointF[] verts, float testx, float testy)
        {
            int nvert = verts.Length;
            int i, j;
            bool c = false;
            for (i = 0, j = nvert - 1; i < nvert; j = i++)
            {
                if (((verts[i].Y > testy) != (verts[j].Y > testy)) &&
                    (testx < (verts[j].X - verts[i].X) * (testy - verts[i].Y) / (verts[j].Y - verts[i].Y) + verts[i].X))
                    c = !c;
            }
            return c;
        }
        public static bool pnpoly(SvgPoint[] verts, double testx, double testy)
        {
            int nvert = verts.Length;
            int i, j;
            bool c = false;
            for (i = 0, j = nvert - 1; i < nvert; j = i++)
            {
                if (((verts[i].Y > testy) != (verts[j].Y > testy)) &&
                    (testx < (verts[j].X - verts[i].X) * (testy - verts[i].Y) / (verts[j].Y - verts[i].Y) + verts[i].X))
                    c = !c;
            }
            return c;
        }
        public static Vector3d ToVector3d(this Vector3 v)
        {
            return new Vector3d(v.X, v.Y, v.Z);
        }
        public static Vector3 ToVector3(this Vector3d v)
        {
            return new Vector3((float)v.X, (float)v.Y, (float)v.Z);
        }
        public static double DistTo(this SvgPoint p, SvgPoint p2)
        {
            return Math.Sqrt(Math.Pow(p.X - p2.X, 2) + Math.Pow(p.Y - p2.Y, 2));
        }
        public static double DistTo(this PointF p, PointF p2)
        {
            return Math.Sqrt(Math.Pow(p.X - p2.X, 2) + Math.Pow(p.Y - p2.Y, 2));
        }

        internal static bool ShowQuestion(string v, string title)
        {
            return MessageBox.Show(v, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }
    }
}