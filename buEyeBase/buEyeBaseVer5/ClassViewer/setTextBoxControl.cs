// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.ClassViewer.setTextBoxControl
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buControls.Controls;
using buEyeBaseVer5.Forms.Cam;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.ClassViewer;

[ToolboxItem(false)]
public class setTextBoxControl : TextBox
{
  public buCheckBox chk_depthstepenableflatland;

  internal void \u0001([In] object obj0, [In] double obj1)
  {
    if (!((obj0 as Control).Name == ((F_CamTriMeshSettings) this).spn_geometryrad.Name))
      return;
    ((F_CamTriMeshSettings) this).\u0001.Geometry.ArcDiameter = (int) ((F_CamTriMeshSettings) this).spn_geometryrad.Value;
    ((F_CamTriMeshSettings) this).refLabel.Geometry.ArcDiameter = (int) ((F_CamTriMeshSettings) this).spn_geometryrad.Value;
  }
}
