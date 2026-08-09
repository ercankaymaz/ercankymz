using System;
using System.Collections.Generic;
using System.Drawing;

namespace buClass;

[Serializable]
public class eSurface : eEntities
{
	public SurfaceType SurfType = SurfaceType.ByTriangle;

	public List<List<Pnt3D>> XDirectionPoints = null;

	public List<List<Pnt3D>> YDirectionPoints = null;

	public List<Pnt3D> BorderPoints = null;

	public List<Pnt3D> ContourPoints = null;

	public List<Pnt3D> OutsidePoints = null;

	public List<List<Pnt3D>> InsidePoints = null;

	public Vec3D SurfDirection = new Vec3D();

	public double SurfHeight = 10.0;

	public double SurfLength = 100.0;

	public List<TriangleIndex> TriIndex = new List<TriangleIndex>();

	public eSurface()
	{
		Triangles = new List<Triangle3D>();
	}

	public eSurface(eEntities ent)
	{
		SurfLength = ((eSurface)ent).SurfLength;
		SurfHeight = ((eSurface)ent).SurfHeight;
		SurfDirection = new Vec3D(((eSurface)ent).SurfDirection);
		TriIndex.Clear();
		for (int i = 0; i <= ((eSurface)ent).TriIndex.Count - 1; i++)
		{
			TriIndex.Add(new TriangleIndex(((eSurface)ent).TriIndex[i]));
		}
		if (!(ent.GetType() == typeof(eSurface)))
		{
			return;
		}
		if (((eSurface)ent).Triangles != null)
		{
			if (Triangles == null)
			{
				Triangles = new List<Triangle3D>();
			}
			Triangles.Clear();
			Triangles = new List<Triangle3D>();
			for (int j = 0; j <= ((eSurface)ent).Triangles.Count - 1; j++)
			{
				Triangles.Add(new Triangle3D(((eSurface)ent).Triangles[j]));
				Vertice.Add(new Pnt3D(Triangles[j].FirstPoint));
				Vertice.Add(new Pnt3D(Triangles[j].SecondPoint));
				Vertice.Add(new Pnt3D(Triangles[j].ThirdPoint));
			}
		}
		if (((eSurface)ent).ContourPoints != null)
		{
			if (ContourPoints == null)
			{
				ContourPoints = new List<Pnt3D>();
			}
			ContourPoints.Clear();
			ContourPoints = new List<Pnt3D>();
			for (int k = 0; k <= ((eSurface)ent).ContourPoints.Count - 1; k++)
			{
				ContourPoints.Add(new Pnt3D(((eSurface)ent).ContourPoints[k]));
			}
		}
		if (((eSurface)ent).BorderPoints != null)
		{
			if (BorderPoints == null)
			{
				BorderPoints = new List<Pnt3D>();
			}
			BorderPoints.Clear();
			BorderPoints = new List<Pnt3D>();
			for (int l = 0; l <= ((eSurface)ent).BorderPoints.Count - 1; l++)
			{
				BorderPoints.Add(new Pnt3D(((eSurface)ent).BorderPoints[l]));
			}
		}
		if (((eSurface)ent).XDirectionPoints != null)
		{
			if (XDirectionPoints == null)
			{
				XDirectionPoints = new List<List<Pnt3D>>();
			}
			XDirectionPoints.Clear();
			XDirectionPoints = new List<List<Pnt3D>>();
			for (int m = 0; m <= ((eSurface)ent).XDirectionPoints.Count - 1; m++)
			{
				List<Pnt3D> CopiedPnt = new List<Pnt3D>();
				Pnt3D.Copy(((eSurface)ent).XDirectionPoints[m], ref CopiedPnt);
				XDirectionPoints.Add(CopiedPnt);
			}
		}
		if (((eSurface)ent).YDirectionPoints != null)
		{
			if (YDirectionPoints == null)
			{
				YDirectionPoints = new List<List<Pnt3D>>();
			}
			YDirectionPoints.Clear();
			YDirectionPoints = new List<List<Pnt3D>>();
			for (int n = 0; n <= ((eSurface)ent).YDirectionPoints.Count - 1; n++)
			{
				List<Pnt3D> CopiedPnt2 = new List<Pnt3D>();
				Pnt3D.Copy(((eSurface)ent).YDirectionPoints[n], ref CopiedPnt2);
				YDirectionPoints.Add(CopiedPnt2);
			}
		}
		if (((eSurface)ent).InsidePoints != null)
		{
			if (InsidePoints == null)
			{
				InsidePoints = new List<List<Pnt3D>>();
			}
			InsidePoints.Clear();
			InsidePoints = new List<List<Pnt3D>>();
			for (int num = 0; num <= ((eSurface)ent).InsidePoints.Count - 1; num++)
			{
				List<Pnt3D> CopiedPnt3 = new List<Pnt3D>();
				Pnt3D.Copy(((eSurface)ent).InsidePoints[num], ref CopiedPnt3);
				InsidePoints.Add(CopiedPnt3);
			}
		}
		eEntities.CopyBase(ent, this);
		Update();
	}

	public eSurface(List<Triangle3D> triangles)
	{
		if (Triangles == null)
		{
			Triangles = new List<Triangle3D>();
		}
		Triangles = new List<Triangle3D>();
		Vertice.Clear();
		for (int i = 0; i <= triangles.Count - 1; i++)
		{
			Triangles.Add(new Triangle3D(triangles[i]));
			Vertice.Add(new Pnt3D(triangles[i].FirstPoint));
			Vertice.Add(new Pnt3D(triangles[i].SecondPoint));
			Vertice.Add(new Pnt3D(triangles[i].ThirdPoint));
		}
		SurfType = SurfaceType.ByTriangle;
		Update();
	}

	public eSurface(List<Triangle3D> triangles, Color Color)
	{
		if (Triangles == null)
		{
			Triangles = new List<Triangle3D>();
		}
		Triangles = new List<Triangle3D>();
		for (int i = 0; i <= triangles.Count - 1; i++)
		{
			Triangles.Add(new Triangle3D(triangles[i]));
			Vertice.Add(new Pnt3D(triangles[i].FirstPoint));
			Vertice.Add(new Pnt3D(triangles[i].SecondPoint));
			Vertice.Add(new Pnt3D(triangles[i].ThirdPoint));
		}
		dispColor = Color;
		SurfType = SurfaceType.ByTriangle;
		Update();
	}

	public eSurface(List<TriangleIndex> trianglesindex, List<Pnt3D> vertices, Color Color)
	{
		if (Triangles == null)
		{
			Triangles = new List<Triangle3D>();
		}
		Triangles = new List<Triangle3D>();
		for (int i = 0; i <= trianglesindex.Count - 1; i++)
		{
			TriIndex.Add(new TriangleIndex(trianglesindex[i]));
		}
		for (int j = 0; j <= vertices.Count - 1; j++)
		{
			Vertice.Add(new Pnt3D(vertices[j]));
		}
		dispColor = Color;
		SurfType = SurfaceType.ByTriangle;
	}

	public eSurface(List<Triangle3D> triangles, List<List<Pnt3D>> xDirectionPoints, List<List<Pnt3D>> yDirectionPoints, List<Pnt3D> borderPoints)
	{
		if (Triangles == null)
		{
			Triangles = new List<Triangle3D>();
		}
		Triangles = new List<Triangle3D>();
		for (int i = 0; i <= triangles.Count - 1; i++)
		{
			Triangles.Add(new Triangle3D(triangles[i]));
			Vertice.Add(new Pnt3D(Triangles[i].FirstPoint));
			Vertice.Add(new Pnt3D(Triangles[i].SecondPoint));
			Vertice.Add(new Pnt3D(Triangles[i].ThirdPoint));
		}
		XDirectionPoints = new List<List<Pnt3D>>();
		for (int j = 0; j <= xDirectionPoints.Count - 1; j++)
		{
			List<Pnt3D> CopiedPnt = new List<Pnt3D>();
			Pnt3D.Copy(xDirectionPoints[j], ref CopiedPnt);
			XDirectionPoints.Add(CopiedPnt);
		}
		YDirectionPoints = new List<List<Pnt3D>>();
		for (int k = 0; k <= yDirectionPoints.Count - 1; k++)
		{
			List<Pnt3D> CopiedPnt2 = new List<Pnt3D>();
			Pnt3D.Copy(yDirectionPoints[k], ref CopiedPnt2);
			YDirectionPoints.Add(CopiedPnt2);
		}
		SurfType = SurfaceType.ByGrid;
		BorderPoints = new List<Pnt3D>();
		Pnt3D.Copy(borderPoints, ref BorderPoints);
		Update();
	}

	public eSurface(List<Triangle3D> triangles, List<List<Pnt3D>> xDirectionPoints, List<List<Pnt3D>> yDirectionPoints, List<Pnt3D> borderPoints, Color Color)
	{
		if (Triangles == null)
		{
			Triangles = new List<Triangle3D>();
		}
		Triangles = new List<Triangle3D>();
		for (int i = 0; i <= triangles.Count - 1; i++)
		{
			Triangles.Add(new Triangle3D(triangles[i]));
			Vertice.Add(new Pnt3D(Triangles[i].FirstPoint));
			Vertice.Add(new Pnt3D(Triangles[i].SecondPoint));
			Vertice.Add(new Pnt3D(Triangles[i].ThirdPoint));
		}
		XDirectionPoints = new List<List<Pnt3D>>();
		for (int j = 0; j <= xDirectionPoints.Count - 1; j++)
		{
			List<Pnt3D> CopiedPnt = new List<Pnt3D>();
			Pnt3D.Copy(xDirectionPoints[j], ref CopiedPnt);
			XDirectionPoints.Add(CopiedPnt);
		}
		YDirectionPoints = new List<List<Pnt3D>>();
		for (int k = 0; k <= yDirectionPoints.Count - 1; k++)
		{
			List<Pnt3D> CopiedPnt2 = new List<Pnt3D>();
			Pnt3D.Copy(yDirectionPoints[k], ref CopiedPnt2);
			YDirectionPoints.Add(CopiedPnt2);
		}
		SurfType = SurfaceType.ByGrid;
		BorderPoints = new List<Pnt3D>();
		Pnt3D.Copy(borderPoints, ref BorderPoints);
		dispColor = Color;
		Update();
	}

	public eSurface(List<Triangle3D> triangles, List<Pnt3D> contourPoints, double surflength, Vec3D surfdirection)
	{
		if (Triangles == null)
		{
			Triangles = new List<Triangle3D>();
		}
		Triangles = new List<Triangle3D>();
		for (int i = 0; i <= triangles.Count - 1; i++)
		{
			Triangles.Add(new Triangle3D(triangles[i]));
			Vertice.Add(new Pnt3D(Triangles[i].FirstPoint));
			Vertice.Add(new Pnt3D(Triangles[i].SecondPoint));
			Vertice.Add(new Pnt3D(Triangles[i].ThirdPoint));
		}
		if (ContourPoints == null)
		{
			ContourPoints = new List<Pnt3D>();
		}
		ContourPoints = new List<Pnt3D>();
		Pnt3D.Copy(contourPoints, ref ContourPoints);
		SurfLength = surflength;
		SurfDirection = new Vec3D(surfdirection);
		SurfType = SurfaceType.ByExtrudeWithVector;
		Update();
	}

	public eSurface(TriangulationPoints TP, double surfheight)
	{
		if (Triangles == null)
		{
			Triangles = new List<Triangle3D>();
		}
		Triangles.Clear();
		Triangles = new List<Triangle3D>();
		for (int i = 0; i <= TP.Triangles.Count - 1; i++)
		{
			Triangles.Add(new Triangle3D(TP.Triangles[i]));
		}
		if (OutsidePoints == null)
		{
			OutsidePoints = new List<Pnt3D>();
		}
		if (InsidePoints == null)
		{
			InsidePoints = new List<List<Pnt3D>>();
		}
		OutsidePoints.Clear();
		OutsidePoints = new List<Pnt3D>();
		Pnt3D.Copy(TP.Points, ref OutsidePoints);
		InsidePoints.Clear();
		InsidePoints = new List<List<Pnt3D>>();
		Pnt3D.Copy(TP.Holes, ref InsidePoints);
		SurfHeight = surfheight;
		SurfType = SurfaceType.ByPlane;
		Update();
	}

	public eSurface(List<Pnt3D> outter, List<List<Pnt3D>> inner, List<Triangle3D> triangles, double surfheight)
	{
		if (Triangles == null)
		{
			Triangles = new List<Triangle3D>();
		}
		Triangles.Clear();
		Triangles = new List<Triangle3D>();
		for (int i = 0; i <= triangles.Count - 1; i++)
		{
			Triangles.Add(new Triangle3D(triangles[i]));
		}
		if (OutsidePoints == null)
		{
			OutsidePoints = new List<Pnt3D>();
		}
		if (InsidePoints == null)
		{
			InsidePoints = new List<List<Pnt3D>>();
		}
		OutsidePoints.Clear();
		OutsidePoints = new List<Pnt3D>();
		Pnt3D.Copy(outter, ref OutsidePoints);
		InsidePoints.Clear();
		InsidePoints = new List<List<Pnt3D>>();
		Pnt3D.Copy(inner, ref InsidePoints);
		SurfHeight = surfheight;
		Update();
	}

	public static eSurface DecodeSurface(List<string> Codes)
	{
		eSurface eSurface2 = new eSurface();
		List<cParameter> Vars = new List<cParameter>();
		buSerilization.GetClassVariableValuesFromStringCodes(Codes, eSurface2, ref Vars);
		if (Vars.Count > 0)
		{
			object obj = null;
			obj = eSurface2;
			buSerilization.SetClassVariables(ref obj, Vars);
		}
		eSurface2.Update();
		return eSurface2;
	}
}
