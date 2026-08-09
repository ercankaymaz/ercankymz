using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using devDept.Eyeshot.Control.Labels;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;

namespace devDept.Eyeshot.Control;

public abstract class CoordinateSystemBase : UserInterfaceSymbolBase
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzEn9I2TV2Q0f80jZYbQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003DzUS40q9lzVpgV;

	protected TextOnly osLabelAxisX;

	protected TextOnly osLabelAxisY;

	protected TextOnly osLabelAxisZ;

	protected TextOnly osLabelOrigin;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Color _0023_003DzYMt62Gq1KVD_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Color _0023_003DzwETrOyAwL0aA;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Color _0023_003DzhHbXEP5q2zKc;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Color _0023_003DzA6bpkRXX6ek2;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Font _0023_003DzzmO0Pua6gdb0;

	protected bool disposeFont;

	protected const double arrowScale = 2.0 / 9.0;

	protected EntityGraphicsData drawSphere;

	protected EntityGraphicsData drawArrow;

	protected TextureBase ballTexture;

	protected float currentScale;

	protected Point3D center = Point3D.Origin;

	protected double[] projMatrix;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal float _0023_003DzoGvMfeZtKVwG;

	protected float lineSize = 1.5f;

	protected float thinLineSize = 1f;

	[Description("When false, the UI element is drawn with a flat color.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool Lighting
	{
		get
		{
			return _0023_003DzEn9I2TV2Q0f80jZYbQ_003D_003D;
		}
		set
		{
			_0023_003DzEn9I2TV2Q0f80jZYbQ_003D_003D = value;
		}
	}

	[Description("The edge color.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

	[Description("Label font.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual Font LabelFont
	{
		get
		{
			return _0023_003DzzmO0Pua6gdb0;
		}
		set
		{
			if (value != _0023_003DzzmO0Pua6gdb0)
			{
				if (disposeFont)
				{
					_0023_003DzzmO0Pua6gdb0.Dispose();
					disposeFont = false;
				}
				_0023_003DzzmO0Pua6gdb0 = value;
				osLabelAxisX.Font = value;
				osLabelAxisY.Font = value;
				osLabelAxisZ.Font = value;
				osLabelOrigin.Font = value;
			}
		}
	}

	[Description("The X label color.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual Color LabelColorX
	{
		get
		{
			return RenderContextUtility.ConvertColor(_0023_003DzYMt62Gq1KVD_);
		}
		set
		{
			if (!RenderContextUtility.AreEqual(value, _0023_003DzYMt62Gq1KVD_))
			{
				_0023_003DzYMt62Gq1KVD_ = RenderContextUtility.ConvertColor(value);
				osLabelAxisX.Color = value;
			}
		}
	}

	[Description("The Y label color.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual Color LabelColorY
	{
		get
		{
			return RenderContextUtility.ConvertColor(_0023_003DzwETrOyAwL0aA);
		}
		set
		{
			if (!RenderContextUtility.AreEqual(value, _0023_003DzwETrOyAwL0aA))
			{
				_0023_003DzwETrOyAwL0aA = RenderContextUtility.ConvertColor(value);
				osLabelAxisY.Color = value;
			}
		}
	}

	[Description("The Z label color.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual Color LabelColorZ
	{
		get
		{
			return RenderContextUtility.ConvertColor(_0023_003DzhHbXEP5q2zKc);
		}
		set
		{
			if (!RenderContextUtility.AreEqual(value, _0023_003DzhHbXEP5q2zKc))
			{
				_0023_003DzhHbXEP5q2zKc = RenderContextUtility.ConvertColor(value);
				osLabelAxisZ.Color = value;
			}
		}
	}

	[Description("The axis name label color.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual Color LabelColorName
	{
		get
		{
			return RenderContextUtility.ConvertColor(_0023_003DzA6bpkRXX6ek2);
		}
		set
		{
			if (!RenderContextUtility.AreEqual(value, _0023_003DzA6bpkRXX6ek2))
			{
				_0023_003DzA6bpkRXX6ek2 = RenderContextUtility.ConvertColor(value);
				osLabelOrigin.Color = value;
			}
		}
	}

	[Description("Color of the X axis arrow, applies only to the coordinate system style mode.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual Color ArrowColorX
	{
		get
		{
			return _0023_003Dzj0hgBHdyHzci(1);
		}
		set
		{
			_0023_003DzQ2mq1pAsFtsE(1, value);
		}
	}

	[Description("Color of the Y axis arrow, applies only to the coordinate system style mode.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual Color ArrowColorY
	{
		get
		{
			return _0023_003Dzj0hgBHdyHzci(2);
		}
		set
		{
			_0023_003DzQ2mq1pAsFtsE(2, value);
		}
	}

	[Description("Color of the Z axis arrow, applies only to the coordinate system style mode.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual Color ArrowColorZ
	{
		get
		{
			return _0023_003Dzj0hgBHdyHzci(3);
		}
		set
		{
			_0023_003DzQ2mq1pAsFtsE(3, value);
		}
	}

	[Description("The X axis label.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual string LabelAxisX
	{
		get
		{
			return osLabelAxisX.Text;
		}
		set
		{
			osLabelAxisX.Text = value;
		}
	}

	[Description("The Y axis label.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual string LabelAxisY
	{
		get
		{
			return osLabelAxisY.Text;
		}
		set
		{
			osLabelAxisY.Text = value;
		}
	}

	[Description("The Z axis label.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual string LabelAxisZ
	{
		get
		{
			return osLabelAxisZ.Text;
		}
		set
		{
			osLabelAxisZ.Text = value;
		}
	}

	[Description("The origin label.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual string LabelOrigin
	{
		get
		{
			return osLabelOrigin.Text;
		}
		set
		{
			osLabelOrigin.Text = value;
		}
	}

	protected virtual float LabelScale => GetScalingLevel().Height;

	protected virtual bool HasTextureCoords => false;

	[Obsolete("This constructor is deprecated.")]
	public CoordinateSystemBase(Font labelFont, Color labelColor, Color arrowColorX, Color arrowColorY, Color arrowColorZ, string labelOrigin, string labelAxisX, string labelAxisY, string labelAxisZ, bool visible, int size, Transformation transformation, bool lighting)
	{
		_0023_003DzH2wzlkSxe_0024nyl_0024wEBg_003D_003D(arrowColorX, arrowColorY, arrowColorZ);
		_0023_003DzshPEPAc_003D(null, labelFont, labelColor, labelColor, labelColor, labelColor, labelOrigin, labelAxisX, labelAxisY, labelAxisZ, visible, size, transformation, lighting);
		ArrowColorX = RenderContextUtility.ConvertColor(arrowColorX);
		ArrowColorY = RenderContextUtility.ConvertColor(arrowColorY);
		ArrowColorZ = RenderContextUtility.ConvertColor(arrowColorZ);
	}

	[Obsolete("This constructor is deprecated.")]
	public CoordinateSystemBase(Font labelFont, Color labelColorName, Color labelColorX, Color labelColorY, Color labelColorZ, Color arrowColorX, Color arrowColorY, Color arrowColorZ, string labelOrigin, string labelAxisX, string labelAxisY, string labelAxisZ, bool visible, int size, Transformation transformation, bool lighting)
	{
		_0023_003DzH2wzlkSxe_0024nyl_0024wEBg_003D_003D(arrowColorX, arrowColorY, arrowColorZ);
		_0023_003DzshPEPAc_003D(null, labelFont, labelColorName, labelColorX, labelColorY, labelColorZ, labelOrigin, labelAxisX, labelAxisY, labelAxisZ, visible, size, transformation, lighting);
		ArrowColorX = RenderContextUtility.ConvertColor(arrowColorX);
		ArrowColorY = RenderContextUtility.ConvertColor(arrowColorY);
		ArrowColorZ = RenderContextUtility.ConvertColor(arrowColorZ);
	}

	[Obsolete("This constructor is deprecated.")]
	public CoordinateSystemBase(Color labelColor, Color arrowColorX, Color arrowColorY, Color arrowColorZ, string labelOrigin, string labelAxisX, string labelAxisY, string labelAxisZ, bool visible, int size, Transformation transformation, bool lighting)
	{
		_0023_003DzH2wzlkSxe_0024nyl_0024wEBg_003D_003D(arrowColorX, arrowColorY, arrowColorZ);
		_0023_003DzshPEPAc_003D(null, null, labelColor, labelColor, labelColor, labelColor, labelOrigin, labelAxisX, labelAxisY, labelAxisZ, visible, size, transformation, lighting);
		ArrowColorX = RenderContextUtility.ConvertColor(arrowColorX);
		ArrowColorY = RenderContextUtility.ConvertColor(arrowColorY);
		ArrowColorZ = RenderContextUtility.ConvertColor(arrowColorZ);
	}

	[Obsolete("This constructor is deprecated.")]
	public CoordinateSystemBase(Color labelColorName, Color labelColorX, Color labelColorY, Color labelColorZ, Color arrowColorX, Color arrowColorY, Color arrowColorZ, string labelOrigin, string labelAxisX, string labelAxisY, string labelAxisZ, bool visible, int size, Transformation transformation, bool lighting)
	{
		_0023_003DzH2wzlkSxe_0024nyl_0024wEBg_003D_003D(arrowColorX, arrowColorY, arrowColorZ);
		_0023_003DzshPEPAc_003D(null, null, labelColorName, labelColorX, labelColorY, labelColorZ, labelOrigin, labelAxisX, labelAxisY, labelAxisZ, visible, size, transformation, lighting);
		ArrowColorX = RenderContextUtility.ConvertColor(arrowColorX);
		ArrowColorY = RenderContextUtility.ConvertColor(arrowColorY);
		ArrowColorZ = RenderContextUtility.ConvertColor(arrowColorZ);
	}

	private bool _0023_003DzpDSd4ZiVVBxIMNnMC58SjPE_003D()
	{
		return Lighting == _0023_003DzPCmn_0024Orgk2uCFrU0lA_003D_003D();
	}

	private void _0023_003DzUi_NH3uU71f_AaJ5Gg_003D_003D()
	{
		Lighting = _0023_003DzPCmn_0024Orgk2uCFrU0lA_003D_003D();
	}

	private bool _0023_003DzCHiptfgvMoLc()
	{
		return _0023_003DzUS40q9lzVpgV != _0023_003DzcL0q2vquhdai();
	}

	internal void _0023_003Dz7_f8kaanAepu()
	{
		_0023_003DzUS40q9lzVpgV = _0023_003DzcL0q2vquhdai();
	}

	internal static Font _0023_003Dz0UloR3WvSVa2()
	{
		return null;
	}

	internal static bool _0023_003DzPCmn_0024Orgk2uCFrU0lA_003D_003D()
	{
		return false;
	}

	internal static Color _0023_003Dz3S5baIME1gm5()
	{
		return Color.Black;
	}

	internal static Color _0023_003DzbDdW6a4epgga()
	{
		return Color.FromArgb(80, 80, 80);
	}

	internal static Color _0023_003DziMrsIbBBq4W7()
	{
		return Color.FromArgb(80, 80, 80);
	}

	internal static Color _0023_003DziR7d6jvIc0_0024g()
	{
		return Color.OrangeRed;
	}

	internal static Color _0023_003DzcL0q2vquhdai()
	{
		return Color.Black;
	}

	internal static string _0023_003DzBx1PgZeyDQQZuTHmfA_003D_003D()
	{
		return _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589185);
	}

	internal static string _0023_003DzGjMAP5saIKhANgf_JQ_003D_003D()
	{
		return _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589209);
	}

	internal static string _0023_003DzQyv5Z3I3aLpCHTQ9uQ_003D_003D()
	{
		return _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589201);
	}

	internal static string _0023_003Dzf_KTGHps4l6c()
	{
		return _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589225);
	}

	internal static coordinateSystemPositionType _0023_003DzPkO7IBwkBx9t()
	{
		return coordinateSystemPositionType.BottomLeft;
	}

	public override void ScaleForDPI()
	{
		base.ScaleForDPI();
		LabelFont = UtilityEx._0023_003DzowV4NhAf418J(LabelFont, disposeFont, UtilityEx.GetScalingLevel());
		disposeFont = true;
	}

	protected virtual void UpdateLabelFont(CoordinateSystemBase csb)
	{
		if (csb._0023_003DzzmO0Pua6gdb0 == null)
		{
			if (csb.ParentViewport != null && csb.ParentViewport._0023_003Dz0TvaYNo_003D != null)
			{
				csb._0023_003DzzmO0Pua6gdb0 = (Font)csb.ParentViewport._0023_003Dz0TvaYNo_003D.Font.Clone();
			}
			else
			{
				csb._0023_003DzzmO0Pua6gdb0 = (Font)System.Windows.Forms.Control.DefaultFont.Clone();
			}
			disposeFont = true;
		}
		if (csb.osLabelAxisX != null)
		{
			csb.osLabelAxisX.Font = csb.LabelFont;
			csb.osLabelAxisY.Font = csb.LabelFont;
			csb.osLabelAxisZ.Font = csb.LabelFont;
			csb.osLabelOrigin.Font = csb.LabelFont;
		}
	}

	private bool _0023_003Dz4GHZ6q89cfp5D9vR6g_003D_003D()
	{
		return LabelFont != null;
	}

	protected void ResetLabelFont()
	{
		LabelFont = _0023_003Dz0UloR3WvSVa2();
	}

	private bool _0023_003DzSoRKwksPRksL2BgQqg_003D_003D()
	{
		return !RenderContextUtility.AreEqual(LabelColorX, _0023_003Dz3S5baIME1gm5());
	}

	private void _0023_003DzHiJrTKg6nLcf()
	{
		LabelColorX = RenderContextUtility.ConvertColor(_0023_003Dz3S5baIME1gm5());
	}

	private bool _0023_003DzTejIhT_0024_alZKnXyIqA_003D_003D()
	{
		return !RenderContextUtility.AreEqual(LabelColorY, _0023_003Dz3S5baIME1gm5());
	}

	private void _0023_003DzoWn43LBfUdKD()
	{
		LabelColorY = RenderContextUtility.ConvertColor(_0023_003Dz3S5baIME1gm5());
	}

	private bool _0023_003DzyiYLN3vsXq0RSzpdbQ_003D_003D()
	{
		return !RenderContextUtility.AreEqual(LabelColorZ, _0023_003Dz3S5baIME1gm5());
	}

	private void _0023_003DzwBNHe9YGjqW7()
	{
		LabelColorZ = RenderContextUtility.ConvertColor(_0023_003Dz3S5baIME1gm5());
	}

	private bool _0023_003Dz4VoQkUnl37w6lKUx7g_003D_003D()
	{
		return !RenderContextUtility.AreEqual(LabelColorName, _0023_003Dz3S5baIME1gm5());
	}

	private void _0023_003DzFtORig7_00248O7T()
	{
		LabelColorName = RenderContextUtility.ConvertColor(_0023_003Dz3S5baIME1gm5());
	}

	private Color _0023_003Dzj0hgBHdyHzci(int _0023_003Dz_00dE54_003D)
	{
		if (_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D().Count > _0023_003Dz_00dE54_003D && _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[_0023_003Dz_00dE54_003D] is _0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D)
		{
			return _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[_0023_003Dz_00dE54_003D].Color;
		}
		return Color.Black;
	}

	private void _0023_003DzQ2mq1pAsFtsE(int _0023_003Dz_00dE54_003D, Color _0023_003DzsLHxXyo_003D)
	{
		if (_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D().Count > _0023_003Dz_00dE54_003D && _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[_0023_003Dz_00dE54_003D] is _0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D)
		{
			_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[_0023_003Dz_00dE54_003D].Color = _0023_003DzsLHxXyo_003D;
		}
	}

	private bool _0023_003Dz3DLHNd37lOSXkiM5ZQ_003D_003D()
	{
		return !RenderContextUtility.AreEqual(ArrowColorX, _0023_003DzbDdW6a4epgga());
	}

	private void _0023_003DzA8zlx4p26Vvx()
	{
		ArrowColorX = _0023_003DzbDdW6a4epgga();
	}

	private bool _0023_003Dz87eloSRJRxe8nyzFqA_003D_003D()
	{
		return !RenderContextUtility.AreEqual(ArrowColorY, _0023_003DziMrsIbBBq4W7());
	}

	private void _0023_003DzYn9nj99UJepX()
	{
		ArrowColorY = _0023_003DziMrsIbBBq4W7();
	}

	private bool _0023_003Dzc2RIBm_g2n3ZqCOPAg_003D_003D()
	{
		return !RenderContextUtility.AreEqual(ArrowColorZ, _0023_003DziR7d6jvIc0_0024g());
	}

	private void _0023_003DzziJAb6D1n_0024_h()
	{
		ArrowColorZ = _0023_003DziR7d6jvIc0_0024g();
	}

	private bool _0023_003DzFN7BnFKrs7FX2fOJsA_003D_003D()
	{
		return LabelAxisX != _0023_003DzBx1PgZeyDQQZuTHmfA_003D_003D();
	}

	private void _0023_003DzFtd_XmVl_i4L()
	{
		LabelAxisX = _0023_003DzBx1PgZeyDQQZuTHmfA_003D_003D();
	}

	private bool _0023_003DzHX8BWKYXPj8TdNh0lA_003D_003D()
	{
		return LabelAxisY != _0023_003DzGjMAP5saIKhANgf_JQ_003D_003D();
	}

	private void _0023_003Dzo4RJRRWWFeWU()
	{
		LabelAxisY = _0023_003DzGjMAP5saIKhANgf_JQ_003D_003D();
	}

	private bool _0023_003DzN1F66EXEe4fJurP2Sg_003D_003D()
	{
		return LabelAxisZ != _0023_003DzQyv5Z3I3aLpCHTQ9uQ_003D_003D();
	}

	private void _0023_003Dz_0024sA7OrYJRJ31()
	{
		LabelAxisZ = _0023_003DzQyv5Z3I3aLpCHTQ9uQ_003D_003D();
	}

	private bool _0023_003DzzLdWZMP9aU00qktc_0024A_003D_003D()
	{
		return LabelOrigin != _0023_003Dzf_KTGHps4l6c();
	}

	private void _0023_003DzpFdRshmubh4k()
	{
		LabelOrigin = _0023_003Dzf_KTGHps4l6c();
	}

	protected virtual void CreateLabels(RenderContextBase renderContext, Point3D posLabelAxisX, string textAxisX, Point3D posLabelAxisY, string textAxisY, Point3D posLabelAxisZ, string textAxisZ, Point3D posLabelOrigin, string textOrigin, Viewport viewport, ContentAlignment originNameAlignment = ContentAlignment.BottomLeft)
	{
		if (osLabelAxisX != null)
		{
			_0023_003DzWJESAsWl3WqT();
		}
		UpdateLabelFont(this);
		if (_0023_003DzEn9I2TV2Q0f80jZYbQ_003D_003D || viewport == null)
		{
			Color textColor = ((osLabelAxisX != null) ? RenderContextUtility.ConvertColor(osLabelAxisX.Color) : _0023_003DzYMt62Gq1KVD_);
			Color textColor2 = ((osLabelAxisY != null) ? RenderContextUtility.ConvertColor(osLabelAxisY.Color) : _0023_003DzwETrOyAwL0aA);
			Color textColor3 = ((osLabelAxisZ != null) ? RenderContextUtility.ConvertColor(osLabelAxisZ.Color) : _0023_003DzhHbXEP5q2zKc);
			osLabelAxisX = new TextOnly(posLabelAxisX, textAxisX, LabelFont, textColor);
			osLabelAxisY = new TextOnly(posLabelAxisY, textAxisY, LabelFont, textColor2);
			osLabelAxisZ = new TextOnly(posLabelAxisZ, textAxisZ, LabelFont, textColor3);
			osLabelOrigin = new TextOnly(posLabelOrigin, textOrigin, LabelFont, _0023_003DzA6bpkRXX6ek2, originNameAlignment);
		}
		else
		{
			Color textColor = viewport?.Background.GetContrastColor() ?? _0023_003DzYMt62Gq1KVD_;
			Color textColor2 = viewport?.Background.GetContrastColor() ?? _0023_003DzwETrOyAwL0aA;
			Color textColor3 = viewport?.Background.GetContrastColor() ?? _0023_003DzhHbXEP5q2zKc;
			Color contrastColorInverted = viewport.Background.GetContrastColorInverted();
			osLabelAxisX = new OutlinedText(posLabelAxisX, textAxisX, LabelFont, textColor, contrastColorInverted, ContentAlignment.BottomLeft);
			osLabelAxisY = new OutlinedText(posLabelAxisY, textAxisY, LabelFont, textColor2, contrastColorInverted, ContentAlignment.BottomLeft);
			osLabelAxisZ = new OutlinedText(posLabelAxisZ, textAxisZ, LabelFont, textColor3, contrastColorInverted, ContentAlignment.BottomLeft);
			osLabelOrigin = new OutlinedText(posLabelOrigin, textOrigin, LabelFont, viewport.Background.GetContrastColor(), contrastColorInverted, originNameAlignment);
		}
		_0023_003Dz1cbEsxrB_3T9(renderContext, LabelScale);
	}

	protected internal virtual void CreateLabels(Viewport viewport, RenderContextBase renderContext)
	{
	}

	protected internal virtual void UpdateTexturesForScaledDrawing(RenderContextBase renderContext, double drawScale)
	{
		osLabelOrigin.Regen(renderContext, (float)drawScale);
		osLabelAxisX.Regen(renderContext, (float)drawScale);
		osLabelAxisY.Regen(renderContext, (float)drawScale);
		osLabelAxisZ.Regen(renderContext, (float)drawScale);
	}

	public override void Update(IUserInterfaceElement another)
	{
		CoordinateSystemBase coordinateSystemBase = (CoordinateSystemBase)another;
		_0023_003DzshPEPAc_003D(null, coordinateSystemBase._0023_003DzzmO0Pua6gdb0, coordinateSystemBase._0023_003DzA6bpkRXX6ek2, coordinateSystemBase._0023_003DzYMt62Gq1KVD_, coordinateSystemBase._0023_003DzwETrOyAwL0aA, coordinateSystemBase._0023_003DzhHbXEP5q2zKc, RenderContextUtility.ConvertColor(coordinateSystemBase.ArrowColorX), RenderContextUtility.ConvertColor(coordinateSystemBase.ArrowColorY), RenderContextUtility.ConvertColor(coordinateSystemBase.ArrowColorZ), coordinateSystemBase.LabelOrigin, coordinateSystemBase.LabelAxisX, coordinateSystemBase.LabelAxisY, coordinateSystemBase.LabelAxisZ, coordinateSystemBase.Visible, coordinateSystemBase._0023_003DzgTjCWc4_003D, coordinateSystemBase.Transformation, coordinateSystemBase.Lighting);
	}

	internal void _0023_003DzshPEPAc_003D(RenderContextBase _0023_003DzmNZD0Zs_003D, Font _0023_003DzzaS7QbD7HEzS, Color _0023_003DzACHjCKxTYSss, Color _0023_003DzfFzPWnUjJ3vg, Color _0023_003Dz6_BNK83e21oi, Color _0023_003DzDOgN6zG0tI2u, string _0023_003DzgoPhbTbN_0024wyd, string _0023_003Dztz5sw4jD4OoG, string _0023_003DzJoAuDAilqjE_0024, string _0023_003Dznx3uaJaOu6Ua, bool _0023_003DzbWHNjOg_003D, int _0023_003Dz0ERMHbg_003D, Transformation _0023_003DzHAHtzrODquwUmzF8XyRAeRo_003D, bool _0023_003DzUuC7n1U7RpSVakVO4A_003D_003D)
	{
		_0023_003DzA6bpkRXX6ek2 = _0023_003DzACHjCKxTYSss;
		_0023_003DzYMt62Gq1KVD_ = _0023_003DzfFzPWnUjJ3vg;
		_0023_003DzwETrOyAwL0aA = _0023_003Dz6_BNK83e21oi;
		_0023_003DzhHbXEP5q2zKc = _0023_003DzDOgN6zG0tI2u;
		_0023_003DzzmO0Pua6gdb0 = _0023_003DzzaS7QbD7HEzS;
		base.Visible = _0023_003DzbWHNjOg_003D;
		Lighting = _0023_003DzUuC7n1U7RpSVakVO4A_003D_003D;
		Size = _0023_003Dz0ERMHbg_003D;
		Transformation = _0023_003DzHAHtzrODquwUmzF8XyRAeRo_003D;
		CreateLabels(_0023_003DzmNZD0Zs_003D, Point3D.Origin, _0023_003Dztz5sw4jD4OoG, Point3D.Origin, _0023_003DzJoAuDAilqjE_0024, Point3D.Origin, _0023_003Dznx3uaJaOu6Ua, Point3D.Origin, _0023_003DzgoPhbTbN_0024wyd, null);
	}

	private void _0023_003DzshPEPAc_003D(RenderContextBase _0023_003DzmNZD0Zs_003D, Font _0023_003DzzaS7QbD7HEzS, Color _0023_003DzACHjCKxTYSss, Color _0023_003DzfFzPWnUjJ3vg, Color _0023_003Dz6_BNK83e21oi, Color _0023_003DzDOgN6zG0tI2u, Color _0023_003DzTAZU5Rc0zTox, Color _0023_003Dzp43RmdXIwWW7, Color _0023_003DzyUq9qUUCUWAl, string _0023_003DzgoPhbTbN_0024wyd, string _0023_003Dztz5sw4jD4OoG, string _0023_003DzJoAuDAilqjE_0024, string _0023_003Dznx3uaJaOu6Ua, bool _0023_003DzbWHNjOg_003D, int _0023_003Dz0ERMHbg_003D, Transformation _0023_003DzHAHtzrODquwUmzF8XyRAeRo_003D, bool _0023_003DzUuC7n1U7RpSVakVO4A_003D_003D)
	{
		_0023_003DzshPEPAc_003D(_0023_003DzmNZD0Zs_003D, _0023_003DzzaS7QbD7HEzS, _0023_003DzACHjCKxTYSss, _0023_003DzfFzPWnUjJ3vg, _0023_003Dz6_BNK83e21oi, _0023_003DzDOgN6zG0tI2u, _0023_003DzgoPhbTbN_0024wyd, _0023_003Dztz5sw4jD4OoG, _0023_003DzJoAuDAilqjE_0024, _0023_003Dznx3uaJaOu6Ua, _0023_003DzbWHNjOg_003D, _0023_003Dz0ERMHbg_003D, _0023_003DzHAHtzrODquwUmzF8XyRAeRo_003D, _0023_003DzUuC7n1U7RpSVakVO4A_003D_003D);
		ArrowColorX = RenderContextUtility.ConvertColor(_0023_003DzTAZU5Rc0zTox);
		ArrowColorY = RenderContextUtility.ConvertColor(_0023_003Dzp43RmdXIwWW7);
		ArrowColorZ = RenderContextUtility.ConvertColor(_0023_003DzyUq9qUUCUWAl);
	}

	internal void _0023_003DzH2wzlkSxe_0024nyl_0024wEBg_003D_003D(Color _0023_003DzTAZU5Rc0zTox, Color _0023_003Dzp43RmdXIwWW7, Color _0023_003DzyUq9qUUCUWAl)
	{
		_0023_003DzJ68739VSGtxjhT1AxA_003D_003D(new EyeshotDisposableCollection<Mesh>());
		string defaultLayerName = GetDefaultLayerName();
		_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D().AddRange(new Mesh[4]
		{
			new _0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D(defaultLayerName, HasTextureCoords ? Mesh.natureType.RichSmooth : Mesh.natureType.Smooth, 1.0, 0.0, Vector3D.AxisX, (_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D._0023_003DzemvFlrg_003D)0),
			new _0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D(defaultLayerName, Mesh.natureType.Smooth, 2.0 / 9.0, 0.0, Vector3D.AxisX, (_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D._0023_003DzemvFlrg_003D)1),
			new _0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D(defaultLayerName, Mesh.natureType.Smooth, 2.0 / 9.0, 90.0, Vector3D.AxisZ, (_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D._0023_003DzemvFlrg_003D)2),
			new _0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D(defaultLayerName, Mesh.natureType.Smooth, 2.0 / 9.0, -90.0, Vector3D.AxisY, (_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D._0023_003DzemvFlrg_003D)3)
		});
		_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[0].Color = _0023_003DzTAZU5Rc0zTox;
		_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[1].Color = _0023_003DzTAZU5Rc0zTox;
		_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[2].Color = _0023_003Dzp43RmdXIwWW7;
		_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[3].Color = _0023_003DzyUq9qUUCUWAl;
	}

	public override void Dispose()
	{
		base.Dispose();
		if (_0023_003DzzmO0Pua6gdb0 != null && disposeFont)
		{
			_0023_003DzzmO0Pua6gdb0.Dispose();
			disposeFont = false;
			_0023_003DzzmO0Pua6gdb0 = null;
		}
		if (osLabelAxisX != null)
		{
			osLabelAxisX.Dispose();
			osLabelAxisY.Dispose();
			osLabelAxisZ.Dispose();
			osLabelOrigin.Dispose();
		}
		drawSphere?.Dispose();
		drawArrow?.Dispose();
	}

	private void _0023_003DzSJDeNOUaWXnt(RenderContextBase _0023_003DzmNZD0Zs_003D)
	{
		if (drawSphere == null)
		{
			drawSphere = _0023_003DzmNZD0Zs_003D.CreateEntityGraphicsData(this);
		}
		if (drawArrow == null)
		{
			drawArrow = _0023_003DzmNZD0Zs_003D.CreateEntityGraphicsData(this);
		}
	}

	internal virtual void _0023_003Dz8WTvZ9I_003D(Workspace _0023_003DzU0f5_qE_003D, TextureBase _0023_003DzrRiTzRDcSNK7)
	{
		_0023_003DzSJDeNOUaWXnt(_0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D);
		ballTexture = _0023_003DzrRiTzRDcSNK7;
		_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D().SetDocument(_0023_003DzU0f5_qE_003D.Document);
		if (osLabelAxisX == null || osLabelAxisX.RegenMode != regenType.NotNeeded)
		{
			if (_0023_003DzU0f5_qE_003D._0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D != null)
			{
				foreach (Viewport item in _0023_003DzU0f5_qE_003D._0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D)
				{
					CreateLabels(item, _0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D);
				}
			}
		}
		else if (osLabelAxisX.Image == null)
		{
			_0023_003Dz1cbEsxrB_3T9(_0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D, LabelScale);
		}
		CompileParams compileParams = new CompileParams(_0023_003DzU0f5_qE_003D);
		if (_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D().Count >= 4)
		{
			if (_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[0] is _0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D)
			{
				PointF[] _0023_003Dz7FFO_uoPntMcFlzO_Q_003D_003D = null;
				Point3D[] _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D;
				IndexTriangle[] _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D;
				Vector3D[] _0023_003Dz2pcdJKEqM3of;
				if (HasTextureCoords)
				{
					UtilityEx._0023_003Dzr_u_0024IHWHVAAGbXbZAg_003D_003D(1.0, 16, Lighting ? 8 : 32, HasTextureCoords, out _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, out _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D, out _0023_003Dz2pcdJKEqM3of, out _0023_003Dz7FFO_uoPntMcFlzO_Q_003D_003D);
				}
				else
				{
					Joint joint = new Joint(0.0, 0.0, 0.0, 1.0, 2);
					joint.Regen(0.0);
					for (int i = 0; i < joint.Triangles.Length; i++)
					{
						joint.Triangles[i] = new SmoothTriangle(joint.Triangles[i].V1, joint.Triangles[i].V2, joint.Triangles[i].V3);
					}
					Mesh mesh = new Mesh(joint.Vertices, joint.Triangles);
					mesh.NormalAveragingMode = Mesh.normalAveragingType.Averaged;
					mesh.Regen(0.0);
					_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D = mesh.Vertices;
					_0023_003Dzzmih36dAiKNDCev9Mg_003D_003D = mesh.Triangles;
					_0023_003Dz2pcdJKEqM3of = mesh.Normals;
				}
				_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[0].Vertices = _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D;
				_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[0].Triangles = _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D;
				_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[0].Normals = _0023_003Dz2pcdJKEqM3of;
				if (HasTextureCoords)
				{
					_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[0].TextureCoords = _0023_003Dz7FFO_uoPntMcFlzO_Q_003D_003D;
				}
				_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[0].Compile(compileParams);
				drawSphere = _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[0].drawData;
			}
			bool flag = false;
			for (int j = 1; j < 4; j++)
			{
				if (_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[j] is _0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				Mesh mesh2 = OptimizedArrow(compileParams, Lighting ? 1.6 : 1.5, 15.8, 4.5, 16.0);
				mesh2.Translate(4.2, 0.0);
				_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[1].Vertices = mesh2.Vertices;
				_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[1].Triangles = mesh2.Triangles;
				_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[1].Normals = mesh2.Normals;
				_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[1].Edges = mesh2.Edges;
				_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[1].Compile(compileParams);
				drawArrow = _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[1].drawData;
				for (int k = 2; k < 4; k++)
				{
					if (_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[k] is _0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D)
					{
						((_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D)_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[k])._0023_003DzcJIdS_jd32ls = (_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D)_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[1];
					}
				}
				mesh2.Dispose();
				mesh2 = null;
			}
		}
		List<Point3D> list = new List<Point3D>();
		foreach (Mesh item2 in _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D())
		{
			if (!(item2 is _0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D))
			{
				item2.UpdateBoundingBox(null);
				list.Add(item2.BoxMin);
				list.Add(item2.BoxMax);
			}
		}
		if (list.Count <= 0)
		{
			return;
		}
		foreach (Mesh item3 in _0023_003Dz144AJpBY58Hz)
		{
			if (!(item3 is _0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D))
			{
				if (item3.Normals == null)
				{
					item3.Regen(1.0);
				}
				item3.Compile(compileParams);
			}
		}
	}

	protected Mesh OptimizedArrow(CompileParams cp, double cylRadius, double cylLength, double coneRadius, double coneLength)
	{
		Mesh mesh = Mesh.CreateArrow(cylRadius, cylLength, coneRadius, coneLength, 16, Mesh.natureType.Smooth);
		mesh.Regen(0.0);
		double num = cylRadius * 0.1;
		Mesh mesh2 = new Line(-2.0, num, 0.0, cylRadius).RevolveAsMesh(0.0, Math.PI * 2.0, Vector3D.AxisX, Point3D.Origin, 16, 0.0, Mesh.natureType.Smooth);
		mesh2.Regen(0.0);
		mesh.MergeWith(mesh2);
		for (int i = 0; i < mesh._vertices.Length; i++)
		{
			if (mesh._vertices[i].X == -2.0)
			{
				mesh._vertices[i] = (new Vector3D(new Point3D(-2.0, 0.0, 0.0), mesh._vertices[i]) * cylRadius / num).AsPoint;
				mesh._vertices[i].X = -2.0;
			}
		}
		mesh.Compile(cp);
		return mesh;
	}

	protected virtual void DrawPlain(DrawParams drawParams)
	{
		for (int i = 0; i < _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D().Count; i++)
		{
			Entity entity = _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[i];
			if (!entity.Visible)
			{
				continue;
			}
			Color color = ((!entity.Selectable) ? Utility.GetFrozenColor(entity.Color) : ((!entity.Selected) ? entity.Color : drawParams.SelectionColor));
			if (!Lighting)
			{
				if (!(this is CoordinateSystemIcon))
				{
					drawParams.RenderContext.SetColorWireframe(color);
				}
			}
			else
			{
				drawParams.RenderContext.SetMaterialFrontDiffuse(color);
			}
			((IEntityInternal)entity).Draw(drawParams);
		}
	}

	protected internal virtual float UpdateScreenToWorld(Viewport viewport, int[] layoutViewport)
	{
		return _0023_003DzoGvMfeZtKVwG = 0f;
	}

	protected virtual Transformation GetInitialTransformation()
	{
		return new Identity();
	}

	protected Transformation GetFullTransformation()
	{
		Transformation transformation = ((!(Transformation != null)) ? new Identity() : Transformation);
		double num = currentScale;
		double num2 = currentScale;
		double num3 = currentScale;
		if (Transformation != null)
		{
			num /= Transformation.ScaleFactorX;
			num2 /= Transformation.ScaleFactorY;
			num3 /= Transformation.ScaleFactorZ;
		}
		return transformation * new Translation(center.X, center.Y, center.Z) * new Scaling(num, num2, num3);
	}

	internal void _0023_003DzKa9hVOo_003D(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024, bool _0023_003DzTdL_tg3V5Mp84BhbAA_003D_003D)
	{
		currentScale = _0023_003DzoGvMfeZtKVwG * _0023_003DzCBM7XJK4_5H_0024.DrawScale * (float)Size;
		Point3D boxMin = new Point3D(-1.0, -1.0, -1.0);
		Point3D boxMax = new Point3D(1.0, 1.0, 1.0);
		if (!_0023_003DzTdL_tg3V5Mp84BhbAA_003D_003D)
		{
			boxMin *= 17.0;
			boxMax *= 17.0;
		}
		Utility.GetBoundingBoxTransformed(GetFullTransformation(), boxMin, boxMax, out boxMin, out boxMax);
		UtilityEx._0023_003DzLlW7aSdsQyHy(_0023_003DzCBM7XJK4_5H_0024.Viewport.Camera, Utility.GetBoundingBoxCorners(boxMin, boxMax), out var _0023_003Dz8SiEeqqjUObS, out var _0023_003DzVbNvU5kkJhqV);
		_0023_003Dz8SiEeqqjUObS = _0023_003DzCBM7XJK4_5H_0024.Viewport.Camera.LimitNearFor3DAnaglyph(_0023_003Dz8SiEeqqjUObS);
		if (_0023_003DzCBM7XJK4_5H_0024.Viewport.Camera.ProjectionMode == projectionType.Perspective && (_0023_003Dz8SiEeqqjUObS < 0.0 || _0023_003DzVbNvU5kkJhqV < 0.0))
		{
			projMatrix = null;
		}
		else
		{
			projMatrix = _0023_003DzCBM7XJK4_5H_0024.Viewport.Camera.GetProjectionMatrix(_0023_003Dz8SiEeqqjUObS, _0023_003DzVbNvU5kkJhqV, _0023_003DzCBM7XJK4_5H_0024.CameraEyePos);
		}
	}

	internal virtual bool _0023_003Dz89cPk57rASTGmdmTnA_003D_003D(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024, bool _0023_003DzpIzHYHy1ug2w, bool _0023_003DzTdL_tg3V5Mp84BhbAA_003D_003D)
	{
		if (projMatrix == null)
		{
			_0023_003DzKa9hVOo_003D(_0023_003DzCBM7XJK4_5H_0024, _0023_003DzTdL_tg3V5Mp84BhbAA_003D_003D: false);
			if (projMatrix == null)
			{
				return false;
			}
		}
		Transformation customProjectionMatrix = _0023_003DzCBM7XJK4_5H_0024.Viewport.Camera.GetCustomProjectionMatrix(projMatrix);
		_0023_003DzCBM7XJK4_5H_0024.RenderContext.SetMatrices(null, null);
		if (_0023_003DzpIzHYHy1ug2w)
		{
			SetupLights((Viewport)_0023_003DzCBM7XJK4_5H_0024.Viewport, _0023_003DzCBM7XJK4_5H_0024.RenderContext, 0.75f);
		}
		_0023_003DzCBM7XJK4_5H_0024.Viewport.Camera.SetupModelView(setGraphics: true, reflection: false, _0023_003DzCBM7XJK4_5H_0024.CameraEyePos, applySceneTransformation: false);
		Transformation transformation = new Transformation(_0023_003DzCBM7XJK4_5H_0024.Viewport.Camera.ModelViewMatrix, byRow: false) * GetFullTransformation();
		_0023_003DzCBM7XJK4_5H_0024.RenderContext.SetMatrices(customProjectionMatrix.MatrixAsVectorByColumn, transformation.MatrixAsVectorByColumn);
		if (_0023_003DzCBM7XJK4_5H_0024.ShaderParams != null)
		{
			_0023_003DzCBM7XJK4_5H_0024.ShaderParams.ResetBlockRefTransform();
		}
		return true;
	}

	protected internal override void DrawInternal(DrawSceneParams data)
	{
		UpdateScreenToWorld((Viewport)data.Viewport, data.ViewFrame);
		_0023_003DzKa9hVOo_003D(data, _0023_003DzTdL_tg3V5Mp84BhbAA_003D_003D: false);
		RenderParams renderParams = new RenderParams(data.Viewport, data.Blocks);
		data.RenderContext.SetShader(shaderType.Standard);
		if (!_0023_003Dz89cPk57rASTGmdmTnA_003D_003D(data, _0023_003DzpIzHYHy1ug2w: true, _0023_003DzTdL_tg3V5Mp84BhbAA_003D_003D: false))
		{
			return;
		}
		data.RenderContext.Shaders[shaderType.Standard].UpdatedInFrame = false;
		data.RenderContext.CurrentShaderTechnique.Shader.SetParameters(data.ShaderParams);
		if (projMatrix != null)
		{
			if (((ObjectManipulator)data.viewportInternal.parent.ObjectManipulator).Dragging)
			{
				PreDrawOnDepthBuffer(renderParams.RenderContext);
				Draw(renderParams);
				PostDrawOnDepthBuffer(renderParams.RenderContext);
			}
			renderParams.RenderContext.SetState(depthStencilStateType.DepthTestLessEqual);
			Draw(renderParams);
			renderParams.RenderContext.SetState(depthStencilStateType.DepthTestLess);
		}
		if (!data.RenderContext.IsDirect3D)
		{
			data.RenderContext.SetLightStatus(4, active: false);
			data.RenderContext.SetLightStatus(5, active: false);
		}
	}

	public override void Draw(RenderParams data)
	{
		data.RenderContext.SetLighting(Lighting);
		data.RenderContext.SetState(rasterizerStateType.CCW_PolygonFill_CullFaceBack_NoPolygonOffset);
		data.RenderContext.PushMatrices();
		Workspace workspace = (Workspace)data.viewportInternal.parent;
		if (!Lighting)
		{
			data.RenderContext.SetShader(shaderType.NoLights);
			data.RenderContext.PushRasterizerState();
			data.RenderContext.SetState(rasterizerStateType.CCW_PolygonFill_CullFaceBack_PolygonOffset_1_1);
		}
		else
		{
			data.RenderContext.SetMaterial(workspace._0023_003Dzxpbv4lQ_003D.Diffuse, workspace._0023_003Dzxpbv4lQ_003D.Diffuse, workspace._0023_003Dzxpbv4lQ_003D.Ambient, workspace._0023_003Dzxpbv4lQ_003D.Specular, workspace._0023_003Dzxpbv4lQ_003D.Shininess);
		}
		DrawPlain(data);
		if (!Lighting)
		{
			DrawEdgesAndSilho(data);
			data.RenderContext.PopRasterizerState();
		}
		data.RenderContext.PopMatrices();
	}

	protected void DrawEdgesAndSilho(RenderParams data)
	{
		if (!Lighting)
		{
			data.RenderContext.SetColorWireframe(((BackgroundSettings)data.Viewport.Background).GetContrastColorInverted());
		}
		else
		{
			data.RenderContext.SetColorWireframe(_0023_003DzUS40q9lzVpgV);
		}
		double[] a = data.RenderContext.CurrentModelViewMatrix();
		double[] b = data.RenderContext.CurrentProjectionMatrix();
		double[] modelViewProj = Utility.MultMatrixd(a, b);
		DrawSilhouettesParams data2 = new DrawSilhouettesParams(data.Viewport, data.viewportInternal.parent.Blocks, projectionType.Orthographic, modelViewProj, data.ScreenToWorld);
		data.RenderContext.SetLineSize(lineSize, setShader: true, force: true);
		data.RenderContext.UpdateConstantBufferPerFrame();
		foreach (Mesh item in _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D())
		{
			if (((IEntity)item).Visible)
			{
				((IEntityInternal)item).DrawSilhouettes(data2);
			}
		}
		data.RenderContext.SetLineSize(thinLineSize);
		foreach (Mesh item2 in _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D())
		{
			if (((IEntity)item2).Visible)
			{
				((IEntityInternal)item2).DrawEdges((DrawParams)data2);
			}
		}
	}

	internal virtual void _0023_003Dz1lQiK8IwvEb9(RenderContextBase _0023_003DzmNZD0Zs_003D, Camera _0023_003Dz5rO44GFvhrL3, float _0023_003DzCzsr4CTVr_Ea, int[] _0023_003DzBppTnBIbeUl7)
	{
		if (_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D().Count > 1 && _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[1].Visible)
		{
			osLabelAxisX.Draw(_0023_003DzmNZD0Zs_003D, _0023_003DzCzsr4CTVr_Ea);
		}
		if (_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D().Count > 2 && _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[2].Visible)
		{
			osLabelAxisY.Draw(_0023_003DzmNZD0Zs_003D, _0023_003DzCzsr4CTVr_Ea);
		}
		if (_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D().Count > 3 && _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[3].Visible)
		{
			osLabelAxisZ.Draw(_0023_003DzmNZD0Zs_003D, _0023_003DzCzsr4CTVr_Ea);
		}
	}

	private void _0023_003DzWJESAsWl3WqT()
	{
		osLabelAxisX.Dispose();
		osLabelAxisY.Dispose();
		osLabelAxisZ.Dispose();
		osLabelOrigin.Dispose();
		osLabelAxisX = null;
		osLabelAxisY = null;
		osLabelAxisZ = null;
		osLabelOrigin = null;
	}

	internal virtual void _0023_003Dz1cbEsxrB_3T9(RenderContextBase _0023_003DzmNZD0Zs_003D, float _0023_003DzW_Mwciw_003D)
	{
		float drawScale = _0023_003DzW_Mwciw_003D / GetScalingLevel().Height;
		osLabelOrigin.Regen(_0023_003DzmNZD0Zs_003D, drawScale);
		osLabelAxisX.Regen(_0023_003DzmNZD0Zs_003D, drawScale);
		osLabelAxisY.Regen(_0023_003DzmNZD0Zs_003D, drawScale);
		osLabelAxisZ.Regen(_0023_003DzmNZD0Zs_003D, drawScale);
	}

	internal double[] _0023_003DzUiFXEqJwC41M(double[] _0023_003Dz2tkNFuo_003D)
	{
		if (Transformation != null)
		{
			_0023_003Dz2tkNFuo_003D = Utility.MultMatrixd(Transformation.MatrixAsVectorByColumn, _0023_003Dz2tkNFuo_003D);
		}
		return _0023_003Dz2tkNFuo_003D;
	}
}
