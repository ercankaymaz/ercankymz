using System;
using System.Collections;

namespace Basler.Pylon;

public interface IDataContainer : IDisposable, IEnumerable
{
	IDataComponent this[int index] { get; }

	int Count { get; }

	new IEnumerator GetEnumerator();

	void Save(string filename);

	void Load(string filename);
}
