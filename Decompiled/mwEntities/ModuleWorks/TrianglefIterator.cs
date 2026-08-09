using System;
using System.Collections;
using System.Collections.Generic;

namespace ModuleWorks;

public class TrianglefIterator : IEnumerator<Trianglef>, IDisposable, IEnumerator
{
	private int index = -1;

	private BaseReadonlyMeshf mesh;

	private Trianglef current;

	public Trianglef Current => current;

	object IEnumerator.Current => current;

	internal TrianglefIterator(BaseReadonlyMeshf mesh)
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
