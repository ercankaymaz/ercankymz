// Decompiled with JetBrains decompiler
// Type: buClass.PageSelectedItem
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;

#nullable disable
namespace buClass;

[Serializable]
public class PageSelectedItem : buSerilization
{
  public PageModes Mode = PageModes.None;
  public int PageIndex = -1;
  public string PageName = "";
  public int SceneIndex = -1;
  public string SceneName = "";
  public int CamIndex = -1;
  public string CamName = "";
  public int BlockIndex = -1;
  public string BlockName = "";
  public int EntityIndex = -1;
  public string EntityType = "";
  public string EntityName = "";
  public int Index = -1;
  public int SubIndex = -1;
  public string Info = "";
}
