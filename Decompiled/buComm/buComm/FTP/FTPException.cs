using System;
using System.Reflection;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using buClass;

namespace buComm.FTP;

public class FTPException : Exception
{
	private int _0001 = -1;

	[NonSerialized]
	internal static GetString _008C;

	public int ReplyCode => _0001;

	public FTPException(string msg)
		: base(msg)
	{
	}

	public FTPException(string msg, string replyCode)
		: base(msg)
	{
		try
		{
			_0001 = int.Parse(replyCode);
		}
		catch (FormatException mSException)
		{
			_0001 = -1;
			buLog.addLog(_008C(107397248), _008C(107394602), MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, _008C(107397248));
		}
	}

	static FTPException()
	{
		Strings.CreateGetStringDelegate(typeof(FTPException));
	}
}
