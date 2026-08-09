using System.Collections;
using System.Collections.Generic;

namespace ModuleWorks;

public class PointdCollection : IEnumerable<Vectord>, IEnumerable
{
	private BaseReadonlyMeshd mesh;

	public IEnumerator<Vectord> GetEnumerator()
	{
		return new PointdIterator(mesh);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new PointdIterator(mesh);
	}

	internal PointdCollection(BaseReadonlyMeshd mesh)
	{
		this.mesh = mesh;
	}
}
