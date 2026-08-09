using System;
using System.Collections;
using System.Collections.Generic;

namespace ModuleWorks;

public class TriangledIterator : IEnumerator<Triangled>, IDisposable, IEnumerator
{
	private int index = -1;

	private BaseReadonlyMeshd mesh;

	private Triangled current;

	public Triangled Current => current;

	object IEnumerator.Current => current;

	internal TriangledIterator(BaseReadonlyMeshd mesh)
	{
		this.mesh = mesh;
	}

	public void Dispose()
	{
	}

	public bool MoveNext()
	{
		index++;
		if (index >= mesh.TriangleCount)
		{
			return false;
		}
		current = mesh.GetTriangle(index);
		return true;
	}

	public void Reset()
	{
		index = -1;
	}
}
