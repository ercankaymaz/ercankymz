using System.ServiceModel.Channels;

namespace System.ServiceModel.Dispatcher;

internal static class ListenerBinder
{
	internal class DuplexListenerBinder : IListenerBinder
	{
		private IRequestReplyCorrelator _correlator;

		private IChannelListener<IDuplexChannel> _listener;

		public IChannelListener Listener => _listener;

		public MessageVersion MessageVersion { get; }

		internal DuplexListenerBinder(IChannelListener<IDuplexChannel> listener, MessageVersion messageVersion)
		{
			_correlator = new RequestReplyCorrelator();
			_listener = listener;
			MessageVersion = messageVersion;
		}

		public IChannelBinder Accept(TimeSpan timeout)
		{
			IDuplexChannel duplexChannel = _listener.AcceptChannel(timeout);
			if (duplexChannel == null)
			{
				return null;
			}
			return new DuplexChannelBinder(duplexChannel, _correlator, _listener.Uri);
		}

		public IAsyncResult BeginAccept(TimeSpan timeout, AsyncCallback callback, object state)
		{
			return _listener.BeginAcceptChannel(timeout, callback, state);
		}

		public IChannelBinder EndAccept(IAsyncResult result)
		{
			IDuplexChannel duplexChannel = _listener.EndAcceptChannel(result);
			if (duplexChannel == null)
			{
				return null;
			}
			return new DuplexChannelBinder(duplexChannel, _correlator, _listener.Uri);
		}
	}

	internal class DuplexSessionListenerBinder : IListenerBinder
	{
		private IRequestReplyCorrelator _correlator;

		private IChannelListener<IDuplexSessionChannel> _listener;

		public IChannelListener Listener => _listener;

		public MessageVersion MessageVersion { get; }

		internal DuplexSessionListenerBinder(IChannelListener<IDuplexSessionChannel> listener, MessageVersion messageVersion)
		{
			_correlator = new RequestReplyCorrelator();
			_listener = listener;
			MessageVersion = messageVersion;
		}

		public IChannelBinder Accept(TimeSpan timeout)
		{
			IDuplexSessionChannel duplexSessionChannel = _listener.AcceptChannel(timeout);
			if (duplexSessionChannel == null)
			{
				return null;
			}
			return new DuplexChannelBinder(duplexSessionChannel, _correlator, _listener.Uri);
		}

		public IAsyncResult BeginAccept(TimeSpan timeout, AsyncCallback callback, object state)
		{
			return _listener.BeginAcceptChannel(timeout, callback, state);
		}

		public IChannelBinder EndAccept(IAsyncResult result)
		{
			IDuplexSessionChannel duplexSessionChannel = _listener.EndAcceptChannel(result);
			if (duplexSessionChannel == null)
			{
				return null;
			}
			return new DuplexChannelBinder(duplexSessionChannel, _correlator, _listener.Uri);
		}
	}

	internal class InputListenerBinder : IListenerBinder
	{
		private IChannelListener<IInputChannel> _listener;

		public IChannelListener Listener => _listener;

		public MessageVersion MessageVersion { get; }

		internal InputListenerBinder(IChannelListener<IInputChannel> listener, MessageVersion messageVersion)
		{
			_listener = listener;
			MessageVersion = messageVersion;
		}

		public IChannelBinder Accept(TimeSpan timeout)
		{
			IInputChannel inputChannel = _listener.AcceptChannel(timeout);
			if (inputChannel == null)
			{
				return null;
			}
			return new InputChannelBinder(inputChannel, _listener.Uri);
		}

		public IAsyncResult BeginAccept(TimeSpan timeout, AsyncCallback callback, object state)
		{
			return _listener.BeginAcceptChannel(timeout, callback, state);
		}

		public IChannelBinder EndAccept(IAsyncResult result)
		{
			IInputChannel inputChannel = _listener.EndAcceptChannel(result);
			if (inputChannel == null)
			{
				return null;
			}
			return new InputChannelBinder(inputChannel, _listener.Uri);
		}
	}

	internal class InputSessionListenerBinder : IListenerBinder
	{
		private IChannelListener<IInputSessionChannel> _listener;

		public IChannelListener Listener => _listener;

		public MessageVersion MessageVersion { get; }

		internal InputSessionListenerBinder(IChannelListener<IInputSessionChannel> listener, MessageVersion messageVersion)
		{
			_listener = listener;
			MessageVersion = messageVersion;
		}

		public IChannelBinder Accept(TimeSpan timeout)
		{
			IInputSessionChannel inputSessionChannel = _listener.AcceptChannel(timeout);
			if (inputSessionChannel == null)
			{
				return null;
			}
			return new InputChannelBinder(inputSessionChannel, _listener.Uri);
		}

		public IAsyncResult BeginAccept(TimeSpan timeout, AsyncCallback callback, object state)
		{
			return _listener.BeginAcceptChannel(timeout, callback, state);
		}

		public IChannelBinder EndAccept(IAsyncResult result)
		{
			IInputSessionChannel inputSessionChannel = _listener.EndAcceptChannel(result);
			if (inputSessionChannel == null)
			{
				return null;
			}
			return new InputChannelBinder(inputSessionChannel, _listener.Uri);
		}
	}

	internal class ReplyListenerBinder : IListenerBinder
	{
		private IChannelListener<IReplyChannel> _listener;

		public IChannelListener Listener => _listener;

		public MessageVersion MessageVersion { get; }

		internal ReplyListenerBinder(IChannelListener<IReplyChannel> listener, MessageVersion messageVersion)
		{
			_listener = listener;
			MessageVersion = messageVersion;
		}

		public IChannelBinder Accept(TimeSpan timeout)
		{
			IReplyChannel replyChannel = _listener.AcceptChannel(timeout);
			if (replyChannel == null)
			{
				return null;
			}
			return new ReplyChannelBinder(replyChannel, _listener.Uri);
		}

		public IAsyncResult BeginAccept(TimeSpan timeout, AsyncCallback callback, object state)
		{
			return _listener.BeginAcceptChannel(timeout, callback, state);
		}

		public IChannelBinder EndAccept(IAsyncResult result)
		{
			IReplyChannel replyChannel = _listener.EndAcceptChannel(result);
			if (replyChannel == null)
			{
				return null;
			}
			return new ReplyChannelBinder(replyChannel, _listener.Uri);
		}
	}

	internal class ReplySessionListenerBinder : IListenerBinder
	{
		private IChannelListener<IReplySessionChannel> _listener;

		public IChannelListener Listener => _listener;

		public MessageVersion MessageVersion { get; }

		internal ReplySessionListenerBinder(IChannelListener<IReplySessionChannel> listener, MessageVersion messageVersion)
		{
			_listener = listener;
			MessageVersion = messageVersion;
		}

		public IChannelBinder Accept(TimeSpan timeout)
		{
			IReplySessionChannel replySessionChannel = _listener.AcceptChannel(timeout);
			if (replySessionChannel == null)
			{
				return null;
			}
			return new ReplyChannelBinder(replySessionChannel, _listener.Uri);
		}

		public IAsyncResult BeginAccept(TimeSpan timeout, AsyncCallback callback, object state)
		{
			return _listener.BeginAcceptChannel(timeout, callback, state);
		}

		public IChannelBinder EndAccept(IAsyncResult result)
		{
			IReplySessionChannel replySessionChannel = _listener.EndAcceptChannel(result);
			if (replySessionChannel == null)
			{
				return null;
			}
			return new ReplyChannelBinder(replySessionChannel, _listener.Uri);
		}
	}

	internal static IListenerBinder GetBinder(IChannelListener listener, MessageVersion messageVersion)
	{
		if (listener is IChannelListener<IInputChannel> listener2)
		{
			return new InputListenerBinder(listener2, messageVersion);
		}
		if (listener is IChannelListener<IInputSessionChannel> listener3)
		{
			return new InputSessionListenerBinder(listener3, messageVersion);
		}
		if (listener is IChannelListener<IReplyChannel> listener4)
		{
			return new ReplyListenerBinder(listener4, messageVersion);
		}
		if (listener is IChannelListener<IReplySessionChannel> listener5)
		{
			return new ReplySessionListenerBinder(listener5, messageVersion);
		}
		if (listener is IChannelListener<IDuplexChannel> listener6)
		{
			return new DuplexListenerBinder(listener6, messageVersion);
		}
		if (listener is IChannelListener<IDuplexSessionChannel> listener7)
		{
			return new DuplexSessionListenerBinder(listener7, messageVersion);
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.UnknownListenerType1, listener.Uri.AbsoluteUri)));
	}
}
