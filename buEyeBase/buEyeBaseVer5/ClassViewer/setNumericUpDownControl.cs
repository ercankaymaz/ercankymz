// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.ClassViewer.setNumericUpDownControl
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buControls.Controls;
using buEyeBaseVer5.Forms.Cam;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.ClassViewer;

[ToolboxItem(false)]
public class setNumericUpDownControl : NumericUpDown
{
  internal buGroup \u0016;

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    if ((obj0 as Control).Name == ((F_CamTriMeshSettings) this).\u0001.Name)
      ((F_CamTriMeshSettings) this).\u0001.Display = ((F_CamTriMeshSettings) this).\u0001.Display;
    ((F_CamTriMeshSettings) this).\u0001.Invalidate();
  }
}
