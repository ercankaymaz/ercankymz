using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using devDept.Eyeshot.Control.Converters;
using devDept.Eyeshot.Control.Labels;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;

namespace devDept.Eyeshot.Control;

[TypeConverter(typeof(OriginSymbolConverter))]
public class OriginSymbol : CoordinateSystemBase
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private originSymbolStyleType _0023_003DzU_hIjulDg9rByIZc54yIies_003D;

	protected internal static Color DefaultArrowColorX => Color.Red;

	protected internal static Color DefaultArrowColorY => Color.Green;

	protected internal static Color DefaultArrowColorZ => Color.Blue;

	[Description("The symbol style.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual originSymbolStyleType StyleMode
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzU_hIjulDg9rByIZc54yIies_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzU_hIjulDg9rByIZc54yIies_003D = value;
		}
	}

	protected override bool HasTextureCoords => StyleMode == originSymbolStyleType.Ball;

	public OriginSymbol()
		: this(_0023_003DzmuZmjj_0024WEUbi(), _0023_003DzCp6SpVT8Q9QG(), CoordinateSystemBase._0023_003Dz0UloR3WvSVa2(), CoordinateSystemBase._0023_003Dz3S5baIME1gm5(), DefaultArrowColorX, DefaultArrowColorY, DefaultArrowColorZ, CoordinateSystemBase._0023_003Dzf_KTGHps4l6c(), CoordinateSystemBase._0023_003DzBx1PgZeyDQQZuTHmfA_003D_003D(), CoordinateSystemBase._0023_003DzGjMAP5saIKhANgf_JQ_003D_003D(), CoordinateSystemBase._0023_003DzQyv5Z3I3aLpCHTQ9uQ_003D_003D(), _0023_003DzndG2TcxO_tb_0024())
	{
	}

	[Obsolete("This constructor is deprecated.")]
	public OriginSymbol(int ballSize, originSymbolStyleType styleMode, Font labelFont, Color labelColor, Color arrowColorX, Color arrowColorY, Color arrowColorZ, string labelOrigin, string labelAxisX, string labelAxisY, string labelAxisZ, bool visible)
		: this(ballSize, styleMode, labelFont, labelColor, arrowColorX, arrowColorY, arrowColorZ, labelOrigin, labelAxisX, labelAxisY, labelAxisZ, visible, null)
	{
	}

	[Obsolete("This constructor is deprecated.")]
	public OriginSymbol(int ballSize, originSymbolStyleType styleMode, Color labelColor, Color arrowColorX, Color arrowColorY, Color arrowColorZ, string labelOrigin, string labelAxisX, string labelAxisY, string labelAxisZ, bool visible)
		: this(ballSize, styleMode, labelColor, arrowColorX, arrowColorY, arrowColorZ, labelOrigin, labelAxisX, labelAxisY, labelAxisZ, visible, null)
	{
	}

	[Obsolete("This constructor is deprecated.")]
	public OriginSymbol(int ballSize, originSymbolStyleType styleMode, Font labelFont, Color labelColor, Color arrowColorX, Color arrowColorY, Color arrowColorZ, string labelOrigin, string labelAxisX, string labelAxisY, string labelAxisZ, bool visible, Transformation transformation)
		: base(labelFont, labelColor, arrowColorX, arrowColorY, arrowColorZ, labelOrigin, labelAxisX, labelAxisY, labelAxisZ, visible, ballSize, transformation, lighting: true)
	{
		StyleMode = styleMode;
	}

	[Obsolete("This constructor is deprecated.")]
	public OriginSymbol(int ballSize, originSymbolStyleType styleMode, Color labelColor, Color arrowColorX, Color arrowColorY, Color arrowColorZ, string labelOrigin, string labelAxisX, string labelAxisY, string labelAxisZ, bool visible, Transformation transformation)
		: base(labelColor, arrowColorX, arrowColorY, arrowColorZ, labelOrigin, labelAxisX, labelAxisY, labelAxisZ, visible, ballSize, transformation, lighting: true)
	{
		StyleMode = styleMode;
	}

	[Obsolete("This constructor is deprecated.")]
	public OriginSymbol(int ballSize, originSymbolStyleType styleMode, Font labelFont, Color labelColor, Color arrowColorX, Color arrowColorY, Color arrowColorZ, string labelOrigin, string labelAxisX, string labelAxisY, string labelAxisZ, bool visible, Transformation transformation, bool lighting)
		: base(labelFont, labelColor, arrowColorX, arrowColorY, arrowColorZ, labelOrigin, labelAxisX, labelAxisY, labelAxisZ, visible, ballSize, transformation, lighting)
	{
		StyleMode = styleMode;
	}

	public OriginSymbol(int ballSize, originSymbolStyleType styleMode, Font labelFont, Color labelColorName, Color labelColorX, Color labelColorY, Color labelColorZ, Color arrowColorX, Color arrowColorY, Color arrowColorZ, string labelOrigin, string labelAxisX, string labelAxisY, string labelAxisZ, bool visible, Transformation transformation, bool lighting)
		: base(labelFont, labelColorName, labelColorX, labelColorY, labelColorZ, arrowColorX, arrowColorY, arrowColorZ, labelOrigin, labelAxisX, labelAxisY, labelAxisZ, visible, ballSize, transformation, lighting)
	{
		StyleMode = styleMode;
	}

	[Obsolete("This constructor is deprecated.")]
	public OriginSymbol(int ballSize, originSymbolStyleType styleMode, Color labelColor, Color arrowColorX, Color arrowColorY, Color arrowColorZ, string labelOrigin, string labelAxisX, string labelAxisY, string labelAxisZ, bool visible, Transformation transformation, bool lighting)
		: base(labelColor, arrowColorX, arrowColorY, arrowColorZ, labelOrigin, labelAxisX, labelAxisY, labelAxisZ, visible, ballSize, transformation, lighting)
	{
		StyleMode = styleMode;
	}

	public OriginSymbol(int ballSize, originSymbolStyleType styleMode, Color labelColorName, Color labelColorX, Color labelColorY, Color labelColorZ, Color arrowColorX, Color arrowColorY, Color arrowColorZ, string labelOrigin, string labelAxisX, string labelAxisY, string labelAxisZ, bool visible, Transformation transformation, bool lighting)
		: base(labelColorName, labelColorX, labelColorY, labelColorZ, arrowColorX, arrowColorY, arrowColorZ, labelOrigin, labelAxisX, labelAxisY, labelAxisZ, visible, ballSize, transformation, lighting)
	{
		StyleMode = styleMode;
	}

	[Obsolete("This constructor is deprecated.")]
	public OriginSymbol(int ballSize, originSymbolStyleType styleMode, Font labelFont, Color labelColor, Color arrowColorX, Color arrowColorY, Color arrowColorZ, string labelOrigin, string labelAxisX, string labelAxisY, string labelAxisZ, bool visible, bool lighting)
		: base(labelFont, labelColor, arrowColorX, arrowColorY, arrowColorZ, labelOrigin, labelAxisX, labelAxisY, labelAxisZ, visible, ballSize, null, lighting)
	{
		StyleMode = styleMode;
	}

	[Obsolete("This constructor is deprecated.")]
	public OriginSymbol(int ballSize, string name, Transformation transformation, bool lighting)
		: base(CoordinateSystemBase._0023_003Dz3S5baIME1gm5(), DefaultArrowColorX, DefaultArrowColorY, DefaultArrowColorZ, name, CoordinateSystemBase._0023_003DzBx1PgZeyDQQZuTHmfA_003D_003D(), CoordinateSystemBase._0023_003DzGjMAP5saIKhANgf_JQ_003D_003D(), CoordinateSystemBase._0023_003DzQyv5Z3I3aLpCHTQ9uQ_003D_003D(), visible: true, ballSize, transformation, lighting)
	{
		StyleMode = originSymbolStyleType.CoordinateSystem;
	}

	[Obsolete("This constructor is deprecated.")]
	public OriginSymbol(int ballSize, originSymbolStyleType styleMode, Color labelColor, Color arrowColorX, Color arrowColorY, Color arrowColorZ, string labelOrigin, string labelAxisX, string labelAxisY, string labelAxisZ, bool visible, bool lighting)
		: base(labelColor, arrowColorX, arrowColorY, arrowColorZ, labelOrigin, labelAxisX, labelAxisY, labelAxisZ, visible, ballSize, null, lighting)
	{
		StyleMode = styleMode;
	}

	public OriginSymbol(OriginSymbol other)
		: this(other._0023_003DzgTjCWc4_003D, other.StyleMode, other._0023_003DzzmO0Pua6gdb0, other._0023_003DzA6bpkRXX6ek2, other._0023_003DzYMt62Gq1KVD_, other._0023_003DzwETrOyAwL0aA, other._0023_003DzhHbXEP5q2zKc, RenderContextUtility.ConvertColor(other.ArrowColorX), RenderContextUtility.ConvertColor(other.ArrowColorY), RenderContextUtility.ConvertColor(other.ArrowColorZ), other.LabelOrigin, other.LabelAxisX, other.LabelAxisY, other.LabelAxisZ, other.Visible, null, other.Lighting)
	{
	}

	public static OriginSymbol GetDefaultOriginSymbol()
	{
		return new OriginSymbol(10, originSymbolStyleType.Ball, Color.Black, Color.Red, Color.Green, Color.Blue, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589225), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589185), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589209), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589201), visible: true, null, lighting: false);
	}

	protected internal override void CreateLabels(Viewport viewport, RenderContextBase renderContext)
	{
		ParentViewport = viewport;
		ContentAlignment originNameAlignment = ((StyleMode != originSymbolStyleType.Ball) ? ContentAlignment.TopLeft : ContentAlignment.BottomLeft);
		CreateLabels(renderContext, Point3D.Origin, osLabelAxisX.Text, Point3D.Origin, osLabelAxisY.Text, Point3D.Origin, osLabelAxisZ.Text, Point3D.Origin, osLabelOrigin.Text, viewport, originNameAlignment);
	}

	private bool _0023_003DzPLlSnOGZ0u5W()
	{
		return Size != _0023_003DzmuZmjj_0024WEUbi();
	}

	private void _0023_003Dzo_c5OjY_003D()
	{
		Size = _0023_003DzmuZmjj_0024WEUbi();
	}

	private bool _0023_003DzuooydjCMSwlZPpsh1w_003D_003D()
	{
		return StyleMode != _0023_003DzCp6SpVT8Q9QG();
	}

	private void _0023_003DzyUvVZflI9bLt()
	{
		StyleMode = _0023_003DzCp6SpVT8Q9QG();
	}

	internal static originSymbolStyleType _0023_003DzCp6SpVT8Q9QG()
	{
		return originSymbolStyleType.Ball;
	}

	internal static int _0023_003DzmuZmjj_0024WEUbi()
	{
		return 10;
	}

	private new static bool _0023_003DzndG2TcxO_tb_0024()
	{
		return true;
	}

	protected internal override void DrawInternal(DrawSceneParams data)
	{
		UpdateScreenToWorld((Viewport)data.Viewport, data.ViewFrame);
		_0023_003DzKa9hVOo_003D(data, StyleMode == originSymbolStyleType.Ball);
		RenderParams renderParams = new RenderParams(data.Viewport, data.Blocks);
		shaderType shaderType2 = shaderType.Texture2D;
		if (StyleMode == originSymbolStyleType.CoordinateSystem)
		{
			shaderType2 = shaderType.Standard;
		}
		data.RenderContext.SetShader(shaderType2);
		if (!_0023_003Dz89cPk57rASTGmdmTnA_003D_003D(data, _0023_003DzpIzHYHy1ug2w: true, StyleMode == originSymbolStyleType.Ball))
		{
			return;
		}
		if (data.ShaderParams != null)
		{
			data.RenderContext.Shaders[shaderType2].UpdatedInFrame = false;
			data.RenderContext.CurrentShaderTechnique.Shader.SetParameters(data.ShaderParams);
		}
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

	protected internal override float UpdateScreenToWorld(Viewport viewport, int[] layoutViewport)
	{
		Point3D _0023_003DzhEjPeMs_003D = ((Transformation != null) ? (Transformation * center) : center);
		return _0023_003DzoGvMfeZtKVwG = viewport._0023_003DzuPo9xTkqnag6(layoutViewport, _0023_003DzhEjPeMs_003D);
	}

	public override void Draw(RenderParams data)
	{
		data.RenderContext.SetLighting(base.Lighting);
		data.RenderContext.SetState(rasterizerStateType.CCW_PolygonFill_CullFaceBack_NoPolygonOffset);
		data.RenderContext.PushMatrices();
		IViewportInternal viewportInternal = data.viewportInternal;
		Workspace workspace = (Workspace)viewportInternal.parent;
		switch (StyleMode)
		{
		case originSymbolStyleType.Ball:
		{
			if (!base.Lighting)
			{
				data.RenderContext.SetShader(shaderType.Texture2DNoLights);
				data.RenderContext.PushRasterizerState();
				data.RenderContext.SetState(rasterizerStateType.CCW_PolygonFill_CullFaceBack_PolygonOffset_1_1);
			}
			data.RenderContext.SetMaterial(Color.White, workspace._0023_003Dzxpbv4lQ_003D.Diffuse, workspace._0023_003Dzxpbv4lQ_003D.Ambient, workspace._0023_003Dzxpbv4lQ_003D.Specular, workspace._0023_003Dzxpbv4lQ_003D.Shininess);
			data.RenderContext.SetTexture(ballTexture);
			IEntityInternal entityInternal = _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[0];
			if (entityInternal.Visible)
			{
				entityInternal.Render(data);
			}
			data.RenderContext.CloseTexture();
			if (!base.Lighting)
			{
				data.RenderContext.SetColorWireframe(((BackgroundSettings)data.Viewport.Background).GetContrastColorInverted());
				double[] a = data.RenderContext.CurrentModelViewMatrix();
				double[] b = data.RenderContext.CurrentProjectionMatrix();
				double[] modelViewProj = Utility.MultMatrixd(a, b);
				DrawSilhouettesParams data2 = new DrawSilhouettesParams(data.Viewport, viewportInternal.parent.Blocks, projectionType.Orthographic, modelViewProj, data.ScreenToWorld);
				data.RenderContext.SetLineSize(lineSize);
				data.RenderContext.UpdateConstantBufferPerFrame();
				if (entityInternal.Visible)
				{
					entityInternal.DrawSilhouettes(data2);
				}
				data.RenderContext.PopRasterizerState();
			}
			break;
		}
		case originSymbolStyleType.CoordinateSystem:
			base.Draw(data);
			break;
		}
		data.RenderContext.PopMatrices();
	}

	internal virtual void _0023_003Dz_SqxI8ntug_A(DrawSceneParams _0023_003DzCBM7XJK4_5H_0024)
	{
		Transformation _0023_003DzndAYios_003D = null;
		_0023_003Dz8R9Ht3ly7amE(_0023_003DzndAYios_003D, osLabelOrigin, _0023_003DzCBM7XJK4_5H_0024.Viewport.Camera, _0023_003DzCBM7XJK4_5H_0024.ViewFrame);
		if (StyleMode == originSymbolStyleType.CoordinateSystem)
		{
			double num = currentScale * 8f;
			osLabelAxisX.AnchorPoint = new Point3D(num, 0.0, 0.0);
			osLabelAxisY.AnchorPoint = new Point3D(0.0, num, 0.0);
			osLabelAxisZ.AnchorPoint = new Point3D(0.0, 0.0, num);
			_0023_003Dz8R9Ht3ly7amE(_0023_003DzndAYios_003D, osLabelAxisX, _0023_003DzCBM7XJK4_5H_0024.Viewport.Camera, _0023_003DzCBM7XJK4_5H_0024.ViewFrame);
			_0023_003Dz8R9Ht3ly7amE(_0023_003DzndAYios_003D, osLabelAxisY, _0023_003DzCBM7XJK4_5H_0024.Viewport.Camera, _0023_003DzCBM7XJK4_5H_0024.ViewFrame);
			_0023_003Dz8R9Ht3ly7amE(_0023_003DzndAYios_003D, osLabelAxisZ, _0023_003DzCBM7XJK4_5H_0024.Viewport.Camera, _0023_003DzCBM7XJK4_5H_0024.ViewFrame);
		}
	}

	private void _0023_003Dz8R9Ht3ly7amE(Transformation _0023_003DzndAYios_003D, Label _0023_003DzaO_0024_BNc_003D, Camera _0023_003Dz5rO44GFvhrL3, int[] _0023_003DzBppTnBIbeUl7)
	{
		if (_0023_003Dz5rO44GFvhrL3.ProjectionMatrix != null)
		{
			double[] array = _0023_003DzUiFXEqJwC41M(Utility.MultMatrixd(_0023_003Dz5rO44GFvhrL3.ModelViewMatrix, _0023_003Dz5rO44GFvhrL3.ProjectionMatrix));
			if (_0023_003DzndAYios_003D != null)
			{
				array = Utility.MultMatrixd(_0023_003DzndAYios_003D.MatrixAsVectorByColumn, array);
			}
			_0023_003DzaO_0024_BNc_003D.UpdatePos(_0023_003Dz5rO44GFvhrL3.renderContext, array, _0023_003DzBppTnBIbeUl7);
		}
		else
		{
			_0023_003DzaO_0024_BNc_003D.xPos = float.MinValue;
			_0023_003DzaO_0024_BNc_003D.yPos = float.MinValue;
			_0023_003DzaO_0024_BNc_003D.zPos = 0.0;
		}
	}

	internal void _0023_003Dz1lQiK8IwvEb9(RenderContextBase _0023_003DzmNZD0Zs_003D, float _0023_003DzCzsr4CTVr_Ea)
	{
		int dy = Size;
		if (osLabelOrigin.Alignment == ContentAlignment.TopLeft)
		{
			dy = -Size;
		}
		osLabelOrigin.DrawWithOffset(_0023_003DzmNZD0Zs_003D, 0, dy, _0023_003DzCzsr4CTVr_Ea);
		if (StyleMode == originSymbolStyleType.CoordinateSystem)
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
	}

	internal bool _0023_003Dz4XAvJ5aCRLKs(OriginSymbol _0023_003DzAbAO3f4_003D)
	{
		if (StyleMode == _0023_003DzAbAO3f4_003D.StyleMode && Size == _0023_003DzAbAO3f4_003D.Size && StyleMode == _0023_003DzAbAO3f4_003D.StyleMode && LabelFont != null && LabelFont.Equals(_0023_003DzAbAO3f4_003D.LabelFont) && !(LabelColorName != _0023_003DzAbAO3f4_003D.LabelColorName) && !(LabelColorX != _0023_003DzAbAO3f4_003D.LabelColorX) && !(LabelColorY != _0023_003DzAbAO3f4_003D.LabelColorY) && !(LabelColorZ != _0023_003DzAbAO3f4_003D.LabelColorZ) && !(ArrowColorX != _0023_003DzAbAO3f4_003D.ArrowColorX) && !(ArrowColorY != _0023_003DzAbAO3f4_003D.ArrowColorY) && !(ArrowColorZ != _0023_003DzAbAO3f4_003D.ArrowColorZ) && !(LabelOrigin != _0023_003DzAbAO3f4_003D.LabelOrigin) && !(LabelAxisX != _0023_003DzAbAO3f4_003D.LabelAxisX) && !(LabelAxisY != _0023_003DzAbAO3f4_003D.LabelAxisY) && !(LabelAxisZ != _0023_003DzAbAO3f4_003D.LabelAxisZ) && base.Visible == _0023_003DzAbAO3f4_003D.Visible)
		{
			return base.Lighting != _0023_003DzAbAO3f4_003D.Lighting;
		}
		return true;
	}

	internal virtual bool _0023_003DzL28lpFu5le27()
	{
		if ((!base.Visible || LabelOrigin != null) && drawSphere != null && !drawSphere.NeedToCompile() && drawArrow != null && !drawArrow.NeedToCompile())
		{
			return osLabelOrigin.Image == null;
		}
		return true;
	}

	public override object Clone()
	{
		return new OriginSymbol(this)
		{
			_0023_003DzzmO0Pua6gdb0 = _0023_003DzzmO0Pua6gdb0
		};
	}

	public override void Update(IUserInterfaceElement another)
	{
		OriginSymbol originSymbol = (OriginSymbol)another;
		Size = originSymbol._0023_003DzgTjCWc4_003D;
		StyleMode = originSymbol.StyleMode;
		LabelColorName = originSymbol.LabelColorName;
		LabelColorX = originSymbol.LabelColorX;
		LabelColorY = originSymbol.LabelColorY;
		LabelColorZ = originSymbol.LabelColorZ;
		ArrowColorX = originSymbol.ArrowColorX;
		ArrowColorY = originSymbol.ArrowColorY;
		ArrowColorZ = originSymbol.ArrowColorZ;
		LabelOrigin = originSymbol.LabelOrigin;
		LabelAxisX = originSymbol.LabelAxisX;
		LabelAxisY = originSymbol.LabelAxisY;
		LabelAxisZ = originSymbol.LabelAxisZ;
		LabelFont = originSymbol.LabelFont;
		UpdateLabelFont(this);
		UpdateOriginLabelAlignment(this);
		base.Visible = originSymbol.Visible;
	}

	protected void UpdateOriginLabelAlignment(OriginSymbol os)
	{
		if (StyleMode == originSymbolStyleType.Ball)
		{
			os.osLabelOrigin.Alignment = ContentAlignment.BottomLeft;
		}
		else
		{
			os.osLabelOrigin.Alignment = ContentAlignment.TopLeft;
		}
	}

	public override Rectangle GetBounds(Viewport viewport)
	{
		Point3D point3D = viewport.WorldToScreen(Point3D.Origin);
		point3D.Y = (double)viewport._0023_003Dz0TvaYNo_003D._0023_003DzNwtRJ3cLTrAy() - point3D.Y;
		Rectangle result = new Rectangle((int)(point3D.X - (double)(Size * 4)), (int)(point3D.Y - (double)(Size * 4)), 8 * Size, 8 * Size);
		if (StyleMode == originSymbolStyleType.CoordinateSystem)
		{
			result.Inflate(6 * Size, 6 * Size);
		}
		return result;
	}

	public override Image GetThumbnail(Viewport viewport, Size size, Color backgroundColor)
	{
		Point3D target = viewport.Camera.Target;
		viewport.Camera.Target = Point3D.Origin;
		viewport.Camera.UpdateMatrices();
		_0023_003DzKa9hVOo_003D(new DrawSceneParams
		{
			Viewport = viewport,
			RenderContext = viewport._0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D
		}, StyleMode == originSymbolStyleType.Ball);
		Image thumbnail = base.GetThumbnail(viewport, size, backgroundColor);
		viewport.Camera.Target = target;
		viewport.Camera.UpdateMatrices();
		return thumbnail;
	}

	protected override void DrawForBitmap(object drawSceneParams)
	{
		DrawSceneParams drawSceneParams2 = (DrawSceneParams)drawSceneParams;
		if (!drawSceneParams2.ZoomRect.IsEmpty)
		{
			drawSceneParams2.Viewport.Camera.RecomputeProjection(drawSceneParams2.RenderContext, drawSceneParams2.ViewportSize, drawSceneParams2.ZoomRect, _0023_003Dz5a0lNBR9CWFl: false, _0023_003Dz_OlmZyU_003D: false, CameraEyePosType.Center);
		}
		UpdateScreenToWorld((Viewport)drawSceneParams2.Viewport, drawSceneParams2.ViewFrame);
		base.DrawForBitmap((object)drawSceneParams2);
	}
}
