// Decompiled with JetBrains decompiler
// Type: buClass.SortingResult
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace buClass;

[Serializable]
public class SortingResult : buSerilization
{
  public Pnt3D FirstPoint = new Pnt3D();
  public Pnt3D LastPoint = new Pnt3D();
  public SortingResultType ResultType = SortingResultType.None;
  public List<int> SelectedEntitiesIndex = new List<int>();
  public List<eEntities> LastCalculatedEntities = new List<eEntities>();
  public List<int> LastSelectedEntitiesIndex = new List<int>();
}
