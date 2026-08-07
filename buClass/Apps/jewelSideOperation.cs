// Decompiled with JetBrains decompiler
// Type: buClass.Apps.jewelSideOperation
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Reflection;

#nullable disable
namespace buClass.Apps;

public class jewelSideOperation : buSerilization
{
  public bool Enable = false;
  public double Thickness = 2.0;
  public double DiameterInner = 10.0;
  public double Angle = 90.0;
  public double XOffset = 0.0;
  public double ZOffset = 0.0;

  public jewelSideOperation()
  {
  }

  public jewelSideOperation(jewelSideOperation data)
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
}
