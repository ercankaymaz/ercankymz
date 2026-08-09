using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public class IndexInfo
{
	private readonly string name;

	private readonly CultureInfo cultureInfo;

	private readonly CompareOptions compareOptions;

	private readonly ReadOnlyCollection<IndexSegment> indexSegments;

	private readonly CreateIndexGrbit grbit;

	private readonly int keys;

	private readonly int entries;

	private readonly int pages;

	public string Name
	{
		[DebuggerStepThrough]
		get
		{
			return name;
		}
	}

	public CultureInfo CultureInfo
	{
		[DebuggerStepThrough]
		get
		{
			return cultureInfo;
		}
	}

	public CompareOptions CompareOptions
	{
		[DebuggerStepThrough]
		get
		{
			return compareOptions;
		}
	}

	public IList<IndexSegment> IndexSegments
	{
		[DebuggerStepThrough]
		get
		{
			return indexSegments;
		}
	}

	public CreateIndexGrbit Grbit
	{
		[DebuggerStepThrough]
		get
		{
			return grbit;
		}
	}

	public int Keys
	{
		[DebuggerStepThrough]
		get
		{
			return keys;
		}
	}

	public int Entries
	{
		[DebuggerStepThrough]
		get
		{
			return entries;
		}
	}

	public int Pages
	{
		[DebuggerStepThrough]
		get
		{
			return pages;
		}
	}

	internal IndexInfo(string name, CultureInfo cultureInfo, CompareOptions compareOptions, IndexSegment[] indexSegments, CreateIndexGrbit grbit, int keys, int entries, int pages)
	{
		this.name = name;
		this.cultureInfo = cultureInfo;
		this.compareOptions = compareOptions;
		this.indexSegments = new ReadOnlyCollection<IndexSegment>(indexSegments);
		this.grbit = grbit;
		this.keys = keys;
		this.entries = entries;
		this.pages = pages;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(Name);
		stringBuilder.Append(" (");
		foreach (IndexSegment indexSegment in IndexSegments)
		{
			stringBuilder.Append(indexSegment.ToString());
		}
		stringBuilder.Append(")");
		return stringBuilder.ToString();
	}
}
