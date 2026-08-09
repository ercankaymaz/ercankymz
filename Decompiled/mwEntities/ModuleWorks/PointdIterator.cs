using System;
using System.Collections;
using System.Collections.Generic;

namespace ModuleWorks;

public class PointdIterator : IEnumerator<Vectord>, IDisposable, IEnumerator
{
	private int index = -1;

	private BaseReadonlyMeshd mesh;

	private Vectord current;

	public Vectord Current => current;

	object IEnumerator.Current => current;

	internal PointdIterator(BaseReadonlyMeshd mesh)
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
