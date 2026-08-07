// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Robotic.buRoboticCalc
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.Apps.Marble;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps.Robotic;

public class buRoboticCalc
{
  public bool MoveUpSafe;
  public MarbleCamAreaMode RoughAreaMode;

  public abstract void m001FEF();

  public buRoboticCalc()
  {
    ((marbleProfileCutPars) this).LatheSettings = (MarbleMachineLatheSettings) new CamToComauConverter();
    ((marbleProfileCutPars) this).SimulationSettings = (MarbleMachineSimultionSettings) new CamToComauConverter();
    ((marbleProfileCutPars) this).OptionSettings = (MarbleMachineOptionsSettings) new CamToComauConverter();
    ((marbleProfileCutPars) this).BaseWoodWidth = 3000.0;
    ((marbleProfileCutPars) this).BaseWoodHeight = 2000.0;
    ((marbleProfileCutPars) this).BaseWoodThickness = 50.0;
    ((marbleProfileCutPars) this).BaseWoodXOffset = 0.0;
    ((marbleProfileCutPars) this).BaseWoodYOffset = 0.0;
    ((marbleProfileCutPars) this).BaseWoodZOffset = -0.5;
    ((marbleProfileCutPars) this).MotorBlockBottomHeight = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buRoboticCalc(MarbleMachineSettings data)
  {
    ((marbleProfileCutPars) this).LatheSettings = (MarbleMachineLatheSettings) new CamToComauConverter();
    ((marbleProfileCutPars) this).SimulationSettings = (MarbleMachineSimultionSettings) new CamToComauConverter();
    ((marbleProfileCutPars) this).OptionSettings = (MarbleMachineOptionsSettings) new CamToComauConverter();
    ((marbleProfileCutPars) this).BaseWoodWidth = 3000.0;
    ((marbleProfileCutPars) this).BaseWoodHeight = 2000.0;
    ((marbleProfileCutPars) this).BaseWoodThickness = 50.0;
    ((marbleProfileCutPars) this).BaseWoodXOffset = 0.0;
    ((marbleProfileCutPars) this).BaseWoodYOffset = 0.0;
    ((marbleProfileCutPars) this).BaseWoodZOffset = -0.5;
    ((marbleProfileCutPars) this).MotorBlockBottomHeight = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }
}
