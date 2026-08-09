using System;
using System.ComponentModel;
using System.Drawing;
using devDept.Eyeshot.Control.Converters;

namespace devDept.Eyeshot.Control;

[Serializable]
[TypeConverter(typeof(SelectionBoxColorsConverter))]
public class SelectionBoxColorsSettings
{
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Color used to draw the box or polygon for crossing selection modes")]
	public Color Crossing { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Color used to draw the box or polygon for enclosed selection modes")]
	public Color Enclosed { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Color used to draw the box or polygon for visible selection modes")]
	public Color Visible { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("When true the border is drawn in XOR, otherwise it is drawn according to the box color")]
	public bool BorderXOR { get; set; } = true;

	public SelectionBoxColorsSettings()
		: this(_0023_003DzWTMgW4FWAvL3mTQU7A_003D_003D(), _0023_003Dz8NQ_cyyL0CmvIFN8Mg_003D_003D(), _0023_003DzndG2TcxO_tb_0024(), _0023_003DzosdL7FB0Vcgulr2Quw_003D_003D())
	{
	}

	[Obsolete("Use the overload with the borderXOR parameter.")]
	public SelectionBoxColorsSettings(Color crossing, Color enclosed, Color visible)
		: this(crossing, enclosed, visible, _0023_003DzosdL7FB0Vcgulr2Quw_003D_003D())
	{
	}

	public SelectionBoxColorsSettings(Color crossing, Color enclosed, Color visible, bool borderXOR)
	{
		Crossing = crossing;
		Enclosed = enclosed;
		Visible = visible;
		BorderXOR = borderXOR;
	}

	private static Color _0023_003DzWTMgW4FWAvL3mTQU7A_003D_003D()
	{
		return Color.Blue;
	}

	private static Color _0023_003Dz8NQ_cyyL0CmvIFN8Mg_003D_003D()
	{
		return Color.Red;
	}

	private static Color _0023_003DzndG2TcxO_tb_0024()
	{
		return Color.Green;
	}

	private static bool _0023_003DzosdL7FB0Vcgulr2Quw_003D_003D()
	{
		return true;
	}

	internal bool _0023_003Dz4XAvJ5aCRLKs(SelectionBoxColorsSettings _0023_003DzyQmY6T8_003D)
	{
		if (!(Crossing != _0023_003DzyQmY6T8_003D.Crossing) && !(Enclosed != _0023_003DzyQmY6T8_003D.Enclosed) && !(Visible != _0023_003DzyQmY6T8_003D.Visible))
		{
			return BorderXOR != _0023_003DzyQmY6T8_003D.BorderXOR;
		}
		return true;
	}
}
