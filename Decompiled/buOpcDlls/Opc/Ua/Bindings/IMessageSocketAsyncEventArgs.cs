using System;
using System.Runtime.InteropServices;

namespace Opc.Ua.Bindings;

[ComVisible(true)]
public interface IMessageSocketAsyncEventArgs : IDisposable
{
	byte[] Buffer { get; }

	BufferCollection BufferList { get; set; }

	int BytesTransferred { get; }

	bool IsSocketError { get; }

	string SocketErrorString { get; }

	object UserToken { get; set; }

	event EventHandler<IMessageSocketAsyncEventArgs> Completed;

	void SetBuffer(byte[] buffer, int offset, int count);
}
