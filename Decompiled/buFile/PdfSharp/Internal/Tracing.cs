using System.Diagnostics;

namespace PdfSharp.Internal;

internal class Tracing
{
	[Conditional("DEBUG")]
	public void Foo()
	{
	}
}
