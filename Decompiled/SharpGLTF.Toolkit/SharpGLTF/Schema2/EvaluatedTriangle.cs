using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using SharpGLTF.Geometry;
using SharpGLTF.Geometry.VertexTypes;
using SharpGLTF.Transforms;

namespace SharpGLTF.Schema2;

public readonly struct EvaluatedTriangle<TvG, TvM, TvS> where TvG : struct, IVertexGeometry where TvM : struct, IVertexMaterial where TvS : struct, IVertexSkinning
{
	public readonly VertexBuilder<TvG, TvM, TvS> A;

	public readonly VertexBuilder<TvG, TvM, TvS> B;

	public readonly VertexBuilder<TvG, TvM, TvS> C;

	public readonly Material Material;

	public static IEnumerable<EvaluatedTriangle<TvG, TvM, TvS>> GetTrianglesFromMesh(Mesh mesh, IGeometryTransform xform = null)
	{
		if (xform != null && !xform.Visible)
		{
			mesh = null;
		}
		if (mesh == null)
		{
			return Enumerable.Empty<EvaluatedTriangle<TvG, TvM, TvS>>();
		}
		List<(Material Material, VertexBufferColumns Vertices, IEnumerable<(int, int, int)> Triangles)> primitives = _GatherMeshGeometry(mesh);
		return InstancingTransform.Evaluate(xform).SelectMany((IGeometryTransform xinst) => primitives.SelectMany(delegate((Material Material, VertexBufferColumns Vertices, IEnumerable<(int, int, int)> Triangles) prim)
		{
			VertexBufferColumns vertices = ((xinst != null) ? prim.Vertices.WithTransform(xinst) : prim.Vertices);
			return _EvaluateTriangles(prim.Material, vertices, prim.Triangles);
		}));
	}

	private static List<(Material Material, VertexBufferColumns Vertices, IEnumerable<(int, int, int)> Triangles)> _GatherMeshGeometry(Mesh mesh)
	{
		List<(Material, VertexBufferColumns, IEnumerable<(int, int, int)>)> list = (from prim in mesh.Primitives
			where prim.GetTriangleIndices().Any()
			select ((Material Material, VertexBufferColumns, IEnumerable<(int, int, int)>))(Material: prim.Material, prim.GetVertexColumns(), prim.GetTriangleIndices().ToList())).ToList();
		Vector3 normal;
		bool flag = default(TvG).TryGetNormal(out normal);
		Vector4 tangent;
		bool flag2 = default(TvG).TryGetTangent(out tangent);
		if (flag)
		{
			List<(VertexBufferColumns, IEnumerable<(int, int, int)>)> list2 = (from p in list
				where p.Item2.Normals == null
				select (p.Item2, p.Item3)).ToList();
			if (list2.Count > 0)
			{
				VertexBufferColumns.CalculateSmoothNormals(list2);
			}
		}
		if (flag2)
		{
			List<(VertexBufferColumns, IEnumerable<(int, int, int)>)> list3 = (from p in list
				where p.Item2.Tangents == null && p.Item2.TexCoords0 != null
				select (p.Item2, p.Item3)).ToList();
			if (list3.Count > 0)
			{
				VertexBufferColumns.CalculateTangents(list3);
			}
		}
		return list;
	}

	private static IEnumerable<EvaluatedTriangle<TvG, TvM, TvS>> _EvaluateTriangles(Material material, VertexBufferColumns vertices, IEnumerable<(int A, int B, int C)> indices)
	{
		foreach (var index in indices)
		{
			int item = index.A;
			int item2 = index.B;
			int item3 = index.C;
			VertexBuilder<TvG, TvM, TvS> vertex = vertices.GetVertex<TvG, TvM, TvS>(item);
			VertexBuilder<TvG, TvM, TvS> vertex2 = vertices.GetVertex<TvG, TvM, TvS>(item2);
			VertexBuilder<TvG, TvM, TvS> vertex3 = vertices.GetVertex<TvG, TvM, TvS>(item3);
			yield return (A: vertex, B: vertex2, C: vertex3, Material: material);
		}
	}

	public static implicit operator EvaluatedTriangle<TvG, TvM, TvS>((VertexBuilder<TvG, TvM, TvS> A, VertexBuilder<TvG, TvM, TvS> B, VertexBuilder<TvG, TvM, TvS> C, Material Material) tri)
	{
		return new EvaluatedTriangle<TvG, TvM, TvS>(tri.A, tri.B, tri.C, tri.Material);
	}

	public EvaluatedTriangle(VertexBuilder<TvG, TvM, TvS> a, VertexBuilder<TvG, TvM, TvS> b, VertexBuilder<TvG, TvM, TvS> c, Material m)
	{
		A = a;
		B = b;
		C = c;
		Material = m;
	}

	public static IEnumerable<EvaluatedTriangle<TvG, TvM, TvS>> TransformTextureCoordsByMaterial(IEnumerable<EvaluatedTriangle<TvG, TvM, TvS>> triangles, Animation track = null, float time = -1f)
	{
		Dictionary<Material, Matrix3x2> diffuseTextureXformDict = new Dictionary<Material, Matrix3x2>();
		return triangles.Select((EvaluatedTriangle<TvG, TvM, TvS> tri) => _getTransformedTriangle(tri));
		EvaluatedTriangle<TvG, TvM, TvS> _getTransformedTriangle(EvaluatedTriangle<TvG, TvM, TvS> triangle)
		{
			//IL_0049: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			if (triangle.Material == null)
			{
				return triangle;
			}
			if (!diffuseTextureXformDict.TryGetValue(triangle.Material, out var value))
			{
				value = (Matrix3x2)(((_003F?)triangle.Material.GetDiffuseTextureMatrix(track, time)) ?? Matrix3x2.Identity);
				diffuseTextureXformDict[triangle.Material] = value;
			}
			if (((Matrix3x2)(ref value)).IsIdentity)
			{
				return triangle;
			}
			return triangle._TransformTextureBy(in value);
		}
	}

	private EvaluatedTriangle<TvG, TvM, TvS> _TransformTextureBy(in Matrix3x2 xform)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		VertexBuilder<TvG, TvM, TvS> a = A;
		VertexBuilder<TvG, TvM, TvS> b = B;
		VertexBuilder<TvG, TvM, TvS> c = C;
		a.Material.SetTexCoord(0, Vector2.Transform(a.Material.GetTexCoord(0), xform));
		b.Material.SetTexCoord(0, Vector2.Transform(b.Material.GetTexCoord(0), xform));
		c.Material.SetTexCoord(0, Vector2.Transform(c.Material.GetTexCoord(0), xform));
		return (A: a, B: b, C: c, Material: Material);
	}
}
