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
public struct VertexTexture3 : IVertexMaterial, IVertexReflection, IEquatable<VertexTexture3>
{
	public Vector2 TexCoord0;

	public Vector2 TexCoord1;

	public Vector2 TexCoord2;

	public readonly int MaxColors => 0;

	public readonly int MaxTextCoords => 3;

	private readonly string _GetDebuggerDisplay()
	{
		return VertexUtils._GetDebuggerDisplay(this);
	}

	public VertexTexture3(Vector2 texcoord0, Vector2 texcoord1, Vector2 texcoord2)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		TexCoord0 = texcoord0;
		TexCoord1 = texcoord1;
		TexCoord2 = texcoord2;
	}

	public VertexTexture3(IVertexMaterial src)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		SharpGLTF.Guard.NotNull(src, "src");
		TexCoord0 = ((0 < src.MaxTextCoords) ? src.GetTexCoord(0) : Vector2.Zero);
		TexCoord1 = ((1 < src.MaxTextCoords) ? src.GetTexCoord(1) : Vector2.Zero);
		TexCoord2 = ((2 < src.MaxTextCoords) ? src.GetTexCoord(2) : Vector2.Zero);
	}

	IEnumerable<KeyValuePair<string, AttributeFormat>> IVertexReflection.GetEncodingAttributes()
	{
		yield return new KeyValuePair<string, AttributeFormat>("TEXCOORD_0", new AttributeFormat(DimensionType.VEC2));
		yield return new KeyValuePair<string, AttributeFormat>("TEXCOORD_1", new AttributeFormat(DimensionType.VEC2));
		yield return new KeyValuePair<string, AttributeFormat>("TEXCOORD_2", new AttributeFormat(DimensionType.VEC2));
	}

	public override readonly int GetHashCode()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		return ((object)TexCoord0/*cast due to constrained. prefix*/).GetHashCode() + ((object)TexCoord1/*cast due to constrained. prefix*/).GetHashCode() + ((object)TexCoord2/*cast due to constrained. prefix*/).GetHashCode();
	}

	public override readonly bool Equals(object obj)
	{
		if (!(obj is VertexTexture3 other))
		{
			return false;
		}
		return Equals(other);
	}

	public readonly bool Equals(VertexTexture3 other)
	{
		return AreEqual(this, in other);
	}

	public static bool operator ==(in VertexTexture3 a, in VertexTexture3 b)
	{
		return AreEqual(in a, in b);
	}

	public static bool operator !=(in VertexTexture3 a, in VertexTexture3 b)
	{
		return !AreEqual(in a, in b);
	}

	public static bool AreEqual(in VertexTexture3 a, in VertexTexture3 b)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		if (a.TexCoord0 != b.TexCoord0)
		{
			return false;
		}
		if (a.TexCoord1 != b.TexCoord1)
		{
			return false;
		}
		if (a.TexCoord2 != b.TexCoord2)
		{
			return false;
		}
		return true;
	}

	public readonly VertexMaterialDelta Subtract(IVertexMaterial baseValue)
	{
		return new VertexMaterialDelta((VertexTexture3)(object)baseValue, this);
	}

	public void Add(in VertexMaterialDelta delta)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		TexCoord0 += delta.TexCoord0Delta;
		TexCoord1 += delta.TexCoord1Delta;
		TexCoord2 += delta.TexCoord2Delta;
	}

	void IVertexMaterial.SetColor(int index, Vector4 color)
	{
	}

	void IVertexMaterial.SetTexCoord(int index, Vector2 coord)
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		if (index == 0)
		{
			TexCoord0 = coord;
		}
		if (index == 1)
		{
			TexCoord1 = coord;
		}
		if (index == 2)
		{
			TexCoord2 = coord;
		}
	}

	public readonly Vector4 GetColor(int index)
	{
		throw new ArgumentOutOfRangeException("index");
	}

	public readonly Vector2 GetTexCoord(int index)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		return (Vector2)(index switch
		{
			0 => TexCoord0, 
			1 => TexCoord1, 
			2 => TexCoord2, 
			_ => throw new ArgumentOutOfRangeException("index"), 
		});
	}

	void IVertexMaterial.Add(in VertexMaterialDelta delta)
	{
		Add(in delta);
	}
}
