// Decompiled with JetBrains decompiler
// Type: DevAge.Windows.Forms.PositionRecorderIsolatedStorage
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.IO;
using DevAge.IO.IsolatedStorage;
using System.Drawing;
using System.IO;
using System.IO.IsolatedStorage;
using System.Windows.Forms;

#nullable disable
namespace DevAge.Windows.Forms;

public class PositionRecorderIsolatedStorage : IsolatedStorageSettingVersionBase
{
  private Point point_0;
  private Size size_0;
  private FormWindowState formWindowState_0;
  private RestoreFlags restoreFlags_0 = RestoreFlags.WindowState | RestoreFlags.Size | RestoreFlags.Location;
  private SaveFlags saveFlags_0 = SaveFlags.ActiveMDIMaximized;

  public PositionRecorderIsolatedStorage()
    : base(1)
  {
  }

  public RestoreFlags RestoreFlags
  {
    get => this.restoreFlags_0;
    set => this.restoreFlags_0 = value;
  }

  public SaveFlags SaveFlags
  {
    get => this.saveFlags_0;
    set => this.saveFlags_0 = value;
  }

  public Point Location
  {
    get => this.point_0;
    set => this.point_0 = value;
  }

  public Size Size
  {
    get => this.size_0;
    set => this.size_0 = value;
  }

  public FormWindowState WindowState
  {
    get => this.formWindowState_0;
    set => this.formWindowState_0 = value;
  }

  protected override void OnLoad(IsolatedStorageFileStream p_File, int p_CurrentVersion)
  {
    if (p_CurrentVersion != this.Version)
      throw new DevAge.IO.InvalidDataException();
    int num1 = StreamPersistence.ReadInt32((Stream) p_File);
    int num2 = StreamPersistence.ReadInt32((Stream) p_File);
    int num3 = StreamPersistence.ReadInt32((Stream) p_File);
    int num4 = StreamPersistence.ReadInt32((Stream) p_File);
    int num5 = StreamPersistence.ReadInt32((Stream) p_File);
    this.point_0.X = num1;
    this.point_0.Y = num2;
    this.size_0.Width = num3;
    this.size_0.Height = num4;
    this.formWindowState_0 = (FormWindowState) num5;
  }

  protected override void OnSave(IsolatedStorageFileStream p_File)
  {
    base.OnSave(p_File);
    StreamPersistence.Write((Stream) p_File, this.point_0.X);
    StreamPersistence.Write((Stream) p_File, this.point_0.Y);
    StreamPersistence.Write((Stream) p_File, this.size_0.Width);
    StreamPersistence.Write((Stream) p_File, this.size_0.Height);
    StreamPersistence.Write((Stream) p_File, (int) this.formWindowState_0);
  }

  protected override void OnCreate()
  {
    this.point_0 = new Point(int.MinValue, int.MinValue);
    this.size_0 = new Size(int.MinValue, int.MinValue);
    this.formWindowState_0 = ~FormWindowState.Normal;
  }

  public virtual void Save(Control p_Control)
  {
    if (p_Control is Form)
    {
      Form form = (Form) p_Control;
      this.WindowState = ((this.saveFlags_0 & SaveFlags.ActiveMDIMaximized) != SaveFlags.ActiveMDIMaximized ? 0 : (form.IsMdiChild ? 1 : 0)) == 0 ? form.WindowState : ((form.MdiParent.ActiveMdiChild == null ? 0 : (form.MdiParent.ActiveMdiChild.WindowState == FormWindowState.Maximized ? 1 : 0)) == 0 ? form.WindowState : FormWindowState.Maximized);
    }
    if (this.WindowState != FormWindowState.Minimized)
    {
      this.Location = p_Control.Location;
      this.Size = p_Control.Size;
    }
    this.Save();
  }

  public virtual void Load(Control p_Control)
  {
    this.Load();
    if ((this.RestoreFlags & RestoreFlags.WindowState) == RestoreFlags.WindowState && (!(p_Control is Form) || this.WindowState == ~FormWindowState.Normal ? 0 : (this.WindowState != FormWindowState.Minimized ? 1 : ((this.RestoreFlags & RestoreFlags.Minimized) == RestoreFlags.Minimized ? 1 : 0))) != 0)
      ((Form) p_Control).WindowState = this.WindowState;
    if ((!(p_Control is Form) ? 0 : (((Form) p_Control).WindowState == FormWindowState.Minimized ? 1 : 0)) != 0)
      return;
    if (((this.RestoreFlags & RestoreFlags.Location) != RestoreFlags.Location ? 0 : (this.Location.X != int.MinValue ? 1 : 0)) != 0)
      p_Control.Location = this.Location;
    if (((this.RestoreFlags & RestoreFlags.Size) != RestoreFlags.Size ? 0 : (this.Size.Width != int.MinValue ? 1 : 0)) == 0)
      return;
    p_Control.Size = this.Size;
  }
}
