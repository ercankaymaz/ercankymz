// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.ClassViewer.setColorComboControl
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buControls.ColorPicker;
using buControls.Controls;
using buEyeBaseVer5.Forms.Cam;
using buEyeBaseVer5.Forms.Controls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.ClassViewer;

[ToolboxItem(false)]
public class setColorComboControl : buColorComboBox
{
  public buCheckBox chk_flatlandoffset;

  public void Init()
  {
    ((F_CamTriMeshSettings) this).PropertiesForm.Inited = false;
    if (((F_CamTriMeshSettings) this).PropertiesForm.Height > 10)
      this.Height = ((F_CamTriMeshSettings) this).PropertiesForm.Height;
    if (((F_CamTriMeshSettings) this).PropertiesForm.Width > 10)
      this.Width = ((F_CamTriMeshSettings) this).PropertiesForm.Width;
    ((Form) this).TopMost = ((F_CamTriMeshSettings) this).PropertiesForm.TopMost;
    ((Form) this).StartPosition = ((F_CamTriMeshSettings) this).PropertiesForm.FormPosition;
    ((F_CamTriMeshSettings) this).\u0001.Items.Clear();
    ((F_CamTriMeshSettings) this).\u0001.Items.AddRange(Enum.GetValues(typeof (ContentAlignment)).Cast<object>().ToArray<object>());
    ((F_CamTriMeshSettings) this).\u0002.Items.Clear();
    ((F_CamTriMeshSettings) this).\u0002.Items.AddRange(Enum.GetValues(typeof (ShapeType)).Cast<object>().ToArray<object>());
    if (((F_CamTriMeshSettings) this).refButton != null)
    {
      ((F_CamTriMeshSettings) this).\u0001.Display = ((F_CamTriMeshSettings) this).refButton.Display;
      ((F_CamTriMeshSettings) this).\u0002.Display = ((F_CamTriMeshSettings) this).refButton.ButtonDownDisplay;
      ((F_CamTriMeshSettings) this).\u0003.Display = ((F_CamTriMeshSettings) this).refButton.ButtonOverDisplay;
      ((F_CamTriMeshSettings) this).spn_geometryrad.Value = (double) ((F_CamTriMeshSettings) this).refButton.Geometry.ArcDiameter;
      ((F_CamTriMeshSettings) this).\u0002.SelectedItem = (object) ((F_CamTriMeshSettings) this).refButton.Geometry.ShapeMode;
      ((F_CamTriMeshSettings) this).\u0001.SelectedItem = (object) ((F_CamTriMeshSettings) this).refButton.ImageAlign;
      ((F_CamTriMeshSettings) this).btn_ref.Display = ((F_CamTriMeshSettings) this).\u0001.Display;
      ((F_CamTriMeshSettings) this).btn_ref.ButtonDownDisplay = ((F_CamTriMeshSettings) this).\u0002.Display;
      ((F_CamTriMeshSettings) this).btn_ref.ButtonOverDisplay = ((F_CamTriMeshSettings) this).\u0003.Display;
      ((F_CamTriMeshSettings) this).\u0001.UpdateControl();
      ((F_CamTriMeshSettings) this).\u0002.UpdateControl();
      ((F_CamTriMeshSettings) this).\u0003.UpdateControl();
    }
    ((F_CamTriMeshSettings) this).PropertiesForm.Result = DialogResult.None;
    ((F_CamTriMeshSettings) this).PropertiesForm.Inited = true;
    \u0007.\u0001.\u0001((F_ControlUIButton) this);
  }
}
