using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(false)]
[DesignerCategory("code")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public abstract class VisualControl : VisualControlBase, ISupportInitializeNotification, ISupportInitialize
{
	private bool _initializing;

	private bool _initialized;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public bool IsInitialized
	{
		[DebuggerStepThrough]
		get
		{
			return _initialized;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public bool IsInitializing
	{
		[DebuggerStepThrough]
		get
		{
			return _initializing;
		}
	}

	internal bool InDesignMode => base.DesignMode;

	[Category("Behavior")]
	[Description("Occurs when the control has been fully initialized.")]
	public event EventHandler Initialized;

	public virtual void BeginInit()
	{
		_initializing = true;
		SuspendLayout();
	}

	public virtual void EndInit()
	{
		_initialized = true;
		_initializing = false;
		base.DirtyPaletteCounter++;
		OnNeedPaint(this, new NeedLayoutEventArgs(needLayout: true));
		ResumeLayout(performLayout: true);
		OnInitialized(EventArgs.Empty);
	}

	protected virtual void OnInitialized(EventArgs e)
	{
		if (this.Initialized != null)
		{
			this.Initialized(this, EventArgs.Empty);
		}
	}
}
