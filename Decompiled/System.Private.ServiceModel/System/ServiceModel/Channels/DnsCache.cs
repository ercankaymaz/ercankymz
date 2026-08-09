using System.Net;
using System.Net.Sockets;
using System.Runtime;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal static class DnsCache
{
	internal class DnsCacheEntry
	{
		private IPAddress[] _addressList;

		public IPAddress[] AddressList => _addressList;

		public DateTime TimeStamp { get; }

		public DnsCacheEntry(IPAddress[] addressList, DateTime timeStamp)
		{
			TimeStamp = timeStamp;
			_addressList = addressList;
		}
	}

	private const int mruWatermark = 64;

	private static MruCache<string, DnsCacheEntry> s_resolveCache = new MruCache<string, DnsCacheEntry>(64);

	private static readonly TimeSpan s_cacheTimeout = TimeSpan.FromSeconds(2.0);

	private static volatile string s_machineName;

	private static object ThisLock => s_resolveCache;

	public static string MachineName
	{
		get
		{
			if (s_machineName == null)
			{
				lock (ThisLock)
				{
					if (s_machineName == null)
					{
						try
						{
							s_machineName = Dns.GetHostEntry(string.Empty).HostName;
						}
						catch (SocketException)
						{
							throw;
						}
					}
				}
			}
			return s_machineName;
		}
	}

	public static async Task<IPAddress[]> ResolveAsync(Uri uri)
	{
		string hostName = uri.DnsSafeHost;
		IPAddress[] hostAddresses = null;
		DateTime now = DateTime.UtcNow;
		lock (ThisLock)
		{
			if (s_resolveCache.TryGetValue(hostName, out var value))
			{
				if (now.Subtract(value.TimeStamp) > s_cacheTimeout)
				{
					s_resolveCache.Remove(hostName);
				}
				else
				{
					if (value.AddressList == null)
					{
						throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new EndpointNotFoundException(System.SR.Format(System.SR.DnsResolveFailed, hostName)));
					}
					hostAddresses = value.AddressList;
				}
			}
		}
		if (hostAddresses == null)
		{
			SocketException dnsException = null;
			try
			{
				hostAddresses = await LookupHostName(hostName);
			}
			catch (SocketException ex)
			{
				dnsException = ex;
			}
			lock (ThisLock)
			{
				s_resolveCache.Remove(hostName);
				s_resolveCache.Add(hostName, new DnsCacheEntry(hostAddresses, now));
			}
			if (dnsException != null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new EndpointNotFoundException(System.SR.Format(System.SR.DnsResolveFailed, hostName), dnsException));
			}
		}
		return hostAddresses;
	}

	internal static async Task<IPAddress[]> LookupHostName(string hostName)
	{
		return (await Dns.GetHostEntryAsync(hostName)).AddressList;
	}
}
