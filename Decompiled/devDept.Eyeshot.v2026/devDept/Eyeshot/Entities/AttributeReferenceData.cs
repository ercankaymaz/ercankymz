using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Entities;

[Serializable]
internal class AttributeReferenceData : AttributeBase
{
	public AttributeReferenceData(double x, double y, double z, string text, double height)
		: base(x, y, z, text, height)
	{
	}

	public AttributeReferenceData(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	public AttributeReferenceData(Point3D insPoint, string text, double height)
		: base(insPoint, text, height)
	{
	}

	public AttributeReferenceData(Plane pln, Point3D insPoint, string text, double height)
		: base(pln, insPoint, text, height)
	{
	}

	public AttributeReferenceData(AttributeBase another)
		: base(another)
	{
	}

	protected internal AttributeReferenceData(AttributeReferenceDataSurrogate surrogate)
		: this(surrogate.Plane, surrogate.Plane.Origin, surrogate.TextString, surrogate.Height)
	{
	}

	protected override void DrawEntity(RenderContextBase context, object myParams)
	{
		if (!context.IsDirect3D || !base.Compiling)
		{
			base.DrawEntity(context, myParams);
		}
	}

	protected internal override void Draw(DrawParams data)
	{
		if (RegenMode == regenType.RegenAndCompile)
		{
			Regen(new RegenParams(1.0, data.viewportInternal.parent));
			Compile(new CompileParams(data.viewportInternal.parent));
			RegenMode = regenType.NotNeeded;
		}
		else if (RegenMode == regenType.CompileOnly)
		{
			Compile(new CompileParams(data.viewportInternal.parent));
			RegenMode = regenType.NotNeeded;
		}
		base.Draw(data);
	}

	protected internal override bool IsVisibleAndInFrustum(Stack<BlockReference> parents, LayerKeyedCollection layers, attributeReferenceVisibilityType attributeReferenceMode)
	{
		switch (attributeReferenceMode)
		{
		case attributeReferenceVisibilityType.Off:
			return false;
		case attributeReferenceVisibilityType.Normal:
			if (base.IsVisibleAndInFrustum(parents, layers, attributeReferenceMode))
			{
				return base.NormalMode;
			}
			return false;
		case attributeReferenceVisibilityType.On:
			return IsValidForDraw();
		default:
			return true;
		}
	}

	protected internal override bool IsVisible(Stack<BlockReference> parents, LayerKeyedCollection layers, attributeReferenceVisibilityType attributeReferenceMode)
	{
		switch (attributeReferenceMode)
		{
		case attributeReferenceVisibilityType.Off:
			return false;
		case attributeReferenceVisibilityType.Normal:
			if (base.IsVisible(parents, layers, attributeReferenceMode))
			{
				return base.NormalMode;
			}
			return false;
		case attributeReferenceVisibilityType.On:
			return RegenMode != regenType.RegenAndCompile;
		default:
			return true;
		}
	}

	public override object Clone()
	{
		return new AttributeReferenceData(this);
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new AttributeReferenceDataSurrogate(this);
	}
}
