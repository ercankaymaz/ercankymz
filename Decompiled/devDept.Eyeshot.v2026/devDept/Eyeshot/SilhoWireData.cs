using System.Collections.Generic;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;

namespace devDept.Eyeshot;

internal class SilhoWireData : GfxSilhoData
{
	public silhoDataType DataMode;

	internal Transformation Transformation;

	public int startPointVertices = -1;

	public double[,] ScreenVertices;

	public Point2D screenBoxMin;

	public Point2D screenBoxMax;

	public GfxAttributesWire Attributes { get; set; }

	public SilhoWireData()
	{
	}

	public SilhoWireData(Entity entity, Stack<BlockReference> parents)
	{
		Entity = entity;
		if (parents != null)
		{
			Parents = Utility.CloneStack(parents);
		}
	}

	public SilhoWireData(SilhoWireData copy)
	{
		if (copy == null)
		{
			Transformation = null;
			return;
		}
		Entity = copy.Entity;
		Parents = copy.Parents;
		Attributes = copy.Attributes;
		Vertices = copy.Vertices;
		Transformation = copy.Transformation;
		DataMode = copy.DataMode;
		startPointVertices = copy.startPointVertices;
	}

	public virtual void ComputeScreenVertices(RenderContextBase renderContext, double[] modelViewProj, int[] viewFrame)
	{
		ScreenVertices = GfxSilhoData.ComputeScreenVertices(Vertices, renderContext, Transformation, modelViewProj, viewFrame);
		Utility.ComputeBoundingRect(ScreenVertices, out screenBoxMin, out screenBoxMax);
	}
}
