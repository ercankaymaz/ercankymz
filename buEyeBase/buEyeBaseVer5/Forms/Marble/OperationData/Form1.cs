// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Marble.OperationData.Form1
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Controls;
using dummy_ptr;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Marble.OperationData;

public class Form1 : Form
{
  internal buLabel \u0001;

  static Form1() => F_MarbleHorizontalCut.Captions = new List<string>();

  public Form1()
  {
    ((F_MarbleAxesSettings) this).SpinBaseColor = Color.LightGreen;
    ((F_MarbleAxesSettings) this).SpinFocusColor = Color.MistyRose;
    ((F_MarbleSawMillingContourSetting) this).AngleValue = 0.0;
    ((F_MarbleSawMillingContourSetting) this).PropertiesForm = new FormProperties();
    ((F_MarbleSawMillingContourSetting) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_MarbleSetAngle) this);
  }
}
