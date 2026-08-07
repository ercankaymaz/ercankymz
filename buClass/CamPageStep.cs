// Decompiled with JetBrains decompiler
// Type: buClass.CamPageStep
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class CamPageStep : buSerilization
{
  public bool Enable = true;
  public bool Start = true;
  public bool End = false;
  public bool Step = false;
  public bool Count = false;
  public bool Distance = false;
  public bool MoveUp = false;
  public bool MoveUpType = false;
  public bool Sequence = false;

  public CamPageStep()
  {
  }

  public CamPageStep(CamPageStep data)
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
