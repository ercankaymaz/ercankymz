using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using devDept.Geometry;

namespace devDept.Eyeshot;

public class ScreenPolygonParams : FrustumParams
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Size _0023_003DzynP54vEQB9i1rTyH7g_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IList<Point2D> _0023_003Dz0e_0024CnFuhEypNQ3NV51GUFwo_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IList<Segment2D> _0023_003Dz_waZT1NWeCI_y0eXErWHq6E_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Point2D _0023_003DzQTJw_0024UKah960TMPUhA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Point2D _0023_003DzfOZD3gfvIrCMc2EnhQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int[] _0023_003DzqzgLb0X4VKkkNYzJXQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double[] _0023_003Dzl3iF7aS_Xkoh3HUP77VEuvI_003D;

	public Size ViewportSize
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzynP54vEQB9i1rTyH7g_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzynP54vEQB9i1rTyH7g_003D_003D = value;
		}
	}

	public IList<Point2D> ScreenPolygon
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz0e_0024CnFuhEypNQ3NV51GUFwo_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz0e_0024CnFuhEypNQ3NV51GUFwo_003D = value;
		}
	}

	public IList<Segment2D> ScreenSegments
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz_waZT1NWeCI_y0eXErWHq6E_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz_waZT1NWeCI_y0eXErWHq6E_003D = value;
		}
	}

	public Point2D Min
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzQTJw_0024UKah960TMPUhA_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzQTJw_0024UKah960TMPUhA_003D_003D = value;
		}
	}

	public Point2D Max
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzfOZD3gfvIrCMc2EnhQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzfOZD3gfvIrCMc2EnhQ_003D_003D = value;
		}
	}

	public int[] ViewFrame
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzqzgLb0X4VKkkNYzJXQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzqzgLb0X4VKkkNYzJXQ_003D_003D = value;
		}
	}

	public double[] ModelViewProj
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzl3iF7aS_Xkoh3HUP77VEuvI_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzl3iF7aS_Xkoh3HUP77VEuvI_003D = value;
		}
	}

	public ScreenPolygonParams(int[] viewFrame, double[] modelViewProj, IList<Point2D> screenPolygon, IList<Segment2D> screenSegments, Point2D min, Point2D max, displayType displayMode, float screenToWorld, IWorkspace workspace, Transformation transform)
		: base(null, null, displayMode, screenToWorld, null, workspace.Document.MaxPatternRepetitions, workspace, transform)
	{
		ScreenPolygon = screenPolygon;
		ScreenSegments = screenSegments;
		Min = min;
		Max = max;
		ViewFrame = viewFrame;
		ModelViewProj = modelViewProj;
	}
}
