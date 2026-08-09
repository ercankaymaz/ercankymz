using System;
using System.IO;

namespace Microsoft.Windows.Design.Services;

public abstract class BinaryResource
{
	public abstract Uri FileUri { get; }

	public abstract Uri StreamUri { get; }

	public abstract bool IsResourceValid { get; }

	public abstract event EventHandler Changed;

	public abstract Stream OpenStream(FileAccess access);
}
