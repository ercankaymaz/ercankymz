using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading;
using _0005;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using buClass;

namespace buComm.FTP;

public class FTPClient
{
	[CompilerGenerated]
	internal FtpFileSendEventHandler _0001;

	private static string _0001;

	private static string _0002;

	private static string _0003;

	internal FTPControlSocket _0001 = null;

	internal Socket _0001 = null;

	private int _0001 = 0;

	private FTPTransferType _0001 = FTPTransferType.ASCII;

	internal FTPConnectMode _0001 = FTPConnectMode.PASV;

	internal FTPReply _0001;

	[NonSerialized]
	internal static GetString _009E;

	public int Timeout
	{
		set
		{
			this._0001 = value;
			_0005._0004._0001(value, this._0001);
		}
	}

	public FTPConnectMode ConnectMode
	{
		set
		{
			this._0001 = value;
		}
	}

	public FTPReply LastValidReply => _0001;

	public StreamWriter LogStream
	{
		set
		{
			_0005._0004._0001(value, this._0001);
		}
	}

	public FTPTransferType TransferType
	{
		get
		{
			return this._0001;
		}
		set
		{
			if (true)
			{
				string text = _0003;
				bool flag;
				if (7u != 0)
				{
					flag = value.Equals(FTPTransferType.BINARY);
				}
				if (flag)
				{
					if (false)
					{
						return;
					}
					string text2 = _0002;
					if (0 == 0)
					{
						text = text2;
					}
				}
				string text3 = _0005._0004._0001(this._0001, global::_0002._0003(_009E(107394654), text));
				FTPControlSocket fTPControlSocket = this._0001;
				string text4 = _009E(107394613);
				_0001 = _0005._0004._0001(text4, text3, fTPControlSocket);
			}
			this._0001 = value;
		}
	}

	public event FtpFileSendEventHandler FileSending
	{
		[CompilerGenerated]
		add
		{
			FtpFileSendEventHandler ftpFileSendEventHandler = this._0001;
			while (true)
			{
				FtpFileSendEventHandler ftpFileSendEventHandler2 = ftpFileSendEventHandler;
				while (true)
				{
					FtpFileSendEventHandler obj = (FtpFileSendEventHandler)_0016._008F(ftpFileSendEventHandler2, value);
					FtpFileSendEventHandler value2;
					if (4u != 0)
					{
						value2 = obj;
					}
					ftpFileSendEventHandler = Interlocked.CompareExchange(ref this._0001, value2, ftpFileSendEventHandler2);
					if ((object)ftpFileSendEventHandler != ftpFileSendEventHandler2)
					{
						break;
					}
					if (0 == 0 && 0 == 0)
					{
						return;
					}
				}
			}
		}
		[CompilerGenerated]
		remove
		{
			FtpFileSendEventHandler ftpFileSendEventHandler = this._0001;
			while (true)
			{
				FtpFileSendEventHandler ftpFileSendEventHandler2 = ftpFileSendEventHandler;
				while (true)
				{
					FtpFileSendEventHandler obj = (FtpFileSendEventHandler)_0016._0090(ftpFileSendEventHandler2, value);
					FtpFileSendEventHandler value2;
					if (4u != 0)
					{
						value2 = obj;
					}
					ftpFileSendEventHandler = Interlocked.CompareExchange(ref this._0001, value2, ftpFileSendEventHandler2);
					if ((object)ftpFileSendEventHandler != ftpFileSendEventHandler2)
					{
						break;
					}
					if (0 == 0 && 0 == 0)
					{
						return;
					}
				}
			}
		}
	}

	public FTPClient(string remoteHost)
	{
		this._0001 = new FTPControlSocket(remoteHost, 21, null, 0);
	}

	public FTPClient(string remoteHost, int controlPort)
	{
		this._0001 = new FTPControlSocket(remoteHost, controlPort, null, 0);
	}

	public FTPClient(IPAddress remoteAddr)
	{
		this._0001 = new FTPControlSocket(remoteAddr, 21, null, 0);
	}

	public FTPClient(IPAddress remoteAddr, int controlPort)
	{
		this._0001 = new FTPControlSocket(remoteAddr, controlPort, null, 0);
	}

	public FTPClient(string remoteHost, StreamWriter log, int timeout)
	{
		this._0001 = new FTPControlSocket(remoteHost, 21, log, timeout);
	}

	public FTPClient(string remoteHost, int controlPort, StreamWriter log, int timeout)
	{
		this._0001 = new FTPControlSocket(remoteHost, controlPort, log, timeout);
	}

	public FTPClient(IPAddress remoteAddr, StreamWriter log, int timeout)
	{
		this._0001 = new FTPControlSocket(remoteAddr, 21, log, timeout);
	}

	public FTPClient(IPAddress remoteAddr, int controlPort, StreamWriter log, int timeout)
	{
		this._0001 = new FTPControlSocket(remoteAddr, controlPort, log, timeout);
	}

	public bool Login(string user, string password)
	{
		FTPReply fTPReply = null;
		FTPReply fTPReply2 = null;
		string text = _0005._0004._0001(this._0001, global::_0002._0003(_009E(107394608), user));
		FTPControlSocket fTPControlSocket = this._0001;
		string text2 = _009E(107394631);
		fTPReply = _0005._0004._0001(text2, text, fTPControlSocket);
		text = _0005._0004._0001(this._0001, global::_0002._0003(_009E(107394626), password));
		fTPControlSocket = this._0001;
		text2 = _009E(107394585);
		fTPReply2 = _0005._0004._0001(text2, text, fTPControlSocket);
		if (fTPReply != null && fTPReply2 != null && (global::_0001._0002(global::_0005._007E_0010(fTPReply.ReplyCode), _009E(107394631)) & global::_0001._0002(global::_0005._007E_0010(fTPReply2.ReplyCode), _009E(107394585))))
		{
			return true;
		}
		return false;
	}

	public void User(string user)
	{
		string text = _0005._0004._0001(this._0001, global::_0002._0003(_009E(107394608), user));
		string[] array;
		do
		{
			array = new string[2]
			{
				_009E(107394585),
				_009E(107394631)
			};
		}
		while (5 == 0);
		_0001 = _0005._0004._0001(text, array, this._0001);
	}

	public void Password(string password)
	{
		string text = _0005._0004._0001(this._0001, global::_0002._0003(_009E(107394626), password));
		string[] array;
		do
		{
			array = new string[2]
			{
				_009E(107394585),
				_009E(107394580)
			};
		}
		while (5 == 0);
		_0001 = _0005._0004._0001(text, array, this._0001);
	}

	public void Quote(string command, string[] validCodes)
	{
		while (true)
		{
			string text = _0005._0004._0001(this._0001, command);
			if (false)
			{
				goto IL_003b;
			}
			int num = ((validCodes != null && validCodes.Length != 0) ? 1 : 0);
			goto IL_005b;
			IL_003b:
			if (false)
			{
				continue;
			}
			if (0 == 0)
			{
				if (1 == 0)
				{
					continue;
				}
				break;
			}
			goto IL_005e;
			IL_005e:
			bool flag;
			num = (flag ? 1 : 0);
			if (false)
			{
				goto IL_005b;
			}
			if (num != 0)
			{
				_0001 = _0005._0004._0001(text, validCodes, this._0001);
			}
			goto IL_003b;
			IL_005b:
			flag = (byte)num != 0;
			goto IL_005e;
		}
	}

	public void Put(string localPath, string remoteFile)
	{
		Put(localPath, remoteFile, append: false);
	}

	public void Put(Stream srcStream, string remoteFile)
	{
		Put(srcStream, remoteFile, append: false);
	}

	public void Put(string localPath, string remoteFile, bool append)
	{
		if (0 == 0)
		{
			if (TransferType != FTPTransferType.ASCII)
			{
				goto IL_0029;
			}
			if (8u != 0)
			{
				goto IL_0050;
			}
			return;
		}
		return;
		IL_0035:
		if (false)
		{
			goto IL_0050;
		}
		_0005._0004._0001(this);
		return;
		IL_0029:
		_0005._0004._0001(localPath, append, remoteFile, this);
		goto IL_0035;
		IL_0050:
		_0005._0004._0001(append, this, localPath, remoteFile);
		if (uint.MaxValue != 0)
		{
			if (false)
			{
				goto IL_0029;
			}
			goto IL_0035;
		}
	}

	public void Put(Stream srcStream, string remoteFile, bool append)
	{
		if (0 == 0)
		{
			if (TransferType != FTPTransferType.ASCII)
			{
				goto IL_0029;
			}
			if (8u != 0)
			{
				goto IL_0050;
			}
			return;
		}
		return;
		IL_0035:
		if (false)
		{
			goto IL_0050;
		}
		_0005._0004._0001(this);
		return;
		IL_0029:
		_0005._0004._0001(remoteFile, this, append, srcStream);
		goto IL_0035;
		IL_0050:
		_0005._0004._0001(srcStream, this, append, remoteFile);
		if (uint.MaxValue != 0)
		{
			if (false)
			{
				goto IL_0029;
			}
			goto IL_0035;
		}
	}

	public void Put(byte[] bytes, string remoteFile)
	{
		Put(bytes, remoteFile, append: false);
	}

	public void Put(byte[] bytes, string remoteFile, bool append)
	{
		_0005._0004._0001(append, remoteFile, this);
		while (true)
		{
			if (7u != 0)
			{
			}
			BinaryWriter binaryWriter = new BinaryWriter(_0005._0004._0001(this));
			_007F_0002._007E_000E_0003(binaryWriter, bytes, 0, bytes.Length);
			while (true)
			{
				IL_0029:
				_0011._007E_0082(binaryWriter);
				while (true)
				{
					IL_0035:
					_0011._007E_0083(binaryWriter);
					while (2u != 0)
					{
						_0005._0004._0001(this);
						if (3 == 0)
						{
							goto IL_0035;
						}
						if (false)
						{
							goto IL_0029;
						}
						if (true)
						{
							return;
						}
					}
					break;
				}
				break;
			}
		}
	}

	public void Get(string localPath, string remoteFile)
	{
		bool num;
		bool flag;
		if (0 == 0)
		{
			num = TransferType == FTPTransferType.ASCII;
			if (false)
			{
				goto IL_0012;
			}
			flag = num;
			goto IL_004b;
		}
		return;
		IL_004b:
		num = flag;
		goto IL_0012;
		IL_0012:
		if (num)
		{
			_0005._0004._0001(remoteFile, localPath, this);
			if (7 == 0)
			{
				goto IL_004b;
			}
			if (false)
			{
			}
		}
		else
		{
			_0005._0004._0001(remoteFile, this, localPath);
			while (2 == 0)
			{
			}
		}
		_0005._0004._0001(this);
	}

	public void Get(Stream destStream, string remoteFile)
	{
		bool num;
		bool flag;
		if (0 == 0)
		{
			num = TransferType == FTPTransferType.ASCII;
			if (false)
			{
				goto IL_0012;
			}
			flag = num;
			goto IL_004b;
		}
		return;
		IL_004b:
		num = flag;
		goto IL_0012;
		IL_0012:
		if (num)
		{
			_0005._0004._0001(remoteFile, destStream, this);
			if (7 == 0)
			{
				goto IL_004b;
			}
			if (false)
			{
			}
		}
		else
		{
			_0005._0004._0001(remoteFile, destStream, this);
			while (2 == 0)
			{
			}
		}
		_0005._0004._0001(this);
	}

	public byte[] Get(string remoteFile)
	{
		_0005._0004._0001(remoteFile, this);
		BinaryReader binaryReader = new BinaryReader(_0005._0004._0001(this));
		int num = 4096;
		byte[] array = new byte[num];
		int num2 = num;
		if (false)
		{
			goto IL_007e;
		}
		if (-1 == 0)
		{
			goto IL_007a;
		}
		MemoryStream memoryStream = new MemoryStream(num2);
		if (true)
		{
			goto IL_0064;
		}
		goto IL_008c;
		IL_011a:
		return _0083_0002._007E_0014_0003(memoryStream);
		IL_008c:
		try
		{
			_0011._007E_001E(binaryReader);
		}
		catch (IOException ex)
		{
			if (0 == 0)
			{
				_0082_0002._0013_0003(_009E(107397221), _009E(107394575), global::_0005._007E_0012(_0081_0002._0012_0003()));
			}
			_008F._0014_0002(ex, global::_0005._007E_0012(_0081_0002._0012_0003()), true, _009E(107397221));
		}
		_0005._0004._0001(this);
		goto IL_011a;
		IL_0064:
		int num3 = default(int);
		num2 = (((num3 = _0080_0002._007E_0010_0003(binaryReader, array, 0, array.Length)) > 0) ? 1 : 0);
		goto IL_007a;
		IL_007a:
		bool flag = (byte)num2 != 0;
		num2 = (flag ? 1 : 0);
		goto IL_007e;
		IL_007e:
		if (num2 != 0)
		{
			_007F_0002._007E_000F_0003(memoryStream, array, 0, num3);
			if (0 == 0)
			{
				goto IL_0064;
			}
			goto IL_011a;
		}
		_0011._007E_0084(memoryStream);
		goto IL_008c;
	}

	public bool Site(string command)
	{
		string text = _0005._0004._0001(this._0001, global::_0002._0003(_009E(107394598), command));
		string[] array = new string[3]
		{
			_009E(107394613),
			_009E(107394580),
			_009E(107394589)
		};
		_0001 = _0005._0004._0001(text, array, this._0001);
		if (_0084_0002._007E_0015_0003(global::_009E._007E_0087_0002(text, 0, 3), _009E(107394613)))
		{
			return true;
		}
		return false;
	}

	public string[] Dir()
	{
		return Dir(null, full: false);
	}

	public string[] Dir(string dirname)
	{
		return Dir(dirname, full: false);
	}

	public string[] Dir(string dirname, bool full)
	{
		this._0001 = _0005._0004._0001(this._0001, this._0001);
		if (full)
		{
			goto IL_003c;
		}
		string text = _009E(107394552);
		goto IL_02b9;
		IL_0252:
		bool flag = default(bool);
		bool num = flag;
		if (false)
		{
			goto IL_0250;
		}
		string[] result = default(string[]);
		ArrayList arrayList = default(ArrayList);
		if (num)
		{
			result = (string[])_0086_0002._007E_0016_0003(arrayList, _001B._0097(typeof(string).TypeHandle));
		}
		goto IL_027b;
		IL_02b9:
		string text2 = text;
		if (8 == 0)
		{
			goto IL_0252;
		}
		if (dirname != null)
		{
			text2 = global::_0002._0003(text2, dirname);
		}
		text2 = global::_0005._007E_0010(text2);
		string text3 = _0005._0004._0001(this._0001, text2);
		StreamReader streamReader;
		while (true)
		{
			int num2 = 3;
			do
			{
				string[] array = new string[num2];
				array[0] = _009E(107394566);
				array[1] = _009E(107394561);
				array[2] = _009E(107394524);
				string[] array2 = array;
				_0001 = _0005._0004._0001(text3, array2, this._0001);
				result = new string[0];
				num2 = ((!_0084_0002._007E_0015_0003(_0001.ReplyCode, _009E(107394524))) ? 1 : 0);
			}
			while (3 == 0);
			if (num2 == 0)
			{
				break;
			}
			streamReader = new StreamReader(_0005._0004._0001(this));
			arrayList = new ArrayList();
			string text4 = null;
			while (true)
			{
				bool flag2 = (text4 = global::_0005._007E_0013(streamReader)) != null;
				if (3 == 0)
				{
					break;
				}
				if (flag2)
				{
					_0097._007E_007F_0002(arrayList, text4);
					continue;
				}
				goto IL_0167;
			}
		}
		goto IL_027b;
		IL_01ef:
		string[] array3 = new string[2]
		{
			_009E(107394519),
			_009E(107394514)
		};
		text3 = _0005._0004._0001(this._0001);
		_0001 = _0005._0004._0001(text3, array3, this._0001);
		if (false)
		{
			goto IL_003c;
		}
		num = _000E._007E_001A(arrayList) > 0;
		goto IL_0250;
		IL_0250:
		flag = num;
		goto IL_0252;
		IL_027b:
		return result;
		IL_0167:
		try
		{
			do
			{
				_0011._007E_0086(streamReader);
			}
			while (7 == 0);
		}
		catch (IOException ex)
		{
			_0082_0002._0013_0003(_009E(107397221), _009E(107394575), global::_0005._007E_0012(_0081_0002._0012_0003()));
			_008F._0014_0002(ex, global::_0005._007E_0012(_0081_0002._0012_0003()), true, _009E(107397221));
		}
		goto IL_01ef;
		IL_003c:
		if (false)
		{
			goto IL_01ef;
		}
		text = _009E(107394543);
		goto IL_02b9;
	}

	public void DebugResponses(bool on)
	{
		this._0001._0001 = on;
	}

	public void Delete(string remoteFile)
	{
		string text = _0005._0004._0001(this._0001, global::_0002._0003(_009E(107394509), remoteFile));
		FTPControlSocket fTPControlSocket = this._0001;
		string text2 = _009E(107394514);
		_0001 = _0005._0004._0001(text2, text, fTPControlSocket);
	}

	public void Rename(string from, string to)
	{
		string text = _0005._0004._0001(this._0001, global::_0002._0003(_009E(107394532), from));
		FTPControlSocket fTPControlSocket = this._0001;
		string text2 = _009E(107394491);
		_0001 = _0005._0004._0001(text2, text, fTPControlSocket);
		text = _0005._0004._0001(this._0001, global::_0002._0003(_009E(107394486), to));
		fTPControlSocket = this._0001;
		text2 = _009E(107394514);
		_0001 = _0005._0004._0001(text2, text, fTPControlSocket);
	}

	public void Rmdir(string dir)
	{
		string text = _0005._0004._0001(this._0001, global::_0002._0003(_009E(107394477), dir));
		string[] array;
		do
		{
			array = new string[2]
			{
				_009E(107394514),
				_009E(107394500)
			};
		}
		while (5 == 0);
		_0001 = _0005._0004._0001(text, array, this._0001);
	}

	public void Mkdir(string dir)
	{
		string text = _0005._0004._0001(this._0001, global::_0002._0003(_009E(107394495), dir));
		FTPControlSocket fTPControlSocket = this._0001;
		string text2 = _009E(107394500);
		_0001 = _0005._0004._0001(text2, text, fTPControlSocket);
	}

	public void Chdir(string dir)
	{
		string text = _0005._0004._0001(this._0001, global::_0002._0003(_009E(107394454), dir));
		FTPControlSocket fTPControlSocket = this._0001;
		string text2 = _009E(107394514);
		_0001 = _0005._0004._0001(text2, text, fTPControlSocket);
	}

	public DateTime ModTime(string remoteFile)
	{
		DateTime result;
		DateTime dateTime = default(DateTime);
		while (true)
		{
			if (4 == 0)
			{
				goto IL_008e;
			}
			goto IL_00a0;
			IL_008e:
			if (false)
			{
				continue;
			}
			result = dateTime;
			goto IL_0096;
			IL_00a0:
			string text = _0005._0004._0001(this._0001, global::_0002._0003(_009E(107394445), remoteFile));
			if (6u != 0)
			{
				FTPControlSocket fTPControlSocket = this._0001;
				string text2 = _009E(107394468);
				_0001 = _0005._0004._0001(text2, text, fTPControlSocket);
				if (0 == 0)
				{
					dateTime = _0087_0002._0017_0003(_0001.ReplyText, FTPClient._0001, null);
				}
				goto IL_008e;
			}
			goto IL_0096;
			IL_0096:
			if (2 == 0)
			{
				goto IL_00a0;
			}
			break;
		}
		return result;
	}

	public string Pwd()
	{
		string text = _0005._0004._0001(this._0001, _009E(107394463));
		FTPControlSocket fTPControlSocket = this._0001;
		string text2 = _009E(107394500);
		_0001 = _0005._0004._0001(text2, text, fTPControlSocket);
		string replyText = _0001.ReplyText;
		int num = _0088_0002._007E_0018_0003(replyText, '"');
		int num2 = _0088_0002._007E_0019_0003(replyText, '"');
		int num3 = num;
		int num4 = 0;
		if (num4 == 0)
		{
			if ((num3 < num4) ? true : false)
			{
				goto IL_00b1;
			}
			num3 = num2;
			num4 = num;
		}
		if (num3 > num4)
		{
			return global::_009E._007E_0087_0002(replyText, num + 1, num2 - (num + 1));
		}
		goto IL_00b1;
		IL_00b1:
		return replyText;
	}

	public string SystemFTP()
	{
		if (7u != 0)
		{
			if (false)
			{
				goto IL_0044;
			}
			goto IL_0057;
		}
		goto IL_006b;
		IL_0044:
		string replyText = _0001.ReplyText;
		if (-1 == 0)
		{
			goto IL_0057;
		}
		return replyText;
		IL_0057:
		string text = _0005._0004._0001(this._0001, _009E(107394426));
		goto IL_006b;
		IL_006b:
		FTPControlSocket fTPControlSocket = this._0001;
		string text2 = _009E(107394417);
		_0001 = _0005._0004._0001(text2, text, fTPControlSocket);
		goto IL_0044;
	}

	public string Help(string command)
	{
		string text = _0005._0004._0001(this._0001, global::_0002._0003(_009E(107394444), command));
		string[] array = new string[2]
		{
			_009E(107394435),
			_009E(107394430)
		};
		_0001 = _0005._0004._0001(text, array, this._0001);
		return _0001.ReplyText;
	}

	public void Quit()
	{
		if (3 == 0)
		{
			return;
		}
		try
		{
			string text = _0005._0004._0001(this._0001, _009E(107393881));
			string[] array = new string[2]
			{
				_009E(107393872),
				_009E(107394519)
			};
			do
			{
				_0001 = _0005._0004._0001(text, array, this._0001);
			}
			while (8 == 0);
			if (3 == 0)
			{
			}
		}
		finally
		{
			do
			{
				if (0 == 0)
				{
					this._0001.Logout();
				}
			}
			while (5 == 0);
			this._0001 = null;
		}
	}

	static FTPClient()
	{
		if (uint.MaxValue != 0)
		{
			Strings.CreateGetStringDelegate(typeof(FTPClient));
			FTPClient._0001 = _009E(107393899);
			goto IL_001d;
		}
		goto IL_0031;
		IL_0031:
		_0003 = _009E(107393841);
		goto IL_0042;
		IL_001d:
		if (0 == 0)
		{
			_0002 = _009E(107393846);
			goto IL_0031;
		}
		goto IL_0042;
		IL_0042:
		if (0 == 0)
		{
			if (true)
			{
				return;
			}
			goto IL_001d;
		}
		goto IL_0031;
	}
}
