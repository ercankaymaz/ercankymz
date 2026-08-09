using System;
using System.IO;

namespace SharpDX.D3DCompiler;

[Shadow(typeof(IncludeShadow))]
public interface Include : ICallbackable, IDisposable
{
	Stream Open(IncludeType type, string fileName, Stream parentStream);

	void Close(Stream stream);
}
