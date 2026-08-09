using System;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public interface IJsonEncoder : IEncoder, IDisposable
{
	bool ForceNamespaceUri { get; set; }

	void PushArray(string fieldName);

	void PushStructure(string fieldName);

	void PopArray();

	void PopStructure();

	void UsingReversibleEncoding<T>(Action<string, T> action, string fieldName, T value, bool useReversibleEncoding);
}
