using System.Runtime;
using System.ServiceModel.Channels.ConnectionHelpers;
using System.ServiceModel.Security;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal abstract class FramingDuplexSessionChannel : TransportDuplexSessionChannel
{
	internal class FramingConnectionDuplexSession : ConnectionDuplexSession
	{
		private class SecureConnectionDuplexSession : FramingConnectionDuplexSession, ISecuritySession, ISession
		{
			private EndpointIdentity _remoteIdentity;

			EndpointIdentity ISecuritySession.RemoteIdentity
			{
				get
				{
					if (_remoteIdentity == null)
					{
						SecurityMessageProperty remoteSecurity = base.Channel.RemoteSecurity;
						if (remoteSecurity != null && remoteSecurity.ServiceSecurityContext != null && remoteSecurity.ServiceSecurityContext.IdentityClaim != null && remoteSecurity.ServiceSecurityContext.PrimaryIdentity != null)
						{
							_remoteIdentity = EndpointIdentity.CreateIdentity(remoteSecurity.ServiceSecurityContext.IdentityClaim);
						}
					}
					return _remoteIdentity;
				}
			}

			public SecureConnectionDuplexSession(FramingDuplexSessionChannel channel)
				: base(channel)
			{
			}
		}

		private FramingConnectionDuplexSession(FramingDuplexSessionChannel channel)
			: base(channel)
		{
		}

		public static FramingConnectionDuplexSession CreateSession(FramingDuplexSessionChannel channel, StreamUpgradeProvider upgrade)
		{
			if (!(upgrade is StreamSecurityUpgradeProvider))
			{
				return new FramingConnectionDuplexSession(channel);
			}
			return new SecureConnectionDuplexSession(channel);
		}
	}

	private static EndpointAddress s_anonymousEndpointAddress = new EndpointAddress(EndpointAddress.AnonymousUri);

	private bool _exposeConnectionProperty;

	protected IConnection Connection { get; set; }

	protected override bool IsStreamedOutput => false;

	private FramingDuplexSessionChannel(ChannelManagerBase manager, IConnectionOrientedTransportFactorySettings settings, EndpointAddress localAddress, Uri localVia, EndpointAddress remoteAddress, Uri via, bool exposeConnectionProperty)
		: base(manager, settings, localAddress, localVia, remoteAddress, via)
	{
		_exposeConnectionProperty = exposeConnectionProperty;
	}

	protected FramingDuplexSessionChannel(ChannelManagerBase factory, IConnectionOrientedTransportFactorySettings settings, EndpointAddress remoteAddress, Uri via, bool exposeConnectionProperty)
		: this(factory, settings, s_anonymousEndpointAddress, (settings.MessageVersion.Addressing == AddressingVersion.None) ? null : new Uri("http://www.w3.org/2005/08/addressing/anonymous"), remoteAddress, via, exposeConnectionProperty)
	{
		base.Session = FramingConnectionDuplexSession.CreateSession(this, settings.Upgrade);
	}

	protected override void CloseOutputSessionCore(TimeSpan timeout)
	{
		Connection.Write(SessionEncoder.EndBytes, 0, SessionEncoder.EndBytes.Length, immediate: true, timeout);
	}

	protected override Task CloseOutputSessionCoreAsync(TimeSpan timeout)
	{
		return Connection.WriteAsync(SessionEncoder.EndBytes, 0, SessionEncoder.EndBytes.Length, immediate: true, timeout);
	}

	protected override void CompleteClose(TimeSpan timeout)
	{
		ReturnConnectionIfNecessary(abort: false, timeout);
	}

	protected override void PrepareMessage(Message message)
	{
		if (_exposeConnectionProperty)
		{
			message.Properties[ConnectionMessageProperty.Name] = Connection;
		}
		base.PrepareMessage(message);
	}

	protected override void OnSendCore(Message message, TimeSpan timeout)
	{
		bool allowOutputBatching = message.Properties.AllowOutputBatching;
		ArraySegment<byte> arraySegment = EncodeMessage(message);
		Connection.Write(arraySegment.Array, arraySegment.Offset, arraySegment.Count, !allowOutputBatching, timeout, base.BufferManager);
	}

	protected override AsyncCompletionResult BeginCloseOutput(TimeSpan timeout, Action<object> callback, object state)
	{
		return Connection.BeginWrite(SessionEncoder.EndBytes, 0, SessionEncoder.EndBytes.Length, immediate: true, timeout, callback, state);
	}

	protected override void FinishWritingMessage()
	{
		Connection.EndWrite();
	}

	protected override AsyncCompletionResult StartWritingBufferedMessage(Message message, ArraySegment<byte> messageData, bool allowOutputBatching, TimeSpan timeout, Action<object> callback, object state)
	{
		return Connection.BeginWrite(messageData.Array, messageData.Offset, messageData.Count, !allowOutputBatching, timeout, callback, state);
	}

	protected override AsyncCompletionResult StartWritingStreamedMessage(Message message, TimeSpan timeout, Action<object> callback, object state)
	{
		throw new InvalidOperationException();
	}

	protected override ArraySegment<byte> EncodeMessage(Message message)
	{
		ArraySegment<byte> messageFrame = base.MessageEncoder.WriteMessage(message, int.MaxValue, base.BufferManager, 6);
		return SessionEncoder.EncodeMessageFrame(messageFrame);
	}
}
