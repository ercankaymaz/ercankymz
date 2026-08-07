// Decompiled with JetBrains decompiler
// Type: buClass.Apps.JewelVar
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class JewelVar : buSerilization
{
  public jewelLimits Limits = new jewelLimits();
  public jewelMode JewelMode = new jewelMode();
  public jewelPositioningSettings PositionProp = new jewelPositioningSettings();
  public jewelMaterial JewelMaterialProp = new jewelMaterial();
  public jewelTangent JewelTangentProp = new jewelTangent();
  public camStep JewelSteppingProp = new camStep();
  public jewelSideOperation JewelSideProp = new jewelSideOperation();
  public jewelScale JewelScaleProp = new jewelScale();
  public jewelPunching JewelPunchProp = new jewelPunching();
  public jewelCam JewelCamProp = new jewelCam();
  public jewelCamItem JewelCamItemProp = new jewelCamItem();
  public jewelUserSettings UserSettings = new jewelUserSettings();
  public jewelSettings Settings = new jewelSettings();
  public CodesysCNCSets CNCSettings = new CodesysCNCSets();
  public CodesysAxCnc AxisXCncSetting = new CodesysAxCnc();
  public CodesysAxCnc AxisYCncSetting = new CodesysAxCnc();
  public CodesysAxCnc AxisZCncSetting = new CodesysAxCnc();
  public CodesysAxCnc AxisACncSetting = new CodesysAxCnc();
  public CodesysAxCnc AxisBCncSetting = new CodesysAxCnc();
  public CodesysAxCnc AxisCCncSetting = new CodesysAxCnc();
  public CodesysAxCnc AxisUCncSetting = new CodesysAxCnc();
  public CodesysAxCnc AxisVCncSetting = new CodesysAxCnc();
  public CodesysAxCnc AxisWCncSetting = new CodesysAxCnc();
  public string ModeName = "";
  public string ModePreparedBy = "";
  public bool OilEnable = false;
  public SortingNextGroupFindRulesType SortNextGRoupRules = SortingNextGroupFindRulesType.ClosestLength;
  public string PostPath = Application.StartupPath;
  public string PostName = "";

  public JewelVar()
  {
  }

  public JewelVar(JewelVar jewel)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) jewel, ref CopiedClass);
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
    this.JewelCamItemProp = new jewelCamItem(jewel.JewelCamItemProp);
    this.JewelCamProp = new jewelCam(jewel.JewelCamProp);
    this.JewelMaterialProp = new jewelMaterial(jewel.JewelMaterialProp);
    this.JewelMode = new jewelMode(jewel.JewelMode);
    this.JewelPunchProp = new jewelPunching(jewel.JewelPunchProp);
    this.JewelScaleProp = new jewelScale(jewel.JewelScaleProp);
    this.JewelSteppingProp = new camStep(jewel.JewelSteppingProp);
    this.JewelSideProp = new jewelSideOperation(jewel.JewelSideProp);
    this.JewelTangentProp = new jewelTangent(jewel.JewelTangentProp);
    this.Settings = new jewelSettings(jewel.Settings);
    this.UserSettings = new jewelUserSettings(jewel.UserSettings);
    this.PositionProp = new jewelPositioningSettings(jewel.PositionProp);
    this.CNCSettings = new CodesysCNCSets(jewel.CNCSettings);
    this.Limits = new jewelLimits(jewel.Limits);
    this.AxisACncSetting = new CodesysAxCnc(jewel.AxisACncSetting);
    this.AxisBCncSetting = new CodesysAxCnc(jewel.AxisBCncSetting);
    this.AxisCCncSetting = new CodesysAxCnc(jewel.AxisCCncSetting);
    this.AxisXCncSetting = new CodesysAxCnc(jewel.AxisXCncSetting);
    this.AxisYCncSetting = new CodesysAxCnc(jewel.AxisYCncSetting);
    this.AxisZCncSetting = new CodesysAxCnc(jewel.AxisZCncSetting);
    this.AxisUCncSetting = new CodesysAxCnc(jewel.AxisUCncSetting);
    this.AxisVCncSetting = new CodesysAxCnc(jewel.AxisVCncSetting);
    this.AxisWCncSetting = new CodesysAxCnc(jewel.AxisWCncSetting);
  }
}
