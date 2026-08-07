// Decompiled with JetBrains decompiler
// Type: buClass.Apps.ProfileOperationDataFreeDraw
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class ProfileOperationDataFreeDraw : buSerilization
{
  public double FreeDrawWidth = 0.0;
  public double FreeDrawHeight = 0.0;
  public double FreeDrawAngle = 0.0;
  public ProfileScaleCenterType FreeDrawScaleCenter = ProfileScaleCenterType.Center;
  public Color FreeDrawColor = Color.Blue;
  public double FreeDrawThickness = 1.0;

  public ProfileOperationDataFreeDraw()
  {
  }

  public ProfileOperationDataFreeDraw(ProfileOperationDataFreeDraw data)
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
    return $"Width : {this.FreeDrawWidth.ToString()} - EllipseHeight : {this.FreeDrawHeight.ToString()}";
  }
}
