using System.Security.Authentication.ExtendedProtection;

namespace System.ServiceModel.Channels;

internal sealed class ChannelBindingMessageProperty : IDisposable, IMessageProperty
{
	private const string propertyName = "ChannelBindingMessageProperty";

	private ChannelBinding _channelBinding;

	private object _thisLock;

	private bool _ownsCleanup;

	private int _refCount;

	public static string Name => "ChannelBindingMessageProperty";

	private bool IsDisposed => _refCount <= 0;

	public ChannelBinding ChannelBinding
	{
		get
		{
			ThrowIfDisposed();
			return _channelBinding;
		}
	}

	public ChannelBindingMessageProperty(ChannelBinding channelBinding, bool ownsCleanup)
	{
		_refCount = 1;
		_thisLock = new object();
		_channelBinding = channelBinding ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("channelBinding");
		_ownsCleanup = ownsCleanup;
	}

	public static bool TryGet(Message message, out ChannelBindingMessageProperty property)
	{
		if (message == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("message");
		}
		return TryGet(message.Properties, out property);
	}

	public static bool TryGet(MessageProperties properties, out ChannelBindingMessageProperty property)
	{
		if (properties == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("properties");
		}
		property = null;
		if (properties.TryGetValue(Name, out var value))
		{
			property = value as ChannelBindingMessageProperty;
			return property != null;
		}
		return false;
	}

	public void AddTo(Message message)
	{
		if (message == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("message");
		}
		AddTo(message.Properties);
	}

	public void AddTo(MessageProperties properties)
	{
		ThrowIfDisposed();
		if (properties == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("properties");
		}
		properties.Add(Name, this);
	}

	public IMessageProperty CreateCopy()
	{
		lock (_thisLock)
		{
			ThrowIfDisposed();
			_refCount++;
			return this;
		}
	}

	public void Dispose()
	{
		if (IsDisposed)
		{
			return;
		}
		lock (_thisLock)
		{
			if (!IsDisposed && --_refCount == 0 && _ownsCleanup)
			{
				((IDisposable)_channelBinding).Dispose();
			}
		}
	}

	private void ThrowIfDisposed()
	{
		if (IsDisposed)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ObjectDisposedException(GetType().FullName));
		}
	}
}
