using System.Collections.Generic;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Graphics;

public class GfxSilhoData
{
	public Entity Entity;

	public Stack<BlockReference> Parents;

	public float[,] Vertices;

	public double[,] dblVertices;

	public SilhoVertexArrayData VertexArrayData;

	protected double[,] ComputeScreenVerticesDouble(RenderContextBase renderContext, Transformation transf, double[] modelViewProj, int[] viewFrame)
	{
		int length = dblVertices.GetLength(0);
		double[,] array = new double[length, 3];
		if (transf != null && !transf.IsIdentity(0.0))
		{
			for (int i = 0; i < length; i++)
			{
				Point3D point3D = new Point3D(dblVertices[i, 0], dblVertices[i, 1], dblVertices[i, 2]);
				point3D = transf * point3D;
				ComputeScreenCoords(renderContext, modelViewProj, viewFrame, point3D.X, point3D.Y, point3D.Z, out array[i, 0], out array[i, 1], out array[i, 2]);
			}
		}
		else
		{
			for (int j = 0; j < length; j++)
			{
				ComputeScreenCoords(renderContext, modelViewProj, viewFrame, dblVertices[j, 0], dblVertices[j, 1], dblVertices[j, 2], out array[j, 0], out array[j, 1], out array[j, 2]);
			}
		}
		return array;
	}

	protected static double[,] ComputeScreenVertices(float[,] vertices, RenderContextBase renderContext, Transformation transf, double[] modelViewProj, int[] viewFrame)
	{
		int length = vertices.GetLength(0);
		double[,] array = new double[length, 3];
		if (transf != null && !transf.IsIdentity())
		{
			for (int i = 0; i < length; i++)
			{
				Point3D point3D = new Point3D(vertices[i, 0], vertices[i, 1], vertices[i, 2]);
				point3D = transf * point3D;
				ComputeScreenCoords(renderContext, modelViewProj, viewFrame, point3D.X, point3D.Y, point3D.Z, out array[i, 0], out array[i, 1], out array[i, 2]);
			}
		}
		else
		{
			for (int j = 0; j < length; j++)
			{
				ComputeScreenCoords(renderContext, modelViewProj, viewFrame, vertices[j, 0], vertices[j, 1], vertices[j, 2], out array[j, 0], out array[j, 1], out array[j, 2]);
			}
		}
		return array;
	}

	public static void ComputeScreenCoords(RenderContextBase renderContext, double[] modelViewProj, int[] viewFrame, double px, double py, double pz, out double x, out double y, out double z)
	{
		Camera.Project(renderContext, modelViewProj, viewFrame, px, py, pz, out x, out y, out z);
	}
}
