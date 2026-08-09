using System;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;

namespace buComm.FTP;

public class FTPConnect
{
	public FTPClient ftpClient = null;

	public static FTPConnectProperties ftpConnectionProperties;

	public static int TotalLineCount;

	public static int SentLineCount;

	public static double SendPersentage;

	[NonSerialized]
	internal static GetString _0082;

	public void FtpClientConnect()
	{
		try
		{
			ftpClient = new FTPClient(ftpConnectionProperties.IP);
			ftpConnectionProperties.Connected = false;
			ftpConnectionProperties.Connected = ftpClient.Login(ftpConnectionProperties.UserName, ftpConnectionProperties.Password);
		}
		catch (Exception ex)
		{
			ftpConnectionProperties.Connected = false;
			_0082_0002._0013_0003(_0082(107397227), _0082(107394581), global::_0005._007E_0012(_0081_0002._0012_0003()));
			do
			{
				_008F._0014_0002(ex, global::_0005._007E_0012(_0081_0002._0012_0003()), false, _0082(107397227));
			}
			while (-1 == 0);
		}
	}

	public void FtpClientDisConnect()
	{
		try
		{
			bool num = ftpClient != null;
			if (true)
			{
				bool flag = num;
				if (-1 == 0)
				{
					return;
				}
				num = flag;
			}
			if (num)
			{
				if (3u != 0)
				{
					ftpClient.Quit();
					ftpConnectionProperties.Connected = false;
				}
				if (false)
				{
				}
			}
		}
		catch (Exception ex)
		{
			if (7u != 0)
			{
				ftpConnectionProperties.Connected = false;
				_0082_0002._0013_0003(_0082(107397227), _0082(107394581), global::_0005._007E_0012(_0081_0002._0012_0003()));
			}
			do
			{
				_008F._0014_0002(ex, global::_0005._007E_0012(_0081_0002._0012_0003()), false, _0082(107397227));
			}
			while (5 == 0);
		}
	}

	public bool FtpClientFileTransfer(string FileName, string RemoteFileName)
	{
		bool result;
		do
		{
			try
			{
				SentLineCount = 0;
				if (ftpClient != null)
				{
					ftpClient.Put(FileName, RemoteFileName);
					result = true;
				}
				else
				{
					result = false;
				}
			}
			catch (Exception ex)
			{
				_0082_0002._0013_0003(_0082(107397227), _0082(107394581), global::_0005._007E_0012(_0081_0002._0012_0003()));
				_008F._0014_0002(ex, global::_0005._007E_0012(_0081_0002._0012_0003()), false, _0082(107397227));
				result = false;
			}
		}
		while (4 == 0);
		return result;
	}

	public bool FtpClientFileRecieve(string FileName, string RemoteFileName)
	{
		bool result;
		do
		{
			try
			{
				SentLineCount = 0;
				if (ftpClient != null)
				{
					ftpClient.Get(FileName, RemoteFileName);
					result = true;
				}
				else
				{
					result = false;
				}
			}
			catch (Exception ex)
			{
				_0082_0002._0013_0003(_0082(107397227), _0082(107394581), global::_0005._007E_0012(_0081_0002._0012_0003()));
				_008F._0014_0002(ex, global::_0005._007E_0012(_0081_0002._0012_0003()), false, _0082(107397227));
				result = false;
			}
		}
		while (4 == 0);
		return result;
	}

	static FTPConnect()
	{
		while (true)
		{
			Strings.CreateGetStringDelegate(typeof(FTPConnect));
			while (true)
			{
				ftpConnectionProperties = new FTPConnectProperties();
				int num;
				if (0 == 0)
				{
					num = 0;
					while (true)
					{
						TotalLineCount = num;
						if (false)
						{
							break;
						}
						num = 0;
						if (num != 0)
						{
							continue;
						}
						goto IL_0020;
					}
					break;
				}
				goto IL_0025;
				IL_0020:
				SentLineCount = num;
				goto IL_0025;
				IL_0025:
				SendPersentage = 0.0;
				if (false)
				{
					continue;
				}
				return;
			}
		}
	}
}
