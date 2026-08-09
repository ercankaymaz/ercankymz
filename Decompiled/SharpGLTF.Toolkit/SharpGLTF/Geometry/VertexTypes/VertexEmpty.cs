using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.InteropServices;
using SharpGLTF.Memory;
using SharpGLTF.Transforms;

namespace SharpGLTF.Geometry.VertexTypes;

[StructLayout(LayoutKind.Sequential, Size = 1)]
[DebuggerDisplay("Empty")]
public readonly struct VertexEmpty : IVertexMaterial, IVertexReflection, IVertexSkinning, IEquatable<VertexEmpty>
{
	public int MaxBindings => 0;

	public int MaxColors => 0;

	public int MaxTextCoords => 0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	Vector4 IVertexSkinning.JointsLow => Vector4.Zero;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	Vector4 IVertexSkinning.JointsHigh => Vector4.Zero;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	Vector4 IVertexSkinning.WeightsLow => Vector4.Zero;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	Vector4 IVertexSkinning.WeightsHigh => Vector4.Zero;

	public void Validate()
	{
	}

	IEnumerable<KeyValuePair<string, AttributeFormat>> IVertexReflection.GetEncodingAttributes()
	{
		yield break;
	}

	public override int GetHashCode()
	{
		return 0;
	}

	public override bool Equals(object obj)
	{
		return obj is VertexEmpty;
	}

	public bool Equals(VertexEmpty other)
	{
		return true;
	}

	public static bool operator ==(in VertexEmpty a, in VertexEmpty b)
	{
		return true;
	}

	public static bool operator !=(in VertexEmpty a, in VertexEmpty b)
	{
		return false;
	}

	void IVertexMaterial.SetColor(int index, Vector4 color)
	{
		throw new ArgumentOutOfRangeException("index");
	}

	void IVertexMaterial.SetTexCoord(int index, Vector2 coord)
	{
		throw new ArgumentOutOfRangeException("index");
	}

	VertexMaterialDelta IVertexMaterial.Subtract(IVertexMaterial baseValue)
	{
		return VertexMaterialDelta.Zero;
	}

	void IVertexMaterial.Add(in VertexMaterialDelta delta)
	{
	}

	Vector4 IVertexMaterial.GetColor(int index)
	{
		throw new ArgumentOutOfRangeException("index");
	}

	Vector2 IVertexMaterial.GetTexCoord(int index)
	{
		throw new ArgumentOutOfRangeException("index");
	}

	public SparseWeight8 GetBindings()
	{
		return default(SparseWeight8);
	}

	public void SetBindings(in SparseWeight8 bindings)
	{
		throw new NotSupportedException();
	}

	public void SetBindings(params (int Index, float Weight)[] bindings)
	{
		throw new NotSupportedException();
	}

	(int Index, float Weight) IVertexSkinning.GetBinding(int index)
	{
		throw new ArgumentOutOfRangeException("index");
	}

	void IVertexSkinning.SetBindings(in SparseWeight8 bindings)
	{
		SetBindings(in bindings);
	}
}
