using System;
using System.Collections;
using System.Collections.Generic;

namespace buClass.Apps;

[Serializable]
public class TheoItem : buSerilization
{
	public double XPos = 0.0;

	public double Offset = 0.0;

	public int BaseIndex = -1;

	public double OffsetedX = 0.0;

	public string Explanation = "";

	public bool Enable = true;

	public static List<string> Captions = new List<string>();

	public static void Copy(TheoItem data, ref TheoItem CopiedItem)
	{
		if (data.GetType() == typeof(TheoBendItem))
		{
			CopiedItem = new TheoBendItem((TheoBendItem)data);
		}
		if (data.GetType() == typeof(TheoBridgeItem))
		{
			CopiedItem = new TheoBridgeItem((TheoBridgeItem)data);
		}
		if (data.GetType() == typeof(TheoNickItem))
		{
			CopiedItem = new TheoNickItem((TheoNickItem)data);
		}
		if (data.GetType() == typeof(TheoBroachItem))
		{
			CopiedItem = new TheoBroachItem((TheoBroachItem)data);
		}
	}

	public static TheoItem Decode(List<string> AL, string Char, SerilizationMode Mode)
	{
		TheoItem theoItem = null;
		string text = "";
		if (AL.Count > 0)
		{
			text = AL[0];
			if (text.Length > 0)
			{
				if (text.IndexOf("TheoBendItem") >= 0)
				{
					theoItem = new TheoBendItem();
					buSerilization.Decode(AL, "", SerilizationMode.MultiLine, theoItem);
					List<List<string>> CalcList = new List<List<string>>();
					buStatics.ListToSpecificList("<TheoBendOriginalPosition>", "</TheoBendOriginalPosition>", AL, ref CalcList);
					for (int i = 0; i <= CalcList.Count - 1; i++)
					{
						CalcList[i].Insert(0, "<TheoBendOriginalPosition>");
						CalcList[i].Add("</TheoBendOriginalPosition>");
						TheoBendOriginalPosition theoBendOriginalPosition = new TheoBendOriginalPosition();
						buSerilization.Decode(CalcList[i], "", SerilizationMode.MultiLine, theoBendOriginalPosition);
						((TheoBendItem)theoItem).OriginalFromCode.Add(theoBendOriginalPosition);
					}
				}
				if (text.IndexOf("TheoBroachItem") >= 0)
				{
					theoItem = new TheoBroachItem();
					buSerilization.Decode(AL, "", SerilizationMode.MultiLine, theoItem);
				}
				if (text.IndexOf("TheoNickItem") >= 0)
				{
					theoItem = new TheoNickItem();
					buSerilization.Decode(AL, "", SerilizationMode.MultiLine, theoItem);
				}
				if (text.IndexOf("TheoBridgeItem") >= 0)
				{
					theoItem = new TheoBridgeItem();
					buSerilization.Decode(AL, "", SerilizationMode.MultiLine, theoItem);
				}
			}
		}
		return theoItem;
	}

	public ArrayList ToDefAll(int Space)
	{
		string text = new string(' ', Space);
		ArrayList arrayList = new ArrayList();
		buSerilization.ExceptionalVariables.Clear();
		arrayList.Add(text + "<TheoItem>");
		if (GetType() == typeof(TheoBendItem))
		{
			arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
			string value = arrayList[arrayList.Count - 1].ToString();
			arrayList.RemoveAt(arrayList.Count - 1);
			for (int i = 0; i <= ((TheoBendItem)this).OriginalFromCode.Count - 1; i++)
			{
				arrayList.AddRange(((TheoBendItem)this).OriginalFromCode[i].ToDefAll("", 6, SerilizationMode.MultiLine));
			}
			arrayList.Add(value);
		}
		if (GetType() == typeof(TheoBroachItem))
		{
			arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
		}
		if (GetType() == typeof(TheoNickItem))
		{
			arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
		}
		if (GetType() == typeof(TheoBridgeItem))
		{
			arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
		}
		arrayList.Add(text + "</TheoItem>");
		return arrayList;
	}
}
