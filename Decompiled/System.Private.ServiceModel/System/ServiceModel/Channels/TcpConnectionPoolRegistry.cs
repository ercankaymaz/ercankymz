using System.Globalization;

namespace System.ServiceModel.Channels;

internal class TcpConnectionPoolRegistry : ConnectionPoolRegistry
{
	private class TcpConnectionPool : ConnectionPool
	{
		public TcpConnectionPool(ITcpChannelFactorySettings settings)
			: base(settings, settings.LeaseTimeout)
		{
		}

		protected override string GetPoolKey(EndpointAddress address, Uri via)
		{
			int num = via.Port;
			if (num == -1)
			{
				num = 808;
			}
			string arg = via.DnsSafeHost.ToUpperInvariant();
			return string.Format(CultureInfo.InvariantCulture, "[{0}, {1}]", arg, num);
		}

		public override bool IsCompatible(IConnectionOrientedTransportChannelFactorySettings settings)
		{
			ITcpChannelFactorySettings tcpChannelFactorySettings = (ITcpChannelFactorySettings)settings;
			if (base.LeaseTimeout == tcpChannelFactorySettings.LeaseTimeout)
			{
				return base.IsCompatible(settings);
			}
			return false;
		}
	}

	protected override ConnectionPool CreatePool(IConnectionOrientedTransportChannelFactorySettings settings)
	{
		ITcpChannelFactorySettings settings2 = (ITcpChannelFactorySettings)settings;
		return new TcpConnectionPool(settings2);
	}
}
