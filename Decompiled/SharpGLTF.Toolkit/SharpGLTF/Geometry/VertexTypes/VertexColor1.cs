using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using SharpGLTF.Memory;
using SharpGLTF.Schema2;

namespace SharpGLTF.Geometry.VertexTypes;

[GeneratedCode("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
[DebuggerDisplay("{_GetDebuggerDisplay(),nq}")]
public struct VertexColor1 : IVertexMaterial, IVertexReflection, IEquatable<VertexColor1>
{
	public Vector4 Color;

	public readonly int MaxColors => 1;

	public readonly int MaxTextCoords => 0;

	public static implicit operator VertexColor1(Vector4 color)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return new VertexColor1(color);
	}

	private readonly string _GetDebuggerDisplay()
	{
		return VertexUtils._GetDebuggerDisplay(this);
	}

	public VertexColor1(Vector4 color)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		Color = color;
	}

	public VertexColor1(IVertexMaterial src)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		SharpGLTF.Guard.NotNull(src, "src");
		Color = ((0 < src.MaxColors) ? src.GetColor(0) : Vector4.One);
	}

	IEnumerable<KeyValuePair<string, AttributeFormat>> IVertexReflection.GetEncodingAttributes()
	{
		yield return new KeyValuePair<string, AttributeFormat>("COLOR_0", new AttributeFormat(DimensionType.VEC4, EncodingType.UNSIGNED_BYTE, nrm: true));
	}

	public override readonly int GetHashCode()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		return ((object)Color/*cast due to constrained. prefix*/).GetHashCode();
	}

	public override readonly bool Equals(object obj)
	{
		if (!(obj is VertexColor1 other))
		{
			return false;
		}
		return Equals(other);
	}

	public readonly bool Equals(VertexColor1 other)
	{
		return AreEqual(this, in other);
	}

	public static bool operator ==(in VertexColor1 a, in VertexColor1 b)
	{
		return AreEqual(in a, in b);
	}

	public static bool operator !=(in VertexColor1 a, in VertexColor1 b)
	{
		return !AreEqual(in a, in b);
	}

	public static bool AreEqual(in VertexColor1 a, in VertexColor1 b)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		if (a.Color != b.Color)
		{
			return false;
		}
		return true;
	}

	public readonly VertexMaterialDelta Subtract(IVertexMaterial baseValue)
	{
		return new VertexMaterialDelta((VertexColor1)(object)baseValue, this);
	}

	public void Add(in VertexMaterialDelta delta)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		Color += delta.Color0Delta;
	}

	void IVertexMaterial.SetColor(int index, Vector4 color)
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		if (index == 0)
		{
			Color = color;
		}
	}

	void IVertexMaterial.SetTexCoord(int index, Vector2 coord)
	{
	}

	public readonly Vector4 GetColor(int index)
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		if (index == 0)
		{
			return Color;
		}
		throw new ArgumentOutOfRangeException("index");
	}

	public readonly Vector2 GetTexCoord(int index)
	{
		throw new ArgumentOutOfRangeException("index");
	}

	void IVertexMaterial.Add(in VertexMaterialDelta delta)
	{
		Add(in delta);
	}
}
