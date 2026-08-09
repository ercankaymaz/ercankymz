using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using SharpGLTF.Geometry.VertexTypes;
using SharpGLTF.Materials;

namespace SharpGLTF.Geometry;

public class MeshBuilder<TMaterial, TvG, TvM, TvS> : BaseBuilder, IMeshBuilder<TMaterial>, ICloneable where TvG : struct, IVertexGeometry where TvM : struct, IVertexMaterial where TvS : struct, IVertexSkinning
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly Dictionary<(TMaterial Material, int PrimType), PrimitiveBuilder<TMaterial, TvG, TvM, TvS>> _Primitives = new Dictionary<(TMaterial, int), PrimitiveBuilder<TMaterial, TvG, TvM, TvS>>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private VertexPreprocessor<TvG, TvM, TvS> _VertexPreprocessor;

	public bool IsEmpty => Primitives.Sum((PrimitiveBuilder<TMaterial, TvG, TvM, TvS> item) => item.Vertices.Count) == 0;

	public VertexPreprocessor<TvG, TvM, TvS> VertexPreprocessor
	{
		get
		{
			return _VertexPreprocessor;
		}
		set
		{
			_VertexPreprocessor = value;
		}
	}

	public IEnumerable<TMaterial> Materials => _Primitives.Keys.Select(((TMaterial Material, int PrimType) item) => item.Material).Distinct();

	public IReadOnlyCollection<PrimitiveBuilder<TMaterial, TvG, TvM, TvS>> Primitives => _Primitives.Values;

	IReadOnlyCollection<IPrimitiveReader<TMaterial>> IMeshBuilder<TMaterial>.Primitives => _Primitives.Values;

	public MeshBuilder()
		: this((string)null)
	{
	}

	public MeshBuilder(string name)
		: base(name)
	{
		_VertexPreprocessor = new VertexPreprocessor<TvG, TvM, TvS>();
		_VertexPreprocessor.SetSanitizerPreprocessors();
	}

	object ICloneable.Clone()
	{
		return new MeshBuilder<TMaterial, TvG, TvM, TvS>(this);
	}

	IMeshBuilder<TMaterial> IMeshBuilder<TMaterial>.Clone(Func<TMaterial, TMaterial> materialCloneCallback)
	{
		return new MeshBuilder<TMaterial, TvG, TvM, TvS>(this, materialCloneCallback);
	}

	public MeshBuilder<TMaterial, TvG, TvM, TvS> Clone(Func<TMaterial, TMaterial> materialCloneCallback = null)
	{
		return new MeshBuilder<TMaterial, TvG, TvM, TvS>(this, materialCloneCallback);
	}

	private MeshBuilder(MeshBuilder<TMaterial, TvG, TvM, TvS> other, Func<TMaterial, TMaterial> materialCloneCallback = null)
		: base(other)
	{
		SharpGLTF.Guard.NotNull(other, "other");
		_VertexPreprocessor = other._VertexPreprocessor;
		foreach (KeyValuePair<(TMaterial, int), PrimitiveBuilder<TMaterial, TvG, TvM, TvS>> primitive in other._Primitives)
		{
			TMaterial val = primitive.Key.Item1;
			if (materialCloneCallback != null)
			{
				val = materialCloneCallback(val);
				if (val == null)
				{
					continue;
				}
			}
			(TMaterial, int) key = (val, primitive.Key.Item2);
			if (_Primitives.TryGetValue(key, out var value))
			{
				value.AddPrimitive(primitive.Value, null);
			}
			else
			{
				_Primitives[key] = primitive.Value.Clone(this, val);
			}
		}
	}

	public MorphTargetBuilder<TMaterial, TvG, TvS, TvM> UseMorphTarget(int morphTargetIndex)
	{
		return new MorphTargetBuilder<TMaterial, TvG, TvS, TvM>(this, morphTargetIndex);
	}

	IMorphTargetBuilder IMeshBuilder<TMaterial>.UseMorphTarget(int index)
	{
		return UseMorphTarget(index);
	}

	private PrimitiveBuilder<TMaterial, TvG, TvM, TvS> _UsePrimitive((TMaterial Material, int PrimType) key)
	{
		if (!_Primitives.TryGetValue(key, out var value))
		{
			if (key.PrimType == 1)
			{
				value = new PointsPrimitiveBuilder<TMaterial, TvG, TvM, TvS>(this, key.Material);
			}
			if (key.PrimType == 2)
			{
				value = new LinesPrimitiveBuilder<TMaterial, TvG, TvM, TvS>(this, key.Material);
			}
			if (key.PrimType == 3)
			{
				value = new TrianglesPrimitiveBuilder<TMaterial, TvG, TvM, TvS>(this, key.Material);
			}
			SharpGLTF.Guard.NotNull(value, "key");
			_Primitives[key] = value;
		}
		return value;
	}

	public PrimitiveBuilder<TMaterial, TvG, TvM, TvS> UsePrimitive(TMaterial material, int primitiveVertexCount = 3)
	{
		SharpGLTF.Guard.NotNull(material, "material");
		SharpGLTF.Guard.MustBeBetweenOrEqualTo(primitiveVertexCount, 1, 3, "primitiveVertexCount");
		return _UsePrimitive((Material: material, PrimType: primitiveVertexCount));
	}

	IPrimitiveBuilder IMeshBuilder<TMaterial>.UsePrimitive(TMaterial material, int primitiveVertexCount)
	{
		SharpGLTF.Guard.NotNull(material, "material");
		SharpGLTF.Guard.MustBeBetweenOrEqualTo(primitiveVertexCount, 1, 3, "primitiveVertexCount");
		return _UsePrimitive((Material: material, PrimType: primitiveVertexCount));
	}

	public void AddMesh(IMeshBuilder<TMaterial> mesh, Matrix4x4 vertexTransform)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		if (mesh == null)
		{
			return;
		}
		if (vertexTransform == Matrix4x4.Identity)
		{
			this.AddMesh<TMaterial>(mesh, (Func<TMaterial, TMaterial>)null, (Converter<IVertexBuilder, VertexBuilder<TvG, TvM, TvS>>)null);
			return;
		}
		this.AddMesh<TMaterial>(mesh, (Func<TMaterial, TMaterial>)null, (Converter<IVertexBuilder, VertexBuilder<TvG, TvM, TvS>>)((IVertexBuilder v) => VertexBuilder<TvG, TvM, TvS>.CreateFrom(v).TransformedBy(in vertexTransform)));
	}

	public void AddMesh(IMeshBuilder<TMaterial> mesh, Func<TMaterial, TMaterial> materialTransform = null, Converter<IVertexBuilder, VertexBuilder<TvG, TvM, TvS>> vertexTransform = null)
	{
		if (mesh == null)
		{
			return;
		}
		if (materialTransform == null)
		{
			materialTransform = (TMaterial m) => m;
		}
		if (vertexTransform == null)
		{
			vertexTransform = (IVertexBuilder v) => VertexBuilder<TvG, TvM, TvS>.CreateFrom(v);
		}
		this.AddMesh<TMaterial>(mesh, materialTransform, vertexTransform);
	}

	public void AddMesh<TSourceMaterial>(IMeshBuilder<TSourceMaterial> mesh, Func<TSourceMaterial, TMaterial> materialTransform, Converter<IVertexBuilder, VertexBuilder<TvG, TvM, TvS>> vertexTransform = null)
	{
		if (mesh == null)
		{
			return;
		}
		SharpGLTF.Guard.NotNull(materialTransform, "materialTransform");
		if (vertexTransform == null)
		{
			vertexTransform = (IVertexBuilder v) => VertexBuilder<TvG, TvM, TvS>.CreateFrom(v);
		}
		foreach (IPrimitiveReader<TSourceMaterial> primitive in mesh.Primitives)
		{
			TMaterial material = materialTransform(primitive.Material);
			UsePrimitive(material).AddPrimitive(primitive, vertexTransform);
		}
	}

	public void TransformVertices(Func<VertexBuilder<TvG, TvM, TvS>, VertexBuilder<TvG, TvM, TvS>> vertexTransform)
	{
		foreach (PrimitiveBuilder<TMaterial, TvG, TvM, TvS> primitive in Primitives)
		{
			primitive.TransformVertices(vertexTransform);
		}
	}

	public void Validate()
	{
		foreach (PrimitiveBuilder<TMaterial, TvG, TvM, TvS> value in _Primitives.Values)
		{
			value.Validate();
		}
	}
}
public class MeshBuilder<TvG, TvM, TvS> : MeshBuilder<MaterialBuilder, TvG, TvM, TvS> where TvG : struct, IVertexGeometry where TvM : struct, IVertexMaterial where TvS : struct, IVertexSkinning
{
	public MeshBuilder(string name = null)
		: base(name)
	{
	}
}
public class MeshBuilder<TvG, TvM> : MeshBuilder<MaterialBuilder, TvG, TvM, VertexEmpty> where TvG : struct, IVertexGeometry where TvM : struct, IVertexMaterial
{
	public MeshBuilder(string name = null)
		: base(name)
	{
	}
}
public class MeshBuilder<TvG> : MeshBuilder<MaterialBuilder, TvG, VertexEmpty, VertexEmpty> where TvG : struct, IVertexGeometry
{
	public MeshBuilder(string name = null)
		: base(name)
	{
	}
}
