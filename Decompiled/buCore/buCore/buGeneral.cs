using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using buClass;

namespace buCore;

public class buGeneral
{
	public buGeneral()
	{
		if (!buVector.smethod_0("buGeneral"))
		{
			throw new RegisterException("buGeneral");
		}
	}

	public static void ExchangeDatas(ref double FirstData, ref double SecondData)
	{
		try
		{
			double num = 0.0;
			num = FirstData;
			FirstData = SecondData;
			SecondData = num;
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, "");
		}
	}

	public static void ExchangeDatas(ref int FirstData, ref int SecondData)
	{
		try
		{
			int num = 0;
			num = FirstData;
			FirstData = SecondData;
			SecondData = num;
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, "");
		}
	}

	public static void ExchangeDatas(ref float FirstData, ref float SecondData)
	{
		try
		{
			float num = 0f;
			num = FirstData;
			FirstData = SecondData;
			SecondData = num;
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, "");
		}
	}

	public static void ExchangeDatas(ref object FirstData, ref object SecondData)
	{
		try
		{
			object obj = 0;
			obj = FirstData;
			FirstData = SecondData;
			SecondData = obj;
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, "");
		}
	}

	public static void ExchangeDatas(ref Pnt3D FirstData, ref Pnt3D SecondData)
	{
		try
		{
			Pnt3D pnt3D = new Pnt3D();
			pnt3D = new Pnt3D(FirstData);
			FirstData = new Pnt3D(SecondData);
			SecondData = new Pnt3D(pnt3D);
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, "");
		}
	}

	public static void ExchangeDatas(ref Pnt2D FirstData, ref Pnt2D SecondData)
	{
		try
		{
			Pnt2D pnt2D = new Pnt2D();
			pnt2D = new Pnt2D(FirstData);
			FirstData = new Pnt2D(SecondData);
			SecondData = new Pnt2D(pnt2D);
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, "");
		}
	}

	public static void ExchangeDatas(ref List<Pnt3D> FirstData, ref List<Pnt3D> SecondData)
	{
		try
		{
			List<Pnt3D> list = new List<Pnt3D>();
			for (int i = 0; i <= FirstData.Count - 1; i++)
			{
				list.Add(new Pnt3D(FirstData[i]));
			}
			FirstData.Clear();
			for (int j = 0; j <= SecondData.Count - 1; j++)
			{
				FirstData.Add(new Pnt3D(SecondData[j]));
			}
			SecondData.Clear();
			for (int k = 0; k <= list.Count - 1; k++)
			{
				SecondData.Add(new Pnt3D(list[k]));
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, "");
		}
	}

	public static bool SwapBool(bool RefVal)
	{
		if (!RefVal)
		{
			return true;
		}
		return false;
	}

	public static void SwapBool(ref bool RefVal)
	{
		if (!RefVal)
		{
			RefVal = true;
		}
		else
		{
			RefVal = false;
		}
	}

	public static void CopyLists(List<int> SourceList, ref List<int> TargetList)
	{
		try
		{
			TargetList.Clear();
			if (SourceList.Count > 0)
			{
				for (int i = 0; i <= SourceList.Count - 1; i++)
				{
					TargetList.Add(SourceList[i]);
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "SourceList : " + SourceList.Count;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void AddLists(List<int> SourceList, ref List<int> TargetList)
	{
		try
		{
			if (SourceList.Count > 0)
			{
				for (int i = 0; i <= SourceList.Count - 1; i++)
				{
					TargetList.Add(SourceList[i]);
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "SourceList : " + SourceList.Count;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void CopyLists(List<double> SourceList, ref List<double> TargetList)
	{
		try
		{
			TargetList.Clear();
			if (SourceList.Count > 0)
			{
				for (int i = 0; i <= SourceList.Count - 1; i++)
				{
					TargetList.Add(SourceList[i]);
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "SourceList : " + SourceList.Count;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void AddLists(List<double> SourceList, ref List<double> TargetList)
	{
		try
		{
			if (SourceList.Count > 0)
			{
				for (int i = 0; i <= SourceList.Count - 1; i++)
				{
					TargetList.Add(SourceList[i]);
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "SourceList : " + SourceList.Count;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void CopyLists(List<string> SourceList, ref List<string> TargetList)
	{
		try
		{
			TargetList.Clear();
			if (SourceList.Count > 0)
			{
				for (int i = 0; i <= SourceList.Count - 1; i++)
				{
					TargetList.Add(SourceList[i]);
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "SourceList : " + SourceList.Count;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static List<string> CopyLists(List<string> SourceList)
	{
		try
		{
			List<string> list = new List<string>();
			if (SourceList.Count > 0)
			{
				for (int i = 0; i <= SourceList.Count - 1; i++)
				{
					list.Add(SourceList[i]);
				}
				return list;
			}
			return list;
		}
		catch (Exception mSException)
		{
			string text = "SourceList : " + SourceList.Count;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
			return new List<string>();
		}
	}

	public static void CopyLists(List<string> SourceList, ref ArrayList TargetList)
	{
		try
		{
			TargetList.Clear();
			if (SourceList.Count > 0)
			{
				for (int i = 0; i <= SourceList.Count - 1; i++)
				{
					TargetList.Add(SourceList[i]);
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "SourceList : " + SourceList.Count;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void AddLists(List<Pnt3D> SourceList, ref List<Pnt3D> TargetList)
	{
		try
		{
			if (SourceList.Count > 0)
			{
				for (int i = 0; i <= SourceList.Count - 1; i++)
				{
					TargetList.Add(new Pnt3D(SourceList[i]));
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "SourceList : " + SourceList.Count;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void CopyLists(List<Pnt3D> SourceList, ref List<Pnt3D> TargetList)
	{
		try
		{
			TargetList.Clear();
			if (SourceList.Count > 0)
			{
				for (int i = 0; i <= SourceList.Count - 1; i++)
				{
					TargetList.Add(new Pnt3D(SourceList[i]));
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "SourceList : " + SourceList.Count;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void CopyLists(List<List<Pnt3D>> SourceList, ref List<Pnt3D> TargetList)
	{
		try
		{
			if (SourceList == null)
			{
				return;
			}
			TargetList = new List<Pnt3D>();
			for (int i = 0; i <= SourceList.Count - 1; i++)
			{
				for (int j = 0; j <= SourceList[i].Count - 1; j++)
				{
					TargetList.Add(new Pnt3D(SourceList[i][j]));
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "SourceList : " + SourceList.Count;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void CopyLists(List<Pnt3D> SourceList, ref ArrayList TargetList)
	{
		try
		{
			TargetList.Clear();
			if (SourceList.Count > 0)
			{
				for (int i = 0; i <= SourceList.Count - 1; i++)
				{
					TargetList.Add(new Pnt3D(SourceList[i]));
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "SourceList : " + SourceList.Count;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void CopyLists(ArrayList SourceList, ref ArrayList TargetList)
	{
		try
		{
			TargetList.Clear();
			if (SourceList.Count > 0)
			{
				for (int i = 0; i <= SourceList.Count - 1; i++)
				{
					TargetList.Add(SourceList[i]);
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "SourceList : " + SourceList.Count;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void CopyLists(List<Pnt3D>[] SourceList, ref List<Pnt3D>[] TargetList)
	{
		try
		{
			if (SourceList == null)
			{
				return;
			}
			TargetList = new List<Pnt3D>[SourceList.Length];
			for (int i = 0; i <= SourceList.Length - 1; i++)
			{
				TargetList[i] = new List<Pnt3D>();
				for (int j = 0; j <= SourceList[i].Count - 1; j++)
				{
					TargetList[i].Add(new Pnt3D(SourceList[i][j]));
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "SourceList : " + SourceList.Length;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void AddLists(List<eEntities> SourceList, ref List<eEntities> TargetList)
	{
		try
		{
			if (SourceList.Count > 0)
			{
				for (int i = 0; i <= SourceList.Count - 1; i++)
				{
					eEntities eEntities2 = new eEntities();
					eEntities2 = eEntities.CopyEntity(SourceList[i]);
					TargetList.Add(eEntities2);
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "SourceList : " + SourceList.Count;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void CopyLists(List<eEntities> SourceList, ref List<eEntities> TargetList)
	{
		try
		{
			TargetList = new List<eEntities>();
			if (SourceList.Count > 0)
			{
				for (int i = 0; i <= SourceList.Count - 1; i++)
				{
					eEntities eEntities2 = new eEntities();
					eEntities2 = eEntities.CopyEntity(SourceList[i]);
					TargetList.Add(eEntities2);
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "SourceList : " + SourceList.Count;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void CopyLists(List<eEntities>[] SourceList, ref List<eEntities>[] TargetList)
	{
		try
		{
			if (SourceList == null)
			{
				return;
			}
			TargetList = new List<eEntities>[SourceList.Length];
			for (int i = 0; i <= SourceList.Length - 1; i++)
			{
				TargetList[i] = new List<eEntities>();
				for (int j = 0; j <= SourceList[i].Count - 1; j++)
				{
					eEntities eEntities2 = new eEntities();
					eEntities2 = eEntities.CopyEntity(SourceList[i][j]);
					TargetList[i].Add(eEntities2);
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "SourceList : " + SourceList.Length;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void CopyLists(List<List<eEntities>> SourceList, ref List<List<eEntities>> TargetList)
	{
		try
		{
			if (SourceList == null)
			{
				return;
			}
			TargetList = new List<List<eEntities>>();
			for (int i = 0; i <= SourceList.Count - 1; i++)
			{
				List<eEntities> list = new List<eEntities>();
				for (int j = 0; j <= SourceList[i].Count - 1; j++)
				{
					eEntities eEntities2 = new eEntities();
					eEntities2 = eEntities.CopyEntity(SourceList[i][j]);
					list.Add(eEntities2);
				}
				TargetList.Add(list);
			}
		}
		catch (Exception mSException)
		{
			string text = "SourceList : " + SourceList.Count;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void CopyLists(List<List<eEntities>> SourceList, ref List<eEntities> TargetList)
	{
		try
		{
			if (SourceList == null)
			{
				return;
			}
			TargetList = new List<eEntities>();
			for (int i = 0; i <= SourceList.Count - 1; i++)
			{
				for (int j = 0; j <= SourceList[i].Count - 1; j++)
				{
					eEntities eEntities2 = new eEntities();
					eEntities2 = eEntities.CopyEntity(SourceList[i][j]);
					TargetList.Add(eEntities2);
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "SourceList : " + SourceList.Count;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void AddLists(List<List<eEntities>> SourceList, ref List<eEntities> TargetList)
	{
		try
		{
			if (SourceList == null)
			{
				return;
			}
			for (int i = 0; i <= SourceList.Count - 1; i++)
			{
				for (int j = 0; j <= SourceList[i].Count - 1; j++)
				{
					eEntities eEntities2 = new eEntities();
					eEntities2 = eEntities.CopyEntity(SourceList[i][j]);
					TargetList.Add(eEntities2);
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "SourceList : " + SourceList.Count;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void CopyLists(List<Pnt9D> SourceList, ref List<Pnt9D> TargetList)
	{
		try
		{
			TargetList.Clear();
			if (SourceList.Count > 0)
			{
				for (int i = 0; i <= SourceList.Count - 1; i++)
				{
					TargetList.Add(new Pnt9D(SourceList[i]));
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "SourceList : " + SourceList.Count;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static object EnumValueFromInt(object EnumVar, int Index)
	{
		try
		{
			return (Enum)Enum.ToObject(EnumVar.GetType(), Index);
		}
		catch (Exception mSException)
		{
			string text = "EnumVar : " + EnumVar.ToString() + " - Index: " + Index;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
			return null;
		}
	}

	public static object EnumValueFromString(object EnumVar, string EnumString)
	{
		try
		{
			Type type = EnumVar.GetType();
			return Enum.Parse(type, EnumString, ignoreCase: true);
		}
		catch (Exception mSException)
		{
			string text = "EnumVar : " + EnumVar.ToString() + " - EnumString: " + EnumString.ToString();
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
			return null;
		}
	}

	public static void GetEnumTypeValues(object EnumType, ref ArrayList EnumItems)
	{
		try
		{
			Array array = null;
			if (EnumType != null && EnumType.GetType().IsEnum)
			{
				array = Enum.GetValues(EnumType.GetType());
				EnumItems.Clear();
				for (int i = 0; i <= array.Length - 1; i++)
				{
					EnumItems.Add(array.GetValue(i));
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "EnumType : " + EnumType;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void ArrayIndexIncrease(ref int ActualIndex, int MaxValue, int IncreaseStep, int VisibleCount)
	{
		try
		{
			if (ActualIndex + IncreaseStep <= MaxValue)
			{
				ActualIndex += IncreaseStep;
			}
			else
			{
				ActualIndex = MaxValue - VisibleCount;
			}
		}
		catch (Exception mSException)
		{
			string text = "ActualIndex : " + ActualIndex + " - MaxValue: " + MaxValue + " - IncreaseStep: " + IncreaseStep + " - VisibleCount: " + VisibleCount;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void ArrayIndexDecrease(ref int ActualIndex, int MinValue, int DecreaseStep, int VisibleCount)
	{
		try
		{
			if (ActualIndex - DecreaseStep >= MinValue)
			{
				ActualIndex -= DecreaseStep;
			}
			else
			{
				ActualIndex = MinValue;
			}
		}
		catch (Exception mSException)
		{
			string text = "ActualIndex : " + ActualIndex + " - MinValue: " + MinValue + " - DecreaseStep: " + DecreaseStep + " - VisibleCount: " + VisibleCount;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static ShortCutKey DecodeShortKey(string ShortKeyCode)
	{
		try
		{
			string text = ShortKeyCode.Replace("ShortKey", "");
			text = text.Replace("(", "");
			text = text.Replace(")", "");
			string[] array = text.Split(',');
			ShortCutKey shortCutKey = new ShortCutKey();
			if (array != null && array.Length == 4)
			{
				shortCutKey.FirstControlKey = (ControlKeys)EnumValueFromString(shortCutKey.FirstControlKey, array[0].Trim());
				shortCutKey.SecondControlKey = (ControlKeys)EnumValueFromString(shortCutKey.SecondControlKey, array[1].Trim());
				string text2 = array[2].Trim().ToUpper();
				if ((text2 == "0") | (text2 == "1") | (text2 == "2") | (text2 == "3") | (text2 == "4") | (text2 == "5") | (text2 == "6") | (text2 == "7") | (text2 == "8") | (text2 == "9"))
				{
					text2 = "Key" + text2;
				}
				if ((text2 == "F0") | (text2 == "F1") | (text2 == "F2") | (text2 == "F3") | (text2 == "F4") | (text2 == "F5") | (text2 == "F6") | (text2 == "F7") | (text2 == "F8") | (text2 == "F9") | (text2 == "F10") | (text2 == "F11") | (text2 == "F12"))
				{
					text2 = "Key" + text2;
				}
				if ((text2 == "SPACE") | (text2 == "ESC") | (text2 == "ENTER") | (text2 == "DELETE") | (text2 == "HOME") | (text2 == "END") | (text2 == "PAGEUP") | (text2 == "PAGEDOWN"))
				{
					text2 = "Key" + text2;
				}
				shortCutKey.Key = (ActionKeys)EnumValueFromString(shortCutKey.Key, text2.Trim());
				shortCutKey.Command = array[3].Trim();
			}
			return shortCutKey;
		}
		catch (Exception mSException)
		{
			buLog.addLog(ShortKeyCode, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, ShortKeyCode);
			return new ShortCutKey();
		}
	}

	public static MacroBase DecodeMacro(string MacroCode)
	{
		try
		{
			MacroBase macroBase = new MacroBase();
			string[] array = MacroCode.Split('=');
			string text = "";
			if (array != null)
			{
				if (array.Length == 1)
				{
					macroBase.Command = array[0].Trim();
				}
				if (array.Length == 2)
				{
					macroBase.Command = array[0].Trim();
					text = array[1].Replace("(", "");
					text = text.Replace(")", "");
					text = text.Trim();
					if (text.Length > 0)
					{
						string[] array2 = text.Split(',');
						if (array2 != null)
						{
							for (int i = 0; i <= array2.Length - 1; i++)
							{
								macroBase.Args.Add(array2[i]);
							}
						}
					}
				}
			}
			return macroBase;
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, "");
			return new MacroBase();
		}
	}

	public static void CultureSettings()
	{
		int[] currencyGroupSizes = new int[3] { 3, 2, 2 };
		CultureInfo cultureInfo = new CultureInfo("en-US");
		new DateTimeFormatInfo();
		NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
		numberFormatInfo.CurrencySymbol = "Rs";
		numberFormatInfo.CurrencyDecimalDigits = 3;
		numberFormatInfo.CurrencyDecimalSeparator = ".";
		numberFormatInfo.CurrencyGroupSizes = currencyGroupSizes;
		numberFormatInfo.CurrencyGroupSeparator = ",";
		numberFormatInfo.PositiveInfinitySymbol = " ";
		cultureInfo.NumberFormat = numberFormatInfo;
		Application.CurrentCulture = cultureInfo;
		Thread.CurrentThread.CurrentCulture = cultureInfo;
		Thread.CurrentThread.CurrentUICulture = cultureInfo;
	}

	public static void DoEventCountCalc(int MaxCount, ref int CalcEventCount)
	{
		if (MaxCount <= 10)
		{
			CalcEventCount = 1;
		}
		if (MaxCount > 10 && MaxCount <= 50)
		{
			CalcEventCount = 2;
		}
		if (MaxCount > 50 && MaxCount <= 100)
		{
			CalcEventCount = 5;
		}
		if (MaxCount > 100 && MaxCount <= 500)
		{
			CalcEventCount = 20;
		}
		if (MaxCount > 500 && MaxCount <= 1000)
		{
			CalcEventCount = 25;
		}
		if (MaxCount > 1000 && MaxCount <= 5000)
		{
			CalcEventCount = 50;
		}
		if (MaxCount > 5000)
		{
			CalcEventCount = Convert.ToInt32((double)MaxCount / 100.0);
		}
	}

	public static long GetMemorySizeofObject(object Obj)
	{
		long result = 0L;
		using (Stream stream = new MemoryStream())
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			binaryFormatter.Serialize(stream, Obj);
			result = stream.Length;
		}
		return result;
	}

	public static void RulerSteps(double Length, ref double Step)
	{
		try
		{
			if (Length >= 0.0 && Length < 0.2)
			{
				Step = 0.1;
			}
			if (Length >= 0.2 && Length < 0.5)
			{
				Step = 0.2;
			}
			if (Length >= 0.5 && Length < 1.0)
			{
				Step = 0.5;
			}
			if (Length >= 1.0 && Length < 2.0)
			{
				Step = 1.0;
			}
			if (Length >= 2.0 && Length < 5.0)
			{
				Step = 2.0;
			}
			if (Length >= 5.0 && Length < 10.0)
			{
				Step = 5.0;
			}
			if (Length >= 10.0 && Length < 20.0)
			{
				Step = 10.0;
			}
			if (Length >= 20.0 && Length < 50.0)
			{
				Step = 20.0;
			}
			if (Length >= 50.0 && Length < 100.0)
			{
				Step = 50.0;
			}
			if (Length >= 100.0 && Length < 200.0)
			{
				Step = 100.0;
			}
			if (Length >= 200.0 && Length < 300.0)
			{
				Step = 200.0;
			}
			if (Length >= 300.0 && Length < 500.0)
			{
				Step = 300.0;
			}
			if (Length >= 500.0 && Length < 1000.0)
			{
				Step = 500.0;
			}
			if (Length >= 1000.0 && Length < 2000.0)
			{
				Step = 1000.0;
			}
			if (Length >= 2000.0 && Length < 4000.0)
			{
				Step = 2000.0;
			}
			if (Length >= 4000.0 && Length < 10000.0)
			{
				Step = 4000.0;
			}
			if (Length >= 10000.0 && Length < 20000.0)
			{
				Step = 10000.0;
			}
			if (Length >= 20000.0)
			{
				Step = 20000.0;
			}
		}
		catch (Exception mSException)
		{
			string text = "Length : " + Length;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static string SecondToTime(double Second, bool Usems)
	{
		try
		{
			TimeSpan timeSpan = TimeSpan.FromSeconds(Second);
			string text = "";
			return Usems ? $"{timeSpan.Hours:D2}h:{timeSpan.Minutes:D2}m:{timeSpan.Seconds:D2}s:{timeSpan.Milliseconds:D3}ms" : $"{timeSpan.Hours:D2}h:{timeSpan.Minutes:D2}m:{timeSpan.Seconds:D2}s";
		}
		catch (Exception mSException)
		{
			string text2 = "Second : " + Second + " - Usems: " + Usems;
			buLog.addLog(text2, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text2);
			return "00:00:00";
		}
	}

	public static string GetToolExplanation(ToolBase Tool)
	{
		string result = "Tool";
		if (Tool.Geometry.GeometryType == ToolType.Flat)
		{
			result = "Name = " + Tool.Data.Name.ToString() + Environment.NewLine;
			result = result + "No = " + Tool.Data.No + Environment.NewLine;
			result = result + "Diameter = " + Tool.Geometry.Diameter + Environment.NewLine;
			result = result + "Length = " + Tool.Geometry.Length + Environment.NewLine;
			result = result + "Spindle = " + Tool.CamData.SpindleSpeed + Environment.NewLine;
			result = result + "Feed = " + Tool.CamData.FeedSpeed + Environment.NewLine;
			result = result + "Plunge = " + Tool.CamData.PlungeSpeed + Environment.NewLine;
			result = result + "Purpose = " + Tool.Purpose.ToString() + Environment.NewLine;
		}
		if (Tool.Geometry.GeometryType == ToolType.Sphere)
		{
			result = "Name = " + Tool.Data.Name.ToString() + Environment.NewLine;
			result = result + "No = " + Tool.Data.No + Environment.NewLine;
			result = result + "Diameter = " + Tool.Geometry.Diameter + Environment.NewLine;
			result = result + "Length = " + Tool.Geometry.Length + Environment.NewLine;
			result = result + "Spindle = " + Tool.CamData.SpindleSpeed + Environment.NewLine;
			result = result + "Feed = " + Tool.CamData.FeedSpeed + Environment.NewLine;
			result = result + "Plunge = " + Tool.CamData.PlungeSpeed + Environment.NewLine;
			result = result + "Purpose = " + Tool.Purpose.ToString() + Environment.NewLine;
		}
		if (Tool.Geometry.GeometryType == ToolType.Saw)
		{
			result = "Name = " + Tool.Data.Name.ToString() + Environment.NewLine;
			result = result + "No = " + Tool.Data.No + Environment.NewLine;
			result = result + "Diameter = " + Tool.Geometry.Diameter + Environment.NewLine;
			result = result + "Thickness = " + Tool.Geometry.Thickness + Environment.NewLine;
			result = result + "Spindle = " + Tool.CamData.SpindleSpeed + Environment.NewLine;
			result = result + "Feed = " + Tool.CamData.FeedSpeed + Environment.NewLine;
			result = result + "Plunge = " + Tool.CamData.PlungeSpeed + Environment.NewLine;
			result = result + "Purpose = " + Tool.Purpose.ToString() + Environment.NewLine;
		}
		return result;
	}

	public static void FitObjectByWidth(int TotalWidth, int ObjectHeigth, int ObjectTopPosition, int ObjectLeftOffset, int Space, int ObjectCount, ref List<Rectangle> Rects)
	{
		try
		{
			float num = TotalWidth - Space * 2 - Space * (ObjectCount - 1);
			Rectangle item = default(Rectangle);
			int num2 = (int)Math.Floor((double)num / (double)ObjectCount);
			item.Height = ObjectHeigth;
			Rects.Clear();
			for (int i = 0; i <= ObjectCount - 1; i++)
			{
				int num3 = Space + (num2 + Space) * i;
				item.Width = num2;
				item.Location = new Point(num3 + ObjectLeftOffset, ObjectTopPosition);
				Rects.Add(item);
			}
		}
		catch (Exception mSException)
		{
			string text = "TotalWidth : " + TotalWidth + " - ObjectHeigth: " + ObjectHeigth + " - ObjectTopPosition: " + ObjectTopPosition + " - ObjectLeftOffset: " + ObjectLeftOffset + " - Space: " + Space + " - ObjectCount: " + ObjectCount;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public static void CreatParameterDefaultFiles(object Par, string RefString, ref string DefaultStr)
	{
		try
		{
			new List<string>();
			new List<object>();
			List<Type> list = new List<Type>();
			List<cParameter> Vars = new List<cParameter>();
			buSerilization.GetClassVariables(Par, ref Vars);
			for (int i = 0; i <= Vars.Count - 1; i++)
			{
				string text = Vars[i].Value.ToString();
				if ((text.ToLower() == "false") | (text.ToLower() == "true"))
				{
					text = text.ToLower();
				}
				if (list[i] == typeof(string))
				{
					text = "\"" + text + "\"";
				}
				if (list[i].BaseType == typeof(Enum))
				{
					text = "\"" + text + "\"";
					text = "";
				}
				if (text.Length > 0)
				{
					string text2 = RefString + Vars[i].Name + " = " + text + ";";
					DefaultStr = DefaultStr + text2 + Environment.NewLine;
				}
			}
		}
		catch (Exception mSException)
		{
			string text3 = "Par : " + Par.ToString() + " - RefString: " + RefString.ToString();
			buLog.addLog(text3, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text3);
		}
	}

	public static bool isFirstInit(string path)
	{
		string callMethod = "isFirstInit";
		try
		{
			path = path.Replace("\\\\", "\\");
			FileInfo fileInfo = new FileInfo(path + "\\FirstInit.dll");
			if (!fileInfo.Exists)
			{
				return false;
			}
			return true;
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", callMethod);
			buException.throwException(mSException, callMethod, ShowMessageBox: true, text);
			return false;
		}
	}

	public static void DeleteFirstInit(string path)
	{
		string callMethod = "DeleteFirstInit";
		try
		{
			path = path.Replace("\\\\", "\\");
			FileInfo fileInfo = new FileInfo(path + "\\FirstInit.dll");
			if (fileInfo.Exists)
			{
				fileInfo.Delete();
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", callMethod);
			buException.throwException(mSException, callMethod, ShowMessageBox: true, text);
		}
	}
}
