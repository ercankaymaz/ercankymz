using System;

namespace Xbim.Common;

public interface IInverseCache : IDisposable
{
	int Size { get; }

	bool IsDisposed { get; }

	void Clear();
}
