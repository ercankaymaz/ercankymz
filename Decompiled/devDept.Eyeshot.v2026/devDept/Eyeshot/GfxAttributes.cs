using System;
using System.Drawing;
using devDept.Eyeshot.Entities;

namespace devDept.Eyeshot;

public class GfxAttributes : ICloneable
{
	public float LineWeight = 1f;

	public string MaterialName;

	protected internal Color Color;

	public string LineTypeName = string.Empty;

	protected GfxAttributes(GfxAttributes other)
	{
		Init(other);
	}

	public GfxAttributes()
		: this(Color.Black)
	{
	}

	public GfxAttributes(Color color)
	{
		Color = color;
	}

	protected internal void Init(GfxAttributes other)
	{
		Assign(other);
	}

	protected internal virtual void Init(Color defaultColor, LayerKeyedCollection layers)
	{
		Color = defaultColor;
	}

	internal virtual void PropagateLayer0(Entity _0023_003Dzs_0024uS8LA_003D, Layer _0023_003DztIaJjPw_003D)
	{
	}

	internal virtual void Propagate(Entity _0023_003Dzs_0024uS8LA_003D, Layer _0023_003DztIaJjPw_003D, MaterialKeyedCollection _0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D)
	{
	}

	public virtual object Clone()
	{
		return new GfxAttributes(this);
	}

	public virtual void Assign(GfxAttributes other)
	{
		Color = other.Color;
		LineWeight = other.LineWeight;
		LineTypeName = other.LineTypeName;
		MaterialName = other.MaterialName;
	}

	public virtual void AssignColor(Color color)
	{
	}

	public virtual Color GetColor()
	{
		return Color;
	}

	public bool IsColorTransparent(bool forceGray, IWorkspace ws, Entity ent, bool forBlending = false)
	{
		return GetColor(forceGray, ws, ent, forBlending).A != byte.MaxValue;
	}

	public virtual Color GetColor(bool forceGray, IWorkspace ws, Entity ent, bool edge = false, bool forBlending = false)
	{
		if (!forceGray)
		{
			return Color;
		}
		return ((IWorkspaceInternal)ws).ComputeNonCurrentEntityColor(ent, Color, edge, forBlending);
	}
}
