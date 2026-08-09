using System;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public interface INodeBrowser : IDisposable
{
	IReference Next();

	void Push(IReference reference);
}
