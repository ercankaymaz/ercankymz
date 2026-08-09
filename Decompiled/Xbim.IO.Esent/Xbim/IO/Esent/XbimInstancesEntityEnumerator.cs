using System;
using System.Collections;
using System.Collections.Generic;
using Xbim.Common;

namespace Xbim.IO.Esent;

internal class XbimInstancesEntityEnumerator : IEnumerator<IPersistEntity>, IEnumerator, IDisposable
{
	private PersistedEntityInstanceCache cache;

	private EsentEntityCursor cursor;

	private int current;

	public IPersistEntity Current => cache.GetInstance(current);

	object IEnumerator.Current => cache.GetInstance(current);

	public XbimInstancesEntityEnumerator(PersistedEntityInstanceCache cache)
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
		if (!cursor.TryMoveNextLabel(out var label))
		{
			return false;
		}
		current = label;
		return true;
	}

	public void Dispose()
	{
		cache.FreeTable(cursor);
	}
}
