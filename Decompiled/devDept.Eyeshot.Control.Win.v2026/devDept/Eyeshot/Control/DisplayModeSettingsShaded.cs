using System.ComponentModel;
using System.Drawing;
using devDept.Eyeshot.Control.Converters;
using devDept.Graphics;

namespace devDept.Eyeshot.Control;

[TypeConverter(typeof(DisplayModeSettingsShadedConverter))]
public class DisplayModeSettingsShaded : DisplayModeSettings
{
	protected new static bool DefaultShowEdges => true;

	protected internal static edgeColorMethodType DefaultEdgeColorMethod => edgeColorMethodType.EntityColor;

	protected internal new static Color DefaultEdgeColor => Color.Black;

	protected internal new static float DefaultEdgeThickness => 2f;

	protected internal new static float DefaultSilhouetteThickness => 2f;

	protected new static silhouettesDrawingType DefaultSilhouettesDrawingMode => silhouettesDrawingType.Never;

	protected static bool DefaultShowInternalWires => true;

	protected static shadowType DefaultShadowMode => shadowType.Planar;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("The shadow mode.")]
	public shadowType ShadowMode
	{
		get
		{
			return _0023_003DzLipASLNgxA13;
		}
		set
		{
			_0023_003DzLipASLNgxA13 = value;
		}
	}

	public DisplayModeSettingsShaded()
		: this(DefaultShowEdges, DefaultEdgeColorMethod, DefaultEdgeColor, DefaultEdgeThickness, DefaultSilhouetteThickness, DefaultSilhouettesDrawingMode, DefaultShowInternalWires, DefaultShadowMode)
	{
	}

	public DisplayModeSettingsShaded(bool showEdges, edgeColorMethodType edgeColorMethod, Color edgeColor, float edgeThickness, float silhouetteThickness, silhouettesDrawingType silhouettesDrawingMode, bool showInternalWires, shadowType shadowMode)
		: base(showEdges, edgeColorMethod, edgeColor, edgeThickness, silhouetteThickness, silhouettesDrawingMode, showInternalWires)
	{
		ShadowMode = shadowMode;
	}

	internal new bool _0023_003DzKbV5zK4hqflvFYL0Bg_003D_003D()
	{
		return base.ShowEdges != DefaultShowEdges;
	}

	internal new void _0023_003Dz4TE9un89m41_0024()
	{
		base.ShowEdges = DefaultShowEdges;
	}

	internal new bool _0023_003Dz4t8ufdzaDDpJ4XFavg_003D_003D()
	{
		return base.EdgeColorMethod != DefaultEdgeColorMethod;
	}

	internal new void _0023_003DzgHhQCSIF0fab()
	{
		base.EdgeColorMethod = DefaultEdgeColorMethod;
	}

	internal new bool _0023_003DzCHiptfgvMoLc()
	{
		return base.EdgeColor.ToArgb() != DefaultEdgeColor.ToArgb();
	}

	internal new void _0023_003Dz7_f8kaanAepu()
	{
		base.EdgeColor = DefaultEdgeColor;
	}

	internal new bool _0023_003DzcOVRKBfrGiB8oZos1w_003D_003D()
	{
		return base.EdgeThickness != DefaultEdgeThickness;
	}

	internal new void _0023_003Dzq0Cw1J49zgzU()
	{
		base.EdgeThickness = DefaultEdgeThickness;
	}

	internal new bool _0023_003DzU69CTOPIS7UmhkNDLBxQegLZp9uB()
	{
		return base.SilhouetteThickness != DefaultSilhouetteThickness;
	}

	internal new void _0023_003Dz1hYiRBj3PBY_0024oiNMA3f8wsc_003D()
	{
		base.SilhouetteThickness = DefaultSilhouetteThickness;
	}

	internal new bool _0023_003DzDfc8fDZ9BDNz65fFBCMNzTvSt4OC()
	{
		return base.SilhouettesDrawingMode != DefaultSilhouettesDrawingMode;
	}

	internal new void _0023_003DzQ_OEXVUSzQlJCWcbHRDP10qX36GA()
	{
		base.SilhouettesDrawingMode = DefaultSilhouettesDrawingMode;
	}

	internal new bool _0023_003DzecFWt6CO3aiMwaf2lcK1Ldc_003D()
	{
		return base.ShowInternalWires != DefaultShowInternalWires;
	}

	internal new void _0023_003Dzgxb9_0024i8hHOWHFCsggg_003D_003D()
	{
		base.ShowInternalWires = DefaultShowInternalWires;
	}

	internal bool _0023_003DzdAeM6VdiNYZ3Cz0ZlA_003D_003D()
	{
		return ShadowMode != DefaultShadowMode;
	}

	internal void _0023_003DzB8ugf4dG_Bf5()
	{
		ShadowMode = DefaultShadowMode;
	}

	internal override bool _0023_003Dz4XAvJ5aCRLKs(DisplayModeSettings _0023_003DzAbAO3f4_003D)
	{
		if (!base._0023_003Dz4XAvJ5aCRLKs(_0023_003DzAbAO3f4_003D))
		{
			return ShadowMode != ((DisplayModeSettingsShaded)_0023_003DzAbAO3f4_003D).ShadowMode;
		}
		return true;
	}
}
