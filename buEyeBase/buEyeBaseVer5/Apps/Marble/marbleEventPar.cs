// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleEventPar
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps.PanelCut;
using System;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleEventPar : buSerilization5
{
  public bool selectedLibraryAddNesting;
  public bool selectedTextAddNesting;
  public bool selectedDrawingAddNesting;
  public bool selectedEngraving5AxisMilling;
  public bool selectedColomns5AxisMilling;
  public bool InisdeMilling;

  public marbleEventPar()
  {
  }

  public abstract void m001EE3();

  public marbleEventPar()
  {
    // ISSUE: unable to decompile the method.
  }

  public marbleEventPar(PanelCutMove data)
  {
    // ISSUE: unable to decompile the method.
  }

  public override string ToString()
  {
    // ISSUE: unable to decompile the method.
  }

  public abstract void m001EE7();

  public marbleEventPar()
  {
    ((MarbleRuntimeSettings) this).Depth = 0;
    ((MarbleRuntimeSettings) this).XIndex = -1;
    ((MarbleRuntimeSettings) this).YIndex = -1;
    ((MarbleRuntimeSettings) this).Note = "";
    ((MarbleRuntimeSettings) this).NodeID = -1;
    ((MarbleRuntimeSettings) this).NodeType = nestPanelNodeType.Assembly;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
