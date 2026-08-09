using System;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public interface IChannelBase
{
	bool UseBinaryEncoding { get; }

	void ScheduleOutgoingRequest(IChannelOutgoingRequest request);

	InvokeServiceResponseMessage InvokeService(InvokeServiceMessage request);

	IAsyncResult BeginInvokeService(InvokeServiceMessage request, AsyncCallback callback, object asyncState);

	InvokeServiceResponseMessage EndInvokeService(IAsyncResult result);
}
