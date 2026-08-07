// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Views.F_Preview
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buControls.Viewer;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.WinControlForms.Views;

public class F_Preview : Form
{
  public static List<string> Captions = new List<string>();
  public List<eEntities> Entities = new List<eEntities>();
  public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;
  public string FormCaption = "Preview";
  public bool CoordinateByMouse = true;
  private IContainer icontainer_0 = (IContainer) null;
  internal buViewer buViewer_0;

  public F_Preview() => Class39.smethod_29(this);

  public void Init()
  {
    this.buViewer_0.Entities = new List<eEntities>();
    for (int index = 0; index <= this.Entities.Count - 1; ++index)
    {
      eEntities copiedEnt = new eEntities();
      eEntities.CopyEntity(this.Entities[index], ref copiedEnt);
      this.buViewer_0.Entities.Add(copiedEnt);
    }
    this.buViewer_0.DrawEntities();
    this.buViewer_0.ZoomFit();
    this.buViewer_0.ZoomOut();
    this.LoadLanguage();
    GC.Collect();
  }

  public void LoadLanguage()
  {
    if (F_Preview.Captions.Count < 1)
      return;
    this.Text = F_Preview.Captions[0];
  }

  internal void method_0(object sender, FormClosingEventArgs e)
  {
    e.Cancel = true;
    if (this.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.FormCloseMode == FormCloseModeType.Invisible)
      this.Visible = false;
    if (this.FormCloseMode != FormCloseModeType.Close)
      return;
    this.Close();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
