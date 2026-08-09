using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using devDept.Eyeshot.Control.Converters;
using devDept.Geometry;
using devDept.Graphics;

namespace devDept.Eyeshot.Control;

[TypeConverter(typeof(CoordinateSystemIconConverter))]
public class CoordinateSystemIcon : CoordinateSystemBase
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private coordinateSystemPositionType _0023_003DzABDpBS0_003D = CoordinateSystemBase._0023_003DzPkO7IBwkBx9t();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static int _0023_003DzO_eMxMTJ9zLZ = 37;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double[] _0023_003DzF7jvx0NGqi2c;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double[] _0023_003DzSjxujsYzN51j;

	[Description("The position on screen.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public coordinateSystemPositionType Position
	{
		get
		{
			return _0023_003DzABDpBS0_003D;
		}
		set
		{
			_0023_003DzABDpBS0_003D = value;
		}
	}

	protected override float LabelScale
	{
		get
		{
			float num = (float)Size / GetScalingLevel().Height / 37f;
			if (num > 0f)
			{
				return num * GetScalingLevel().Height;
			}
			return base.LabelScale;
		}
	}

	public CoordinateSystemIcon()
		: this(CoordinateSystemBase._0023_003Dz0UloR3WvSVa2(), CoordinateSystemBase._0023_003Dz3S5baIME1gm5(), CoordinateSystemBase._0023_003DzbDdW6a4epgga(), CoordinateSystemBase._0023_003DziMrsIbBBq4W7(), CoordinateSystemBase._0023_003DziR7d6jvIc0_0024g(), CoordinateSystemBase._0023_003Dzf_KTGHps4l6c(), CoordinateSystemBase._0023_003DzBx1PgZeyDQQZuTHmfA_003D_003D(), CoordinateSystemBase._0023_003DzGjMAP5saIKhANgf_JQ_003D_003D(), CoordinateSystemBase._0023_003DzQyv5Z3I3aLpCHTQ9uQ_003D_003D(), UserInterfaceSymbolBase._0023_003DzndG2TcxO_tb_0024(), CoordinateSystemBase._0023_003DzPkO7IBwkBx9t())
	{
	}

	[Obsolete("This constructor is deprecated.")]
	public CoordinateSystemIcon(Font labelFont, Color labelColor, Color arrowColorX, Color arrowColorY, Color arrowColorZ, string labelOrigin, string labelAxisX, string labelAxisY, string labelAxisZ, bool visible, coordinateSystemPositionType position)
		: this(labelFont, labelColor, arrowColorX, arrowColorY, arrowColorZ, labelOrigin, labelAxisX, labelAxisY, labelAxisZ, visible, position, 37)
	{
	}

	[Obsolete("This constructor is deprecated.")]
	public CoordinateSystemIcon(Font labelFont, Color labelColor, Color arrowColorX, Color arrowColorY, Color arrowColorZ, string labelOrigin, string labelAxisX, string labelAxisY, string labelAxisZ, bool visible, coordinateSystemPositionType position, int size)
		: this(labelFont, labelColor, arrowColorX, arrowColorY, arrowColorZ, labelOrigin, labelAxisX, labelAxisY, labelAxisZ, visible, position, size, null)
	{
	}

	[Obsolete("This constructor is deprecated.")]
	public CoordinateSystemIcon(Font labelFont, Color labelColor, Color arrowColorX, Color arrowColorY, Color arrowColorZ, string labelOrigin, string labelAxisX, string labelAxisY, string labelAxisZ, bool visible, coordinateSystemPositionType position, int size, Transformation transformation)
		: base(labelFont, labelColor, arrowColorX, arrowColorY, arrowColorZ, labelOrigin, labelAxisX, labelAxisY, labelAxisZ, visible, size, transformation, lighting: true)
	{
		Position = position;
	}

	public CoordinateSystemIcon(Color labelColor, Color arrowColorX, Color arrowColorY, Color arrowColorZ, string labelOrigin, string labelAxisX, string labelAxisY, string labelAxisZ, bool visible, coordinateSystemPositionType position, int size, Transformation transformation)
		: base(labelColor, arrowColorX, arrowColorY, arrowColorZ, labelOrigin, labelAxisX, labelAxisY, labelAxisZ, visible, size, transformation, lighting: true)
	{
		Position = position;
	}

	[Obsolete("This constructor is deprecated.")]
	public CoordinateSystemIcon(Font labelFont, Color labelColor, Color arrowColorX, Color arrowColorY, Color arrowColorZ, string labelOrigin, string labelAxisX, string labelAxisY, string labelAxisZ, bool visible, coordinateSystemPositionType position, int size, Transformation transformation, bool lighting)
		: base(labelFont, labelColor, arrowColorX, arrowColorY, arrowColorZ, labelOrigin, labelAxisX, labelAxisY, labelAxisZ, visible, size, transformation, lighting)
	{
		Position = position;
	}

	public CoordinateSystemIcon(Font labelFont, Color labelColorName, Color labelColorX, Color labelColorY, Color labelColorZ, Color arrowColorX, Color arrowColorY, Color arrowColorZ, string labelOrigin, string labelAxisX, string labelAxisY, string labelAxisZ, bool visible, coordinateSystemPositionType position, int size, Transformation transformation, bool lighting)
		: base(labelFont, labelColorName, labelColorX, labelColorY, labelColorZ, arrowColorX, arrowColorY, arrowColorZ, labelOrigin, labelAxisX, labelAxisY, labelAxisZ, visible, size, transformation, lighting)
	{
		Position = position;
	}

	[Obsolete("This constructor is deprecated.")]
	public CoordinateSystemIcon(Color labelColor, Color arrowColorX, Color arrowColorY, Color arrowColorZ, string labelOrigin, string labelAxisX, string labelAxisY, string labelAxisZ, bool visible, coordinateSystemPositionType position, int size, Transformation transformation, bool lighting)
		: base(labelColor, arrowColorX, arrowColorY, arrowColorZ, labelOrigin, labelAxisX, labelAxisY, labelAxisZ, visible, size, transformation, lighting)
	{
		Position = position;
	}

	public CoordinateSystemIcon(Color labelColorName, Color labelColorX, Color labelColorY, Color labelColorZ, Color arrowColorX, Color arrowColorY, Color arrowColorZ, string labelOrigin, string labelAxisX, string labelAxisY, string labelAxisZ, bool visible, coordinateSystemPositionType position, int size, Transformation transformation, bool lighting)
		: base(labelColorName, labelColorX, labelColorY, labelColorZ, arrowColorX, arrowColorY, arrowColorZ, labelOrigin, labelAxisX, labelAxisY, labelAxisZ, visible, size, transformation, lighting)
	{
		Position = position;
	}

	[Obsolete("This constructor is deprecated.")]
	public CoordinateSystemIcon(Font labelFont, Color labelColor, Color arrowColorX, Color arrowColorY, Color arrowColorZ, string labelOrigin, string labelAxisX, string labelAxisY, string labelAxisZ, bool visible, coordinateSystemPositionType position, int size, bool lighting)
		: base(labelFont, labelColor, arrowColorX, arrowColorY, arrowColorZ, labelOrigin, labelAxisX, labelAxisY, labelAxisZ, visible, size, null, lighting)
	{
		Position = position;
	}

	[Obsolete("This constructor is deprecated.")]
	public CoordinateSystemIcon(Font labelFont, Color labelColorName, Color labelColorX, Color labelColorY, Color labelColorZ, Color arrowColorX, Color arrowColorY, Color arrowColorZ, string labelOrigin, string labelAxisX, string labelAxisY, string labelAxisZ, bool visible, coordinateSystemPositionType position, int size, bool lighting)
		: base(labelFont, labelColorName, labelColorX, labelColorY, labelColorZ, arrowColorX, arrowColorY, arrowColorZ, labelOrigin, labelAxisX, labelAxisY, labelAxisZ, visible, size, null, lighting)
	{
		Position = position;
	}

	[Obsolete("This constructor is deprecated.")]
	public CoordinateSystemIcon(Color labelColor, Color arrowColorX, Color arrowColorY, Color arrowColorZ, string labelOrigin, string labelAxisX, string labelAxisY, string labelAxisZ, bool visible, coordinateSystemPositionType position, int size, bool lighting)
		: base(labelColor, arrowColorX, arrowColorY, arrowColorZ, labelOrigin, labelAxisX, labelAxisY, labelAxisZ, visible, size, null, lighting)
	{
		Position = position;
	}

	public CoordinateSystemIcon(Color labelColorName, Color labelColorX, Color labelColorY, Color labelColorZ, Color arrowColorX, Color arrowColorY, Color arrowColorZ, string labelOrigin, string labelAxisX, string labelAxisY, string labelAxisZ, bool visible, coordinateSystemPositionType position, int size, bool lighting)
		: base(labelColorName, labelColorX, labelColorY, labelColorZ, arrowColorX, arrowColorY, arrowColorZ, labelOrigin, labelAxisX, labelAxisY, labelAxisZ, visible, size, null, lighting)
	{
		Position = position;
	}

	public CoordinateSystemIcon(CoordinateSystemIcon other)
		: this(other._0023_003DzzmO0Pua6gdb0, other._0023_003DzA6bpkRXX6ek2, other._0023_003DzYMt62Gq1KVD_, other._0023_003DzwETrOyAwL0aA, other._0023_003DzhHbXEP5q2zKc, RenderContextUtility.ConvertColor(other.ArrowColorX), RenderContextUtility.ConvertColor(other.ArrowColorY), RenderContextUtility.ConvertColor(other.ArrowColorZ), other.LabelOrigin, other.LabelAxisX, other.LabelAxisY, other.LabelAxisZ, other.Visible, other.Position, other._0023_003DzgTjCWc4_003D, other.Transformation, other.Lighting)
	{
	}

	public static CoordinateSystemIcon GetDefaultCoordinateSystemIcon()
	{
		return new CoordinateSystemIcon();
	}

	protected internal override void DrawInternal(DrawSceneParams data)
	{
		RenderContextBase renderContext = data.RenderContext;
		renderContext.SetShader(shaderType.Standard);
		_0023_003DzEnSwckvY9L5_0024yBIrhA_003D_003D(renderContext, (Viewport)data.Viewport, data.ZoomRect, data.ViewportScaleRatio);
		Color color = Color.FromArgb(255, 12, 12, 12);
		Color ambient = color;
		Color specular = Color.FromArgb(255, 77, 77, 77);
		renderContext.SetMaterial(color, color, ambient, specular, 0.25f);
		if (data.ViewportScaleRatio != 1f)
		{
			renderContext.MultMatrixModelView(new Scaling(data.ViewportScaleRatio, data.ViewportScaleRatio, data.ViewportScaleRatio));
		}
		renderContext.SetState(depthStencilStateType.DepthTestLessEqual);
		Draw(new RenderParams(data.Viewport, data.Blocks));
		data.RenderContext.SetState(depthStencilStateType.DepthTestLess);
	}

	private void _0023_003Dzl9Ajpi3D2U27(RenderParams _0023_003DzCBM7XJK4_5H_0024)
	{
		_0023_003DzCBM7XJK4_5H_0024.Viewport.Camera.SetViewport(new int[4]
		{
			0,
			0,
			_0023_003DzCBM7XJK4_5H_0024.TextureSize.Width,
			_0023_003DzCBM7XJK4_5H_0024.TextureSize.Height
		});
		if (_0023_003DzCBM7XJK4_5H_0024.RenderContext.HasFBO())
		{
			_0023_003DzCBM7XJK4_5H_0024.RenderContext.ClearColor(Color.FromArgb(0, 255, 255, 255));
			_0023_003DzCBM7XJK4_5H_0024.RenderContext.ClearDepthStencil(depthBuffer: true, stencilBuffer: true, 0);
			lineSize = 4f;
		}
		Draw(_0023_003DzCBM7XJK4_5H_0024);
		lineSize = 1f;
	}

	protected internal override void DrawLabels(DrawSceneParams myParams)
	{
		myParams.RenderContext.SetShader(shaderType.Texture2DNoLights);
		_0023_003Dz1lQiK8IwvEb9(myParams.RenderContext, myParams.Viewport.Camera, 1f, myParams.ViewFrame);
	}

	private void _0023_003DzEnSwckvY9L5_0024yBIrhA_003D_003D(RenderContextBase _0023_003DzmNZD0Zs_003D, Viewport _0023_003DzYzWi5Yw_003D, RectangleF _0023_003DzF7kGEgqMZE2_, double _0023_003Dz9DzCOOE601Zj)
	{
		_0023_003DzF7jvx0NGqi2c = _0023_003DzWJfmbnPYcnXa(_0023_003DzmNZD0Zs_003D, _0023_003DzYzWi5Yw_003D.Size, _0023_003DzF7kGEgqMZE2_, _0023_003Dz9DzCOOE601Zj);
		_0023_003DzmNZD0Zs_003D.SetMatrices(_0023_003DzF7jvx0NGqi2c, null);
		SetupLights(_0023_003DzYzWi5Yw_003D, _0023_003DzmNZD0Zs_003D, 1f);
		_0023_003DzSjxujsYzN51j = GetModelViewMatrix(_0023_003DzYzWi5Yw_003D.Camera, 1.0);
		_0023_003DzmNZD0Zs_003D.SetMatrices(_0023_003DzF7jvx0NGqi2c, _0023_003DzUiFXEqJwC41M(_0023_003DzSjxujsYzN51j));
	}

	private double[] _0023_003DzWJfmbnPYcnXa(RenderContextBase _0023_003DzmNZD0Zs_003D, Size _0023_003Dz0_0024_0024VbFw_003D, RectangleF _0023_003DzF7kGEgqMZE2_, double _0023_003Dz9DzCOOE601Zj)
	{
		double[] array = Camera.myOrtho(_0023_003DzmNZD0Zs_003D, 0.0, _0023_003Dz0_0024_0024VbFw_003D.Width, 0.0, _0023_003Dz0_0024_0024VbFw_003D.Height, -Size * 5, Size * 5);
		if (!_0023_003DzF7kGEgqMZE2_.IsEmpty)
		{
			array = Camera.ApplyPickMatrix(_0023_003DzmNZD0Zs_003D.ComputePickMatrix(_0023_003DzF7kGEgqMZE2_, new Size(_0023_003Dz0_0024_0024VbFw_003D.Width, _0023_003Dz0_0024_0024VbFw_003D.Height), new int[4] { 0, 0, _0023_003Dz0_0024_0024VbFw_003D.Width, _0023_003Dz0_0024_0024VbFw_003D.Height }), array);
		}
		GetPosition(_0023_003Dz0_0024_0024VbFw_003D, default(RectangleF), out var x, out var y);
		return Utility.MultMatrixd(new Translation(x * _0023_003Dz9DzCOOE601Zj, y * _0023_003Dz9DzCOOE601Zj).MatrixAsVectorByColumn, array);
	}

	protected virtual void GetPosition(Size viewportSize, RectangleF zoomRect, out double x, out double y)
	{
		zoomRect = new RectangleF(0f, 0f, viewportSize.Width, viewportSize.Height);
		x = 0.0;
		y = 0.0;
		double num = (float)Size + LabelScale * 15f;
		double num2 = ParentViewport.Size.Height - ParentViewport._0023_003DzMKzDmN7E2lXsAlFJ_0024Q_003D_003D().Height;
		switch (Position)
		{
		case coordinateSystemPositionType.BottomRight:
			x = (double)zoomRect.Right - num;
			y = num - 5.0 + num2;
			break;
		case coordinateSystemPositionType.BottomLeft:
		{
			x = num - 5.0;
			y = num - 5.0 + num2;
			if (ParentViewport?.ToolBar == null)
			{
				break;
			}
			int num3 = ParentViewport._0023_003Dz0TvaYNo_003D.ButtonStyle.Size + ParentViewport.ToolBar.Margin + ParentViewport.ToolBar.Padding * 2;
			bool flag = false;
			bool flag2 = false;
			ToolBar[] toolBars = ParentViewport.ToolBars;
			foreach (ToolBar toolBar in toolBars)
			{
				if (!flag2 && toolBar.Position == ToolBar.positionType.HorizontalBottomLeft)
				{
					y += num3;
					flag2 = true;
				}
				if (!flag && toolBar.Position == ToolBar.positionType.VerticalBottomLeft)
				{
					x += num3;
					flag = true;
				}
				if (flag && flag2)
				{
					break;
				}
			}
			break;
		}
		case coordinateSystemPositionType.TopLeft:
			x = Size - 5;
			y = (double)zoomRect.Bottom - num;
			break;
		case coordinateSystemPositionType.TopRight:
			x = (double)zoomRect.Right - num;
			y = (double)zoomRect.Bottom - num;
			break;
		}
	}

	public override object Clone()
	{
		return new CoordinateSystemIcon(this)
		{
			_0023_003DzzmO0Pua6gdb0 = _0023_003DzzmO0Pua6gdb0
		};
	}

	public override void Update(IUserInterfaceElement another)
	{
		base.Update(another);
		CoordinateSystemIcon coordinateSystemIcon = (CoordinateSystemIcon)another;
		Position = coordinateSystemIcon.Position;
	}

	public override Rectangle GetBounds(Viewport viewport)
	{
		GetPosition(viewport.Size, RectangleF.Empty, out var x, out var y);
		viewport.GetViewFrame();
		Point point = viewport._0023_003Dz_0WcPl0XuxCA(new Point((int)x, (int)y));
		int num = (int)((double)Size * 1.5) / 2;
		Rectangle result = new Rectangle(point.X - num, (int)((double)point.Y - (double)Size * 1.5), 2 * Size, 2 * Size);
		if (result.Right > viewport._0023_003Dz0TvaYNo_003D._0023_003Dz0P1LCYH__O4t())
		{
			result.Location = new Point(result.X - (result.Right - viewport._0023_003Dz0TvaYNo_003D._0023_003Dz0P1LCYH__O4t()), result.Y);
		}
		if (result.Top < 0)
		{
			result.Location = new Point(result.X, 0);
		}
		return result;
	}

	internal void _0023_003Dz_SqxI8ntug_A(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024)
	{
		double[] b = _0023_003DzUiFXEqJwC41M(Utility.MultMatrixd(_0023_003DzSjxujsYzN51j, _0023_003DzF7jvx0NGqi2c));
		b = Utility.MultMatrixd(new Scaling(_0023_003DzCBM7XJK4_5H_0024.ViewportScaleRatio).MatrixAsVectorByColumn, b);
		osLabelAxisX.UpdatePos(_0023_003DzCBM7XJK4_5H_0024.RenderContext, b, _0023_003DzCBM7XJK4_5H_0024.ViewFrame);
		osLabelAxisY.UpdatePos(_0023_003DzCBM7XJK4_5H_0024.RenderContext, b, _0023_003DzCBM7XJK4_5H_0024.ViewFrame);
		osLabelAxisZ.UpdatePos(_0023_003DzCBM7XJK4_5H_0024.RenderContext, b, _0023_003DzCBM7XJK4_5H_0024.ViewFrame);
	}

	public override void Draw(RenderParams data)
	{
		data.RenderContext.SetLighting(base.Lighting);
		data.RenderContext.SetState(rasterizerStateType.CCW_PolygonFill_CullFaceBack_NoPolygonOffset);
		data.RenderContext.PushMatrices();
		double num = (double)Size / 7.555555555555555;
		data.RenderContext.ScaleMatrixModelView(num, num, num);
		if (!base.Lighting)
		{
			data.RenderContext.SetShader(shaderType.NoLights);
			data.RenderContext.SetColorWireframe(data.Viewport.Background.GetContrastColor());
			data.RenderContext.PushRasterizerState();
			data.RenderContext.SetState(rasterizerStateType.CCW_PolygonFill_CullFaceBack_PolygonOffset_1_1);
		}
		else
		{
			data.RenderContext.SetBlockRefTransform(RenderContextBase.IdentityMatrix);
		}
		if (((ObjectManipulator)data.viewportInternal.parent.ObjectManipulator).Dragging)
		{
			PreDrawOnDepthBuffer(data.RenderContext);
			DrawPlain(data);
			PostDrawOnDepthBuffer(data.RenderContext);
		}
		DrawPlain(data);
		if (!base.Lighting)
		{
			DrawEdgesAndSilho(data);
			data.RenderContext.PopRasterizerState();
		}
		data.RenderContext.PopMatrices();
	}

	protected internal override void CreateLabels(Viewport viewport, RenderContextBase renderContext)
	{
		ParentViewport = viewport;
		CreateLabels(renderContext, new Point3D(Size, 0.0, 0.0), LabelAxisX, new Point3D(0.0, Size, 0.0), LabelAxisY, new Point3D(0.0, 0.0, Size), LabelAxisZ, Point3D.Origin, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589225), viewport);
	}

	internal bool _0023_003Dz4XAvJ5aCRLKs(CoordinateSystemIcon _0023_003DzAbAO3f4_003D)
	{
		if (LabelFont != null && LabelFont.Equals(_0023_003DzAbAO3f4_003D.LabelFont) && !(LabelColorName != _0023_003DzAbAO3f4_003D.LabelColorName) && !(LabelColorX != _0023_003DzAbAO3f4_003D.LabelColorX) && !(LabelColorY != _0023_003DzAbAO3f4_003D.LabelColorY) && !(LabelColorZ != _0023_003DzAbAO3f4_003D.LabelColorZ) && !(ArrowColorX != _0023_003DzAbAO3f4_003D.ArrowColorX) && !(ArrowColorY != _0023_003DzAbAO3f4_003D.ArrowColorY) && !(ArrowColorZ != _0023_003DzAbAO3f4_003D.ArrowColorZ) && !(LabelOrigin != _0023_003DzAbAO3f4_003D.LabelOrigin) && !(LabelAxisX != _0023_003DzAbAO3f4_003D.LabelAxisX) && !(LabelAxisY != _0023_003DzAbAO3f4_003D.LabelAxisY) && !(LabelAxisZ != _0023_003DzAbAO3f4_003D.LabelAxisZ) && base.Visible == _0023_003DzAbAO3f4_003D.Visible && Position == _0023_003DzAbAO3f4_003D.Position && Size == _0023_003DzAbAO3f4_003D.Size)
		{
			return base.Lighting != _0023_003DzAbAO3f4_003D.Lighting;
		}
		return true;
	}
}
