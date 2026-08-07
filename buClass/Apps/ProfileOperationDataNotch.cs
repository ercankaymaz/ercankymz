// Decompiled with JetBrains decompiler
// Type: buClass.Apps.ProfileOperationDataNotch
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class ProfileOperationDataNotch : buSerilization
{
  public ProfileNotchType NotchType = ProfileNotchType.LType;
  public double NotchLDepth = 20.0;
  public double NotchLWidth = 10.0;
  public double NotchLHeight = 20.0;
  public UpDownLocationType NotchLUpDown = UpDownLocationType.Up;
  public double NotchUDepth = 20.0;
  public double NotchUWidth = 10.0;
  public double NotchUHeight = 20.0;
  public double NotchUStart = 10.0;
  public double NotchCutPersentage = 90.0;
  public LeftRightLocationType NotchLeftRight = LeftRightLocationType.Left;
  public Color NotchColor = Color.Blue;
  public double NotchThickness = 1.0;
  public ProfileNotchCutType NotchCutType = ProfileNotchCutType.BySawAndMilling;
  public CamCuttingWayDirectionType NotchCutDirection = CamCuttingWayDirectionType.TwoWayDirection;

  public ProfileOperationDataNotch()
  {
  }

  public ProfileOperationDataNotch(ProfileOperationDataNotch data)
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

  public override string ToString() => "NotchType : " + this.NotchType.ToString();
}
