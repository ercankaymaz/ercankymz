using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Milling;

[Serializable]
public class MachiningBoundary : Region
{
	public MachiningBoundary(params ICurve[] contours)
		: base(contours, Plane.XY, sortAndOrient: true)
	{
	}

	public MachiningBoundary(IList<ICurve> contours, Plane pln)
		: base(contours, pln, sortAndOrient: true)
	{
	}

	public MachiningBoundary(ICurve contour, Plane pln)
		: base(contour, pln, true)
	{
	}

	protected MachiningBoundary(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	protected internal override void DrawEdges(DrawParams data)
	{
		if (!data.Selected && data.Viewport.DisplayMode != displayType.HiddenLines)
		{
			data.RenderContext.SetColorWireframe(Color);
		}
		data.RenderContext.SetLineSize(4f);
		base.DrawEdges(data);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
	}
}
