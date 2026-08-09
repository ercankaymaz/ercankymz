using System.Collections.Generic;
using System.Linq;

namespace ACadSharp.XData;

public class ExtendedData
{
	public List<ExtendedDataRecord> Records { get; } = new List<ExtendedDataRecord>();

	public ExtendedData()
	{
	}

	public ExtendedData(IEnumerable<ExtendedDataRecord> records)
		: this()
	{
		Records.AddRange(records);
	}

	public void AddControlStrings()
	{
		if (!Records.Any())
		{
			Records.Add(ExtendedDataControlString.Open);
			Records.Add(ExtendedDataControlString.Close);
			return;
		}
		if (!(Records.First() is ExtendedDataControlString extendedDataControlString))
		{
			Records.Insert(0, ExtendedDataControlString.Open);
		}
		else if (extendedDataControlString.IsClosing)
		{
			Records.Insert(0, ExtendedDataControlString.Open);
		}
		if (!(Records.Last() is ExtendedDataControlString extendedDataControlString2))
		{
			Records.Add(ExtendedDataControlString.Close);
		}
		else if (!extendedDataControlString2.IsClosing)
		{
			Records.Add(ExtendedDataControlString.Close);
		}
	}
}
