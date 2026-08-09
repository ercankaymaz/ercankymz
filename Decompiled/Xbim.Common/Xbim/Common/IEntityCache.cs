using System;

namespace Xbim.Common;

public interface IEntityCache : IDisposable
{
	int Size { get; }

	bool IsActive { get; }

	void Clear();

	void Stop();

	void Start();
}
