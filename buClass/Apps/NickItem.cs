// Decompiled with JetBrains decompiler
// Type: buClass.Apps.NickItem
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class NickItem : buSerilization
{
  public double Height;
  public double Width;
  public double Offset = 0.0;
  public double Distance;
  public double Angle;
  public double ToolWidth;
  public bool Enable = true;
  public int Index;
  public int SubIndex;
  public Pnt3D OriginalPosition = new Pnt3D();
  public double ExtractXPosition = 0.0;
  public Pnt3D BasePosition = new Pnt3D();
  public ToolBase ToolNick = new ToolBase();
  public List<Pnt3D> CamPoints = new List<Pnt3D>();

  public NickItem()
  {
  }

  public NickItem(NickItem data)
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

  public override string ToString() => "Extract X : " + this.ExtractXPosition.ToString("f2");
}
