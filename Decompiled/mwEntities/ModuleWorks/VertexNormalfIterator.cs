using System;
using System.Collections;
using System.Collections.Generic;

namespace ModuleWorks;

public class VertexNormalfIterator : IEnumerator<Vectorf>, IDisposable, IEnumerator
{
	private int index = -1;

	private BaseReadonlyMeshf mesh;

	private Vectorf current;

	public Vectorf Current => current;

	object IEnumerator.Current => current;

	internal VertexNormalfIterator(BaseReadonlyMeshf mesh)
	{
		this.mesh = mesh;
	}

	public void Dispose()
	{
	}

	public bool MoveNext()
	{
		index++;
		if (index >= mesh.VertexNormalCount)
		{
			return false;
		}
		current = mesh.GetVertexNormal(index);
		return true;
	}

	public void Reset()
	{
		index = -1;
	}
}
