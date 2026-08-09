using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using devDept.Geometry;
using devDept.Graphics;

namespace devDept.Eyeshot.Control;

[TypeConverter(typeof(LegendItemConverter))]
public class LegendItem : ICloneable
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzRAH3IbiWW3MyKWPbqQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzwR3Bph0knP45pTU5Cw_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003DzZE7cepnMKKeB8RG9Sw_003D_003D;

	[Description("The legend item width.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int Width
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzRAH3IbiWW3MyKWPbqQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzRAH3IbiWW3MyKWPbqQ_003D_003D = value;
		}
	}

	[Description("The legend item height.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int Height
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzwR3Bph0knP45pTU5Cw_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzwR3Bph0knP45pTU5Cw_003D_003D = value;
		}
	}

	[Description("The legend item color.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

	public LegendItem()
		: this(RenderContextUtility.ConvertColor(Legend._0023_003DzaiEN3rzYDoWa()))
	{
	}

	public LegendItem(Color color)
		: this(Legend._0023_003DzpDYcwH01f_0024GA().Width, Legend._0023_003DzpDYcwH01f_0024GA().Height, color)
	{
	}

	public LegendItem(int width, int height, Color color)
	{
		Width = width;
		Height = height;
		Color = color;
		_0023_003DzUMSSRSw_003D();
	}

	public LegendItem(int width, int height, float red, float green, float blue)
	{
		Width = width;
		Height = height;
		Color = Color.FromArgb((int)red * 255, (int)green * 255, (int)blue * 255);
		_0023_003DzUMSSRSw_003D();
	}

	protected LegendItem(LegendItem another)
	{
		Width = another.Width;
		Height = another.Height;
		Color = another.Color;
		_0023_003DzUMSSRSw_003D();
	}

	private bool _0023_003DzaV3bh_j9bma7()
	{
		return Width != Legend._0023_003DzpDYcwH01f_0024GA().Width;
	}

	private void _0023_003Dzmcuf9gqQ8U7g()
	{
		Width = Legend._0023_003DzpDYcwH01f_0024GA().Width;
	}

	private bool _0023_003Dzafe_gw_aRT6o()
	{
		return Height != Legend._0023_003DzpDYcwH01f_0024GA().Height;
	}

	private void _0023_003Dz0R0CUtrqGlZX()
	{
		Height = Legend._0023_003DzpDYcwH01f_0024GA().Height;
	}

	private bool _0023_003Dz03FyqHnF4Qsp()
	{
		return !RenderContextUtility.AreEqual(Color, Legend._0023_003DzaiEN3rzYDoWa());
	}

	private void _0023_003DzIgBloT8_003D()
	{
		Color = Legend._0023_003DzaiEN3rzYDoWa();
	}

	private void _0023_003DzUMSSRSw_003D()
	{
	}

	internal void _0023_003Dz99kJFjE_003D(Workspace _0023_003DzU0f5_qE_003D, float _0023_003Dz85G4lxo_003D, float _0023_003DzGuW5l4E_003D, float _0023_003DzVDBzBJQ_003D, float _0023_003DzdoUVo1Fyxkwv, float _0023_003DzWBQC3y1PpX2a, float _0023_003Dzme4iFiwq7lcq, int _0023_003DzyIIGKQqRhhVN, bool _0023_003DzUuC7n1U7RpSVakVO4A_003D_003D, int _0023_003Dzy50wP2s_003D, float _0023_003DzVxKEcOzjMJUJ)
	{
		_0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D.SetShader(shaderType.NoLights);
		int num = (int)(_0023_003DzGuW5l4E_003D + _0023_003Dz85G4lxo_003D * _0023_003DzWBQC3y1PpX2a + 2f * _0023_003DzWBQC3y1PpX2a);
		Color contrastColorInverted = _0023_003DzU0f5_qE_003D._0023_003DzipBYly6zFKAp().Background.GetContrastColorInverted();
		int num2 = (int)_0023_003DzVDBzBJQ_003D;
		float num3 = (float)Height * _0023_003Dzme4iFiwq7lcq * _0023_003DzdoUVo1Fyxkwv;
		float num4 = (float)Width * _0023_003DzdoUVo1Fyxkwv;
		float num5 = _0023_003DzVxKEcOzjMJUJ * _0023_003DzdoUVo1Fyxkwv;
		Color color = RenderContextUtility.ConvertColor(Color);
		if (_0023_003DzUuC7n1U7RpSVakVO4A_003D_003D)
		{
			color = Color.FromArgb(220, color);
		}
		_0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D.SetColorWireframe(color);
		_0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D.DrawQuad(new RectangleF(new PointF(num + _0023_003DzyIIGKQqRhhVN, num2), new SizeF(num4 - (float)_0023_003DzyIIGKQqRhhVN, num3)), 1f);
		if (!_0023_003DzUuC7n1U7RpSVakVO4A_003D_003D)
		{
			_0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D.SetColorWireframe(contrastColorInverted);
			if (_0023_003Dzy50wP2s_003D > 0)
			{
				_0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D.DrawLineLoop(new Point2D[4]
				{
					new Point2D((float)num + num4, num2),
					new Point2D(num + _0023_003DzyIIGKQqRhhVN, num2),
					new Point2D(num + _0023_003DzyIIGKQqRhhVN, (float)num2 + num3),
					new Point2D((float)num + num4, (float)num2 + num3)
				});
			}
			else
			{
				_0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D.DrawLineStrip(new Point2D[4]
				{
					new Point2D((float)num + num4 + num5 * 0.333f, num2),
					new Point2D(num + _0023_003DzyIIGKQqRhhVN, num2),
					new Point2D(num + _0023_003DzyIIGKQqRhhVN, (float)num2 + num3),
					new Point2D((float)num + num4 + num5 * 0.333f, (float)num2 + num3)
				});
				_0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D.DrawLine((float)num + num4, num2, 0f, (float)num + num4, (float)num2 + num3, 0f);
			}
		}
	}

	public override string ToString()
	{
		return string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348586738), Width, Height, Color);
	}

	public virtual object Clone()
	{
		return new LegendItem(this);
	}
}
