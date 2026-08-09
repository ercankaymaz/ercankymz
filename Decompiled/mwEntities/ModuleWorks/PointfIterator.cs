using System;
using System.Collections;
using System.Collections.Generic;

namespace ModuleWorks;

public class PointfIterator : IEnumerator<Vectorf>, IDisposable, IEnumerator
{
	private int index = -1;

	private BaseReadonlyMeshf mesh;

	private Vectorf current;

	public Vectorf Current => current;

	object IEnumerator.Current => current;

	internal PointfIterator(BaseReadonlyMeshf mesh)
	{
		this.mesh = mesh;
	}

	public void Dispose()
	{
	}

	public bool MoveNext()
	{
		index++;
		if (index >= mesh.PointCount)
		{
			return false;
		}
		current = mesh.GetPoint(index);
		return true;
	}

	public void Reset()
	{
		index = -1;
	}
}
