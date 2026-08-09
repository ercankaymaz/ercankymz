using System.Collections;
using System.Collections.Generic;

namespace ModuleWorks;

public class PointfCollection : IEnumerable<Vectorf>, IEnumerable
{
	private BaseReadonlyMeshf mesh;

	public IEnumerator<Vectorf> GetEnumerator()
	{
		return new PointfIterator(mesh);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new PointfIterator(mesh);
	}

	internal PointfCollection(BaseReadonlyMeshf mesh)
	{
		this.mesh = mesh;
	}
}
