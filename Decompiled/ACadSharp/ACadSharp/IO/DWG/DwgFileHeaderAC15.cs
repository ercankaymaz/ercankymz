using System;
using System.Collections.Generic;

namespace ACadSharp.IO.DWG;

internal class DwgFileHeaderAC15 : DwgFileHeader
{
	public static readonly byte[] EndSentinel = new byte[16]
	{
		149, 160, 78, 40, 153, 130, 26, 229, 94, 65,
		224, 95, 157, 58, 77, 0
	};

	public Dictionary<int, DwgSectionLocatorRecord> Records { get; set; } = new Dictionary<int, DwgSectionLocatorRecord>();

	public DwgFileHeaderAC15()
	{
	}

	public DwgFileHeaderAC15(ACadVersion version)
		: base(version)
	{
	}

	public override void AddSection(string name)
	{
		throw new NotImplementedException();
	}

	public override DwgSectionDescriptor GetDescriptor(string name)
	{
		throw new NotImplementedException();
	}
}
