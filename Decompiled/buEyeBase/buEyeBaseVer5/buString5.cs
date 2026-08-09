using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using buClass;
using devDept.Geometry;

namespace buEyeBaseVer5;

public class buString5
{
	public buString5()
	{
		if (!buVector5.smethod_0("buString5"))
		{
			throw new RegisterException("buString5");
		}
	}

	public static void MessageBoxInfo(string Message)
	{
		MessageBox.Show(Message, Application.ProductName + " ,  Ver : " + Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
	}

	public static void MessageBoxError(string Message)
	{
		MessageBox.Show(Message, Application.ProductName + " ,  Ver : " + Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Hand);
	}

	public static void MessageBoxWarning(string Message)
	{
		MessageBox.Show(Message, Application.ProductName + " ,  Ver : " + Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
	}

	public static DialogResult MessageBoxQuestion(string Message)
	{
		return MessageBox.Show(Message, Application.ProductName + " ,  Ver : " + Application.ProductVersion, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
	}

	public static DialogResult MessageBoxQuestionYesNoCancel(string Message)
	{
		return MessageBox.Show(Message, Application.ProductName + " ,  Ver : " + Application.ProductVersion, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
	}

	public static Font UpdateFontStyle(Font refFont, bool Bold, bool Italic, bool Undeline, bool StrikeOut)
	{
		try
		{
			FontStyle fontStyle = FontStyle.Regular;
			if (Bold)
			{
				fontStyle |= FontStyle.Bold;
			}
			if (Undeline)
			{
				fontStyle |= FontStyle.Underline;
			}
			if (Italic)
			{
				fontStyle |= FontStyle.Italic;
			}
			if (StrikeOut)
			{
				fontStyle |= FontStyle.Strikeout;
			}
			refFont = new Font(refFont.Name, refFont.Size, fontStyle);
			return refFont;
		}
		catch (Exception)
		{
			return refFont;
		}
	}

	public static Font UpdateFontStyle(Font refFont, double Size, bool Bold, bool Italic, bool Undeline, bool StrikeOut)
	{
		try
		{
			FontStyle fontStyle = FontStyle.Regular;
			if (Bold)
			{
				fontStyle |= FontStyle.Bold;
			}
			if (Undeline)
			{
				fontStyle |= FontStyle.Underline;
			}
			if (Italic)
			{
				fontStyle |= FontStyle.Italic;
			}
			if (StrikeOut)
			{
				fontStyle |= FontStyle.Strikeout;
			}
			float num = (float)Size;
			if (num <= 0f)
			{
				num = refFont.Size;
			}
			refFont = new Font(refFont.Name, num, fontStyle);
			return refFont;
		}
		catch (Exception)
		{
			return refFont;
		}
	}

	public static Font GetFontFromName(string fontName, double Size, bool Bold)
	{
		Font font = null;
		float num = (float)Size;
		string text = fontName;
		if (text.Trim().Length <= 0)
		{
			text = "Microsoft Sans Serif";
		}
		if (num <= 0f)
		{
			num = 10f;
		}
		try
		{
			FontStyle fontStyle = FontStyle.Regular;
			if (Bold)
			{
				fontStyle |= FontStyle.Bold;
			}
			return new Font(text, num, fontStyle);
		}
		catch (Exception)
		{
			return new Font("Microsoft Sans Serif", num);
		}
	}

	public static Font GetFontFromName(string fontName, double Size, bool Bold, bool Italic, bool Undeline, bool StrikeOut)
	{
		Font font = null;
		float num = (float)Size;
		string text = fontName;
		if (text.Trim().Length <= 0)
		{
			text = "Microsoft Sans Serif";
		}
		if (num <= 0f)
		{
			num = 10f;
		}
		try
		{
			FontStyle fontStyle = FontStyle.Regular;
			if (Bold)
			{
				fontStyle |= FontStyle.Bold;
			}
			if (Undeline)
			{
				fontStyle |= FontStyle.Underline;
			}
			if (Italic)
			{
				fontStyle |= FontStyle.Italic;
			}
			if (StrikeOut)
			{
				fontStyle |= FontStyle.Strikeout;
			}
			return new Font(text, num, fontStyle);
		}
		catch (Exception)
		{
			return new Font("Microsoft Sans Serif", num);
		}
	}

	public static string StringArrayToStringByIndex(string[] strArr, int Index, bool Trim = true)
	{
		if (strArr != null)
		{
			if (strArr.Length != 0)
			{
				if (Index <= strArr.Length)
				{
					if (Index > strArr.Length)
					{
						return "";
					}
					if (strArr[Index] == null)
					{
						return "";
					}
					if (Trim)
					{
						return strArr[Index].Trim();
					}
					return strArr[Index];
				}
				return "";
			}
			return "";
		}
		return "";
	}

	public static void GetLanguageItem(List<string> LanguageList, int Index, ref string refItem)
	{
		if (!((Index >= 0) & (Index <= LanguageList.Count - 1)))
		{
			refItem = "_" + refItem;
		}
		else
		{
			refItem = LanguageList[Index];
		}
	}

	public static string GetAlfabetLetter(int index)
	{
		string text = "";
		if (index >= "ABCDEFGHIJKLMNOPQRSTUVWXYZ".Length)
		{
			text += "ABCDEFGHIJKLMNOPQRSTUVWXYZ"[index / "ABCDEFGHIJKLMNOPQRSTUVWXYZ".Length - 1];
		}
		return text + "ABCDEFGHIJKLMNOPQRSTUVWXYZ"[index % "ABCDEFGHIJKLMNOPQRSTUVWXYZ".Length];
	}

	public static string GetLetterFromAscii(int AsciiNumber)
	{
		return ((char)AsciiNumber).ToString();
	}

	public static void ReadStringValue(string Line, string Paramater, ref string Value, string EqualChar = "=")
	{
		try
		{
			string[] array = null;
			array = Line.Split(Convert.ToChar(EqualChar));
			if (array == null)
			{
				return;
			}
			if (array.Length == 2)
			{
				Value = array[1].Trim();
			}
			if (array.Length <= 2)
			{
				return;
			}
			Value = "";
			for (int i = 1; i <= array.Length - 1; i++)
			{
				string text = array[i].Trim();
				if (i > 1)
				{
					text = "=" + text;
				}
				if (text.Length == 0)
				{
					text = "=";
				}
				Value += text;
			}
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public static void ReadStringValue(string Line, string Paramater, ref double Value, string EqualChar = "=")
	{
		try
		{
			string text = "";
			string[] array = null;
			array = Line.Split(Convert.ToChar(EqualChar));
			if (array == null)
			{
				return;
			}
			if (array.Length == 2)
			{
				text = array[1].Trim();
			}
			if (array.Length > 2)
			{
				text = "";
				for (int i = 1; i <= array.Length - 1; i++)
				{
					string text2 = array[i].Trim();
					if (i > 1)
					{
						text2 = "=" + text2;
					}
					if (text2.Length == 0)
					{
						text2 = "=";
					}
					text += text2;
				}
			}
			if (text.Length > 0)
			{
				double.TryParse(text, out Value);
			}
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public static bool ReadCharValue(string FullLine, string Chr, ref double Value)
	{
		try
		{
			int num = FullLine.IndexOf(Chr);
			string text = "";
			bool flag = false;
			int length = Chr.Length;
			for (int i = num + length; i <= FullLine.Length - 1; i++)
			{
				string text2 = FullLine.Substring(i, 1);
				flag = false;
				if (buNumeric5.IsNumeric(text2))
				{
					flag = true;
				}
				if (!flag & ((text2 == ".") | (text2 == "-")))
				{
					flag = true;
				}
				if (!flag)
				{
					text = FullLine.Substring(num + 1, i - (num + 1));
					if (!buNumeric5.IsNumeric(text))
					{
						return false;
					}
					Value = double.Parse(text);
					return true;
				}
			}
			text = FullLine.Substring(num + length, FullLine.Length - num - length);
			if (!buNumeric5.IsNumeric(text))
			{
				return false;
			}
			Value = double.Parse(text);
			return true;
		}
		catch (Exception mSException)
		{
			string text3 = "FullLine : " + FullLine.ToString() + "- Chr : " + Chr.ToString();
			buLog.addLog(text3, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text3);
			return false;
		}
	}

	public static bool ReadStringValue(string Char, string Line, ref double Value)
	{
		bool flag = false;
		string text = "";
		int num = Line.ToLower().IndexOf(Char.ToLower());
		if (num >= 0)
		{
			for (int i = num + 1; i <= Line.Length - 1; i++)
			{
				string text2 = Line.Substring(i, 1);
				if (!(flag = buNumeric5.IsNumeric(text2)))
				{
					if (text2 == ".")
					{
						flag = true;
					}
					if (text2 == "-")
					{
						flag = true;
					}
				}
				if (!flag)
				{
					text = Line.Substring(num + 1, i - (num + 1));
					if (!buNumeric5.IsNumeric(text))
					{
						return false;
					}
					Value = double.Parse(text);
					return true;
				}
			}
			text = Line.Substring(num + 1, Line.Length - num - 1);
			if (!buNumeric5.IsNumeric(text))
			{
				return false;
			}
			Value = double.Parse(text);
			return true;
		}
		return false;
	}

	public static bool ReadXYZFromString(string Line, bool XEnable, bool YEnable, bool ZEnable, ref Point3D Value)
	{
		string text = Line.ToLower();
		text = text.Replace(",", ".");
		int num = -1;
		int num2 = -1;
		int num3 = -1;
		if (XEnable)
		{
			num = text.IndexOf("x");
			if (num >= 0)
			{
				bool flag = false;
				for (int i = num + 1; i <= text.Length - 1; i++)
				{
					if (!buNumeric5.IsCharBelongToNumerical(text.Substring(i, 1)))
					{
						string s = text.Substring(num + 1, i - num);
						double.TryParse(s, out Value.X);
						i = text.Length;
						flag = true;
					}
				}
				if (!flag)
				{
					string s2 = text.Substring(num + 1, text.Length - 1 - num);
					double.TryParse(s2, out Value.X);
				}
			}
		}
		if (YEnable)
		{
			num2 = text.IndexOf("y");
			if (num2 >= 0)
			{
				bool flag2 = false;
				for (int j = num2 + 1; j <= text.Length - 1; j++)
				{
					if (!buNumeric5.IsCharBelongToNumerical(text.Substring(j, 1)))
					{
						string s3 = text.Substring(num2 + 1, j - num2);
						double.TryParse(s3, out Value.Y);
						j = text.Length;
						flag2 = true;
					}
				}
				if (!flag2)
				{
					string s4 = text.Substring(num2 + 1, text.Length - 1 - num2);
					double.TryParse(s4, out Value.Y);
				}
			}
		}
		if (ZEnable)
		{
			num3 = text.IndexOf("z");
			if (num3 >= 0)
			{
				bool flag3 = false;
				for (int k = num3 + 1; k <= text.Length - 1; k++)
				{
					if (!buNumeric5.IsCharBelongToNumerical(text.Substring(k, 1)))
					{
						string s5 = text.Substring(num3 + 1, k - num3);
						double.TryParse(s5, out Value.Z);
						k = text.Length;
						flag3 = true;
					}
				}
				if (!flag3)
				{
					string s6 = text.Substring(num3 + 1, text.Length - 1 - num3);
					double.TryParse(s6, out Value.Z);
				}
			}
		}
		if (!(num == -1 && num2 == -1 && num3 == -1))
		{
			return true;
		}
		return false;
	}

	public static void RemoveLastNewLineFromString(ref string Str)
	{
		Str = Str.ToString().TrimEnd(Environment.NewLine.ToCharArray());
	}

	public static string RemoveLastNewLineFromString(string Str)
	{
		return Str.ToString().TrimEnd(Environment.NewLine.ToCharArray());
	}

	public static void RemoveCharsFromString(bool Trim, bool Tab, ref List<string> Str)
	{
		for (int i = 0; i <= Str.Count - 1; i++)
		{
			string Str2 = Str[i];
			RemoveCharsFromString(Trim, Tab, new List<string>(), ref Str2);
			Str[i] = Str2;
		}
	}

	public static void RemoveCharsFromString(bool Trim, bool Tab, List<string> RemoveChars, ref List<string> Str)
	{
		for (int i = 0; i <= Str.Count - 1; i++)
		{
			string Str2 = Str[i];
			RemoveCharsFromString(Trim, Tab, RemoveChars, ref Str2);
			Str[i] = Str2;
		}
	}

	public static void RemoveCharsFromString(bool Trim, bool Tab, List<string> RemoveChars, ref string Str)
	{
		try
		{
			if (Trim)
			{
				Str = Str.Trim();
			}
			if (Tab)
			{
				RemoveChars.Add("\t");
			}
			if (RemoveChars.Count > 0)
			{
				for (int i = 0; i <= RemoveChars.Count - 1; i++)
				{
					Str = Str.Replace(RemoveChars[i], "");
				}
			}
			if (Trim)
			{
				Str = Str.Trim();
			}
		}
		catch (Exception mSException)
		{
			string text = "Trim : " + Trim + "- Tab : " + Tab;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static string SpaceChar(int Space)
	{
		return new string(' ', Space);
	}

	public static string DefItem(string strBase, object Value, string Decimal = "f2", string SeperastorPre = " , ", string ValEqual = ": ", string SeperatorNext = "")
	{
		string text = SeperastorPre + strBase + ValEqual;
		text = ((Value.GetType() == typeof(double)) ? (text + ((double)Value).ToString(Decimal)) : ((Value.GetType() == typeof(decimal)) ? (text + ((decimal)Value).ToString(Decimal)) : ((Value.GetType() == typeof(float)) ? (text + ((float)Value).ToString(Decimal)) : (text + Value.ToString()))));
		return text + SeperatorNext;
	}

	public static void ListToSpecificList(string StartKey, string EndKey, bool AddStartEndKey, ArrayList RefList, ref List<List<string>> CalcList)
	{
		try
		{
			List<string> list = new List<string>();
			bool flag = false;
			CalcList = new List<List<string>>();
			for (int i = 0; i <= RefList.Count - 1; i++)
			{
				if (flag)
				{
					RefList[i] = ((string)RefList[i]).Trim();
				}
				if (((string)RefList[i]).Length >= 2 && RefList[i].ToString().Trim() == EndKey && flag)
				{
					if (AddStartEndKey)
					{
						list.Add(EndKey);
					}
					CalcList.Add(list);
					list = new List<string>();
					flag = false;
				}
				if (flag)
				{
					list.Add(RefList[i].ToString());
				}
				if (RefList[i].ToString().Trim() == StartKey)
				{
					flag = true;
					if (AddStartEndKey)
					{
						list.Add(StartKey);
					}
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "StartKey : " + StartKey + " - EndKey : " + EndKey;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void ListToSpecificList(string StartKey, string EndKey, bool AddStartEndKey, ArrayList RefList, ref List<string> CalcList)
	{
		try
		{
			CalcList = new List<string>();
			bool flag = false;
			for (int i = 0; i <= RefList.Count - 1; i++)
			{
				if (flag)
				{
					RefList[i] = RefList[i].ToString().TrimStart();
				}
				if (RefList[i].ToString().Length < 2 || !(RefList[i].ToString().Trim() == EndKey && flag))
				{
					if (flag)
					{
						CalcList.Add(RefList[i].ToString());
					}
					if (RefList[i].ToString().Trim() == StartKey)
					{
						flag = true;
						if (AddStartEndKey)
						{
							CalcList.Add(StartKey);
						}
					}
					continue;
				}
				if (AddStartEndKey)
				{
					CalcList.Add(EndKey);
				}
				flag = false;
				break;
			}
		}
		catch (Exception mSException)
		{
			string text = "StartKey : " + StartKey + " - EndKey : " + EndKey;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void ListToSpecificList(string StartKey, string EndKey, bool AddStartEndKey, ArrayList RefList, ref ArrayList CalcList)
	{
		try
		{
			CalcList = new ArrayList();
			bool flag = false;
			for (int i = 0; i <= RefList.Count - 1; i++)
			{
				if (flag)
				{
					RefList[i] = RefList[i].ToString().TrimStart();
				}
				if (RefList[i].ToString().Length < 2 || !(RefList[i].ToString().Trim() == EndKey && flag))
				{
					if (flag)
					{
						CalcList.Add(RefList[i].ToString());
					}
					if (RefList[i].ToString().Trim() == StartKey)
					{
						flag = true;
						if (AddStartEndKey)
						{
							CalcList.Add(StartKey);
						}
					}
					continue;
				}
				if (AddStartEndKey)
				{
					CalcList.Add(EndKey);
				}
				flag = false;
				break;
			}
		}
		catch (Exception mSException)
		{
			string text = "StartKey : " + StartKey + " - EndKey : " + EndKey;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void ListToSpecificList(string StartKey, string EndKey, bool AddStartEndKey, List<string> RefList, ref List<string> CalcList)
	{
		try
		{
			CalcList = new List<string>();
			bool flag = false;
			for (int i = 0; i <= RefList.Count - 1; i++)
			{
				if (flag)
				{
					RefList[i] = RefList[i].ToString().TrimStart();
				}
				if (RefList[i].ToString().Length < 2 || !(RefList[i].ToString().Trim() == EndKey && flag))
				{
					if (flag)
					{
						CalcList.Add(RefList[i].ToString());
					}
					if (RefList[i].ToString().Trim() == StartKey)
					{
						flag = true;
						if (AddStartEndKey)
						{
							CalcList.Add(StartKey);
						}
					}
					continue;
				}
				if (AddStartEndKey)
				{
					CalcList.Add(EndKey);
				}
				flag = false;
				break;
			}
		}
		catch (Exception mSException)
		{
			string text = "StartKey : " + StartKey + " - EndKey : " + EndKey;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void ListToSpecificList(string StartKey, string EndKey, bool AddStartEndKey, List<string> RefList, ref ArrayList CalcList)
	{
		try
		{
			CalcList = new ArrayList();
			bool flag = false;
			for (int i = 0; i <= RefList.Count - 1; i++)
			{
				if (flag)
				{
					RefList[i] = RefList[i].ToString().TrimStart();
				}
				if (RefList[i].ToString().Length < 2 || !(RefList[i].ToString().Trim() == EndKey && flag))
				{
					if (flag)
					{
						CalcList.Add(RefList[i].ToString());
					}
					if (RefList[i].ToString().Trim() == StartKey)
					{
						flag = true;
						if (AddStartEndKey)
						{
							CalcList.Add(StartKey);
						}
					}
					continue;
				}
				if (AddStartEndKey)
				{
					CalcList.Add(EndKey);
				}
				flag = false;
				break;
			}
		}
		catch (Exception mSException)
		{
			string text = "StartKey : " + StartKey + " - EndKey : " + EndKey;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void ListToSpecificList(string StartKey, string EndKey, bool AddStartEndKey, List<string> RefList, ref List<List<string>> CalcList)
	{
		try
		{
			List<string> list = new List<string>();
			bool flag = false;
			CalcList = new List<List<string>>();
			for (int i = 0; i <= RefList.Count - 1; i++)
			{
				if (flag)
				{
					RefList[i] = RefList[i].Trim();
				}
				if (RefList[i].Length >= 2 && RefList[i].Trim() == EndKey && flag)
				{
					if (AddStartEndKey)
					{
						list.Add(EndKey);
					}
					CalcList.Add(list);
					list = new List<string>();
					flag = false;
				}
				if (flag)
				{
					list.Add(RefList[i]);
				}
				if (RefList[i].Trim() == StartKey)
				{
					flag = true;
					if (AddStartEndKey)
					{
						list.Add(StartKey);
					}
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "StartKey : " + StartKey + " - EndKey : " + EndKey;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void AddFileToRecentFileList(string FileName, int MaxCount, ref ArrayList RecentFiles)
	{
		for (int i = 0; i <= RecentFiles.Count - 1; i++)
		{
			if (RecentFiles[i].ToString() == FileName)
			{
				RecentFiles.RemoveAt(i);
				i = RecentFiles.Count;
			}
		}
		if (RecentFiles.Count > 0 && RecentFiles[0].ToString() != FileName)
		{
			RecentFiles.Insert(0, FileName);
		}
		if (RecentFiles.Count == 0)
		{
			RecentFiles.Add(FileName);
		}
		if (RecentFiles.Count > MaxCount)
		{
			RecentFiles.RemoveRange(6, RecentFiles.Count - 6);
		}
	}

	public static string StringListToString(List<string> SL)
	{
		string text = "";
		StringBuilder stringBuilder = new StringBuilder();
		foreach (string item in SL)
		{
			stringBuilder.Append((object)item);
		}
		return stringBuilder.ToString();
	}

	public static string StringListToString(List<string> SL, bool NewLineEnable)
	{
		string text = "";
		for (int i = 0; i <= SL.Count - 1; i++)
		{
			text += SL[i].ToString();
			if (i < SL.Count - 1)
			{
				text = (NewLineEnable ? (text + Environment.NewLine) : (text + " "));
			}
		}
		return text;
	}

	public static string ArrayListToString(ArrayList AL)
	{
		string text = "";
		StringBuilder stringBuilder = new StringBuilder();
		foreach (object item in AL)
		{
			stringBuilder.Append(item);
		}
		return stringBuilder.ToString();
	}

	public static string ArrayListToString(ArrayList AL, bool NewLineEnable)
	{
		string text = "";
		for (int i = 0; i <= AL.Count - 1; i++)
		{
			text += AL[i].ToString();
			if (i < AL.Count - 1)
			{
				text = (NewLineEnable ? (text + Environment.NewLine) : (text + " "));
			}
		}
		return text;
	}

	public static void StringToArrayListByNewLine(string RefString, ref ArrayList Lines)
	{
		SplitStringByNewLine(RefString, ref Lines);
	}

	public static void StringToListByNewLine(string RefString, ref List<string> Lines)
	{
		SplitStringByNewLine(RefString, ref Lines);
	}

	public static void StringToArrayByNewLine(string RefString, ref string[] Lines)
	{
		Lines = RefString.Split(new string[2] { "\r\n", "\n" }, StringSplitOptions.None);
	}

	public static void AddToArrayList(ArrayList refAL, ref ArrayList AddedAL)
	{
		for (int i = 0; i <= refAL.Count - 1; i++)
		{
			AddedAL.Add(refAL[i]);
		}
	}

	public static void SplitStringByNewLine(string RefString, ref List<string> Lines)
	{
		string[] array = null;
		Lines = new List<string>();
		array = RefString.Split(new string[2] { "\r\n", "\n" }, StringSplitOptions.None);
		for (int i = 0; i <= array.Length - 1; i++)
		{
			Lines.Add(array[i]);
		}
	}

	public static void SplitStringByNewLine(string RefString, ref ArrayList Lines)
	{
		string[] array = null;
		Lines = new ArrayList();
		array = RefString.Split(new string[2] { "\r\n", "\n" }, StringSplitOptions.None);
		for (int i = 0; i <= array.Length - 1; i++)
		{
			Lines.Add(array[i]);
		}
	}

	public static void SplitStringByRefWord(string RefString, string RefWord, ref string[] Lines)
	{
		Lines = RefString.Split(new string[1] { RefWord }, StringSplitOptions.RemoveEmptyEntries);
	}

	public static void AddStringsToList(string S1, ref List<string> SL, bool ClearList = true, string S2 = "", string S3 = "", string S4 = "", string S5 = "", string S6 = "", string S7 = "", string S8 = "", string S9 = "", string S10 = "")
	{
		if (SL == null)
		{
			SL = new List<string>();
		}
		if (ClearList)
		{
			SL.Clear();
		}
		if (S1.Length > 0)
		{
			SL.Add(S1);
		}
		if (S2.Length > 0)
		{
			SL.Add(S2);
		}
		if (S3.Length > 0)
		{
			SL.Add(S3);
		}
		if (S4.Length > 0)
		{
			SL.Add(S4);
		}
		if (S5.Length > 0)
		{
			SL.Add(S5);
		}
		if (S6.Length > 0)
		{
			SL.Add(S6);
		}
		if (S7.Length > 0)
		{
			SL.Add(S7);
		}
		if (S8.Length > 0)
		{
			SL.Add(S8);
		}
		if (S9.Length > 0)
		{
			SL.Add(S9);
		}
		if (S10.Length > 0)
		{
			SL.Add(S10);
		}
	}

	public static void AddStringsToList1(string S1, ref List<string> SL, bool ClearList = true, string S2 = "", string S3 = "", string S4 = "", string S5 = "")
	{
		if (SL == null)
		{
			SL = new List<string>();
		}
		if (ClearList)
		{
			SL.Clear();
		}
		if (S1.Length > 0)
		{
			SL.Add(S1);
		}
		if (S2.Length > 0)
		{
			SL.Add(S2);
		}
		if (S3.Length > 0)
		{
			SL.Add(S3);
		}
		if (S4.Length > 0)
		{
			SL.Add(S4);
		}
		if (S5.Length > 0)
		{
			SL.Add(S5);
		}
	}

	public static void AddStringsToList1(string S1, ref List<string> SL, bool ClearList = true, string S2 = "")
	{
		if (SL == null)
		{
			SL = new List<string>();
		}
		if (ClearList)
		{
			SL.Clear();
		}
		if (S1.Length > 0)
		{
			SL.Add(S1);
		}
		if (S2.Length > 0)
		{
			SL.Add(S2);
		}
	}

	public static void GetItemsAccordingToTheLang(List<string> RefList, int Language, List<string> CalcList)
	{
		try
		{
			if (RefList.Count <= 0)
			{
				return;
			}
			for (int i = 0; i <= RefList.Count - 1; i++)
			{
				string[] array = RefList[i].Split('|');
				if (array.Length <= 1)
				{
					string[] array2 = RefList[i].Split(';');
					if (Language <= array2.Length - 1)
					{
						CalcList.Add(array2[Language].Trim());
					}
				}
				else
				{
					string[] array3 = array[1].Split(';');
					if (Language <= array3.Length - 1)
					{
						CalcList.Add(array3[Language].Trim());
					}
				}
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("GetItemsAccordingToTheLang", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public static void GetItemsAccordingToTheLang(List<string> RefList, int Language, ref List<string> CalcList)
	{
		try
		{
			if (RefList.Count <= 0)
			{
				return;
			}
			for (int i = 0; i <= RefList.Count - 1; i++)
			{
				string[] array = RefList[i].Split('|');
				if (array.Length <= 1)
				{
					string[] array2 = RefList[i].Split(';');
					if (Language <= array2.Length - 1)
					{
						CalcList.Add(array2[Language].Trim());
					}
				}
				else
				{
					string[] array3 = array[1].Split(';');
					if (Language <= array3.Length - 1)
					{
						CalcList.Add(array3[Language].Trim());
					}
				}
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("GetItemsAccordingToTheLang", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public static void GetItemsAccordingToTheLang(List<string> RefList, int Language, ref ArrayList CalcList)
	{
		try
		{
			if (RefList.Count <= 0)
			{
				return;
			}
			for (int i = 0; i <= RefList.Count - 1; i++)
			{
				string[] array = RefList[i].Split('|');
				if (array.Length <= 1)
				{
					string[] array2 = RefList[i].Split(';');
					if (Language <= array2.Length - 1)
					{
						CalcList.Add(array2[Language].Trim());
					}
				}
				else
				{
					string[] array3 = array[1].Split(';');
					if (Language <= array3.Length - 1)
					{
						CalcList.Add(array3[Language].Trim());
					}
				}
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("GetItemsAccordingToTheLang", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public static void GetItemsAccordingToTheLang(string RefString, int Language, ref string CalcStirng)
	{
		try
		{
			string[] array = RefString.Split('|');
			if (array.Length <= 1)
			{
				string[] array2 = RefString.Split(';');
				if (Language <= array2.Length - 1)
				{
					CalcStirng = array2[Language].Trim();
				}
			}
			else
			{
				string[] array3 = array[1].Split(';');
				if (Language <= array3.Length - 1)
				{
					CalcStirng = array3[Language].Trim();
				}
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("GetItemsAccordingToTheLang", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public static string FindStringBetweenTwoChar(string RefString, string FirstStr, string SecondStr)
	{
		try
		{
			int num = 0;
			int num2 = 0;
			num = RefString.IndexOf(FirstStr);
			num2 = RefString.IndexOf(SecondStr);
			if (num != num2)
			{
				if (!(num >= 0 && num2 >= 0))
				{
					return "";
				}
				if (num2 <= num)
				{
					return RefString.Substring(num2 + FirstStr.Length, num - num2 - FirstStr.Length);
				}
				return RefString.Substring(num + FirstStr.Length, num2 - num - FirstStr.Length);
			}
			return "";
		}
		catch (Exception mSException)
		{
			string text = "RefString : " + RefString + " - FirstStr : " + FirstStr + " - SecondStr : " + SecondStr;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
			return "";
		}
	}

	public static bool isCharsInStringList(string refString, List<string> StringList)
	{
		for (int i = 0; i <= StringList.Count - 1; i++)
		{
			if (StringList[i] == refString)
			{
				return true;
			}
		}
		return false;
	}

	public static List<string> Copy(List<string> refList)
	{
		List<string> list = new List<string>();
		if (refList != null)
		{
			for (int i = 0; i <= refList.Count - 1; i++)
			{
				list.Add(refList[i]);
			}
		}
		return list;
	}

	public static ArrayList Copy(ArrayList refList)
	{
		ArrayList arrayList = new ArrayList();
		if (refList != null)
		{
			for (int i = 0; i <= refList.Count - 1; i++)
			{
				arrayList.Add(refList[i]);
			}
		}
		return arrayList;
	}

	public static int TotalLineCountOfString(string refString)
	{
		try
		{
			string[] array = refString.Split('\n');
			int result = array.Length;
			array = null;
			return result;
		}
		catch (Exception)
		{
			return 0;
		}
	}

	public static void MoveUp(ref List<string> refList, int Index)
	{
		if ((refList.Count >= 0 && Index > 0) & (Index <= refList.Count - 1))
		{
			string item = refList[Index];
			refList.RemoveAt(Index);
			Index--;
			refList.Insert(Index, item);
		}
	}

	public static void MoveDown(ref List<string> refList, int Index)
	{
		if ((refList.Count >= 0) & (Index <= refList.Count - 2) & (Index <= refList.Count - 1))
		{
			string item = refList[Index];
			refList.RemoveAt(Index);
			Index++;
			refList.Insert(Index, item);
		}
	}

	public static List<string> ReadXmlItem(string StartString, string EndString, ArrayList SourceList)
	{
		try
		{
			List<string> list = new List<string>();
			bool flag = false;
			for (int i = 0; i <= SourceList.Count - 1; i++)
			{
				if (!(SourceList[i].ToString() == EndString))
				{
					if (flag)
					{
						list.Add(SourceList[i].ToString());
					}
					if (SourceList[i].ToString() == StartString)
					{
						flag = true;
					}
					continue;
				}
				return list;
			}
			return list;
		}
		catch (Exception mSException)
		{
			buLog.addLog("ReadXmlItem", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
			return new List<string>();
		}
	}

	public static List<string> ReadXmlItem(string StartString, string EndString, List<string> SourceList)
	{
		try
		{
			List<string> list = new List<string>();
			bool flag = false;
			for (int i = 0; i <= SourceList.Count - 1; i++)
			{
				if (!(SourceList[i].ToString().Trim() == EndString))
				{
					if (flag)
					{
						list.Add(SourceList[i].ToString().Trim());
					}
					SourceList[i].ToString().Trim();
					if (SourceList[i].ToString().Trim() == StartString)
					{
						flag = true;
					}
					continue;
				}
				return list;
			}
			return list;
		}
		catch (Exception mSException)
		{
			buLog.addLog("ReadXmlItem", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
			return new List<string>();
		}
	}

	public static void ReadXmlItem(string StartString, string EndString, ArrayList SourceList, ref ArrayList CalcList)
	{
		try
		{
			CalcList = new ArrayList();
			bool flag = false;
			for (int i = 0; i <= SourceList.Count - 1 && !(SourceList[i].ToString().Trim() == EndString); i++)
			{
				if (flag)
				{
					CalcList.Add(SourceList[i].ToString().Trim());
				}
				SourceList[i].ToString().Trim();
				if (SourceList[i].ToString().Trim() == StartString)
				{
					flag = true;
				}
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("ReadXmlItem", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public static void ReadXmlItem(string StartString, string EndString, List<string> SourceList, ref List<List<string>> DecodeList)
	{
		try
		{
			bool flag = false;
			List<string> list = new List<string>();
			DecodeList = new List<List<string>>();
			for (int i = 0; i <= SourceList.Count - 1; i++)
			{
				if (SourceList[i].ToString() == EndString)
				{
					DecodeList.Add(list);
					flag = false;
					list = new List<string>();
				}
				if (flag)
				{
					list.Add(SourceList[i].ToString());
				}
				if (SourceList[i].ToString() == StartString)
				{
					flag = true;
				}
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("ReadXmlItem", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}
}
