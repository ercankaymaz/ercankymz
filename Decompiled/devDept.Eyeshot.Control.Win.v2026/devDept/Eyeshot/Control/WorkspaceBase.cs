#define WINFORMS
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using devDept.Diagnostic;
using devDept.Geometry;
using devDept.Graphics;

namespace devDept.Eyeshot.Control;

public abstract class WorkspaceBase : System.Windows.Forms.Control, ISupportInitialize, IMessageFilter
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal rendererType _0023_003DzLiazRDDl7mem7npetQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal _0023_003DzoFrj_j4xP7LR4PzpMFSwbLcZc_0024wi _0023_003DzY7PoD1c_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal _0023_003Dz3yTehjY_1ZV5QPm48sNaXRgcW8e5 _0023_003DzxIgINtc_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal RenderContextBase _0023_003DzmNZD0Zs_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly ToolTip _0023_003DzWzhNRpNHgT2b = new ToolTip();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Cursor _0023_003DzByXVr0E_0024Xvje;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Cursor _0023_003DzCRjLB8xmFyn8;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Cursor _0023_003DzPK2U1X_CaUvq;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Cursor _0023_003DzOuCsi3Nw7q_0024xhQQx0A_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Cursor _0023_003DzMANLSxJk4AWs;

	[Category("Workspace - Initialization")]
	[Description("Gets or sets the desired Renderer.")]
	public rendererType Renderer
	{
		get
		{
			return _0023_003DzLiazRDDl7mem7npetQ_003D_003D;
		}
		set
		{
			if (base.IsHandleCreated && !IsDesignMode())
			{
				string message = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348600973);
				Logger.Instance.Error(((Workspace)this).InstanceId, message, null);
				throw new EyeshotException(message);
			}
			_0023_003DzLiazRDDl7mem7npetQ_003D_003D = value;
			Logger.Instance.Info(((Workspace)this).InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348596761), _0023_003DzLiazRDDl7mem7npetQ_003D_003D);
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public RenderContextBase RenderContext
	{
		get
		{
			return _0023_003DzmNZD0Zs_003D;
		}
		set
		{
			_0023_003DzmNZD0Zs_003D = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override Color BackColor
	{
		get
		{
			return base.BackColor;
		}
		set
		{
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override Image BackgroundImage
	{
		get
		{
			return base.BackgroundImage;
		}
		set
		{
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override ImageLayout BackgroundImageLayout
	{
		get
		{
			return base.BackgroundImageLayout;
		}
		set
		{
			throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601024));
		}
	}

	[Description("Affects the color of the fps string.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public override Color ForeColor
	{
		get
		{
			return base.ForeColor;
		}
		set
		{
			base.ForeColor = value;
		}
	}

	protected override Size DefaultSize => new Size(320, 320);

	static WorkspaceBase()
	{
		_0023_003Dz3q1x_lkzCKr3hY_BuQ_003D_003D._0023_003DzL07WkTo_003D _0023_003DzL07WkTo_003D = (_0023_003Dz3q1x_lkzCKr3hY_BuQ_003D_003D._0023_003DzL07WkTo_003D)0;
		object[] array = null;
		array = new object[1] { _0023_003DzL07WkTo_003D };
		_0023_003DzyhuoqeH8sA2fipOFVu_0024vNrvZ5baZl1cB7KAOHYNB1gCDLfwzSg_003D_003D._0023_003DzJFvCOLF47QY9KjaoNO2URxP_00249fg9qG9I_0024MUMd5p_0024tKrBmG2JgA_003D_003D()._0023_003DzPpVzJh2WmrmhWqXh9NNYr_0024sLr3Oq(_0023_003DzyhuoqeH8sA2fipOFVu_0024vNrvZ5baZl1cB7KAOHYNB1gCDLfwzSg_003D_003D._0023_003Dzc3Qn0OgNn7PNyXPUMe9oTNMJcU481onqr2l7palyXDkZrhZNbQ_003D_003D(), "M#I>Qq\"ad(", array);
	}

	protected WorkspaceBase()
	{
		base.BackColor = Color.LightGray;
		Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		SetStyle(ControlStyles.ResizeRedraw, value: true);
		if (IsDesignMode())
		{
			base.FontChanged += _0023_003DzCrUc7kFlvf4f;
		}
	}

	public abstract void InitializeViewports();

	public abstract bool IsDesignMode();

	private bool ShouldSerializeRenderer()
	{
		return Renderer != rendererType.OpenGL;
	}

	private void ResetRenderer()
	{
		Renderer = rendererType.OpenGL;
	}

	internal SizeF _0023_003DztnrgTmT5sBNd()
	{
		return UtilityEx.GetScalingLevel();
	}

	private void _0023_003DzCrUc7kFlvf4f(object _0023_003DzxwGby4M_003D, EventArgs _0023_003Dz1SmHC4c_003D)
	{
		Workspace obj = (Workspace)this;
		obj._0023_003DzPxrSykdhxj_0024ErGq9Jg_003D_003D(_0023_003DzKgAu6qDy__0024H_0024: false);
		obj.CompileUserInterfaceElements();
		obj.UpdateDesignModeScene();
		obj.Invalidate();
	}

	internal bool _0023_003DzAn5aCJc_003D()
	{
		return base.Parent != null;
	}

	internal Color _0023_003DzPLHOLrUGcLLG()
	{
		return base.ForeColor;
	}

	internal Color _0023_003DzBkFnx3LCeZ0EQCoBYw_003D_003D()
	{
		for (System.Windows.Forms.Control control = base.Parent; control != null; control = control.Parent)
		{
			if (control.BackColor.A == byte.MaxValue)
			{
				return control.BackColor;
			}
		}
		return Color.White;
	}

	internal Color _0023_003DzU7yFFKcRyseX()
	{
		if (base.Parent == null)
		{
			return Color.White;
		}
		return base.Parent.BackColor;
	}

	internal void _0023_003DzMhFbfqb7W7_B(bool _0023_003DzSgZxUH0_003D)
	{
		base.DoubleBuffered = _0023_003DzSgZxUH0_003D;
	}

	private protected void _0023_003DzxopYzhAbGfyU()
	{
		_0023_003DzWzhNRpNHgT2b.AutoPopDelay = 5000;
		_0023_003DzWzhNRpNHgT2b.InitialDelay = 200;
		_0023_003DzWzhNRpNHgT2b.ReshowDelay = 1000;
		_0023_003DzWzhNRpNHgT2b.ShowAlways = true;
		_0023_003DzWzhNRpNHgT2b.Active = false;
	}

	internal void _0023_003DzhuBlAi9v6TXq(bool _0023_003DzWtFDQr8_003D)
	{
		if (IsDesignMode())
		{
			return;
		}
		if (_0023_003DzWtFDQr8_003D && !((Workspace)this)._0023_003Dz32fCUXg4rkVM._0023_003Dzw1jKay_0024z8meP())
		{
			if (!_0023_003DzWzhNRpNHgT2b.Active)
			{
				_0023_003DzWzhNRpNHgT2b.Active = true;
			}
		}
		else if (_0023_003DzWzhNRpNHgT2b.Active)
		{
			_0023_003DzWzhNRpNHgT2b.Active = false;
		}
	}

	internal void _0023_003DzPpGh50u0FkyM(string _0023_003Dz2ft66hVNYnkY)
	{
		if (_0023_003DzWzhNRpNHgT2b.GetToolTip(this) != _0023_003Dz2ft66hVNYnkY)
		{
			_0023_003DzWzhNRpNHgT2b.SetToolTip(this, _0023_003Dz2ft66hVNYnkY);
			_0023_003DzhuBlAi9v6TXq(_0023_003DzWtFDQr8_003D: true);
		}
	}

	internal void _0023_003DzIrKiHGdeRRkt()
	{
		Application.AddMessageFilter(this);
	}

	internal void _0023_003Dzeszsu8ntnZ3R()
	{
		Application.RemoveMessageFilter(this);
	}

	public bool PreFilterMessage(ref Message m)
	{
		if (!Focused)
		{
			return false;
		}
		return _0023_003DzJS1ojzsV_0024_85(m.Msg, m.LParam);
	}

	protected override void OnHandleCreated(EventArgs e)
	{
		((Workspace)this)._0023_003DzKrDqx6j0jLR2();
		base.OnHandleCreated(e);
	}

	protected override void OnPaintBackground(PaintEventArgs e)
	{
		if (_0023_003Dz8Q16RtM94O0K())
		{
			base.OnPaintBackground(e);
		}
	}

	internal void _0023_003Dz9nEsxEntbdvX(bool _0023_003DzSB0yHII_003D)
	{
		if (_0023_003DzSB0yHII_003D)
		{
			Cursor.Hide();
		}
		else
		{
			Cursor.Show();
		}
	}

	internal void _0023_003DzPHKlzPNfviRt(Rectangle _0023_003Dzols9v2M_003D)
	{
		Cursor.Clip = _0023_003Dzols9v2M_003D;
	}

	public abstract void BeginInit();

	public abstract void EndInit();

	internal abstract bool _0023_003DzJS1ojzsV_0024_85(int _0023_003Dz1xK0BLg_003D, IntPtr _0023_003DzNAnADu0_003D);

	internal abstract Stream _0023_003DzUyKAKuK2rf1X();

	private protected abstract bool _0023_003Dz8Q16RtM94O0K();

	internal abstract void _0023_003DzIRSxr5GrGB6E(IntPtr _0023_003Dziaz9rYc_003D);

	protected abstract void OnPaint();

	public abstract IntPtr WndProcMouse3D(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled);

	internal void _0023_003DzlFa_Yaf4PE_0024O()
	{
		_0023_003DzByXVr0E_0024Xvje = new Cursor(typeof(Workspace), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348600911));
		_0023_003DzCRjLB8xmFyn8 = new Cursor(typeof(Workspace), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348600941));
		_0023_003DzPK2U1X_CaUvq = new Cursor(typeof(Workspace), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348600945));
		_0023_003DzOuCsi3Nw7q_0024xhQQx0A_003D_003D = new Cursor(typeof(Workspace), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348601238));
		((Workspace)this)._0023_003Dzm3mTJqFjb_5X();
	}

	protected virtual void FreeCursors()
	{
	}

	internal virtual void _0023_003DzBpmu52eXbLog()
	{
		if (_0023_003DzWzhNRpNHgT2b != null)
		{
			_0023_003DzWzhNRpNHgT2b.Dispose();
		}
	}
}
