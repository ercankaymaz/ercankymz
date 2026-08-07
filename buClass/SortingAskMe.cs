// Decompiled with JetBrains decompiler
// Type: buClass.SortingAskMe
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace buClass;

[Serializable]
public class SortingAskMe : buSerilization
{
  public bool Return = false;
  public bool ReturnNextGroup = false;
  public int SelectedIndex = 0;
  public Pnt3D RefPoint = new Pnt3D();
  public List<int> EntitiesIndex = new List<int>();
  public List<eEntities> Entities = new List<eEntities>();
  public List<eEntities> SortedEntities = new List<eEntities>();
  public List<eEntities> UpperEntities = new List<eEntities>();
}
