using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Translators;

[Serializable]
public class LinearPathEx : LinearPath
{
	public LinearPathEx(LinearPath another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
	}

	public LinearPathEx(IList<Point3D> points)
		: base(points)
	{
	}

	public LinearPathEx(SerializationInfo info, StreamingContext ctxt)
		: base(info, ctxt)
	{
	}

	protected internal LinearPathEx(LinearPathExSurrogate surrogate)
		: base(surrogate)
	{
	}

	public override object Clone()
	{
		return new LinearPathEx(this);
	}

	public override object CloneWithTessellation()
	{
		return new LinearPathEx(this, RegenMode != regenType.RegenAndCompile);
	}

	protected override void CompilePattern(CompileParams data)
	{
	}

	protected internal override void Draw(DrawParams data)
	{
		DrawWire(data);
	}

	protected override void DrawWire(DrawParams data)
	{
		if (data.CompileWires)
		{
			data.RenderContext.Draw(drawData);
			return;
		}
		for (int i = 0; i < Vertices.Length - 1; i++)
		{
			data.RenderContext.DrawBufferedLine(Vertices[i], Vertices[i + 1]);
		}
	}

	protected override void DrawWireEntity(RenderContextBase context, object myParams)
	{
		context.DrawLineStrip(Vertices);
	}

	public override void SetLineWeight(RenderContextBase renderContext, float lineWeight)
	{
		renderContext.SetLineSize(1f, setShader: false);
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new LinearPathExSurrogate(this);
	}
}
