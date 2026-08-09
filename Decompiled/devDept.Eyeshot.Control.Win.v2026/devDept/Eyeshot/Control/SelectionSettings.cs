using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using devDept.Geometry;

namespace devDept.Eyeshot.Control;

public class SelectionSettings : ISelectionSettings
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003DzZE7cepnMKKeB8RG9Sw_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003DzO3S8AgstFxeqDHKscX3lYC4_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003Dz4ePyP_I8B8_zJgC5O3iYoFc_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003Dz7CL1fUJEH7SVUk_gtg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003Dzft5thAtNT9yePxrNz0Ai1JZk8mmQ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003DzwYXp1upCDGVMBSaReYDukUOaPrSV;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float _0023_003DzX7tBv6hZNIBHrV4kXQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzFvN23ni1I56hTlRFiJCC5JY_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzDAqJXAzsuwQb4tZN1r7efPM_003D;

	public Color Color
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzZE7cepnMKKeB8RG9Sw_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzZE7cepnMKKeB8RG9Sw_003D_003D = value;
		}
	}

	public Color HaloInnerColor
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzO3S8AgstFxeqDHKscX3lYC4_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzO3S8AgstFxeqDHKscX3lYC4_003D = value;
		}
	}

	public Color HaloOuterColor
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz4ePyP_I8B8_zJgC5O3iYoFc_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz4ePyP_I8B8_zJgC5O3iYoFc_003D = value;
		}
	}

	public Color ColorDynamic
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz7CL1fUJEH7SVUk_gtg_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz7CL1fUJEH7SVUk_gtg_003D_003D = value;
		}
	}

	public Color HaloInnerColorDynamic
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzft5thAtNT9yePxrNz0Ai1JZk8mmQ;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzft5thAtNT9yePxrNz0Ai1JZk8mmQ = value;
		}
	}

	public Color HaloOuterColorDynamic
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzwYXp1upCDGVMBSaReYDukUOaPrSV;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzwYXp1upCDGVMBSaReYDukUOaPrSV = value;
		}
	}

	public float LineWeightScaleFactor
	{
		get
		{
			return _0023_003DzX7tBv6hZNIBHrV4kXQ_003D_003D;
		}
		set
		{
			_0023_003DzX7tBv6hZNIBHrV4kXQ_003D_003D = value;
			if (_0023_003DzX7tBv6hZNIBHrV4kXQ_003D_003D <= 0f)
			{
				throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348593168));
			}
		}
	}

	public int HaloWidthPolygons
	{
		get
		{
			return _0023_003DzFvN23ni1I56hTlRFiJCC5JY_003D;
		}
		set
		{
			_0023_003DzFvN23ni1I56hTlRFiJCC5JY_003D = value;
			Utility.LimitRange(0, ref _0023_003DzFvN23ni1I56hTlRFiJCC5JY_003D, 4);
		}
	}

	public int HaloWidthWires
	{
		get
		{
			return _0023_003DzDAqJXAzsuwQb4tZN1r7efPM_003D;
		}
		set
		{
			_0023_003DzDAqJXAzsuwQb4tZN1r7efPM_003D = value;
			Utility.LimitRange(0, ref _0023_003DzDAqJXAzsuwQb4tZN1r7efPM_003D, 4);
		}
	}

	public SelectionSettings(Color color, Color haloInnerColor, Color haloOuterColor, Color colorDynamic, Color haloInnerColorDynamic, Color haloOuterColorDynamic, float lineWeightScaleFactor, int haloWidthPolygons, int haloWidthWires)
	{
		_0023_003Dz3q1x_lkzCKr3hY_BuQ_003D_003D._0023_003DzL07WkTo_003D _0023_003DzL07WkTo_003D = (_0023_003Dz3q1x_lkzCKr3hY_BuQ_003D_003D._0023_003DzL07WkTo_003D)0;
		object[] array = null;
		array = new object[1] { _0023_003DzL07WkTo_003D };
		_0023_003DzyhuoqeH8sA2fipOFVu_0024vNrvZ5baZl1cB7KAOHYNB1gCDLfwzSg_003D_003D._0023_003DzJFvCOLF47QY9KjaoNO2URxP_00249fg9qG9I_0024MUMd5p_0024tKrBmG2JgA_003D_003D()._0023_003DzPpVzJh2WmrmhWqXh9NNYr_0024sLr3Oq(_0023_003DzyhuoqeH8sA2fipOFVu_0024vNrvZ5baZl1cB7KAOHYNB1gCDLfwzSg_003D_003D._0023_003Dzc3Qn0OgNn7PNyXPUMe9oTNMJcU481onqr2l7palyXDkZrhZNbQ_003D_003D(), "M#I>Qq\"ad(", array);
		Color = color;
		HaloInnerColor = haloInnerColor;
		HaloOuterColor = haloOuterColor;
		ColorDynamic = colorDynamic;
		HaloInnerColorDynamic = haloInnerColorDynamic;
		HaloOuterColorDynamic = haloOuterColorDynamic;
		LineWeightScaleFactor = lineWeightScaleFactor;
		HaloWidthPolygons = haloWidthPolygons;
		HaloWidthWires = haloWidthWires;
	}

	public SelectionSettings()
		: this(_0023_003Dz3S5baIME1gm5(), _0023_003DzaGl3Hp8s6oGZ84qGIg_003D_003D(), _0023_003Dzk_iEhJ4f_036TA8dyQ_003D_003D(), _0023_003DzFnGxyKAz69Vq(), _0023_003DzYcxEEMHsHJ6_o_My0ntOp4k_003D(), _0023_003DzqG0IODNQ2aTyxC6yq5Hu3oE_003D(), _0023_003Dzv8BykSbeEVpnPb7DBw_003D_003D(), _0023_003Dzp7ugfBBUww6K4U0XF11Zs553bSv4(), _0023_003DzP4QyJZ75Gkp7QwKvOOsmuDo_003D())
	{
	}

	internal static Color _0023_003Dz3S5baIME1gm5()
	{
		return Color.FromArgb(80, Color.Gold);
	}

	private static Color _0023_003DzaGl3Hp8s6oGZ84qGIg_003D_003D()
	{
		return Color.Gold;
	}

	private static Color _0023_003Dzk_iEhJ4f_036TA8dyQ_003D_003D()
	{
		return Color.FromArgb(255, Color.Gold);
	}

	internal static Color _0023_003DzFnGxyKAz69Vq()
	{
		return Color.FromArgb(80, Color.OrangeRed);
	}

	private static Color _0023_003DzYcxEEMHsHJ6_o_My0ntOp4k_003D()
	{
		return Color.OrangeRed;
	}

	private static Color _0023_003DzqG0IODNQ2aTyxC6yq5Hu3oE_003D()
	{
		return Color.OrangeRed;
	}

	internal static float _0023_003Dzv8BykSbeEVpnPb7DBw_003D_003D()
	{
		return 1f;
	}

	private static int _0023_003Dzp7ugfBBUww6K4U0XF11Zs553bSv4()
	{
		return 2;
	}

	private static int _0023_003DzP4QyJZ75Gkp7QwKvOOsmuDo_003D()
	{
		return 1;
	}
}
