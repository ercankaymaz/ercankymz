using System;
using System.Collections;
using System.Collections.Generic;

namespace ModuleWorks.Util;

[Obsolete("Deprecated since Release 2018.04.")]
public class FastListEnumerator<T> : IEnumerator<T>, IDisposable, IEnumerator
{
	private int index;

	private readonly int modCount;

	private readonly FastList<T> L;

	public T Current
	{
		get
		{
			if (index < 0 || index >= L.Count)
			{
				throw new IndexOutOfRangeException();
			}
			return L[index];
		}
	}

	object IEnumerator.Current => Current;

	public FastListEnumerator(FastList<T> list)
	{
		L = list;
		modCount = list.modifycount;
		index = -1;
	}

	public void Dispose()
	{
	}

	public bool MoveNext()
	{
		ModifyCheck();
		return ++index < L.Count;
	}

	public void Reset()
	{
		ModifyCheck();
		index = -1;
	}

	private void ModifyCheck()
	{
		if (modCount != L.modifycount)
		{
			throw new InvalidOperationException();
		}
	}
}
