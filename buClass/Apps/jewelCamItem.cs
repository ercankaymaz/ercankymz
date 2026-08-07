// Decompiled with JetBrains decompiler
// Type: buClass.Apps.jewelCamItem
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Reflection;

#nullable disable
namespace buClass.Apps;

public class jewelCamItem : buSerilization
{
  public Pnt9D Point = new Pnt9D();
  public Pnt3D NotMovedPoint = new Pnt3D();
  public Pnt9D SimPoints = new Pnt9D();
  public string Code = "";
  public double Speed = 0.0;
  public bool FastMoveByG1 = false;
  public bool LeaveMode = false;
  public bool PlungeMode = false;
  public bool G0Mode = false;

  public jewelCamItem()
  {
  }

  public jewelCamItem(jewelCamItem data)
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

  public override string ToString() => this.Point.ToString();
}
