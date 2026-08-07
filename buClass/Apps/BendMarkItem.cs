// Decompiled with JetBrains decompiler
// Type: buClass.Apps.BendMarkItem
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class BendMarkItem : buSerilization
{
  public double Height;
  public double Width;
  public double Offset;
  public bool Enable = true;
  public Pnt3D Start = new Pnt3D();
  public Pnt3D End = new Pnt3D();
  public double ExtractXPosition = 0.0;
  public ToolBase ToolBendMark = new ToolBase();
  public List<Pnt3D> CamPoints = new List<Pnt3D>();

  public BendMarkItem()
  {
  }

  public BendMarkItem(BendMarkItem data)
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
