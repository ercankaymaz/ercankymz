// Decompiled with JetBrains decompiler
// Type: buClass.Apps.MarbleReCalculateParameter
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Collections.Generic;

#nullable disable
namespace buClass.Apps;

public class MarbleReCalculateParameter
{
  public camParameters CamPar = new camParameters();
  public marbleOperation Operation = new marbleOperation();
  public marbleCamParameters CamMarblePar = new marbleCamParameters();
  public List<List<eEntities>> ReCalcEntities = new List<List<eEntities>>();
  public List<List<eEntities>> ReCalcAfterEntities = new List<List<eEntities>>();
  public List<List<Pnt6D>> CalculatedPnt6D = new List<List<Pnt6D>>();
  public int CamIndex = -1;
  public bool Copy = false;
}
