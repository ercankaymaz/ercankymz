#define WINFORMS
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using devDept.Eyeshot.Control.Labels;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Control;

[ToolboxItem(true)]
[ToolboxBitmap(typeof(Design))]
[Description("Provides the ability to import or create geometry.")]
[Designer("devDept.Eyeshot.Designer.DesignControlDesigner, devDept.Eyeshot.Control.Win.v2026.Design")]
public class Design : Workspace, IDesign, IWorkspace
{
	[StructLayout(LayoutKind.Auto)]
	private struct _0023_003Dz6cURjfaIAPf_Uwdn75T1QJk_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003Dz0FVSO5LFyxyq;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder _0023_003DzFUVSvBsTIB9Y;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Design _0023_003DzKdgtcDsi34jL;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Stream _0023_003DzRKBNJQQ_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Drawing _0023_003DzfdgxWgs_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public FileSerializer _0023_003DzPQvnoRZw23LX;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter _0023_003Dz9ZxzSZcDWPjZ;

		private void MoveNext()
		{
			int num = _0023_003Dz0FVSO5LFyxyq;
			Design design = _0023_003DzKdgtcDsi34jL;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = design.Document.OpenFileAsync(_0023_003DzRKBNJQQ_003D, _0023_003DzfdgxWgs_003D?.Document, _0023_003DzPQvnoRZw23LX).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_0023_003Dz0FVSO5LFyxyq = 0);
						_0023_003Dz9ZxzSZcDWPjZ = awaiter;
						_0023_003DzFUVSvBsTIB9Y.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
				}
				else
				{
					awaiter = _0023_003Dz9ZxzSZcDWPjZ;
					_0023_003Dz9ZxzSZcDWPjZ = default(TaskAwaiter);
					num = (_0023_003Dz0FVSO5LFyxyq = -1);
				}
				awaiter.GetResult();
			}
			catch (Exception exception)
			{
				_0023_003Dz0FVSO5LFyxyq = -2;
				_0023_003DzFUVSvBsTIB9Y.SetException(exception);
				return;
			}
			_0023_003Dz0FVSO5LFyxyq = -2;
			_0023_003DzFUVSvBsTIB9Y.SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine _0023_003DzVzjxMe0_003D)
		{
			_0023_003DzFUVSvBsTIB9Y.SetStateMachine(_0023_003DzVzjxMe0_003D);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine _0023_003DzVzjxMe0_003D)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(_0023_003DzVzjxMe0_003D);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct _0023_003Dz7zX7fHZ8QyYSMYPhzw_003D_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003Dz0FVSO5LFyxyq;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder _0023_003DzFUVSvBsTIB9Y;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Design _0023_003DzKdgtcDsi34jL;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Stream _0023_003DzRKBNJQQ_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Drawing _0023_003DzfdgxWgs_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public contentType _0023_003DztCpV_0024Es_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public FileSerializer _0023_003DzPQvnoRZw23LX;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter _0023_003Dz9ZxzSZcDWPjZ;

		private void MoveNext()
		{
			int num = _0023_003Dz0FVSO5LFyxyq;
			Design design = _0023_003DzKdgtcDsi34jL;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = design.Document.SaveFileAsync(_0023_003DzRKBNJQQ_003D, _0023_003DzfdgxWgs_003D?.Document, _0023_003DztCpV_0024Es_003D, _0023_003DzPQvnoRZw23LX).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_0023_003Dz0FVSO5LFyxyq = 0);
						_0023_003Dz9ZxzSZcDWPjZ = awaiter;
						_0023_003DzFUVSvBsTIB9Y.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
				}
				else
				{
					awaiter = _0023_003Dz9ZxzSZcDWPjZ;
					_0023_003Dz9ZxzSZcDWPjZ = default(TaskAwaiter);
					num = (_0023_003Dz0FVSO5LFyxyq = -1);
				}
				awaiter.GetResult();
			}
			catch (Exception exception)
			{
				_0023_003Dz0FVSO5LFyxyq = -2;
				_0023_003DzFUVSvBsTIB9Y.SetException(exception);
				return;
			}
			_0023_003Dz0FVSO5LFyxyq = -2;
			_0023_003DzFUVSvBsTIB9Y.SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine _0023_003DzVzjxMe0_003D)
		{
			_0023_003DzFUVSvBsTIB9Y.SetStateMachine(_0023_003DzVzjxMe0_003D);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine _0023_003DzVzjxMe0_003D)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(_0023_003DzVzjxMe0_003D);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct _0023_003DzQbrlE3VpJs_00247zLzgmNa8xwY_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003Dz0FVSO5LFyxyq;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder _0023_003DzFUVSvBsTIB9Y;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Design _0023_003DzKdgtcDsi34jL;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string _0023_003Dz83HaHYE_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Drawing _0023_003DzfdgxWgs_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public contentType _0023_003DztCpV_0024Es_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public FileSerializer _0023_003DzPQvnoRZw23LX;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter _0023_003Dz9ZxzSZcDWPjZ;

		private void MoveNext()
		{
			int num = _0023_003Dz0FVSO5LFyxyq;
			Design design = _0023_003DzKdgtcDsi34jL;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = design.Document.SaveFileAsync(_0023_003Dz83HaHYE_003D, _0023_003DzfdgxWgs_003D?.Document, _0023_003DztCpV_0024Es_003D, _0023_003DzPQvnoRZw23LX).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_0023_003Dz0FVSO5LFyxyq = 0);
						_0023_003Dz9ZxzSZcDWPjZ = awaiter;
						_0023_003DzFUVSvBsTIB9Y.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
				}
				else
				{
					awaiter = _0023_003Dz9ZxzSZcDWPjZ;
					_0023_003Dz9ZxzSZcDWPjZ = default(TaskAwaiter);
					num = (_0023_003Dz0FVSO5LFyxyq = -1);
				}
				awaiter.GetResult();
			}
			catch (Exception exception)
			{
				_0023_003Dz0FVSO5LFyxyq = -2;
				_0023_003DzFUVSvBsTIB9Y.SetException(exception);
				return;
			}
			_0023_003Dz0FVSO5LFyxyq = -2;
			_0023_003DzFUVSvBsTIB9Y.SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine _0023_003DzVzjxMe0_003D)
		{
			_0023_003DzFUVSvBsTIB9Y.SetStateMachine(_0023_003DzVzjxMe0_003D);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine _0023_003DzVzjxMe0_003D)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(_0023_003DzVzjxMe0_003D);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct _0023_003Dzqm3LPuqg6wZaOzaiFuB7Hr0_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003Dz0FVSO5LFyxyq;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder _0023_003DzFUVSvBsTIB9Y;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Design _0023_003DzKdgtcDsi34jL;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string _0023_003Dz83HaHYE_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Drawing _0023_003DzfdgxWgs_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public FileSerializer _0023_003DzPQvnoRZw23LX;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter _0023_003Dz9ZxzSZcDWPjZ;

		private void MoveNext()
		{
			int num = _0023_003Dz0FVSO5LFyxyq;
			Design design = _0023_003DzKdgtcDsi34jL;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = design.Document.OpenFileAsync(_0023_003Dz83HaHYE_003D, _0023_003DzfdgxWgs_003D?.Document, _0023_003DzPQvnoRZw23LX).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_0023_003Dz0FVSO5LFyxyq = 0);
						_0023_003Dz9ZxzSZcDWPjZ = awaiter;
						_0023_003DzFUVSvBsTIB9Y.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
				}
				else
				{
					awaiter = _0023_003Dz9ZxzSZcDWPjZ;
					_0023_003Dz9ZxzSZcDWPjZ = default(TaskAwaiter);
					num = (_0023_003Dz0FVSO5LFyxyq = -1);
				}
				awaiter.GetResult();
			}
			catch (Exception exception)
			{
				_0023_003Dz0FVSO5LFyxyq = -2;
				_0023_003DzFUVSvBsTIB9Y.SetException(exception);
				return;
			}
			_0023_003Dz0FVSO5LFyxyq = -2;
			_0023_003DzFUVSvBsTIB9Y.SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine _0023_003DzVzjxMe0_003D)
		{
			_0023_003DzFUVSvBsTIB9Y.SetStateMachine(_0023_003DzVzjxMe0_003D);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine _0023_003DzVzjxMe0_003D)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(_0023_003DzVzjxMe0_003D);
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private zoomFitType _0023_003Dz4e4Kqy0qbT_0024U = zoomFitType.ConvexHull;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private viewportLayoutType _0023_003Dz7Ms6XWE0v6md;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzfNVPZ4kzXmPE;

	public new DesignDocument Document => (DesignDocument)base.Document;

	[NotifyParentProperty(true)]
	[Category("Workspace - Viewports")]
	[Description("Viewports.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Editor("devDept.Eyeshot.Designer.Converters.ViewportCollectionEditor", "System.Drawing.Design.UITypeEditor")]
	public ViewportList Viewports
	{
		get
		{
			return base._0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D;
		}
		set
		{
			base._0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public int ActiveViewportIndex
	{
		get
		{
			return base._0023_003DzBn2ByFKdwrou;
		}
		set
		{
			base._0023_003DzBn2ByFKdwrou = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public Viewport ActiveViewport => _0023_003DzipBYly6zFKAp();

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public linearUnitsType Units
	{
		get
		{
			return base._0023_003DzpYxLcIs_003D;
		}
		set
		{
			base._0023_003DzpYxLcIs_003D = value;
		}
	}

	[Category("Workspace - Viewports")]
	[Description("Gap between Viewports in pixels.")]
	public int ViewportsGap
	{
		get
		{
			return base._0023_003DzIoLIfRTMnbedgBTKjQ_003D_003D;
		}
		set
		{
			base._0023_003DzIoLIfRTMnbedgBTKjQ_003D_003D = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public MaterialKeyedCollection Materials
	{
		get
		{
			return base._0023_003DzBAUfV9t86bF_z_Vm8Q_003D_003D;
		}
		set
		{
			base._0023_003DzBAUfV9t86bF_z_Vm8Q_003D_003D = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Camera Camera
	{
		get
		{
			_0023_003Dz6uL_0024EozYGt7t7F45Ag_003D_003D();
			return ActiveViewport.Camera;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public RotateSettings Rotate
	{
		get
		{
			_0023_003Dz6uL_0024EozYGt7t7F45Ag_003D_003D();
			return ActiveViewport.Rotate;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ZoomSettings Zoom
	{
		get
		{
			_0023_003Dz6uL_0024EozYGt7t7F45Ag_003D_003D();
			return ActiveViewport.Zoom;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public PanSettings Pan
	{
		get
		{
			_0023_003Dz6uL_0024EozYGt7t7F45Ag_003D_003D();
			return ActiveViewport.Pan;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public LabelList Labels
	{
		get
		{
			_0023_003Dz6uL_0024EozYGt7t7F45Ag_003D_003D();
			return ActiveViewport.Labels;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Grid Grid => ActiveViewport.Grid;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Grid[] Grids
	{
		get
		{
			_0023_003Dz6uL_0024EozYGt7t7F45Ag_003D_003D();
			return ActiveViewport.Grids;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public OriginSymbol OriginSymbol
	{
		get
		{
			_0023_003Dz6uL_0024EozYGt7t7F45Ag_003D_003D();
			return ActiveViewport.OriginSymbol;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public OriginSymbol[] OriginSymbols
	{
		get
		{
			_0023_003Dz6uL_0024EozYGt7t7F45Ag_003D_003D();
			return ActiveViewport.OriginSymbols;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public CoordinateSystemIcon CoordinateSystemIcon
	{
		get
		{
			_0023_003Dz6uL_0024EozYGt7t7F45Ag_003D_003D();
			return ActiveViewport._0023_003DzFfOjsSRCbzpd;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ViewCubeIcon ViewCubeIcon
	{
		get
		{
			_0023_003Dz6uL_0024EozYGt7t7F45Ag_003D_003D();
			return ActiveViewport._0023_003Dz4ry2vZefVkxX;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Histogram Histogram
	{
		get
		{
			_0023_003Dz6uL_0024EozYGt7t7F45Ag_003D_003D();
			return ActiveViewport.Histogram;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public zoomFitType ZoomFitMode
	{
		get
		{
			return _0023_003Dz4e4Kqy0qbT_0024U;
		}
		set
		{
			if (_0023_003Dz4e4Kqy0qbT_0024U == zoomFitType.ConvexHull2D && value != zoomFitType.ConvexHull2D)
			{
				_0023_003DzTdGsKPrsLPf8lMrax9_0024HWb0_003D(base.Blocks, _0023_003DzdT0PBw1onYvu: true);
			}
			_0023_003Dz4e4Kqy0qbT_0024U = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ScaleBar ScaleBar
	{
		get
		{
			_0023_003Dz6uL_0024EozYGt7t7F45Ag_003D_003D();
			return ActiveViewport.ScaleBar;
		}
	}

	[Category("Workspace - Display Settings")]
	[Description("Display Settings for Wireframe mode, shared by all viewports.")]
	public DisplayModeSettings Wireframe
	{
		get
		{
			return base._0023_003DzAdpXPj_0024l7nqBsSXydw_003D_003D;
		}
		set
		{
			base._0023_003DzAdpXPj_0024l7nqBsSXydw_003D_003D = value;
		}
	}

	[Category("Workspace - Display Settings")]
	[Description("Display Settings for Shaded mode, shared by all viewports.")]
	public DisplayModeSettingsShaded Shaded
	{
		get
		{
			return base._0023_003DzAv2OMNy7DJ5L;
		}
		set
		{
			base._0023_003DzAv2OMNy7DJ5L = value;
		}
	}

	[Category("Workspace - Display Settings")]
	[Description("Display Settings for Flat mode, shared by all viewports.")]
	public DisplayModeSettingsFlat Flat
	{
		get
		{
			return base._0023_003Dzipe8ch4_003D;
		}
		set
		{
			base._0023_003Dzipe8ch4_003D = value;
		}
	}

	[Category("Workspace - Display Settings")]
	[Description("Display Settings for Rendered mode, shared by all viewports.")]
	public DisplayModeSettingsRendered Rendered
	{
		get
		{
			return base._0023_003DznKkOfo8_003D;
		}
		set
		{
			base._0023_003DznKkOfo8_003D = value;
		}
	}

	[Category("Workspace - Display Settings")]
	[Description("Hidden Lines settings.")]
	public HiddenLinesSettings HiddenLines
	{
		get
		{
			return base._0023_003DzP6FAuV4Dwq24;
		}
		set
		{
			base._0023_003DzP6FAuV4Dwq24 = value;
		}
	}

	[Category("Workspace")]
	[Description("Bounding box settings.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public BoundingBoxSettings BoundingBox
	{
		get
		{
			return base._0023_003DzK3OaHhra7VrS;
		}
		set
		{
			base._0023_003DzK3OaHhra7VrS = value;
		}
	}

	[Category("Workspace - Performance")]
	[Description("The minimum acceptable framerate for dynamic movements.")]
	public int MinimumFramerate
	{
		get
		{
			return base._0023_003DzEDUeIexdjfn_EoBUmQ_003D_003D;
		}
		set
		{
			base._0023_003DzEDUeIexdjfn_EoBUmQ_003D_003D = value;
		}
	}

	[Category("Workspace - Performance")]
	[Description("The minimum screen-space size for entities to be rendered. Entities smaller than this threshold are skipped during rendering.")]
	public double MinimumScreenSize
	{
		get
		{
			return base._0023_003DzW9xZcbsM9yIJ;
		}
		set
		{
			base._0023_003DzW9xZcbsM9yIJ = value;
		}
	}

	[Description("Viewports configuration.")]
	[Category("Workspace - Viewports")]
	public virtual viewportLayoutType LayoutMode
	{
		get
		{
			return base._0023_003DzAyrAfQurY_bE;
		}
		set
		{
			base._0023_003DzAyrAfQurY_bE = value;
		}
	}

	[Category("Workspace - Lighting")]
	[Description("Light 1 attributes.")]
	public LightSettings Light1
	{
		get
		{
			return base._0023_003DzA8xJVfE_003D;
		}
		set
		{
			base._0023_003DzA8xJVfE_003D = value;
		}
	}

	[Category("Workspace - Lighting")]
	[Description("Light 2 attributes.")]
	public LightSettings Light2
	{
		get
		{
			return base._0023_003DzUHjavx4_003D;
		}
		set
		{
			base._0023_003DzUHjavx4_003D = value;
		}
	}

	[Category("Workspace - Lighting")]
	[Description("Light 3 attributes.")]
	public LightSettings Light3
	{
		get
		{
			return base._0023_003Dznb93J4o_003D;
		}
		set
		{
			base._0023_003Dznb93J4o_003D = value;
		}
	}

	[Category("Workspace - Lighting")]
	[Description("Light 4 attributes.")]
	public LightSettings Light4
	{
		get
		{
			return base._0023_003Dz_DQFpGk_003D;
		}
		set
		{
			base._0023_003Dz_DQFpGk_003D = value;
		}
	}

	[Category("Workspace - Lighting")]
	[Description("Light 5 attributes.")]
	public LightSettings Light5
	{
		get
		{
			return base._0023_003DzOFMlt_0024c_003D;
		}
		set
		{
			base._0023_003DzOFMlt_0024c_003D = value;
		}
	}

	[Category("Workspace - Lighting")]
	[Description("Light 6 attributes.")]
	public LightSettings Light6
	{
		get
		{
			return base._0023_003DzBlyZl0s_003D;
		}
		set
		{
			base._0023_003DzBlyZl0s_003D = value;
		}
	}

	[Category("Workspace - Lighting")]
	[Description("Light 7 attributes.")]
	public LightSettings Light7
	{
		get
		{
			return base._0023_003DzROpY3fw_003D;
		}
		set
		{
			base._0023_003DzROpY3fw_003D = value;
		}
	}

	[Category("Workspace - Lighting")]
	[Description("Light 8 attributes.")]
	public LightSettings Light8
	{
		get
		{
			return base._0023_003DzWf_0024Lcf0_003D;
		}
		set
		{
			base._0023_003DzWf_0024Lcf0_003D = value;
		}
	}

	[Category("Workspace - Lighting")]
	[Description("Ambient light intensity.")]
	public Color AmbientLight
	{
		get
		{
			return base._0023_003DzB4HyWijCerQJ;
		}
		set
		{
			base._0023_003DzB4HyWijCerQJ = value;
		}
	}

	[Category("Workspace")]
	[Description("Default material attributes used by the entities without their own material.")]
	public Material DefaultMaterial
	{
		get
		{
			return base._0023_003Dzxpbv4lQ_003D;
		}
		set
		{
			base._0023_003Dzxpbv4lQ_003D = value;
		}
	}

	[TypeConverter(typeof(OpacityConverter))]
	[Category("Workspace")]
	[Description("Distance between the ground plane and the design's bounding box expressed as a fraction of the design height (range 0-1).")]
	public double GroundPlaneDistance
	{
		get
		{
			return _0023_003DzhxZwygT5_0024eSRWpPtOWHuTPM_003D;
		}
		set
		{
			_0023_003DzhxZwygT5_0024eSRWpPtOWHuTPM_003D = value;
		}
	}

	[TypeConverter(typeof(OpacityConverter))]
	[Category("Workspace")]
	[Description("Planar shadow's opacity (range 0-1).")]
	public double PlanarShadowOpacity
	{
		get
		{
			return _0023_003Dz1en4hYuH_0024KDC2BdK0g_003D_003D;
		}
		set
		{
			_0023_003Dz1en4hYuH_0024KDC2BdK0g_003D_003D = value;
		}
	}

	[Category("Workspace - Clipping planes")]
	[Description("Clipping plane 1 attributes.")]
	public ClippingPlane ClippingPlane1
	{
		get
		{
			return base._0023_003DzG6pm3fB_0024JDYx85tz2g_003D_003D;
		}
		set
		{
			base._0023_003DzG6pm3fB_0024JDYx85tz2g_003D_003D = value;
		}
	}

	[Category("Workspace - Clipping planes")]
	[Description("Clipping plane 2 attributes.")]
	public ClippingPlane ClippingPlane2
	{
		get
		{
			return base._0023_003DzUuD80DLRm9m0Ctp_0024LQ_003D_003D;
		}
		set
		{
			base._0023_003DzUuD80DLRm9m0Ctp_0024LQ_003D_003D = value;
		}
	}

	[Category("Workspace - Clipping planes")]
	[Description("Clipping plane 3 attributes.")]
	public ClippingPlane ClippingPlane3
	{
		get
		{
			return base._0023_003DzecljuDpEX8THFTC1Bg_003D_003D;
		}
		set
		{
			base._0023_003DzecljuDpEX8THFTC1Bg_003D_003D = value;
		}
	}

	[Category("Workspace - Clipping planes")]
	[Description("Clipping plane 4 attributes.")]
	public ClippingPlane ClippingPlane4
	{
		get
		{
			return base._0023_003Dz7_0024B6af_0024DoIkBDt98sA_003D_003D;
		}
		set
		{
			base._0023_003Dz7_0024B6af_0024DoIkBDt98sA_003D_003D = value;
		}
	}

	[Category("Workspace - Clipping planes")]
	[Description("Clipping plane 5 attributes.")]
	public ClippingPlane ClippingPlane5
	{
		get
		{
			return base._0023_003DzFcrMFMgYL_8vDuzo_0024A_003D_003D;
		}
		set
		{
			base._0023_003DzFcrMFMgYL_8vDuzo_0024A_003D_003D = value;
		}
	}

	[Category("Workspace - Clipping planes")]
	[Description("Clipping plane 6 attributes.")]
	public ClippingPlane ClippingPlane6
	{
		get
		{
			return base._0023_003DzJD9deTMAEJ3hlvoP_0024A_003D_003D;
		}
		set
		{
			base._0023_003DzJD9deTMAEJ3hlvoP_0024A_003D_003D = value;
		}
	}

	[Category("Workspace")]
	[Description("Gets or sets the manipulator used to graphically position the selected entities.")]
	public ObjectManipulator ObjectManipulator
	{
		get
		{
			return base._0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D;
		}
		set
		{
			base._0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D = value;
		}
	}

	[Category("Workspace")]
	[Description("Border settings.")]
	public BorderSettings ViewportBorder
	{
		get
		{
			return base._0023_003DzOLP90s_0024AN26E;
		}
		set
		{
			base._0023_003DzOLP90s_0024AN26E = value;
		}
	}

	[Category("Workspace - Display Settings")]
	[Description("Default color for top entities with ByParent ColorMethod.")]
	public Color DefaultColor
	{
		get
		{
			return Document.DefaultColor;
		}
		set
		{
			Document.DefaultColor = value;
		}
	}

	[Category("Workspace")]
	[Description("Backface color, shared by all viewports.")]
	public BackfaceSettings Backface
	{
		get
		{
			return base._0023_003DzAzve6tkKNr7t1F9Q_g_003D_003D;
		}
		set
		{
			base._0023_003DzAzve6tkKNr7t1F9Q_g_003D_003D = value;
		}
	}

	[Category("Workspace")]
	[Description("If false, the SetView operations set the orientation with the up-vector closest to the current one.")]
	public bool KeepSceneUpright
	{
		get
		{
			return _0023_003Dzsr62oKVDDQue_0024_0024wA43zLq0s_003D();
		}
		set
		{
			_0023_003DzVB3rG1jFj36mUeWbLcbOAQU_003D(value);
		}
	}

	[Category("Workspace")]
	[Description("Coordinate system orientation mode.")]
	public orientationType OrientationMode
	{
		get
		{
			return base._0023_003Dz0fqXN00AlqdN;
		}
		set
		{
			base._0023_003Dz0fqXN00AlqdN = value;
		}
	}

	[Category("Workspace - Selection")]
	public assemblySelectionType AssemblySelectionMode
	{
		get
		{
			return base._0023_003DznugYzyWkU3Do;
		}
		set
		{
			base._0023_003DznugYzyWkU3Do = value;
		}
	}

	[Category("Workspace - Selection")]
	public selectionFilterType SelectionFilterMode
	{
		get
		{
			return base._0023_003Dz28QCun7pbbWH;
		}
		set
		{
			base._0023_003Dz28QCun7pbbWH = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool SplitterMoving
	{
		get
		{
			return base._0023_003Dz_0024zgVvF4OlegG;
		}
		set
		{
			base._0023_003Dz_0024zgVvF4OlegG = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public double FaceSelectionAngle
	{
		get
		{
			return base._0023_003DzXTX6Wl_tlLz9;
		}
		set
		{
			base._0023_003DzXTX6Wl_tlLz9 = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public bool WriteDepthForTransparents
	{
		get
		{
			return _0023_003DzYtqGTMwg_0024Ufr8epgUBxoDPPd_0024XV2;
		}
		set
		{
			_0023_003DzYtqGTMwg_0024Ufr8epgUBxoDPPd_0024XV2 = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public bool WriteDepthForFrozen
	{
		get
		{
			return _0023_003Dz_EkZHS2QnMod;
		}
		set
		{
			_0023_003Dz_EkZHS2QnMod = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public SketchEntity CurrentSketch => base.CurrentBlock.sketchEntity;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool IsAnimationRunning => _0023_003DzyobtGSd5_zcs();

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int AnimationStep
	{
		get
		{
			return _0023_003Dz11GAUsevhJJJ;
		}
		set
		{
			_0023_003Dz11GAUsevhJJJ = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int AnimationInterval
	{
		get
		{
			return _0023_003DzfrZS1vKuIMTc;
		}
		set
		{
			_0023_003DzfrZS1vKuIMTc = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int AnimationFrameNumber
	{
		get
		{
			return _0023_003DzadGKi_0024sgvFBr;
		}
		set
		{
			_0023_003DzadGKi_0024sgvFBr = value;
		}
	}

	public Design()
	{
		if (IsDesignMode())
		{
			ZoomFitMode = zoomFitType.Standard;
		}
		DefaultMaterial.EnvironmentMappingImage = _0023_003DzuFB8tZJm0S0gGof5g000kq4FhI0ejaxNgA_003D_003D._0023_003DzmsLRsIpQV5sG().ToByteArray();
	}

	private protected override void _0023_003Dz6iZ1ZQQ_003D()
	{
		_0023_003Dzjgaq1UhfISUG(new DesignDocument());
	}

	public void LoadDocument(DesignDocument designDocument)
	{
		_0023_003Dzjgaq1UhfISUG(designDocument);
	}

	public DesignDocument UnloadDocument()
	{
		DesignDocument document = Document;
		_0023_003Dz6iZ1ZQQ_003D();
		return document;
	}

	private bool ShouldSerializeViewportsGap()
	{
		return ViewportsGap != 4;
	}

	private void ResetViewportsGap()
	{
		ViewportsGap = 4;
	}

	private bool ShouldSerializeWireframe()
	{
		return _0023_003DzsliWYheSU0DTuUNAYg_003D_003D._0023_003Dz4XAvJ5aCRLKs(Workspace._0023_003DzE86ntJk_bvntbeCPgA_003D_003D());
	}

	internal void ResetWireframe()
	{
		Wireframe = Workspace._0023_003DzE86ntJk_bvntbeCPgA_003D_003D();
		_0023_003Dz3tGL3rg_003D();
	}

	private bool ShouldSerializeShaded()
	{
		return _0023_003DzEfebv86OlSaQUw9POQ_003D_003D._0023_003Dz4XAvJ5aCRLKs(Workspace._0023_003DzSWtY5yxqfuBh8s2w07KB3SI_003D());
	}

	internal void ResetShaded()
	{
		Shaded = Workspace._0023_003DzSWtY5yxqfuBh8s2w07KB3SI_003D();
		_0023_003Dz3tGL3rg_003D();
	}

	private bool ShouldSerializeFlat()
	{
		return _0023_003Dzl8PjArmAqC_m._0023_003Dz4XAvJ5aCRLKs(Workspace._0023_003DzNmcCUKQZrt_0024ZBKfmbQ_003D_003D());
	}

	internal void ResetFlat()
	{
		Flat = Workspace._0023_003DzNmcCUKQZrt_0024ZBKfmbQ_003D_003D();
		_0023_003Dz3tGL3rg_003D();
	}

	private bool ShouldSerializeRendered()
	{
		return Rendered._0023_003Dz4XAvJ5aCRLKs(Workspace._0023_003DztuL3fSvrLHESbtlEgQ_003D_003D());
	}

	internal void ResetRendered()
	{
		Rendered = Workspace._0023_003DztuL3fSvrLHESbtlEgQ_003D_003D();
		_0023_003Dz3tGL3rg_003D();
	}

	private bool ShouldSerializeHiddenLines()
	{
		return _0023_003Dzddm_0024rF6S_0024y27._0023_003Dz4XAvJ5aCRLKs(Workspace._0023_003Dz6pySpQ7YNYytZ7KDm_0024lng_s_003D());
	}

	internal void ResetHiddenLines()
	{
		_0023_003Dzddm_0024rF6S_0024y27 = Workspace._0023_003Dz6pySpQ7YNYytZ7KDm_0024lng_s_003D();
		CompileUserInterfaceElements();
		_0023_003Dz3tGL3rg_003D();
	}

	private bool ShouldSerializeBoundingBox()
	{
		return _0023_003Dz6CMmzY6fHGlL._0023_003Dz4XAvJ5aCRLKs(Workspace._0023_003DzusLvEi5hoe9_0024());
	}

	internal void ResetBoundingBox()
	{
		_0023_003Dz6CMmzY6fHGlL = Workspace._0023_003DzusLvEi5hoe9_0024();
		_0023_003Dz6CMmzY6fHGlL.ParentWorkspace = this;
	}

	private bool ShouldSerializeMinimumFramerate()
	{
		return MinimumFramerate != Workspace._0023_003Dzg5Xj0dn9LsZAo_0024aLAJV5nOo_003D();
	}

	internal void ResetMinimumFramerate()
	{
		MinimumFramerate = Workspace._0023_003Dzg5Xj0dn9LsZAo_0024aLAJV5nOo_003D();
	}

	private bool ShouldSerializeMinimumScreenSize()
	{
		return MinimumScreenSize != (double)Workspace._0023_003Dzzyw4qcFvt7djMFj7Aw_003D_003D();
	}

	internal void ResetMinimumScreenSize()
	{
		MinimumScreenSize = Workspace._0023_003Dzzyw4qcFvt7djMFj7Aw_003D_003D();
	}

	public viewportLayoutType GetDefaultLayoutMode()
	{
		return _0023_003DzK9iHR98l0rNuEjAV4A_003D_003D();
	}

	private bool ShouldSerializeLayoutMode()
	{
		return LayoutMode != GetDefaultLayoutMode();
	}

	internal void ResetLayoutMode()
	{
		LayoutMode = GetDefaultLayoutMode();
	}

	private bool ShouldSerializeLight1()
	{
		return _0023_003DzMuApP021PUyU[0].ShouldSerialize(Workspace._0023_003Dz7NpJnabG16hc());
	}

	internal void ResetLight1()
	{
		_0023_003DzMuApP021PUyU[0] = Workspace._0023_003Dz7NpJnabG16hc();
		UpdateDesignModeScene();
		_0023_003Dz3tGL3rg_003D();
	}

	private bool ShouldSerializeLight2()
	{
		return _0023_003DzMuApP021PUyU[1].ShouldSerialize(Workspace._0023_003Dz__OrNlvkiVf_0024());
	}

	internal void ResetLight2()
	{
		_0023_003DzMuApP021PUyU[1] = Workspace._0023_003Dz__OrNlvkiVf_0024();
		_0023_003Dz3tGL3rg_003D();
	}

	private bool ShouldSerializeLight3()
	{
		return _0023_003DzMuApP021PUyU[2].ShouldSerialize(Workspace._0023_003DzeVWRUBuT_00244su());
	}

	internal void ResetLight3()
	{
		_0023_003DzMuApP021PUyU[2] = Workspace._0023_003DzeVWRUBuT_00244su();
		_0023_003Dz3tGL3rg_003D();
	}

	private bool ShouldSerializeLight4()
	{
		return _0023_003DzMuApP021PUyU[3].ShouldSerialize(Workspace._0023_003DzGAvKLzvtgdSE());
	}

	internal void ResetLight4()
	{
		_0023_003DzMuApP021PUyU[3] = Workspace._0023_003DzGAvKLzvtgdSE();
		_0023_003Dz3tGL3rg_003D();
	}

	private bool ShouldSerializeLight5()
	{
		return _0023_003DzMuApP021PUyU[4].ShouldSerialize(Workspace._0023_003DzvlMrltGUGwqD());
	}

	internal void ResetLight5()
	{
		_0023_003DzMuApP021PUyU[4] = Workspace._0023_003DzvlMrltGUGwqD();
		_0023_003Dz3tGL3rg_003D();
	}

	private bool ShouldSerializeLight6()
	{
		return _0023_003DzMuApP021PUyU[5].ShouldSerialize(Workspace._0023_003DzxLBZtGeVsnzR());
	}

	internal void ResetLight6()
	{
		_0023_003DzMuApP021PUyU[5] = Workspace._0023_003DzxLBZtGeVsnzR();
		_0023_003Dz3tGL3rg_003D();
	}

	private bool ShouldSerializeLight7()
	{
		return _0023_003DzMuApP021PUyU[6].ShouldSerialize(Workspace._0023_003Dzy9a2gvNR_0024L5N());
	}

	internal void ResetLight7()
	{
		_0023_003DzMuApP021PUyU[6] = Workspace._0023_003Dzy9a2gvNR_0024L5N();
		_0023_003Dz3tGL3rg_003D();
	}

	private bool ShouldSerializeLight8()
	{
		return _0023_003DzMuApP021PUyU[7].ShouldSerialize(Workspace._0023_003DzzcdYAd1MAULe());
	}

	internal void ResetLight8()
	{
		_0023_003DzMuApP021PUyU[7] = Workspace._0023_003DzzcdYAd1MAULe();
		_0023_003Dz3tGL3rg_003D();
	}

	private bool ShouldSerializeAmbientLight()
	{
		return _0023_003DzXVJ6CvJJYmrqf3ztQQ_003D_003D != Color.FromArgb(50, 50, 50);
	}

	internal void ResetAmbientLight()
	{
		_0023_003DzXVJ6CvJJYmrqf3ztQQ_003D_003D = Color.FromArgb(50, 50, 50);
		_0023_003Dz3tGL3rg_003D();
	}

	private bool ShouldSerializeDefaultMaterial()
	{
		Material defaultMaterialShaded = ControlData.DefaultMaterialShaded;
		if (!(DefaultMaterial.Ambient != defaultMaterialShaded.Ambient) && !(DefaultMaterial.Specular != defaultMaterialShaded.Specular))
		{
			return DefaultMaterial.Shininess != defaultMaterialShaded.Shininess;
		}
		return true;
	}

	internal void ResetDefaultMaterial()
	{
		_0023_003DzjC4hA2I_003D.ResetDefaultMaterial();
		_0023_003Dz3tGL3rg_003D();
	}

	private bool ShouldSerializeGroundPlaneDistance()
	{
		return GroundPlaneDistance != Workspace._0023_003Dz5FN_jliv6I7mvmLmSUzqQ98Ojt_00240();
	}

	internal void ResetGroundPlaneDistance()
	{
		GroundPlaneDistance = Workspace._0023_003Dz5FN_jliv6I7mvmLmSUzqQ98Ojt_00240();
	}

	private bool ShouldSerializePlanarShadowOpacity()
	{
		return PlanarShadowOpacity != Workspace._0023_003Dz_0024qFq48Dx8t9MkqcygP0YSu4_003D();
	}

	internal void ResetPlanarShadowOpacity()
	{
		PlanarShadowOpacity = Workspace._0023_003Dz_0024qFq48Dx8t9MkqcygP0YSu4_003D();
	}

	private bool ShouldSerializeClippingPlane1()
	{
		if (!_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D[0].Active && !(_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D[0].Normal != Vector3D.AxisZ))
		{
			return _0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D[0].Distance != 0.0;
		}
		return true;
	}

	internal void ResetClippingPlane1()
	{
		ClippingPlane1 = new ClippingPlane(Vector3D.AxisZ, 0.0, active: false);
	}

	private bool ShouldSerializeClippingPlane2()
	{
		if (!_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D[1].Active && !(_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D[1].Normal != Vector3D.AxisZ))
		{
			return _0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D[1].Distance != 0.0;
		}
		return true;
	}

	internal void ResetClippingPlane2()
	{
		ClippingPlane2 = new ClippingPlane(Vector3D.AxisZ, 0.0, active: false);
	}

	private bool ShouldSerializeClippingPlane3()
	{
		if (!_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D[2].Active && !(_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D[2].Normal != Vector3D.AxisZ))
		{
			return _0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D[2].Distance != 0.0;
		}
		return true;
	}

	internal void ResetClippingPlane3()
	{
		ClippingPlane3 = new ClippingPlane(Vector3D.AxisZ, 0.0, active: false);
	}

	private bool ShouldSerializeClippingPlane4()
	{
		if (!_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D[3].Active && !(_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D[3].Normal != Vector3D.AxisZ))
		{
			return _0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D[3].Distance != 0.0;
		}
		return true;
	}

	internal void ResetClippingPlane4()
	{
		ClippingPlane4 = new ClippingPlane(Vector3D.AxisZ, 0.0, active: false);
	}

	private bool ShouldSerializeClippingPlane5()
	{
		if (!_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D[4].Active && !(_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D[4].Normal != Vector3D.AxisZ))
		{
			return _0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D[4].Distance != 0.0;
		}
		return true;
	}

	internal void ResetClippingPlane5()
	{
		ClippingPlane5 = new ClippingPlane(Vector3D.AxisZ, 0.0, active: false);
	}

	private bool ShouldSerializeClippingPlane6()
	{
		if (!_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D[5].Active && !(_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D[5].Normal != Vector3D.AxisZ))
		{
			return _0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D[5].Distance != 0.0;
		}
		return true;
	}

	internal void ResetClippingPlane6()
	{
		ClippingPlane6 = new ClippingPlane(Vector3D.AxisZ, 0.0, active: false);
	}

	internal bool ShouldSerializeObjectManipulator()
	{
		return ObjectManipulator._0023_003Dz4XAvJ5aCRLKs();
	}

	internal void ResetObjectManipulator()
	{
		ObjectManipulator = new ObjectManipulator();
	}

	private bool ShouldSerializeViewportBorder()
	{
		return ViewportBorder._0023_003Dz4XAvJ5aCRLKs();
	}

	internal void ResetViewportBorder()
	{
		ViewportBorder = new BorderSettings();
		_0023_003Dz3tGL3rg_003D();
	}

	private bool ShouldSerializeDefaultColor()
	{
		return DefaultColor.ToArgb() != Color.Black.ToArgb();
	}

	internal void ResetDefaultColor()
	{
		DefaultColor = Color.Black;
	}

	private bool ShouldSerializeBackface()
	{
		if (_0023_003DzoF4FlAGfV8hKCuDCVA_003D_003D.ColorMethod == backfaceColorMethodType.EntityColor)
		{
			return _0023_003DzoF4FlAGfV8hKCuDCVA_003D_003D.Color != Color.LightGreen;
		}
		return true;
	}

	internal void ResetBackface()
	{
		_0023_003DzoF4FlAGfV8hKCuDCVA_003D_003D = new BackfaceSettings(backfaceColorMethodType.EntityColor, Color.LightGreen);
		_0023_003Dz3tGL3rg_003D();
	}

	private bool ShouldSerializeKeepSceneUpright()
	{
		return !KeepSceneUpright;
	}

	internal void ResetKeepSceneUpright()
	{
		KeepSceneUpright = true;
	}

	private bool ShouldSerializeOrientationMode()
	{
		return _0023_003DzLpjRly40lvq1 != orientationType.UpAxisZ;
	}

	internal void ResetOrientationMode()
	{
		_0023_003DzLpjRly40lvq1 = orientationType.UpAxisZ;
		_0023_003Dz8ok_dRe4bjRDcVb_0024afNnmr8_003D = true;
		_0023_003Dz3tGL3rg_003D();
	}

	private bool ShouldSerializeAssemblySelectionMode()
	{
		return AssemblySelectionMode != assemblySelectionType.Branch;
	}

	private void ResetAssemblySelectionMode()
	{
		AssemblySelectionMode = assemblySelectionType.Branch;
	}

	private bool ShouldSerializeSelectionFilterMode()
	{
		return SelectionFilterMode != selectionFilterType.Entity;
	}

	private void ResetSelectionFilterMode()
	{
		SelectionFilterMode = selectionFilterType.Entity;
	}

	public void PrintPreview(Size printPreviewDlgClientSize, bool extents = false)
	{
		_0023_003Dzws3VyglDjXPb(printPreviewDlgClientSize, _0023_003Dz8Sjn85TIry34: true, extents);
	}

	public void Print(bool extents = false)
	{
		_0023_003Dzws3VyglDjXPb(default(Size), _0023_003Dz8Sjn85TIry34: false, extents);
	}

	public virtual void SaveFile(string filePath, Drawing drawing = null, contentType contentType = contentType.GeometryAndTessellation, FileSerializer fileSerializer = null)
	{
		Document.SaveFile(filePath, drawing?.Document, contentType, fileSerializer);
	}

	public virtual async Task SaveFileAsync(string filePath, Drawing drawing = null, contentType contentType = contentType.GeometryAndTessellation, FileSerializer fileSerializer = null)
	{
		await Document.SaveFileAsync(filePath, drawing?.Document, contentType, fileSerializer);
	}

	public virtual void SaveFile(Stream stream, Drawing drawing = null, contentType contentType = contentType.GeometryAndTessellation, FileSerializer fileSerializer = null)
	{
		Document.SaveFile(stream, drawing?.Document, contentType, fileSerializer);
	}

	public virtual async Task SaveFileAsync(Stream stream, Drawing drawing = null, contentType contentType = contentType.GeometryAndTessellation, FileSerializer fileSerializer = null)
	{
		await Document.SaveFileAsync(stream, drawing?.Document, contentType, fileSerializer);
	}

	public virtual void OpenFile(string filePath, Drawing drawing = null, FileSerializer fileSerializer = null)
	{
		Document.OpenFile(filePath, drawing?.Document, fileSerializer);
	}

	public virtual async Task OpenFileAsync(string filePath, Drawing drawing = null, FileSerializer fileSerializer = null)
	{
		await Document.OpenFileAsync(filePath, drawing?.Document, fileSerializer);
	}

	public virtual void OpenFile(Stream stream, Drawing drawing = null, FileSerializer fileSerializer = null)
	{
		Document.OpenFile(stream, drawing?.Document, fileSerializer);
	}

	public virtual async Task OpenFileAsync(Stream stream, Drawing drawing = null, FileSerializer fileSerializer = null)
	{
		await Document.OpenFileAsync(stream, drawing?.Document, fileSerializer);
	}

	public Table CreateBOMTable(EntityList entites, BlockKeyedCollection blocks, string itemNumberText, string partNumberText, string descriptionText, string quantityText, bool partsOnly = true, Table.flowDirection flowDirection = Table.flowDirection.Down, int maxLevel = int.MaxValue)
	{
		return Utility.CreateBOMTable(entites, blocks, itemNumberText, partNumberText, descriptionText, quantityText, partsOnly, flowDirection, maxLevel);
	}

	public DataTable CreateBillOfMaterials(EntityList entities, BlockKeyedCollection blocks, bool partsOnly, int maxLevel = int.MaxValue)
	{
		return Utility.CreateBillOfMaterials(entities, blocks, partsOnly);
	}

	internal override void _0023_003DzEqBQ2waUAbQ7(DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024, Entity _0023_003DztJCl_0024mM_003D, ref bool _0023_003DzAYcbN5Y_003D)
	{
		bool flag = _0023_003DzlT_tPDs_003D(_0023_003DzCBM7XJK4_5H_0024.DrawParams.ParentSelected, _0023_003DzCBM7XJK4_5H_0024.DrawParams, _0023_003DztJCl_0024mM_003D);
		_0023_003DzCBM7XJK4_5H_0024.DrawParams.Selected = (_0023_003DzAYcbN5Y_003D = _0023_003DzJIOQOs_0024rX_pgqV_uZQ_003D_003D(flag, _0023_003DzCBM7XJK4_5H_0024.DrawParams));
		_0023_003DzCBM7XJK4_5H_0024.selectionFound |= flag;
	}

	public override void Clear()
	{
		base.Clear();
		CurrentSketch?.Exit();
	}

	private protected override void _0023_003DznL1WlsQ9pGcL(bool _0023_003DzWrfLNCo_003D, bool _0023_003DzBQC8k3F0wJN4)
	{
		if (CurrentSketch != null)
		{
			CurrentSketch.ResetCameraForSketchEditing(new SketchEntity.CameraSettings(_0023_003DzBQC8k3F0wJN4, _0023_003DzWrfLNCo_003D ? SketchEntity.zoomFitType.Block : SketchEntity.zoomFitType.None));
		}
		else
		{
			base._0023_003DznL1WlsQ9pGcL(_0023_003DzWrfLNCo_003D, _0023_003DzBQC8k3F0wJN4);
		}
	}

	public Solidifier[] GetSolidifiers(IList<Surface> surfaces, double tol = 0.0)
	{
		return Document.GetSolidifiers(surfaces, tol);
	}

	public Solidifier[] GetSolidifiers(double tol = 0.0)
	{
		return Document.GetSolidifiers(tol);
	}

	public Solidifier[] GetSolidifiers(Block current, BlockKeyedCollection blocks, double tol = 0.0)
	{
		return Document.GetSolidifiers(current, blocks, tol);
	}

	private Size _0023_003DzWgU25u_0024Glo22(Viewport _0023_003DzYzWi5Yw_003D, Size _0023_003Dz0ERMHbg_003D)
	{
		int num = base.Size.Width - _0023_003DzYzWi5Yw_003D.Location.X - _0023_003Dz0ERMHbg_003D.Width;
		if (num != 0)
		{
			return new Size(_0023_003Dz0ERMHbg_003D.Width + num, _0023_003Dz0ERMHbg_003D.Height);
		}
		return _0023_003Dz0ERMHbg_003D;
	}

	private Size _0023_003Dz2fULvgfSeaWJ(Viewport _0023_003DzYzWi5Yw_003D, Size _0023_003Dz0ERMHbg_003D)
	{
		int num = base.Size.Height - _0023_003DzYzWi5Yw_003D.Location.Y - _0023_003Dz0ERMHbg_003D.Height;
		if (num != 0)
		{
			return new Size(_0023_003Dz0ERMHbg_003D.Width, _0023_003Dz0ERMHbg_003D.Height + num);
		}
		return _0023_003Dz0ERMHbg_003D;
	}

	private Size _0023_003Dz8jo_1ggX1xGU(Viewport _0023_003DzYzWi5Yw_003D, Size _0023_003Dz0ERMHbg_003D)
	{
		Size _0023_003Dz0ERMHbg_003D2 = _0023_003DzWgU25u_0024Glo22(_0023_003DzYzWi5Yw_003D, _0023_003Dz0ERMHbg_003D);
		return _0023_003Dz2fULvgfSeaWJ(_0023_003DzYzWi5Yw_003D, _0023_003Dz0ERMHbg_003D2);
	}

	internal override void _0023_003DzxMjXttTc5JNkWQh7J4z9LEwPvett()
	{
		UpdateViewportsSizeAndLocation();
	}

	public virtual void UpdateViewportsSizeAndLocation()
	{
		if (!_0023_003DzYBRkt7OvpTz_0024() || Math.Min(_0023_003Dz0P1LCYH__O4t(), _0023_003DzNwtRJ3cLTrAy()) <= 2)
		{
			return;
		}
		int num = (int)((double)base.Size.Width / 2.0 - (double)ViewportsGap / 2.0);
		int num2 = (int)((double)base.Size.Height / 2.0 - (double)ViewportsGap / 2.0);
		Size size;
		switch (LayoutMode)
		{
		case viewportLayoutType.SingleViewport:
			Viewports[0].Location = new System.Drawing.Point(0, 0);
			Viewports[0].Size = base.Size;
			break;
		case viewportLayoutType.TwoViewportsVertical:
			Viewports[0].Location = new System.Drawing.Point(0, 0);
			Viewports[1].Location = new System.Drawing.Point(num + ViewportsGap, 0);
			size = new Size(num, base.Size.Height);
			Viewports[0].Size = size;
			Viewports[1].Size = _0023_003DzWgU25u_0024Glo22(Viewports[1], size);
			break;
		case viewportLayoutType.TwoViewportsHorizontal:
			Viewports[0].Location = new System.Drawing.Point(0, 0);
			Viewports[1].Location = new System.Drawing.Point(0, num2 + ViewportsGap);
			size = new Size(base.Size.Width, num2);
			Viewports[0].Size = size;
			Viewports[1].Size = _0023_003Dz2fULvgfSeaWJ(Viewports[1], size);
			break;
		case viewportLayoutType.ThreeViewportsWithOneOnLeft:
			Viewports[0].Size = new Size(num, base.Size.Height);
			Viewports[0].Location = new System.Drawing.Point(0, 0);
			Viewports[1].Location = new System.Drawing.Point(num + ViewportsGap, 0);
			Viewports[2].Location = new System.Drawing.Point(num + ViewportsGap, num2 + ViewportsGap);
			size = new Size(num, num2);
			Viewports[1].Size = _0023_003DzWgU25u_0024Glo22(Viewports[1], size);
			Viewports[2].Size = _0023_003Dz2fULvgfSeaWJ(Viewports[2], Viewports[1].Size);
			break;
		case viewportLayoutType.ThreeViewportsWithOneOnTop:
			Viewports[0].Location = new System.Drawing.Point(0, 0);
			Viewports[1].Location = new System.Drawing.Point(0, num2 + ViewportsGap);
			Viewports[2].Location = new System.Drawing.Point(num + ViewportsGap, num2 + ViewportsGap);
			Viewports[0].Size = new Size(base.Size.Width, num2);
			size = new Size(num, num2);
			Viewports[1].Size = _0023_003Dz2fULvgfSeaWJ(Viewports[1], size);
			Viewports[2].Size = _0023_003DzWgU25u_0024Glo22(Viewports[2], Viewports[1].Size);
			break;
		case viewportLayoutType.ThreeViewportsWithOneOnRight:
			Viewports[0].Location = new System.Drawing.Point(0, 0);
			Viewports[1].Location = new System.Drawing.Point(num + ViewportsGap, 0);
			Viewports[2].Location = new System.Drawing.Point(0, num2 + ViewportsGap);
			Viewports[0].Size = new Size(num, num2);
			Viewports[1].Size = _0023_003Dz8jo_1ggX1xGU(Viewports[1], new Size(num, base.Size.Height));
			Viewports[2].Size = _0023_003Dz2fULvgfSeaWJ(Viewports[2], new Size(num, num2));
			break;
		case viewportLayoutType.ThreeViewportsWithOneOnBottom:
			Viewports[0].Location = new System.Drawing.Point(0, 0);
			Viewports[1].Location = new System.Drawing.Point(num + ViewportsGap, 0);
			Viewports[2].Location = new System.Drawing.Point(0, num2 + ViewportsGap);
			size = new Size(num, num2);
			Viewports[0].Size = size;
			Viewports[1].Size = _0023_003DzWgU25u_0024Glo22(Viewports[1], size);
			Viewports[2].Size = _0023_003Dz2fULvgfSeaWJ(Viewports[2], new Size(base.Size.Width, num2));
			break;
		case viewportLayoutType.FourViewports:
			Viewports[0].Location = new System.Drawing.Point(0, 0);
			Viewports[1].Location = new System.Drawing.Point(num + ViewportsGap, 0);
			Viewports[2].Location = new System.Drawing.Point(0, num2 + ViewportsGap);
			Viewports[3].Location = new System.Drawing.Point(num + ViewportsGap, num2 + ViewportsGap);
			size = new Size(num, num2);
			Viewports[0].Size = size;
			Viewports[1].Size = _0023_003DzWgU25u_0024Glo22(Viewports[1], size);
			Viewports[3].Size = _0023_003Dz2fULvgfSeaWJ(Viewports[3], Viewports[1].Size);
			Viewports[2].Size = new Size(Viewports[0].Size.Width, Viewports[3].Size.Height);
			break;
		case viewportLayoutType.Stacked:
		{
			int num3 = (int)((double)base.Size.Height / (double)Viewports.Count - (double)ViewportsGap / 2.0);
			int num4 = 0;
			size = new Size(base.Size.Width, num3);
			int count = Viewports.Count;
			for (int i = 0; i < count; i++)
			{
				Viewport viewport = Viewports[i];
				viewport.Location = new System.Drawing.Point(0, num4);
				if (i == count - 1)
				{
					viewport.Size = _0023_003Dz2fULvgfSeaWJ(viewport, size);
				}
				else
				{
					viewport.Size = size;
				}
				num4 += num3 + ViewportsGap;
			}
			break;
		}
		}
		_0023_003DzOKl0QUWVZez4();
	}

	private void _0023_003Dz37WqNaNEV5HZ(Text _0023_003DzgWGS4uo_003D, double _0023_003DzA5LZPo2Grwz4TIK4uQ_003D_003D, out ICurve[] _0023_003Dzf0NImE_xvj8u, out ICurve[][] _0023_003DzyGaR_8tOPKPu)
	{
		_0023_003DzmNZD0Zs_003D.MakeCurrent();
		Text text = (Text)_0023_003DzgWGS4uo_003D.Clone();
		RegenParams data = new RegenParams(_0023_003DzA5LZPo2Grwz4TIK4uQ_003D_003D, this);
		if (text.RegenMode != regenType.NotNeeded)
		{
			text.Regen(data);
		}
		text.ConvertToInternal(_0023_003DzA5LZPo2Grwz4TIK4uQ_003D_003D, null, _0023_003DztGfy8BAzQdGaU6HShA_003D_003D: true, _0023_003Dzh6bB8iUYNCW4: false, this, out _0023_003Dzf0NImE_xvj8u, out _0023_003DzyGaR_8tOPKPu);
		text.Dispose();
	}

	public Solid[] ExtrudeText(Text text, double deviation, double amount, bool endCaps)
	{
		return ExtrudeText(text, deviation, amount * text.Plane.AxisZ, endCaps);
	}

	public Solid[] ExtrudeText(Text text, double deviation, Vector3D amount, bool endCaps)
	{
		_0023_003Dz37WqNaNEV5HZ(text, deviation, out var _0023_003Dzf0NImE_xvj8u, out var _0023_003DzyGaR_8tOPKPu);
		List<Solid> list = new List<Solid>();
		for (int i = 0; i < _0023_003Dzf0NImE_xvj8u.Length; i++)
		{
			if (endCaps)
			{
				List<ICurve> list2 = new List<ICurve>();
				list2.Add(_0023_003Dzf0NImE_xvj8u[i]);
				list2.AddRange(_0023_003DzyGaR_8tOPKPu[i]);
				devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region(list2, text.Plane, sortAndOrient: false);
				list.Add(region.ExtrudeAsSolid(amount, deviation));
			}
			else
			{
				list.Add(_0023_003Dzf0NImE_xvj8u[i].ExtrudeAsSolid(amount, deviation));
				for (int j = 0; j < _0023_003DzyGaR_8tOPKPu[i].Length; j++)
				{
					list.Add(_0023_003DzyGaR_8tOPKPu[i][j].ExtrudeAsSolid(amount, deviation));
				}
			}
		}
		return list.ToArray();
	}

	public Mesh[] ExtrudeText(Text text, double deviation, double amount, bool endCaps, Mesh.natureType meshNature)
	{
		return ExtrudeText(text, deviation, amount * text.Plane.AxisZ, endCaps, meshNature);
	}

	public Mesh[] ExtrudeText(Text text, double deviation, Vector3D amount, bool endCaps, Mesh.natureType meshNature)
	{
		_0023_003Dz37WqNaNEV5HZ(text, deviation, out var _0023_003Dzf0NImE_xvj8u, out var _0023_003DzyGaR_8tOPKPu);
		List<Mesh> list = new List<Mesh>();
		for (int i = 0; i < _0023_003Dzf0NImE_xvj8u.Length; i++)
		{
			if (endCaps)
			{
				List<ICurve> list2 = new List<ICurve>();
				list2.Add(_0023_003Dzf0NImE_xvj8u[i]);
				list2.AddRange(_0023_003DzyGaR_8tOPKPu[i]);
				devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region(list2, text.Plane, sortAndOrient: false);
				list.Add(region.ExtrudeAsMesh(amount, deviation, Math.PI / 6.0, meshNature));
			}
			else
			{
				list.Add(_0023_003Dzf0NImE_xvj8u[i].ExtrudeAsMesh(amount, deviation, meshNature));
				for (int j = 0; j < _0023_003DzyGaR_8tOPKPu[i].Length; j++)
				{
					list.Add(_0023_003DzyGaR_8tOPKPu[i][j].ExtrudeAsMesh(amount, deviation, meshNature));
				}
			}
		}
		return list.ToArray();
	}

	internal override void _0023_003Dzk_0024_0024VvG_00245PP4u(int _0023_003DzDI8Y9ks_003D, int _0023_003DzJx6crCU_003D)
	{
		RotateCamera(_0023_003DzDI8Y9ks_003D, _0023_003DzJx6crCU_003D);
	}

	internal override void _0023_003Dzk_0024_0024VvG_00245PP4u(int _0023_003DzDI8Y9ks_003D, int _0023_003DzJx6crCU_003D, bool _0023_003DzBQC8k3F0wJN4)
	{
		RotateCamera(_0023_003DzDI8Y9ks_003D, _0023_003DzJx6crCU_003D, _0023_003DzBQC8k3F0wJN4);
	}

	internal override void _0023_003Dzk_0024_0024VvG_00245PP4u(System.Drawing.Point _0023_003DzFrKrmnmn1LqQ, System.Drawing.Point _0023_003Dzx34Z7rf2lLJX)
	{
		RotateCamera(_0023_003DzFrKrmnmn1LqQ, _0023_003Dzx34Z7rf2lLJX);
	}

	internal override void _0023_003Dzk_0024_0024VvG_00245PP4u(Vector3D _0023_003DzfZZZs54_003D, double _0023_003DzgTFdQ0BoTJUxeE6Vz8CMzjg_003D, bool _0023_003DzaDYRbvgbaa7a)
	{
		RotateCamera(_0023_003DzfZZZs54_003D, _0023_003DzgTFdQ0BoTJUxeE6Vz8CMzjg_003D, _0023_003DzaDYRbvgbaa7a);
	}

	internal override void _0023_003Dzk_0024_0024VvG_00245PP4u(Vector3D _0023_003DzfZZZs54_003D, double _0023_003DzgTFdQ0BoTJUxeE6Vz8CMzjg_003D, bool _0023_003DzaDYRbvgbaa7a, bool _0023_003DzBQC8k3F0wJN4)
	{
		RotateCamera(_0023_003DzfZZZs54_003D, _0023_003DzgTFdQ0BoTJUxeE6Vz8CMzjg_003D, _0023_003DzaDYRbvgbaa7a, _0023_003DzBQC8k3F0wJN4);
	}

	internal override void _0023_003Dzk_0024_0024VvG_00245PP4u(Vector3D _0023_003Dzs8G0wXc_003D, Vector3D _0023_003DzFcXCpKE_003D)
	{
		RotateCamera(_0023_003Dzs8G0wXc_003D, _0023_003DzFcXCpKE_003D);
	}

	internal override void _0023_003Dzk_0024_0024VvG_00245PP4u(Vector3D _0023_003Dzs8G0wXc_003D, Vector3D _0023_003DzFcXCpKE_003D, bool _0023_003DzBQC8k3F0wJN4)
	{
		RotateCamera(_0023_003Dzs8G0wXc_003D, _0023_003DzFcXCpKE_003D, _0023_003DzBQC8k3F0wJN4);
	}

	public virtual void RotateCamera(int dx, int dy)
	{
		ActiveViewport.RotateCamera(dx, dy);
	}

	public virtual void RotateCamera(int dx, int dy, bool animate)
	{
		ActiveViewport.RotateCamera(dx, dy, animate);
	}

	public virtual void RotateCamera(System.Drawing.Point mousePos1, System.Drawing.Point mousePos2)
	{
		ActiveViewport.RotateCamera(mousePos1, mousePos2);
	}

	public virtual void RotateCamera(Vector3D last, Vector3D current)
	{
		RotateCamera(last, current, base.AnimateCamera);
	}

	public virtual void RotateCamera(Vector3D last, Vector3D current, bool animate)
	{
		ActiveViewport.RotateCamera(last, current, animate);
	}

	public virtual void RotateCamera(Vector3D axis, double rotAngleInDegrees, bool trackBall)
	{
		RotateCamera(axis, rotAngleInDegrees, trackBall, base.AnimateCamera);
	}

	public virtual void RotateCamera(Vector3D axis, double rotAngleInDegrees, bool trackBall, bool animate)
	{
		ActiveViewport.RotateCamera(axis, rotAngleInDegrees, trackBall, animate);
	}

	public virtual void OrientCamera(Point3D location, Point3D target)
	{
		ActiveViewport.OrientCamera(location, target);
	}

	public void RotateLeft(double degrees)
	{
		_0023_003DzhFM5QuysOc2a(degrees, _0023_003DzerPaB6icXZKY: true);
	}

	public void RotateRight(double degrees)
	{
		_0023_003DzqXK12IwuBesy(degrees, _0023_003DzerPaB6icXZKY: true);
	}

	public void RotateUp(double degrees)
	{
		_0023_003Dz_mIv_0024Fqqnit2(degrees, _0023_003DzerPaB6icXZKY: true);
	}

	public void RotateDown(double degrees)
	{
		_0023_003DzDnP_iy6mfpH5(degrees, _0023_003DzerPaB6icXZKY: true);
	}

	public void MoveToPlane(ICollection<Entity> entList, Point3D origin, Point3D xAxis, Point3D yAxis)
	{
		Plane plane = new Plane(origin, xAxis, yAxis);
		MoveToPlane(entList, plane);
	}

	public void MoveToPlane(ICollection<Entity> entList, Plane plane)
	{
		Transformation xform = new Transformation(plane.Origin, plane.AxisX, plane.AxisY, plane.AxisZ);
		foreach (Entity ent in entList)
		{
			ent.TransformBy(xform);
		}
	}

	public void MoveToPlane(IList<Point3D> points, Plane plane)
	{
		Transformation transformation = new Transformation(plane.Origin, plane.AxisX, plane.AxisY, plane.AxisZ);
		for (int i = 0; i < points.Count; i++)
		{
			points[i] = transformation * points[i];
		}
	}

	public int FindClosestTriangle(IFace entity, System.Drawing.Point mousePos, out Point3D hitPoint, out int hitTriangleIndex)
	{
		return _0023_003Dz3WmPj0ZtGb9Pf2Zfuw_003D_003D(entity, mousePos, out hitPoint, out hitTriangleIndex);
	}

	public int FindClosestTriangle(SelectedItem item, System.Drawing.Point mousePos, out Point3D hitPoint, out int hitTriangleIndex)
	{
		return _0023_003Dz3WmPj0ZtGb9Pf2Zfuw_003D_003D(item, mousePos, out hitPoint, out hitTriangleIndex);
	}

	public IList<HitTriangle> FindClosestTriangle(IFace entity, System.Drawing.Point mousePos)
	{
		return _0023_003Dz3WmPj0ZtGb9Pf2Zfuw_003D_003D(entity, mousePos);
	}

	public IList<HitTriangle> FindClosestTriangle(SelectedItem item, System.Drawing.Point mousePos)
	{
		return _0023_003Dz3WmPj0ZtGb9Pf2Zfuw_003D_003D(item, mousePos);
	}

	public void StartAnimation(int? interval = null, int? stopAfter = null)
	{
		_0023_003DzbMij5IjKskzE(interval, stopAfter);
	}

	public virtual void StopAnimation()
	{
		_0023_003DzqYQgL_pXJcCP(_0023_003DzNir3dPKLkVT3: false);
	}

	[Obsolete("Use SetCurrentStack() or IsolateInstances() instead")]
	public void SetSelectionScope(Stack<BlockReference> parents)
	{
		_0023_003Dz2_dex5RlnxWY(parents);
	}

	public Plane GetPlanarReflectionsPlane()
	{
		return _0023_003DzrnMI_SiQDx8_0024QFSmZA3zGE6q_QjC4hO9xRf6Hz8_003D();
	}

	public static void SetColorShaded(RenderContextBase context, entityNatureType nature, Color color, bool selected, BackfaceSettings backface)
	{
		context.SetColorShadedInternal(nature, color, selected, backface);
	}

	public static void SetColorRendered(RenderContextBase context, entityNatureType nature, Material material, bool selected, RenderParams data)
	{
		context.SetColorRenderedInternal(nature, material, selected, data);
	}
}
