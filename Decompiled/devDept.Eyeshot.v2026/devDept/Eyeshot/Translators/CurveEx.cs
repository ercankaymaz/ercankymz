using System;
using System.Runtime.Serialization;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Translators;

[Serializable]
public class CurveEx : Curve
{
	public CurveEx(int degree, double[] knotVector, Point4D[] ctrlPoints)
		: base(degree, knotVector, ctrlPoints)
	{
	}

	public CurveEx(SerializationInfo info, StreamingContext ctxt)
		: base(info, ctxt)
	{
	}

	public CurveEx(Curve another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
	}

	protected internal CurveEx(CurveExSurrogate surrogate)
		: base(surrogate)
	{
	}

	public override object Clone()
	{
		return new CurveEx(this);
	}

	public override object CloneWithTessellation()
	{
		return new CurveEx(this, RegenMode != regenType.RegenAndCompile);
	}

	protected override void CompilePattern(CompileParams data)
	{
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

	public override void SetLineWeight(RenderContextBase renderContext, float lineWeight)
	{
		renderContext.SetLineSize(1f, setShader: false);
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new CurveExSurrogate(this);
	}
}
