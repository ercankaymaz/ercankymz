// Decompiled with JetBrains decompiler
// Type: buClass.Apps.TheoItem
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections;
using System.Collections.Generic;

#nullable disable
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
    if (data.GetType() == typeof (TheoBendItem))
      CopiedItem = (TheoItem) new TheoBendItem((TheoBendItem) data);
    if (data.GetType() == typeof (TheoBridgeItem))
      CopiedItem = (TheoItem) new TheoBridgeItem((TheoBridgeItem) data);
    if (data.GetType() == typeof (TheoNickItem))
      CopiedItem = (TheoItem) new TheoNickItem((TheoNickItem) data);
    if (!(data.GetType() == typeof (TheoBroachItem)))
      return;
    CopiedItem = (TheoItem) new TheoBroachItem((TheoBroachItem) data);
  }

  public static TheoItem Decode(List<string> AL, string Char, SerilizationMode Mode)
  {
    TheoItem theoItem = (TheoItem) null;
    if (AL.Count > 0)
    {
      string str = AL[0];
      if (str.Length > 0)
      {
        if (str.IndexOf("TheoBendItem") >= 0)
        {
          theoItem = (TheoItem) new TheoBendItem();
          buSerilization.Decode(AL, "", SerilizationMode.MultiLine, (object) theoItem);
          List<List<string>> CalcList = new List<List<string>>();
          buStatics.ListToSpecificList("<TheoBendOriginalPosition>", "</TheoBendOriginalPosition>", AL, ref CalcList);
          for (int index = 0; index <= CalcList.Count - 1; ++index)
          {
            CalcList[index].Insert(0, "<TheoBendOriginalPosition>");
            CalcList[index].Add("</TheoBendOriginalPosition>");
            TheoBendOriginalPosition originalPosition = new TheoBendOriginalPosition();
            buSerilization.Decode(CalcList[index], "", SerilizationMode.MultiLine, (object) originalPosition);
            ((TheoBendItem) theoItem).OriginalFromCode.Add(originalPosition);
          }
        }
        if (str.IndexOf("TheoBroachItem") >= 0)
        {
          theoItem = (TheoItem) new TheoBroachItem();
          buSerilization.Decode(AL, "", SerilizationMode.MultiLine, (object) theoItem);
        }
        if (str.IndexOf("TheoNickItem") >= 0)
        {
          theoItem = (TheoItem) new TheoNickItem();
          buSerilization.Decode(AL, "", SerilizationMode.MultiLine, (object) theoItem);
        }
        if (str.IndexOf("TheoBridgeItem") >= 0)
        {
          theoItem = (TheoItem) new TheoBridgeItem();
          buSerilization.Decode(AL, "", SerilizationMode.MultiLine, (object) theoItem);
        }
      }
    }
    return theoItem;
  }

  public ArrayList ToDefAll(int Space)
  {
    string str1 = new string(' ', Space);
    ArrayList defAll = new ArrayList();
    buSerilization.ExceptionalVariables.Clear();
    defAll.Add((object) (str1 + "<TheoItem>"));
    if (this.GetType() == typeof (TheoBendItem))
    {
      defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
      string str2 = defAll[defAll.Count - 1].ToString();
      defAll.RemoveAt(defAll.Count - 1);
      for (int index = 0; index <= ((TheoBendItem) this).OriginalFromCode.Count - 1; ++index)
        defAll.AddRange((ICollection) ((TheoBendItem) this).OriginalFromCode[index].ToDefAll("", 6, SerilizationMode.MultiLine));
      defAll.Add((object) str2);
    }
    if (this.GetType() == typeof (TheoBroachItem))
      defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
    if (this.GetType() == typeof (TheoNickItem))
      defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
    if (this.GetType() == typeof (TheoBridgeItem))
      defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
    defAll.Add((object) (str1 + "</TheoItem>"));
    return defAll;
  }
}
