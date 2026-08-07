// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.MarbleMachineLatheSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

public class MarbleMachineLatheSettings : buSerilization5
{
  public int CamIndex;
  public ToolBase5 ToolOP;
  public MarbleToolType ToolType;
  public MarbleItemType ItemType;
  public MarbleShapeTypes ShapeType;
  public static byte f0048DD;
  public static string MarbleReleaseVer;
  public static int HMIStyle;

  public abstract void m001EAC();
}
