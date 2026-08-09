using System;
using System.Drawing;
using devDept.Geometry;

namespace devDept.Eyeshot;

internal class FindClosestVertexParamsBase : TraversalParams
{
	public Type entType;

	public Point mousePos;

	public double sqrDistance;

	public int clientWidth;

	public int clientHeight;

	public Camera camera;

	public int[] viewFrame;

	public FindClosestVertexParamsBase(Transformation transform, IWorkspace workspace, Type entType, Point mousePos, double sqrDistance, int clientWidth, int clientHeight, Camera camera, int[] viewFrame)
		: base(workspace, transform)
	{
		this.entType = entType;
		this.mousePos = mousePos;
		this.sqrDistance = sqrDistance;
		this.clientWidth = clientWidth;
		this.clientHeight = clientHeight;
		this.camera = camera;
		this.viewFrame = viewFrame;
	}
}
