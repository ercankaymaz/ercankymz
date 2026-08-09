using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Microsoft.Isam.Esent.Interop;

internal abstract class TableEnumerator<T> : IEnumerator<T>, IEnumerator, IDisposable
{
	private bool isAtEnd;

	private bool moveToFirst = true;

	public T Current { get; private set; }

	object IEnumerator.Current
	{
		[DebuggerStepThrough]
		get
		{
			return Current;
		}
	}

	protected JET_SESID Sesid { get; private set; }

	protected JET_TABLEID TableidToEnumerate { get; set; }

	protected TableEnumerator(JET_SESID sesid)
	{
		Sesid = sesid;
		TableidToEnumerate = JET_TABLEID.Nil;
	}

	public void Reset()
	{
		isAtEnd = false;
		moveToFirst = true;
	}

	public void Dispose()
	{
		CloseTable();
		GC.SuppressFinalize(this);
	}

	public bool MoveNext()
	{
		if (isAtEnd)
		{
			return false;
		}
		if (TableidToEnumerate.IsInvalid)
		{
			OpenTable();
		}
		bool flag = true;
		if (moveToFirst)
		{
			if (!Api.TryMoveFirst(Sesid, TableidToEnumerate))
			{
				isAtEnd = true;
				return false;
			}
			moveToFirst = false;
			flag = false;
		}
		while (flag || SkipCurrent())
		{
			if (!Api.TryMoveNext(Sesid, TableidToEnumerate))
			{
				isAtEnd = true;
				return false;
			}
			flag = false;
		}
		Current = GetCurrent();
		return true;
	}

	protected abstract void OpenTable();

	protected abstract T GetCurrent();

	protected virtual bool SkipCurrent()
	{
		return false;
	}

	protected virtual void CloseTable()
	{
		if (!TableidToEnumerate.IsInvalid)
		{
			Api.JetCloseTable(Sesid, TableidToEnumerate);
		}
		TableidToEnumerate = JET_TABLEID.Nil;
	}
}
