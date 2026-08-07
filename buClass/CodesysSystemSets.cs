// Decompiled with JetBrains decompiler
// Type: buClass.CodesysSystemSets
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class CodesysSystemSets : buSerilization
{
  public FeedSettings Feed = new FeedSettings();
  public SpindleSettings Spindle = new SpindleSettings();
  public SpindleSettings SpindleSaw = new SpindleSettings();
  public TimeSettings Times = new TimeSettings();
  public ToolSettings Tool = new ToolSettings();
  public OffsetSettings Offset = new OffsetSettings();
  public int EthercatSyncTime = 4000;
  public bool EnableAxesAfterInit = true;
  public bool FairLoopMode = false;
  public ParameterTransferType ParameterTransfer = ParameterTransferType.FromVariable;
  public static List<string> Captions = new List<string>();

  public CodesysSystemSets()
  {
  }

  public CodesysSystemSets(CodesysSystemSets data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields != null)
    {
      for (int index = 0; index <= fields.Length - 1; ++index)
      {
        string name = fields[index].Name;
        object obj = fields[index].GetValue(CopiedClass);
        fields[index].SetValue((object) this, obj);
      }
    }
  }

  public override string ToString()
  {
    return $"EnableAxesAfterInit: {this.EnableAxesAfterInit.ToString()} , EthercatSyncTime : {this.EthercatSyncTime.ToString()}";
  }
}
