using System.Collections.Generic;
using System.ServiceModel.Channels;

namespace System.ServiceModel.Dispatcher;

internal class SynchronizedChannelCollection<TChannel> : SynchronizedCollection<TChannel> where TChannel : IChannel
{
	private EventHandler _onChannelClosed;

	private EventHandler _onChannelFaulted;

	internal SynchronizedChannelCollection(object syncRoot)
		: base(syncRoot)
	{
		_onChannelClosed = OnChannelClosed;
		_onChannelFaulted = OnChannelFaulted;
	}

	private void AddingChannel(TChannel channel)
	{
		EventHandler onChannelFaulted = _onChannelFaulted;
		channel.Faulted += onChannelFaulted;
		EventHandler onChannelClosed = _onChannelClosed;
		channel.Closed += onChannelClosed;
	}

	private void RemovingChannel(TChannel channel)
	{
		EventHandler onChannelFaulted = _onChannelFaulted;
		channel.Faulted -= onChannelFaulted;
		EventHandler onChannelClosed = _onChannelClosed;
		channel.Closed -= onChannelClosed;
	}

	private void OnChannelClosed(object sender, EventArgs args)
	{
		TChannel item = (TChannel)sender;
		Remove(item);
	}

	private void OnChannelFaulted(object sender, EventArgs args)
	{
		TChannel item = (TChannel)sender;
		Remove(item);
	}

	protected override void ClearItems()
	{
		List<TChannel> items = base.Items;
		for (int i = 0; i < items.Count; i++)
		{
			RemovingChannel(items[i]);
		}
		base.ClearItems();
	}

	protected override void InsertItem(int index, TChannel item)
	{
		AddingChannel(item);
		base.InsertItem(index, item);
	}

	protected override void RemoveItem(int index)
	{
		TChannel channel = base.Items[index];
		base.RemoveItem(index);
		RemovingChannel(channel);
	}

	protected override void SetItem(int index, TChannel item)
	{
		TChannel channel = base.Items[index];
		AddingChannel(item);
		base.SetItem(index, item);
		RemovingChannel(channel);
	}
}
