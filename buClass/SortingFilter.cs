// Decompiled with JetBrains decompiler
// Type: buClass.SortingFilter
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buClass;

[Serializable]
public class SortingFilter : buSerilization
{
  public List<eEntities> NotSelectEntities = new List<eEntities>();
  public List<eEntities> SelectableEntities = new List<eEntities>();
  public List<int> NotSelectIndex = new List<int>();
  public List<int> SelectableIndex = new List<int>();
  public List<Color> NotSelectColor = new List<Color>();
  public List<Color> SelectableColor = new List<Color>();
  public MostClosestPointType MostClosestType = MostClosestPointType.OnlyNotCamSelectedEntities;
  public bool UsePointEntities = false;
}
