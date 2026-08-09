using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Meshing;
using devDept.Geometry;
using devDept.Graphics;

namespace devDept.Eyeshot.Control;

[ToolboxItem(true)]
[ToolboxBitmap(typeof(Simulation))]
[Description("Provides the ability to investigate performance using finite element analysis.")]
[Designer("devDept.Eyeshot.Designer.DesignControlDesigner, devDept.Eyeshot.Control.Win.v2026.Design")]
public class Simulation : Design
{
	private sealed class _0023_003Dz3bkkM1hGGWJMd6fIyRfwB9w_003D
	{
		public Simulation _0023_003DzKdgtcDsi34jL;

		public RenderContextBase _0023_003DzmNZD0Zs_003D;

		internal void _0023_003DzfLPmqfrZGlp6O5ha7sXIkOo_003D(RenderContextBase _0023_003DzNkgzXsMnh9_b, object _0023_003DzuueBYDLjncfR)
		{
			_0023_003DzKdgtcDsi34jL._0023_003DzWpkuWzhHzbrLm_0024WEkeeI9tw_003D(_0023_003DzmNZD0Zs_003D);
		}

		internal void _0023_003Dz9JXCJgK39EQa27e4YcywGGE_003D(RenderContextBase _0023_003DzNkgzXsMnh9_b, object _0023_003DzuueBYDLjncfR)
		{
			_0023_003DzKdgtcDsi34jL.DrawTranslationRestraint(_0023_003DzmNZD0Zs_003D);
		}

		internal void _0023_003DzVg5C8L7aWhdKR7Mc3Z4lzGM_003D(RenderContextBase _0023_003DzNkgzXsMnh9_b, object _0023_003DzuueBYDLjncfR)
		{
			_0023_003DzKdgtcDsi34jL.DrawRotationRestraint(_0023_003DzmNZD0Zs_003D);
		}

		internal void _0023_003Dzm_TNlWolD2xV1wq5kutLmYE_003D(RenderContextBase _0023_003DzNkgzXsMnh9_b, object _0023_003DzuueBYDLjncfR)
		{
			_0023_003DzKdgtcDsi34jL.DrawForce(_0023_003DzmNZD0Zs_003D);
		}

		internal void _0023_003DzknTN1LOpIkJmBg7GVgrtBac_003D(RenderContextBase _0023_003DzNkgzXsMnh9_b, object _0023_003DzuueBYDLjncfR)
		{
			_0023_003DzKdgtcDsi34jL.DrawMoment(_0023_003DzmNZD0Zs_003D);
		}

		internal void _0023_003DzqllAkjyP0TbMooRt4a7zMNc_003D(RenderContextBase _0023_003DzNkgzXsMnh9_b, object _0023_003DzuueBYDLjncfR)
		{
			_0023_003DzKdgtcDsi34jL._0023_003DzJmwbeajmWIbTqBGbLQ_003D_003D(_0023_003DzmNZD0Zs_003D);
		}

		internal void _0023_003DzpO_00247e7YrIpTeFQCWTqaXV9w_003D(RenderContextBase _0023_003DzNkgzXsMnh9_b, object _0023_003DzuueBYDLjncfR)
		{
			_0023_003DzKdgtcDsi34jL._0023_003DzHQkahxA7XJilojaQqQ_003D_003D(_0023_003DzmNZD0Zs_003D);
		}
	}

	[Serializable]
	private sealed class _0023_003DzP0sFNwY_003D
	{
		public static readonly _0023_003DzP0sFNwY_003D _0023_003Dz84eeg84_003D = new _0023_003DzP0sFNwY_003D();

		public static Func<ToolBar, bool> _0023_003DzJuvbzOkcJYLORKzQuQ_003D_003D;

		public static Func<Entity, bool> _0023_003Dz2PCuzLiqido0sCmhOQ_003D_003D;

		public static Func<Entity, Entity> _0023_003DzOsjoP2twK45xThQSVg_003D_003D;

		internal bool _0023_003Dz1PWbaAQQ7XTLTiXQWuo1c0E_003D(ToolBar _0023_003DzH69yFvkdPCYv)
		{
			return _0023_003DzH69yFvkdPCYv._0023_003DzMtJdeBwDLtvi();
		}

		internal bool _0023_003DzDOfymvufiPEvjBEmrTM_sbKg4IHu(Entity _0023_003Dz8GBMuoM_003D)
		{
			if (!(_0023_003Dz8GBMuoM_003D is FemMesh))
			{
				if (_0023_003Dz8GBMuoM_003D is NestedEntity nestedEntity && nestedEntity.entity is FemMesh && !nestedEntity.ForceGray)
				{
					return nestedEntity.parents.Count == 0;
				}
				return false;
			}
			return true;
		}

		internal Entity _0023_003DzAOwJ53Rl5tBaAYTsSAYtcgSmEd22(Entity _0023_003Dz8GBMuoM_003D)
		{
			if (!(_0023_003Dz8GBMuoM_003D is NestedEntity nestedEntity))
			{
				return _0023_003Dz8GBMuoM_003D;
			}
			return nestedEntity.entity;
		}
	}

	public delegate void SimulationPausedEventHandler(object sender, EventArgs e);

	public delegate void SimulationStartedEventHandler(object sender, EventArgs e);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private FemMesh _0023_003DzH9aDWVd0mBS7;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzpqjlSP5zsEDCdaikmg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dzn_svp9S4IgHhWIPQVpz_HKw_003D = 20;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private SimulationStartedEventHandler _0023_003DzxyPXdKmFERan;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private SimulationPausedEventHandler _0023_003Dz_0024ZG9gsVTSVkC;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private silhouettesDrawingType _0023_003DzIMzi9JAvb4iGNpwi0A_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private shadowType _0023_003DzKQKZozMiwcr5;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private shadowType _0023_003DzYMb1PVVvnw1EEg2g4A_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzW_BoWEDvWvC1HPPcmnl_rzI_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003DzjiyAmyRg6X4t = Color.Magenta;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003Dzk_0024o9chkteb27_0024X0MxA_003D_003D = Color.Cyan;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003DzzE_hbUTq9TJFOgSqtwSEKWs_003D = Color.CornflowerBlue;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003Dz_0024A7Xp4GPwMfwPdEAEEbGHsc_003D = Color.Green;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dzab2SM4cZO6FjAIPL0w_003D_003D = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzVzodAXCs9sQi = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzFUUe8_owUAdg = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private EntityGraphicsData _0023_003DzkR0wANj5mIXT;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private EntityGraphicsData _0023_003Dzs23gQos9I9jjZodCxA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private EntityGraphicsData _0023_003DzsDonKHd5EskAallJ6g_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private EntityGraphicsData _0023_003Dz6LaEDy1uum1vm8pH0g_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private EntityGraphicsData _0023_003Dz1fr8w_0024AKywAvZ9mslQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private EntityGraphicsData _0023_003DzavWp_0024UaRz2ZoBqKKL2phf5I_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private EntityGraphicsData _0023_003Dzge8fIOtHs9SBObms2kc7b7s_003D;

	[Category("Workspace")]
	[Description("Keyboard shortcuts.")]
	public new SimulationShortcutKeysSettings ShortcutKeys
	{
		get
		{
			return (SimulationShortcutKeysSettings)shortcutKeys;
		}
		set
		{
			shortcutKeys = value;
		}
	}

	public ToolBar SimulationToolBar => _0023_003DzTN1DFSSGkW6c(base.ActiveViewport);

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public FemMesh SimulationResult
	{
		get
		{
			return _0023_003DzH9aDWVd0mBS7;
		}
		set
		{
			_0023_003DzH9aDWVd0mBS7 = value;
			if (base.ActiveViewportIndex <= base.Viewports.Count)
			{
				_0023_003DzHZMqgEfrVWAi(base.ActiveViewport, CanSimulate());
			}
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int ModeIndex
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzpqjlSP5zsEDCdaikmg_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzpqjlSP5zsEDCdaikmg_003D_003D = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int SimulationFrames
	{
		get
		{
			return _0023_003Dzn_svp9S4IgHhWIPQVpz_HKw_003D;
		}
		set
		{
			_0023_003Dzn_svp9S4IgHhWIPQVpz_HKw_003D = value;
			Utility.LimitRange(8, ref _0023_003Dzn_svp9S4IgHhWIPQVpz_HKw_003D, 32);
			if (SimulationResult != null)
			{
				SimulationResult.ResetAnimation();
				SimulationResult.FrameNumber = 0;
			}
		}
	}

	public Color ForceSymbolColor
	{
		get
		{
			return _0023_003DzjiyAmyRg6X4t;
		}
		set
		{
			_0023_003DzjiyAmyRg6X4t = value;
		}
	}

	public Color PressureSymbolColor
	{
		get
		{
			return _0023_003Dzk_0024o9chkteb27_0024X0MxA_003D_003D;
		}
		set
		{
			_0023_003Dzk_0024o9chkteb27_0024X0MxA_003D_003D = value;
		}
	}

	public Color PunctualForceSymbolColor
	{
		get
		{
			return _0023_003DzzE_hbUTq9TJFOgSqtwSEKWs_003D;
		}
		set
		{
			_0023_003DzzE_hbUTq9TJFOgSqtwSEKWs_003D = value;
		}
	}

	public Color RestraintSymbolColor
	{
		get
		{
			return _0023_003Dz_0024A7Xp4GPwMfwPdEAEEbGHsc_003D;
		}
		set
		{
			_0023_003Dz_0024A7Xp4GPwMfwPdEAEEbGHsc_003D = value;
		}
	}

	[Category("Workspace - Fem")]
	[Description("Restraint symbols visibility status.")]
	public bool ShowRestraint
	{
		get
		{
			return _0023_003Dzab2SM4cZO6FjAIPL0w_003D_003D;
		}
		set
		{
			_0023_003Dzab2SM4cZO6FjAIPL0w_003D_003D = value;
			_0023_003Dz3tGL3rg_003D();
		}
	}

	[Category("Workspace - Fem")]
	[Description("Load symbols visibility status.")]
	public bool ShowLoad
	{
		get
		{
			return _0023_003DzVzodAXCs9sQi;
		}
		set
		{
			_0023_003DzVzodAXCs9sQi = value;
			_0023_003Dz3tGL3rg_003D();
		}
	}

	[Category("Workspace - Fem")]
	[Description("Joint symbols visibility status.")]
	public bool ShowJoint
	{
		get
		{
			return _0023_003DzFUUe8_owUAdg;
		}
		set
		{
			_0023_003DzFUUe8_owUAdg = value;
			_0023_003Dz3tGL3rg_003D();
		}
	}

	[Description("Occurs when the simulation is started.")]
	public event SimulationStartedEventHandler SimulationStarted
	{
		[CompilerGenerated]
		add
		{
			SimulationStartedEventHandler simulationStartedEventHandler = _0023_003DzxyPXdKmFERan;
			SimulationStartedEventHandler simulationStartedEventHandler2;
			do
			{
				simulationStartedEventHandler2 = simulationStartedEventHandler;
				SimulationStartedEventHandler value2 = (SimulationStartedEventHandler)Delegate.Combine(simulationStartedEventHandler2, value);
				simulationStartedEventHandler = Interlocked.CompareExchange(ref _0023_003DzxyPXdKmFERan, value2, simulationStartedEventHandler2);
			}
			while ((object)simulationStartedEventHandler != simulationStartedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			SimulationStartedEventHandler simulationStartedEventHandler = _0023_003DzxyPXdKmFERan;
			SimulationStartedEventHandler simulationStartedEventHandler2;
			do
			{
				simulationStartedEventHandler2 = simulationStartedEventHandler;
				SimulationStartedEventHandler value2 = (SimulationStartedEventHandler)Delegate.Remove(simulationStartedEventHandler2, value);
				simulationStartedEventHandler = Interlocked.CompareExchange(ref _0023_003DzxyPXdKmFERan, value2, simulationStartedEventHandler2);
			}
			while ((object)simulationStartedEventHandler != simulationStartedEventHandler2);
		}
	}

	[Description("Occurs when the simulation is paused.")]
	public event SimulationPausedEventHandler SimulationPaused
	{
		[CompilerGenerated]
		add
		{
			SimulationPausedEventHandler simulationPausedEventHandler = _0023_003Dz_0024ZG9gsVTSVkC;
			SimulationPausedEventHandler simulationPausedEventHandler2;
			do
			{
				simulationPausedEventHandler2 = simulationPausedEventHandler;
				SimulationPausedEventHandler value2 = (SimulationPausedEventHandler)Delegate.Combine(simulationPausedEventHandler2, value);
				simulationPausedEventHandler = Interlocked.CompareExchange(ref _0023_003Dz_0024ZG9gsVTSVkC, value2, simulationPausedEventHandler2);
			}
			while ((object)simulationPausedEventHandler != simulationPausedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			SimulationPausedEventHandler simulationPausedEventHandler = _0023_003Dz_0024ZG9gsVTSVkC;
			SimulationPausedEventHandler simulationPausedEventHandler2;
			do
			{
				simulationPausedEventHandler2 = simulationPausedEventHandler;
				SimulationPausedEventHandler value2 = (SimulationPausedEventHandler)Delegate.Remove(simulationPausedEventHandler2, value);
				simulationPausedEventHandler = Interlocked.CompareExchange(ref _0023_003Dz_0024ZG9gsVTSVkC, value2, simulationPausedEventHandler2);
			}
			while ((object)simulationPausedEventHandler != simulationPausedEventHandler2);
		}
	}

	public Simulation()
	{
		bool flag = false;
		byte b = 4;
		object[] array = null;
		array = new object[3] { b, this, flag };
		_0023_003DzyhuoqeH8sA2fipOFVu_0024vNrvZ5baZl1cB7KAOHYNB1gCDLfwzSg_003D_003D._0023_003DzJFvCOLF47QY9KjaoNO2URxP_00249fg9qG9I_0024MUMd5p_0024tKrBmG2JgA_003D_003D()._0023_003DzPpVzJh2WmrmhWqXh9NNYr_0024sLr3Oq(_0023_003DzyhuoqeH8sA2fipOFVu_0024vNrvZ5baZl1cB7KAOHYNB1gCDLfwzSg_003D_003D._0023_003Dzc3Qn0OgNn7PNyXPUMe9oTNMJcU481onqr2l7palyXDkZrhZNbQ_003D_003D(), "4oPB[q\"adB", array);
		shortcutKeys = new SimulationShortcutKeysSettings();
	}

	private bool ShouldSerializeShortcutKeys()
	{
		return ShortcutKeys._0023_003Dz4XAvJ5aCRLKs();
	}

	internal new void ResetShortcutKeys()
	{
		ShortcutKeys = new SimulationShortcutKeysSettings();
	}

	internal override ToolBar _0023_003DzTN1DFSSGkW6c(Viewport _0023_003Dz7Xo5EoA_003D)
	{
		return _0023_003Dz7Xo5EoA_003D.ToolBars.FirstOrDefault(_0023_003DzP0sFNwY_003D._0023_003Dz84eeg84_003D._0023_003Dz1PWbaAQQ7XTLTiXQWuo1c0E_003D);
	}

	internal override ToolBar _0023_003Dz7CYefrTDPabx()
	{
		ToolBarButton toolBarButton = new StartToolBarButton
		{
			Enabled = false
		};
		ToolBarButton toolBarButton2 = new PauseToolBarButton
		{
			Enabled = false,
			Visible = false
		};
		ToolBarButton[] buttons = new ToolBarButton[2] { toolBarButton, toolBarButton2 };
		return new ToolBar(ToolBar.positionType.HorizontalBottomCenter, visible: true, buttons);
	}

	public bool CanSimulate()
	{
		if (_0023_003DzH9aDWVd0mBS7 != null)
		{
			return _0023_003DzH9aDWVd0mBS7.Solved;
		}
		return false;
	}

	protected override void OnAnimationTimerTick(object stateInfo)
	{
		base.AnimationFrameNumber += base.AnimationStep;
		if (base.InvokeRequired)
		{
			BeginInvoke(new Action(_0023_003DzsJ0zkMjUnSLb), null);
		}
		else
		{
			SimulationResult.ComputePlot(this, base.ActiveViewport.Legend, ModeIndex);
		}
	}

	private void _0023_003DzsJ0zkMjUnSLb()
	{
		SimulationResult.FrameNumber = base.AnimationFrameNumber % _0023_003Dzn_svp9S4IgHhWIPQVpz_HKw_003D;
		Invalidate();
	}

	private void _0023_003DzoxYJkAM5bdYq()
	{
		if (_0023_003DzxyPXdKmFERan != null)
		{
			_0023_003DzxyPXdKmFERan(this, new EventArgs());
		}
	}

	private void _0023_003DzeO8LRLrcr7EG()
	{
		if (_0023_003Dz_0024ZG9gsVTSVkC != null)
		{
			_0023_003Dz_0024ZG9gsVTSVkC(this, new EventArgs());
		}
	}

	protected override Viewport GetDefaultViewport()
	{
		Viewport viewport = new Viewport();
		viewport.Grid.Visible = false;
		ToolBar defaultToolBar = ToolBar.GetDefaultToolBar();
		ToolBar toolBar = _0023_003Dz7CYefrTDPabx();
		viewport.ToolBars = new ToolBar[2] { defaultToolBar, toolBar };
		return viewport;
	}

	protected override void OnHandleDestroyed(EventArgs e)
	{
		if (SimulationResult != null)
		{
			SimulationResult.Dispose();
		}
		base.OnHandleDestroyed(e);
	}

	internal override void _0023_003DzuDFPqEJA5SPt1pVAXA_003D_003D(object _0023_003DzxwGby4M_003D, HandledEventArgs _0023_003Dz1SmHC4c_003D)
	{
		if (!_0023_003Dz1SmHC4c_003D.Handled)
		{
			_0023_003DzBAdm_0024f8hI85RZD1R3A_003D_003D = true;
			ToolBarButton toolBarButton = (ToolBarButton)_0023_003DzxwGby4M_003D;
			if (toolBarButton is StartToolBarButton)
			{
				if (toolBarButton._0023_003Dz0hLnOJ4_003D() == (ToolBarButton._0023_003DzJrgugJM_003D)2)
				{
					_0023_003Dz7QMtV8_0024k11am(_0023_003DzxwGby4M_003D, _0023_003Dz1SmHC4c_003D);
				}
			}
			else if (toolBarButton is PauseToolBarButton && toolBarButton._0023_003Dz0hLnOJ4_003D() == (ToolBarButton._0023_003DzJrgugJM_003D)2)
			{
				_0023_003Dz_rOvHYZwsb_a(_0023_003DzxwGby4M_003D, _0023_003Dz1SmHC4c_003D);
			}
			_0023_003DzBAdm_0024f8hI85RZD1R3A_003D_003D = false;
		}
		base._0023_003DzuDFPqEJA5SPt1pVAXA_003D_003D(_0023_003DzxwGby4M_003D, _0023_003Dz1SmHC4c_003D);
	}

	public void Start(int? interval = null)
	{
		SimulationResult.PrepareAnimation(_0023_003Dzn_svp9S4IgHhWIPQVpz_HKw_003D, this, base.ActiveViewport.Legend);
		_0023_003DzqyIi0qJHHOrU(base.ActiveViewport, _0023_003DzsLHxXyo_003D: false);
		_0023_003DzIMzi9JAvb4iGNpwi0A_003D_003D = base.Rendered.SilhouettesDrawingMode;
		_0023_003DzKQKZozMiwcr5 = base.Rendered.ShadowMode;
		_0023_003DzYMb1PVVvnw1EEg2g4A_003D_003D = base.Shaded.ShadowMode;
		_0023_003DzW_BoWEDvWvC1HPPcmnl_rzI_003D = base.Rendered.PlanarReflections;
		base.Rendered.SilhouettesDrawingMode = silhouettesDrawingType.Never;
		base.Rendered.ShadowMode = shadowType.None;
		base.Rendered.PlanarReflections = false;
		_0023_003DzHZMqgEfrVWAi(base.ActiveViewport, _0023_003DzWtFDQr8_003D: false);
		_0023_003DzoxYJkAM5bdYq();
		femMeshAnimation = true;
		StartAnimation(interval);
	}

	private void _0023_003Dz7QMtV8_0024k11am(object _0023_003DzxwGby4M_003D, EventArgs _0023_003Dz1SmHC4c_003D)
	{
		Start();
	}

	private void _0023_003Dz_rOvHYZwsb_a(object _0023_003DzxwGby4M_003D, EventArgs _0023_003Dz1SmHC4c_003D)
	{
		Pause();
	}

	public void Pause()
	{
		_0023_003DzqyIi0qJHHOrU(base.ActiveViewport, _0023_003DzsLHxXyo_003D: true);
		_0023_003DzHZMqgEfrVWAi(base.ActiveViewport, _0023_003DzWtFDQr8_003D: true);
		base.Rendered.SilhouettesDrawingMode = _0023_003DzIMzi9JAvb4iGNpwi0A_003D_003D;
		base.Rendered.ShadowMode = _0023_003DzKQKZozMiwcr5;
		base.Shaded.ShadowMode = _0023_003DzYMb1PVVvnw1EEg2g4A_003D_003D;
		base.Rendered.PlanarReflections = _0023_003DzW_BoWEDvWvC1HPPcmnl_rzI_003D;
		_0023_003DzeO8LRLrcr7EG();
		StopAnimation();
		femMeshAnimation = false;
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		base.OnKeyDown(e);
		if (SimulationResult == null)
		{
			return;
		}
		if (base.IsAnimationRunning)
		{
			if (e.KeyData == ShortcutKeys.Pause && !e.Handled)
			{
				Pause();
				Invalidate();
			}
		}
		else if (e.KeyData == ShortcutKeys.Start && !e.Handled)
		{
			Start();
			Invalidate();
		}
	}

	private bool ShouldSerializeForceSymbolColor()
	{
		return _0023_003DzjiyAmyRg6X4t != Color.Magenta;
	}

	internal void ResetForceSymbolColor()
	{
		_0023_003DzjiyAmyRg6X4t = Color.Magenta;
	}

	private bool ShouldSerializePressureSymbolColor()
	{
		return _0023_003Dzk_0024o9chkteb27_0024X0MxA_003D_003D != Color.Cyan;
	}

	internal void ResetPressureSymbolColor()
	{
		_0023_003Dzk_0024o9chkteb27_0024X0MxA_003D_003D = Color.Cyan;
	}

	private bool ShouldSerializePunctualForceSymbolColor()
	{
		return _0023_003DzzE_hbUTq9TJFOgSqtwSEKWs_003D != Color.CornflowerBlue;
	}

	internal void ResetPunctualForceSymbolColor()
	{
		_0023_003DzzE_hbUTq9TJFOgSqtwSEKWs_003D = Color.CornflowerBlue;
	}

	private bool ShouldSerializeRestraintSymbolColor()
	{
		return _0023_003Dz_0024A7Xp4GPwMfwPdEAEEbGHsc_003D != Color.Green;
	}

	internal void ResetRestraintSymbolColor()
	{
		_0023_003Dz_0024A7Xp4GPwMfwPdEAEEbGHsc_003D = Color.Green;
	}

	internal override void _0023_003DzSJDeNOUaWXnt()
	{
		base._0023_003DzSJDeNOUaWXnt();
		_0023_003DzkR0wANj5mIXT = _0023_003DzmNZD0Zs_003D.CreateEntityGraphicsData(this);
		_0023_003Dzs23gQos9I9jjZodCxA_003D_003D = _0023_003DzmNZD0Zs_003D.CreateEntityGraphicsData(this);
		_0023_003DzsDonKHd5EskAallJ6g_003D_003D = _0023_003DzmNZD0Zs_003D.CreateEntityGraphicsData(this);
		_0023_003Dz6LaEDy1uum1vm8pH0g_003D_003D = _0023_003DzmNZD0Zs_003D.CreateEntityGraphicsData(this);
		_0023_003Dz1fr8w_0024AKywAvZ9mslQ_003D_003D = _0023_003DzmNZD0Zs_003D.CreateEntityGraphicsData(this);
		_0023_003DzavWp_0024UaRz2ZoBqKKL2phf5I_003D = _0023_003DzmNZD0Zs_003D.CreateEntityGraphicsData(this);
		_0023_003Dzge8fIOtHs9SBObms2kc7b7s_003D = _0023_003DzmNZD0Zs_003D.CreateEntityGraphicsData(this);
	}

	internal override void _0023_003DzPY_0024ulDyKjEOA()
	{
		_0023_003DzkR0wANj5mIXT?.Dispose();
		_0023_003DzsDonKHd5EskAallJ6g_003D_003D?.Dispose();
		_0023_003DzavWp_0024UaRz2ZoBqKKL2phf5I_003D?.Dispose();
		_0023_003Dzge8fIOtHs9SBObms2kc7b7s_003D?.Dispose();
		_0023_003Dzs23gQos9I9jjZodCxA_003D_003D?.Dispose();
		_0023_003Dz6LaEDy1uum1vm8pH0g_003D_003D?.Dispose();
		_0023_003Dz1fr8w_0024AKywAvZ9mslQ_003D_003D?.Dispose();
		base._0023_003DzPY_0024ulDyKjEOA();
	}

	private bool ShouldSerializeShowRestraint()
	{
		return !_0023_003Dzab2SM4cZO6FjAIPL0w_003D_003D;
	}

	private void ResetShowRestraint()
	{
		_0023_003Dzab2SM4cZO6FjAIPL0w_003D_003D = true;
		_0023_003Dz3tGL3rg_003D();
	}

	private bool ShouldSerializeShowLoad()
	{
		return !_0023_003DzVzodAXCs9sQi;
	}

	private void ResetShowLoad()
	{
		_0023_003DzVzodAXCs9sQi = true;
		_0023_003Dz3tGL3rg_003D();
	}

	private bool ShouldSerializeShowJoint()
	{
		return !_0023_003DzVzodAXCs9sQi;
	}

	private void ResetShowJoint()
	{
		_0023_003DzVzodAXCs9sQi = true;
		_0023_003Dz3tGL3rg_003D();
	}

	[Obsolete("Use Region.Triangulate() method instead.")]
	public static Point3D[] MakeLoopByLength(IList<ICurve> entityList, int startIndex, double length)
	{
		return Workspace._0023_003Dzmb7PhZUTPQPe(entityList, startIndex, length, (_0023_003DzrWM_00242Vk_003D)1, _0023_003DzobfaVZ4_003D: false);
	}

	private void _0023_003DzWpkuWzhHzbrLm_0024WEkeeI9tw_003D(RenderContextBase _0023_003DzoC62DbA_003D)
	{
		UtilityEx._0023_003Dz39qa4kLY69E2922TrA_003D_003D(0.01, 2.0, 5.0, 16, 1, out var _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, out var _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D, out var _0023_003Dz2pcdJKEqM3of);
		UtilityEx._0023_003Dz39qa4kLY69E2922TrA_003D_003D(0.75, 0.75, 4.0, 16, 1, out var _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D2, out var _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D2, out var _0023_003Dz2pcdJKEqM3of2);
		double num = 5.0;
		Point3D[] array = _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D2;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Z += num;
		}
		_0023_003Dz1DPZVY_0024t6KPX(_0023_003Dzzmih36dAiKNDCev9Mg_003D_003D2, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length);
		UtilityEx._0023_003Dz39qa4kLY69E2922TrA_003D_003D(2.0, 2.0, 1.0, 16, 1, out var _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D3, out var _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D3, out var _0023_003Dz2pcdJKEqM3of3);
		num += 4.0;
		array = _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D3;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Z += num;
		}
		_0023_003Dz1DPZVY_0024t6KPX(_0023_003Dzzmih36dAiKNDCev9Mg_003D_003D3, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length + _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D2.Length);
		Point3D[] array2 = new Point3D[_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length + _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D2.Length + _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D3.Length];
		IndexTriangle[] array3 = new IndexTriangle[_0023_003Dzzmih36dAiKNDCev9Mg_003D_003D.Length + _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D2.Length + _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D3.Length];
		Vector3D[] array4 = new Vector3D[_0023_003Dz2pcdJKEqM3of.Length + _0023_003Dz2pcdJKEqM3of2.Length + _0023_003Dz2pcdJKEqM3of3.Length];
		Array.Copy(_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, array2, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length);
		Array.Copy(_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D2, 0, array2, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D2.Length);
		Array.Copy(_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D3, 0, array2, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length + _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D2.Length, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D3.Length);
		Array.Copy(_0023_003Dzzmih36dAiKNDCev9Mg_003D_003D, array3, _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D.Length);
		Array.Copy(_0023_003Dzzmih36dAiKNDCev9Mg_003D_003D2, 0, array3, _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D.Length, _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D2.Length);
		Array.Copy(_0023_003Dzzmih36dAiKNDCev9Mg_003D_003D3, 0, array3, _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D.Length + _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D2.Length, _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D3.Length);
		Array.Copy(_0023_003Dz2pcdJKEqM3of, array4, _0023_003Dz2pcdJKEqM3of.Length);
		Array.Copy(_0023_003Dz2pcdJKEqM3of2, 0, array4, _0023_003Dz2pcdJKEqM3of.Length, _0023_003Dz2pcdJKEqM3of2.Length);
		Array.Copy(_0023_003Dz2pcdJKEqM3of3, 0, array4, _0023_003Dz2pcdJKEqM3of.Length + _0023_003Dz2pcdJKEqM3of2.Length, _0023_003Dz2pcdJKEqM3of3.Length);
		_0023_003DzoC62DbA_003D.DrawTriangles(array2, array4, array3, null);
	}

	protected virtual void DrawTranslationRestraint(RenderContextBase context)
	{
		UtilityEx._0023_003Dz39qa4kLY69E2922TrA_003D_003D(0.01, 2.0, 5.0, 16, 1, out var _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, out var _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D, out var _0023_003Dz2pcdJKEqM3of);
		UtilityEx._0023_003Dz39qa4kLY69E2922TrA_003D_003D(0.75, 0.75, 4.0, 16, 1, out var _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D2, out var _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D2, out var _0023_003Dz2pcdJKEqM3of2);
		double num = 5.0;
		Point3D[] array = _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D2;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Z += num;
		}
		_0023_003Dz1DPZVY_0024t6KPX(_0023_003Dzzmih36dAiKNDCev9Mg_003D_003D2, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length);
		Point3D[] array2 = new Point3D[_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length + _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D2.Length];
		IndexTriangle[] array3 = new IndexTriangle[_0023_003Dzzmih36dAiKNDCev9Mg_003D_003D.Length + _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D2.Length];
		Vector3D[] array4 = new Vector3D[_0023_003Dz2pcdJKEqM3of.Length + _0023_003Dz2pcdJKEqM3of2.Length];
		Array.Copy(_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, array2, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length);
		Array.Copy(_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D2, 0, array2, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D2.Length);
		Array.Copy(_0023_003Dzzmih36dAiKNDCev9Mg_003D_003D, array3, _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D.Length);
		Array.Copy(_0023_003Dzzmih36dAiKNDCev9Mg_003D_003D2, 0, array3, _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D.Length, _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D2.Length);
		Array.Copy(_0023_003Dz2pcdJKEqM3of, array4, _0023_003Dz2pcdJKEqM3of.Length);
		Array.Copy(_0023_003Dz2pcdJKEqM3of2, 0, array4, _0023_003Dz2pcdJKEqM3of.Length, _0023_003Dz2pcdJKEqM3of2.Length);
		context.DrawTriangles(array2, array4, array3, null);
	}

	protected virtual void DrawRotationRestraint(RenderContextBase context)
	{
		UtilityEx._0023_003Dz39qa4kLY69E2922TrA_003D_003D(0.01, 0.75, 5.0, 16, 1, out var _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, out var _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D, out var _0023_003Dz2pcdJKEqM3of);
		UtilityEx._0023_003Dz39qa4kLY69E2922TrA_003D_003D(0.75, 0.75, 4.0, 16, 1, out var _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D2, out var _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D2, out var _0023_003Dz2pcdJKEqM3of2);
		double num = 5.0;
		Point3D[] array = _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D2;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Z += num;
		}
		_0023_003Dz1DPZVY_0024t6KPX(_0023_003Dzzmih36dAiKNDCev9Mg_003D_003D2, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length);
		UtilityEx._0023_003Dz39qa4kLY69E2922TrA_003D_003D(2.0, 2.0, 1.0, 16, 1, out var _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D3, out var _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D3, out var _0023_003Dz2pcdJKEqM3of3);
		num += 4.0;
		array = _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D3;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Z += num;
		}
		_0023_003Dz1DPZVY_0024t6KPX(_0023_003Dzzmih36dAiKNDCev9Mg_003D_003D3, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length + _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D2.Length);
		Point3D[] array2 = new Point3D[_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length + _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D2.Length + _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D3.Length];
		IndexTriangle[] array3 = new IndexTriangle[_0023_003Dzzmih36dAiKNDCev9Mg_003D_003D.Length + _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D2.Length + _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D3.Length];
		Vector3D[] array4 = new Vector3D[_0023_003Dz2pcdJKEqM3of.Length + _0023_003Dz2pcdJKEqM3of2.Length + _0023_003Dz2pcdJKEqM3of3.Length];
		Array.Copy(_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, array2, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length);
		Array.Copy(_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D2, 0, array2, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D2.Length);
		Array.Copy(_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D3, 0, array2, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length + _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D2.Length, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D3.Length);
		Array.Copy(_0023_003Dzzmih36dAiKNDCev9Mg_003D_003D, array3, _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D.Length);
		Array.Copy(_0023_003Dzzmih36dAiKNDCev9Mg_003D_003D2, 0, array3, _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D.Length, _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D2.Length);
		Array.Copy(_0023_003Dzzmih36dAiKNDCev9Mg_003D_003D3, 0, array3, _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D.Length + _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D2.Length, _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D3.Length);
		Array.Copy(_0023_003Dz2pcdJKEqM3of, array4, _0023_003Dz2pcdJKEqM3of.Length);
		Array.Copy(_0023_003Dz2pcdJKEqM3of2, 0, array4, _0023_003Dz2pcdJKEqM3of.Length, _0023_003Dz2pcdJKEqM3of2.Length);
		Array.Copy(_0023_003Dz2pcdJKEqM3of3, 0, array4, _0023_003Dz2pcdJKEqM3of.Length + _0023_003Dz2pcdJKEqM3of2.Length, _0023_003Dz2pcdJKEqM3of3.Length);
		context.DrawTriangles(array2, array4, array3, null);
	}

	private static void _0023_003Dz1DPZVY_0024t6KPX(IndexTriangle[] _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D, int _0023_003Dzsdr_I1A_003D)
	{
		foreach (IndexTriangle indexTriangle in _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D)
		{
			indexTriangle.V1 += _0023_003Dzsdr_I1A_003D;
			indexTriangle.V2 += _0023_003Dzsdr_I1A_003D;
			indexTriangle.V3 += _0023_003Dzsdr_I1A_003D;
		}
	}

	protected virtual void DrawForce(RenderContextBase context)
	{
		UtilityEx._0023_003Dz39qa4kLY69E2922TrA_003D_003D(0.01, 2.0, 5.0, 16, 1, out var _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, out var _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D, out var _0023_003Dz2pcdJKEqM3of);
		UtilityEx._0023_003Dz39qa4kLY69E2922TrA_003D_003D(0.75, 0.75, 10.0, 16, 1, out var _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D2, out var _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D2, out var _0023_003Dz2pcdJKEqM3of2);
		double num = 5.0;
		Point3D[] array = _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D2;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Z += num;
		}
		_0023_003Dz1DPZVY_0024t6KPX(_0023_003Dzzmih36dAiKNDCev9Mg_003D_003D2, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length);
		Point3D[] array2 = new Point3D[_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length + _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D2.Length];
		IndexTriangle[] array3 = new IndexTriangle[_0023_003Dzzmih36dAiKNDCev9Mg_003D_003D.Length + _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D2.Length];
		Vector3D[] array4 = new Vector3D[_0023_003Dz2pcdJKEqM3of.Length + _0023_003Dz2pcdJKEqM3of2.Length];
		Array.Copy(_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, array2, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length);
		Array.Copy(_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D2, 0, array2, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D2.Length);
		Array.Copy(_0023_003Dzzmih36dAiKNDCev9Mg_003D_003D, array3, _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D.Length);
		Array.Copy(_0023_003Dzzmih36dAiKNDCev9Mg_003D_003D2, 0, array3, _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D.Length, _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D2.Length);
		Array.Copy(_0023_003Dz2pcdJKEqM3of, array4, _0023_003Dz2pcdJKEqM3of.Length);
		Array.Copy(_0023_003Dz2pcdJKEqM3of2, 0, array4, _0023_003Dz2pcdJKEqM3of.Length, _0023_003Dz2pcdJKEqM3of2.Length);
		context.DrawTriangles(array2, array4, array3, null);
	}

	protected virtual void DrawMoment(RenderContextBase context)
	{
		UtilityEx._0023_003Dz39qa4kLY69E2922TrA_003D_003D(0.01, 0.75, 5.0, 16, 1, out var _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, out var _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D, out var _0023_003Dz2pcdJKEqM3of);
		UtilityEx._0023_003Dz39qa4kLY69E2922TrA_003D_003D(0.75, 0.75, 10.0, 16, 1, out var _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D2, out var _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D2, out var _0023_003Dz2pcdJKEqM3of2);
		double num = 5.0;
		Point3D[] array = _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D2;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Z += num;
		}
		_0023_003Dz1DPZVY_0024t6KPX(_0023_003Dzzmih36dAiKNDCev9Mg_003D_003D2, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length);
		UtilityEx._0023_003Dz39qa4kLY69E2922TrA_003D_003D(2.0, 2.0, 1.0, 16, 1, out var _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D3, out var _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D3, out var _0023_003Dz2pcdJKEqM3of3);
		num += 10.0;
		array = _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D3;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Z += num;
		}
		_0023_003Dz1DPZVY_0024t6KPX(_0023_003Dzzmih36dAiKNDCev9Mg_003D_003D3, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length + _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D2.Length);
		Point3D[] array2 = new Point3D[_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length + _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D2.Length + _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D3.Length];
		IndexTriangle[] array3 = new IndexTriangle[_0023_003Dzzmih36dAiKNDCev9Mg_003D_003D.Length + _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D2.Length + _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D3.Length];
		Vector3D[] array4 = new Vector3D[_0023_003Dz2pcdJKEqM3of.Length + _0023_003Dz2pcdJKEqM3of2.Length + _0023_003Dz2pcdJKEqM3of3.Length];
		Array.Copy(_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, array2, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length);
		Array.Copy(_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D2, 0, array2, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D2.Length);
		Array.Copy(_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D3, 0, array2, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length + _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D2.Length, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D3.Length);
		Array.Copy(_0023_003Dzzmih36dAiKNDCev9Mg_003D_003D, array3, _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D.Length);
		Array.Copy(_0023_003Dzzmih36dAiKNDCev9Mg_003D_003D2, 0, array3, _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D.Length, _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D2.Length);
		Array.Copy(_0023_003Dzzmih36dAiKNDCev9Mg_003D_003D3, 0, array3, _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D.Length + _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D2.Length, _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D3.Length);
		Array.Copy(_0023_003Dz2pcdJKEqM3of, array4, _0023_003Dz2pcdJKEqM3of.Length);
		Array.Copy(_0023_003Dz2pcdJKEqM3of2, 0, array4, _0023_003Dz2pcdJKEqM3of.Length, _0023_003Dz2pcdJKEqM3of2.Length);
		Array.Copy(_0023_003Dz2pcdJKEqM3of3, 0, array4, _0023_003Dz2pcdJKEqM3of.Length + _0023_003Dz2pcdJKEqM3of2.Length, _0023_003Dz2pcdJKEqM3of3.Length);
		context.DrawTriangles(array2, array4, array3, null);
	}

	private void _0023_003DzJmwbeajmWIbTqBGbLQ_003D_003D(RenderContextBase _0023_003DzoC62DbA_003D)
	{
		UtilityEx._0023_003Dzr_u_0024IHWHVAAGbXbZAg_003D_003D(1.75, 16, 16, _0023_003DzkPBo_0024TDVHEJXyVd0yQ_003D_003D: true, out var _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, out var _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D, out var _0023_003Dz2pcdJKEqM3of, out var _);
		_0023_003DzoC62DbA_003D.DrawTriangles(_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, _0023_003Dz2pcdJKEqM3of, _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D, null);
		_0023_003DzUR6yt2Nox6IG0tpr3w_003D_003D(_0023_003DzoC62DbA_003D, null);
		_0023_003DzUR6yt2Nox6IG0tpr3w_003D_003D(_0023_003DzoC62DbA_003D, new Rotation(-Math.PI / 2.0, Vector3D.AxisX));
	}

	private void _0023_003DzHQkahxA7XJilojaQqQ_003D_003D(RenderContextBase _0023_003DzoC62DbA_003D)
	{
		_0023_003DzJmwbeajmWIbTqBGbLQ_003D_003D(_0023_003DzoC62DbA_003D);
		_0023_003DzUR6yt2Nox6IG0tpr3w_003D_003D(_0023_003DzoC62DbA_003D, new Rotation(-Math.PI / 2.0, Vector3D.AxisY));
	}

	private void _0023_003DzUR6yt2Nox6IG0tpr3w_003D_003D(RenderContextBase _0023_003DzoC62DbA_003D, Transformation _0023_003DzjTAO7fqYkNXL)
	{
		UtilityEx._0023_003Dz39qa4kLY69E2922TrA_003D_003D(1.0, 1.0, 8.0, 16, 1, out var _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, out var _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D, out var _0023_003Dz2pcdJKEqM3of);
		if (_0023_003DzjTAO7fqYkNXL != null)
		{
			for (int i = 0; i < _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length; i++)
			{
				_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[i] = _0023_003DzjTAO7fqYkNXL * _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[i];
			}
		}
		_0023_003DzoC62DbA_003D.DrawTriangles(_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, _0023_003Dz2pcdJKEqM3of, _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D, null);
		UtilityEx._0023_003Dz39qa4kLY69E2922TrA_003D_003D(1.0, 0.01, 2.0, 16, 1, out _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, out _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D, out _0023_003Dz2pcdJKEqM3of);
		Point3D[] array = _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D;
		for (int j = 0; j < array.Length; j++)
		{
			array[j].Z += 8.0;
		}
		if (_0023_003DzjTAO7fqYkNXL != null)
		{
			for (int k = 0; k < _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length; k++)
			{
				_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[k] = _0023_003DzjTAO7fqYkNXL * _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[k];
			}
		}
		_0023_003DzoC62DbA_003D.DrawTriangles(_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, _0023_003Dz2pcdJKEqM3of, _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D, null);
	}

	internal override void _0023_003Dzemj_0024cuX1Dkz_KyAnyw_003D_003D(DrawSceneParams _0023_003Dzt5jpbHs_003D)
	{
		base._0023_003Dzemj_0024cuX1Dkz_KyAnyw_003D_003D(_0023_003Dzt5jpbHs_003D);
		_0023_003DzmNZD0Zs_003D.SetLighting(enable: true);
		_0023_003DzmNZD0Zs_003D.SetShader(shaderType.Standard, _0023_003Dzt5jpbHs_003D.ShaderParams);
		if (_0023_003DzmNZD0Zs_003D.CurrentShaderTechnique != null)
		{
			_0023_003DzmNZD0Zs_003D.UpdateConstantBufferPerFrame(_0023_003Dzt5jpbHs_003D.ShaderParams);
		}
		_0023_003DzmNZD0Zs_003D.SetState(rasterizerStateType.CCW_PolygonFill_CullFaceBack_PolygonOffset_1_1);
		_0023_003DzmNZD0Zs_003D.SetMaterial(Color.Black, Color.Black, Color.FromArgb(25, 25, 25), Color.Black, 0f);
		Entity[] array = _0023_003Dzt5jpbHs_003D.Entities.Where(_0023_003DzP0sFNwY_003D._0023_003Dz84eeg84_003D._0023_003DzDOfymvufiPEvjBEmrTM_sbKg4IHu).Select(_0023_003DzP0sFNwY_003D._0023_003Dz84eeg84_003D._0023_003DzAOwJ53Rl5tBaAYTsSAYtcgSmEd22).ToArray();
		if (_0023_003Dzab2SM4cZO6FjAIPL0w_003D_003D)
		{
			_0023_003DzmNZD0Zs_003D.SetMaterial(_0023_003Dz_0024A7Xp4GPwMfwPdEAEEbGHsc_003D, _0023_003Dz_0024A7Xp4GPwMfwPdEAEEbGHsc_003D, Color.Black, Color.White, 1f);
			for (int i = 0; i < array.Length; i++)
			{
				FemMesh femMesh = array[i] as FemMesh;
				if (!femMesh.Selected && base.Layers[femMesh.LayerName].Visible && femMesh.Visible)
				{
					femMesh.DrawRestraints(_0023_003DzmNZD0Zs_003D, _0023_003DzsDonKHd5EskAallJ6g_003D_003D, _0023_003DzavWp_0024UaRz2ZoBqKKL2phf5I_003D, _0023_003Dzge8fIOtHs9SBObms2kc7b7s_003D);
				}
			}
		}
		if (_0023_003DzVzodAXCs9sQi)
		{
			_0023_003DzmNZD0Zs_003D.SetMaterial(_0023_003DzjiyAmyRg6X4t, _0023_003DzjiyAmyRg6X4t, Color.Black, Color.White, 1f);
			for (int j = 0; j < array.Length; j++)
			{
				FemMesh femMesh2 = array[j] as FemMesh;
				if (!femMesh2.Selected && base.Layers[femMesh2.LayerName].Visible && femMesh2.Visible)
				{
					femMesh2.DrawLoads(_0023_003DzmNZD0Zs_003D, _0023_003DzkR0wANj5mIXT, _0023_003Dzs23gQos9I9jjZodCxA_003D_003D);
				}
			}
			_0023_003DzmNZD0Zs_003D.SetMaterial(_0023_003Dzk_0024o9chkteb27_0024X0MxA_003D_003D, _0023_003Dzk_0024o9chkteb27_0024X0MxA_003D_003D, Color.Black, Color.White, 1f);
			for (int k = 0; k < array.Length; k++)
			{
				FemMesh femMesh3 = array[k] as FemMesh;
				if (!femMesh3.Selected && base.Layers[femMesh3.LayerName].Visible && femMesh3.Visible)
				{
					femMesh3.DrawLoadsPress(_0023_003DzmNZD0Zs_003D, _0023_003DzkR0wANj5mIXT);
				}
			}
			_0023_003DzmNZD0Zs_003D.SetMaterial(_0023_003DzzE_hbUTq9TJFOgSqtwSEKWs_003D, _0023_003DzzE_hbUTq9TJFOgSqtwSEKWs_003D, Color.Black, Color.White, 1f);
			for (int l = 0; l < array.Length; l++)
			{
				FemMesh femMesh4 = array[l] as FemMesh;
				if (!femMesh4.Selected && base.Layers[femMesh4.LayerName].Visible && femMesh4.Visible && (femMesh4.IsBeamStudy || femMesh4.IsBeam2DStudy))
				{
					femMesh4.DrawPunctualForce(_0023_003DzmNZD0Zs_003D, _0023_003DzkR0wANj5mIXT);
				}
			}
		}
		if (!_0023_003DzFUUe8_owUAdg)
		{
			return;
		}
		_0023_003DzmNZD0Zs_003D.SetMaterial(Color.DeepSkyBlue, Color.DeepSkyBlue, Color.Black, Color.White, 1f);
		for (int m = 0; m < array.Length; m++)
		{
			FemMesh femMesh5 = array[m] as FemMesh;
			if (!femMesh5.Selected && base.Layers[femMesh5.LayerName].Visible && femMesh5.Visible)
			{
				femMesh5.DrawJoints(_0023_003DzmNZD0Zs_003D, _0023_003Dz6LaEDy1uum1vm8pH0g_003D_003D, _0023_003Dz1fr8w_0024AKywAvZ9mslQ_003D_003D);
			}
		}
	}

	internal override void _0023_003DzNFTjT933JCr9(RenderContextBase _0023_003DzmNZD0Zs_003D)
	{
		_0023_003Dz3bkkM1hGGWJMd6fIyRfwB9w_003D CS_0024_003C_003E8__locals18 = new _0023_003Dz3bkkM1hGGWJMd6fIyRfwB9w_003D();
		CS_0024_003C_003E8__locals18._0023_003DzKdgtcDsi34jL = this;
		CS_0024_003C_003E8__locals18._0023_003DzmNZD0Zs_003D = _0023_003DzmNZD0Zs_003D;
		base._0023_003DzNFTjT933JCr9(CS_0024_003C_003E8__locals18._0023_003DzmNZD0Zs_003D);
		CS_0024_003C_003E8__locals18._0023_003DzmNZD0Zs_003D.Compile(_0023_003DzsDonKHd5EskAallJ6g_003D_003D, CS_0024_003C_003E8__locals18._0023_003DzfLPmqfrZGlp6O5ha7sXIkOo_003D, null);
		CS_0024_003C_003E8__locals18._0023_003DzmNZD0Zs_003D.Compile(_0023_003DzavWp_0024UaRz2ZoBqKKL2phf5I_003D, CS_0024_003C_003E8__locals18._0023_003Dz9JXCJgK39EQa27e4YcywGGE_003D, null);
		CS_0024_003C_003E8__locals18._0023_003DzmNZD0Zs_003D.Compile(_0023_003Dzge8fIOtHs9SBObms2kc7b7s_003D, CS_0024_003C_003E8__locals18._0023_003DzVg5C8L7aWhdKR7Mc3Z4lzGM_003D, null);
		CS_0024_003C_003E8__locals18._0023_003DzmNZD0Zs_003D.Compile(_0023_003DzkR0wANj5mIXT, CS_0024_003C_003E8__locals18._0023_003Dzm_TNlWolD2xV1wq5kutLmYE_003D, null);
		CS_0024_003C_003E8__locals18._0023_003DzmNZD0Zs_003D.Compile(_0023_003Dzs23gQos9I9jjZodCxA_003D_003D, CS_0024_003C_003E8__locals18._0023_003DzknTN1LOpIkJmBg7GVgrtBac_003D, null);
		CS_0024_003C_003E8__locals18._0023_003DzmNZD0Zs_003D.Compile(_0023_003Dz6LaEDy1uum1vm8pH0g_003D_003D, CS_0024_003C_003E8__locals18._0023_003DzqllAkjyP0TbMooRt4a7zMNc_003D, null);
		CS_0024_003C_003E8__locals18._0023_003DzmNZD0Zs_003D.Compile(_0023_003Dz1fr8w_0024AKywAvZ9mslQ_003D_003D, delegate
		{
			CS_0024_003C_003E8__locals18._0023_003DzKdgtcDsi34jL._0023_003DzHQkahxA7XJilojaQqQ_003D_003D(CS_0024_003C_003E8__locals18._0023_003DzmNZD0Zs_003D);
		}, null);
	}

	public Mesher[] GetMeshers(double size = 0.0, bool quadratic = false)
	{
		return base.Document.GetMeshers(size, quadratic);
	}

	public Mesher[] GetMeshers(Brep brep, double size, bool quadratic, double maxGradation, double shapeQualityWeight, bool computeEdgeQuality)
	{
		return base.Document.GetMeshers(brep, size, quadratic, maxGradation, shapeQualityWeight, computeEdgeQuality);
	}

	public Mesher[] GetMeshers(Brep brep, double[] sizeOnVertices, bool quadratic, double maxGradation, double shapeQualityWeight, bool computeEdgeQuality)
	{
		return base.Document.GetMeshers(brep, sizeOnVertices, quadratic, maxGradation, shapeQualityWeight, computeEdgeQuality);
	}

	public Mesher[] GetMeshers(Block current, BlockKeyedCollection blocks, MaterialKeyedCollection materials, double size, bool quadratic)
	{
		return base.Document.GetMeshers(current, blocks, materials, size, quadratic);
	}
}
