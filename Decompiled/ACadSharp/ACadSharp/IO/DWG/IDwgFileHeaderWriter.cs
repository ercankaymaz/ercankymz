using System.IO;

namespace ACadSharp.IO.DWG;

internal interface IDwgFileHeaderWriter
{
	int HandleSectionOffset { get; }

	void AddSection(string name, MemoryStream stream, bool isCompressed, int decompsize = 29696);

	void WriteFile();
}
