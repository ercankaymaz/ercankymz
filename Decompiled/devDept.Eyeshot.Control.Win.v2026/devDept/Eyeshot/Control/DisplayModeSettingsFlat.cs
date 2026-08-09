using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using devDept.Eyeshot.Control.Converters;

namespace devDept.Eyeshot.Control;

[TypeConverter(typeof(DisplayModeSettingsFlatConverter))]
public class DisplayModeSettingsFlat : DisplayModeSettings
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private flatColorMethodType _0023_003Dz9VY6VdRAM4vn = _0023_003DzMmEcaz3qTVMi();

	protected new static silhouettesDrawingType DefaultSilhouettesDrawingMode => silhouettesDrawingType.LastFrame;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Color Method.")]
	public flatColorMethodType ColorMethod
	{
		get
		{
			return _0023_003Dz9VY6VdRAM4vn;
		}
		set
		{
			_0023_003Dz9VY6VdRAM4vn = value;
		}
	}

	public DisplayModeSettingsFlat()
		: this(DisplayModeSettings.DefaultShowEdges, _0023_003DzjeceEL3etdby(), DisplayModeSettings.DefaultEdgeColor, DisplayModeSettings.DefaultEdgeThickness, DisplayModeSettings.DefaultSilhouetteThickness, DefaultSilhouettesDrawingMode, _0023_003DzdzI8AAuTdcwWHgOPdn1Rn2I_003D())
	{
	}

	public DisplayModeSettingsFlat(bool showEdges, Color edgeColor, float edgeThickness, float silhouetteThickness, silhouettesDrawingType silhouettesDrawingMode)
		: this(showEdges, _0023_003DzjeceEL3etdby(), edgeColor, edgeThickness, silhouetteThickness, silhouettesDrawingMode, _0023_003DzdzI8AAuTdcwWHgOPdn1Rn2I_003D())
	{
	}

	public DisplayModeSettingsFlat(bool showEdges, edgeColorMethodType edgeColorMethod, Color edgeColor, float edgeThickness, float silhouetteThickness, silhouettesDrawingType silhouettesDrawingMode, bool showInternalWires)
		: base(showEdges, edgeColorMethod, edgeColor, edgeThickness, silhouetteThickness, silhouettesDrawingMode, showInternalWires)
	{
	}

	public DisplayModeSettingsFlat(bool showEdges, edgeColorMethodType edgeColorMethod, Color edgeColor, float edgeThickness, float silhouetteThickness, silhouettesDrawingType silhouettesDrawingMode, bool showInternalWires, flatColorMethodType colorMethod)
		: base(showEdges, edgeColorMethod, edgeColor, edgeThickness, silhouetteThickness, silhouettesDrawingMode, showInternalWires)
	{
		ColorMethod = colorMethod;
	}

	public DisplayModeSettingsFlat(bool showEdges, Color edgeColor, float edgeThickness, float silhouetteThickness, silhouettesDrawingType silhouettesDrawingMode, flatColorMethodType colorMethod)
		: this(showEdges, _0023_003DzjeceEL3etdby(), edgeColor, edgeThickness, silhouetteThickness, silhouettesDrawingMode, _0023_003DzdzI8AAuTdcwWHgOPdn1Rn2I_003D(), colorMethod)
	{
	}

	private static edgeColorMethodType _0023_003DzjeceEL3etdby()
	{
		return edgeColorMethodType.SingleColor;
	}

	private static bool _0023_003DzdzI8AAuTdcwWHgOPdn1Rn2I_003D()
	{
		return true;
	}

	private static flatColorMethodType _0023_003DzMmEcaz3qTVMi()
	{
		return flatColorMethodType.EntityColor;
	}

	private bool _0023_003Dz1oRUGOfgE6xO()
	{
		return ColorMethod != _0023_003DzMmEcaz3qTVMi();
	}

	internal void _0023_003DzVL_buBrPJ_0024fr()
	{
		ColorMethod = _0023_003DzMmEcaz3qTVMi();
	}

	internal override bool _0023_003Dz4XAvJ5aCRLKs(DisplayModeSettings _0023_003DzAbAO3f4_003D)
	{
		DisplayModeSettingsFlat displayModeSettingsFlat = (DisplayModeSettingsFlat)_0023_003DzAbAO3f4_003D;
		if (!base._0023_003Dz4XAvJ5aCRLKs(_0023_003DzAbAO3f4_003D))
		{
			return ColorMethod != displayModeSettingsFlat.ColorMethod;
		}
		return true;
	}
}
