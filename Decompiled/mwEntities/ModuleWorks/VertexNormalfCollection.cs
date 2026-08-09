using System.Collections;
using System.Collections.Generic;

namespace ModuleWorks;

public class VertexNormalfCollection : IEnumerable<Vectorf>, IEnumerable
{
	private BaseReadonlyMeshf mesh;

	public IEnumerator<Vectorf> GetEnumerator()
	{
		return new VertexNormalfIterator(mesh);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new VertexNormalfIterator(mesh);
	}

	internal VertexNormalfCollection(BaseReadonlyMeshf mesh)
	{
		this.mesh = mesh;
	}
}
