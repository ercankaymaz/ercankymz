// Decompiled with JetBrains decompiler
// Type: buClass.Apps.jewelTangent
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Reflection;

#nullable disable
namespace buClass.Apps;

public class jewelTangent : buSerilization
{
  public bool Enable = false;
  public double LimitAngle = 0.0;
  public double MinAngle = 0.0;
  public double MaxAngle = 180.0;
  public double Offset = 0.0;
  public double ContantAngle = 0.0;
  public bool UseLimitAngle = false;
  public bool UseContantAngle = false;
  public bool UseMirrorAngle = false;
  public bool UseNoScaleEntities = false;
  public bool LimitAngleUseNextCValue = true;
  public jewelTangentType Type = jewelTangentType.Continous;

  public jewelTangent()
  {
  }

  public jewelTangent(jewelTangent data)
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
