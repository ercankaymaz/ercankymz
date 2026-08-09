using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Reflection;
using System.Text;
using SharpGLTF.Geometry.VertexTypes;
using SharpGLTF.Transforms;

namespace SharpGLTF.Geometry;

[DebuggerDisplay("{_GetDebuggerDisplay(),nq}")]
public struct VertexBuilder<TvG, TvM, TvS> : IVertexBuilder, IEquatable<VertexBuilder<TvG, TvM, TvS>> where TvG : struct, IVertexGeometry where TvM : struct, IVertexMaterial where TvS : struct, IVertexSkinning
{
	public TvG Geometry;

	public TvM Material;

	public TvS Skinning;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public Vector3 Position
	{
		readonly get
		{
			//IL_0009: Unknown result type (might be due to invalid IL or missing references)
			return Geometry.GetPosition();
		}
		set
		{
			Geometry.SetPosition(in value);
		}
	}

	internal readonly string _GetDebuggerDisplay()
	{
		string text = "Vertex";
		text = text + " " + _GetDebuggerDisplayTextFrom(Geometry);
		text = text + " " + _GetDebuggerDisplayTextFrom(Material);
		return text + " " + _GetDebuggerDisplayTextFrom(Skinning);
	}

	private static string _GetDebuggerDisplayTextFrom(object o)
	{
		if (o is VertexEmpty)
		{
			return string.Empty;
		}
		BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
		MethodInfo method = o.GetType().GetMethod("_GetDebuggerDisplay", bindingAttr);
		if (method == null)
		{
			return string.Empty;
		}
		return method.Invoke(o, Array.Empty<object>()) as string;
	}

	private readonly string _GetDebugWarnings()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		StringBuilder stringBuilder = new StringBuilder();
		if (Geometry.TryGetNormal(out var normal) && !normal.IsNormalized())
		{
			stringBuilder.Append($" ❌\ud835\udeb4:{normal}");
		}
		if (Geometry.TryGetTangent(out var tangent) && !tangent.IsValidTangent())
		{
			stringBuilder.Append($" ❌\ud835\udebb:{tangent}");
		}
		for (int i = 0; i < Material.MaxColors; i++)
		{
			Vector4 v = Material.GetColor(i);
			if (!v._IsFinite() | !v.IsInRange(Vector4.Zero, Vector4.One))
			{
				stringBuilder.Append($" ❌\ud835\udc02{i}:{v}");
			}
		}
		for (int j = 0; j < Material.MaxTextCoords; j++)
		{
			Vector2 texCoord = Material.GetTexCoord(j);
			if (!texCoord._IsFinite())
			{
				stringBuilder.Append($" ❌\ud835\udc14\ud835\udc15{j}:{texCoord}");
			}
		}
		for (int k = 0; k < Skinning.MaxBindings; k++)
		{
			var (num, num2) = Skinning.GetBinding(k);
			if (!num2._IsFinite() || num2 < 0f || num < 0)
			{
				stringBuilder.Append($" ❌\ud835\udc09\ud835\udc16{k} {num}:{num2}");
			}
		}
		return stringBuilder.ToString();
	}

	public VertexBuilder(in TvG g, in TvM m, in TvS s)
	{
		Geometry = g;
		Material = m;
		Skinning = s;
	}

	public VertexBuilder(in TvG g, in TvM m, params (int JointIndex, float Weight)[] bindings)
	{
		Geometry = g;
		Material = m;
		SparseWeight8 bindings2 = SparseWeight8.Create(bindings);
		Skinning = default(TvS);
		Skinning.SetBindings(in bindings2);
	}

	public VertexBuilder(in TvG g, in TvM m, in SparseWeight8 bindings)
	{
		Geometry = g;
		Material = m;
		Skinning = default(TvS);
		Skinning.SetBindings(in bindings);
	}

	public VertexBuilder(in TvG g, in TvM m)
	{
		Geometry = g;
		Material = m;
		Skinning = default(TvS);
	}

	public VertexBuilder(in TvG g, in TvS s)
	{
		Geometry = g;
		Material = default(TvM);
		Skinning = s;
	}

	public VertexBuilder(in TvG g)
	{
		Geometry = g;
		Material = default(TvM);
		Skinning = default(TvS);
	}

	public VertexBuilder(in TvG g, params (int JointIndex, float Weight)[] bindings)
	{
		Geometry = g;
		Material = default(TvM);
		SparseWeight8 bindings2 = SparseWeight8.Create(bindings);
		Skinning = default(TvS);
		Skinning.SetBindings(in bindings2);
	}

	public VertexBuilder(TvG g, SparseWeight8 bindings)
	{
		Geometry = g;
		Material = default(TvM);
		Skinning = default(TvS);
		Skinning.SetBindings(in bindings);
	}

	public static implicit operator VertexBuilder<TvG, TvM, TvS>(in (TvG Geo, TvM Mat, TvS Skin) tuple)
	{
		return new VertexBuilder<TvG, TvM, TvS>(in tuple.Geo, in tuple.Mat, in tuple.Skin);
	}

	public static implicit operator VertexBuilder<TvG, TvM, TvS>(in (TvG Geo, TvM Mat) tuple)
	{
		return new VertexBuilder<TvG, TvM, TvS>(in tuple.Geo, in tuple.Mat);
	}

	public static implicit operator VertexBuilder<TvG, TvM, TvS>(in (TvG Geo, TvS Skin) tuple)
	{
		return new VertexBuilder<TvG, TvM, TvS>(in tuple.Geo, in tuple.Skin);
	}

	public static implicit operator VertexBuilder<TvG, TvM, TvS>(in TvG g)
	{
		return new VertexBuilder<TvG, TvM, TvS>(in g);
	}

	public static VertexBuilder<TvG, TvM, TvS> Create(in Vector3 position)
	{
		VertexBuilder<TvG, TvM, TvS> result = default(VertexBuilder<TvG, TvM, TvS>);
		result.Geometry.SetPosition(in position);
		return result;
	}

	public static VertexBuilder<TvG, TvM, TvS> Create(in Vector3 position, in Vector3 normal)
	{
		VertexBuilder<TvG, TvM, TvS> result = default(VertexBuilder<TvG, TvM, TvS>);
		result.Geometry.SetPosition(in position);
		result.Geometry.SetNormal(in normal);
		return result;
	}

	public static VertexBuilder<TvG, TvM, TvS> Create(in Vector3 position, in Vector3 normal, in Vector4 tangent)
	{
		VertexBuilder<TvG, TvM, TvS> result = default(VertexBuilder<TvG, TvM, TvS>);
		result.Geometry.SetPosition(in position);
		result.Geometry.SetNormal(in normal);
		result.Geometry.SetTangent(in tangent);
		return result;
	}

	public static VertexBuilder<TvG, TvM, TvS> CreateFrom(IVertexBuilder src)
	{
		if (src is VertexBuilder<TvG, TvM, TvS>)
		{
			return (VertexBuilder<TvG, TvM, TvS>)(object)src;
		}
		SharpGLTF.Guard.NotNull(src, "src");
		return new VertexBuilder<TvG, TvM, TvS>
		{
			Geometry = src.GetGeometry().ConvertToGeometry<TvG>(),
			Material = src.GetMaterial().ConvertToMaterial<TvM>(),
			Skinning = src.GetSkinning().ConvertToSkinning<TvS>()
		};
	}

	public override readonly int GetHashCode()
	{
		return Geometry.GetHashCode();
	}

	public override readonly bool Equals(object obj)
	{
		if (obj is VertexBuilder<TvG, TvM, TvS> b)
		{
			return AreEqual(this, in b);
		}
		return false;
	}

	public readonly bool Equals(VertexBuilder<TvG, TvM, TvS> other)
	{
		return AreEqual(this, in other);
	}

	public static bool operator ==(in VertexBuilder<TvG, TvM, TvS> a, in VertexBuilder<TvG, TvM, TvS> b)
	{
		return AreEqual(in a, in b);
	}

	public static bool operator !=(in VertexBuilder<TvG, TvM, TvS> a, in VertexBuilder<TvG, TvM, TvS> b)
	{
		return !AreEqual(in a, in b);
	}

	public static bool AreEqual(in VertexBuilder<TvG, TvM, TvS> a, in VertexBuilder<TvG, TvM, TvS> b)
	{
		if (a.Geometry.Equals(b.Geometry) && a.Material.Equals(b.Material))
		{
			return a.Skinning.Equals(b.Skinning);
		}
		return false;
	}

	public readonly void Validate()
	{
		VertexPreprocessorLambdas.ValidateVertexGeometry(Geometry);
		VertexPreprocessorLambdas.ValidateVertexMaterial(Material);
		VertexPreprocessorLambdas.ValidateVertexSkinning(Skinning);
	}

	public static MeshBuilder<TMaterial, TvG, TvM, TvS> CreateCompatibleMesh<TMaterial>(string name = null)
	{
		return new MeshBuilder<TMaterial, TvG, TvM, TvS>(name);
	}

	public static MeshBuilder<TvG, TvM, TvS> CreateCompatibleMesh(string name = null)
	{
		return new MeshBuilder<TvG, TvM, TvS>(name);
	}

	IMeshBuilder<TMaterial> IVertexBuilder.CreateCompatibleMesh<TMaterial>(string name)
	{
		return new MeshBuilder<TMaterial, TvG, TvM, TvS>(name);
	}

	readonly IVertexGeometry IVertexBuilder.GetGeometry()
	{
		return Geometry;
	}

	readonly IVertexMaterial IVertexBuilder.GetMaterial()
	{
		return Material;
	}

	readonly IVertexSkinning IVertexBuilder.GetSkinning()
	{
		return Skinning;
	}

	void IVertexBuilder.SetGeometry(IVertexGeometry geometry)
	{
		SharpGLTF.Guard.NotNull(geometry, "geometry");
		Geometry = geometry.ConvertToGeometry<TvG>();
	}

	void IVertexBuilder.SetMaterial(IVertexMaterial material)
	{
		SharpGLTF.Guard.NotNull(material, "material");
		Material = material.ConvertToMaterial<TvM>();
	}

	void IVertexBuilder.SetSkinning(IVertexSkinning skinning)
	{
		SharpGLTF.Guard.NotNull(skinning, "skinning");
		Skinning = skinning.ConvertToSkinning<TvS>();
	}

	public readonly VertexBuilder<TvG, TvM, TvS> TransformedBy(in Matrix4x4 transform)
	{
		VertexBuilder<TvG, TvM, TvS> result = this;
		result.Geometry.ApplyTransform(in transform);
		return result;
	}

	public readonly VertexBuilder<TvG, TvM, TvS> WithGeometry(in Vector3 position)
	{
		VertexBuilder<TvG, TvM, TvS> result = this;
		result.Geometry.SetPosition(in position);
		return result;
	}

	public readonly VertexBuilder<TvG, TvM, TvS> WithGeometry(in Vector3 position, in Vector3 normal)
	{
		VertexBuilder<TvG, TvM, TvS> result = this;
		result.Geometry.SetPosition(in position);
		result.Geometry.SetNormal(in normal);
		return result;
	}

	public readonly VertexBuilder<TvG, TvM, TvS> WithGeometry(in Vector3 position, in Vector3 normal, in Vector4 tangent)
	{
		VertexBuilder<TvG, TvM, TvS> result = this;
		result.Geometry.SetPosition(in position);
		result.Geometry.SetNormal(in normal);
		result.Geometry.SetTangent(in tangent);
		return result;
	}

	public readonly VertexBuilder<TvG, TvM, TvS> WithMaterial(params Vector2[] uvs)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		SharpGLTF.Guard.NotNull(uvs, "uvs");
		VertexBuilder<TvG, TvM, TvS> result = this;
		for (int i = 0; i < uvs.Length; i++)
		{
			result.Material.SetTexCoord(i, uvs[i]);
		}
		return result;
	}

	public readonly VertexBuilder<TvG, TvM, TvS> WithMaterial(in Vector4 color0, params Vector2[] uvs)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		SharpGLTF.Guard.NotNull(uvs, "uvs");
		VertexBuilder<TvG, TvM, TvS> result = this;
		result.Material.SetColor(0, color0);
		for (int i = 0; i < uvs.Length; i++)
		{
			result.Material.SetTexCoord(i, uvs[i]);
		}
		return result;
	}

	public readonly VertexBuilder<TvG, TvM, TvS> WithMaterial(in Vector4 color0, Vector4 color1, params Vector2[] uvs)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		SharpGLTF.Guard.NotNull(uvs, "uvs");
		VertexBuilder<TvG, TvM, TvS> result = this;
		result.Material.SetColor(0, color0);
		result.Material.SetColor(1, color1);
		for (int i = 0; i < uvs.Length; i++)
		{
			result.Material.SetTexCoord(i, uvs[i]);
		}
		return result;
	}

	public readonly VertexBuilder<TvG, TvM, TvS> WithSkinning(in SparseWeight8 sparse)
	{
		VertexBuilder<TvG, TvM, TvS> result = this;
		result.Skinning.SetBindings(in sparse);
		return result;
	}

	public readonly VertexBuilder<TvG, TvM, TvS> WithSkinning(params (int Index, float Weight)[] bindings)
	{
		VertexBuilder<TvG, TvM, TvS> result = this;
		SparseWeight8 bindings2 = SparseWeight8.Create(bindings);
		result.Skinning.SetBindings(in bindings2);
		return result;
	}

	public readonly VertexBuilder<TvG, TvM, TvS> WithSkinning(IEnumerable<(int Index, float Weight)> bindings)
	{
		VertexBuilder<TvG, TvM, TvS> result = this;
		SparseWeight8 bindings2 = SparseWeight8.Create(bindings);
		result.Skinning.SetBindings(in bindings2);
		return result;
	}
}
internal struct VertexBuilder : IVertexBuilder
{
	public IVertexGeometry Geometry;

	public IVertexMaterial Material;

	public IVertexSkinning Skinning;

	public VertexBuilder(IVertexGeometry g)
	{
		Geometry = g;
		Material = null;
		Skinning = null;
	}

	public VertexBuilder(IVertexGeometry g, IVertexMaterial m, IVertexSkinning s)
	{
		Geometry = g;
		Material = m;
		Skinning = s;
	}

	public override readonly int GetHashCode()
	{
		return Geometry.GetHashCode();
	}

	public readonly IVertexGeometry GetGeometry()
	{
		return Geometry;
	}

	public readonly IVertexMaterial GetMaterial()
	{
		return Material;
	}

	public readonly IVertexSkinning GetSkinning()
	{
		return Skinning;
	}

	public void SetGeometry(IVertexGeometry geometry)
	{
		Geometry = geometry;
	}

	public void SetMaterial(IVertexMaterial material)
	{
		Material = material;
	}

	public void SetSkinning(IVertexSkinning skinning)
	{
		Skinning = skinning;
	}

	public readonly IVertexBuilder ConvertToType(Func<IVertexBuilder> factory)
	{
		IVertexBuilder vertexBuilder = factory();
		vertexBuilder.SetGeometry(Geometry);
		vertexBuilder.SetMaterial(Material);
		vertexBuilder.SetSkinning(Skinning);
		return vertexBuilder;
	}

	IMeshBuilder<TMaterial> IVertexBuilder.CreateCompatibleMesh<TMaterial>(string name)
	{
		throw new NotImplementedException();
	}
}
