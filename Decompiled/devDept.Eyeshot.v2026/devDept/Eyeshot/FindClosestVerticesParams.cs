using System;
using System.Collections.Generic;
using System.Drawing;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot;

internal class FindClosestVerticesParams : FindClosestVertexParamsBase
{
	public List<HitVertex> ClosestVertices;

	public FindClosestVerticesParams(Transformation transform, IWorkspace workspace, Type entType, System.Drawing.Point mousePos, double sqrDistance, int clientWidth, int clientHeight, Camera camera, int[] viewFrame)
		: base(transform, workspace, entType, mousePos, sqrDistance, clientWidth, clientHeight, camera, viewFrame)
	{
		ClosestVertices = new List<HitVertex>();
	}
}
