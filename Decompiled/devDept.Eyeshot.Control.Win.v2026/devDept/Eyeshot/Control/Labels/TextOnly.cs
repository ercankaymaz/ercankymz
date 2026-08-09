using System;
using System.Drawing;
using System.Runtime.Serialization;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Control.Labels;

[Serializable]
public class TextOnly : Label
{
	private string _text;

	private Font _font;

	private bool _vertical;

	protected Color labelFillColor = Color.Empty;

	private Color _fillColorForSelection = Color.Empty;

	private Color _colorForSelection = Color.Empty;

	internal int cornerRadius;

	public override Size Size
	{
		get
		{
			if (base.Image == null)
			{
				_0023_003Dztk2RiLk_003D(1f);
			}
			return base.Size;
		}
	}

	public int CornerRadius
	{
		get
		{
			return cornerRadius;
		}
		set
		{
			_0023_003Dz9wGA9a2YRpOi(value);
		}
	}

	public string Text
	{
		get
		{
			return _text;
		}
		set
		{
			_text = value;
			base.RegenMode = regenType.RegenAndCompile;
		}
	}

	public Font Font
	{
		get
		{
			return _font;
		}
		set
		{
			_font = value;
			base.RegenMode = regenType.RegenAndCompile;
		}
	}

	public bool Vertical
	{
		get
		{
			return _vertical;
		}
		set
		{
			_vertical = value;
			base.RegenMode = regenType.RegenAndCompile;
		}
	}

	public Color FillColor
	{
		get
		{
			return labelFillColor;
		}
		set
		{
			labelFillColor = value;
			base.RegenMode = regenType.RegenAndCompile;
		}
	}

	public Color FillColorForSelection
	{
		get
		{
			return _fillColorForSelection;
		}
		set
		{
			_fillColorForSelection = value;
			base.RegenMode = regenType.RegenAndCompile;
		}
	}

	public Color ColorForSelection
	{
		get
		{
			return _colorForSelection;
		}
		set
		{
			_colorForSelection = value;
			base.RegenMode = regenType.RegenAndCompile;
		}
	}

	public TextOnly(double x, double y, double z, string text, Font textFont, Color textColor)
		: base(x, y, z, textColor)
	{
		_text = text;
		_font = textFont;
	}

	public TextOnly(double x, double y, double z, string text, Font textFont, Color textColor, ContentAlignment alignment)
		: base(x, y, z, textColor)
	{
		_text = text;
		_font = textFont;
		base.Alignment = alignment;
	}

	public TextOnly(Point3D pt, string text, Font textFont, Color textColor)
		: base(pt, textColor)
	{
		_text = text;
		_font = textFont;
	}

	public TextOnly(Point3D pt, string text, Font textFont, Color textColor, ContentAlignment alignment)
		: base(pt, textColor)
	{
		_text = text;
		_font = textFont;
		base.Alignment = alignment;
	}

	protected TextOnly(TextOnly another)
		: base(another)
	{
		FillColor = another.FillColor;
		_colorForSelection = another._colorForSelection;
		_fillColorForSelection = another._fillColorForSelection;
		Font = another.Font;
		Text = another.Text;
		Vertical = another.Vertical;
	}

	protected TextOnly(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		_text = info.GetString(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588815));
		_font = (Font)info.GetValue(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588074), typeof(Font));
		_vertical = info.GetBoolean(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348586668));
		labelFillColor = (Color)info.GetValue(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348586685), typeof(Color));
		_colorForSelection = (Color)info.GetValue(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348586694), typeof(Color));
		_fillColorForSelection = (Color)info.GetValue(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348586734), typeof(Color));
		cornerRadius = info.GetInt32(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650553));
	}

	public override void ScaleForDPI()
	{
		Font = UtilityEx._0023_003DzowV4NhAf418J(Font, _0023_003DzzihtqSXtvdcF: true, UtilityEx.GetScalingLevel());
	}

	public override object Clone()
	{
		return new TextOnly(this);
	}

	protected virtual Bitmap GetBitmapFromText(Font myScaledFont, float scale, Color color, Color fillColor)
	{
		string text = _text;
		IntPtr zero = IntPtr.Zero;
		int _0023_003DzgumMmXEw_0024MRuB8uEuw_003D_003D = (_vertical ? 5 : 6);
		int _0023_003DzvjTHbaTV_0024Ffg = CornerRadius * (int)scale;
		return Workspace._0023_003DzRFGA2zTmmjXj(text, myScaledFont, color, fillColor, zero, (RotateFlipType)_0023_003DzgumMmXEw_0024MRuB8uEuw_003D_003D, _0023_003DzlA4vqb43pzit8w_0024Q4A_003D_003D: true, _0023_003DzPtJa_0024HEmQfD_YqtyuA_003D_003D: false, default(Color), _0023_003DzvjTHbaTV_0024Ffg);
	}

	public override void Regen(RenderContextBase renderContext, float drawScale)
	{
		_0023_003Dztk2RiLk_003D(drawScale);
		base.Regen(renderContext, drawScale);
	}

	private void _0023_003Dztk2RiLk_003D(float _0023_003DzCzsr4CTVr_Ea)
	{
		Font font = new Font(_font.Name, _font.SizeInPoints * _0023_003DzCzsr4CTVr_Ea, _font.Style);
		try
		{
			if (base.Image != null)
			{
				base.Image.Dispose();
			}
			SetImage(GetBitmapFromText(font, _0023_003DzCzsr4CTVr_Ea, labelColor, labelFillColor));
			if (Selected)
			{
				CreateSelectedBitmap(_0023_003DzCzsr4CTVr_Ea);
			}
		}
		finally
		{
			((IDisposable)font).Dispose();
		}
		base.RegenMode = regenType.CompileOnly;
	}

	protected override void CreateSelectedBitmap(float drawScale)
	{
		if (_colorForSelection == Color.Empty && _fillColorForSelection == Color.Empty)
		{
			base.CreateSelectedBitmap(drawScale);
		}
		else if (selectedBitmap == null)
		{
			Font font = new Font(_font.Name, _font.SizeInPoints * drawScale, _font.Style);
			try
			{
				selectedBitmap = GetBitmapFromText(font, drawScale, (_colorForSelection == Color.Empty) ? labelColor : _colorForSelection, (_fillColorForSelection == Color.Empty) ? labelFillColor : _fillColorForSelection);
			}
			finally
			{
				((IDisposable)font).Dispose();
			}
		}
	}

	private void _0023_003Dz9wGA9a2YRpOi(int _0023_003DzsLHxXyo_003D)
	{
		if (_0023_003DzsLHxXyo_003D < 0)
		{
			cornerRadius = 0;
		}
		else if (_0023_003DzsLHxXyo_003D > 3)
		{
			cornerRadius = 3;
		}
		else
		{
			cornerRadius = _0023_003DzsLHxXyo_003D;
		}
	}

	public override void Draw(RenderContextBase renderContext, float drawScale)
	{
		_0023_003DzRzuCrPw_003D(renderContext, xPos, yPos, drawScale);
	}

	internal virtual void _0023_003DzRzuCrPw_003D(RenderContextBase _0023_003DzmNZD0Zs_003D, float _0023_003Dz8GBMuoM_003D, float _0023_003DzJU0R6e0_003D, float _0023_003DzCzsr4CTVr_Ea)
	{
		Point2D point2D = ComputePositions(_0023_003Dz8GBMuoM_003D, _0023_003DzJU0R6e0_003D, _0023_003DzCzsr4CTVr_Ea);
		TextureBase textureBase = GetTexture(_0023_003DzmNZD0Zs_003D);
		RectangleF rect = new RectangleF((int)point2D.X, (int)point2D.Y, textureBase.BitmapSize.Width, textureBase.BitmapSize.Height);
		if (rect.Width > 0f && rect.Height > 0f)
		{
			_0023_003DzmNZD0Zs_003D.SetShader(shaderType.Texture2DNoLights);
			DrawTexture(_0023_003DzmNZD0Zs_003D, textureBase, rect, flipY: false);
		}
	}

	protected internal override void DrawForSelection(RenderContextBase context)
	{
		DrawForSelection(context, xPos, yPos);
	}

	protected void DrawForSelection(RenderContextBase context, float x, float y)
	{
		Point2D point2D = ComputePositions(x, y, 1f);
		context.DrawQuad(new RectangleF((float)point2D.X, (float)point2D.Y, base.Image.Width, base.Image.Height));
		base.DrawForSelection(context);
	}

	public override void DrawWithOffset(RenderContextBase renderContext, int dx, int dy, float drawScale)
	{
		_0023_003DzRzuCrPw_003D(renderContext, xPos + (float)dx * drawScale, yPos + (float)dy * drawScale, drawScale);
	}

	public override LabelSurrogate ConvertToSurrogate()
	{
		return new TextOnlySurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588815), _text);
		info.AddValue(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588074), _font);
		info.AddValue(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348586668), _vertical);
		info.AddValue(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348586685), labelFillColor);
		info.AddValue(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348586694), ColorForSelection);
		info.AddValue(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348586734), FillColorForSelection);
		info.AddValue(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650553), cornerRadius);
	}

	internal override void _0023_003DzPY_0024ulDyKjEOA()
	{
		base._0023_003DzPY_0024ulDyKjEOA();
		if (base.Image != null)
		{
			base.Image.Dispose();
			SetImage(null);
		}
	}
}
