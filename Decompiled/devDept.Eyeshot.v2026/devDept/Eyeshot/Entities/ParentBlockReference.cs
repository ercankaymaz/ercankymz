using System;
using System.Runtime.Serialization;
using devDept.Geometry;

namespace devDept.Eyeshot.Entities;

[Serializable]
internal class ParentBlockReference : BlockReference
{
	public ParentBlockReference(double x, double y, double z, string blockName, double rotationAngleInRadians)
		: base(x, y, z, blockName, rotationAngleInRadians)
	{
	}

	public ParentBlockReference(Transformation t, string blockName)
		: base(t, blockName)
	{
	}

	protected ParentBlockReference(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	protected internal override void Draw(DrawEntitiesParams myParams, WorkspaceDrawCallback drawCall)
	{
		bool accurateTransparency = myParams.Workspace.AccurateTransparency;
		myParams.Workspace.AccurateTransparency = false;
		bool parentForceGray = myParams.DrawParams.ParentForceGray;
		myParams.DrawParams.ParentForceGray = true;
		if (myParams.DrawParams.Parents.Count == 0)
		{
			myParams.DrawParams.RenderContext.DisableClipPlanes();
		}
		base.Draw(myParams, drawCall);
		if (myParams.DrawParams.Parents.Count == 0)
		{
			myParams.DrawParams.RenderContext.ProcessClippingPlanesVisibility(myParams._0023_003DzHwUoFCUb88ry().clippingPlanes, updateGraphics: true);
		}
		myParams.DrawParams.ParentForceGray = parentForceGray;
		myParams.Workspace.AccurateTransparency = accurateTransparency;
	}

	protected internal override bool IsCrossing(FrustumParams data)
	{
		return false;
	}

	protected internal override bool IsCrossingScreenPolygon(ScreenPolygonParams data)
	{
		return false;
	}

	protected internal override bool AllVerticesInFrustum(FrustumParams data)
	{
		return false;
	}

	protected internal override bool AllVerticesInScreenPolygon(ScreenPolygonParams data)
	{
		return false;
	}

	protected internal override bool InsideOrCrossingScreenPolygon(ScreenPolygonParams data)
	{
		return false;
	}

	internal override bool IntersectEdgeOrIsoline(FrustumParams data)
	{
		return false;
	}

	internal override bool IntersectEdgeOrIsolineScreenPolygon(ScreenPolygonParams data)
	{
		return false;
	}
}
