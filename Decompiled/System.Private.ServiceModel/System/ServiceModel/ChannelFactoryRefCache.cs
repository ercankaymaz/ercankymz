using System.Collections.Generic;
using System.Runtime;

namespace System.ServiceModel;

internal class ChannelFactoryRefCache<TChannel> : MruCache<EndpointTrait<TChannel>, ChannelFactoryRef<TChannel>> where TChannel : class
{
	private class EndpointTraitComparer : IEqualityComparer<EndpointTrait<TChannel>>
	{
		public bool Equals(EndpointTrait<TChannel> x, EndpointTrait<TChannel> y)
		{
			if (x != null)
			{
				if (y != null)
				{
					return x.Equals(y);
				}
				return false;
			}
			if (y != null)
			{
				return false;
			}
			return true;
		}

		public int GetHashCode(EndpointTrait<TChannel> obj)
		{
			return obj?.GetHashCode() ?? 0;
		}
	}

	private static EndpointTraitComparer DefaultEndpointTraitComparer = new EndpointTraitComparer();

	private readonly int _watermark;

	public ChannelFactoryRefCache(int watermark)
		: base(watermark * 4 / 5, watermark, (IEqualityComparer<EndpointTrait<TChannel>>)DefaultEndpointTraitComparer)
	{
		_watermark = watermark;
	}

	protected override void OnSingleItemRemoved(ChannelFactoryRef<TChannel> item)
	{
		if (item.Release())
		{
			item.Abort();
		}
		if (WcfEventSource.Instance.ClientBaseCachedChannelFactoryCountIsEnabled())
		{
			WcfEventSource.Instance.ClientBaseCachedChannelFactoryCount(base.Count, _watermark, this);
		}
	}

	protected override void OnItemAgedOutOfCache(ChannelFactoryRef<TChannel> item)
	{
		if (WcfEventSource.Instance.ClientBaseChannelFactoryAgedOutofCacheIsEnabled())
		{
			WcfEventSource.Instance.ClientBaseChannelFactoryAgedOutofCache(_watermark, this);
		}
	}
}
