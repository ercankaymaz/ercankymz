using System.Collections;
using System.Collections.Generic;

namespace ModuleWorks;

public class VertexNormaldCollection : IEnumerable<Vectord>, IEnumerable
{
	private BaseReadonlyMeshd mesh;

	public IEnumerator<Vectord> GetEnumerator()
	{
		return new VertexNormaldIterator(mesh);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new VertexNormaldIterator(mesh);
	}

	internal VertexNormaldCollection(BaseReadonlyMeshd mesh)
	{
		this.mesh = mesh;
	}
}
