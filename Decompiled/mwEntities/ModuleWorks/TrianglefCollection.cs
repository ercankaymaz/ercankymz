using System.Collections;
using System.Collections.Generic;

namespace ModuleWorks;

public class TrianglefCollection : IEnumerable<Trianglef>, IEnumerable
{
	private BaseReadonlyMeshf mesh;

	public IEnumerator<Trianglef> GetEnumerator()
	{
		return new TrianglefIterator(mesh);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new TrianglefIterator(mesh);
	}

	internal TrianglefCollection(BaseReadonlyMeshf mesh)
	{
		this.mesh = mesh;
	}
}
