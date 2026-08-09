using System;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public interface IJsonDecoder : IDecoder, IDisposable
{
	bool PushStructure(string fieldName);

	bool PushArray(string fieldName, int index);

	void Pop();

	bool ReadField(string fieldName, out object token);
}
