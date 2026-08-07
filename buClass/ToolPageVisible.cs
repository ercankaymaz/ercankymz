// Decompiled with JetBrains decompiler
// Type: buClass.ToolPageVisible
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class ToolPageVisible : buSerilization
{
  public bool ShowTabData = true;
  public bool ShowTabCam = true;
  public bool ShowTabGeometry = true;
  public bool ShowTabColor = true;
  public bool ShowTabAux = true;
  public bool ShowTabPosition = true;
  public bool ShowTabLimit = true;
  public bool ShowName = true;
  public bool ShowNo = true;
  public bool ShowSector = true;
  public bool ShowHeightOffsetIndex = true;
  public bool ShowTag = true;
  public bool ShowPurpose = true;
  public bool ShowClone = true;
  public bool ShowMinLength = true;
  public bool ShowVector = true;
  public bool ShowGeometryType = true;
  public bool ShowStepOverride = true;
  public bool ShowCutOverride = true;
  public bool ShowOperationHeight = true;
  public bool ShowFeedVelocity = true;
  public bool ShowPlungeVelocity = true;
  public bool ShowFinishVelocity = true;
  public bool ShowAreaClearanceVelocity = true;
  public bool ShowSpindleSpeed = true;
  public bool ShowSpindleDirection = true;
  public bool ShowSafeDistance = true;
  public bool ShowSecondHeadHeight = true;
  public bool ShowOutputs = true;
  public bool ShowAir = true;
  public bool ShowWater = true;
  public bool ShowOil = true;
  public bool ShowInnerCooler = true;
  public bool ShowAngularPosition = true;
  public bool ShowSetPositionXYZ = true;
  public bool ShowSetPositionABC = true;
  public bool ShowOfsetXYZ = true;
  public bool ShowOffsetABC = true;
  public bool ShowPlaneLimits = true;
  public bool ShowAxisALimits = true;
  public bool ShowAxisBLimits = true;
  public bool ShowAxisCLimits = true;
  public bool ShowColorToolCuttings = true;
  public bool ShowColorToolBody = true;
  public bool ShowColorHolder = true;
  public bool ShowColorBody = true;
  public bool ShowColorCam = true;
  public bool ShowColorUpper = true;
  public bool ShowColorPlunge = true;
  public bool ShowColorLeave = true;
  public int PageWidth = 0;
  public int PageHeight = 0;

  public ToolPageVisible()
  {
  }

  public ToolPageVisible(ToolPageVisible data)
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
