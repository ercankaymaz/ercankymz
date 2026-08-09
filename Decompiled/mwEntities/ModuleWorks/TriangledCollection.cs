using System.Collections;
using System.Collections.Generic;

namespace ModuleWorks;

public class TriangledCollection : IEnumerable<Triangled>, IEnumerable
{
	private BaseReadonlyMeshd mesh;

	public IEnumerator<Triangled> GetEnumerator()
	{
		return new TriangledIterator(mesh);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new TriangledIterator(mesh);
	}

	internal TriangledCollection(BaseReadonlyMeshd mesh)
	{
		this.mesh = mesh;
	}
}
