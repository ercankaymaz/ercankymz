using System;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;

namespace buComm.FTP;

public class FTPConnectProperties
{
	public string IP = _009D(107395886);

	public int Port = 21;

	public string UserName = _009D(107393885);

	public string Password = _009D(107397238);

	public string RemoteFolder = _009D(107393876);

	public string RemoteFileName = _009D(107397238);

	public string LocalFileName = _009D(107397238);

	public bool Connected = false;

	public bool Login = false;

	public bool UseRevolveDNS = false;

	[NonSerialized]
	internal static GetString _009D;

	static FTPConnectProperties()
	{
		Strings.CreateGetStringDelegate(typeof(FTPConnectProperties));
	}
}
