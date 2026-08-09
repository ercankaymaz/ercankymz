using System;
using System.Collections.Generic;
using System.IO;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using buClass;

namespace buMotion;

[Serializable]
public class buMotionLogVer5
{
	public static string LogFileName;

	public static string ExceptionFileName;

	public static string SeasonFileName;

	public string Message = null;

	public string Command = _0012(107397507);

	public string Method = _0012(107397507);

	public string Data = null;

	public string BaseClass = null;

	public double ID = 0.0;

	public double Value = 0.0;

	public DateTime Time = default(DateTime);

	public static List<string> LogList;

	[NonSerialized]
	internal static GetString _0012;

	public buMotionLogVer5()
	{
	}

	public buMotionLogVer5(buMotionLogVer5 log)
	{
		Message = log.Message;
		Data = log.Data;
		ID = log.ID;
		Time = log.Time;
		Command = log.Command;
		Method = log.Method;
		Value = log.Value;
	}

	public buMotionLogVer5(string baseClass, string method, string command, string message, string data, double id, double value)
	{
		BaseClass = baseClass;
		Command = command;
		Message = message;
		Method = method;
		Data = data;
		ID = id;
		Value = value;
		Time = DateTime.Now;
	}

	public unsafe static void checkLogFileSize()
	{
		void* ptr = stackalloc byte[39];
		try
		{
			FileInfo fileInfo = new FileInfo(global::_0002._0003(global::_001A_0002._0098_0002(), _0012(107382872), LogFileName));
			((sbyte*)ptr)[32] = (global::_0089._007E_0001_0002(fileInfo) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[32])
			{
				*(int*)ptr = 2048;
				((int*)ptr)[1] = 20;
				((sbyte*)ptr)[33] = ((global::_001B_0002._007E_009A_0002(fileInfo) > global::_001C_0002._009C_0002(*(int*)ptr * 1024)) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[33])
				{
					List<string> list = new List<string>();
					string text = _0012(107397507);
					TextReader textReader = global::_008B._0004_0002(global::_0010._007E_0017(fileInfo));
					while ((text = global::_0010._007E_0018(textReader)) != null)
					{
						list.Add(text);
					}
					global::_001C._007E_008F(textReader);
					((int*)ptr)[2] = global::_001C_0002._009C_0002(list.Count * ((int*)ptr)[1] / 100);
					list.Reverse();
					list.RemoveRange(((int*)ptr)[2], list.Count - ((int*)ptr)[2]);
					list.Reverse();
					TextWriter textWriter = global::_001D_0002._009D_0002(buSystem.fileNameLog);
					((int*)ptr)[3] = 0;
					while (true)
					{
						((sbyte*)ptr)[34] = ((((int*)ptr)[3] <= list.Count - 1) ? ((sbyte)1) : ((sbyte)0));
						if (((sbyte*)ptr)[34] == 0)
						{
							break;
						}
						global::_0019._007E_0089(textWriter, global::_0010._007E_0012(list[((int*)ptr)[3]]));
						if (0 == 0)
						{
							((int*)ptr)[3]++;
							continue;
						}
						goto IL_029d;
					}
					global::_001C._007E_0090(textWriter);
				}
			}
			fileInfo = new FileInfo(global::_0002._0003(global::_001A_0002._0098_0002(), _0012(107382872), ExceptionFileName));
			((sbyte*)ptr)[35] = (global::_0089._007E_0001_0002(fileInfo) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[35])
			{
				global::_001C._007E_0091(fileInfo);
			}
			fileInfo = new FileInfo(global::_0002._0003(global::_001A_0002._0098_0002(), _0012(107382872), SeasonFileName));
			((sbyte*)ptr)[36] = (global::_0089._007E_0001_0002(fileInfo) ? ((sbyte)1) : ((sbyte)0));
			if (((sbyte*)ptr)[36] == 0)
			{
				return;
			}
			((int*)ptr)[4] = 2048;
			((int*)ptr)[5] = 20;
			((sbyte*)ptr)[37] = ((global::_001B_0002._007E_009A_0002(fileInfo) > global::_001C_0002._009C_0002(((int*)ptr)[4] * 1024)) ? ((sbyte)1) : ((sbyte)0));
			if (0 == 0)
			{
				if (((sbyte*)ptr)[37] == 0)
				{
					return;
				}
				goto IL_029d;
			}
			goto IL_0395;
			IL_029d:
			List<string> list2;
			TextReader textReader2;
			string text2;
			if (0 == 0)
			{
				list2 = new List<string>();
				text2 = _0012(107397507);
				textReader2 = global::_008B._0004_0002(global::_0010._007E_0017(fileInfo));
			}
			while ((text2 = global::_0010._007E_0018(textReader2)) != null)
			{
				list2.Add(text2);
			}
			global::_001C._007E_008F(textReader2);
			((int*)ptr)[6] = global::_001C_0002._009C_0002(list2.Count * ((int*)ptr)[5] / 100);
			list2.Reverse();
			list2.RemoveRange(((int*)ptr)[6], list2.Count - ((int*)ptr)[6]);
			list2.Reverse();
			TextWriter textWriter2 = global::_001D_0002._009D_0002(buSystem.fileNameExceptionLog);
			((int*)ptr)[7] = 0;
			goto IL_0395;
			IL_0395:
			while (true)
			{
				((sbyte*)ptr)[38] = ((((int*)ptr)[7] <= list2.Count - 1) ? ((sbyte)1) : ((sbyte)0));
				if (((sbyte*)ptr)[38] == 0)
				{
					break;
				}
				global::_0019._007E_0089(textWriter2, global::_0010._007E_0012(list2[((int*)ptr)[7]]));
				((int*)ptr)[7]++;
			}
			global::_001C._007E_0090(textWriter2);
		}
		catch (Exception)
		{
		}
	}

	public static void addToLogList(string strClass, string method, string command, string message = "", string data = "", double id = 0.0, double value = 0.0, bool AddException = false)
	{
		bool num = LogList == null;
		do
		{
			bool flag = num;
			num = flag;
		}
		while (false);
		if (num)
		{
			LogList = new List<string>();
		}
		string item = global::_0007._000E(new string[15]
		{
			global::_001E_0002._009F_0002().ToLocalTime().ToString(),
			_0012(107382835),
			strClass,
			_0012(107382835),
			method,
			_0012(107382835),
			command,
			_0012(107382835),
			message,
			_0012(107382835),
			data,
			_0012(107382835),
			value.ToString(),
			_0012(107382835),
			id.ToString()
		});
		LogList.Add(item);
	}

	public unsafe static void saveLogList()
	{
		if (false)
		{
			goto IL_00f8;
		}
		void* ptr = stackalloc byte[11];
		goto IL_0164;
		IL_0124:
		((sbyte*)ptr)[10] = ((((int*)ptr)[1] <= LogList.Count - 1) ? ((sbyte)1) : ((sbyte)0));
		TextWriter textWriter;
		if (((sbyte*)ptr)[10] == 0)
		{
			global::_001C._007E_0090(textWriter);
			LogList.Clear();
			return;
		}
		goto IL_00f8;
		IL_0164:
		((sbyte*)ptr)[8] = ((LogList != null) ? ((sbyte)1) : ((sbyte)0));
		if (((sbyte*)ptr)[8] == 0)
		{
			return;
		}
		string text = global::_0002._0003(global::_001A_0002._0098_0002(), _0012(107382872), LogFileName);
		TextWriter textWriter2 = global::_001D_0002._009E_0002(text);
		*(int*)ptr = 0;
		while (true)
		{
			((sbyte*)ptr)[9] = ((*(int*)ptr <= LogList.Count - 1) ? ((sbyte)1) : ((sbyte)0));
			if (((sbyte*)ptr)[9] == 0)
			{
				break;
			}
			global::_0019._007E_008A(textWriter2, LogList[*(int*)ptr]);
			(*(int*)ptr)++;
		}
		global::_001C._007E_0090(textWriter2);
		text = global::_0002._0003(global::_001A_0002._0098_0002(), _0012(107382872), SeasonFileName);
		textWriter = global::_001D_0002._009E_0002(text);
		((int*)ptr)[1] = 0;
		goto IL_0124;
		IL_00f8:
		global::_0019._007E_008A(textWriter, LogList[((int*)ptr)[1]]);
		if (4 == 0)
		{
			goto IL_0164;
		}
		((int*)ptr)[1]++;
		goto IL_0124;
	}

	public static void addToLog(string strClass, string method, string command, string message = "", string data = "", double id = 0.0, double value = 0.0, bool AddException = false)
	{
		if (false)
		{
			return;
		}
		try
		{
			string text = global::_0007._000E(new string[16]
			{
				global::_001E_0002._009F_0002().ToLocalTime().ToString(),
				_0012(107382835),
				strClass,
				_0012(107382835),
				method,
				_0012(107382835),
				command,
				_0012(107382835),
				message,
				_0012(107382835),
				data,
				_0012(107382835),
				value.ToString(),
				_0012(107382835),
				id.ToString(),
				global::_001A_0002._0099_0002()
			});
			string text2 = global::_0002._0003(global::_001A_0002._0098_0002(), _0012(107382872), LogFileName);
			TextWriter textWriter = global::_001D_0002._009E_0002(text2);
			global::_0019._007E_008A(textWriter, text);
			global::_001C._007E_0090(textWriter);
			while (true)
			{
				if (0 == 0)
				{
					if (AddException)
					{
						addToLogException(strClass, method, _0012(107397453), message, data, id, value);
					}
					goto IL_017b;
				}
				goto IL_01a7;
				IL_01a7:
				if (3u != 0)
				{
					break;
				}
				goto IL_017b;
				IL_017b:
				if (false)
				{
					continue;
				}
				text2 = global::_0002._0003(global::_001A_0002._0098_0002(), _0012(107382872), SeasonFileName);
				goto IL_01a7;
			}
			TextWriter textWriter2 = global::_001D_0002._009E_0002(text2);
			global::_0019._007E_008A(textWriter2, text);
			global::_001C._007E_0090(textWriter2);
		}
		catch (Exception)
		{
		}
	}

	public static void addToLogException(string strClass, string method, string command = "", string message = "Exception", string data = "", double id = 0.0, double value = 0.0)
	{
		try
		{
			string text;
			if (0 == 0)
			{
				global::_0007 obj = global::_0007._000E;
				string[] array = new string[16];
				DateTime dateTime = global::_001E_0002._009F_0002();
				DateTime dateTime2 = default(DateTime);
				if (0 == 0)
				{
					dateTime2 = dateTime;
				}
				DateTime dateTime3 = dateTime2.ToLocalTime();
				if (0 == 0)
				{
					dateTime2 = dateTime3;
				}
				array[0] = dateTime2.ToString();
				array[1] = _0012(107382835);
				array[2] = strClass;
				array[3] = _0012(107382835);
				array[4] = method;
				array[5] = _0012(107382835);
				array[6] = command;
				array[7] = _0012(107382835);
				array[8] = message;
				array[9] = _0012(107382835);
				array[10] = data;
				array[11] = _0012(107382835);
				array[12] = value.ToString();
				array[13] = _0012(107382835);
				array[14] = id.ToString();
				array[15] = global::_001A_0002._0099_0002();
				text = obj(array);
			}
			string text2 = global::_0003._0005(global::_001A_0002._0098_0002(), _0012(107382830));
			TextWriter textWriter = global::_001D_0002._009E_0002(text2);
			do
			{
				global::_0019._007E_008A(textWriter, text);
			}
			while (false);
			global::_001C._007E_0090(textWriter);
		}
		catch (Exception)
		{
			while (7 == 0)
			{
			}
		}
	}

	public override string ToString()
	{
		if (true)
		{
		}
		if (true)
		{
			return global::_0007._000E(new string[9]
			{
				Time.ToShortTimeString(),
				_0012(107382797),
				BaseClass,
				_0012(107382808),
				Method,
				_0012(107383303),
				Command,
				_0012(107383290),
				Message
			});
		}
		string result;
		return result;
	}

	static buMotionLogVer5()
	{
		while (2u != 0)
		{
			Strings.CreateGetStringDelegate(typeof(buMotionLogVer5));
			do
			{
				if (4u != 0)
				{
					LogFileName = _0012(107383245);
					continue;
				}
				return;
			}
			while (false);
			if (0 == 0)
			{
				ExceptionFileName = _0012(107383256);
				SeasonFileName = _0012(107383227);
				LogList = null;
				break;
			}
		}
	}
}
