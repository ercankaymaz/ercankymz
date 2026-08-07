// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buArc
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.ColorPicker;
using buControls.Controls;
using buEyeBaseVer5.ClassViewer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.buEntities;

[Serializable]
public class buArc : buEntity
{
  public buSpin spn_LagAngle;
  public buButton btn_ok;
  public buSpin spn_SideTiltAngle;
  public buButton btn_cancel;
  public buSpin spn_AAngleLimitStartInYZPlane;
  public buSpin spn_AAngleLimitEndInYZPlane;

  public buArc()
  {
    ((buShapeVisualition) this).EditValue = (object) null;
    // ISSUE: explicit constructor call
    ((NumericUpDown) this).\u002Ector();
  }

  public buArc()
  {
    ((buShapeVisualition) this).EditValue = (object) null;
    // ISSUE: explicit constructor call
    ((TextBox) this).\u002Ector();
  }

  public buArc()
  {
    ((buShapeVisualition) this).EditValue = (object) null;
    // ISSUE: explicit constructor call
    ((CheckBox) this).\u002Ector();
  }

  public buArc()
  {
    ((buShapeVisualition) this).EditValue = (object) null;
    // ISSUE: explicit constructor call
    ((Label) this).\u002Ector();
  }

  public buArc()
  {
    ((buShapeVisualition) this).EditValue = (object) null;
    // ISSUE: explicit constructor call
    ((ComboBox) this).\u002Ector();
  }

  public buArc()
  {
    ((buShapeVisualition) this).EditValue = (object) null;
    // ISSUE: explicit constructor call
    ((DateTimePicker) this).\u002Ector();
  }

  public buArc()
  {
    ((buCompositeCurveCam) this).EditValue = (object) null;
    // ISSUE: explicit constructor call
    ((buColorComboBox) this).\u002Ector();
  }

  public buArc()
  {
    ((buCompositeCurveCam) this).RowHeight = 30;
    ((buCompositeCurveCam) this).RowSpace = 4;
    ((buLinearPathCam) this).DecimalPlace = 3;
    ((buLinearPathCam) this).FontCaptions = new Font("Times New Roman", 12f);
    ((buLinearPathCam) this).FontValues = new Font("Times New Roman", 12f);
    ((buLinearPathCam) this).ValueWidth = 250;
    ((buLinearPathCam) this).ShowOkButton = false;
    ((buArcCam) this).ShowCancelButton = false;
    ((buArcCam) this).OkButtonText = "Ok";
    ((buArcCam) this).CancelButtonText = "Cancel";
    ((buArcCam) this).ClassObject = (object) null;
    ((buLineCam) this).OwnerForm = (Form) null;
    ((buLineCam) this).TouchPayStyle = TouchPadType.buControlStyleBasic;
    ((buLineCam) this).ParCaptions = new List<string>();
    ((buTool) this).ControlList = new List<Control>();
    ((buTool) this).\u0001 = new Label();
    ((buTool) this).\u0001 = new Button();
    ((buTool) this).\u0002 = new Button();
    ((buTool) this).\u0001 = (setColorComboControl) new buArc();
    ((buTool) this).\u0001 = (setDateTimeControl) new buArc();
    ((buTool) this).\u0001 = (setLabelControl) new buArc();
    ((buTool) this).\u0001 = (setCheckBoxControl) new buArc();
    ((buTool) this).\u0002 = (setLabelControl) new buArc();
    ((buTool) this).\u0003 = (setLabelControl) new buArc();
    ((buTool) this).\u0001 = (setNumericUpDownControl) new buArc();
    ((buTool) this).\u0001 = (setComboBoxControl) new buArc();
    ((buTool) this).\u0001 = (setTextBoxControl) new buArc();
    ((buTool) this).\u0001 = new PictureBox();
    ((buTool) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    ((UserControl) this).\u002Ector();
    \u0007.\u0001.\u0001((buClassViewerColor5) this);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_ValueChanged(buClassViewerColor5.ClassViewerEventHandler5 value)
  {
    // ISSUE: reference to a compiler-generated field
    buClassViewerColor5.ClassViewerEventHandler5 viewerEventHandler5 = ((buTool) this).\u0001;
    buClassViewerColor5.ClassViewerEventHandler5 comparand;
    do
    {
      comparand = viewerEventHandler5;
      // ISSUE: reference to a compiler-generated field
      viewerEventHandler5 = Interlocked.CompareExchange<buClassViewerColor5.ClassViewerEventHandler5>(ref ((buTool) this).\u0001, comparand + value, comparand);
    }
    while (viewerEventHandler5 != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_ValueChanged(buClassViewerColor5.ClassViewerEventHandler5 value)
  {
    // ISSUE: reference to a compiler-generated field
    buClassViewerColor5.ClassViewerEventHandler5 viewerEventHandler5 = ((buTool) this).\u0001;
    buClassViewerColor5.ClassViewerEventHandler5 comparand;
    do
    {
      comparand = viewerEventHandler5;
      // ISSUE: reference to a compiler-generated field
      viewerEventHandler5 = Interlocked.CompareExchange<buClassViewerColor5.ClassViewerEventHandler5>(ref ((buTool) this).\u0001, comparand - value, comparand);
    }
    while (viewerEventHandler5 != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_OkButtonClicked(System.EventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    System.EventHandler eventHandler = ((buTool) this).\u0001;
    System.EventHandler comparand;
    do
    {
      comparand = eventHandler;
      // ISSUE: reference to a compiler-generated field
      eventHandler = Interlocked.CompareExchange<System.EventHandler>(ref ((buTool) this).\u0001, comparand + value, comparand);
    }
    while (eventHandler != comparand);
  }
}
