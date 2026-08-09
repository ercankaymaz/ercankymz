using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Opc.Ua.Bindings;

[ComVisible(true)]
public class TcpReverseConnectChannel : TcpListenerChannel
{
	public override string ChannelName => "TCPREVERSECONNECTCHANNEL";

	public TcpReverseConnectChannel(string contextId, ITcpChannelListener listener, BufferManager bufferManager, ChannelQuotas quotas, EndpointDescriptionCollection endpoints)
		: base(contextId, listener, bufferManager, quotas, null, null, endpoints)
	{
	}

	protected override bool HandleIncomingMessage(uint messageType, ArraySegment<byte> messageChunk)
	{
		lock (base.DataLock)
		{
			SetResponseRequired(responseRequired: true);
			try
			{
				if (messageType == 1178945618)
				{
					Utils.LogInfo("ChannelId {0}: ProcessReverseHelloMessage", base.ChannelId);
					return ProcessReverseHelloMessage(messageType, messageChunk);
				}
				ForceChannelFault(2155741184u, "The reverse connect handler does not recognize the message type: {0:X8}.", messageType);
				return false;
			}
			finally
			{
				SetResponseRequired(responseRequired: false);
			}
		}
	}

	private bool ProcessReverseHelloMessage(uint messageType, ArraySegment<byte> messageChunk)
	{
		if (base.State != TcpChannelState.Connecting)
		{
			ForceChannelFault(2155741184u, "Client sent an unexpected ReverseHello message.");
			return false;
		}
		try
		{
			MemoryStream memoryStream = new MemoryStream(messageChunk.Array, messageChunk.Offset, messageChunk.Count, writable: false);
			BinaryDecoder binaryDecoder = new BinaryDecoder(memoryStream, base.Quotas.MessageContext);
			memoryStream.Seek(8L, SeekOrigin.Current);
			string serverUri = binaryDecoder.ReadString(null);
			string uriString = binaryDecoder.ReadString(null);
			Uri endpointUri = new Uri(uriString);
			base.State = TcpChannelState.Connecting;
			Task.Run(async delegate
			{
				try
				{
					if (!(await base.Listener.TransferListenerChannel(base.Id, serverUri, endpointUri).ConfigureAwait(continueOnCapturedContext: false)))
					{
						SetResponseRequired(responseRequired: true);
						ForceChannelFault(2155741184u, "The reverse connection was rejected by the client.");
					}
					else
					{
						CleanupTimer();
					}
				}
				catch (Exception)
				{
					SetResponseRequired(responseRequired: true);
					ForceChannelFault(2147614720u, "Internal error approving the reverse connection.");
				}
			});
		}
		catch (Exception exception)
		{
			ForceChannelFault(exception, 2156003328u, "Unexpected error while processing a ReverseHello message.");
		}
		return false;
	}
}
