using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using buClass;

namespace buCore;

public class buString
{
	private static string string_0 = "fduyfuFDSGERTHSAF-*05435/&%(hgfdhgfHGFHGFHvxcvcvTREQWEFVFDNB gR E%YT%E";

	private static string string_1 = "QWEFGHLJHGFhjklopoıuygtfc-*098h?=)(/TFDERTYUI)OKNBVFDRErd345678uhgfdXCVBHJ/&%RDW^+%&/()=)(/TRFCVBNYTrEDSX";

	private static string string_2 = "";

	private static string string_3 = "";

	private static double double_0 = 0.0;

	private static double double_1 = 0.0;

	public buString()
	{
		if (!buVector.smethod_0("buString"))
		{
			throw new RegisterException("buString");
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

	public static void StringToArrayByNewLine(string RefString, ref string[] Lines)
	{
		Lines = RefString.Split(new string[2] { "\r\n", "\n" }, StringSplitOptions.None);
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

	public static void GetWarningInfo(List<string> WarningList, int WarningID, string WarningText, string WarningAxis, double WarningCode, int WarningOption, string WarningAux, ref string ResultWarning, ref AppWarning Wars)
	{
		try
		{
			string text = "Axis [ " + WarningAxis + " ]";
			string text2 = "";
			string text3 = "";
			string text4 = "";
			string text5 = "";
			string text6 = "";
			if (WarningCode != 0.0)
			{
				text2 = " | Code = " + WarningCode;
			}
			if (WarningOption != 0)
			{
				text3 = " | Option = " + WarningOption;
			}
			if (WarningAux.Trim().Length > 0)
			{
				text4 = " | Aux = " + WarningAux;
			}
			if (WarningAxis.Trim().ToLower() == "system")
			{
				text = "System";
			}
			text6 = WarningAxis;
			text5 = WarningText;
			if (WarningID > WarningList.Count - 1)
			{
				ResultWarning = text + WarningAxis + " : " + WarningText + " - ID : " + WarningID;
			}
			else
			{
				text5 = WarningList[WarningID];
				ResultWarning = text + WarningAxis + " : " + WarningList[WarningID] + " - ID : " + WarningID + text2 + text3 + text4;
			}
			Wars.Aux = text4;
			Wars.Axis = text6;
			Wars.Code = WarningCode;
			Wars.ID = WarningID;
			Wars.Option = WarningOption;
			Wars.Text = text5;
		}
		catch (Exception mSException)
		{
			string text7 = "WarningList : " + WarningList.Count + " - WarningID : " + WarningID + " - WarningText : " + WarningText + " - WarningAxis : " + WarningAxis.ToString() + " - WarningAux : " + WarningAux.ToString() + " - WarningCode : " + WarningCode;
			buLog.addLog(text7, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text7);
		}
	}

	public static void GetAlarmInfo(List<string> AlarmList, int AlarmID, string AlarmText, string AlarmAxis, double AlarmCode, int AlarmOption, string AlarmAux, ref string ResultAlarm, ref AppAlarm Alrm)
	{
		try
		{
			string text = "Axis [ " + AlarmAxis + " ]";
			string text2 = "";
			string text3 = "";
			string text4 = "";
			string text5 = "";
			string text6 = "";
			if (AlarmCode != 0.0)
			{
				text2 = " | Code = " + AlarmCode;
			}
			if (AlarmOption != 0)
			{
				text3 = " | Option = " + AlarmOption;
			}
			if (AlarmAux.Trim().Length > 0)
			{
				text4 = " | Aux = " + AlarmAux;
			}
			if (AlarmAxis.Trim().ToLower() == "system")
			{
				text = "System";
			}
			text6 = AlarmAxis;
			text5 = AlarmText;
			if (AlarmID > AlarmList.Count - 1)
			{
				ResultAlarm = text + AlarmAxis + " : " + AlarmText + " - ID = " + AlarmID;
			}
			else
			{
				text5 = AlarmList[AlarmID];
				ResultAlarm = text + " : " + AlarmList[AlarmID] + " - ID = " + AlarmID + text2 + text3 + text4;
			}
			Alrm.Aux = text4;
			Alrm.Axis = text6;
			Alrm.Code = AlarmCode;
			Alrm.ID = AlarmID;
			Alrm.Option = AlarmOption;
			Alrm.Text = text5;
		}
		catch (Exception mSException)
		{
			string text7 = "AlarmList : " + AlarmList.Count + " - AlarmID : " + AlarmID + " - AlarmText : " + AlarmText + " - AlarmAxis : " + AlarmAxis.ToString() + " - AlarmAux : " + AlarmAux.ToString() + " - AlarmCode : " + AlarmCode;
			buLog.addLog(text7, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text7);
		}
	}

	public static string SpaceChar(int Space)
	{
		return new string(' ', Space);
	}

	public static string StringFromBool(bool State, string TrueString, string FalseString)
	{
		if (!State)
		{
			return FalseString;
		}
		return TrueString;
	}

	public static string InchValueToString(double Value, int Base)
	{
		int num = Convert.ToInt32(buNumeric.RoundToLower(Value));
		double num2 = Value - (double)num;
		int num3 = Convert.ToInt32((double)Base * num2);
		return num + "\\" + num3;
	}

	public static double StringToInchValue(string Value, int Base)
	{
		string[] array = Value.Split('\\');
		if (array == null)
		{
			return 0.0;
		}
		if (array.Length != 1)
		{
			if (array.Length != 2)
			{
				return 0.0;
			}
			double result = 0.0;
			double result2 = 0.0;
			double.TryParse(array[0], out result);
			double.TryParse(array[1], out result2);
			return result + result2 / 16.0;
		}
		double result3 = 0.0;
		double.TryParse(array[0], out result3);
		return result3;
	}

	public static string CharToString(int Unicode)
	{
		return ((char)Unicode).ToString();
	}

	public static void ReadCharValue(string FullLine, string Chr, ref double Value)
	{
		try
		{
			int num = FullLine.IndexOf(Chr);
			string text = "";
			bool flag = false;
			for (int i = num + 1; i <= FullLine.Length - 1; i++)
			{
				string value = FullLine.Substring(i, 1);
				flag = false;
				if (buNumeric.IsNumeric(value))
				{
					flag = true;
				}
				if (!flag)
				{
					text = FullLine.Substring(num + 1, i - (num + 1));
					if (buNumeric.IsNumeric(text))
					{
						Value = double.Parse(text);
					}
					return;
				}
			}
			text = FullLine.Substring(num + 1, FullLine.Length - num - 1);
			if (buNumeric.IsNumeric(text))
			{
				Value = double.Parse(text);
			}
		}
		catch (Exception mSException)
		{
			string text2 = "FullLine : " + FullLine.ToString() + "- Chr : " + Chr.ToString();
			buLog.addLog(text2, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text2);
		}
	}

	public static bool ReadStringValue(string Char, string Line, ref double Value)
	{
		bool flag = false;
		string text = "";
		int num = Line.IndexOf(Char);
		for (int i = num + 1; i <= Line.Length - 1; i++)
		{
			string text2 = Line.Substring(i, 1);
			if (!(flag = buNumeric.IsNumeric(text2)))
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
				if (!buNumeric.IsNumeric(text))
				{
					return false;
				}
				Value = double.Parse(text);
				return true;
			}
		}
		text = Line.Substring(num + 1, Line.Length - num - 1);
		if (!buNumeric.IsNumeric(text))
		{
			return false;
		}
		Value = double.Parse(text);
		return true;
	}

	public static bool ReadXYZFromString(string Line, bool XEnable, bool YEnable, bool ZEnable, ref Pnt3D Value)
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
					if (!buNumeric.IsCharBelongToNumerical(text.Substring(i, 1)))
					{
						string s = text.Substring(num + 1, i - num);
						double.TryParse(s, out Value.X);
						i = text.Length;
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
					if (!buNumeric.IsCharBelongToNumerical(text.Substring(j, 1)))
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
		if (XEnable)
		{
			num3 = text.IndexOf("y");
			if (num3 >= 0)
			{
				bool flag3 = false;
				for (int k = num3 + 1; k <= text.Length - 1; k++)
				{
					if (!buNumeric.IsCharBelongToNumerical(text.Substring(k, 1)))
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

	public static string SetDialogFileExtensionFilters(ArrayList ExtensionList)
	{
		try
		{
			string text = "";
			for (int i = 0; i <= ExtensionList.Count - 1; i++)
			{
				text = ((i == 0) ? ExtensionList[i].ToString() : (text + "|" + ExtensionList[i].ToString()));
			}
			return text;
		}
		catch (Exception mSException)
		{
			string text2 = "ExtensionList : " + ExtensionList.Count;
			buLog.addLog(text2, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text2);
			return "";
		}
	}

	public static string DecimalString(int Decimal)
	{
		try
		{
			if (Decimal < 0)
			{
				return "f0";
			}
			return "f" + Decimal;
		}
		catch (Exception mSException)
		{
			string text = "Decimal : " + Decimal;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
			return "";
		}
	}
}
