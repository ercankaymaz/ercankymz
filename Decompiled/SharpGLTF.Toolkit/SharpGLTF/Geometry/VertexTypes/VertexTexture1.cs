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
public struct VertexTexture1 : IVertexMaterial, IVertexReflection, IEquatable<VertexTexture1>
{
	public Vector2 TexCoord;

	public readonly int MaxColors => 0;

	public readonly int MaxTextCoords => 1;

	public static implicit operator VertexTexture1(Vector2 uv)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return new VertexTexture1(uv);
	}

	private readonly string _GetDebuggerDisplay()
	{
		return VertexUtils._GetDebuggerDisplay(this);
	}

	public VertexTexture1(Vector2 texcoord)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		TexCoord = texcoord;
	}

	public VertexTexture1(IVertexMaterial src)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		SharpGLTF.Guard.NotNull(src, "src");
		TexCoord = ((0 < src.MaxTextCoords) ? src.GetTexCoord(0) : Vector2.Zero);
	}

	IEnumerable<KeyValuePair<string, AttributeFormat>> IVertexReflection.GetEncodingAttributes()
	{
		yield return new KeyValuePair<string, AttributeFormat>("TEXCOORD_0", new AttributeFormat(DimensionType.VEC2));
	}

	public override readonly int GetHashCode()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		return ((object)TexCoord/*cast due to constrained. prefix*/).GetHashCode();
	}

	public override readonly bool Equals(object obj)
	{
		if (!(obj is VertexTexture1 other))
		{
			return false;
		}
		return Equals(other);
	}

	public readonly bool Equals(VertexTexture1 other)
	{
		return AreEqual(this, in other);
	}

	public static bool operator ==(in VertexTexture1 a, in VertexTexture1 b)
	{
		return AreEqual(in a, in b);
	}

	public static bool operator !=(in VertexTexture1 a, in VertexTexture1 b)
	{
		return !AreEqual(in a, in b);
	}

	public static bool AreEqual(in VertexTexture1 a, in VertexTexture1 b)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		if (a.TexCoord != b.TexCoord)
		{
			return false;
		}
		return true;
	}

	public readonly VertexMaterialDelta Subtract(IVertexMaterial baseValue)
	{
		return new VertexMaterialDelta((VertexTexture1)(object)baseValue, this);
	}

	public void Add(in VertexMaterialDelta delta)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		TexCoord += delta.TexCoord0Delta;
	}

	void IVertexMaterial.SetColor(int index, Vector4 color)
	{
	}

	void IVertexMaterial.SetTexCoord(int index, Vector2 coord)
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		if (index == 0)
		{
			TexCoord = coord;
		}
	}

	public readonly Vector4 GetColor(int index)
	{
		throw new ArgumentOutOfRangeException("index");
	}

	public readonly Vector2 GetTexCoord(int index)
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		if (index == 0)
		{
			return TexCoord;
		}
		throw new ArgumentOutOfRangeException("index");
	}

	void IVertexMaterial.Add(in VertexMaterialDelta delta)
	{
		Add(in delta);
	}
}
