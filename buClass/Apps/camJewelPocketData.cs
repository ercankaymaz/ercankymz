// Decompiled with JetBrains decompiler
// Type: buClass.Apps.camJewelPocketData
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

public class camJewelPocketData : buSerilization
{
  public double Depth = 0.0;
  public double ToolDiameterOffset = 0.0;
  public double StepDownDistance = 1.0;
  public int StepDownCount = 1;
  public CamMachiningSequenceType Sort = CamMachiningSequenceType.Level;
  public ClockDirectionType Direction = ClockDirectionType.CW;
  public bool AllClosedPath = true;
  public static List<string> Captions = new List<string>();

  public camJewelPocketData()
  {
  }

  public camJewelPocketData(camJewelPocketData data)
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

  public override string ToString() => "( Jewel5AxPocket ->  )";
}
