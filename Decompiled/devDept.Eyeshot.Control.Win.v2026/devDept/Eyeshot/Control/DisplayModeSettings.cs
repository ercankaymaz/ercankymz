using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using devDept.Eyeshot.Control.Converters;
using devDept.Graphics;

namespace devDept.Eyeshot.Control;

[TypeConverter(typeof(DisplayModeSettingsConverter))]
public class DisplayModeSettings : IDisplayModeSettings
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzDDTqn6lBDa_h;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003DzUS40q9lzVpgV;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float _0023_003DzPKXENMxRB78h;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal shadowType _0023_003DzLipASLNgxA13 = _0023_003DzntPtVW3D_Yst();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private silhouettesDrawingType _0023_003DzYFTZAFQUwKS7OozlFRH8usLozhxIQxVbjw_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float _0023_003DzVkLUUCxiV5t8PRn_0024lHMOh_002436kGpEMN976w_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private edgeColorMethodType _0023_003DzijMpVqnwAHCU;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzUIKmH6yk_u6AB2x_qDX0cUlhPvD9;

	protected static bool DefaultShowEdges => true;

	protected static Color DefaultEdgeColor => Color.Black;

	protected static float DefaultEdgeThickness => 2f;

	protected static float DefaultSilhouetteThickness => 2f;

	protected static silhouettesDrawingType DefaultSilhouettesDrawingMode => silhouettesDrawingType.Never;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Entity edges visibility status.")]
	public bool ShowEdges
	{
		get
		{
			return _0023_003DzDDTqn6lBDa_h;
		}
		set
		{
			_0023_003DzDDTqn6lBDa_h = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Entity edges color, applies only to single color style mode.")]
	public Color EdgeColor
	{
		get
		{
			return _0023_003DzUS40q9lzVpgV;
		}
		set
		{
			_0023_003DzUS40q9lzVpgV = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Entity edges thickness.")]
	public float EdgeThickness
	{
		get
		{
			return _0023_003DzPKXENMxRB78h;
		}
		set
		{
			if (value <= 0f)
			{
				throw new ArgumentException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589295));
			}
			_0023_003DzPKXENMxRB78h = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Silhouettes drawing mode.")]
	public silhouettesDrawingType SilhouettesDrawingMode
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzYFTZAFQUwKS7OozlFRH8usLozhxIQxVbjw_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzYFTZAFQUwKS7OozlFRH8usLozhxIQxVbjw_003D_003D = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Thickness of the silhouettes, applies only if the ShowSilhouettes is true.")]
	public float SilhouetteThickness
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzVkLUUCxiV5t8PRn_0024lHMOh_002436kGpEMN976w_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzVkLUUCxiV5t8PRn_0024lHMOh_002436kGpEMN976w_003D_003D = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Entity edges color mode.")]
	public edgeColorMethodType EdgeColorMethod
	{
		get
		{
			return _0023_003DzijMpVqnwAHCU;
		}
		set
		{
			_0023_003DzijMpVqnwAHCU = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Internal Wireframe visibility status in display modes different from Hidden Lines.")]
	public bool ShowInternalWires
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzUIKmH6yk_u6AB2x_qDX0cUlhPvD9;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzUIKmH6yk_u6AB2x_qDX0cUlhPvD9 = value;
		}
	}

	public DisplayModeSettings()
		: this(DefaultShowEdges, _0023_003DzjeceEL3etdby(), DefaultEdgeColor, DefaultEdgeThickness, DefaultSilhouetteThickness, DefaultSilhouettesDrawingMode, _0023_003DzdzI8AAuTdcwWHgOPdn1Rn2I_003D())
	{
	}

	public DisplayModeSettings(bool showEdges, edgeColorMethodType edgeColorMethod, Color edgeColor, float edgeThickness, float silhouetteThickness, silhouettesDrawingType silhouettesDrawingMode, bool showInternalWires)
	{
		_0023_003DzDDTqn6lBDa_h = showEdges;
		_0023_003DzUS40q9lzVpgV = edgeColor;
		_0023_003DzPKXENMxRB78h = edgeThickness;
		SilhouettesDrawingMode = silhouettesDrawingMode;
		SilhouetteThickness = silhouetteThickness;
		_0023_003DzijMpVqnwAHCU = edgeColorMethod;
		ShowInternalWires = showInternalWires;
	}

	internal bool _0023_003DzKbV5zK4hqflvFYL0Bg_003D_003D()
	{
		return ShowEdges != DefaultShowEdges;
	}

	internal void _0023_003Dz4TE9un89m41_0024()
	{
		ShowEdges = DefaultShowEdges;
	}

	internal bool _0023_003DzCHiptfgvMoLc()
	{
		return EdgeColor.ToArgb() != DefaultEdgeColor.ToArgb();
	}

	internal void _0023_003Dz7_f8kaanAepu()
	{
		EdgeColor = DefaultEdgeColor;
	}

	internal bool _0023_003DzcOVRKBfrGiB8oZos1w_003D_003D()
	{
		return EdgeThickness != DefaultEdgeThickness;
	}

	internal void _0023_003Dzq0Cw1J49zgzU()
	{
		EdgeThickness = DefaultEdgeThickness;
	}

	internal bool _0023_003DzU69CTOPIS7UmhkNDLBxQegLZp9uB()
	{
		return SilhouetteThickness != DefaultSilhouetteThickness;
	}

	internal void _0023_003Dz1hYiRBj3PBY_0024oiNMA3f8wsc_003D()
	{
		SilhouetteThickness = DefaultSilhouetteThickness;
	}

	internal bool _0023_003DzDfc8fDZ9BDNz65fFBCMNzTvSt4OC()
	{
		return SilhouettesDrawingMode != DefaultSilhouettesDrawingMode;
	}

	internal void _0023_003DzQ_OEXVUSzQlJCWcbHRDP10qX36GA()
	{
		SilhouettesDrawingMode = DefaultSilhouettesDrawingMode;
	}

	private static shadowType _0023_003DzntPtVW3D_Yst()
	{
		return shadowType.None;
	}

	internal virtual bool _0023_003Dz4XAvJ5aCRLKs(DisplayModeSettings _0023_003DzAbAO3f4_003D)
	{
		if (ShowEdges == _0023_003DzAbAO3f4_003D.ShowEdges && !(EdgeColor != _0023_003DzAbAO3f4_003D.EdgeColor) && EdgeThickness == _0023_003DzAbAO3f4_003D.EdgeThickness && SilhouetteThickness == _0023_003DzAbAO3f4_003D.SilhouetteThickness && SilhouettesDrawingMode == _0023_003DzAbAO3f4_003D.SilhouettesDrawingMode && EdgeColorMethod == _0023_003DzAbAO3f4_003D.EdgeColorMethod)
		{
			return ShowInternalWires != _0023_003DzAbAO3f4_003D.ShowInternalWires;
		}
		return true;
	}

	private static edgeColorMethodType _0023_003DzjeceEL3etdby()
	{
		return edgeColorMethodType.EntityColor;
	}

	private static bool _0023_003DzdzI8AAuTdcwWHgOPdn1Rn2I_003D()
	{
		return true;
	}

	internal bool _0023_003Dz4t8ufdzaDDpJ4XFavg_003D_003D()
	{
		return EdgeColorMethod != _0023_003DzjeceEL3etdby();
	}

	internal void _0023_003DzgHhQCSIF0fab()
	{
		EdgeColorMethod = _0023_003DzjeceEL3etdby();
	}

	internal bool _0023_003DzecFWt6CO3aiMwaf2lcK1Ldc_003D()
	{
		return ShowInternalWires != _0023_003DzdzI8AAuTdcwWHgOPdn1Rn2I_003D();
	}

	internal void _0023_003Dzgxb9_0024i8hHOWHFCsggg_003D_003D()
	{
		ShowInternalWires = _0023_003DzdzI8AAuTdcwWHgOPdn1Rn2I_003D();
	}
}
