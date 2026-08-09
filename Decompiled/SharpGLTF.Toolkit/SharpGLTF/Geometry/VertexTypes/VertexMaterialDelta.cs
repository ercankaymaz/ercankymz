using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using SharpGLTF.Memory;
using SharpGLTF.Schema2;

namespace SharpGLTF.Geometry.VertexTypes;

[DebuggerDisplay("{_GetDebuggerDisplay(),nq}")]
public struct VertexMaterialDelta : IVertexMaterial, IVertexReflection, IEquatable<VertexMaterialDelta>
{
	public Vector4 Color0Delta;

	public Vector4 Color1Delta;

	public Vector2 TexCoord0Delta;

	public Vector2 TexCoord1Delta;

	public Vector2 TexCoord2Delta;

	public Vector2 TexCoord3Delta;

	public static VertexMaterialDelta Zero => new VertexMaterialDelta(Vector4.Zero, Vector4.Zero, Vector2.Zero, Vector2.Zero, Vector2.Zero, Vector2.Zero);

	public int MaxColors { get; }

	public int MaxTextCoords { get; }

	private readonly string _GetDebuggerDisplay()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		return $"ΔC₀:{Color0Delta} ΔC₁:{Color1Delta} ΔUV₀:{TexCoord0Delta}  ΔUV₁:{TexCoord1Delta}";
	}

	public static implicit operator VertexMaterialDelta(in (Vector4 Color0Delta, Vector4 Color1Delta, Vector2 TextCoord0Delta, Vector2 TextCoord1Delta) tuple)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		return new VertexMaterialDelta(in tuple.Color0Delta, in tuple.Color1Delta, in tuple.TextCoord0Delta, in tuple.TextCoord1Delta, Vector2.Zero, Vector2.Zero);
	}

	public static implicit operator VertexMaterialDelta(in (Vector4 Color0Delta, Vector4 Color1Delta, Vector2 TextCoord0Delta, Vector2 TextCoord1Delta, Vector2 TextCoord2Delta, Vector2 TextCoord3Delta) tuple)
	{
		return new VertexMaterialDelta(in tuple.Color0Delta, in tuple.Color1Delta, in tuple.TextCoord0Delta, in tuple.TextCoord1Delta, in tuple.TextCoord2Delta, in tuple.TextCoord3Delta);
	}

	public VertexMaterialDelta(IVertexMaterial src)
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		SharpGLTF.Guard.NotNull(src, "src");
		MaxColors = Math.Min(2, src.MaxColors);
		MaxTextCoords = Math.Min(4, src.MaxTextCoords);
		Color0Delta = ((src.MaxColors < 1) ? Vector4.Zero : src.GetColor(0));
		Color1Delta = ((src.MaxColors < 2) ? Vector4.Zero : src.GetColor(1));
		TexCoord0Delta = ((src.MaxTextCoords < 1) ? Vector2.Zero : src.GetTexCoord(0));
		TexCoord1Delta = ((src.MaxTextCoords < 2) ? Vector2.Zero : src.GetTexCoord(1));
		TexCoord2Delta = ((src.MaxTextCoords < 3) ? Vector2.Zero : src.GetTexCoord(2));
		TexCoord3Delta = ((src.MaxTextCoords < 4) ? Vector2.Zero : src.GetTexCoord(3));
	}

	public VertexMaterialDelta(in Vector4 color0Delta, in Vector4 color1Delta, in Vector2 texCoord0Delta, in Vector2 texCoord1Delta)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		MaxColors = 2;
		MaxTextCoords = 4;
		Color0Delta = color0Delta;
		Color1Delta = color1Delta;
		TexCoord0Delta = texCoord0Delta;
		TexCoord1Delta = texCoord1Delta;
		TexCoord2Delta = Vector2.Zero;
		TexCoord3Delta = Vector2.Zero;
	}

	public VertexMaterialDelta(in Vector4 color0Delta, in Vector4 color1Delta, in Vector2 texCoord0Delta, in Vector2 texCoord1Delta, in Vector2 texCoord2Delta, in Vector2 texCoord3Delta)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		MaxColors = 2;
		MaxTextCoords = 4;
		Color0Delta = color0Delta;
		Color1Delta = color1Delta;
		TexCoord0Delta = texCoord0Delta;
		TexCoord1Delta = texCoord1Delta;
		TexCoord2Delta = texCoord2Delta;
		TexCoord3Delta = texCoord3Delta;
	}

	internal VertexMaterialDelta(in VertexMaterialDelta rootVal, in VertexMaterialDelta morphVal)
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		if (rootVal.MaxColors != morphVal.MaxColors)
		{
			throw new ArgumentException("MaxColors do not match!");
		}
		if (rootVal.MaxTextCoords != morphVal.MaxTextCoords)
		{
			throw new ArgumentException("MaxTextCoords do not match!");
		}
		MaxColors = rootVal.MaxColors;
		MaxTextCoords = rootVal.MaxTextCoords;
		Color0Delta = morphVal.Color0Delta - rootVal.Color0Delta;
		Color1Delta = morphVal.Color1Delta - rootVal.Color1Delta;
		TexCoord0Delta = morphVal.TexCoord0Delta - rootVal.TexCoord0Delta;
		TexCoord1Delta = morphVal.TexCoord1Delta - rootVal.TexCoord1Delta;
		TexCoord2Delta = morphVal.TexCoord2Delta - rootVal.TexCoord2Delta;
		TexCoord3Delta = morphVal.TexCoord3Delta - rootVal.TexCoord3Delta;
	}

	IEnumerable<KeyValuePair<string, AttributeFormat>> IVertexReflection.GetEncodingAttributes()
	{
		yield return new KeyValuePair<string, AttributeFormat>("COLOR_0DELTA", new AttributeFormat(DimensionType.VEC4, EncodingType.UNSIGNED_BYTE, nrm: true));
		yield return new KeyValuePair<string, AttributeFormat>("COLOR_1DELTA", new AttributeFormat(DimensionType.VEC4, EncodingType.UNSIGNED_BYTE, nrm: true));
		yield return new KeyValuePair<string, AttributeFormat>("TEXCOORD_0DELTA", new AttributeFormat(DimensionType.VEC2));
		yield return new KeyValuePair<string, AttributeFormat>("TEXCOORD_1DELTA", new AttributeFormat(DimensionType.VEC2));
		yield return new KeyValuePair<string, AttributeFormat>("TEXCOORD_2DELTA", new AttributeFormat(DimensionType.VEC2));
		yield return new KeyValuePair<string, AttributeFormat>("TEXCOORD_3DELTA", new AttributeFormat(DimensionType.VEC2));
	}

	public override readonly int GetHashCode()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		return ((object)Color0Delta/*cast due to constrained. prefix*/).GetHashCode() ^ ((object)Color1Delta/*cast due to constrained. prefix*/).GetHashCode() ^ ((object)TexCoord0Delta/*cast due to constrained. prefix*/).GetHashCode() ^ ((object)TexCoord1Delta/*cast due to constrained. prefix*/).GetHashCode() ^ ((object)TexCoord2Delta/*cast due to constrained. prefix*/).GetHashCode() ^ ((object)TexCoord3Delta/*cast due to constrained. prefix*/).GetHashCode();
	}

	public override readonly bool Equals(object obj)
	{
		if (obj is VertexMaterialDelta b)
		{
			return AreEqual(this, in b);
		}
		return false;
	}

	public readonly bool Equals(VertexMaterialDelta other)
	{
		return AreEqual(this, in other);
	}

	public static bool operator ==(in VertexMaterialDelta a, in VertexMaterialDelta b)
	{
		return AreEqual(in a, in b);
	}

	public static bool operator !=(in VertexMaterialDelta a, in VertexMaterialDelta b)
	{
		return !AreEqual(in a, in b);
	}

	public static bool AreEqual(in VertexMaterialDelta a, in VertexMaterialDelta b)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		if (a.Color0Delta == b.Color0Delta && a.Color1Delta == b.Color1Delta && a.TexCoord0Delta == b.TexCoord0Delta && a.TexCoord1Delta == b.TexCoord1Delta && a.TexCoord2Delta == b.TexCoord2Delta)
		{
			return a.TexCoord3Delta == b.TexCoord3Delta;
		}
		return false;
	}

	public readonly VertexMaterialDelta Subtract(IVertexMaterial baseValue)
	{
		return new VertexMaterialDelta((VertexMaterialDelta)(object)baseValue, this);
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
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		Color0Delta += delta.Color0Delta;
		Color1Delta += delta.Color1Delta;
		TexCoord0Delta += delta.TexCoord0Delta;
		TexCoord1Delta += delta.TexCoord1Delta;
		TexCoord2Delta += delta.TexCoord2Delta;
		TexCoord3Delta += delta.TexCoord3Delta;
	}

	void IVertexMaterial.SetColor(int setIndex, Vector4 color)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		SetColor(setIndex, color);
	}

	private void SetColor(int setIndex, Vector4 color)
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		if (setIndex == 0)
		{
			Color0Delta = color;
		}
		if (setIndex == 1)
		{
			Color1Delta = color;
		}
	}

	void IVertexMaterial.SetTexCoord(int setIndex, Vector2 coord)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		SetTexCoord(setIndex, coord);
	}

	private void SetTexCoord(int setIndex, Vector2 coord)
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		if (setIndex == 0)
		{
			TexCoord0Delta = coord;
		}
		if (setIndex == 1)
		{
			TexCoord1Delta = coord;
		}
		if (setIndex == 2)
		{
			TexCoord2Delta = coord;
		}
		if (setIndex == 3)
		{
			TexCoord3Delta = coord;
		}
	}

	public readonly Vector4 GetColor(int index)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		return (Vector4)(index switch
		{
			0 => Color0Delta, 
			1 => Color1Delta, 
			_ => throw new ArgumentOutOfRangeException("index"), 
		});
	}

	public readonly Vector2 GetTexCoord(int index)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		return (Vector2)(index switch
		{
			0 => TexCoord0Delta, 
			1 => TexCoord1Delta, 
			2 => TexCoord2Delta, 
			3 => TexCoord3Delta, 
			_ => throw new ArgumentOutOfRangeException("index"), 
		});
	}

	internal VertexMaterialDelta(in VertexTexture1 rootVal, in VertexTexture1 morphVal)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		MaxColors = 0;
		MaxTextCoords = 1;
		Color0Delta = Vector4.Zero;
		Color1Delta = Vector4.Zero;
		TexCoord0Delta = morphVal.TexCoord - rootVal.TexCoord;
		TexCoord1Delta = Vector2.Zero;
		TexCoord2Delta = Vector2.Zero;
		TexCoord3Delta = Vector2.Zero;
	}

	internal VertexMaterialDelta(in VertexTexture2 rootVal, in VertexTexture2 morphVal)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		MaxColors = 0;
		MaxTextCoords = 2;
		Color0Delta = Vector4.Zero;
		Color1Delta = Vector4.Zero;
		TexCoord0Delta = morphVal.TexCoord0 - rootVal.TexCoord0;
		TexCoord1Delta = morphVal.TexCoord1 - rootVal.TexCoord1;
		TexCoord2Delta = Vector2.Zero;
		TexCoord3Delta = Vector2.Zero;
	}

	internal VertexMaterialDelta(in VertexTexture3 rootVal, in VertexTexture3 morphVal)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		MaxColors = 0;
		MaxTextCoords = 3;
		Color0Delta = Vector4.Zero;
		Color1Delta = Vector4.Zero;
		TexCoord0Delta = morphVal.TexCoord0 - rootVal.TexCoord0;
		TexCoord1Delta = morphVal.TexCoord1 - rootVal.TexCoord1;
		TexCoord2Delta = morphVal.TexCoord2 - rootVal.TexCoord2;
		TexCoord3Delta = Vector2.Zero;
	}

	internal VertexMaterialDelta(in VertexTexture4 rootVal, in VertexTexture4 morphVal)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		MaxColors = 0;
		MaxTextCoords = 4;
		Color0Delta = Vector4.Zero;
		Color1Delta = Vector4.Zero;
		TexCoord0Delta = morphVal.TexCoord0 - rootVal.TexCoord0;
		TexCoord1Delta = morphVal.TexCoord1 - rootVal.TexCoord1;
		TexCoord2Delta = morphVal.TexCoord2 - rootVal.TexCoord2;
		TexCoord3Delta = morphVal.TexCoord3 - rootVal.TexCoord3;
	}

	internal VertexMaterialDelta(in VertexColor1 rootVal, in VertexColor1 morphVal)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		MaxColors = 1;
		MaxTextCoords = 0;
		Color0Delta = morphVal.Color - rootVal.Color;
		Color1Delta = Vector4.Zero;
		TexCoord0Delta = Vector2.Zero;
		TexCoord1Delta = Vector2.Zero;
		TexCoord2Delta = Vector2.Zero;
		TexCoord3Delta = Vector2.Zero;
	}

	internal VertexMaterialDelta(in VertexColor1Texture1 rootVal, in VertexColor1Texture1 morphVal)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		MaxColors = 1;
		MaxTextCoords = 1;
		Color0Delta = morphVal.Color - rootVal.Color;
		Color1Delta = Vector4.Zero;
		TexCoord0Delta = morphVal.TexCoord - rootVal.TexCoord;
		TexCoord1Delta = Vector2.Zero;
		TexCoord2Delta = Vector2.Zero;
		TexCoord3Delta = Vector2.Zero;
	}

	internal VertexMaterialDelta(in VertexColor1Texture2 rootVal, in VertexColor1Texture2 morphVal)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		MaxColors = 1;
		MaxTextCoords = 2;
		Color0Delta = morphVal.Color - rootVal.Color;
		Color1Delta = Vector4.Zero;
		TexCoord0Delta = morphVal.TexCoord0 - rootVal.TexCoord0;
		TexCoord1Delta = morphVal.TexCoord1 - rootVal.TexCoord1;
		TexCoord2Delta = Vector2.Zero;
		TexCoord3Delta = Vector2.Zero;
	}

	internal VertexMaterialDelta(in VertexColor1Texture3 rootVal, in VertexColor1Texture3 morphVal)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		MaxColors = 1;
		MaxTextCoords = 3;
		Color0Delta = morphVal.Color - rootVal.Color;
		Color1Delta = Vector4.Zero;
		TexCoord0Delta = morphVal.TexCoord0 - rootVal.TexCoord0;
		TexCoord1Delta = morphVal.TexCoord1 - rootVal.TexCoord1;
		TexCoord2Delta = morphVal.TexCoord2 - rootVal.TexCoord2;
		TexCoord3Delta = Vector2.Zero;
	}

	internal VertexMaterialDelta(in VertexColor1Texture4 rootVal, in VertexColor1Texture4 morphVal)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		MaxColors = 1;
		MaxTextCoords = 4;
		Color0Delta = morphVal.Color - rootVal.Color;
		Color1Delta = Vector4.Zero;
		TexCoord0Delta = morphVal.TexCoord0 - rootVal.TexCoord0;
		TexCoord1Delta = morphVal.TexCoord1 - rootVal.TexCoord1;
		TexCoord2Delta = morphVal.TexCoord2 - rootVal.TexCoord2;
		TexCoord3Delta = morphVal.TexCoord3 - rootVal.TexCoord3;
	}

	internal VertexMaterialDelta(in VertexColor2 rootVal, in VertexColor2 morphVal)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		MaxColors = 2;
		MaxTextCoords = 0;
		Color0Delta = morphVal.Color0 - rootVal.Color0;
		Color1Delta = morphVal.Color1 - rootVal.Color1;
		TexCoord0Delta = Vector2.Zero;
		TexCoord1Delta = Vector2.Zero;
		TexCoord2Delta = Vector2.Zero;
		TexCoord3Delta = Vector2.Zero;
	}

	internal VertexMaterialDelta(in VertexColor2Texture1 rootVal, in VertexColor2Texture1 morphVal)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		MaxColors = 2;
		MaxTextCoords = 1;
		Color0Delta = morphVal.Color0 - rootVal.Color0;
		Color1Delta = morphVal.Color1 - rootVal.Color1;
		TexCoord0Delta = morphVal.TexCoord - rootVal.TexCoord;
		TexCoord1Delta = Vector2.Zero;
		TexCoord2Delta = Vector2.Zero;
		TexCoord3Delta = Vector2.Zero;
	}

	internal VertexMaterialDelta(in VertexColor2Texture2 rootVal, in VertexColor2Texture2 morphVal)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		MaxColors = 2;
		MaxTextCoords = 2;
		Color0Delta = morphVal.Color0 - rootVal.Color0;
		Color1Delta = morphVal.Color1 - rootVal.Color1;
		TexCoord0Delta = morphVal.TexCoord0 - rootVal.TexCoord0;
		TexCoord1Delta = morphVal.TexCoord1 - rootVal.TexCoord1;
		TexCoord2Delta = Vector2.Zero;
		TexCoord3Delta = Vector2.Zero;
	}

	internal VertexMaterialDelta(in VertexColor2Texture3 rootVal, in VertexColor2Texture3 morphVal)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		MaxColors = 2;
		MaxTextCoords = 3;
		Color0Delta = morphVal.Color0 - rootVal.Color0;
		Color1Delta = morphVal.Color1 - rootVal.Color1;
		TexCoord0Delta = morphVal.TexCoord0 - rootVal.TexCoord0;
		TexCoord1Delta = morphVal.TexCoord1 - rootVal.TexCoord1;
		TexCoord2Delta = morphVal.TexCoord2 - rootVal.TexCoord2;
		TexCoord3Delta = Vector2.Zero;
	}

	internal VertexMaterialDelta(in VertexColor2Texture4 rootVal, in VertexColor2Texture4 morphVal)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		MaxColors = 2;
		MaxTextCoords = 4;
		Color0Delta = morphVal.Color0 - rootVal.Color0;
		Color1Delta = morphVal.Color1 - rootVal.Color1;
		TexCoord0Delta = morphVal.TexCoord0 - rootVal.TexCoord0;
		TexCoord1Delta = morphVal.TexCoord1 - rootVal.TexCoord1;
		TexCoord2Delta = morphVal.TexCoord2 - rootVal.TexCoord2;
		TexCoord3Delta = morphVal.TexCoord3 - rootVal.TexCoord3;
	}

	void IVertexMaterial.Add(in VertexMaterialDelta delta)
	{
		Add(in delta);
	}
}
