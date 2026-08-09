using System;
using System.ComponentModel;

namespace DevAge.ComponentModel;

[Serializable]
[ToolboxItem(false)]
public class ComponentLight : IDisposable, IComponent
{
	[NonSerialized]
	private ISite isite_0 = null;

	private bool disposed = false;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public IContainer Container
	{
		get
		{
			if (Site == null)
			{
				return null;
			}
			return Site.Container;
		}
	}

	[DefaultValue(null)]
	[Browsable(false)]
	public ISite Site
	{
		get
		{
			return isite_0;
		}
		set
		{
			isite_0 = value;
		}
	}

	public event EventHandler Disposed;

	public ComponentLight()
	{
	}

	public ComponentLight(ComponentLight other)
	{
	}

	protected virtual object GetService(Type service)
	{
		if (Site == null)
		{
			return null;
		}
		return Site.GetService(service);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposed)
		{
			return;
		}
		if (disposing)
		{
			lock (this)
			{
				if (Site != null && Site.Container != null)
				{
					Site.Container.Remove(this);
				}
			}
			if (this.Disposed != null)
			{
				this.Disposed(this, EventArgs.Empty);
			}
		}
		disposed = true;
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	~ComponentLight()
	{
		Dispose(disposing: false);
	}
}
