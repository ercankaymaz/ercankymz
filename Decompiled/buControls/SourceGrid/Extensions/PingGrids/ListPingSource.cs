using System;
using System.Collections.Generic;

namespace SourceGrid.Extensions.PingGrids;

public class ListPingSource<T> : List<T>, IPingData
{
	public bool AllowSort
	{
		get
		{
			return true;
		}
		set
		{
		}
	}

	public void ApplySort(string propertyName, bool ascending)
	{
		Sort();
	}

	public object GetItemValue(int index, string propertyName)
	{
		throw new NotImplementedException();
	}
}
