using System;
using System.Drawing;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot;

internal class FindClosestVertexParams : FindClosestVertexParamsBase
{
	public double minSqrDist;

	public HitVertex ClosestVertex;

	public FindClosestVertexParams(Transformation transform, IWorkspace workspace, Type entType, System.Drawing.Point mousePos, double sqrDistance, int clientWidth, int clientHeight, Camera camera, int[] viewFrame)
		: base(transform, workspace, entType, mousePos, sqrDistance, clientWidth, clientHeight, camera, viewFrame)
	{
		ClosestVertex = new HitVertex();
		minSqrDist = double.MaxValue;
	}
}
