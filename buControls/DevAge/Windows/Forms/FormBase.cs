// Decompiled with JetBrains decompiler
// Type: DevAge.Windows.Forms.FormBase
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

#nullable disable
namespace DevAge.Windows.Forms;

public class FormBase : Form
{
  internal System.ComponentModel.Container container_0 = (System.ComponentModel.Container) null;
  private PositionRecorderIsolatedStorage positionRecorderIsolatedStorage_0 = new PositionRecorderIsolatedStorage();

  public FormBase()
  {
    Class39.smethod_724(this);
    string str = $"{AppDomain.CurrentDomain.FriendlyName}.{this.GetType().ToString()}.frp";
    foreach (char invalidPathChar in Path.GetInvalidPathChars())
      str = str.Replace(new string(invalidPathChar, 1), "");
    this.StorageFileName = str;
    this.RestoreFlags = RestoreFlags.None;
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.container_0 != null)
      this.container_0.Dispose();
    base.Dispose(disposing);
  }

  [Description("Isolated Storage FileName where the form save the position information")]
  public virtual string StorageFileName
  {
    get => this.positionRecorderIsolatedStorage_0.StorageFileName;
    set => this.positionRecorderIsolatedStorage_0.StorageFileName = value;
  }

  [Description("Restore flags")]
  public virtual RestoreFlags RestoreFlags
  {
    get => this.positionRecorderIsolatedStorage_0.RestoreFlags;
    set => this.positionRecorderIsolatedStorage_0.RestoreFlags = value;
  }

  [Description("Save flags")]
  public virtual SaveFlags SaveFlags
  {
    get => this.positionRecorderIsolatedStorage_0.SaveFlags;
    set => this.positionRecorderIsolatedStorage_0.SaveFlags = value;
  }

  protected override void OnLoad(EventArgs e)
  {
    base.OnLoad(e);
    try
    {
      if ((this.DesignMode ? 0 : ((Control.ModifierKeys & Keys.Control) != Keys.Control ? 1 : 0)) == 0)
        return;
      this.positionRecorderIsolatedStorage_0.Load((Control) this);
    }
    catch (Exception ex)
    {
      Debug.Assert(false, ex.Message);
    }
  }

  protected override void OnClosing(CancelEventArgs e)
  {
    base.OnClosing(e);
    try
    {
      if ((this.DesignMode ? 0 : ((Control.ModifierKeys & Keys.Control) != Keys.Control ? 1 : 0)) == 0)
        return;
      this.positionRecorderIsolatedStorage_0.Save((Control) this);
    }
    catch (Exception ex)
    {
      Debug.Assert(false, ex.Message);
    }
  }
}
