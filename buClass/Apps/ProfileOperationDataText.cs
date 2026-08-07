// Decompiled with JetBrains decompiler
// Type: buClass.Apps.ProfileOperationDataText
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class ProfileOperationDataText : buSerilization
{
  public double TextWidth = 0.0;
  public double TextHeight = 0.0;
  public double TextAngle = 0.0;
  public string TextString = "";
  public Font TextFont = new Font("Arial", 12f);
  public ProfileScaleCenterType TextScaleCenter = ProfileScaleCenterType.Center;
  public Color TextColor = Color.Blue;
  public double TextThickness = 1.0;

  public ProfileOperationDataText()
  {
  }

  public ProfileOperationDataText(ProfileOperationDataText data)
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
    return $"{this.TextString} - Width : {this.TextWidth.ToString()} - TextHeight : {this.TextHeight.ToString()}";
  }
}
