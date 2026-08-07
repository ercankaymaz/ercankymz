// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.OperationSizeCalcArgs
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.buEntities;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps;

public class OperationSizeCalcArgs : buSerilization5
{
  public double Length;
  public double XBendingPos;
  public double ExecutedStep;

  public OperationSizeCalcArgs()
  {
    ((FoamSettings) this).entityPlaneBottom = (buEntity) null;
    ((FoamSettings) this).entityPlaneBottomText = (buEntity) null;
    ((FoamSettings) this).entityPlaneTop = (buEntity) null;
    ((FoamSettings) this).entityPlaneTopText = (buEntity) null;
    ((FoamSettings) this).entityPlaneClearance = (buEntity) null;
    ((FoamSettings) this).entityPlaneClearanceText = (buEntity) null;
    ((FoamSettings) this).entityPlaneRetract = (buEntity) null;
    ((FoamSettings) this).entityPlaneRetractText = (buEntity) null;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public OperationSizeCalcArgs(Router3AXCamPlane data)
  {
    ((FoamSettings) this).entityPlaneBottom = (buEntity) null;
    ((FoamSettings) this).entityPlaneBottomText = (buEntity) null;
    ((FoamSettings) this).entityPlaneTop = (buEntity) null;
    ((FoamSettings) this).entityPlaneTopText = (buEntity) null;
    ((FoamSettings) this).entityPlaneClearance = (buEntity) null;
    ((FoamSettings) this).entityPlaneClearanceText = (buEntity) null;
    ((FoamSettings) this).entityPlaneRetract = (buEntity) null;
    ((FoamSettings) this).entityPlaneRetractText = (buEntity) null;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (this != null & CopiedClass != null && this.GetType() == CopiedClass.GetType())
    {
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
    if (((FoamSettings) data).entityPlaneBottom != null)
      buDiametricDim.Copy(((FoamSettings) data).entityPlaneBottom, ref ((FoamSettings) this).entityPlaneBottom);
    if (((FoamSettings) data).entityPlaneBottomText != null)
      buDiametricDim.Copy(((FoamSettings) data).entityPlaneBottomText, ref ((FoamSettings) this).entityPlaneBottomText);
    if (((FoamSettings) data).entityPlaneTop != null)
      buDiametricDim.Copy(((FoamSettings) data).entityPlaneTop, ref ((FoamSettings) this).entityPlaneTop);
    if (((FoamSettings) data).entityPlaneTopText != null)
      buDiametricDim.Copy(((FoamSettings) data).entityPlaneTopText, ref ((FoamSettings) this).entityPlaneTopText);
    if (((FoamSettings) data).entityPlaneClearance != null)
      buDiametricDim.Copy(((FoamSettings) data).entityPlaneClearance, ref ((FoamSettings) this).entityPlaneClearance);
    if (((FoamSettings) data).entityPlaneClearanceText != null)
      buDiametricDim.Copy(((FoamSettings) data).entityPlaneClearanceText, ref ((FoamSettings) this).entityPlaneClearanceText);
    if (((FoamSettings) data).entityPlaneRetract != null)
      buDiametricDim.Copy(((FoamSettings) data).entityPlaneRetract, ref ((FoamSettings) this).entityPlaneRetract);
    if (((FoamSettings) data).entityPlaneRetractText == null)
      return;
    buDiametricDim.Copy(((FoamSettings) data).entityPlaneRetractText, ref ((FoamSettings) this).entityPlaneRetractText);
  }

  public static void Decode(List<string> AL, ref FoamBlock Item)
  {
  }
}
