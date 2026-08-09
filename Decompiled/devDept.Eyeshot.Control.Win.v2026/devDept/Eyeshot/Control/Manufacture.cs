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
using devDept.Eyeshot.Milling;
using devDept.Geometry;
using devDept.Graphics;

namespace devDept.Eyeshot.Control;

[ToolboxItem(true)]
[ToolboxBitmap(typeof(Manufacture))]
[Description("Provides the ability to generate 3 axis toolpaths.")]
[Designer("devDept.Eyeshot.Designer.DesignControlDesigner, devDept.Eyeshot.Control.Win.v2026.Design")]
public class Manufacture : Design
{
	[Serializable]
	private sealed class _0023_003DzP0sFNwY_003D
	{
		public static readonly _0023_003DzP0sFNwY_003D _0023_003Dz84eeg84_003D = new _0023_003DzP0sFNwY_003D();

		public static Func<ToolBar, bool> _0023_003Dz3OtnxrAZTXpYyEK4FA_003D_003D;

		public static Func<Entity, bool> _0023_003DzXQX2wcboxWk0_idd0w_003D_003D;

		public static Predicate<Entity> _0023_003Dzt7ijbh4bpZwN9Fxtuw_003D_003D;

		internal bool _0023_003DzWePs5OxddRdjkurZ0MieTds_003D(ToolBar _0023_003DzH69yFvkdPCYv)
		{
			return _0023_003DzH69yFvkdPCYv._0023_003Dz6IiAnIkiGeJ4c1d3fnMBUNw_003D();
		}

		internal bool _0023_003DzmdHNTIEnYMN8dXI4Y1qn0bk_003D(Entity _0023_003DztJCl_0024mM_003D)
		{
			return ((NestedEntity)_0023_003DztJCl_0024mM_003D).entity is MachiningPlane;
		}

		internal bool _0023_003DzJuAh_aBGah4nOrk5sarv7IA_003D(Entity _0023_003DztJCl_0024mM_003D)
		{
			return ((NestedEntity)_0023_003DztJCl_0024mM_003D).entity is MachiningPlane;
		}
	}

	public class PositionChangedEventArgs : EventArgs
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly PointCL _0023_003DzBZhG9k3zb4FixT5YIRN8vW_0024HoW5i;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly int _0023_003DzM73aM3G1F1_Acd9lxg_003D_003D;

		public PointCL CutterLocation
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzBZhG9k3zb4FixT5YIRN8vW_0024HoW5i;
			}
		}

		public int Direction
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzM73aM3G1F1_Acd9lxg_003D_003D;
			}
		}

		public PositionChangedEventArgs(PointCL cl, int direction)
		{
			_0023_003DzBZhG9k3zb4FixT5YIRN8vW_0024HoW5i = cl;
			_0023_003DzM73aM3G1F1_Acd9lxg_003D_003D = direction;
		}
	}

	public delegate void PositionChangedEventHandler(object sender, PositionChangedEventArgs e);

	public delegate void SimulationEndedEventHandler(object sender, EventArgs e);

	public delegate void SimulationPausedEventHandler(object sender, EventArgs e);

	public delegate void SimulationStartedEventHandler(object sender, EventArgs e);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal ToolTip _0023_003DzCtnwKNnQGFFBun6dqoRblrs_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Mesh _0023_003DzD0oP7TBd5Fj9;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzrQyjXtExhfZQ0QwQVBHDCtA_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private PositionChangedEventHandler _0023_003DzmxUYWPI_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private SimulationEndedEventHandler _0023_003DzpodBPKgrsyR_0024;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private SimulationStartedEventHandler _0023_003DzxyPXdKmFERan;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private SimulationPausedEventHandler _0023_003Dz_0024ZG9gsVTSVkC;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Point3D _0023_003DznnG9k_o_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DziZ8BZpigbMTt = 1.0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int? _0023_003DzmqbiRTIqhL7EvFfwZQ_003D_003D = 1;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal _0023_003Dzxpt0XNAjj_SVL0Q1U47dqJl3lOw2gkDKuxE2GD9zeiaV5qT_0024dw_003D_003D _0023_003DzKRihwpJbu9W_0024pR7AinD0Xrs_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private silhouettesDrawingType _0023_003DzIMzi9JAvb4iGNpwi0A_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private shadowType _0023_003DzKQKZozMiwcr5;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private shadowType _0023_003DzYMb1PVVvnw1EEg2g4A_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzW_BoWEDvWvC1HPPcmnl_rzI_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private BlockReference _0023_003Dz20mE5GcuA_0024Nv;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Toolpath _0023_003Dz66_G081XVxFkU61S4PaN_io_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private EndMill _0023_003DzeNQjlVo8TnwL;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private SimulationStock _0023_003DzznDghL_IGqSJ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003DzdRU4TSI5nCSw;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003DzGrg75r5OtcLP;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Point3D _0023_003DzxppThJsMAJvL;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003DzFrVxU64BV0ac;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Setup _0023_003DzapYoGglCRW8kB_SXSgtLW9I_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal string _0023_003DzMK_SXXTeS2YU;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzLRxhPW_0024VOH3jws004IPOO1_f1att = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348586904);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Entity _0023_003Dz2UfdJ_SfotNctzPMTVnI8Lg_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Entity _0023_003DzN82DCxtj79dGyGF3QxA30x0_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Entity _0023_003DzBqnmOMQbymUZBIXA0A_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Entity _0023_003DzJy9FHddJnnQ00_FXBQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IList<Entity> _0023_003Dzm8V3ST5A34Ye;

	[Category("Workspace")]
	[Description("Keyboard shortcuts.")]
	public new ManufactureShortcutKeysSettings ShortcutKeys
	{
		get
		{
			return (ManufactureShortcutKeysSettings)shortcutKeys;
		}
		set
		{
			shortcutKeys = value;
		}
	}

	public ToolBar ManufactureToolBar => _0023_003DzTN1DFSSGkW6c(base.ActiveViewport);

	[Category("Workspace - User Interface")]
	[Description("Simulation timeline settings.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public SimulationTimeLine SimulationTimeLine
	{
		get
		{
			return _0023_003Dz5rO_0024Fj2CJdsU();
		}
		set
		{
			_0023_003DzvuwkOvabY479(value);
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Toolpath SimulationToolpath
	{
		get
		{
			return _0023_003Dz66_G081XVxFkU61S4PaN_io_003D;
		}
		set
		{
			if (value != null)
			{
				if (base.Entities.IndexOf(value) != -1)
				{
					_0023_003Dz66_G081XVxFkU61S4PaN_io_003D = value;
				}
				else
				{
					if (_0023_003Dz66_G081XVxFkU61S4PaN_io_003D != null)
					{
						_0023_003Dz66_G081XVxFkU61S4PaN_io_003D.Dispose();
					}
					_0023_003Dz66_G081XVxFkU61S4PaN_io_003D = value;
					base.Entities.Add(_0023_003Dz66_G081XVxFkU61S4PaN_io_003D);
					base.Entities.Regen();
				}
			}
			_0023_003DzKRihwpJbu9W_0024pR7AinD0Xrs_003D = new _0023_003Dzxpt0XNAjj_SVL0Q1U47dqJl3lOw2gkDKuxE2GD9zeiaV5qT_0024dw_003D_003D(_0023_003Dz66_G081XVxFkU61S4PaN_io_003D.allVertices);
			_0023_003DznnG9k_o_003D = _0023_003DzKRihwpJbu9W_0024pR7AinD0Xrs_003D._0023_003DzUMSSRSw_003D(0);
			SimulationTimeLine._0023_003Dz1BiD_wY_003D(_0023_003Dz66_G081XVxFkU61S4PaN_io_003D);
			_0023_003DzHZMqgEfrVWAi(base.ActiveViewport, CanSimulate());
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public BlockReference ToolBlockRef => _0023_003Dz20mE5GcuA_0024Nv;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public EndMill SimulationTool
	{
		get
		{
			return _0023_003DzeNQjlVo8TnwL;
		}
		set
		{
			_0023_003DzeNQjlVo8TnwL = value;
			if (_0023_003Dz20mE5GcuA_0024Nv != null)
			{
				base.Entities.Remove(_0023_003Dz20mE5GcuA_0024Nv);
				_0023_003Dz20mE5GcuA_0024Nv = null;
			}
			_0023_003DzHZMqgEfrVWAi(base.ActiveViewport, CanSimulate());
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public SimulationStock SimulationStock
	{
		get
		{
			return _0023_003DzznDghL_IGqSJ;
		}
		set
		{
			if (_0023_003DzznDghL_IGqSJ != null)
			{
				_0023_003DzznDghL_IGqSJ.Dispose();
			}
			_0023_003DzznDghL_IGqSJ = value;
			if (_0023_003DzznDghL_IGqSJ != null)
			{
				base.Entities.Add(_0023_003DzznDghL_IGqSJ);
				base.Entities.Regen();
			}
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool StopOnCollision
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzrQyjXtExhfZQ0QwQVBHDCtA_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzrQyjXtExhfZQ0QwQVBHDCtA_003D = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public double SimulationSpeed
	{
		get
		{
			return _0023_003DzKRihwpJbu9W_0024pR7AinD0Xrs_003D._0023_003DznQGaNxg_003D;
		}
		set
		{
			if (value < 0.0)
			{
				throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348586913));
			}
			_0023_003DzmqbiRTIqhL7EvFfwZQ_003D_003D = null;
			_0023_003DziZ8BZpigbMTt = value;
			_0023_003Dzjj21PP8_003D();
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Setup SimulationSetup
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzapYoGglCRW8kB_SXSgtLW9I_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzapYoGglCRW8kB_SXSgtLW9I_003D = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string CuttingStockText
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzLRxhPW_0024VOH3jws004IPOO1_f1att;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzLRxhPW_0024VOH3jws004IPOO1_f1att = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Entity ClearancePlane
	{
		get
		{
			return _0023_003Dz2UfdJ_SfotNctzPMTVnI8Lg_003D;
		}
		set
		{
			if (_0023_003Dz2UfdJ_SfotNctzPMTVnI8Lg_003D != null)
			{
				_0023_003Dz2UfdJ_SfotNctzPMTVnI8Lg_003D.Dispose();
			}
			_0023_003Dz2UfdJ_SfotNctzPMTVnI8Lg_003D = value;
			base.Entities.Add(_0023_003Dz2UfdJ_SfotNctzPMTVnI8Lg_003D);
			base.Entities.Regen();
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Entity RetractPlane
	{
		get
		{
			return _0023_003DzN82DCxtj79dGyGF3QxA30x0_003D;
		}
		set
		{
			if (_0023_003DzN82DCxtj79dGyGF3QxA30x0_003D != null)
			{
				_0023_003DzN82DCxtj79dGyGF3QxA30x0_003D.Dispose();
			}
			_0023_003DzN82DCxtj79dGyGF3QxA30x0_003D = value;
			base.Entities.Add(_0023_003DzN82DCxtj79dGyGF3QxA30x0_003D);
			base.Entities.Regen();
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Entity TopPlane
	{
		get
		{
			return _0023_003DzBqnmOMQbymUZBIXA0A_003D_003D;
		}
		set
		{
			if (_0023_003DzBqnmOMQbymUZBIXA0A_003D_003D != null)
			{
				_0023_003DzBqnmOMQbymUZBIXA0A_003D_003D.Dispose();
			}
			_0023_003DzBqnmOMQbymUZBIXA0A_003D_003D = value;
			base.Entities.Add(_0023_003DzBqnmOMQbymUZBIXA0A_003D_003D);
			base.Entities.Regen();
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Entity BottomPlane
	{
		get
		{
			return _0023_003DzJy9FHddJnnQ00_FXBQ_003D_003D;
		}
		set
		{
			if (_0023_003DzJy9FHddJnnQ00_FXBQ_003D_003D != null)
			{
				_0023_003DzJy9FHddJnnQ00_FXBQ_003D_003D.Dispose();
			}
			_0023_003DzJy9FHddJnnQ00_FXBQ_003D_003D = value;
			base.Entities.Add(_0023_003DzJy9FHddJnnQ00_FXBQ_003D_003D);
			base.Entities.Regen();
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public IList<Entity> SimulationGeometry
	{
		get
		{
			return _0023_003Dzm8V3ST5A34Ye;
		}
		set
		{
			if (_0023_003Dzm8V3ST5A34Ye != null)
			{
				foreach (Entity item in _0023_003Dzm8V3ST5A34Ye)
				{
					item.Dispose();
				}
			}
			_0023_003Dzm8V3ST5A34Ye = value;
			if (_0023_003Dzm8V3ST5A34Ye != null)
			{
				base.Entities.AddRange(_0023_003Dzm8V3ST5A34Ye);
				base.Entities.Regen();
			}
		}
	}

	[Description("Occurs when the simulation tool position changes.")]
	public event PositionChangedEventHandler PositionChanged
	{
		[CompilerGenerated]
		add
		{
			PositionChangedEventHandler positionChangedEventHandler = _0023_003DzmxUYWPI_003D;
			PositionChangedEventHandler positionChangedEventHandler2;
			do
			{
				positionChangedEventHandler2 = positionChangedEventHandler;
				PositionChangedEventHandler value2 = (PositionChangedEventHandler)Delegate.Combine(positionChangedEventHandler2, value);
				positionChangedEventHandler = Interlocked.CompareExchange(ref _0023_003DzmxUYWPI_003D, value2, positionChangedEventHandler2);
			}
			while ((object)positionChangedEventHandler != positionChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			PositionChangedEventHandler positionChangedEventHandler = _0023_003DzmxUYWPI_003D;
			PositionChangedEventHandler positionChangedEventHandler2;
			do
			{
				positionChangedEventHandler2 = positionChangedEventHandler;
				PositionChangedEventHandler value2 = (PositionChangedEventHandler)Delegate.Remove(positionChangedEventHandler2, value);
				positionChangedEventHandler = Interlocked.CompareExchange(ref _0023_003DzmxUYWPI_003D, value2, positionChangedEventHandler2);
			}
			while ((object)positionChangedEventHandler != positionChangedEventHandler2);
		}
	}

	[Description("Occurs when the simulation is ended.")]
	public event SimulationEndedEventHandler SimulationEnded
	{
		[CompilerGenerated]
		add
		{
			SimulationEndedEventHandler simulationEndedEventHandler = _0023_003DzpodBPKgrsyR_0024;
			SimulationEndedEventHandler simulationEndedEventHandler2;
			do
			{
				simulationEndedEventHandler2 = simulationEndedEventHandler;
				SimulationEndedEventHandler value2 = (SimulationEndedEventHandler)Delegate.Combine(simulationEndedEventHandler2, value);
				simulationEndedEventHandler = Interlocked.CompareExchange(ref _0023_003DzpodBPKgrsyR_0024, value2, simulationEndedEventHandler2);
			}
			while ((object)simulationEndedEventHandler != simulationEndedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			SimulationEndedEventHandler simulationEndedEventHandler = _0023_003DzpodBPKgrsyR_0024;
			SimulationEndedEventHandler simulationEndedEventHandler2;
			do
			{
				simulationEndedEventHandler2 = simulationEndedEventHandler;
				SimulationEndedEventHandler value2 = (SimulationEndedEventHandler)Delegate.Remove(simulationEndedEventHandler2, value);
				simulationEndedEventHandler = Interlocked.CompareExchange(ref _0023_003DzpodBPKgrsyR_0024, value2, simulationEndedEventHandler2);
			}
			while ((object)simulationEndedEventHandler != simulationEndedEventHandler2);
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

	public Manufacture()
	{
		base.Units = linearUnitsType.Millimeters;
		base.WorkCompleted += delegate(object _0023_003DzxwGby4M_003D, WorkCompletedEventArgs _0023_003Dz1SmHC4c_003D)
		{
			_0023_003DzLkcEukpVm0uw(_0023_003Dz1SmHC4c_003D);
		};
		base.WorkCancelled += _0023_003Dzd_nP7InHm5gVR5JPzgyjTDOgu2td;
		if (SimulationTimeLine == null)
		{
			SimulationTimeLine = new SimulationTimeLine();
		}
		shortcutKeys = new ManufactureShortcutKeysSettings();
		_0023_003DzrKqKIaOjM2s_0024MgtH8IWTUvjdY1ng();
		_0023_003DzMK_SXXTeS2YU = Guid.NewGuid().ToString();
	}

	private bool ShouldSerializeShortcutKeys()
	{
		return ShortcutKeys._0023_003Dz4XAvJ5aCRLKs();
	}

	internal new void ResetShortcutKeys()
	{
		ShortcutKeys = new ManufactureShortcutKeysSettings();
	}

	internal override ToolBar _0023_003DzTN1DFSSGkW6c(Viewport _0023_003Dz7Xo5EoA_003D)
	{
		return _0023_003Dz7Xo5EoA_003D.ToolBars.FirstOrDefault(_0023_003DzP0sFNwY_003D._0023_003Dz84eeg84_003D._0023_003DzWePs5OxddRdjkurZ0MieTds_003D);
	}

	internal override ToolBar _0023_003Dz7CYefrTDPabx()
	{
		ToolBarButton toolBarButton = new BeginningToolBarButton
		{
			Enabled = false
		};
		ToolBarButton toolBarButton2 = new PreviousToolBarButton
		{
			Enabled = false
		};
		ToolBarButton toolBarButton3 = new StartToolBarButton
		{
			Enabled = false
		};
		ToolBarButton toolBarButton4 = new PauseToolBarButton
		{
			Enabled = false,
			Visible = false
		};
		ToolBarButton toolBarButton5 = new NextToolBarButton
		{
			Enabled = false
		};
		ToolBarButton toolBarButton6 = new EndToolBarButton
		{
			Enabled = false
		};
		ToolBarButton[] buttons = new ToolBarButton[6] { toolBarButton, toolBarButton2, toolBarButton3, toolBarButton4, toolBarButton5, toolBarButton6 };
		return new ToolBar(ToolBar.positionType.HorizontalBottomCenter, visible: true, buttons);
	}

	public bool CanSimulate()
	{
		if (_0023_003Dz66_G081XVxFkU61S4PaN_io_003D != null)
		{
			return _0023_003DzeNQjlVo8TnwL != null;
		}
		return false;
	}

	private void _0023_003DzrKqKIaOjM2s_0024MgtH8IWTUvjdY1ng()
	{
		_0023_003DzCtnwKNnQGFFBun6dqoRblrs_003D = new ToolTip();
		_0023_003DzCtnwKNnQGFFBun6dqoRblrs_003D.ShowAlways = true;
		_0023_003DzCtnwKNnQGFFBun6dqoRblrs_003D.Active = false;
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		SimulationTimeLine._0023_003DzMhJnK2KPd8YE(this, e);
		base.OnMouseMove(e);
	}

	private bool _0023_003Dz8bQaWdbbg_0024_W()
	{
		if (CanSimulate())
		{
			return SimulationTimeLine.enabled;
		}
		return false;
	}

	protected override void DrawOverlayBlended(DrawSceneParams myParams, bool isCurrentViewport)
	{
		if (_0023_003Dz8bQaWdbbg_0024_W())
		{
			SimulationTimeLine.Draw(myParams);
		}
		base.DrawOverlayBlended(myParams, isCurrentViewport);
	}

	private protected override void _0023_003DzNfLvQb1InVte(ref List<Entity> _0023_003DzY_0024ABPwh9wryC)
	{
		IList<Entity> collection = _0023_003DzY_0024ABPwh9wryC.Where(_0023_003DzP0sFNwY_003D._0023_003Dz84eeg84_003D._0023_003DzmdHNTIEnYMN8dXI4Y1qn0bk_003D).ToArray();
		_0023_003DzY_0024ABPwh9wryC.RemoveAll(_0023_003DzP0sFNwY_003D._0023_003Dz84eeg84_003D._0023_003DzJuAh_aBGah4nOrk5sarv7IA_003D);
		base._0023_003DzNfLvQb1InVte(ref _0023_003DzY_0024ABPwh9wryC);
		_0023_003DzY_0024ABPwh9wryC.AddRange(collection);
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		SimulationTimeLine._0023_003DzA_0024DikLW4dIhx(e);
		Invalidate();
		base.OnMouseLeave(e);
	}

	protected override void OnMouseClick(MouseEventArgs e)
	{
		SimulationTimeLine._0023_003DznLFqJ0dXjXHS(this, e);
		base.OnMouseClick(e);
	}

	private void _0023_003Dz3tEZqD3ybBMmRH7eDrX_0024knbCULeQ(object _0023_003DzxwGby4M_003D, WorkCompletedEventArgs _0023_003Dz1SmHC4c_003D)
	{
		_0023_003DzLkcEukpVm0uw(_0023_003Dz1SmHC4c_003D);
	}

	private void _0023_003Dzd_nP7InHm5gVR5JPzgyjTDOgu2td(object _0023_003DzxwGby4M_003D, EventArgs _0023_003Dz1SmHC4c_003D)
	{
		_0023_003DzLkcEukpVm0uw(null);
	}

	private void _0023_003DzLkcEukpVm0uw(WorkCompletedEventArgs _0023_003Dzx_0024xIZ5OblIJN)
	{
		if (_0023_003Dzx_0024xIZ5OblIJN != null && _0023_003Dzx_0024xIZ5OblIJN.WorkUnit is _0023_003DzUcEVokiS1LwqHRRaC0mGpnaI1oOZ68PVIQ_003D_003D)
		{
			if (_0023_003DzznDghL_IGqSJ != null)
			{
				_0023_003DzznDghL_IGqSJ.Optimize(new CompileParams(this));
			}
			_0023_003Dzl36fwfqeTvT9();
		}
		Invalidate();
	}

	internal void _0023_003DzLibvUa2axNVJ(PointCL _0023_003DzRo3lpTk5P2Y_0024UcPgtg_003D_003D, int _0023_003DzusPIN8Q_003D)
	{
		if (_0023_003DzmxUYWPI_003D != null)
		{
			_0023_003DzmxUYWPI_003D(this, new PositionChangedEventArgs(_0023_003DzRo3lpTk5P2Y_0024UcPgtg_003D_003D, _0023_003DzusPIN8Q_003D));
		}
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		base.OnKeyDown(e);
		if (_0023_003DzKRihwpJbu9W_0024pR7AinD0Xrs_003D == null || SimulationToolpath == null)
		{
			return;
		}
		if (base.IsAnimationRunning && !_0023_003DzGrg75r5OtcLP)
		{
			if (e.KeyData == ShortcutKeys.Pause && !e.Handled)
			{
				Pause();
				Invalidate();
			}
			return;
		}
		if (e.KeyData == ShortcutKeys.Start && !e.Handled)
		{
			Start();
			Invalidate();
		}
		if (e.KeyData == ShortcutKeys.Next && !e.Handled)
		{
			GoToNext();
			Invalidate();
		}
		if (e.KeyData == ShortcutKeys.Previous && !e.Handled)
		{
			GoToPrevious();
			Invalidate();
		}
	}

	private void _0023_003Dzl36fwfqeTvT9()
	{
		if (_0023_003DzpodBPKgrsyR_0024 != null)
		{
			_0023_003DzpodBPKgrsyR_0024(this, new EventArgs());
		}
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
		if (_0023_003DzznDghL_IGqSJ != null)
		{
			_0023_003DzznDghL_IGqSJ.Dispose();
		}
		if (_0023_003Dz20mE5GcuA_0024Nv != null)
		{
			_0023_003Dz20mE5GcuA_0024Nv.Dispose();
		}
		if (_0023_003DzJy9FHddJnnQ00_FXBQ_003D_003D != null)
		{
			_0023_003DzJy9FHddJnnQ00_FXBQ_003D_003D.Dispose();
		}
		if (_0023_003DzBqnmOMQbymUZBIXA0A_003D_003D != null)
		{
			_0023_003DzBqnmOMQbymUZBIXA0A_003D_003D.Dispose();
		}
		if (_0023_003DzN82DCxtj79dGyGF3QxA30x0_003D != null)
		{
			_0023_003DzN82DCxtj79dGyGF3QxA30x0_003D.Dispose();
		}
		if (_0023_003Dz2UfdJ_SfotNctzPMTVnI8Lg_003D != null)
		{
			_0023_003Dz2UfdJ_SfotNctzPMTVnI8Lg_003D.Dispose();
		}
		base.OnHandleDestroyed(e);
	}

	internal override void _0023_003DzuDFPqEJA5SPt1pVAXA_003D_003D(object _0023_003DzxwGby4M_003D, HandledEventArgs _0023_003Dz1SmHC4c_003D)
	{
		if (!_0023_003Dz1SmHC4c_003D.Handled)
		{
			_0023_003DzBAdm_0024f8hI85RZD1R3A_003D_003D = true;
			ToolBarButton toolBarButton = (ToolBarButton)_0023_003DzxwGby4M_003D;
			if (toolBarButton is BeginningToolBarButton)
			{
				if (toolBarButton._0023_003Dz0hLnOJ4_003D() == (ToolBarButton._0023_003DzJrgugJM_003D)2)
				{
					_0023_003Dzcp60CRpn2SZv(_0023_003DzxwGby4M_003D, _0023_003Dz1SmHC4c_003D);
				}
			}
			else if (toolBarButton is PreviousToolBarButton)
			{
				if (toolBarButton._0023_003Dz0hLnOJ4_003D() == (ToolBarButton._0023_003DzJrgugJM_003D)2)
				{
					_0023_003DzA63SKRsqNbI4(_0023_003DzxwGby4M_003D, _0023_003Dz1SmHC4c_003D);
				}
			}
			else if (toolBarButton is StartToolBarButton)
			{
				if (toolBarButton._0023_003Dz0hLnOJ4_003D() == (ToolBarButton._0023_003DzJrgugJM_003D)2)
				{
					_0023_003Dz7QMtV8_0024k11am(_0023_003DzxwGby4M_003D, _0023_003Dz1SmHC4c_003D);
				}
			}
			else if (toolBarButton is PauseToolBarButton)
			{
				if (toolBarButton._0023_003Dz0hLnOJ4_003D() == (ToolBarButton._0023_003DzJrgugJM_003D)2)
				{
					_0023_003Dz_rOvHYZwsb_a(_0023_003DzxwGby4M_003D, _0023_003Dz1SmHC4c_003D);
				}
			}
			else if (toolBarButton is NextToolBarButton)
			{
				if (toolBarButton._0023_003Dz0hLnOJ4_003D() == (ToolBarButton._0023_003DzJrgugJM_003D)2)
				{
					_0023_003DzjlQtxOK8F_0024Ai(_0023_003DzxwGby4M_003D, _0023_003Dz1SmHC4c_003D);
				}
			}
			else if (toolBarButton is EndToolBarButton && toolBarButton._0023_003Dz0hLnOJ4_003D() == (ToolBarButton._0023_003DzJrgugJM_003D)2)
			{
				_0023_003DzAieoim7wfgUE(_0023_003DzxwGby4M_003D, _0023_003Dz1SmHC4c_003D);
			}
			_0023_003DzBAdm_0024f8hI85RZD1R3A_003D_003D = false;
		}
		base._0023_003DzuDFPqEJA5SPt1pVAXA_003D_003D(_0023_003DzxwGby4M_003D, _0023_003Dz1SmHC4c_003D);
	}

	private protected override void _0023_003DznL1WlsQ9pGcL(bool _0023_003DzWrfLNCo_003D, bool _0023_003DzBQC8k3F0wJN4)
	{
		if (SimulationSetup != null)
		{
			Plane plane = SimulationSetup.Plane;
			Transformation transformation = new Transformation();
			transformation.Rotation(Vector3D.AxisX, Vector3D.AxisY, Vector3D.AxisZ, plane.AxisX, plane.AxisY, plane.AxisZ);
			transformation.Invert();
			Quaternion initialRotation = new Quaternion(transformation.Matrix);
			Quaternion cameraRotation = base.ActiveViewport.GetCameraRotation(viewType.Trimetric, initialRotation);
			base.ActiveViewport.SetView(cameraRotation, _0023_003DzWrfLNCo_003D, _0023_003DzBQC8k3F0wJN4);
		}
		else
		{
			base._0023_003DznL1WlsQ9pGcL(_0023_003DzWrfLNCo_003D, _0023_003DzBQC8k3F0wJN4);
		}
	}

	public void ResetSimulation()
	{
		_0023_003DznnG9k_o_003D = null;
		_0023_003DzKRihwpJbu9W_0024pR7AinD0Xrs_003D?._0023_003DzUMSSRSw_003D(0);
	}

	public void PauseSimulation()
	{
		_0023_003DzGrg75r5OtcLP = true;
	}

	protected override void OnAnimationTimerTick(object stateInfo)
	{
		if (!_0023_003DzGrg75r5OtcLP && _0023_003DzmNZD0Zs_003D != null)
		{
			BeginInvoke(new Action(_0023_003DzBVcoghPc2Tnx), null);
		}
	}

	private void _0023_003DzBVcoghPc2Tnx()
	{
		if (_0023_003Dz20mE5GcuA_0024Nv == null || _0023_003Dz66_G081XVxFkU61S4PaN_io_003D == null || !_0023_003DzKRihwpJbu9W_0024pR7AinD0Xrs_003D._0023_003Dz0_4_A89QUv3z())
		{
			return;
		}
		if (!_0023_003DzKRihwpJbu9W_0024pR7AinD0Xrs_003D._0023_003DzYW9U4v0_003D())
		{
			_0023_003DzKRihwpJbu9W_0024pR7AinD0Xrs_003D._0023_003Dze5O5R4s_003D();
			_0023_003DzqyIi0qJHHOrU(base.ActiveViewport, _0023_003DzsLHxXyo_003D: true);
			_0023_003DzHZMqgEfrVWAi(base.ActiveViewport, _0023_003DzWtFDQr8_003D: true);
			StopAnimation();
			SimulationTimeLine._0023_003DzlGvHHDocBoCZ(SimulationToolpath.Length());
			_0023_003Dzl36fwfqeTvT9();
			return;
		}
		PointCL pointCL = null;
		bool flag = false;
		foreach (PointCL item in _0023_003DzKRihwpJbu9W_0024pR7AinD0Xrs_003D._0023_003DzrCQ6Dc8_003D(_0023_003Dz6B6EHOKYvqqdVUmdgQ_003D_003D: true))
		{
			if (_0023_003DzKLccc_A_003D(item, this, _0023_003Dz20mE5GcuA_0024Nv, null, _0023_003DzUFCuHpQ_003D: true, _0023_003DzmYYhyTjTIK2p: false))
			{
				flag = true;
			}
			pointCL = item;
		}
		_0023_003DzFrByqiXF9Gb8(flag);
		if (pointCL != null)
		{
			_0023_003DzKLccc_A_003D(pointCL, this, _0023_003Dz20mE5GcuA_0024Nv, null, _0023_003DzUFCuHpQ_003D: false, _0023_003DzmYYhyTjTIK2p: false);
		}
		if (_0023_003DzznDghL_IGqSJ != null)
		{
			base.RenderContext.MakeCurrent();
			_0023_003DzznDghL_IGqSJ.Compile(new CompileParams(this));
		}
		Invalidate();
		if (flag && StopOnCollision)
		{
			Pause();
		}
	}

	internal void _0023_003DzFrByqiXF9Gb8(bool _0023_003DzGXRK8GYwmXjPflrP_g_003D_003D)
	{
		_0023_003DzD0oP7TBd5Fj9.Visible = _0023_003DzdRU4TSI5nCSw && _0023_003DzGXRK8GYwmXjPflrP_g_003D_003D && _0023_003Dz20mE5GcuA_0024Nv.Visible;
	}

	private static void _0023_003DzmiSm_9n_7gFtXBtmyQ_003D_003D(BlockReference _0023_003DzKSC6PU0_003D, Point3D _0023_003DzfOC0YjY_003D, Setup _0023_003Dzmn8NnRo_003D)
	{
		Point3D point3D = (Point3D)_0023_003DzfOC0YjY_003D.Clone();
		point3D.TransformBy(_0023_003Dzmn8NnRo_003D.Transformation);
		Transformation transformation = (_0023_003DzKSC6PU0_003D.Transformation = Transformation.CreateTranslation(point3D.X, point3D.Y, point3D.Z));
		if (point3D is PointNormal pointNormal)
		{
			Vector3D axis = Vector3D.Cross(Vector3D.AxisZ, pointNormal.Normal);
			Transformation transformation3 = Transformation.CreateRotation(Vector3D.AngleBetween(Vector3D.AxisZ, pointNormal.Normal), axis, pointNormal);
			_0023_003DzKSC6PU0_003D.Transformation = transformation3 * transformation;
		}
	}

	private void _0023_003Dzjj21PP8_003D()
	{
		if (_0023_003DzKRihwpJbu9W_0024pR7AinD0Xrs_003D != null)
		{
			_0023_003DzKRihwpJbu9W_0024pR7AinD0Xrs_003D._0023_003DznQGaNxg_003D = (_0023_003DzmqbiRTIqhL7EvFfwZQ_003D_003D.HasValue ? (_0023_003DzeNQjlVo8TnwL.Diameter / 10.0 * 50.0 * (double)_0023_003DzmqbiRTIqhL7EvFfwZQ_003D_003D.Value) : _0023_003DziZ8BZpigbMTt);
		}
	}

	public void AutoSpeed(int factor)
	{
		if (factor < 0)
		{
			throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348586964));
		}
		_0023_003DzmqbiRTIqhL7EvFfwZQ_003D_003D = factor;
		_0023_003Dzjj21PP8_003D();
	}

	private void _0023_003Dzcp60CRpn2SZv(object _0023_003DzxwGby4M_003D, EventArgs _0023_003Dz1SmHC4c_003D)
	{
		GoToBeginning();
	}

	public void GoToBeginning()
	{
		if (_0023_003Dz20mE5GcuA_0024Nv != null)
		{
			PointCL pointCL = _0023_003DzKRihwpJbu9W_0024pR7AinD0Xrs_003D._0023_003DzUMSSRSw_003D(0);
			_0023_003DzKLccc_A_003D(pointCL, this, _0023_003Dz20mE5GcuA_0024Nv, null, _0023_003DzUFCuHpQ_003D: false, _0023_003DzmYYhyTjTIK2p: false);
			_0023_003DzLibvUa2axNVJ((PointCL)pointCL.Clone(), -1);
		}
	}

	private void _0023_003DzA63SKRsqNbI4(object _0023_003DzxwGby4M_003D, EventArgs _0023_003Dz1SmHC4c_003D)
	{
		GoToPrevious();
	}

	private void _0023_003DzNju0dz8dOXb9(int _0023_003DzusPIN8Q_003D)
	{
		if (_0023_003DzFrVxU64BV0ac)
		{
			_0023_003DzFrVxU64BV0ac = false;
			_0023_003DzKLccc_A_003D(_0023_003DzxppThJsMAJvL, this, _0023_003Dz20mE5GcuA_0024Nv, new CompileParams(this), _0023_003DzUFCuHpQ_003D: false, _0023_003DzmYYhyTjTIK2p: false);
			_0023_003DzLibvUa2axNVJ((PointCL)_0023_003DzxppThJsMAJvL, _0023_003DzusPIN8Q_003D);
		}
	}

	public void GoToPrevious()
	{
		_0023_003DzNju0dz8dOXb9(-1);
		if (_0023_003DzKRihwpJbu9W_0024pR7AinD0Xrs_003D._0023_003Dzt3NUtcQ_003D(out var _0023_003DzxGL6Kng_003D))
		{
			_0023_003DzKLccc_A_003D(_0023_003DzxGL6Kng_003D, this, _0023_003Dz20mE5GcuA_0024Nv, null, _0023_003DzUFCuHpQ_003D: true, _0023_003DzmYYhyTjTIK2p: false);
			_0023_003DzLibvUa2axNVJ((PointCL)_0023_003DzxGL6Kng_003D.Clone(), -1);
		}
	}

	public void SimulationStart()
	{
		ResetSimulation();
		_0023_003Dz7QMtV8_0024k11am(null, null);
	}

	protected override void OnResize(EventArgs e)
	{
		base.OnResize(e);
		SimulationTimeLine?._0023_003DzCKgO2G0_003D();
	}

	private void _0023_003DzAjrT9Qo_003D()
	{
		SimulationTimeLine._0023_003DzEnEOg3EifJXc(_0023_003DzeNQjlVo8TnwL);
		if (SimulationTimeLine.isDirty)
		{
			SimulationTimeLine.Init();
		}
	}

	private void _0023_003Dzc70I3AxXlcSB()
	{
		_0023_003DzFrVxU64BV0ac = false;
		if (SimulationTimeLine.resetTool)
		{
			SimulationTimeLine.resetTool = false;
			base.Blocks[_0023_003DzMK_SXXTeS2YU].Entities.Clear();
			Entity visualRep = _0023_003DzeNQjlVo8TnwL.GetVisualRep();
			_0023_003DzFq4cQqFyw187(visualRep);
			base.Blocks[_0023_003DzMK_SXXTeS2YU].Entities.Add(visualRep);
		}
	}

	public void Start()
	{
		_0023_003DzAjrT9Qo_003D();
		_0023_003DzmusH3OdgzW8u();
		_0023_003Dzjj21PP8_003D();
		_0023_003DzqyIi0qJHHOrU(base.ActiveViewport, _0023_003DzsLHxXyo_003D: false);
		_0023_003DzIMzi9JAvb4iGNpwi0A_003D_003D = base.Rendered.SilhouettesDrawingMode;
		_0023_003DzKQKZozMiwcr5 = base.Rendered.ShadowMode;
		_0023_003DzYMb1PVVvnw1EEg2g4A_003D_003D = base.Shaded.ShadowMode;
		_0023_003DzW_BoWEDvWvC1HPPcmnl_rzI_003D = base.Rendered.PlanarReflections;
		base.Rendered.SilhouettesDrawingMode = silhouettesDrawingType.Never;
		base.Rendered.ShadowMode = shadowType.None;
		base.Rendered.PlanarReflections = false;
		_0023_003DzdRU4TSI5nCSw = _0023_003DzeNQjlVo8TnwL is Tool tool && tool.CollisionRadius > 0.0;
		_0023_003DzHZMqgEfrVWAi(base.ActiveViewport, _0023_003DzWtFDQr8_003D: false);
		if (_0023_003DzFrVxU64BV0ac)
		{
			_0023_003Dzc70I3AxXlcSB();
			_0023_003DzKLccc_A_003D(_0023_003DzxppThJsMAJvL, this, _0023_003Dz20mE5GcuA_0024Nv, new CompileParams(this), _0023_003DzUFCuHpQ_003D: false, _0023_003DzmYYhyTjTIK2p: false);
		}
		if (!_0023_003DzKRihwpJbu9W_0024pR7AinD0Xrs_003D._0023_003DzYW9U4v0_003D())
		{
			_0023_003DznnG9k_o_003D = _0023_003DzKRihwpJbu9W_0024pR7AinD0Xrs_003D._0023_003DzUMSSRSw_003D(0);
			_0023_003DzmiSm_9n_7gFtXBtmyQ_003D_003D(_0023_003Dz20mE5GcuA_0024Nv, _0023_003DznnG9k_o_003D, SimulationSetup);
		}
		_0023_003DzoxYJkAM5bdYq();
		_0023_003DzKRihwpJbu9W_0024pR7AinD0Xrs_003D._0023_003DzvsdjAuY_003D();
		_0023_003DzGrg75r5OtcLP = false;
		StartAnimation(20);
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
		_0023_003DzGrg75r5OtcLP = true;
		_0023_003DzKRihwpJbu9W_0024pR7AinD0Xrs_003D._0023_003Dze5O5R4s_003D();
		_0023_003DzqyIi0qJHHOrU(base.ActiveViewport, _0023_003DzsLHxXyo_003D: true);
		_0023_003DzHZMqgEfrVWAi(base.ActiveViewport, _0023_003DzWtFDQr8_003D: true);
		base.Rendered.SilhouettesDrawingMode = _0023_003DzIMzi9JAvb4iGNpwi0A_003D_003D;
		base.Rendered.ShadowMode = _0023_003DzKQKZozMiwcr5;
		base.Shaded.ShadowMode = _0023_003DzYMb1PVVvnw1EEg2g4A_003D_003D;
		base.Rendered.PlanarReflections = _0023_003DzW_BoWEDvWvC1HPPcmnl_rzI_003D;
		_0023_003DzeO8LRLrcr7EG();
		PointCL _0023_003DzRo3lpTk5P2Y_0024UcPgtg_003D_003D = _0023_003DzKRihwpJbu9W_0024pR7AinD0Xrs_003D._0023_003DzpBTIMwo_003D(_0023_003Dz6B6EHOKYvqqdVUmdgQ_003D_003D: true);
		_0023_003DzLibvUa2axNVJ(_0023_003DzRo3lpTk5P2Y_0024UcPgtg_003D_003D, 1);
	}

	public void GoToNext()
	{
		_0023_003DzNju0dz8dOXb9(1);
		if (_0023_003DzKRihwpJbu9W_0024pR7AinD0Xrs_003D._0023_003DzYW9U4v0_003D())
		{
			_0023_003DzmusH3OdgzW8u();
			PointCL pointCL = _0023_003DzKRihwpJbu9W_0024pR7AinD0Xrs_003D._0023_003DzrCQ6Dc8_003D(_0023_003Dz6B6EHOKYvqqdVUmdgQ_003D_003D: false).First();
			bool flag = _0023_003DzKLccc_A_003D(pointCL, this, _0023_003Dz20mE5GcuA_0024Nv, new CompileParams(this), _0023_003DzUFCuHpQ_003D: true, _0023_003DzmYYhyTjTIK2p: false);
			_0023_003DzD0oP7TBd5Fj9.Visible = _0023_003DzdRU4TSI5nCSw && flag;
			_0023_003Dz20mE5GcuA_0024Nv.Visible = !_0023_003DzD0oP7TBd5Fj9.Visible;
			_0023_003DzLibvUa2axNVJ((PointCL)pointCL.Clone(), 1);
		}
	}

	public void GoToMotion(int index, bool cut = false)
	{
		_0023_003DzNju0dz8dOXb9(0);
		if (!_0023_003DzKRihwpJbu9W_0024pR7AinD0Xrs_003D._0023_003DzYW9U4v0_003D())
		{
			return;
		}
		if (_0023_003Dz20mE5GcuA_0024Nv == null)
		{
			_0023_003DzmusH3OdgzW8u();
		}
		else
		{
			_0023_003Dz20mE5GcuA_0024Nv.Transformation = new Identity();
			_0023_003DzmiSm_9n_7gFtXBtmyQ_003D_003D(_0023_003Dz20mE5GcuA_0024Nv, _0023_003Dz66_G081XVxFkU61S4PaN_io_003D.Vertices[0], SimulationSetup);
		}
		PointCL _0023_003Dzdlv8VnHlpMGa = (PointCL)_0023_003Dz66_G081XVxFkU61S4PaN_io_003D.Vertices[0];
		if (cut)
		{
			int num = _0023_003DzKRihwpJbu9W_0024pR7AinD0Xrs_003D._0023_003DzLk_00240G8HRo6CP();
			int num2 = _0023_003Dz66_G081XVxFkU61S4PaN_io_003D.Vertices.ToList().IndexOf(_0023_003Dz66_G081XVxFkU61S4PaN_io_003D.MotionList[index].EndPoint);
			for (int i = num; i < num2; i++)
			{
				_0023_003Dzdlv8VnHlpMGa = _0023_003DzKRihwpJbu9W_0024pR7AinD0Xrs_003D._0023_003DzrCQ6Dc8_003D(_0023_003Dz6B6EHOKYvqqdVUmdgQ_003D_003D: false).First();
			}
			_0023_003DzyPtIoUHaGaKn(num);
		}
		else
		{
			bool flag = _0023_003DzKLccc_A_003D(_0023_003Dzdlv8VnHlpMGa, this, _0023_003Dz20mE5GcuA_0024Nv, new CompileParams(this), _0023_003DzUFCuHpQ_003D: false, _0023_003DzmYYhyTjTIK2p: false);
			_0023_003DzD0oP7TBd5Fj9.Visible = _0023_003DzdRU4TSI5nCSw && flag;
			_0023_003Dz20mE5GcuA_0024Nv.Visible = !_0023_003DzD0oP7TBd5Fj9.Visible;
		}
	}

	private void _0023_003DzyPtIoUHaGaKn(int _0023_003DzhlCpXt8_003D)
	{
		_0023_003DzAjrT9Qo_003D();
		if (_0023_003DzznDghL_IGqSJ != null)
		{
			_0023_003DzoxYJkAM5bdYq();
			_0023_003DzUcEVokiS1LwqHRRaC0mGpnaI1oOZ68PVIQ_003D_003D workUnit = new _0023_003DzUcEVokiS1LwqHRRaC0mGpnaI1oOZ68PVIQ_003D_003D(this, _0023_003DzhlCpXt8_003D, _0023_003DzKRihwpJbu9W_0024pR7AinD0Xrs_003D._0023_003DzLk_00240G8HRo6CP() + 1, CuttingStockText);
			SimulationTimeLine.enabled = false;
			StartWork(workUnit);
		}
		_0023_003DzmusH3OdgzW8u();
		_0023_003DzKLccc_A_003D(_0023_003DzKRihwpJbu9W_0024pR7AinD0Xrs_003D._0023_003DzpBTIMwo_003D(_0023_003Dz6B6EHOKYvqqdVUmdgQ_003D_003D: false), this, _0023_003Dz20mE5GcuA_0024Nv, new CompileParams(this), _0023_003DzUFCuHpQ_003D: false, _0023_003DzmYYhyTjTIK2p: false);
	}

	private void _0023_003DzjlQtxOK8F_0024Ai(object _0023_003DzxwGby4M_003D, EventArgs _0023_003Dz1SmHC4c_003D)
	{
		GoToNext();
	}

	private void _0023_003DzAieoim7wfgUE(object _0023_003DzxwGby4M_003D, EventArgs _0023_003Dz1SmHC4c_003D)
	{
		GoToEnd();
	}

	public void GoToEnd()
	{
		_0023_003DzAjrT9Qo_003D();
		if (_0023_003DzznDghL_IGqSJ != null)
		{
			_0023_003DzoxYJkAM5bdYq();
			_0023_003DzUcEVokiS1LwqHRRaC0mGpnaI1oOZ68PVIQ_003D_003D workUnit = new _0023_003DzUcEVokiS1LwqHRRaC0mGpnaI1oOZ68PVIQ_003D_003D(this, _0023_003DzKRihwpJbu9W_0024pR7AinD0Xrs_003D._0023_003DzLk_00240G8HRo6CP(), _0023_003Dz66_G081XVxFkU61S4PaN_io_003D.allVertices.Length, CuttingStockText);
			SimulationTimeLine.enabled = false;
			StartWork(workUnit);
		}
		_0023_003DzmusH3OdgzW8u();
		PointCL pointCL = _0023_003DzKRihwpJbu9W_0024pR7AinD0Xrs_003D._0023_003DzjUof5tE_003D();
		_0023_003DzKLccc_A_003D(pointCL, this, _0023_003Dz20mE5GcuA_0024Nv, new CompileParams(this), _0023_003DzUFCuHpQ_003D: false, _0023_003DzmYYhyTjTIK2p: false);
		_0023_003DzLibvUa2axNVJ((PointCL)pointCL.Clone(), 1);
	}

	public void SimulateToEnd()
	{
		_0023_003DzmusH3OdgzW8u();
		_0023_003DzAieoim7wfgUE(null, null);
	}

	internal static bool _0023_003DzKLccc_A_003D(Point3D _0023_003Dzdlv8VnHlpMGa, Manufacture _0023_003DzBVcepo2A_gB2PiTRJg_003D_003D, BlockReference _0023_003DzqhWU5eA_003D, CompileParams _0023_003Dz3gif_00241c_003D, bool _0023_003DzUFCuHpQ_003D, bool _0023_003DzmYYhyTjTIK2p)
	{
		bool flag = false;
		Point3D point3D = ((_0023_003DzBVcepo2A_gB2PiTRJg_003D_003D._0023_003DznnG9k_o_003D != null) ? _0023_003DzBVcepo2A_gB2PiTRJg_003D_003D._0023_003DznnG9k_o_003D : _0023_003DzBVcepo2A_gB2PiTRJg_003D_003D._0023_003Dz66_G081XVxFkU61S4PaN_io_003D.Vertices[0]);
		Point3D obj = (Point3D)point3D.Clone();
		Point3D point3D2 = (Point3D)_0023_003Dzdlv8VnHlpMGa.Clone();
		obj.TransformBy(_0023_003DzBVcepo2A_gB2PiTRJg_003D_003D.SimulationSetup.Transformation);
		point3D2.TransformBy(_0023_003DzBVcepo2A_gB2PiTRJg_003D_003D.SimulationSetup.Transformation);
		if (_0023_003DzUFCuHpQ_003D && _0023_003DzBVcepo2A_gB2PiTRJg_003D_003D._0023_003DzznDghL_IGqSJ != null)
		{
			flag = _0023_003DzBVcepo2A_gB2PiTRJg_003D_003D._0023_003DzznDghL_IGqSJ.Cut(point3D, _0023_003Dzdlv8VnHlpMGa, _0023_003DzBVcepo2A_gB2PiTRJg_003D_003D._0023_003DzeNQjlVo8TnwL, computeDiagonals: true, computeNormals: true, _0023_003Dz3gif_00241c_003D);
			if (_0023_003DzBVcepo2A_gB2PiTRJg_003D_003D._0023_003DzdRU4TSI5nCSw && flag)
			{
				int motionIndex = _0023_003DzBVcepo2A_gB2PiTRJg_003D_003D._0023_003DzKRihwpJbu9W_0024pR7AinD0Xrs_003D._0023_003DzqXBOy1c_003D[_0023_003DzBVcepo2A_gB2PiTRJg_003D_003D._0023_003DzKRihwpJbu9W_0024pR7AinD0Xrs_003D._0023_003DzLk_00240G8HRo6CP()].MotionIndex;
				Toolpath.Motion motion = _0023_003DzBVcepo2A_gB2PiTRJg_003D_003D.SimulationToolpath.MotionList[motionIndex];
				_0023_003DzBVcepo2A_gB2PiTRJg_003D_003D.SimulationTimeLine._0023_003DzaRI1GtM_003D(motion.lengthUpTo, motion.Length(), motionIndex, _0023_003DzBVcepo2A_gB2PiTRJg_003D_003D.SimulationTimeLine.simulationToolPaths.IndexOf(_0023_003DzBVcepo2A_gB2PiTRJg_003D_003D.SimulationToolpath));
			}
		}
		Vector3D v = new Vector3D(obj, point3D2);
		_0023_003DzqhWU5eA_003D.Translate(v);
		_0023_003DzBVcepo2A_gB2PiTRJg_003D_003D._0023_003DzD0oP7TBd5Fj9.Translate(v);
		if (obj is PointNormal pointNormal && point3D2 is PointNormal pointNormal2 && !Vector3D.AreParallel(pointNormal.Normal, pointNormal2.Normal))
		{
			Vector3D axis = Vector3D.Cross(pointNormal.Normal, pointNormal2.Normal);
			double angleInRadians = Vector3D.AngleBetween(pointNormal.Normal, pointNormal2.Normal);
			_0023_003DzqhWU5eA_003D.Rotate(angleInRadians, axis, point3D2);
			_0023_003DzBVcepo2A_gB2PiTRJg_003D_003D._0023_003DzD0oP7TBd5Fj9.Rotate(angleInRadians, axis, point3D2);
		}
		_0023_003DzqhWU5eA_003D.UpdateBoundingBox(new TraversalParams(_0023_003DzBVcepo2A_gB2PiTRJg_003D_003D.Blocks));
		_0023_003DzqhWU5eA_003D.RegenMode = regenType.NotNeeded;
		if (_0023_003DzmYYhyTjTIK2p)
		{
			_0023_003DzBVcepo2A_gB2PiTRJg_003D_003D._0023_003DzxppThJsMAJvL = _0023_003DzBVcepo2A_gB2PiTRJg_003D_003D._0023_003DznnG9k_o_003D.Clone() as Point3D;
		}
		_0023_003DzBVcepo2A_gB2PiTRJg_003D_003D._0023_003DznnG9k_o_003D = _0023_003Dzdlv8VnHlpMGa;
		return flag;
	}

	private void _0023_003DzmusH3OdgzW8u()
	{
		if (_0023_003Dz20mE5GcuA_0024Nv == null)
		{
			Entity visualRep = _0023_003DzeNQjlVo8TnwL.GetVisualRep();
			_0023_003DzFq4cQqFyw187(visualRep);
			if (!base.Blocks.Contains(_0023_003DzMK_SXXTeS2YU))
			{
				Block block = new Block(_0023_003DzMK_SXXTeS2YU);
				block.Entities.Add(visualRep);
				base.Blocks.Add(block);
			}
			else
			{
				base.Blocks[_0023_003DzMK_SXXTeS2YU].Entities.Clear();
				base.Blocks[_0023_003DzMK_SXXTeS2YU].Entities.Add(visualRep);
			}
			_0023_003Dz20mE5GcuA_0024Nv = new BlockReference(_0023_003DzMK_SXXTeS2YU);
			_0023_003DzmiSm_9n_7gFtXBtmyQ_003D_003D(_0023_003Dz20mE5GcuA_0024Nv, _0023_003Dz66_G081XVxFkU61S4PaN_io_003D.Vertices[0], SimulationSetup);
			base.Entities.Add(_0023_003Dz20mE5GcuA_0024Nv);
		}
		_0023_003DzUSdcpYGibIjc(base.Blocks[_0023_003DzMK_SXXTeS2YU].Entities[0].Clone() as Mesh);
	}

	internal void _0023_003DzFq4cQqFyw187(Entity _0023_003DzLtLprGE_003D)
	{
		if (!SimulationSetup.Transformation.IsIdentity())
		{
			Transformation transformation = (Transformation)SimulationSetup.Transformation.Clone();
			transformation[0, 3] = 0.0;
			transformation[1, 3] = 0.0;
			transformation[2, 3] = 0.0;
			_0023_003DzLtLprGE_003D.TransformBy(transformation);
		}
	}

	internal void _0023_003DzUSdcpYGibIjc(Mesh _0023_003DzLtLprGE_003D)
	{
		base.TempEntities.Clear();
		_0023_003DzD0oP7TBd5Fj9 = _0023_003DzLtLprGE_003D.Clone() as Mesh;
		_0023_003DzD0oP7TBd5Fj9.EdgeStyle = Mesh.edgeStyleType.Sharp;
		_0023_003DzD0oP7TBd5Fj9.Color = Color.FromArgb(100, Color.Red);
		_0023_003DzD0oP7TBd5Fj9.Visible = false;
		_0023_003DzD0oP7TBd5Fj9.TransformBy(_0023_003Dz20mE5GcuA_0024Nv.Transformation);
		_0023_003DzD0oP7TBd5Fj9.Regen(0.0);
		base.TempEntities.Add(_0023_003DzD0oP7TBd5Fj9);
	}

	public override void Clear()
	{
		base.Clear();
		if (_0023_003Dz20mE5GcuA_0024Nv != null)
		{
			_0023_003Dz20mE5GcuA_0024Nv.Dispose();
		}
		_0023_003DzeNQjlVo8TnwL = null;
		if (_0023_003Dz66_G081XVxFkU61S4PaN_io_003D != null)
		{
			_0023_003Dz66_G081XVxFkU61S4PaN_io_003D.Dispose();
		}
		_0023_003Dz66_G081XVxFkU61S4PaN_io_003D = null;
		if (_0023_003DzznDghL_IGqSJ != null)
		{
			_0023_003DzznDghL_IGqSJ.Dispose();
		}
		_0023_003DzznDghL_IGqSJ = null;
		if (_0023_003DzJy9FHddJnnQ00_FXBQ_003D_003D != null)
		{
			_0023_003DzJy9FHddJnnQ00_FXBQ_003D_003D.Dispose();
		}
		_0023_003DzJy9FHddJnnQ00_FXBQ_003D_003D = null;
		if (_0023_003DzBqnmOMQbymUZBIXA0A_003D_003D != null)
		{
			_0023_003DzBqnmOMQbymUZBIXA0A_003D_003D.Dispose();
		}
		_0023_003DzBqnmOMQbymUZBIXA0A_003D_003D = null;
		if (_0023_003DzN82DCxtj79dGyGF3QxA30x0_003D != null)
		{
			_0023_003DzN82DCxtj79dGyGF3QxA30x0_003D.Dispose();
		}
		_0023_003DzN82DCxtj79dGyGF3QxA30x0_003D = null;
		if (_0023_003Dz2UfdJ_SfotNctzPMTVnI8Lg_003D != null)
		{
			_0023_003Dz2UfdJ_SfotNctzPMTVnI8Lg_003D.Dispose();
		}
		_0023_003Dz2UfdJ_SfotNctzPMTVnI8Lg_003D = null;
		ResetSimulation();
		ResetTimeLine();
	}

	public void ResetTimeLine()
	{
		SimulationTimeLine._0023_003DzxEpSi5o_003D();
	}

	public int AddUserInterfaceElementFor(Setup setup, int size = 5)
	{
		return base.ActiveViewport.AddUserInterfaceElementFor(setup, size);
	}
}
