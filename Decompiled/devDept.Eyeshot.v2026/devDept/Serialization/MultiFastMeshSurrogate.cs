using System;
using System.Drawing;
using System.Linq;
using devDept.Eyeshot.Entities;

namespace devDept.Serialization;

public class MultiFastMeshSurrogate : FastMeshSurrogate
{
	public Tuple<int, int, Color>[] SubMeshColors;

	internal Tuple<int, int>[] subMeshRanges;

	public MultiFastMeshSurrogate(MultiFastMesh mfm)
		: base(mfm)
	{
	}

	protected override Entity ConvertToObject()
	{
		MultiFastMesh multiFastMesh = new MultiFastMesh(this);
		CopyDataToObject(multiFastMesh);
		return multiFastMesh;
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		MultiFastMesh multiFastMesh = (MultiFastMesh)entity;
		SubMeshColors = MultiFastMesh._0023_003Dzvv6hJ9KR6NHc(multiFastMesh.SubMeshIntervals).ToArray();
		subMeshRanges = MultiFastMesh._0023_003Dzvv6hJ9KR6NHc(multiFastMesh._0023_003DzlTUjqXrVSKtY8Mj2rg_003D_003D()).ToArray();
		base.CopyDataFromObject(entity);
	}
}
