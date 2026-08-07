// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_Mirror
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Events;
using buEyeBaseVer5.Variables;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;
using devDept.Geometry;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms;

public class F_Mirror : Form
{
  public CamClosedContourType OffsetType;
  public bool DeleteOriginal;
  public double OffsetValue;
  public FormProperties PropertiesForm;
  private IContainer \u0001;
  internal Label \u0001;
  internal Label \u0002;
  internal Label \u0003;
  internal Panel \u0001;
  internal NumericUpDown \u0001;
  internal Button \u0001;
  internal ImageList \u0001;
  internal Button \u0002;
  internal Panel \u0002;
  internal Label \u0004;
  internal Label \u0005;
  internal CheckBox \u0001;
  internal RadioButton \u0001;
  internal RadioButton \u0002;
  public static byte f000AB9;
  public static List<string> Captions;
  public CutterNotch Notch;
  public bool ChangeDirection;
  public FormProperties PropertiesForm;
  private IContainer \u0001;

  public void ReadStepFile(string FileName, ref List<Entity> Entities)
  {
    ReadSTEP readStep = new ReadSTEP(FileName);
    readStep.DoWork();
    if (readStep.Entities == null)
      return;
    Entities.AddRange((IEnumerable<Entity>) readStep.Entities);
  }

  public void ReadStepFile(string FileName, ref Design refViewport)
  {
    ReadSTEP readStep = new ReadSTEP(FileName);
    readStep.DoWork();
    if (readStep.Entities == null)
      return;
    readStep.OpenTo((IDesign) refViewport);
  }

  public void ReadGCodeFile(string FileName)
  {
  }

  public void SaveModelEnitities(string FileName, Design refModel) => refModel.SaveFile(FileName);

  public void OpenModelEnitities(string FileName, ref Design refModel)
  {
    refModel.OpenFile(FileName);
  }

  static F_Mirror()
  {
    EditorRuntimeSettings.AskMeResult = "";
    EditorRuntimeSettings.AskMeValue = 0.0;
    EditorRuntimeSettings.AskMe = (SortAskMe) new CurveToSurfaceSettingsType();
    EditorRuntimeSettings.AskMeBu = (SortbuAskMe) new dynamicInfo();
    EditorRuntimeSettings.PointClickData = (SortPointClickData) new SelectionAlingmentPoints();
    DrawingFinisedEventArgs.baseModel = (Design) null;
    DrawingFinisedEventArgs.ScreenInfo = (screenInfo) new EntitiesGroup();
    // ISSUE: reference to a compiler-generated field
    \u0082.\u0001.RegenDeviation = 0.01;
    // ISSUE: reference to a compiler-generated field
    \u0082.\u0001.\u0001 = "EU23-EGYEF-UX12Y-K7RW-RE09";
  }

  static F_Mirror()
  {
    F_CutterMachineSettings.\u003C\u003E9 = (buVector5.\u003C\u003Ec) new F_Mirror();
  }

  internal ICurve \u0001([In] Entity obj0) => (ICurve) obj0;

  internal LinearPath \u0001([In] Point3D[] obj0) => new LinearPath(obj0);

  internal ICurve \u0002([In] Entity obj0) => (ICurve) obj0;

  public event OkCommandWithDataEventHandler CommandOk;

  public event CancelCommandEventHandler CommandCancel;

  public event ApplyCommandWithDataEventHandler CommandApply;
}
