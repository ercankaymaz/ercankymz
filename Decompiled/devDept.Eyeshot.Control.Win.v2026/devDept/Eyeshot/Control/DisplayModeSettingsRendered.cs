using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using devDept.Eyeshot.Control.Converters;
using devDept.Graphics;

namespace devDept.Eyeshot.Control;

[TypeConverter(typeof(DisplayModeSettingsRenderedConverter))]
public class DisplayModeSettingsRendered : DisplayModeSettingsShaded, IDisplayModeSettingsRendered, IDisplayModeSettings
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Image _0023_003DzzCRy71aPOrSnUrNZv2Kh9Pc_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzAz8bHCdP_0024x4N2tPRgaMQt4A_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzXcZJhJf58hlAbNaHrnddXZN_0024UHBKpGE_00242qwXmbs_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float _0023_003Dz1nsBc1B62A8BdZRNJ2AW_5eI3AuhNj4STDDQwopmFvo2BoFC9Q_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private realisticShadowQualityType _0023_003Dz8XNA0rgg42am1osdJMYXvvLzDkXlbYJKhw_003D_003D;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Image for environment mapping.")]
	[Bindable(true)]
	public Image EnvironmentMappingImage
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzzCRy71aPOrSnUrNZv2Kh9Pc_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzzCRy71aPOrSnUrNZv2Kh9Pc_003D = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Environment mapping enabled status.")]
	public bool EnvironmentMapping
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzAz8bHCdP_0024x4N2tPRgaMQt4A_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzAz8bHCdP_0024x4N2tPRgaMQt4A_003D = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Planar reflections.")]
	public bool PlanarReflections
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzXcZJhJf58hlAbNaHrnddXZN_0024UHBKpGE_00242qwXmbs_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzXcZJhJf58hlAbNaHrnddXZN_0024UHBKpGE_00242qwXmbs_003D = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Planar reflection intensity.")]
	public float PlanarReflectionsIntensity
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz1nsBc1B62A8BdZRNJ2AW_5eI3AuhNj4STDDQwopmFvo2BoFC9Q_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz1nsBc1B62A8BdZRNJ2AW_5eI3AuhNj4STDDQwopmFvo2BoFC9Q_003D_003D = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Realistic shadows quality.")]
	public realisticShadowQualityType RealisticShadowQuality
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz8XNA0rgg42am1osdJMYXvvLzDkXlbYJKhw_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz8XNA0rgg42am1osdJMYXvvLzDkXlbYJKhw_003D_003D = value;
		}
	}

	public DisplayModeSettingsRendered()
		: this(DisplayModeSettingsShaded.DefaultShowEdges, _0023_003DzjeceEL3etdby(), DisplayModeSettingsShaded.DefaultEdgeColor, _0023_003DzxS1LShCwBQyU(), DisplayModeSettingsShaded.DefaultSilhouetteThickness, _0023_003DzC0C7e8dnDY0Hk3Z199PaKbwzU40p(), _0023_003DzdzI8AAuTdcwWHgOPdn1Rn2I_003D(), _0023_003DzntPtVW3D_Yst(), _0023_003DzozksMAqPAhtR2PmzBg_003D_003D(), _0023_003DzIqiOBzDaG67YNWqI0Q_003D_003D(), _0023_003DzuBqEnFQ9GnZ7FuTgA6QulBz4fEP4th3RhA_003D_003D(), _0023_003Dz4cXir63pr1NXLJIhmF2xrIlqio_00243fIpbJg_003D_003D(), _0023_003DzIWiXLJqyXvSLCP7Jd3aBaxGzCVWH())
	{
	}

	public DisplayModeSettingsRendered(bool showEdges, edgeColorMethodType edgeColorMethod, Color edgeColor, float edgeThickness, float silhouetteThickness, silhouettesDrawingType silhouettesDrawingMode, bool showInternalWires, shadowType shadowMode, Image environmentImage, bool environmentMapEnabled, bool planarReflections, float reflectionsIntensity, realisticShadowQualityType realisticShadowQuality)
		: base(showEdges, edgeColorMethod, edgeColor, edgeThickness, silhouetteThickness, silhouettesDrawingMode, showInternalWires, shadowMode)
	{
		_0023_003DzUMSSRSw_003D(environmentImage, environmentMapEnabled, planarReflections, reflectionsIntensity, realisticShadowQuality);
	}

	private static float _0023_003DzxS1LShCwBQyU()
	{
		return 1f;
	}

	private static bool _0023_003DzdzI8AAuTdcwWHgOPdn1Rn2I_003D()
	{
		return false;
	}

	private static silhouettesDrawingType _0023_003DzC0C7e8dnDY0Hk3Z199PaKbwzU40p()
	{
		return silhouettesDrawingType.ImageBased;
	}

	private static shadowType _0023_003DzntPtVW3D_Yst()
	{
		return shadowType.Planar;
	}

	private static Image _0023_003DzozksMAqPAhtR2PmzBg_003D_003D()
	{
		return null;
	}

	private static bool _0023_003DzIqiOBzDaG67YNWqI0Q_003D_003D()
	{
		return true;
	}

	private static bool _0023_003DzuBqEnFQ9GnZ7FuTgA6QulBz4fEP4th3RhA_003D_003D()
	{
		return false;
	}

	private static float _0023_003Dz4cXir63pr1NXLJIhmF2xrIlqio_00243fIpbJg_003D_003D()
	{
		return 0.3f;
	}

	private static realisticShadowQualityType _0023_003DzIWiXLJqyXvSLCP7Jd3aBaxGzCVWH()
	{
		return realisticShadowQualityType.High;
	}

	private static edgeColorMethodType _0023_003DzjeceEL3etdby()
	{
		return edgeColorMethodType.SingleColor;
	}

	internal new bool _0023_003DzcOVRKBfrGiB8oZos1w_003D_003D()
	{
		return base.EdgeThickness != _0023_003DzxS1LShCwBQyU();
	}

	internal new void _0023_003Dzq0Cw1J49zgzU()
	{
		base.EdgeThickness = _0023_003DzxS1LShCwBQyU();
	}

	internal new bool _0023_003DzDfc8fDZ9BDNz65fFBCMNzTvSt4OC()
	{
		return base.SilhouettesDrawingMode != _0023_003DzC0C7e8dnDY0Hk3Z199PaKbwzU40p();
	}

	internal new void _0023_003DzQ_OEXVUSzQlJCWcbHRDP10qX36GA()
	{
		base.SilhouettesDrawingMode = _0023_003DzC0C7e8dnDY0Hk3Z199PaKbwzU40p();
	}

	internal new bool _0023_003DzecFWt6CO3aiMwaf2lcK1Ldc_003D()
	{
		return base.ShowInternalWires != _0023_003DzdzI8AAuTdcwWHgOPdn1Rn2I_003D();
	}

	internal new void _0023_003Dzgxb9_0024i8hHOWHFCsggg_003D_003D()
	{
		base.ShowInternalWires = _0023_003DzdzI8AAuTdcwWHgOPdn1Rn2I_003D();
	}

	internal new bool _0023_003DzdAeM6VdiNYZ3Cz0ZlA_003D_003D()
	{
		return base.ShadowMode != _0023_003DzntPtVW3D_Yst();
	}

	internal new void _0023_003DzB8ugf4dG_Bf5()
	{
		base.ShadowMode = _0023_003DzntPtVW3D_Yst();
	}

	private bool _0023_003Dzuq0rmBPTMbFh1mPN3A_003D_003D()
	{
		return EnvironmentMappingImage != _0023_003DzozksMAqPAhtR2PmzBg_003D_003D();
	}

	internal void _0023_003DzXLrBrBJ00wjPp2qaCQ_003D_003D()
	{
		EnvironmentMappingImage = _0023_003DzozksMAqPAhtR2PmzBg_003D_003D();
	}

	private bool _0023_003Dz9T8WKuyDpPTX9qYR7Q_003D_003D()
	{
		return EnvironmentMapping != _0023_003DzIqiOBzDaG67YNWqI0Q_003D_003D();
	}

	internal void _0023_003Dzt74GvE30_0024FZQ()
	{
		EnvironmentMapping = _0023_003DzIqiOBzDaG67YNWqI0Q_003D_003D();
	}

	private bool _0023_003Dzaca6ya5VFLHW0sxuozO_0024xx6AOAfYv1jGOQ_003D_003D()
	{
		return PlanarReflections != _0023_003DzuBqEnFQ9GnZ7FuTgA6QulBz4fEP4th3RhA_003D_003D();
	}

	internal void _0023_003DzB_Fr6SpcxPOzSllo4B_0024ufIPu42aB()
	{
		PlanarReflections = _0023_003DzuBqEnFQ9GnZ7FuTgA6QulBz4fEP4th3RhA_003D_003D();
	}

	private bool _0023_003Dzz7kawbtsNC1EyP5ULPQd_hXJHGTsiyGlfw3J645HUT1Z()
	{
		return PlanarReflectionsIntensity != _0023_003Dz4cXir63pr1NXLJIhmF2xrIlqio_00243fIpbJg_003D_003D();
	}

	internal void _0023_003DzU58cE42cWHEDETnxJwjS9_0024IiYMSp8LgZjBmwNHOe6s2_0024()
	{
		PlanarReflectionsIntensity = _0023_003Dz4cXir63pr1NXLJIhmF2xrIlqio_00243fIpbJg_003D_003D();
	}

	private bool _0023_003Dzkf3nXwziP_0024zZD7jsiww71CiWthyA()
	{
		return RealisticShadowQuality != _0023_003DzIWiXLJqyXvSLCP7Jd3aBaxGzCVWH();
	}

	internal void _0023_003DzlxGXNH3osbWobTXv40VEt6o_003D()
	{
		RealisticShadowQuality = _0023_003DzIWiXLJqyXvSLCP7Jd3aBaxGzCVWH();
	}

	private void _0023_003DzUMSSRSw_003D(Image _0023_003DzpfQIlVXNQtMt, bool _0023_003Dz7P1uKUoIW7tX, bool _0023_003Dzk3KGpSl0I48qPYLcl6ZgXyfgAmDk, float _0023_003DzjyyNqsPL02XXGoWz_CRM85mM55WGC5MYBA_003D_003D, realisticShadowQualityType _0023_003Dz8sToy13yErz1LEesXn2pwSI_003D)
	{
		EnvironmentMappingImage = _0023_003DzpfQIlVXNQtMt;
		PlanarReflections = _0023_003Dzk3KGpSl0I48qPYLcl6ZgXyfgAmDk;
		PlanarReflectionsIntensity = _0023_003DzjyyNqsPL02XXGoWz_CRM85mM55WGC5MYBA_003D_003D;
		EnvironmentMapping = _0023_003Dz7P1uKUoIW7tX;
		RealisticShadowQuality = _0023_003Dz8sToy13yErz1LEesXn2pwSI_003D;
	}

	internal override bool _0023_003Dz4XAvJ5aCRLKs(DisplayModeSettings _0023_003DzAbAO3f4_003D)
	{
		DisplayModeSettingsRendered displayModeSettingsRendered = (DisplayModeSettingsRendered)_0023_003DzAbAO3f4_003D;
		if (!base._0023_003Dz4XAvJ5aCRLKs(_0023_003DzAbAO3f4_003D) && EnvironmentMappingImage == displayModeSettingsRendered.EnvironmentMappingImage && EnvironmentMapping == displayModeSettingsRendered.EnvironmentMapping && PlanarReflections == displayModeSettingsRendered.PlanarReflections && PlanarReflectionsIntensity == displayModeSettingsRendered.PlanarReflectionsIntensity)
		{
			return RealisticShadowQuality != displayModeSettingsRendered.RealisticShadowQuality;
		}
		return true;
	}
}
