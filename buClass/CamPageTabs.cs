// Decompiled with JetBrains decompiler
// Type: buClass.CamPageTabs
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class CamPageTabs : buSerilization
{
  public bool ShowOperation = true;
  public bool ShowDistance = true;
  public bool ShowVelocity = true;
  public bool ShowStep = false;
  public bool ShowLeadIn = false;
  public bool ShowLeadOut = false;
  public bool ShowMisc = false;
  public bool ShowOffset = false;
  public bool ShowTools = false;
  public int Width = 950;
  public int Height = 530;

  public CamPageTabs()
  {
  }

  public CamPageTabs(CamPageTabs data)
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
