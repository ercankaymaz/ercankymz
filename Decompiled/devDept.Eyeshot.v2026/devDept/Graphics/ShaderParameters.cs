using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using devDept.Eyeshot;
using devDept.Geometry;

namespace devDept.Graphics;

public class ShaderParameters : ShaderParametersBase
{
	public struct ClipPlane
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private float _0023_003DznSKWu0U_GXZ8VlZ0YA_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private float _0023_003DzvIaviwJ2R9Txx45uiw_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private float _0023_003DzZsYCzNiQ8PYruCsYIA_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private float _0023_003DzPndl6wF1CY5b7NUhtQ_003D_003D;

		public readonly float X
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DznSKWu0U_GXZ8VlZ0YA_003D_003D;
			}
		}

		public readonly float Y
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzvIaviwJ2R9Txx45uiw_003D_003D;
			}
		}

		public readonly float Z
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzZsYCzNiQ8PYruCsYIA_003D_003D;
			}
		}

		public readonly float W
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzPndl6wF1CY5b7NUhtQ_003D_003D;
			}
		}

		public float[] Params => new float[4] { X, Y, Z, W };

		public ClipPlane(float[] @params)
		{
			_0023_003Dz8vQIrOc_003D(@params[0]);
			_0023_003DzsMht64A_003D(@params[1]);
			_0023_003Dz0ONWN20_003D(@params[2]);
			_0023_003Dza8IbxI8_003D(@params[3]);
		}

		public ClipPlane(float x, float y, float z, float w)
		{
			_0023_003Dz8vQIrOc_003D(x);
			_0023_003DzsMht64A_003D(y);
			_0023_003Dz0ONWN20_003D(z);
			_0023_003Dza8IbxI8_003D(w);
		}

		private void _0023_003Dz8vQIrOc_003D(float _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003DznSKWu0U_GXZ8VlZ0YA_003D_003D = _0023_003DzPzO_0024GUk_003D;
		}

		private void _0023_003DzsMht64A_003D(float _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003DzvIaviwJ2R9Txx45uiw_003D_003D = _0023_003DzPzO_0024GUk_003D;
		}

		private void _0023_003Dz0ONWN20_003D(float _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003DzZsYCzNiQ8PYruCsYIA_003D_003D = _0023_003DzPzO_0024GUk_003D;
		}

		private void _0023_003Dza8IbxI8_003D(float _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003DzPndl6wF1CY5b7NUhtQ_003D_003D = _0023_003DzPzO_0024GUk_003D;
		}

		public override string ToString()
		{
			return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302663997), X, Y, Z, W);
		}
	}

	internal class LightsData : ILightsData
	{
		public float[] Position { get; set; }

		public float[] Direction { get; set; }

		public float[] Ambient { get; set; }

		public float[] Diffuse { get; set; }

		public float[] Specular { get; set; }

		public float ConstantAttenuation { get; set; }

		public float LinearAttenuation { get; set; }

		public float QuadraticAttenuation { get; set; }

		public float SpotCosCutoff { get; set; }

		public float SpotExponent { get; set; }

		public int YieldShadow { get; set; }

		public lightType Type { get; set; }
	}

	public bool Selected;

	public bool ColorsModulatedByIntensity;

	public bool MulticolorNoLightsWithNormals;

	public bool Multicolor;

	public bool Texture2D;

	public bool Texture1D;

	public bool AlphaMap;

	public bool WithNormals;

	public shaderPrimitiveType PrimitiveType;

	public textureEnvironmentType TextureEnvironment;

	public IEnvironment Environment;

	public bool Lighting;

	public bool UseColorForAmbientAndDiffuse;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Camera _0023_003DzyKeyfRQ3HVi_;

	public int[] ViewFrame;

	public float DrawScale;

	public RectangleF ZoomRect;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly ShadowMapData _0023_003DzOUx7EzFzJRuJ9E2ezxAXKF4_003D;

	public float ShadowAmbientFactor;

	public bool EnvironmentMapping;

	public int[] LightsEnabled = new int[8];

	public int NumberOfSplits;

	public float[] ShadowTextureScale;

	public int LightWithShadow = -1;

	public bool FirstPass = true;

	public int NumberOfPasses = 1;

	public shadowType ShadowMode;

	public bool DoShadows;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Transformation _0023_003Dzrvt_0024X2xZWPdM;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float _0023_003DzCHlhbSQfDsdIWx0pD5MQwe1hecdj;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float[] _0023_003DzvAP7uHZGrSq5OStnbrKXk1w_003D;

	public realisticShadowQualityType ShadowQuality;

	public IBackgroundSettings Background;

	public BackfaceSettings Backface;

	internal LightsData[] Lights;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float[] _0023_003DzqnlBILT49xWIR9r_KR3Snfk_003D;

	public bool AlphaClip;

	protected const int CLIP_PLANES_NUM = 6;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ClipPlane[] _0023_003DzMPN2OOrd_hRTJNJUFZmqVLg_003D = new ClipPlane[6];

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool[] _0023_003DzRvbDXge4ANKyc3p_eCPewg4_003D = new bool[6];

	public bool TextureOverExposure;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz0jqNni3Ap6OFE6_u7_0024NhMGiytbyu;

	public bool ForceSetTransform;

	public Camera Camera
	{
		get
		{
			return _0023_003DzyKeyfRQ3HVi_;
		}
		set
		{
			_0023_003DzyKeyfRQ3HVi_ = value;
		}
	}

	public ShadowMapData ShadowMapData
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzOUx7EzFzJRuJ9E2ezxAXKF4_003D;
		}
	}

	public Transformation BlockRefTransform
	{
		get
		{
			return _0023_003Dzrvt_0024X2xZWPdM;
		}
		set
		{
			_0023_003Dzrvt_0024X2xZWPdM = value;
			_0023_003DzvAP7uHZGrSq5OStnbrKXk1w_003D = null;
		}
	}

	public float[] BlockRefTansformMatrix
	{
		get
		{
			if (_0023_003DzvAP7uHZGrSq5OStnbrKXk1w_003D == null && BlockRefTransform != null)
			{
				_0023_003DzvAP7uHZGrSq5OStnbrKXk1w_003D = BlockRefTransform.MatrixAsVectorFloatByColumn;
			}
			return _0023_003DzvAP7uHZGrSq5OStnbrKXk1w_003D;
		}
	}

	internal float[] SceneAmbient
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzqnlBILT49xWIR9r_KR3Snfk_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzqnlBILT49xWIR9r_KR3Snfk_003D = value;
		}
	}

	public ClipPlane[] ClipPlanes
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzMPN2OOrd_hRTJNJUFZmqVLg_003D;
		}
	}

	public bool[] ClipPlanesEnabled
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzRvbDXge4ANKyc3p_eCPewg4_003D;
		}
	}

	public bool Clippable
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz0jqNni3Ap6OFE6_u7_0024NhMGiytbyu;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz0jqNni3Ap6OFE6_u7_0024NhMGiytbyu = value;
		}
	}

	public ShaderParameters(RenderContextBase renderContext)
		: base(renderContext)
	{
	}

	public ShaderParameters(RenderContextBase renderContext, int[] viewFrame, Camera camera, shadowType shadowMode, realisticShadowQualityType shadowQuality, IBackgroundSettings background, BackfaceSettings backface, bool environmentMapping, Transformation initialSceneTransformation)
		: this(renderContext, viewFrame, camera, shadowMode, shadowQuality, background, backface, environmentMapping, 1f, RectangleF.Empty, initialSceneTransformation)
	{
	}

	public ShaderParameters(RenderContextBase renderContext, int[] viewFrame, Camera camera, shadowType shadowMode, realisticShadowQualityType shadowQuality, IBackgroundSettings background, BackfaceSettings backface, bool environmentMapping, float drawScale, RectangleF zoomRect, Transformation initialSceneTransformation)
		: base(renderContext)
	{
		Backface = backface;
		ShadowQuality = shadowQuality;
		Background = background;
		ViewFrame = viewFrame;
		DrawScale = drawScale;
		ZoomRect = zoomRect;
		_0023_003DzOUx7EzFzJRuJ9E2ezxAXKF4_003D = renderContext.globalShadowMapData;
		ShadowAmbientFactor = RenderContextBase.GetShadowAmbientFactor(renderContext.ActiveLights);
		EnvironmentMapping = environmentMapping;
		_0023_003DzyKeyfRQ3HVi_ = camera;
		BlockRefTransform = new Identity();
		ShadowMode = (renderContext.SupportShadows ? shadowMode : shadowType.None);
		NumberOfSplits = renderContext.GetNumberOfShadowMapSplits(shadowQuality, renderContext.ActiveLights);
		switch (NumberOfSplits)
		{
		case 1:
			ShadowTextureScale = new float[2] { 1f, 1f };
			break;
		case 2:
			ShadowTextureScale = new float[2] { 0.5f, 1f };
			break;
		default:
			ShadowTextureScale = new float[2] { 0.5f, 0.5f };
			break;
		}
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302663962), AlphaMap));
		stringBuilder.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302663950), ColorsModulatedByIntensity));
		stringBuilder.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302664148), Lighting));
		stringBuilder.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302664136), Multicolor));
		stringBuilder.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302664126), ShadowMode));
		stringBuilder.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302664112), TextureOverExposure));
		stringBuilder.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302663798), Texture2D));
		stringBuilder.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302663783), Texture1D));
		stringBuilder.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302663773), TextureEnvironment));
		return stringBuilder.ToString();
	}

	public void ResetBlockRefTransform()
	{
		_0023_003Dzrvt_0024X2xZWPdM = new Identity();
	}

	public void Set(bool texture, bool lighting, bool multicolor, bool texture1D)
	{
	}

	internal float _0023_003DzHra2fjngell6mfGg8_0024i3OQU_003D()
	{
		return _0023_003DzCHlhbSQfDsdIWx0pD5MQwe1hecdj;
	}

	internal void _0023_003DzrzWQM66GMVu0JW_00249HKIjYKo_003D(float _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzCHlhbSQfDsdIWx0pD5MQwe1hecdj = _0023_003DzPzO_0024GUk_003D;
	}

	internal void _0023_003Dzx7w5iaoKWbUL(ShaderParameters _0023_003Dzl_0024MIsC0_003D)
	{
		Environment = _0023_003Dzl_0024MIsC0_003D.Environment;
		Texture2D = _0023_003Dzl_0024MIsC0_003D.Texture2D;
		AlphaMap = _0023_003Dzl_0024MIsC0_003D.AlphaMap;
		Lighting = _0023_003Dzl_0024MIsC0_003D.Lighting;
		Multicolor = _0023_003Dzl_0024MIsC0_003D.Multicolor;
		Texture1D = _0023_003Dzl_0024MIsC0_003D.Texture1D;
		PrimitiveType = _0023_003Dzl_0024MIsC0_003D.PrimitiveType;
	}

	public void PrepareForWireframe()
	{
		Environment = null;
		Texture2D = false;
		AlphaMap = false;
		Lighting = false;
		Multicolor = false;
		Texture1D = false;
		PrimitiveType = shaderPrimitiveType.Line;
	}

	public void PrepareForRender(RenderContextBase renderContext, IEnvironment environment)
	{
		Environment = environment;
		Texture2D = false;
		AlphaMap = false;
		Lighting = true;
		Multicolor = false;
		Texture1D = false;
	}

	public void PrepareForTransparency(RenderContextBase renderContext, IEnvironment environment)
	{
		Environment = environment;
		Texture2D = false;
		AlphaMap = false;
		Lighting = true;
		Multicolor = true;
		Texture1D = false;
	}

	private void _0023_003DzvAoPB7WVBmUJ(ClipPlane[] _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzMPN2OOrd_hRTJNJUFZmqVLg_003D = _0023_003DzPzO_0024GUk_003D;
	}

	private void _0023_003Dzj7TSiAPKoZvBkReC5w_003D_003D(bool[] _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzRvbDXge4ANKyc3p_eCPewg4_003D = _0023_003DzPzO_0024GUk_003D;
	}

	public ShaderParameters Clone()
	{
		ShaderParameters shaderParameters = new ShaderParameters(RenderContext);
		shaderParameters.ShadowQuality = ShadowQuality;
		shaderParameters.Background = Background;
		shaderParameters.Backface = Backface;
		shaderParameters.AlphaClip = AlphaClip;
		shaderParameters.TextureOverExposure = TextureOverExposure;
		shaderParameters.ForceSetTransform = ForceSetTransform;
		shaderParameters.Selected = Selected;
		shaderParameters.ColorsModulatedByIntensity = ColorsModulatedByIntensity;
		shaderParameters.MulticolorNoLightsWithNormals = MulticolorNoLightsWithNormals;
		shaderParameters.Multicolor = Multicolor;
		shaderParameters.Texture2D = Texture2D;
		shaderParameters.Texture1D = Texture1D;
		shaderParameters.AlphaMap = AlphaMap;
		shaderParameters.WithNormals = WithNormals;
		shaderParameters.PrimitiveType = PrimitiveType;
		shaderParameters.TextureEnvironment = TextureEnvironment;
		shaderParameters.Environment = Environment;
		shaderParameters.Lighting = Lighting;
		shaderParameters.UseColorForAmbientAndDiffuse = UseColorForAmbientAndDiffuse;
		shaderParameters.DrawScale = DrawScale;
		shaderParameters.ZoomRect = ZoomRect;
		shaderParameters.NumberOfSplits = NumberOfSplits;
		shaderParameters.LightWithShadow = LightWithShadow;
		shaderParameters.FirstPass = FirstPass;
		shaderParameters.DoShadows = DoShadows;
		shaderParameters.NumberOfPasses = NumberOfPasses;
		shaderParameters.ShadowMode = ShadowMode;
		shaderParameters._0023_003DzrzWQM66GMVu0JW_00249HKIjYKo_003D(_0023_003DzHra2fjngell6mfGg8_0024i3OQU_003D());
		shaderParameters.ShadowAmbientFactor = ShadowAmbientFactor;
		shaderParameters.EnvironmentMapping = EnvironmentMapping;
		shaderParameters._0023_003DzyKeyfRQ3HVi_ = (Camera)_0023_003DzyKeyfRQ3HVi_.Clone();
		shaderParameters.ViewFrame = (int[])ViewFrame.Clone();
		shaderParameters.LightsEnabled = (int[])LightsEnabled.Clone();
		shaderParameters.ShadowTextureScale = (float[])ShadowTextureScale?.Clone();
		shaderParameters._0023_003Dzrvt_0024X2xZWPdM = (Transformation)(BlockRefTransform?.Clone());
		shaderParameters._0023_003DzvAP7uHZGrSq5OStnbrKXk1w_003D = (float[])BlockRefTansformMatrix?.Clone();
		shaderParameters.Clippable = Clippable;
		return shaderParameters;
	}
}
