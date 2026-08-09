using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using devDept.Eyeshot.Control.Converters;

namespace devDept.Eyeshot.Control;

[TypeConverter(typeof(HiddenLinesConverter))]
public class HiddenLinesSettings : DisplayModeSettings, IHiddenLinesSettings
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzejtBeCCXCURt6xOTo9zZgAQ0f0Xn;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private hiddenLinesColorMethodType _0023_003Dz2j_00248dTsFN9joF8Yg_0024Q_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003DzlpvRsa3dLCSF9t12x2X8yMPPK8LY;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private edgeColorMethodType _0023_003DzuneRvxPcf51nIdnfWYW9Mks_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003DzXdIR_0024vekVfWlIer4NA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003DzEKDTQsOYU3eami8e_0024Q_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float _0023_003DzfqSLTGNZBRTd7m8uZVN5CxQ_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz0FAnsOzH_VjkU1IAKbW_00240_0024V8flzS;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003DzBsQbvU_0024IoXhfPYXW_0024trQWq1RAmXH;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float _0023_003DzKueXSWcPEfbvgT_o7_0024kXgegn_k37cPO_Dg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ushort _0023_003Dzzu_B6HrQeWuVnxKCJ8uqZ2_00243BSMADAaALQ_003D_003D;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Enable/Disable lighting in hidden lines mode.")]
	public bool Lighting
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzejtBeCCXCURt6xOTo9zZgAQ0f0Xn;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzejtBeCCXCURt6xOTo9zZgAQ0f0Xn = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Color Method.")]
	public hiddenLinesColorMethodType ColorMethod
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz2j_00248dTsFN9joF8Yg_0024Q_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz2j_00248dTsFN9joF8Yg_0024Q_003D_003D = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Color of the silhouettes, applies only if the ShowSilhouettes is true.")]
	public Color SilhouetteColor
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzlpvRsa3dLCSF9t12x2X8yMPPK8LY;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzlpvRsa3dLCSF9t12x2X8yMPPK8LY = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Wires color method.")]
	public edgeColorMethodType WireColorMethod
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzuneRvxPcf51nIdnfWYW9Mks_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzuneRvxPcf51nIdnfWYW9Mks_003D = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Color of the polygons, applies only if the ColorMethod is SingleColor.")]
	public Color PolygonColor
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzXdIR_0024vekVfWlIer4NA_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzXdIR_0024vekVfWlIer4NA_003D_003D = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Color of the wireframe entities when the WireColorMethod is SingleColor.")]
	public Color WireColor
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzEKDTQsOYU3eami8e_0024Q_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzEKDTQsOYU3eami8e_0024Q_003D_003D = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Thickness of the wireframe entities.")]
	public float WireThickness
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzfqSLTGNZBRTd7m8uZVN5CxQ_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzfqSLTGNZBRTd7m8uZVN5CxQ_003D = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Enable / disable dashed hidden lines visualization.")]
	public bool DashedHiddenLines
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz0FAnsOzH_VjkU1IAKbW_00240_0024V8flzS;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz0FAnsOzH_VjkU1IAKbW_00240_0024V8flzS = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Color of the dashed hidden lines.")]
	public Color DashedHiddenLinesColor
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzBsQbvU_0024IoXhfPYXW_0024trQWq1RAmXH;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzBsQbvU_0024IoXhfPYXW_0024trQWq1RAmXH = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Thickness of the dashed hidden lines.")]
	public float DashedHiddenLinesThickness
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzKueXSWcPEfbvgT_o7_0024kXgegn_k37cPO_Dg_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzKueXSWcPEfbvgT_o7_0024kXgegn_k37cPO_Dg_003D_003D = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Hidden lines dashed pattern.")]
	[TypeConverter("devDept.Geometry.Converters.ushortHexTypeConverter, devDept.Geometry")]
	[CLSCompliant(false)]
	public ushort DashedHiddenLinesPattern
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzzu_B6HrQeWuVnxKCJ8uqZ2_00243BSMADAaALQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzzu_B6HrQeWuVnxKCJ8uqZ2_00243BSMADAaALQ_003D_003D = value;
		}
	}

	public HiddenLinesSettings()
		: this(_0023_003DzPCmn_0024Orgk2uCFrU0lA_003D_003D(), _0023_003DzMmEcaz3qTVMi(), _0023_003DzZrM_v3fKnpHX(), _0023_003DzK68careqyPNOUd1_0024S5YXtwk_003D(), _0023_003DzxS1LShCwBQyU(), _0023_003DztGgoGqht6fsG(), _0023_003DzzzTL_00241CJ7A3nBnzop6zrqQo_003D(), _0023_003DzWMRgv0tyy_dkOxwQGoqFHpU_003D(), _0023_003DzHbsRiQFz7cLtRuuvFyJyB8glJlv3(), _0023_003DzO9gZYVuk2S3aXSuwbgztfB0_003D(), _0023_003DzcL0q2vquhdai(), _0023_003DzSakbSm5vy1JL(), _0023_003DztXSH0Ks4JrJSjrpGgFuJhck_003D(), _0023_003Dzo2OH91tXtt2MCUcvTPcP_R0_003D())
	{
	}

	[CLSCompliant(false)]
	public HiddenLinesSettings(bool lighting, hiddenLinesColorMethodType colorMethod, bool showEdges, float silhouetteThickness, float edgeThickness, float wireThickness, float dashedHiddenLinesThickness, bool dashedHiddenLines, silhouettesDrawingType silhouettesDrawingMode, Color silhouetteColor, Color edgeColor, Color wireColor, Color dashedHiddenLinesColor, ushort dashedHiddenLinesPattern)
		: this(lighting, colorMethod, showEdges, edgeColorMethodType.SingleColor, silhouetteThickness, edgeThickness, wireThickness, dashedHiddenLinesThickness, dashedHiddenLines, silhouettesDrawingMode, showInternalWires: false, silhouetteColor, edgeColor, wireColor, dashedHiddenLinesColor, dashedHiddenLinesPattern)
	{
	}

	[CLSCompliant(false)]
	public HiddenLinesSettings(bool lighting, hiddenLinesColorMethodType colorMethod, bool showEdges, edgeColorMethodType edgeColorMethod, float silhouetteThickness, float edgeThickness, float wireThickness, float dashedHiddenLinesThickness, bool dashedHiddenLines, silhouettesDrawingType silhouettesDrawingMode, bool showInternalWires, Color silhouetteColor, Color edgeColor, Color wireColor, Color dashedHiddenLinesColor, ushort dashedHiddenLinesPattern)
		: this(lighting, colorMethod, showEdges, edgeColorMethod, silhouetteThickness, edgeThickness, wireThickness, dashedHiddenLinesThickness, dashedHiddenLines, silhouettesDrawingMode, showInternalWires, silhouetteColor, edgeColor, wireColor, dashedHiddenLinesColor, dashedHiddenLinesPattern, _0023_003DzkyBR0i7BkyrS(), _0023_003DzfBIpus6dbSC7())
	{
	}

	[CLSCompliant(false)]
	public HiddenLinesSettings(bool lighting, hiddenLinesColorMethodType colorMethod, bool showEdges, edgeColorMethodType edgeColorMethod, float silhouetteThickness, float edgeThickness, float wireThickness, float dashedHiddenLinesThickness, bool dashedHiddenLines, silhouettesDrawingType silhouettesDrawingMode, bool showInternalWires, Color silhouetteColor, Color edgeColor, Color wireColor, Color dashedHiddenLinesColor, ushort dashedHiddenLinesPattern, edgeColorMethodType wireColorMethod, Color polygonColor)
		: base(showEdges, edgeColorMethod, edgeColor, edgeThickness, silhouetteThickness, silhouettesDrawingMode, showInternalWires)
	{
		Lighting = lighting;
		ColorMethod = colorMethod;
		SilhouetteColor = silhouetteColor;
		WireColor = wireColor;
		WireThickness = wireThickness;
		DashedHiddenLines = dashedHiddenLines;
		DashedHiddenLinesColor = dashedHiddenLinesColor;
		DashedHiddenLinesThickness = dashedHiddenLinesThickness;
		DashedHiddenLinesPattern = dashedHiddenLinesPattern;
		WireColorMethod = wireColorMethod;
		PolygonColor = polygonColor;
	}

	private static bool _0023_003DzPCmn_0024Orgk2uCFrU0lA_003D_003D()
	{
		return false;
	}

	private static hiddenLinesColorMethodType _0023_003DzMmEcaz3qTVMi()
	{
		return hiddenLinesColorMethodType.SingleColor;
	}

	private static bool _0023_003DzZrM_v3fKnpHX()
	{
		return true;
	}

	private static float _0023_003DzK68careqyPNOUd1_0024S5YXtwk_003D()
	{
		return 2f;
	}

	private static float _0023_003DzxS1LShCwBQyU()
	{
		return 1f;
	}

	private static float _0023_003DztGgoGqht6fsG()
	{
		return 1f;
	}

	private static float _0023_003DzzzTL_00241CJ7A3nBnzop6zrqQo_003D()
	{
		return 1f;
	}

	private static bool _0023_003DzWMRgv0tyy_dkOxwQGoqFHpU_003D()
	{
		return false;
	}

	private static silhouettesDrawingType _0023_003DzHbsRiQFz7cLtRuuvFyJyB8glJlv3()
	{
		return silhouettesDrawingType.Always;
	}

	private static Color _0023_003DzO9gZYVuk2S3aXSuwbgztfB0_003D()
	{
		return Color.Black;
	}

	private static edgeColorMethodType _0023_003DzkyBR0i7BkyrS()
	{
		return edgeColorMethodType.SingleColor;
	}

	private static Color _0023_003DzfBIpus6dbSC7()
	{
		return Color.White;
	}

	private static Color _0023_003DzcL0q2vquhdai()
	{
		return Color.Black;
	}

	private static Color _0023_003DzSakbSm5vy1JL()
	{
		return Color.Black;
	}

	private static Color _0023_003DztXSH0Ks4JrJSjrpGgFuJhck_003D()
	{
		return Color.Gray;
	}

	private static ushort _0023_003Dzo2OH91tXtt2MCUcvTPcP_R0_003D()
	{
		return 13107;
	}

	internal new bool _0023_003DzKbV5zK4hqflvFYL0Bg_003D_003D()
	{
		return base.ShowEdges != _0023_003DzZrM_v3fKnpHX();
	}

	internal new void _0023_003Dz4TE9un89m41_0024()
	{
		base.ShowEdges = _0023_003DzZrM_v3fKnpHX();
	}

	internal new bool _0023_003DzU69CTOPIS7UmhkNDLBxQegLZp9uB()
	{
		return base.SilhouetteThickness != _0023_003DzK68careqyPNOUd1_0024S5YXtwk_003D();
	}

	internal new void _0023_003Dz1hYiRBj3PBY_0024oiNMA3f8wsc_003D()
	{
		base.SilhouetteThickness = _0023_003DzK68careqyPNOUd1_0024S5YXtwk_003D();
	}

	internal new bool _0023_003DzcOVRKBfrGiB8oZos1w_003D_003D()
	{
		return base.EdgeThickness != _0023_003DzxS1LShCwBQyU();
	}

	internal new void _0023_003Dzq0Cw1J49zgzU()
	{
		base.EdgeThickness = _0023_003DzxS1LShCwBQyU();
	}

	internal new bool _0023_003DzCHiptfgvMoLc()
	{
		return base.EdgeColor.ToArgb() != _0023_003DzcL0q2vquhdai().ToArgb();
	}

	internal new void _0023_003Dz7_f8kaanAepu()
	{
		base.EdgeColor = _0023_003DzcL0q2vquhdai();
	}

	private bool _0023_003DzpDSd4ZiVVBxIMNnMC58SjPE_003D()
	{
		return Lighting != _0023_003DzPCmn_0024Orgk2uCFrU0lA_003D_003D();
	}

	internal void _0023_003DzUi_NH3uU71f_AaJ5Gg_003D_003D()
	{
		Lighting = _0023_003DzPCmn_0024Orgk2uCFrU0lA_003D_003D();
	}

	private bool _0023_003Dz1oRUGOfgE6xO()
	{
		return ColorMethod != _0023_003DzMmEcaz3qTVMi();
	}

	internal void _0023_003DzVL_buBrPJ_0024fr()
	{
		ColorMethod = _0023_003DzMmEcaz3qTVMi();
	}

	private bool _0023_003DzMUfQWt9yl_mrmkKnGFc_Rtc_003D()
	{
		return SilhouetteColor != _0023_003DzO9gZYVuk2S3aXSuwbgztfB0_003D();
	}

	internal void _0023_003DzTM6JGQF2UZ4o6k1GPReUpr8_003D()
	{
		SilhouetteColor = _0023_003DzO9gZYVuk2S3aXSuwbgztfB0_003D();
	}

	private bool _0023_003Dz5KhAJ_0024KlFzNwgT5d1A_003D_003D()
	{
		return WireColorMethod != _0023_003DzkyBR0i7BkyrS();
	}

	internal void _0023_003DzKRjwKquLMw1N()
	{
		WireColorMethod = _0023_003DzkyBR0i7BkyrS();
	}

	private bool _0023_003DzRixBx5ZHoe9t()
	{
		return WireColor != _0023_003DzfBIpus6dbSC7();
	}

	internal void _0023_003DzQJi297kAFhqN()
	{
		WireColor = _0023_003DzfBIpus6dbSC7();
	}

	private bool _0023_003DzCpfxTlHo_0024CBJ()
	{
		return WireColor != _0023_003DzSakbSm5vy1JL();
	}

	internal void _0023_003DzAviLyeuW50fc()
	{
		WireColor = _0023_003DzSakbSm5vy1JL();
	}

	private bool _0023_003DzvnSxIaNQBtTlclqgOw_003D_003D()
	{
		return WireThickness != _0023_003DztGgoGqht6fsG();
	}

	internal void _0023_003DzDOCi_B55CUeK()
	{
		WireThickness = _0023_003DztGgoGqht6fsG();
	}

	private bool _0023_003DzcbCGAi_0024u_jiSTcUNDPEp9zs_003D()
	{
		return DashedHiddenLines != _0023_003DzWMRgv0tyy_dkOxwQGoqFHpU_003D();
	}

	internal void _0023_003DzC6JrVFikMZtHE3DPmgdGz10_003D()
	{
		DashedHiddenLines = _0023_003DzWMRgv0tyy_dkOxwQGoqFHpU_003D();
	}

	private bool _0023_003DzG5IuEnlr8ipupt70_WGkMbA_003D()
	{
		return DashedHiddenLinesColor != _0023_003DztXSH0Ks4JrJSjrpGgFuJhck_003D();
	}

	internal void _0023_003Dzz8TOz9p9xh2HMD0rrgAtTFg_003D()
	{
		DashedHiddenLinesColor = _0023_003DztXSH0Ks4JrJSjrpGgFuJhck_003D();
	}

	private bool _0023_003DzHh6PSK2mr8QGuiRoYaXO6XVyoN_0024L()
	{
		return DashedHiddenLinesThickness != _0023_003DzzzTL_00241CJ7A3nBnzop6zrqQo_003D();
	}

	internal void _0023_003DzGTpFiVroTx_Pj_0024AmhynTx00_003D()
	{
		DashedHiddenLinesThickness = _0023_003DzzzTL_00241CJ7A3nBnzop6zrqQo_003D();
	}

	private bool _0023_003DzWVfuAF7guoVXLRJUwlzzuIvmKhyC()
	{
		return DashedHiddenLinesPattern != _0023_003Dzo2OH91tXtt2MCUcvTPcP_R0_003D();
	}

	internal void _0023_003DzKB_jOxUd3qmMaYsgmbW_0024Cew_003D()
	{
		DashedHiddenLinesPattern = _0023_003Dzo2OH91tXtt2MCUcvTPcP_R0_003D();
	}

	internal override bool _0023_003Dz4XAvJ5aCRLKs(DisplayModeSettings _0023_003DzAbAO3f4_003D)
	{
		HiddenLinesSettings hiddenLinesSettings = (HiddenLinesSettings)_0023_003DzAbAO3f4_003D;
		if (!base._0023_003Dz4XAvJ5aCRLKs(_0023_003DzAbAO3f4_003D) && Lighting == hiddenLinesSettings.Lighting && ColorMethod == hiddenLinesSettings.ColorMethod && WireThickness == hiddenLinesSettings.WireThickness && DashedHiddenLinesThickness == hiddenLinesSettings.DashedHiddenLinesThickness && DashedHiddenLines == hiddenLinesSettings.DashedHiddenLines && !(SilhouetteColor != hiddenLinesSettings.SilhouetteColor) && !(WireColor != hiddenLinesSettings.WireColor) && !(DashedHiddenLinesColor != hiddenLinesSettings.DashedHiddenLinesColor) && DashedHiddenLinesPattern == hiddenLinesSettings.DashedHiddenLinesPattern && WireColorMethod == hiddenLinesSettings.WireColorMethod)
		{
			return PolygonColor != hiddenLinesSettings.PolygonColor;
		}
		return true;
	}
}
