using System;
using System.Collections;
using System.Collections.Generic;

namespace Xbim.IO.Esent;

internal class XbimInstancesLabelEnumerator : IEnumerator<int>, IEnumerator, IDisposable
{
	private PersistedEntityInstanceCache cache;

	private EsentEntityCursor cursor;

	private int current;

	public int Current => current;

	object IEnumerator.Current => current;

	public XbimInstancesLabelEnumerator(PersistedEntityInstanceCache cache)
	{
		this.cache = cache;
		cursor = cache.GetEntityTable();
		Reset();
	}

	public void Reset()
	{
		cursor.MoveBeforeFirst();
		current = 0;
	}

	bool IEnumerator.MoveNext()
	{
		if (cursor.TryMoveNextLabel(out var label))
		{
			current = label;
			return true;
		}
		return false;
	}

	public void Dispose()
	{
		cache.FreeTable(cursor);
	}
}
