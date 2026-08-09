using System.Collections.ObjectModel;

namespace System.ServiceModel.Channels;

public class ChannelParameterCollection : Collection<object>
{
	private IChannel _channel;

	protected virtual IChannel Channel => _channel;

	public ChannelParameterCollection()
	{
	}

	public ChannelParameterCollection(IChannel channel)
	{
		_channel = channel;
	}

	public void PropagateChannelParameters(IChannel innerChannel)
	{
		if (innerChannel == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("innerChannel");
		}
		ThrowIfMutable();
		ChannelParameterCollection property = innerChannel.GetProperty<ChannelParameterCollection>();
		if (property != null)
		{
			for (int i = 0; i < base.Count; i++)
			{
				property.Add(base[i]);
			}
		}
	}

	protected override void ClearItems()
	{
		ThrowIfDisposedOrImmutable();
		base.ClearItems();
	}

	protected override void InsertItem(int index, object item)
	{
		ThrowIfDisposedOrImmutable();
		base.InsertItem(index, item);
	}

	protected override void RemoveItem(int index)
	{
		ThrowIfDisposedOrImmutable();
		base.RemoveItem(index);
	}

	protected override void SetItem(int index, object item)
	{
		ThrowIfDisposedOrImmutable();
		base.SetItem(index, item);
	}

	private void ThrowIfDisposedOrImmutable()
	{
		IChannel channel = Channel;
		if (channel != null)
		{
			CommunicationState state = channel.State;
			string text = null;
			switch (state)
			{
			case CommunicationState.Opening:
			case CommunicationState.Opened:
			case CommunicationState.Closing:
			case CommunicationState.Closed:
			case CommunicationState.Faulted:
				text = System.SR.Format(System.SR.ChannelParametersCannotBeModified, channel.GetType().ToString(), state.ToString());
				break;
			default:
				text = System.SR.Format(System.SR.CommunicationObjectInInvalidState, channel.GetType().ToString(), state.ToString());
				break;
			case CommunicationState.Created:
				break;
			}
			if (text != null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(text));
			}
		}
	}

	private void ThrowIfMutable()
	{
		IChannel channel = Channel;
		if (channel != null)
		{
			CommunicationState state = channel.State;
			string text = null;
			switch (state)
			{
			case CommunicationState.Created:
				text = System.SR.Format(System.SR.ChannelParametersCannotBePropagated, channel.GetType().ToString(), state.ToString());
				break;
			default:
				text = System.SR.Format(System.SR.CommunicationObjectInInvalidState, channel.GetType().ToString(), state.ToString());
				break;
			case CommunicationState.Opening:
			case CommunicationState.Opened:
			case CommunicationState.Closing:
			case CommunicationState.Closed:
			case CommunicationState.Faulted:
				break;
			}
			if (text != null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(text));
			}
		}
	}
}
