// Decompiled with JetBrains decompiler
// Type: buClass.Apps.TheoBridgeItem
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class TheoBridgeItem : TheoItem
{
  public double Width = 0.0;
  public double Height = 0.0;
  public Pnt3D Position = new Pnt3D();

  public TheoBridgeItem()
  {
  }

  public TheoBridgeItem(double x, double width, double height)
  {
    this.Width = width;
    this.XPos = x;
    this.Height = height;
  }

  public TheoBridgeItem(TheoBridgeItem data)
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
    return $"Bridge - Width: {this.Width.ToString()} - X: {this.XPos.ToString()}";
  }
}
