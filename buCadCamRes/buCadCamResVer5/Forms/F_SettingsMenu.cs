// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Forms.F_SettingsMenu
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buControls.ClassViewer;
using buEyeBaseVer5;
using ns8;
using System;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.Forms;

public class F_SettingsMenu : Form
{
  private IContainer icontainer_0 = (IContainer) null;
  internal Button button_0;
  internal Button button_1;
  internal ImageList imageList_0;
  internal Button button_2;
  internal Button button_3;

  public F_SettingsMenu() => Class5.smethod_136(this);

  internal void method_0(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (control2.Name == this.button_1.Name)
    {
      F_ClassViewerDialog classViewerDialog = new F_ClassViewerDialog();
      classViewerDialog.Text = "Analyse";
      classViewerDialog.Value = (object) clsVar.varInterface5.AnalyseEntitySetting;
      classViewerDialog.StartPosition = FormStartPosition.CenterParent;
      classViewerDialog.Width = 500;
      classViewerDialog.Height = 600;
      classViewerDialog.ValuePersentage = 35.0;
      classViewerDialog.Init();
      int num = (int) classViewerDialog.ShowDialog();
      if (classViewerDialog.Result == DialogResult.OK)
      {
        clsVar.varInterface5.AnalyseEntitySetting = new AnalyseEntitiesSetting((AnalyseEntitiesSetting) classViewerDialog.Value);
        clsFiles.SaveParameter();
      }
    }
    if (control2.Name == this.button_2.Name)
    {
      F_ClassViewerDialog classViewerDialog = new F_ClassViewerDialog();
      classViewerDialog.Text = "Arrow";
      classViewerDialog.Value = (object) clsVar.varInterface5.DirectionArrowSettings;
      classViewerDialog.StartPosition = FormStartPosition.CenterParent;
      classViewerDialog.Width = 500;
      classViewerDialog.Height = 600;
      classViewerDialog.ValuePersentage = 35.0;
      classViewerDialog.Init();
      int num = (int) classViewerDialog.ShowDialog();
      if (classViewerDialog.Result == DialogResult.OK)
      {
        clsVar.varInterface5.DirectionArrowSettings = new DirectionArrowSetting((DirectionArrowSetting) classViewerDialog.Value);
        clsFiles.SaveParameter();
      }
    }
    if (control2.Name == this.button_3.Name)
    {
      F_ClassViewerDialog classViewerDialog = new F_ClassViewerDialog();
      classViewerDialog.Text = "Arrow";
      classViewerDialog.Value = (object) clsVar.varInterface5.FlatViewSettings;
      classViewerDialog.StartPosition = FormStartPosition.CenterParent;
      classViewerDialog.Width = 500;
      classViewerDialog.Height = 600;
      classViewerDialog.ValuePersentage = 35.0;
      classViewerDialog.Init();
      int num = (int) classViewerDialog.ShowDialog();
      if (classViewerDialog.Result == DialogResult.OK)
      {
        clsVar.varInterface5.FlatViewSettings = new FlatViewSettings((FlatViewSettings) classViewerDialog.Value);
        clsFiles.SaveParameter();
      }
    }
    if (!(control2.Name == this.button_0.Name))
      return;
    this.Visible = false;
  }

  internal void method_1(object sender, FormClosingEventArgs e)
  {
    e.Cancel = true;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
