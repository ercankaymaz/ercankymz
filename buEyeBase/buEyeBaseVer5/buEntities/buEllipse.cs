// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buEllipse
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
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
public class buEllipse : buEntity
{
  public buSpin spn_CAngleLimitStartInXYPlane;
  public buSpin spn_CAngleLimitEndInXYPlane;
  public buSpin spn_WOrtAngleLimitStart;
  public buSpin spn_WOrtAngleLimitEnd;
  public buCheckBox chk_BAngleLimit;

  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  public virtual extern void Invoke(object sender, object Value, cParameter5 Parameter);

  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  public virtual extern IAsyncResult BeginInvoke(
    object sender,
    object Value,
    cParameter5 Parameter,
    AsyncCallback callback,
    object @object);

  [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
  public virtual extern void EndInvoke(IAsyncResult result);

  public buEllipse()
  {
    ((buMachinePart) this).RowHeight = 30;
    ((buMachinePart) this).RowSpace = 4;
    ((buMachinePart) this).DecimalPlace = 3;
    ((buMachinePart) this).FontCaptions = new Font("Times New Roman", 12f);
    ((buMachinePart) this).FontValues = new Font("Times New Roman", 12f);
    ((buMachinePart) this).ValueWidth = 250;
    ((buMachinePart) this).ShowOkButton = false;
    ((buMachinePart) this).ShowCancelButton = false;
    ((buMachinePart) this).OkButtonText = "Ok";
    ((buMachinePart) this).CancelButtonText = "Cancel";
    ((buMachinePart) this).ClassObject = (object) null;
    ((buMachinePart) this).OwnerForm = (Form) null;
    ((buMachinePart) this).TouchPayStyle = TouchPadType.buControlStyleBasic;
    ((buMachinePart) this).ParCaptions = new List<string>();
    ((buMachinePart) this).ControlList = new List<Control>();
    ((buMachinePart) this).\u0001 = new Label();
    ((buMachinePart) this).\u0001 = new Button();
    ((buMachinePart) this).\u0002 = new Button();
    ((buMachinePart) this).\u0001 = (setColorComboControl) new buArc();
    ((buMachinePart) this).\u0001 = (setDateTimeControl) new buArc();
    ((buMachinePart) this).\u0001 = (setLabelControl) new buArc();
    ((buMachinePart) this).\u0001 = (setCheckBoxControl) new buArc();
    ((buMachinePart) this).\u0002 = (setLabelControl) new buArc();
    ((buMachinePart) this).\u0003 = (setLabelControl) new buArc();
    ((buMachinePart) this).\u0001 = (setNumericUpDownControl) new buArc();
    ((buMachinePart) this).\u0001 = (setComboBoxControl) new buArc();
    ((buMachinePart) this).\u0001 = (setTextBoxControl) new buArc();
    ((buMachinePart) this).\u0001 = new PictureBox();
    ((buMachinePart) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    ((UserControl) this).\u002Ector();
    \u0007.\u0001.\u0001((buClassViewer5) this);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_ValueChanged(buClassViewer5.ClassViewerEventHandler5 value)
  {
    // ISSUE: reference to a compiler-generated field
    buClassViewer5.ClassViewerEventHandler5 viewerEventHandler5 = ((buMachinePart) this).\u0001;
    buClassViewer5.ClassViewerEventHandler5 comparand;
    do
    {
      comparand = viewerEventHandler5;
      // ISSUE: reference to a compiler-generated field
      viewerEventHandler5 = Interlocked.CompareExchange<buClassViewer5.ClassViewerEventHandler5>(ref ((buMachinePart) this).\u0001, comparand + value, comparand);
    }
    while (viewerEventHandler5 != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_ValueChanged(buClassViewer5.ClassViewerEventHandler5 value)
  {
    // ISSUE: reference to a compiler-generated field
    buClassViewer5.ClassViewerEventHandler5 viewerEventHandler5 = ((buMachinePart) this).\u0001;
    buClassViewer5.ClassViewerEventHandler5 comparand;
    do
    {
      comparand = viewerEventHandler5;
      // ISSUE: reference to a compiler-generated field
      viewerEventHandler5 = Interlocked.CompareExchange<buClassViewer5.ClassViewerEventHandler5>(ref ((buMachinePart) this).\u0001, comparand - value, comparand);
    }
    while (viewerEventHandler5 != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_OkButtonClicked(EventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    EventHandler eventHandler = ((buMachinePart) this).\u0001;
    EventHandler comparand;
    do
    {
      comparand = eventHandler;
      // ISSUE: reference to a compiler-generated field
      eventHandler = Interlocked.CompareExchange<EventHandler>(ref ((buMachinePart) this).\u0001, comparand + value, comparand);
    }
    while (eventHandler != comparand);
  }
}
