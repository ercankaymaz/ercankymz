// Decompiled with JetBrains decompiler
// Type: buClass.Apps.BendJob
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class BendJob : buSerilization
{
  public Pnt9D Position = new Pnt9D();
  public double OriginalC = 0.0;
  public double Radius = 0.0;
  public double PartWidth = 0.0;
  public double PartLength = 0.0;
  public int PartCount = 0;
  public int PartIndex = -1;
  public double PartThickness = 0.0;
  public int ToolNo = 0;
  public int Type = 0;
  public int Action = 0;
  public int BlockNo = 0;
  public int Index = 0;
  public int Mode = 0;
  public int Closed = 0;
  public int Direction = 0;
  public bool DontUse = false;
  public int Opt = 0;
  public TrimcutSequence TrimcutSequence = TrimcutSequence.Start;

  public BendJob()
  {
  }

  public BendJob(BendJob data)
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
    return $"X:{this.Position.X.ToString("f1")} ; Action: {this.Action.ToString()} ; Tool: {this.ToolNo.ToString()}  ; C:{this.Position.C.ToString("f1")}  ; Mode: {this.Mode.ToString()}  ; Part Index: {this.PartIndex.ToString()}";
  }
}
