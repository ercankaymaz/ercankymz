using System;
using System.Diagnostics;
using SharpGLTF.Geometry;
using SharpGLTF.Materials;
using SharpGLTF.Schema2;

namespace SharpGLTF.Scenes;

[DebuggerDisplay("MeshContent => {_Mesh}")]
internal class MeshContent : IRenderableContent, ICloneable, IEquatable<IRenderableContent>, Schema2SceneBuilder.IOperator<Node>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IMeshBuilder<MaterialBuilder> _Mesh;

	public IMeshBuilder<MaterialBuilder> Mesh
	{
		get
		{
			return _Mesh;
		}
		set
		{
			_Mesh = value;
		}
	}

	public MeshContent(IMeshBuilder<MaterialBuilder> mesh)
	{
		_Mesh = mesh;
	}

	public object Clone()
	{
		return new MeshContent(this);
	}

	private MeshContent(MeshContent other)
	{
		_Mesh = other._Mesh;
	}

	public override int GetHashCode()
	{
		return _Mesh.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is IRenderableContent other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(IRenderableContent other)
	{
		if (other is MeshContent meshContent)
		{
			return _Mesh == meshContent._Mesh;
		}
		throw new ArgumentException("Type mismatch", "other");
	}

	public IMeshBuilder<MaterialBuilder> GetGeometryAsset()
	{
		return _Mesh;
	}

	void Schema2SceneBuilder.IOperator<Node>.ApplyTo(Node dstNode, Schema2SceneBuilder context)
	{
		if (dstNode.Mesh != null)
		{
			dstNode = dstNode.CreateNode();
		}
		dstNode.Mesh = context.GetMesh(_Mesh);
	}
}
