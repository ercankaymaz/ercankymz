using System.Collections.Generic;
using System.Linq;
using SharpGLTF.Schema2;

namespace SharpGLTF.Runtime;

internal sealed class _MeshDecoder<TMaterial> : IMeshDecoder<TMaterial> where TMaterial : class
{
	private readonly string _Name;

	private readonly object _Extras;

	private readonly int _LogicalIndex;

	private readonly _MeshPrimitiveDecoder<TMaterial>[] _Primitives;

	public string Name => _Name;

	public object Extras => _Extras;

	public int LogicalIndex => _LogicalIndex;

	public IReadOnlyList<IMeshPrimitiveDecoder<TMaterial>> Primitives => _Primitives;

	public _MeshDecoder(Mesh srcMesh, RuntimeOptions options)
	{
		SharpGLTF.Guard.NotNull(srcMesh, "srcMesh");
		_Name = srcMesh.Name;
		_Extras = RuntimeOptions.ConvertExtras(srcMesh, options);
		_LogicalIndex = srcMesh.LogicalIndex;
		_Primitives = srcMesh.Primitives.Select((MeshPrimitive item) => new _MeshPrimitiveDecoder<TMaterial>(item)).ToArray();
	}

	public void GenerateNormalsAndTangents()
	{
		if (_Primitives.Length == 0)
		{
			return;
		}
		List<_MeshGeometryDecoder> list = _Primitives.Select((_MeshPrimitiveDecoder<TMaterial> item) => item._Geometry).ToList();
		bool flag = list.All((_MeshGeometryDecoder item) => item.HasNormals);
		bool flag2 = list.All((_MeshGeometryDecoder item) => item.HasTangents);
		if (!flag)
		{
			VertexNormalsFactory.CalculateSmoothNormals(list);
		}
		if (!flag2)
		{
			VertexTangentsFactory.CalculateTangents(list);
		}
		int num = _Primitives.Min((_MeshPrimitiveDecoder<TMaterial> item) => item.MorphTargetsCount);
		List<_MorphTargetDecoder> list2 = new List<_MorphTargetDecoder>();
		int i = 0;
		while (i < num)
		{
			list2.Clear();
			list2.AddRange(_Primitives.Select((_MeshPrimitiveDecoder<TMaterial> item) => item._MorphTargets[i]));
			flag = list2.All((_MorphTargetDecoder item) => item.HasNormals);
			flag2 = list2.All((_MorphTargetDecoder item) => item.HasTangents);
			if (!flag)
			{
				VertexNormalsFactory.CalculateSmoothNormals(list2);
			}
			if (!flag2)
			{
				VertexTangentsFactory.CalculateTangents(list2);
			}
			int num2 = i + 1;
			i = num2;
		}
	}
}
