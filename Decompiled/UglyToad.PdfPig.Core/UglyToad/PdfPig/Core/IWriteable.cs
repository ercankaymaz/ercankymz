using System.IO;

namespace UglyToad.PdfPig.Core;

public interface IWriteable
{
	void Write(Stream stream);
}
