using System;
using System.Collections.Generic;

namespace ACadSharp.IO.DWG;

internal class DwgSectionDescriptor
{
	private int _compressed = 2;

	public long PageType { get; } = 1097008187L;

	public string Name { get; set; }

	public ulong CompressedSize { get; set; }

	public int PageCount { get; set; }

	public ulong DecompressedSize { get; set; } = 29696uL;

	public int CompressedCode
	{
		get
		{
			return _compressed;
		}
		set
		{
			if (value != 1 && value != 2)
			{
				throw new Exception();
			}
			_compressed = value;
		}
	}

	public bool IsCompressed => _compressed == 2;

	public int SectionId { get; set; }

	public int Encrypted { get; set; }

	public ulong? HashCode { get; internal set; }

	public ulong? Encoding { get; internal set; }

	public List<DwgLocalSectionMap> LocalSections { get; set; } = new List<DwgLocalSectionMap>();

	public DwgSectionDescriptor()
	{
	}

	public DwgSectionDescriptor(string name)
	{
		Name = name;
	}
}
