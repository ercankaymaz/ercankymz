// Decompiled with JetBrains decompiler
// Type: DevAge.ComponentModel.ComponentLight
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.ComponentModel;

#nullable disable
namespace DevAge.ComponentModel;

[ToolboxItem(false)]
[Serializable]
public class ComponentLight : IDisposable, IComponent
{
  [NonSerialized]
  private ISite isite_0 = (ISite) null;
  private bool disposed = false;

  public ComponentLight()
  {
  }

  public ComponentLight(ComponentLight other)
  {
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  [Browsable(false)]
  public IContainer Container => this.Site == null ? (IContainer) null : this.Site.Container;

  protected virtual object GetService(Type service)
  {
    return this.Site == null ? (object) null : this.Site.GetService(service);
  }

  public event EventHandler Disposed;

  [DefaultValue(null)]
  [Browsable(false)]
  public ISite Site
  {
    get => this.isite_0;
    set => this.isite_0 = value;
  }

  protected virtual void Dispose(bool disposing)
  {
    if (this.disposed)
      return;
    if (disposing)
    {
      lock (this)
      {
        if ((this.Site == null ? 0 : (this.Site.Container != null ? 1 : 0)) != 0)
          this.Site.Container.Remove((IComponent) this);
      }
      if (this.Disposed != null)
        this.Disposed((object) this, EventArgs.Empty);
    }
    this.disposed = true;
  }

  public void Dispose()
  {
    this.Dispose(true);
    GC.SuppressFinalize((object) this);
  }

  ~ComponentLight() => this.Dispose(false);
}
