using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using devDept.Eyeshot.Control.Converters;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;

namespace devDept.Eyeshot.Control;

[Serializable]
[TypeConverter(typeof(MagnifyingGlassConverter))]
public class MagnifyingGlassSettings : IDisposable
{
	private Size _size;

	private Mesh glassShape;

	private regenType RegenMode = regenType.CompileOnly;

	private Bitmap bmp;

	private System.Drawing.Point mouseLocation;

	private Rectangle glassRect;

	private bool mouseOutsideViewport;

	private TextureBase Texture;

	private TextureBase TextureResolved;

	private int viewportCaptured;

	private double _factor;

	private bool _scaleLineWeight = true;

	[CompilerGenerated]
	private bool _003CSuspend_003Ek__BackingField;

	public Size Size
	{
		get
		{
			return _size;
		}
		set
		{
			_size = value;
			if (Texture != null)
			{
				Texture.Dispose();
				Texture = null;
			}
			RegenMode = regenType.CompileOnly;
		}
	}

	public System.Drawing.Point Offset { get; set; } = new System.Drawing.Point(0, 0);

	public double Factor
	{
		get
		{
			return _factor;
		}
		set
		{
			if (value < 1.0)
			{
				throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348586551));
			}
			_factor = value;
		}
	}

	public bool ScaleLineWeight
	{
		get
		{
			return _scaleLineWeight;
		}
		set
		{
			_scaleLineWeight = value;
		}
	}

	public MagnifyingGlassSettings()
		: this(new Size(200, 200), 3.0)
	{
	}

	[Obsolete("This constructor is deprecated.")]
	public MagnifyingGlassSettings(bool enabled, Size size, double factor)
		: this(size, factor)
	{
	}

	[Obsolete("This constructor is deprecated.")]
	public MagnifyingGlassSettings(bool enabled, Size size, double factor, bool scaleLineWeight)
		: this(size, factor, scaleLineWeight)
	{
	}

	public MagnifyingGlassSettings(Size size, double factor)
		: this(size, factor, scaleLineWeight: true)
	{
	}

	public MagnifyingGlassSettings(Size size, double factor, bool scaleLineWeight)
	{
		Size = size;
		Factor = factor;
		ScaleLineWeight = scaleLineWeight;
	}

	public MagnifyingGlassSettings(Size size, double factor, bool scaleLineWeight, System.Drawing.Point offset)
	{
		Size = size;
		Factor = factor;
		ScaleLineWeight = scaleLineWeight;
		Offset = offset;
	}

	internal void _0023_003Dz8WTvZ9I_003D(CompileParams _0023_003Dzt5jpbHs_003D)
	{
		if (glassShape != null)
		{
			glassShape.Dispose();
		}
		double num = (double)Size.Width / 2.0;
		double num2 = (double)Size.Height / 2.0;
		ICurve outer = new Ellipse(Point3D.Origin, num, num2);
		glassShape = Mesh.CreatePlanar(outer, 0.5, Mesh.natureType.RichPlain);
		double num3 = (double)Size.Height / (double)Size.Width;
		if (!_0023_003Dzt5jpbHs_003D.RenderContext.IsDirect3D)
		{
			num3 *= -1.0;
		}
		glassShape.ApplyTextureMapping(textureMappingType.Plate, 1.0, num3, new Point3D(0.0 - num, 0.0 - num2, 0.0), new Point3D(num, num2, 0.0));
		glassShape.Regen(null);
		glassShape.Compile(_0023_003Dzt5jpbHs_003D);
		RegenMode = regenType.NotNeeded;
	}

	internal bool _0023_003Dz4XAvJ5aCRLKs(MagnifyingGlassSettings _0023_003DzyQmY6T8_003D)
	{
		if (!(Size != _0023_003DzyQmY6T8_003D.Size) && Factor == _0023_003DzyQmY6T8_003D.Factor && ScaleLineWeight == _0023_003DzyQmY6T8_003D.ScaleLineWeight)
		{
			return Offset != _0023_003DzyQmY6T8_003D.Offset;
		}
		return true;
	}

	internal bool _0023_003DzMhJnK2KPd8YE(Workspace _0023_003DzU0f5_qE_003D, System.Drawing.Point _0023_003DzA4Unupo_0024fEe1)
	{
		_0023_003DzA4Unupo_0024fEe1 = new System.Drawing.Point(_0023_003DzA4Unupo_0024fEe1.X + Offset.X, _0023_003DzA4Unupo_0024fEe1.Y + Offset.Y);
		if (RegenMode == regenType.CompileOnly)
		{
			_0023_003Dz8WTvZ9I_003D(new CompileParams(_0023_003DzU0f5_qE_003D));
		}
		if (Texture == null && _0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D.HasFBO())
		{
			Texture = _0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D.CreateTexture2D(Size, depthTexture: false);
			if (_0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D.IsDirect3D && _0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D.IsMultisample())
			{
				TextureResolved = _0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D.CreateTexture2DNoMultisample(Size, depthTexture: false);
			}
		}
		mouseLocation = _0023_003DzA4Unupo_0024fEe1;
		int num = (int)((double)Size.Width / Factor);
		int num2 = (int)((double)Size.Height / Factor);
		Viewport viewport = _0023_003DzU0f5_qE_003D._0023_003DzipBYly6zFKAp();
		if (viewport._0023_003DzBRVqaeuLEkG3yFoWpg_003D_003D())
		{
			return false;
		}
		double num3 = _0023_003DzA4Unupo_0024fEe1.X - num / 2;
		double num4 = _0023_003DzA4Unupo_0024fEe1.Y - num2 / 2;
		glassRect = new Rectangle((int)num3, (int)num4, num, num2);
		int x = viewport.Location.X;
		int num5 = x + viewport.Size.Width;
		int y = viewport.Location.Y;
		int num6 = y + viewport.Size.Height;
		if (_0023_003DzA4Unupo_0024fEe1.X < x || _0023_003DzA4Unupo_0024fEe1.X > num5 || _0023_003DzA4Unupo_0024fEe1.Y < y || _0023_003DzA4Unupo_0024fEe1.Y > num6)
		{
			if (!mouseOutsideViewport)
			{
				mouseOutsideViewport = true;
				return true;
			}
		}
		else
		{
			mouseOutsideViewport = false;
		}
		float _0023_003DzCs_ZxbN2mZ = ((!ScaleLineWeight) ? 1 : 0);
		if (glassRect.Width > 0 && glassRect.Height > 0 && !mouseOutsideViewport)
		{
			object obj = viewport.Camera.ProjectionMatrix.Clone();
			viewportCaptured = _0023_003DzU0f5_qE_003D._0023_003DzBn2ByFKdwrou;
			Color color = _0023_003DzU0f5_qE_003D.Selection.Color;
			_0023_003DzU0f5_qE_003D.Selection.Color = Color.FromArgb(255, color);
			bool enabled = _0023_003DzU0f5_qE_003D.AmbientOcclusion?.Enabled ?? false;
			if (_0023_003DzU0f5_qE_003D.AmbientOcclusion != null)
			{
				_0023_003DzU0f5_qE_003D.AmbientOcclusion.Enabled = false;
			}
			if (_0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D.HasFBO())
			{
				_0023_003DzU0f5_qE_003D._0023_003DzzpG3rT4lYHMG(Texture, glassRect, _0023_003DzbUBvby4V64DY: true, _0023_003DznmdaLoQDqHnqS_0024D_FFTlCe4_003D: true, _0023_003DzCs_ZxbN2mZ);
			}
			else
			{
				if (bmp != null)
				{
					bmp.Dispose();
				}
				bmp = viewport._0023_003DzNZ5R7KqLKF7E(new Viewport._0023_003Dz7XrVzbNXMo8q
				{
					_0023_003Dzy4MPItw_003D = _0023_003DzU0f5_qE_003D,
					_0023_003DzxFNeIFWItLae = viewport.Size,
					_0023_003DzLCFtN0k_003D = glassRect,
					_0023_003DzCs_ZxbN2mZ30 = _0023_003DzCs_ZxbN2mZ,
					_0023_003DzbUBvby4V64DY = false,
					_0023_003DzNLGcq5k_003D = Color.Empty,
					_0023_003DznmdaLoQDqHnqS_0024D_FFTlCe4_003D = true,
					_0023_003Dz0W4nCS2oJwWK = false,
					_0023_003DzRbeRKfvgcnrLx5MxrA_003D_003D = false,
					_0023_003DzmAezgho6pU2i = false,
					_0023_003DzHdL9CKamSnvn = _0023_003DzU0f5_qE_003D._0023_003Dz6LfbgRAYOjvE
				}, Size);
				_0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D.ClearDepthStencil(depthBuffer: true, stencilBuffer: false, 0);
			}
			_0023_003DzU0f5_qE_003D.Selection.Color = color;
			if (_0023_003DzU0f5_qE_003D.AmbientOcclusion != null)
			{
				_0023_003DzU0f5_qE_003D.AmbientOcclusion.Enabled = enabled;
			}
			viewport.Camera.ProjectionMatrix = (double[])obj;
			return true;
		}
		return false;
	}

	internal void _0023_003DzshGHYXMIRfsi(Workspace _0023_003DzU0f5_qE_003D, DrawSceneParams _0023_003DzCBM7XJK4_5H_0024)
	{
		if (_0023_003Dz3J1JrgJesybc() || mouseOutsideViewport || _0023_003DzU0f5_qE_003D.ActionMode != actionType.MagnifyingGlass || _0023_003DzCBM7XJK4_5H_0024.Viewport != _0023_003DzU0f5_qE_003D._0023_003DzipBYly6zFKAp() || _0023_003DzCBM7XJK4_5H_0024.CaptureSurface || _0023_003DzCBM7XJK4_5H_0024.Viewport.Size.Width < Size.Width || _0023_003DzCBM7XJK4_5H_0024.Viewport.Size.Height < Size.Height || viewportCaptured != _0023_003DzU0f5_qE_003D._0023_003DzBn2ByFKdwrou)
		{
			return;
		}
		Viewport viewport = (Viewport)_0023_003DzCBM7XJK4_5H_0024.Viewport;
		Point2D point2D = null;
		if (bmp != null)
		{
			point2D = _0023_003Dz1ZdOevQ_003D(viewport, bmp.Size);
			Bitmap bitmap = new Bitmap(bmp.Width, bmp.Height, PixelFormat.Format32bppArgb);
			try
			{
				using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bitmap))
				{
					GraphicsPath graphicsPath = new GraphicsPath(FillMode.Winding);
					graphicsPath.AddEllipse(new Rectangle(0, 0, bmp.Width - 1, bmp.Height - 1));
					TextureBrush brush = new TextureBrush(bmp);
					graphics.FillPath(brush, graphicsPath);
					GraphicsPath graphicsPath2 = new GraphicsPath(FillMode.Alternate);
					graphicsPath2.AddEllipse(new Rectangle(0, 0, bmp.Width - 1, bmp.Height - 1));
					Pen pen = new Pen(RenderContextUtility.ConvertColor(_0023_003DzU0f5_qE_003D._0023_003DzOLP90s_0024AN26E.Color), 1f);
					graphics.DrawPath(pen, graphicsPath2);
				}
				_0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D.SetState(blendStateType.Blend);
				_0023_003DzU0f5_qE_003D.DrawImage((int)point2D.X, (int)point2D.Y, bitmap);
			}
			finally
			{
				((IDisposable)bitmap).Dispose();
			}
			_0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D.SetState(blendStateType.NoBlend);
		}
		else if (Texture != null)
		{
			_0023_003DzCBM7XJK4_5H_0024.RenderContext.SetShader(shaderType.Texture2DNoLights);
			_0023_003DzCBM7XJK4_5H_0024.RenderContext.CloseTexture(Texture, force: true);
			if (_0023_003DzCBM7XJK4_5H_0024.RenderContext.IsDirect3D && _0023_003DzCBM7XJK4_5H_0024.RenderContext.IsMultisample())
			{
				((D3DRenderContext)_0023_003DzCBM7XJK4_5H_0024.RenderContext).ResolveMultisampleTexture(Texture, TextureResolved);
				_0023_003DzCBM7XJK4_5H_0024.RenderContext.SetTexture(TextureResolved);
			}
			else
			{
				_0023_003DzCBM7XJK4_5H_0024.RenderContext.SetTexture(Texture);
			}
			_0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D.PushModelView();
			System.Drawing.Point point = _0023_003DzU0f5_qE_003D._0023_003DzipBYly6zFKAp().ScreenToViewport(mouseLocation);
			_0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D.TranslateMatrixModelView(point.X, viewport.Size.Height - point.Y, 0.0);
			Mesh mesh = glassShape;
			((IEntityInternal)mesh).Render(new RenderParams(viewport, _0023_003DzCBM7XJK4_5H_0024.Blocks));
			_0023_003DzCBM7XJK4_5H_0024.RenderContext.CloseTexture(Texture, force: true);
			_0023_003DzCBM7XJK4_5H_0024.RenderContext.SetShader(shaderType.NoLights);
			_0023_003DzCBM7XJK4_5H_0024.RenderContext.SetColorShadedInternal(entityNatureType.Wire, RenderContextUtility.ConvertColor(_0023_003DzU0f5_qE_003D._0023_003DzOLP90s_0024AN26E.Color), _0023_003DzNGLWIVQ_003D: false, _0023_003DzU0f5_qE_003D._0023_003DzAzve6tkKNr7t1F9Q_g_003D_003D);
			((IEntityInternal)mesh).DrawEdges(new DrawParams(viewport, _0023_003DzCBM7XJK4_5H_0024.Blocks));
			_0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D.PopModelView();
		}
	}

	private Point2D _0023_003Dz1ZdOevQ_003D(Viewport _0023_003DzYzWi5Yw_003D, Size _0023_003Dz9UoBAvg_003D)
	{
		System.Drawing.Point point = _0023_003DzYzWi5Yw_003D.ScreenToViewport(mouseLocation);
		return new Point2D(point.X - _0023_003Dz9UoBAvg_003D.Width / 2, _0023_003DzYzWi5Yw_003D.Size.Height - (point.Y + _0023_003Dz9UoBAvg_003D.Height / 2));
	}

	public void Dispose()
	{
		if (Texture != null)
		{
			Texture.Dispose();
		}
		if (bmp != null)
		{
			bmp.Dispose();
		}
		if (glassShape != null)
		{
			glassShape.Dispose();
		}
		if (TextureResolved != null)
		{
			TextureResolved.Dispose();
		}
	}

	internal bool _0023_003Dz3J1JrgJesybc()
	{
		return _003CSuspend_003Ek__BackingField;
	}

	internal void _0023_003DzPTfEdKLFXzku(bool _0023_003DzsLHxXyo_003D)
	{
		_003CSuspend_003Ek__BackingField = _0023_003DzsLHxXyo_003D;
	}
}
