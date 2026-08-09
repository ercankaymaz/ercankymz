using System;

namespace SourceGrid.Extensions.PingGrids;

public class EmptyPingSource : IPingData
{
	public int Count
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public bool AllowSort
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public object GetItemValue(int index, string propertyName)
	{
		throw new NotImplementedException();
	}

	public void ApplySort(string propertyName, bool ascending)
	{
		throw new NotImplementedException();
	}
}
