// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buClipperLib.buClipperBase
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5.buClipperLib;

public class buClipperBase
{
  public List<double> DepthLevel;
  public bool Enable;
  public bool isEngraving;
  public bool isPocket;
  public planeBoxNames planeName;
  public ShapeGroup ShapeGroup;
  public CornerLocation Corner;
  public ObjectAlignment Alignment;
  public ShapeTypes ShapeType;
  public ShapeEdit Edit;
  public ShapeSizeInfo ItemSize;

  [CompilerGenerated]
  [SpecialName]
  public void set_CamID(int value) => ((Router3AXCAM) this).\u0001 = value;

  [CompilerGenerated]
  [SpecialName]
  public string get_SceneName() => ((Router3AXCAM) this).\u0002;

  [CompilerGenerated]
  [SpecialName]
  public void set_SceneName(string value) => ((Router3AXCAM) this).\u0002 = value;

  [CompilerGenerated]
  [SpecialName]
  public string get_EntityName() => ((Router3AXCAM) this).\u0003;

  [CompilerGenerated]
  [SpecialName]
  public void set_EntityName(string value) => ((Router3AXCAM) this).\u0003 = value;

  [CompilerGenerated]
  [SpecialName]
  public string get_ActionName() => ((Router3AXCAM) this).\u0004;

  [CompilerGenerated]
  [SpecialName]
  public void set_ActionName(string value) => ((Router3AXCAM) this).\u0004 = value;

  [CompilerGenerated]
  [SpecialName]
  public int get_GroupIdIndex() => ((Router3AXCAM) this).\u0002;

  [CompilerGenerated]
  [SpecialName]
  public void set_GroupIdIndex(int value) => ((Router3AXCAM) this).\u0002 = value;

  public bool PreserveCollinear
  {
    [CompilerGenerated, SpecialName] get => ((PipeBendSettings) this).\u0003;
    [CompilerGenerated, SpecialName] set => ((PipeBendSettings) this).\u0003 = value;
  }
}
