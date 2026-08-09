using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Graphics;

public abstract class RenderContextBase : IDisposable
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static DrawEntityCallBack _0023_003DzIVH6fSPR9msJUI_0024f7Q_003D_003D;

		internal void _0023_003Dz9kiAHz3Tz4AGCp3ilbhPsVbyV_0024ue(RenderContextBase _0023_003Dz8If0AEk_003D, object _0023_003DzmPmPjCPqZ3T3)
		{
			_0023_003Dz8If0AEk_003D.DrawIndexedTriangles((VBOParamsTexture)_0023_003DzmPmPjCPqZ3T3);
		}
	}

	public delegate void drawSceneFuncDelegate(object drawSceneParams);

	public enum matrixType
	{
		All,
		Projection,
		ModelView
	}

	public enum vendorName
	{
		Other,
		Nvidia,
		AMD,
		Intel
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal vendorName _0023_003Dzzvrni3PfeabX;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzHKHSzI5gC_Mt6NcPlg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003DzGRQUNwCv2RFRcWqPTOlYUcmpab6MR5J5mQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly ControlData _0023_003DzvJZaEvEY4ktxSqWSzg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IWorkspace _0023_003DziUCzXJ9LaiWwz9hKxg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal int _0023_003DzzryqcGDsgXHX;

	public const float DefaultPointSize = 1f;

	public const float DefaultLineWidth = 1f;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal float _0023_003Dz7M1xDzbLpt1s = 1f;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal float _0023_003Dzz73_0024dseP1PQg = 1f;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003DzKp52Cl9ff7y2 = Color.Black;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Material _0023_003DzoIFulAZFykiV = new Material(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302662795), Color.Black, Color.Black, Color.Black, 1f, 0f);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Material _0023_003DzEsrXDjXWezOL = new Material(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302663521), Color.Black, Color.White, Color.Black, 0f, 0f, null);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003DzGAgy_0024Qp7pFXyfiSK5w_003D_003D;

	public const double OverlayDepthRange = 0.001;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dzb10NUrrjwPa382VxxjiOZ_o_003D;

	protected internal IntPtr hdc;

	protected internal IntPtr hrc;

	protected IntPtr wnd;

	protected bool ColorsBits16;

	protected const int RedShift16Bpp = 11;

	protected const int GreenShift16Bpp = 5;

	protected const int BlueShift16Bpp = 0;

	protected int BlueShift;

	protected int GreenShift = 8;

	protected int RedShift = 16;

	protected int RedMaxVal = 256;

	protected int GreenMaxVal = 256;

	protected int BlueMaxVal = 256;

	protected int MaxColorVal = 16777215;

	protected Dictionary<byte, byte> redBlue16BitDictionary;

	protected Dictionary<byte, byte> green16BitDictionary;

	protected byte[] redBlue16BppMap = new byte[32]
	{
		0, 8, 16, 24, 33, 41, 49, 57, 66, 74,
		82, 90, 99, 107, 115, 123, 132, 140, 148, 156,
		165, 173, 181, 189, 198, 206, 214, 222, 231, 239,
		247, 255
	};

	protected byte[] green16BppMap = new byte[64]
	{
		0, 4, 8, 12, 16, 20, 24, 28, 32, 36,
		40, 44, 48, 52, 56, 60, 65, 69, 73, 77,
		81, 85, 89, 93, 97, 101, 105, 109, 113, 117,
		121, 125, 130, 134, 138, 142, 146, 150, 154, 158,
		162, 166, 170, 174, 178, 182, 186, 190, 195, 199,
		203, 207, 211, 215, 219, 223, 227, 231, 235, 239,
		243, 247, 251, 255
	};

	protected internal float currDepthMin;

	protected internal float currDepthMax = 1f;

	protected internal int[] currViewFrame;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Stack<IEnvironment> _0023_003DzfDj0j_O1tJI4 = new Stack<IEnvironment>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private rasterizerStateType _0023_003DzuVL21Nxo5x_AzeceFbkWF1A_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private depthStencilStateType _0023_003DzR2NFC6jGVUQp0kOQt30PV74_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private blendStateType _0023_003Dz9cZgShQAQYbXx8yX586UgpY_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Stack<rasterizerStateType> _0023_003Dz3TxoWfLIPNsPUEzdc41VD78_003D = new Stack<rasterizerStateType>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Stack<depthStencilStateType> _0023_003DzD6tPEj6zdb8L = new Stack<depthStencilStateType>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Stack<blendStateType> _0023_003DzP6ACG08767Ml = new Stack<blendStateType>();

	protected bool InvalidatedConstantBuffers;

	protected internal Dictionary<shaderType, IShaderTechnique> Shaders;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Stack<shaderType> _0023_003DzBQ8RqgdR_0024EGqFkGU9w_003D_003D = new Stack<shaderType>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzXEokG1evGui0TWhjEZmPFaIzDKMt;

	protected Stack<double[]> projMatrices = new Stack<double[]>(new double[1][] { IdentityMatrixDouble });

	protected Stack<double[]> viewMatrices = new Stack<double[]>(new double[1][] { IdentityMatrixDouble });

	protected Stack<double[]> modelMatrices = new Stack<double[]>(new double[1][] { IdentityMatrixDouble });

	protected Size texSize;

	protected TextureBase[] texturesForCapture;

	protected internal TextureBase DepthTextureForPostProcessing;

	protected internal TextureBase MaskTextureForPostProcessing;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool[] _0023_003DzzW3dSjRL0oLt = new bool[8];

	protected int prevPolygonOffset;

	protected internal Dictionary<shaderType, IShaderTechnique> ReflectionShaders;

	protected EntityGraphicsData CompilingEntity;

	protected internal static StringBuilder graphicalIssues;

	public static bool MultipleLightsWithShadows = false;

	public const int SHADOW_TEXTURE_SIZE = 256;

	protected internal const int KERNEL_SIZE = 19;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IShader _0023_003DzJHK4iCIfRpq7;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IShader _0023_003Dz7eXxUm84fHqP;

	public FrustumData frustumData;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private shaderType _0023_003DzK__0024j4HwFKsA3sNQCnQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz5GFKk2OIaRZ8;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private EntityGraphicsData _0023_003DzeWSfrbelj_0024MCfXc9kwWHK_s_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private colorMaskFlags _0023_003DzcHyhEzo2jLqItkwVK39lVfo_003D = colorMaskFlags.RGBA;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private colorMaterialType _0023_003Dz_00244DpoaLsDT5s;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz4SjcBbKskKht;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dzmfb0KEd0lJJt;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dzm2OyT8qCbJ7h1QCQmRf0W78_003D;

	protected bool lineStipple;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzevpTLAjaYrgv;

	internal static Color selectionWithHaloColor = Color.FromArgb(255, 255, 0, 255);

	internal static Color selectionWithHaloBackColor = Color.FromArgb(255, 128, 0, 255);

	internal static Color selectionWithoutHaloColor = Color.FromArgb(80, 0, 255, 0);

	internal static Color selectionWithThickHaloColor = Color.FromArgb(255, 255, 0, 0);

	internal static Color selectionWithThickHaloBackColor = Color.FromArgb(255, 128, 0, 0);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzyApymZ5KgNQ3VcXtzg_003D_003D = true;

	public bool UsingShadowFBO = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static int _0023_003Dz_0024i6EYYVd3hV6CzSV7A_003D_003D = 4;

	protected internal ShadowMapData globalShadowMapData;

	internal int compositingAvailabilityFlags = int.MaxValue;

	public ProgDrawCompositingBase ProgDrawCompositingBase;

	internal SmoothUICompositingBase smoothUICompositing;

	internal AOCompositingBase aoCompositing;

	internal SilhoCompositingBase silhoCompositing;

	internal HaloSelectionCompositingBase dynamicSelectionCompositing;

	internal HaloSelectionCompositingBase staticSelectionCompositing;

	protected internal TextureBase aoNoiseTexture;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private EntityGraphicsData _0023_003DzW70aGT4iRDyqZJb7Gg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzDpDUWL3qLTQhfI3oKg_003D_003D = 1;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private LightSettings[] _0023_003DzJ2qPSzaJNmg9tDlZXQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float[] _0023_003DzDd_hgOLU_0024BR_0024 = new float[4] { 0.2f, 0.2f, 0.2f, 1f };

	[CLSCompliant(false)]
	protected uint shadowMapFBOSize = 2048u;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz9Oh2ogQ_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Size _0023_003DzkxACDv3Y64U0He6mXQ_003D_003D = Size.Empty;

	public vendorName Vendor => _0023_003Dzzvrni3PfeabX;

	public string VendorName
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzHKHSzI5gC_Mt6NcPlg_003D_003D;
		}
		[CompilerGenerated]
		protected set
		{
			_0023_003DzHKHSzI5gC_Mt6NcPlg_003D_003D = value;
		}
	}

	public ControlData ControlData
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzvJZaEvEY4ktxSqWSzg_003D_003D;
		}
	}

	public bool IsControlMinimized => ControlData.ControlSize.IsEmpty;

	protected IWorkspace ParentWorkspace
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DziUCzXJ9LaiWwz9hKxg_003D_003D;
		}
	}

	public float CurrentPointSize => _0023_003Dz7M1xDzbLpt1s;

	public float CurrentLineWidth => _0023_003Dzz73_0024dseP1PQg;

	public Color CurrentWireColor => _0023_003DzKp52Cl9ff7y2;

	public Material CurrentMaterial => _0023_003DzoIFulAZFykiV;

	public Material CurrentBackMaterial => _0023_003DzEsrXDjXWezOL;

	public bool IsDirect3D
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzb10NUrrjwPa382VxxjiOZ_o_003D;
		}
		[CompilerGenerated]
		protected set
		{
			_0023_003Dzb10NUrrjwPa382VxxjiOZ_o_003D = value;
		}
	}

	public IEnvironment CurrentEnvironmentMap
	{
		get
		{
			return CurrentMaterial.EnvironmentMappingTexture;
		}
		protected set
		{
			CurrentMaterial._0023_003Dz2nwJSxNyvKB_21BckA_003D_003D(value);
		}
	}

	public rasterizerStateType CurrentRasterizerState => _0023_003DzuVL21Nxo5x_AzeceFbkWF1A_003D;

	public depthStencilStateType CurrentDepthStencilState
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzR2NFC6jGVUQp0kOQt30PV74_003D;
		}
	}

	public blendStateType CurrentBlendState
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz9cZgShQAQYbXx8yX586UgpY_003D;
		}
	}

	public IShaderTechnique CurrentShaderTechnique
	{
		get
		{
			if (Shaders != null && Shaders.ContainsKey(CurrentShader))
			{
				return Shaders[CurrentShader];
			}
			return null;
		}
	}

	public static float[] IdentityMatrix => new float[16]
	{
		1f, 0f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 0f,
		1f, 0f, 0f, 0f, 0f, 1f
	};

	public static double[] IdentityMatrixDouble => new double[16]
	{
		1.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0, 0.0, 0.0, 0.0,
		1.0, 0.0, 0.0, 0.0, 0.0, 1.0
	};

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public static StringBuilder GraphicalIssues => graphicalIssues;

	public shaderType CurrentShader
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzK__0024j4HwFKsA3sNQCnQ_003D_003D;
		}
		[CompilerGenerated]
		internal set
		{
			_0023_003DzK__0024j4HwFKsA3sNQCnQ_003D_003D = value;
		}
	}

	public EntityGraphicsData GraphicsDataWithError
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzeWSfrbelj_0024MCfXc9kwWHK_s_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzeWSfrbelj_0024MCfXc9kwWHK_s_003D = value;
		}
	}

	public bool FrontFaceCW
	{
		get
		{
			return _0023_003Dz5GFKk2OIaRZ8;
		}
		set
		{
			_0023_003Dz5GFKk2OIaRZ8 = value;
			SetState(CurrentRasterizerState);
		}
	}

	public abstract bool SupportShadows { get; }

	public colorMaskFlags CurrentColorMask
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzcHyhEzo2jLqItkwVK39lVfo_003D;
		}
	}

	public virtual colorMaterialType ColorMaterialMode
	{
		get
		{
			return _0023_003Dz_00244DpoaLsDT5s;
		}
		set
		{
			_0023_003Dz_00244DpoaLsDT5s = value;
		}
	}

	public bool IsDrawingForDepth
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzm2OyT8qCbJ7h1QCQmRf0W78_003D;
		}
	}

	[Browsable(false)]
	[Description("Renderer version.")]
	public abstract Version RendererVersion { get; }

	[Browsable(false)]
	[Description("Renderer name.")]
	public abstract string RendererName { get; }

	public virtual bool ReflectionsSupported => true;

	public virtual bool TextureNonPowerOfTwo => true;

	public int NumberOfSplits => _0023_003DzDpDUWL3qLTQhfI3oKg_003D_003D;

	public LightSettings[] ActiveLights => _0023_003DzJ2qPSzaJNmg9tDlZXQ_003D_003D;

	public RenderContextBase(Size size, ControlData data, IWorkspace parentWorkspace)
	{
		_0023_003DzvJZaEvEY4ktxSqWSzg_003D_003D = data;
		ControlData.ControlSize = size;
		graphicalIssues = new StringBuilder();
		_0023_003DzHnOQoDt9c_0024HS(parentWorkspace);
	}

	protected abstract void SetVendorName();

	protected void SetVendorName(string vendorName)
	{
		VendorName = vendorName;
		string text = vendorName.ToUpper();
		if (text.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302663515)))
		{
			_0023_003Dzzvrni3PfeabX = RenderContextBase.vendorName.Nvidia;
		}
		else if (text.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302663498)))
		{
			_0023_003Dzzvrni3PfeabX = RenderContextBase.vendorName.AMD;
		}
		else if (text.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302663476)))
		{
			_0023_003Dzzvrni3PfeabX = RenderContextBase.vendorName.Intel;
		}
		else
		{
			_0023_003Dzzvrni3PfeabX = RenderContextBase.vendorName.Other;
		}
	}

	protected void SetRealAntialiasingSamples(int fsaaSamples)
	{
		ControlData._0023_003DzS3jyMU6piOKbt8f8zFkfA_0024c8ylI5(fsaaSamples);
	}

	protected void SetIsBestAdapterAvailable(bool value)
	{
		ControlData._0023_003Dz5LAqOjoTo3cQ_0024nm6vg_003D_003D(value);
	}

	private void _0023_003DzHnOQoDt9c_0024HS(IWorkspace _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DziUCzXJ9LaiWwz9hKxg_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	internal void _0023_003DzVGPF9Wec3DPz(Color _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzKp52Cl9ff7y2 = _0023_003DzPzO_0024GUk_003D;
	}

	internal void _0023_003DzqYDUSJ9TteeK(Material _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzoIFulAZFykiV = _0023_003DzPzO_0024GUk_003D;
	}

	internal void _0023_003DzoHAcLveg7Bn_(Material _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzEsrXDjXWezOL = _0023_003DzPzO_0024GUk_003D;
	}

	public bool LightingEnabled()
	{
		return _0023_003DzGAgy_0024Qp7pFXyfiSK5w_003D_003D;
	}

	public bool HasDeviceContext()
	{
		return hdc != IntPtr.Zero;
	}

	public IntPtr DeviceContext()
	{
		return hdc;
	}

	public IntPtr RenderingContext()
	{
		return hrc;
	}

	public virtual double[] CurrentModelViewMatrix()
	{
		return Utility.MultMatrixd(modelMatrices.Peek(), viewMatrices.Peek());
	}

	public virtual double[] CurrentProjectionMatrix()
	{
		return projMatrices.Peek();
	}

	public virtual void Dispose()
	{
		FreeCaptureTextures();
		if (CurrentEnvironmentMap != null)
		{
			CurrentEnvironmentMap.Dispose();
			CurrentEnvironmentMap = null;
		}
		if (globalShadowMapData != null)
		{
			globalShadowMapData.Dispose(this);
			globalShadowMapData = null;
		}
		if (ProgDrawCompositingBase != null)
		{
			ProgDrawCompositingBase.Dispose();
			ProgDrawCompositingBase = null;
		}
		FreeCompositingObjects();
		DisposeDepthForPostProcessing();
		_0023_003DzV6RJqRXq1xJpsZWH_0024Q_003D_003D();
	}

	internal void FreeCompositingObjects()
	{
		smoothUICompositing?.Dispose();
		smoothUICompositing = null;
		dynamicSelectionCompositing?.Dispose();
		dynamicSelectionCompositing = null;
		staticSelectionCompositing?.Dispose();
		staticSelectionCompositing = null;
		aoCompositing?.Dispose();
		aoCompositing = null;
		silhoCompositing?.Dispose();
		silhoCompositing = null;
		aoNoiseTexture?.Dispose();
		aoNoiseTexture = null;
	}

	protected internal void ResizeCompositingObjects(Size size)
	{
		_0023_003DzLgDQR0BRx5zm69H00A_003D_003D(size);
		smoothUICompositing?.ResizeTargets(size);
		dynamicSelectionCompositing?.ResizeTargets(size);
		staticSelectionCompositing?.ResizeTargets(size);
		aoCompositing?.ResizeTargets(size);
		silhoCompositing?.ResizeTargets(size);
	}

	protected virtual void FreeCaptureTextures()
	{
		if (texturesForCapture != null)
		{
			for (int i = 0; i < texturesForCapture.Length; i++)
			{
				texturesForCapture[i].Dispose();
			}
			texturesForCapture = null;
		}
	}

	public abstract bool Create();

	public abstract void MakeCurrent();

	public abstract void SwapBuffers();

	public abstract void EndDraw(bool swapBuffer);

	public abstract bool IsMultisample();

	internal byte _0023_003DzasRVx88EAYoctNi_0024lw_003D_003D(int _0023_003Dz2QVVx8s_003D)
	{
		return redBlue16BppMap[_0023_003Dz2QVVx8s_003D];
	}

	internal byte _0023_003DzNO021_0024vKrg7poyaopw_003D_003D(int _0023_003Dz2QVVx8s_003D)
	{
		return green16BppMap[_0023_003Dz2QVVx8s_003D];
	}

	protected int GetRedBlue16BitId(byte color)
	{
		if (!redBlue16BitDictionary.TryGetValue(color, out var value))
		{
			return -1;
		}
		return value;
	}

	protected int GetGreen16BitId(byte color)
	{
		if (!green16BitDictionary.TryGetValue(color, out var value))
		{
			return -1;
		}
		return value;
	}

	public virtual void Resize(Size size)
	{
		ControlData.ControlSize = size;
	}

	public void SetViewport(int[] viewFrame)
	{
		SetViewport(viewFrame, currDepthMin, currDepthMax);
	}

	public virtual double[] ComputePickMatrix(RectangleF rectangle, Size viewportSize, int[] viewFrame)
	{
		Camera._0023_003Dzpvu8W3vYS_ck(rectangle.X + rectangle.Width / 2f, rectangle.Y + rectangle.Height / 2f, rectangle.Width, rectangle.Height, new Size(viewportSize.Width, viewportSize.Height), out var _0023_003DzlTrXFNo_003D);
		return _0023_003DzlTrXFNo_003D;
	}

	public virtual void SetViewport(int[] viewFrame, float depthMin, float depthMax)
	{
		currDepthMin = depthMin;
		currDepthMax = depthMax;
		currViewFrame = viewFrame;
	}

	public virtual void SetProjectionMatrix(double[] proj)
	{
		double[] d3dProj = proj ?? IdentityMatrixDouble;
		SetMatrices(d3dProj, viewMatrices.Peek(), modelMatrices.Peek());
	}

	public virtual void SetModelViewMatrix(double[] matrix)
	{
		double[] modelView = matrix ?? IdentityMatrixDouble;
		SetMatrices(projMatrices.Peek(), modelView);
	}

	public virtual void SetMatrices(double[] proj, double[] modelView)
	{
		double[] d3dProj = proj ?? IdentityMatrixDouble;
		double[] d3dView = modelView ?? IdentityMatrixDouble;
		SetMatrices(d3dProj, d3dView, IdentityMatrixDouble);
	}

	public virtual void SetModelView(Camera camera)
	{
		SetMatrices(camera.ProjectionMatrix, camera.ModelViewMatrix);
	}

	protected bool ColorChanged(Color col1, Color col2)
	{
		return col1 != col2;
	}

	public Color SetColorWireframe(Color color, bool force = false)
	{
		Color currentWireColor = CurrentWireColor;
		if (force || ColorChanged(color, CurrentWireColor))
		{
			_0023_003DzVGPF9Wec3DPz(color);
			SetRGBA(color.R, color.G, color.B, color.A);
		}
		return currentWireColor;
	}

	public abstract void SetColorMaterial(Color color, bool force = false);

	public void SetColorDiffuse(Color color, Color backColor, bool force = false)
	{
		SetMaterialFrontDiffuse(color, force);
		SetMaterialBackDiffuse(backColor, force);
	}

	public void SetMaterial(Color diffuseFront, Color diffuseBack, Color ambient, Color specular, float shininess, bool force = false)
	{
		if (force || ColorChanged(diffuseFront, CurrentMaterial.Diffuse) || ColorChanged(diffuseBack, CurrentBackMaterial.Diffuse) || ColorChanged(ambient, CurrentMaterial.Ambient) || ColorChanged(ambient, CurrentBackMaterial.Ambient) || ColorChanged(specular, CurrentMaterial.Specular) || shininess != CurrentMaterial.Shininess)
		{
			CurrentMaterial.Diffuse = diffuseFront;
			CurrentMaterial.Ambient = ambient;
			CurrentMaterial.Specular = specular;
			CurrentMaterial.Shininess = shininess;
			CurrentBackMaterial.Diffuse = diffuseBack;
			CurrentBackMaterial.Ambient = ambient;
			SetMaterial(Utility.ColorToFloatArray(diffuseFront), Utility.ColorToFloatArray(diffuseBack), Utility.ColorToFloatArray(ambient), Utility.ColorToFloatArray(specular), shininess * 128f);
		}
	}

	public void SetMaterialBackDiffuse(Color color, bool force = false)
	{
		if (force || ColorChanged(color, CurrentBackMaterial.Diffuse))
		{
			CurrentBackMaterial.Diffuse = color;
			SetMaterialBackDiffuse(Utility.ColorToFloatArray(color));
		}
	}

	public void SetMaterialBackAmbient(Color color, bool force = false)
	{
		if (force || ColorChanged(color, CurrentBackMaterial.Ambient))
		{
			CurrentBackMaterial.Ambient = color;
			SetMaterialBackAmbient(Utility.ColorToFloatArray(color));
		}
	}

	public void SetMaterialFrontAmbientAndDiffuse(Color color, bool force = false)
	{
		SetMaterialFrontAmbient(color, force);
		SetMaterialFrontDiffuse(color, force);
	}

	public void SetMaterialBackAmbientAndDiffuse(Color color, bool force = false)
	{
		SetMaterialBackAmbient(color, force);
		SetMaterialBackDiffuse(color, force);
	}

	public void SetMaterialFrontAmbient(Color color, bool force = false)
	{
		if (force || ColorChanged(color, CurrentMaterial.Ambient))
		{
			CurrentMaterial.Ambient = color;
			SetMaterialFrontAmbient(Utility.ColorToFloatArray(color));
		}
	}

	public bool SetMaterial(Material material, Color backColor, bool selected)
	{
		_ = material.Diffuse;
		_ = material.Ambient;
		_ = material.Specular;
		bool result = false;
		if (material.SetTexture(this))
		{
			result = true;
		}
		CurrentMaterial.Texture = material.Texture;
		CurrentMaterial.AlphaMap = material.AlphaMap;
		CurrentMaterial.LinearUnits = material.LinearUnits;
		CurrentMaterial.TextureLength = material.TextureLength;
		SetMaterial(material.Diffuse, backColor, material.Ambient, material.Specular, material.Shininess);
		return result;
	}

	internal Material _0023_003DznAYijHbW1N3q()
	{
		Material material = new Material(CurrentMaterial.Name);
		material.Diffuse = CurrentMaterial.Diffuse;
		material.Ambient = CurrentMaterial.Ambient;
		material.Specular = CurrentMaterial.Specular;
		material.Shininess = CurrentMaterial.Shininess;
		material.Texture = CurrentMaterial.Texture;
		material.AlphaMap = CurrentMaterial.AlphaMap;
		material._0023_003Dz2nwJSxNyvKB_21BckA_003D_003D(CurrentMaterial.EnvironmentMappingTexture);
		material.Environment = CurrentMaterial.Environment;
		return material;
	}

	public void ResetColorDiffuse()
	{
		ResetColorDiffuse(Utility.ColorToFloatArray(CurrentMaterial.Diffuse), Utility.ColorToFloatArray(CurrentWireColor));
		CurrentBackMaterial.Diffuse = CurrentMaterial.Diffuse;
	}

	public void PushEnvironment()
	{
		_0023_003DzfDj0j_O1tJI4.Push(CurrentEnvironmentMap);
	}

	public void PopEnvironment()
	{
		if (_0023_003DzfDj0j_O1tJI4.Count != 0)
		{
			IEnvironment environment = _0023_003DzfDj0j_O1tJI4.Pop();
			if (environment != null)
			{
				SetEnvironment(environment, CurrentMaterial, null);
			}
		}
	}

	public virtual void SetEnvironment(IEnvironment environment, float intensity)
	{
		if (CurrentEnvironmentMap != environment || CurrentMaterial.Environment != intensity)
		{
			CurrentEnvironmentMap = environment;
			if (environment != null)
			{
				environment.Enable(this, intensity);
			}
			else
			{
				CloseEnvironment();
			}
			CurrentMaterial.Environment = intensity;
		}
	}

	public void SetEnvironment(IEnvironment environment, Material material, ShaderParameters shaderParams)
	{
		SetEnvironment(material.EnvironmentMappingTexture ?? environment, material.Environment);
		if (shaderParams != null)
		{
			shaderParams.Environment = CurrentEnvironmentMap;
			shaderParams._0023_003DzrzWQM66GMVu0JW_00249HKIjYKo_003D(CurrentMaterial.Environment);
		}
	}

	public void CloseEnvironment()
	{
		if (CurrentEnvironmentMap != null)
		{
			CurrentEnvironmentMap.Disable(this);
			CurrentEnvironmentMap = null;
		}
	}

	public abstract void ResetColorDiffuse(float[] diffuse, float[] wireColor);

	protected abstract void SetMaterial(float[] diffuseFront, float[] diffuseBack, float[] ambient, float[] specular, float shininess);

	internal void _0023_003DzeGv_0024jdvKknz__0024iqGUUvZXCQ_003D(rasterizerStateType _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzuVL21Nxo5x_AzeceFbkWF1A_003D = _0023_003DzPzO_0024GUk_003D;
	}

	internal void _0023_003DznCr9zn7WFmWWYlspXQ_003D_003D(depthStencilStateType _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzR2NFC6jGVUQp0kOQt30PV74_003D = _0023_003DzPzO_0024GUk_003D;
	}

	internal void _0023_003DzyLAdMMDDytzq(blendStateType _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003Dz9cZgShQAQYbXx8yX586UgpY_003D = _0023_003DzPzO_0024GUk_003D;
	}

	public void PushRasterizerState()
	{
		_0023_003Dz3TxoWfLIPNsPUEzdc41VD78_003D.Push(CurrentRasterizerState);
	}

	public void PopRasterizerState()
	{
		if (_0023_003Dz3TxoWfLIPNsPUEzdc41VD78_003D.Count != 0)
		{
			SetState(_0023_003Dz3TxoWfLIPNsPUEzdc41VD78_003D.Pop());
		}
	}

	public void PushDepthStencilState()
	{
		_0023_003DzD6tPEj6zdb8L.Push(CurrentDepthStencilState);
	}

	public void PopDepthStencilState()
	{
		if (_0023_003DzD6tPEj6zdb8L.Count != 0)
		{
			SetState(_0023_003DzD6tPEj6zdb8L.Pop());
		}
	}

	public void PushBlendState()
	{
		_0023_003DzP6ACG08767Ml.Push(CurrentBlendState);
	}

	public void PopBlendState()
	{
		if (_0023_003DzP6ACG08767Ml.Count != 0)
		{
			SetState(_0023_003DzP6ACG08767Ml.Pop());
		}
	}

	public virtual rasterizerStateType SetState(rasterizerStateType state, bool force = false)
	{
		rasterizerStateType currentRasterizerState = CurrentRasterizerState;
		state = (rasterizerStateType)((int)(state & (rasterizerStateType)(-65)) | ((FrontFaceCW ? 1 : 0) << 6));
		if (state != CurrentRasterizerState || force)
		{
			_0023_003DzeGv_0024jdvKknz__0024iqGUUvZXCQ_003D(state);
			SetStateInternal(state);
		}
		return currentRasterizerState;
	}

	protected rasterizerCullFaceType GetCullFace(rasterizerStateType state)
	{
		return (rasterizerCullFaceType)((int)(state & (rasterizerStateType)24) >> 3);
	}

	protected rasterizerPolygonDrawingType GetPolygonDrawingType(rasterizerStateType state)
	{
		return (rasterizerPolygonDrawingType)((int)(state & rasterizerStateType.CCW_PolygonFill_NoCullFace_NoPolygonOffset) >> 5);
	}

	protected void GetPolygonOffsetValues(rasterizerStateType state, out float factor, out float units)
	{
		switch ((rasterizerPolygonOffsetType)(state & (rasterizerStateType)7))
		{
		case rasterizerPolygonOffsetType.F05_U05:
			factor = 0.5f;
			units = 0.5f;
			break;
		case rasterizerPolygonOffsetType.F1_U1:
			factor = 1f;
			units = 1f;
			break;
		case rasterizerPolygonOffsetType.F2_U2:
			factor = 2f;
			units = 2f;
			break;
		case rasterizerPolygonOffsetType.FMinus05_UMinus1:
			factor = -0.5f;
			units = -1f;
			break;
		case rasterizerPolygonOffsetType.FMinus3_UMinus2:
			factor = -3f;
			units = -2f;
			break;
		case rasterizerPolygonOffsetType.Off:
			factor = 0f;
			units = 0f;
			break;
		default:
			throw new GraphicsException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302663488));
		}
	}

	protected internal bool IsCullFace()
	{
		return GetCullFace(CurrentRasterizerState) != rasterizerCullFaceType.None;
	}

	protected bool IsBlendEnabled(blendStateType state)
	{
		return (int)(state & (blendStateType)1024) >> 10 == 1;
	}

	protected blendStateBlendFactorType GetBlendStateSrcFactor(blendStateType state)
	{
		return (blendStateBlendFactorType)((int)(state & (blendStateType)896) >> 7);
	}

	protected blendStateBlendFactorType GetBlendStateDstFactor(blendStateType state)
	{
		return (blendStateBlendFactorType)((int)(state & (blendStateType)112) >> 4);
	}

	protected blendStateBlendFactorType GetBlendStateSrcAlphaFactor(blendStateType state)
	{
		return (blendStateBlendFactorType)((int)(state & (blendStateType)114688) >> 14);
	}

	protected blendStateBlendFactorType GetBlendStateDstAlphaFactor(blendStateType state)
	{
		return (blendStateBlendFactorType)((int)(state & (blendStateType)14336) >> 11);
	}

	protected colorMaskFlags GetBlendStateColorMask(blendStateType state)
	{
		return (colorMaskFlags)(state & blendStateType.NoBlend);
	}

	protected bool IsDepthTestEnabled(depthStencilStateType state)
	{
		return (int)((long)(state & depthStencilStateType.DepthMaskFalse_DepthTestLess) >> 19) == 1;
	}

	protected bool GetDepthMask(depthStencilStateType state)
	{
		return (int)((long)(state & (depthStencilStateType)262144L) >> 18) == 1;
	}

	protected depthFuncType GetDepthFunc(depthStencilStateType state)
	{
		return (depthFuncType)((long)(state & (depthStencilStateType)229376L) >> 15);
	}

	protected bool IsStencilEnabled(depthStencilStateType state)
	{
		return (int)((long)(state & (depthStencilStateType)16384L) >> 14) == 1;
	}

	protected stencilFuncType GetStencilFunc(depthStencilStateType state)
	{
		return (stencilFuncType)((long)(state & (depthStencilStateType)14336L) >> 11);
	}

	protected int GetStencilFuncRef(depthStencilStateType state)
	{
		return (stencilFuncMaskType)((long)((ulong)(int)state & 0x600uL) >> 9) switch
		{
			stencilFuncMaskType.Zero => 0, 
			stencilFuncMaskType.One => 1, 
			stencilFuncMaskType.FF => 255, 
			_ => throw new GraphicsException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302663431)), 
		};
	}

	protected uint GetStencilFuncMask(depthStencilStateType state)
	{
		return (stencilFuncMaskType)((long)(state & (depthStencilStateType)384L) >> 7) switch
		{
			stencilFuncMaskType.Zero => 0u, 
			stencilFuncMaskType.One => 1u, 
			stencilFuncMaskType.FF => 255u, 
			_ => throw new GraphicsException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302663663)), 
		};
	}

	protected stencilOpActionType GetStencilOpStencilFailAction(depthStencilStateType state)
	{
		return (stencilOpActionType)((long)(state & (depthStencilStateType)96L) >> 5);
	}

	protected stencilOpActionType GetStencilOpDepthFailAction(depthStencilStateType state)
	{
		return (stencilOpActionType)((long)(state & (depthStencilStateType)24L) >> 3);
	}

	protected stencilOpActionType GetStencilOpStencilDepthPassAction(depthStencilStateType state)
	{
		return (stencilOpActionType)(state & (depthStencilStateType)7L);
	}

	protected virtual void SetStateInternal(rasterizerStateType state)
	{
	}

	public void SetupPolygonOffset(bool enable)
	{
		rasterizerStateType state = rasterizerStateType.CCW_PolygonFill_NoCullFace_PolygonOffset_1_1;
		if (enable)
		{
			if ((CurrentRasterizerState & (rasterizerStateType)7) == 0)
			{
				state = CurrentRasterizerState | rasterizerStateType.CCW_PolygonFill_NoCullFace_NoPolygonOffset | rasterizerStateType.CCW_PolygonLine_NoCullFace_PolygonOffset_1_1;
			}
		}
		else
		{
			state = CurrentRasterizerState & (rasterizerStateType)(-8);
		}
		SetState(state);
	}

	public virtual void SetupPolygonOffsetForShadow(bool lightPass, bool withWires)
	{
	}

	public depthStencilStateType SetState(depthStencilStateType state, bool force = false)
	{
		if (_0023_003DzevpTLAjaYrgv)
		{
			return CurrentDepthStencilState;
		}
		depthStencilStateType currentDepthStencilState = CurrentDepthStencilState;
		if (state != CurrentDepthStencilState || force)
		{
			_0023_003DznCr9zn7WFmWWYlspXQ_003D_003D(state);
			SetStateInternal(state);
		}
		return currentDepthStencilState;
	}

	protected virtual void SetStateInternal(depthStencilStateType state)
	{
	}

	public blendStateType SetState(blendStateType state, bool force = false)
	{
		if (_0023_003Dzmfb0KEd0lJJt)
		{
			return CurrentBlendState;
		}
		blendStateType currentBlendState = CurrentBlendState;
		bool _0023_003DzKJ4ybWw_003D;
		bool _0023_003DzdSLxNqxc0Fji;
		bool _0023_003DzQrc8aAaobpi;
		bool _0023_003DzbvIFYko_003D;
		blendStateType blendStateType2 = _0023_003DzjgXxb7Z_0024IFvt(state, out _0023_003DzKJ4ybWw_003D, out _0023_003DzdSLxNqxc0Fji, out _0023_003DzQrc8aAaobpi, out _0023_003DzbvIFYko_003D);
		if (blendStateType2 != CurrentBlendState || force)
		{
			_0023_003DzyLAdMMDDytzq(blendStateType2);
			SetStateInternal(blendStateType2, _0023_003DzKJ4ybWw_003D, _0023_003DzdSLxNqxc0Fji, _0023_003DzQrc8aAaobpi, _0023_003DzbvIFYko_003D);
		}
		return currentBlendState;
	}

	private blendStateType _0023_003DzjgXxb7Z_0024IFvt(blendStateType _0023_003Dzv0svZZSvM84_0024, out bool _0023_003DzKJ4ybWw_003D, out bool _0023_003DzdSLxNqxc0Fji, out bool _0023_003DzQrc8aAaobpi7, out bool _0023_003DzbvIFYko_003D)
	{
		_0023_003DzStiI2K5oxoFd(_0023_003Dzv0svZZSvM84_0024, out _0023_003DzKJ4ybWw_003D, out _0023_003DzdSLxNqxc0Fji, out _0023_003DzQrc8aAaobpi7, out _0023_003DzbvIFYko_003D);
		if (_0023_003DzKJ4ybWw_003D & _0023_003DzdSLxNqxc0Fji & _0023_003DzQrc8aAaobpi7 & _0023_003DzbvIFYko_003D)
		{
			_0023_003Dzv0svZZSvM84_0024 = _0023_003DzjgXxb7Z_0024IFvt(_0023_003Dzv0svZZSvM84_0024, CurrentColorMask);
			_0023_003DzStiI2K5oxoFd(_0023_003Dzv0svZZSvM84_0024, out _0023_003DzKJ4ybWw_003D, out _0023_003DzdSLxNqxc0Fji, out _0023_003DzQrc8aAaobpi7, out _0023_003DzbvIFYko_003D);
		}
		return _0023_003Dzv0svZZSvM84_0024;
	}

	private static void _0023_003DzStiI2K5oxoFd(blendStateType _0023_003Dzv0svZZSvM84_0024, out bool _0023_003DzKJ4ybWw_003D, out bool _0023_003DzdSLxNqxc0Fji, out bool _0023_003DzQrc8aAaobpi7, out bool _0023_003DzbvIFYko_003D)
	{
		_0023_003DzKJ4ybWw_003D = (_0023_003Dzv0svZZSvM84_0024 & (blendStateType)1) != 0;
		_0023_003DzdSLxNqxc0Fji = (_0023_003Dzv0svZZSvM84_0024 & (blendStateType)2) != 0;
		_0023_003DzQrc8aAaobpi7 = (_0023_003Dzv0svZZSvM84_0024 & (blendStateType)4) != 0;
		_0023_003DzbvIFYko_003D = (_0023_003Dzv0svZZSvM84_0024 & blendStateType.NoBlend_Mask_A) != 0;
	}

	protected virtual void SetStateInternal(blendStateType state, bool red, bool green, bool blue, bool alpha)
	{
	}

	public abstract void DrawQuadsOutlines(Point3D[] vertices);

	public virtual void DrawQuad(RectangleF rect)
	{
		DrawQuad(rect, 0f);
	}

	public abstract void DrawQuad(RectangleF rect, float zCoord);

	public void DrawQuadWithColorRange(RectangleF rect, Color color1, Color color2, bool reflection, float reflectionIntensity)
	{
		if (reflection)
		{
			color1 = Color.FromArgb((byte)Math.Max((float)(int)color1.A - reflectionIntensity * 255f, 0f), color1);
			color2 = Color.FromArgb((byte)Math.Max((float)(int)color2.A - reflectionIntensity * 255f, 0f), color2);
		}
		DrawQuadWithColorRange(rect, color1, color2);
	}

	protected abstract void DrawQuadWithColorRange(RectangleF rect, Color color1, Color color2);

	public void DrawQuad(TextureBase texture, byte alpha, RectangleF rect, float zCoord, bool flipY)
	{
		float[] texCoords = ((!flipY) ? new float[8] { 0f, 1f, 1f, 1f, 1f, 0f, 0f, 0f } : new float[8] { 0f, 0f, 1f, 0f, 1f, 1f, 0f, 1f });
		DrawQuadWithTextures(texture, texCoords, alpha, rect, zCoord, buffered: false);
	}

	public abstract void DrawQuadWithTextures(TextureBase texture, float[] texCoords, byte alpha, RectangleF rect, float zCoord, bool buffered);

	protected internal abstract void DrawQuadWithTextures(TextureBase[] textures, float[] texCoords, byte alpha, RectangleF rect, float zCoord, bool buffered);

	public void SetShaders(Dictionary<shaderType, IShaderTechnique> shaders, bool planarReflections, ShaderParameters shaderParams = null)
	{
		_0023_003DzGRQUNwCv2RFRcWqPTOlYUcmpab6MR5J5mQ_003D_003D = planarReflections;
		if (CurrentShaderTechnique != null)
		{
			CurrentShaderTechnique.Disable(this);
		}
		Shaders = shaders;
		_0023_003DzBQ8RqgdR_0024EGqFkGU9w_003D_003D.Clear();
		if (shaders != null && CurrentShader != shaderType.None && !shaders.ContainsKey(CurrentShader))
		{
			CurrentShader = shaderType.Standard;
		}
		SetShader(CurrentShader, shaderParams, force: true);
	}

	public virtual bool SetShader(shaderType type, ShaderParameters shaderParams = null, bool force = false)
	{
		if (Shaders == null || type == shaderType.None || _0023_003Dz4SjcBbKskKht)
		{
			return false;
		}
		ResolveShaderType(ref type);
		if (!force && CurrentShader == type)
		{
			return true;
		}
		if (!Shaders.ContainsKey(type))
		{
			return false;
		}
		IShaderTechnique shaderTechnique = Shaders[type];
		if (!shaderTechnique.IsCompiled)
		{
			if (!shaderTechnique.Compile(this))
			{
				shaderTechnique.Dispose();
				ControlData.ShadersHqrMainSwitch = false;
				return false;
			}
			if (shaderParams != null)
			{
				shaderTechnique.SetParameters(shaderParams);
			}
		}
		if (CurrentShader != shaderType.None)
		{
			CurrentShaderTechnique.Shader.Disable(this);
		}
		CurrentShader = type;
		return EnableShader(CurrentShader, Shaders);
	}

	protected virtual void ResolveShaderType(ref shaderType type)
	{
	}

	public abstract void ClearColor(Color color);

	public abstract TextureBase CreateTexture2D();

	public virtual TextureBase CreateTexture2DNoMultisample(Size size, bool depthTexture)
	{
		throw new NotImplementedException();
	}

	public abstract TextureBase CreateTexture2D(Color[] colors);

	public abstract TextureBase CreateTexture2D(byte[] image, textureFilteringFunctionType minFunc = textureFilteringFunctionType.Linear, textureFilteringFunctionType magFunc = textureFilteringFunctionType.Linear, bool anisotropicFiltering = true, bool enlargeIfSizeNotSupported = false, bool repeatX = true, bool repeatY = true);

	public abstract TextureBase CreateTexture2D(IDisposable image, textureFilteringFunctionType minFunc = textureFilteringFunctionType.Linear, textureFilteringFunctionType magFunc = textureFilteringFunctionType.Linear, bool anisotropicFiltering = true, bool enlargeIfSizeNotSupported = false, bool repeatX = true, bool repeatY = true);

	public abstract TextureBase CreateTexture2D(Size size, bool depthTexture, textureFilteringFunctionType minFilterFunc = textureFilteringFunctionType.Nearest, textureFilteringFunctionType magFilterFunc = textureFilteringFunctionType.Nearest);

	public abstract TextureBase CreateTexture1D(Color[] colorTable, textureFilteringFunctionType minFunc = textureFilteringFunctionType.Linear, textureFilteringFunctionType magFunc = textureFilteringFunctionType.Linear, bool anisotropicFiltering = true, bool repeatX = true);

	public abstract int MaxTextureSize();

	public abstract void ReadSurface(Size controlSize, bool backBuffer, bool antialiasing);

	public abstract byte[] ReadDepthBuffer(Rectangle rect, out int stride, out int bpp);

	public abstract byte[] ReadColorBuffer(IViewport viewport, Rectangle rect, out int stride, out int bpp);

	public virtual void ReadBuffer(int buffer)
	{
	}

	public void PushShader()
	{
		if (!_0023_003Dz4SjcBbKskKht)
		{
			_0023_003DzBQ8RqgdR_0024EGqFkGU9w_003D_003D.Push(CurrentShader);
		}
	}

	public void PopShader()
	{
		if (_0023_003DzBQ8RqgdR_0024EGqFkGU9w_003D_003D.Count != 0 && !_0023_003Dz4SjcBbKskKht)
		{
			shaderType type = _0023_003DzBQ8RqgdR_0024EGqFkGU9w_003D_003D.Pop();
			SetShader(type);
		}
	}

	public virtual void PushMatrices()
	{
		PushProjection();
		PushModelView();
	}

	public virtual void PopMatrices()
	{
		_0023_003DzDK74Fnq1aK3c(_0023_003DzOnQC6_0024o_003D: false);
		_0023_003DzcMsCMY5voS_c(_0023_003DzOnQC6_0024o_003D: false);
		_0023_003DzZ8w5HMufAGWhGIWSF97Y2OU8AyZ5h4hJfw_003D_003D();
	}

	private void _0023_003DzcMsCMY5voS_c(bool _0023_003DzOnQC6_0024o_003D)
	{
		modelMatrices.Pop();
		viewMatrices.Pop();
		if (_0023_003DzOnQC6_0024o_003D)
		{
			_0023_003DzZ8w5HMufAGWhGIWSF97Y2OU8AyZ5h4hJfw_003D_003D();
		}
	}

	private void _0023_003DzDK74Fnq1aK3c(bool _0023_003DzOnQC6_0024o_003D)
	{
		projMatrices.Pop();
		if (_0023_003DzOnQC6_0024o_003D)
		{
			_0023_003DzZ8w5HMufAGWhGIWSF97Y2OU8AyZ5h4hJfw_003D_003D();
		}
	}

	private void _0023_003DzZ8w5HMufAGWhGIWSF97Y2OU8AyZ5h4hJfw_003D_003D()
	{
		if (projMatrices.Count > 0 && modelMatrices.Count > 0)
		{
			if (CompilingEntity == null)
			{
				SetMatrices(projMatrices.Peek(), viewMatrices.Peek(), modelMatrices.Peek());
			}
			else
			{
				_0023_003DzXEokG1evGui0TWhjEZmPFaIzDKMt = true;
			}
		}
	}

	protected void SetMatrices()
	{
		SetMatrices(projMatrices.Peek(), viewMatrices.Peek(), modelMatrices.Peek());
	}

	protected virtual void SetMatrices(double[] d3dProj, double[] d3dView, double[] d3dModel)
	{
		UpdateMatrix(projMatrices, d3dProj);
		UpdateMatrix(viewMatrices, d3dView);
		UpdateMatrix(modelMatrices, d3dModel);
	}

	protected static void UpdateMatrix(Stack<double[]> stack, double[] newMat)
	{
		if (stack.Count > 0)
		{
			stack.Pop();
		}
		stack.Push(newMat);
	}

	public virtual void PushModelView()
	{
		if (modelMatrices.Count > 0)
		{
			modelMatrices.Push(modelMatrices.Peek());
		}
		if (viewMatrices.Count > 0)
		{
			viewMatrices.Push(viewMatrices.Peek());
		}
	}

	public virtual void PushProjection()
	{
		if (projMatrices.Count > 0)
		{
			projMatrices.Push(projMatrices.Peek());
		}
	}

	public virtual void PopModelView()
	{
		_0023_003DzcMsCMY5voS_c(_0023_003DzOnQC6_0024o_003D: true);
	}

	public virtual void PopProjection()
	{
		_0023_003DzDK74Fnq1aK3c(_0023_003DzOnQC6_0024o_003D: true);
	}

	internal void InitDepthForPostProcessing(Size _0023_003Dz14lzA48_003D)
	{
		if (!DepthForPostProcessingAvailable(_0023_003Dz14lzA48_003D))
		{
			InitDepthForPostProcessingInternal(_0023_003Dz14lzA48_003D);
		}
	}

	protected internal virtual bool DepthForPostProcessingAvailable(Size size)
	{
		if (DepthTextureForPostProcessing != null && DepthTextureForPostProcessing.Size == size && MaskTextureForPostProcessing != null)
		{
			return MaskTextureForPostProcessing.Size == size;
		}
		return false;
	}

	protected virtual bool DepthForPostProcessingAvailable()
	{
		if (DepthTextureForPostProcessing != null)
		{
			return MaskTextureForPostProcessing != null;
		}
		return false;
	}

	protected abstract void InitDepthForPostProcessingInternal(Size size);

	protected virtual void DisposeDepthForPostProcessing()
	{
		DepthTextureForPostProcessing?.Dispose();
		DepthTextureForPostProcessing = null;
		MaskTextureForPostProcessing?.Dispose();
		MaskTextureForPostProcessing = null;
	}

	private void _0023_003DzLgDQR0BRx5zm69H00A_003D_003D(Size _0023_003DzsSJGgWE_003D)
	{
		DisposeDepthForPostProcessing();
		InitDepthForPostProcessing(_0023_003DzsSJGgWE_003D);
	}

	protected internal virtual void SetDepthForPostProcessingAsCurrentTarget()
	{
		if (!DepthForPostProcessingAvailable())
		{
			throw new GraphicsException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302663610));
		}
	}

	public virtual void InitTexturesForCapture()
	{
		InitTexturesForCaptureInternal(9);
	}

	public virtual bool InitProgDrawCompositing()
	{
		ProgDrawCompositingBase?.Dispose();
		return true;
	}

	private protected abstract AOCompositingBase GetAoCompositingObj(bool _0023_003Dzn9cl6igd8gN8);

	private protected abstract SilhoCompositingBase GetSilhoCompositingObj();

	private protected abstract SmoothUICompositingBase GetSmoothUICompositingObj();

	private protected abstract HaloSelectionCompositingBase GetDynamicSelectionCompositingObj();

	private bool _0023_003Dz5NJa_0024V9wQdku3lEDOoJZgo8_003D(CompositingBase _0023_003DzN8rp8wKKC48V, Size _0023_003Dz14lzA48_003D)
	{
		bool num = _0023_003DzN8rp8wKKC48V.Init(this, _0023_003Dz14lzA48_003D);
		if (!num)
		{
			_0023_003DzN8rp8wKKC48V.Dispose();
		}
		return num;
	}

	internal bool InitSmoothUICompositing()
	{
		smoothUICompositing?.Dispose();
		smoothUICompositing = GetSmoothUICompositingObj();
		bool num = _0023_003Dz5NJa_0024V9wQdku3lEDOoJZgo8_003D(smoothUICompositing, ControlData.ControlSize);
		if (!num)
		{
			smoothUICompositing = null;
		}
		return num;
	}

	internal bool InitDynamicSelectionCompositing()
	{
		dynamicSelectionCompositing?.Dispose();
		dynamicSelectionCompositing = GetDynamicSelectionCompositingObj();
		bool num = _0023_003Dz5NJa_0024V9wQdku3lEDOoJZgo8_003D(dynamicSelectionCompositing, ControlData.ControlSize);
		if (!num)
		{
			dynamicSelectionCompositing = null;
		}
		return num;
	}

	internal bool InitStaticSelectionCompositing()
	{
		staticSelectionCompositing?.Dispose();
		staticSelectionCompositing = GetDynamicSelectionCompositingObj();
		bool num = _0023_003Dz5NJa_0024V9wQdku3lEDOoJZgo8_003D(staticSelectionCompositing, ControlData.ControlSize);
		if (!num)
		{
			staticSelectionCompositing = null;
		}
		return num;
	}

	protected abstract bool CreateHilbertLut();

	internal bool InitAoCompositing(bool _0023_003Dzn9cl6igd8gN8)
	{
		bool flag = true;
		aoCompositing?.Dispose();
		aoCompositing = GetAoCompositingObj(_0023_003Dzn9cl6igd8gN8);
		flag &= _0023_003Dz5NJa_0024V9wQdku3lEDOoJZgo8_003D(aoCompositing, ControlData.ControlSize);
		if (flag && aoNoiseTexture == null)
		{
			flag &= CreateHilbertLut();
		}
		if (!flag)
		{
			aoCompositing?.Dispose();
			aoNoiseTexture?.Dispose();
			aoCompositing = null;
			aoNoiseTexture = null;
		}
		return flag;
	}

	internal bool InitSilhoCompositing()
	{
		silhoCompositing?.Dispose();
		silhoCompositing = GetSilhoCompositingObj();
		bool num = _0023_003Dz5NJa_0024V9wQdku3lEDOoJZgo8_003D(silhoCompositing, ControlData.ControlSize);
		if (!num)
		{
			silhoCompositing = null;
		}
		return num;
	}

	protected void InitTexturesForCaptureInternal(int nTextures)
	{
		if (texturesForCapture == null)
		{
			texturesForCapture = new TextureBase[nTextures];
			for (int i = 0; i < texturesForCapture.Length; i++)
			{
				texturesForCapture[i] = CreateTexture2D();
			}
		}
		for (int j = 0; j < texturesForCapture.Length; j++)
		{
			texturesForCapture[j].AllocateMemory(this, renderTarget: true, texSize.Width, texSize.Height, textureFilteringFunctionType.Nearest, textureFilteringFunctionType.Nearest, repeatS: false, repeatT: false, IntPtr.Zero, multisample: false);
		}
	}

	public abstract void PaintBackBuffer(int controlHeight);

	public abstract void DrawBorder(Dictionary<shaderType, IShaderTechnique> shaders, Color borderColor, Size size, int radius, bool visible, object borderBitmap, object lowerLeftCorner, object lowerRightCorner, object topLeftCorner, object topRightCorner);

	protected virtual void MultMatrix(double[] transform, matrixType matrixType)
	{
		GetMatrices(transform, matrixType, out var projMat, out var viewMat, out var modelMat);
		SetMatrices(projMat, viewMat, modelMat);
	}

	protected void GetMatrices(double[] transform, matrixType matType, out double[] projMat, out double[] viewMat, out double[] modelMat)
	{
		projMat = projMatrices.Peek();
		viewMat = viewMatrices.Peek();
		modelMat = modelMatrices.Peek();
		switch (matType)
		{
		case matrixType.Projection:
			projMat = Utility.MultMatrixd(transform, projMat);
			break;
		case matrixType.ModelView:
			modelMat = Utility.MultMatrixd(transform, modelMat);
			break;
		}
	}

	public virtual void MultMatrixProj(Transformation transform)
	{
		MultMatrixProj(transform.MatrixAsVectorByColumn);
	}

	public virtual void MultMatrixProj(double[] transform)
	{
		MultMatrix(transform, matrixType.Projection);
	}

	public virtual void MultMatrixModelView(Transformation transform)
	{
		MultMatrixModelView(transform.MatrixAsVectorByColumn);
	}

	public virtual void MultMatrixModelView(double[] transform)
	{
		MultMatrix(transform, matrixType.ModelView);
	}

	public virtual void ScaleMatrixProj(double s1, double s2, double s3)
	{
		MultMatrix(new double[16]
		{
			s1, 0.0, 0.0, 0.0, 0.0, s2, 0.0, 0.0, 0.0, 0.0,
			s3, 0.0, 0.0, 0.0, 0.0, 1.0
		}, matrixType.Projection);
	}

	public virtual void ScaleMatrixModelView(double s1, double s2, double s3)
	{
		MultMatrix(new double[16]
		{
			s1, 0.0, 0.0, 0.0, 0.0, s2, 0.0, 0.0, 0.0, 0.0,
			s3, 0.0, 0.0, 0.0, 0.0, 1.0
		}, matrixType.ModelView);
	}

	public void CloseTexture(TextureBase texture, bool force = false)
	{
		CloseTexture(texture.TextureUnitMode, force);
	}

	public virtual void CloseTexture(TextureBase.textureUnitType textureUnit, bool force = false)
	{
		if (force || _0023_003DzzW3dSjRL0oLt[(int)textureUnit])
		{
			CloseTextureInternal(textureUnit, force);
			_0023_003DzzW3dSjRL0oLt[(int)textureUnit] = false;
			_0023_003DzoIFulAZFykiV.Texture = null;
			_0023_003DzoIFulAZFykiV.AlphaMap = null;
		}
	}

	public void CloseTexture(bool force = false)
	{
		CloseTexture(TextureBase.textureUnitType.Base, force);
	}

	protected internal virtual void CloseTextureInternal(TextureBase.textureUnitType textureUnit, bool force = false)
	{
	}

	[Conditional("DEBUG")]
	public void CheckTexture(TextureBase texture)
	{
	}

	public bool SetTexture(TextureBase texture)
	{
		return SetTexture(texture, TextureBase.textureUnitType.Base);
	}

	public virtual bool SetTexture(TextureBase texture, TextureBase.textureUnitType textureUnit)
	{
		if (texture == null)
		{
			CloseTexture(textureUnit);
			return false;
		}
		bool result = true;
		if (CurrentMaterial.Texture != texture || textureUnit != TextureBase.textureUnitType.Base)
		{
			result = texture.SetTextureInternal(this, textureUnit);
			if (textureUnit == TextureBase.textureUnitType.Base)
			{
				CurrentMaterial.Texture = texture;
			}
		}
		return result;
	}

	public virtual bool SetAlphaTexture(TextureBase texture)
	{
		if (texture == null)
		{
			CurrentMaterial.AlphaMap = null;
			return false;
		}
		bool result = true;
		if (CurrentMaterial.AlphaMap != texture)
		{
			result = texture.SetTextureInternal(this, TextureBase.textureUnitType.AlphaTexture);
			CurrentMaterial.AlphaMap = texture;
		}
		return result;
	}

	public shaderType GetShaderAndEnable(ShaderParameters shaderParams)
	{
		if (Shaders == null)
		{
			return shaderType.None;
		}
		bool flag = shaderParams.Environment != null;
		bool texture2D = shaderParams.Texture2D;
		bool multicolor = shaderParams.Multicolor;
		bool texture1D = shaderParams.Texture1D;
		bool lighting = shaderParams.Lighting;
		shaderType shaderType2;
		if (shaderParams.ColorsModulatedByIntensity)
		{
			shaderType2 = shaderType.SingleColorModulatedByIntensity;
		}
		else if (!lighting)
		{
			if (texture2D)
			{
				shaderType2 = shaderType.Texture2DNoLights;
			}
			else if (texture1D)
			{
				shaderType2 = shaderType.Texture1DNoLights;
			}
			else if (!multicolor)
			{
				shaderType2 = ((!shaderParams.MulticolorNoLightsWithNormals) ? shaderType.NoLights : shaderType.MultiColorNoLightsWithNormals);
			}
			else
			{
				shaderType2 = shaderType.MultiColorNoLights;
				if (shaderParams.WithNormals)
				{
					shaderType2 = shaderType.MultiColorNoLightsWithNormals;
				}
			}
		}
		else
		{
			shaderType2 = (texture1D ? ((!flag) ? shaderType.Texture1D : shaderType.EnvironmentTexture1D) : ((!flag && !texture2D) ? ((!multicolor) ? shaderType.Standard : ((!shaderParams.Selected) ? shaderType.MultiColor : shaderType.MultiColorSelected)) : ((!flag) ? shaderType.Texture2D : (texture2D ? shaderType.EnvironmentTexture2D : ((!multicolor) ? shaderType.Environment : shaderType.EnvironmentMulticolor)))));
			if (shaderParams.ShadowMode == shadowType.Realistic && shaderParams.LightWithShadow >= 0)
			{
				shaderType2 = _0023_003DzF9EDK3xuQzop(shaderType2);
			}
			if (shaderParams.AlphaMap && texture2D)
			{
				shaderType2 = ResolveAlphaMapShader(shaderType2);
			}
		}
		shaderType currentShader = CurrentShader;
		bool flag2 = true;
		switch (shaderParams.PrimitiveType)
		{
		case shaderPrimitiveType.Line:
			flag2 = SetLinesShader(CurrentLineWidth > 1f, shaderType2);
			break;
		case shaderPrimitiveType.Point:
			flag2 = SetPointsShader(CurrentPointSize > 1f, shaderType2);
			break;
		case shaderPrimitiveType.Polygon:
			if (prevPolygonOffset != 0)
			{
				RestorePolygonOffset(ref prevPolygonOffset);
			}
			flag2 = SetShader(shaderType2, shaderParams);
			break;
		}
		if (shaderParams.ForceSetTransform || (flag2 && currentShader != CurrentShader))
		{
			SetBlockRefTransform(shaderParams.BlockRefTansformMatrix);
		}
		if (flag && lighting)
		{
			CurrentShaderTechnique.SetEnvironmentIntensity(shaderParams._0023_003DzHra2fjngell6mfGg8_0024i3OQU_003D());
		}
		if ((texture2D || texture1D) && lighting)
		{
			SetTextureOverExposure(shaderParams.TextureOverExposure);
		}
		return shaderType2;
	}

	public abstract void SetTextureOverExposure(bool textureOverExposure);

	public abstract void SetTextureLength(float textureLength);

	public abstract void SetTextureGrayscale(bool grayscale, float grayscaleAlpha);

	public abstract void SetClippable(bool clippable);

	private static shaderType _0023_003DzF9EDK3xuQzop(shaderType _0023_003Dzi9GXHpY_003D)
	{
		_0023_003Dzi9GXHpY_003D = _0023_003Dzi9GXHpY_003D switch
		{
			shaderType.Standard => shaderType.StandardShadow, 
			shaderType.Environment => shaderType.EnvironmentShadow, 
			shaderType.EnvironmentTexture2D => shaderType.EnvironmentTexture2DShadow, 
			shaderType.Texture2D => shaderType.Texture2DShadow, 
			shaderType.MultiColor => shaderType.MultiColorShadow, 
			shaderType.MultiColorSelected => shaderType.StandardShadow, 
			shaderType.EnvironmentMulticolor => shaderType.EnvironmentMulticolorShadow, 
			shaderType.Texture1D => shaderType.Texture1DShadow, 
			shaderType.EnvironmentTexture1D => shaderType.EnvironmentTexture1DShadow, 
			_ => throw new GraphicsException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302663563)), 
		};
		return _0023_003Dzi9GXHpY_003D;
	}

	public shaderType ResolveAlphaMapShader(shaderType shaderType)
	{
		if (_0023_003Dz4SjcBbKskKht)
		{
			return shaderType;
		}
		shaderType = shaderType switch
		{
			shaderType.EnvironmentTexture2D => shaderType.EnvironmentTexture2DWithAlphaMap, 
			shaderType.EnvironmentTexture2DShadow => shaderType.EnvironmentTexture2DShadowWithAlphaMap, 
			shaderType.Texture2D => shaderType.Texture2DWithAlphaMap, 
			shaderType.Texture2DDecal => shaderType.Texture2DDecalWithAlphaMap, 
			shaderType.Texture2DNoLights => shaderType.Texture2DNoLightsWithAlphaMap, 
			shaderType.Texture2DNoLightsDecal => shaderType.Texture2DNoLightsDecalWithAlphaMap, 
			shaderType.Texture2DNoLightsModulate => shaderType.Texture2DNoLightsModulateWithAlphaMap, 
			shaderType.Texture2DShadow => shaderType.Texture2DShadowWithAlphaMap, 
			_ => throw new GraphicsException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302663250)), 
		};
		return shaderType;
	}

	protected internal virtual bool SetLinesShader(bool thick, shaderType shader, ShaderParameters shaderParams = null)
	{
		return SetShader(shader, shaderParams);
	}

	protected virtual bool SetPointsShader(bool thick, shaderType shader, ShaderParameters shaderParams = null)
	{
		return SetShader(shader, shaderParams);
	}

	protected void RestorePolygonOffset(ref int prev)
	{
		if (prev != 0)
		{
			rasterizerStateType state = (rasterizerStateType)((int)(CurrentRasterizerState & (rasterizerStateType)(-8)) | prev);
			SetState(state);
			prev = 0;
		}
	}

	protected void RemovePolygonOffset(ref int prev)
	{
		if ((CurrentRasterizerState & (rasterizerStateType)7) != rasterizerStateType.CCW_PolygonLine_NoCullFace)
		{
			prev = (int)(CurrentRasterizerState & (rasterizerStateType)7);
			SetState(CurrentRasterizerState & (rasterizerStateType)(-8));
		}
	}

	protected void SetPolygonDrawingMode(rasterizerPolygonDrawingType polygonDrawingMode)
	{
		rasterizerStateType state = (rasterizerStateType)((int)(CurrentRasterizerState & (rasterizerStateType)(-33)) | ((int)polygonDrawingMode << 5));
		SetState(state);
	}

	public abstract Dictionary<shaderType, IShaderTechnique> CreateShaders(realisticShadowQualityType shadowQuality, LightSettings[] lights);

	public abstract Dictionary<shaderType, IShaderTechnique> CreateReflectionShaders(realisticShadowQualityType shadowQuality, orientationType orientationMode, IBackgroundSettings background, LightSettings[] lights);

	protected abstract void SetRGB(byte r, byte g, byte b);

	protected abstract void SetRGBA(byte r, byte g, byte b, byte a);

	protected abstract void SetRGBA(float[] rgba);

	public void GetRGBForSelection(int currentEntityId, out byte r, out byte g, out byte b)
	{
		if (ColorsBits16)
		{
			r = _0023_003DzasRVx88EAYoctNi_0024lw_003D_003D(currentEntityId % BlueMaxVal);
			g = _0023_003DzNO021_0024vKrg7poyaopw_003D_003D((currentEntityId >> GreenShift) % GreenMaxVal);
			b = _0023_003DzasRVx88EAYoctNi_0024lw_003D_003D((currentEntityId >> RedShift) % RedMaxVal);
		}
		else
		{
			r = (byte)(currentEntityId % 256);
			g = (byte)((currentEntityId >> 8) % 256);
			b = (byte)((currentEntityId >> 16) % 256);
		}
	}

	public void SetMaterialFrontDiffuse(Color color, bool force = false)
	{
		if (force || ColorChanged(color, CurrentMaterial.Diffuse))
		{
			CurrentMaterial.Diffuse = color;
			SetMaterialFrontDiffuse(Utility.ColorToFloatArray(color));
		}
	}

	protected abstract void SetMaterialFrontDiffuse(float[] color);

	protected abstract void SetMaterialBackDiffuse(float[] color);

	protected abstract void SetMaterialFrontAmbient(float[] color);

	protected abstract void SetMaterialBackAmbient(float[] color);

	public void SetMaterialFrontAndBackDiffuse(Color color, bool force = false)
	{
		if (force || ColorChanged(color, CurrentMaterial.Diffuse) || ColorChanged(color, CurrentBackMaterial.Diffuse))
		{
			CurrentMaterial.Diffuse = color;
			CurrentBackMaterial.Diffuse = color;
			float[] array = Utility.ColorToFloatArray(color);
			SetMaterialFrontDiffuse(array);
			SetMaterialBackDiffuse(array);
		}
	}

	public abstract void BeginReadDepthValues(Size size, out int strideInPixels);

	public virtual void EndReadDepthValues()
	{
	}

	public short[] ReadDepthValues(System.Drawing.Point centerCameraScreen, Size size)
	{
		return ReadDepthValues(centerCameraScreen.X - size.Width / 2, centerCameraScreen.Y - size.Height / 2, size);
	}

	public virtual short[] ReadDepthValues(int[] layoutViewport, out int stride)
	{
		BeginReadDepthValues(new Size(layoutViewport[2], layoutViewport[3]), out stride);
		short[] result = ReadDepthValuesInternal(layoutViewport);
		EndReadDepthValues();
		return result;
	}

	protected abstract short[] ReadDepthValuesInternal(int[] layoutViewport);

	public abstract short[] ReadDepthValues(int left, int bottom, Size size);

	public void Compile(EntityGraphicsData data, DrawEntityCallBack drawEntityCallBack, object myParams)
	{
		FreeEntityGraphicsData(data);
		CompilingEntity = data;
		CompileInternal(drawEntityCallBack, myParams);
		CompilingEntity = null;
		if (_0023_003DzXEokG1evGui0TWhjEZmPFaIzDKMt)
		{
			SetMatrices();
			_0023_003DzXEokG1evGui0TWhjEZmPFaIzDKMt = false;
		}
	}

	protected abstract void CompileInternal(DrawEntityCallBack drawEntityCallBack, object myParams);

	public virtual void CompileVBO(EntityGraphicsData data, DrawEntityCallBack drawEntityCallBack, object vboParams, bool dynamic = false)
	{
		Compile(data, drawEntityCallBack, vboParams);
	}

	public virtual void UpdateVBO(EntityGraphicsData data, DrawEntityCallBack drawEntityCallBack, object vboParams)
	{
		Compile(data, drawEntityCallBack, vboParams);
	}

	public abstract void ClearDepthStencil(bool depthBuffer, bool stencilBuffer, byte stencilClearValue = 0);

	public void PrepareStencilForDrawing()
	{
		ClearDepthStencil(depthBuffer: false, stencilBuffer: true, 0);
		SetState(depthStencilStateType.DepthTestLess_StencilOn_Func_Always_1_1_Op_Replace_Replace_Replace);
		SetState(blendStateType.ColorMaskOff);
	}

	public void EnableStencilCompare()
	{
		SetState(depthStencilStateType.DepthTestOff_StencilOn_Func_Equal_1_1_Op_Keep_Keep_Keep);
		SetState(blendStateType.NoBlend);
	}

	public abstract void DrawLine(float[] linePoints);

	public abstract void DrawLine(float x0, float y0, float z0, float x1, float y1, float z1);

	public abstract void DrawLine(Point2D p0, Point2D p1);

	public abstract void DrawLine(Point3D p0, Point3D p1);

	public abstract void DrawLine(PointRGB p0, PointRGB p1);

	public abstract void DrawLine(Point3D p0, Point3D p1, Point2D texCoords);

	public virtual void DrawBufferedLine(Point3D v0, Point3D v1)
	{
		DrawLine(v0, v1);
	}

	public virtual void DrawBufferedPoint(Point3D v0)
	{
		DrawPoints(new Point3D[1] { v0 });
	}

	public void DrawLineStrip(float[] vertices)
	{
		DrawLineStrip(vertices, 0, vertices.Length / 3);
	}

	public void DrawLineStrip(Point2D[] vertices)
	{
		DrawLineStrip(vertices, 0, vertices.Length);
	}

	public void DrawLineStrip(Point3D[] vertices)
	{
		DrawLineStrip(vertices, 0, vertices.Length);
	}

	public void DrawLineStrip(Point3D[] vertices, float[] texCoords)
	{
		DrawLineStrip(vertices, texCoords, 0, vertices.Length);
	}

	public void DrawLineStrip(PointRGB[] vertices)
	{
		DrawLineStrip(vertices, 0, vertices.Length);
	}

	public abstract void DrawLineStrip(float[] vertices, int first, int count);

	public abstract void DrawLineStripRGBA(float[] vertices, int first, int count);

	public abstract void DrawLineStrip(Point2D[] vertices, int first, int count);

	public abstract void DrawLineStrip(Point3D[] vertices, int first, int count);

	public abstract void DrawLineStrip(Point3D[] vertices, float[] texCoords, int first, int count);

	public abstract void DrawLineStrip(PointRGB[] vertices, int first, int count);

	public virtual void SetLightStatus(int lightIndex, bool active)
	{
	}

	public abstract void SetLightAttributes(int lightIndex, float[] diffuse, float[] ambient, float[] specular, LightSettings light);

	public abstract void SetLightPosition(int lightIndex, lightType lightType, float[] dir, float[] position);

	public virtual void CheckShadersAndLights(Dictionary<shaderType, IShaderTechnique> shaders, realisticShadowQualityType shadowQuality, IBackgroundSettings background)
	{
	}

	public virtual void UpdateConstantBufferPerFrame(ShaderParameters data = null)
	{
		if (CurrentShaderTechnique == null)
		{
			throw new GraphicsException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302663226));
		}
	}

	public virtual void UpdateConstantBufferPerObject()
	{
		if (CurrentShaderTechnique == null)
		{
			throw new GraphicsException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302663413));
		}
	}

	public abstract void DrawSilhouettes(GfxSilhoData silho);

	public abstract void DisableClipPlanes();

	[Conditional("GFX_DEBUG")]
	public virtual void CheckErrorDEBUG(string s)
	{
	}

	public virtual bool IsGraphicsError()
	{
		return false;
	}

	public virtual bool CheckOutOfMemory()
	{
		return false;
	}

	public virtual string GetErrorString(int errorCode)
	{
		return string.Empty;
	}

	public abstract void ResizeSurfacesForCapture(Size size, bool antialiasing);

	public abstract void PaintBackBuffer(Size controlSize, Camera camera, bool antiAliasing);

	public float SetPointSize(float size, bool setShader = true, bool force = false)
	{
		float result = _0023_003Dz7M1xDzbLpt1s;
		if (force || _0023_003Dz7M1xDzbLpt1s != size)
		{
			_0023_003Dz7M1xDzbLpt1s = size;
			SetPointSizeInternal(size);
		}
		if (setShader)
		{
			EnableThickPoints();
		}
		return result;
	}

	protected abstract void SetPointSizeInternal(float thickness);

	public float SetLineSize(float size, bool setShader = true, bool force = false)
	{
		float result = _0023_003Dzz73_0024dseP1PQg;
		if (force || _0023_003Dzz73_0024dseP1PQg != size)
		{
			_0023_003Dzz73_0024dseP1PQg = size;
			SetLineSizeInternal(size);
		}
		if (setShader)
		{
			EnableThickLines();
		}
		return result;
	}

	protected abstract void SetLineSizeInternal(float thickness);

	public bool SetLighting(bool enable)
	{
		bool result = _0023_003DzGAgy_0024Qp7pFXyfiSK5w_003D_003D;
		if (_0023_003DzGAgy_0024Qp7pFXyfiSK5w_003D_003D != enable)
		{
			_0023_003DzGAgy_0024Qp7pFXyfiSK5w_003D_003D = enable;
			SetLightingInternal(enable);
		}
		return result;
	}

	protected virtual void SetLightingInternal(bool enable)
	{
	}

	public void ProcessMaterial()
	{
		SetMaterial(Color.Black, Color.Black, ControlData.DefaultMaterial.Ambient, ControlData.DefaultMaterial.Specular, ControlData.DefaultMaterial.Shininess);
	}

	public virtual void InitializeCurrentWireColor()
	{
		_0023_003DzVGPF9Wec3DPz(Color.Black);
	}

	public virtual void InitializePreviousColors()
	{
		CloseTexture(force: true);
		SetLighting(enable: true);
		CurrentMaterial.Ambient = ControlData.DefaultMaterialShaded.Ambient;
		CurrentMaterial.Diffuse = Color.Black;
		CurrentMaterial.Specular = ControlData.DefaultMaterialShaded.Specular;
		CurrentMaterial.Shininess = ControlData.DefaultMaterialShaded.Shininess;
		CurrentMaterial.Texture = null;
		CurrentMaterial.AlphaMap = null;
		CurrentBackMaterial.Ambient = CurrentMaterial.Ambient;
		CurrentBackMaterial.Diffuse = CurrentMaterial.Diffuse;
	}

	public void InitializePreviousColorsHiddenLines(bool singleColor)
	{
		SetLighting(enable: true);
		CloseTexture(force: true);
		if (singleColor)
		{
			CurrentMaterial.Ambient = Color.White;
		}
		else
		{
			CurrentMaterial.Ambient = ControlData.DefaultMaterialShaded.Ambient;
		}
		CurrentMaterial.Diffuse = Color.White;
		CurrentBackMaterial.Diffuse = Color.White;
		CurrentMaterial.Specular = Color.Black;
		CurrentMaterial.Shininess = 0f;
		SetMaterial(Utility.ColorToFloatArray(CurrentMaterial.Diffuse), Utility.ColorToFloatArray(CurrentBackMaterial.Diffuse), Utility.ColorToFloatArray(CurrentMaterial.Ambient), Utility.ColorToFloatArray(CurrentMaterial.Specular), CurrentMaterial.Shininess * 128f);
		CurrentMaterial.Texture = null;
		CurrentMaterial.AlphaMap = null;
	}

	protected internal static float GetShadowAmbientFactor(LightSettings[] lights)
	{
		float num = 0f;
		for (int i = 0; i < lights.Length; i++)
		{
			num += 0.17f;
		}
		return num;
	}

	public void InitBlurShader()
	{
		if (!Shaders.ContainsKey(shaderType.BlurHor))
		{
			float[] array = new float[19];
			float[] array2 = new float[19];
			for (int i = 0; i < 19; i++)
			{
				float num = i - 9;
				array[i] = num / 256f;
				array2[i] = (float)_0023_003DzI01JyHImqgiFCc3w2w_003D_003D(num, 4.0);
			}
			InitBlurShader(array, array2, out var blurHor, out var blurVert);
			Shaders.Add(shaderType.BlurHor, blurHor);
			Shaders.Add(shaderType.BlurVert, blurVert);
		}
	}

	protected abstract void InitBlurShader(float[] offset, float[] kernelValues, out IShaderTechnique blurHor, out IShaderTechnique blurVert);

	internal double _0023_003DzI01JyHImqgiFCc3w2w_003D_003D(double _0023_003DzBJFJHwk_003D, double _0023_003DzuwH5j5s_003D)
	{
		double num = 1.0 / (Math.Sqrt(Math.PI * 2.0) * _0023_003DzuwH5j5s_003D);
		double y = (0.0 - _0023_003DzBJFJHwk_003D * _0023_003DzBJFJHwk_003D) / (2.0 * _0023_003DzuwH5j5s_003D * _0023_003DzuwH5j5s_003D);
		return num * Math.Pow(Math.E, y);
	}

	internal bool _0023_003DzdJ308q6v_sqSI6Ni5w_003D_003D(out shaderType _0023_003Dz_0024n2IQdnPECRliK9cuQ_003D_003D)
	{
		switch (CurrentShader)
		{
		case shaderType.NoLightsThickLines:
		case shaderType.NoLightsThickPoints:
		case shaderType.NoLightsThickLinesStipple:
			_0023_003Dz_0024n2IQdnPECRliK9cuQ_003D_003D = shaderType.NoLights;
			break;
		case shaderType.Texture1DNoLightsThickLines:
			_0023_003Dz_0024n2IQdnPECRliK9cuQ_003D_003D = shaderType.Texture1DNoLights;
			break;
		case shaderType.SingleColorModulatedByIntensityThickLines:
		case shaderType.SingleColorModulatedByIntensityThickPoints:
			_0023_003Dz_0024n2IQdnPECRliK9cuQ_003D_003D = shaderType.SingleColorModulatedByIntensity;
			break;
		case shaderType.MultiColorNoLightsThickLines:
		case shaderType.MultiColorNoLightsThickPoints:
		case shaderType.MultiColorNoLightsThickLinesPerVertex:
		case shaderType.MultiColorNoLightsThickPointsPerVertex:
			_0023_003Dz_0024n2IQdnPECRliK9cuQ_003D_003D = shaderType.MultiColorNoLights;
			break;
		case shaderType.StandardThickLines:
		case shaderType.StandardThickPoints:
			_0023_003Dz_0024n2IQdnPECRliK9cuQ_003D_003D = shaderType.Standard;
			break;
		default:
			_0023_003Dz_0024n2IQdnPECRliK9cuQ_003D_003D = CurrentShader;
			return false;
		}
		return true;
	}

	public abstract void CompileBackground(IBackgroundSettings iBackgroundSettings, int height);

	public abstract bool IsValid();

	public abstract IEnvironment CompileEnvironment(object image);

	protected internal abstract IEnvironment CreateEnvironment(byte[] image);

	public virtual void BeginDraw()
	{
	}

	public abstract int[] GetEntityIndicesFromBmp(Rectangle selectionBox, bool firstOnly, byte[] rgbValues, int bpp, int stride);

	public abstract byte[] MakePowerOfTwo(byte[] bmpByteArray, out int bmpWidth, out int bmpHeight);

	public abstract byte[] MakeGrayscale(byte[] original);

	public abstract byte[] SetImageOpacity(byte[] image, float opacity);

	public void DrawLines(float[] vertices)
	{
		DrawLines(vertices, 0, vertices.Length / 3);
	}

	public abstract void DrawLines(float[] vertices, int first, int count);

	public void DrawLines(Point3D[] vertices)
	{
		DrawLines(vertices, 0, vertices.Length);
	}

	public abstract void DrawLines(Point3D[] vertices, int first, int count);

	public void DrawPoints(Point3D[] points)
	{
		DrawPoints(points, 0, points.Length);
	}

	public void DrawPointsWithNormalsIndeterminate(float[] points, float[] normals)
	{
		DrawPointsWithNormalsIndeterminate(points, normals, 0, points.Length / 3);
	}

	public void DrawPointsIndeterminate(float[] points)
	{
		DrawPointsIndeterminate(points, 0, points.Length / 3);
	}

	public void DrawPointsIndeterminate(Point3D[] points)
	{
		DrawPointsIndeterminate(points, 0, points.Length);
	}

	public void DrawPoints(float[] points)
	{
		DrawPoints(points, 0, points.Length / 3);
	}

	public abstract void DrawPoints(float[] points, int first, int count);

	public abstract void DrawPoints(Point3D[] points, int first, int count);

	public abstract void DrawPointsIndeterminate(float[] points, int first, int count);

	public abstract void DrawPointsIndeterminate(Point3D[] points, int first, int count);

	public abstract void DrawPointsWithNormalsIndeterminate(float[] points, float[] normals, int first, int count);

	public void DrawPointsRGB(Point3D[] vertices)
	{
		DrawPointsRGB(vertices, 0, vertices.Length);
	}

	public void DrawPointsWithColorsRGBIndeterminate(float[] points, byte[] colors)
	{
		DrawPointsWithColorsRGBIndeterminate(points, colors, 0, points.Length / 3);
	}

	public abstract void DrawPointsWithColorsRGBIndeterminate(float[] points, byte[] colors, int first, int count);

	public void DrawPointsWithColorsRGBAIndeterminate(float[] points, byte[] colors)
	{
		DrawPointsWithColorsRGBAIndeterminate(points, colors, 0, points.Length / 3);
	}

	public abstract void DrawPointsWithColorsRGBAIndeterminate(float[] points, byte[] colors, int first, int count);

	public void DrawPointsWithColorIntensitiesIndeterminate(float[] points, byte[] colors)
	{
		DrawPointsWithColorIntensitiesIndeterminate(points, colors, 0, points.Length / 3);
	}

	public abstract void DrawPointsWithColorIntensitiesIndeterminate(float[] points, byte[] colors, int first, int count);

	public void DrawPointsRGBIndeterminate(Point3D[] vertices)
	{
		DrawPointsRGBIndeterminate(vertices, 0, vertices.Length);
	}

	public abstract void DrawPointsRGB(Point3D[] points, int first, int count);

	public abstract void DrawPointsRGBIndeterminate(Point3D[] points, int first, int count);

	public virtual void DisableShader()
	{
		CurrentShaderTechnique?.Disable(this);
	}

	public abstract void DrawPointsWithNormals(Point3D[] points, Vector3D[] normals, int first, int count);

	public abstract void DrawPointsWithNormalsIndeterminate(Point3D[] points, Vector3D[] normals, int first, int count);

	protected virtual bool EnableShader(shaderType shader, Dictionary<shaderType, IShaderTechnique> shaders)
	{
		CurrentShader = shader;
		return shader != shaderType.None;
	}

	public abstract void Draw(EntityGraphicsData data, primitiveType primitiveType = primitiveType.Undefined, uint? indexOffset = null, uint? indexCount = null);

	public virtual void DrawSelected(EntityGraphicsData data, primitiveType primitiveType = primitiveType.Undefined)
	{
		Draw(data, primitiveType);
	}

	public abstract void DrawNormals(Point3D[] vertices, Vector3D diffVector);

	public abstract void DrawNormals(Point3D[] vertices, IndexTriangle[] triangles, Vector3D[] normals, double length);

	public abstract void DrawSurfaceNormals(Point3D[] vertices, double length);

	public abstract void DrawNormalsPerVertex(Point3D[] vertices, IndexTriangle[] triangles, Vector3D[] normals, double length);

	public abstract void DrawRichPlainQuads(Point3D[] vertices, Vector3D[] normals, PointF[] texCoords);

	public abstract void DrawTriangles(Point3D[] vertices);

	public abstract void DrawTriangles(Point3D[] vertices, Vector3D normal);

	public abstract void DrawTriangles(Point3D[] vertices, Vector3D[] normals, IndexTriangle[] triangles, PointF[] texCoords);

	public abstract void DrawTriangles(Point3D[] vertices, Vector3D[] normals, PointF[] texCoords = null, bool addToCurrentBufferPart = false);

	public virtual void DrawTrianglesPartial(Point3D[] vertices, Vector3D[] normals, PointF[] texCoords = null)
	{
		DrawTriangles(vertices, normals, texCoords, addToCurrentBufferPart: true);
	}

	public virtual void DrawTrianglesPartialWithMaterialColor(Point3D[] vertices, Vector3D[] normals, bool addToCurrentBufferPart = false)
	{
		DrawTrianglesPartial(vertices, normals);
	}

	public virtual void DrawTrianglesPartialWithTexture(Point3D[] vertices, Vector3D[] normals, PointF[] texCoords, bool addToCurrentBufferPart = false)
	{
		DrawTrianglesPartial(vertices, normals, texCoords);
	}

	public abstract void DrawTriangles(Point3D[] vertices, Vector3D[] normals, float[] texCoords, bool addToCurrentBufferPart = false);

	public virtual void DrawTrianglesPartial(Point3D[] vertices, Vector3D[] normals, float[] texCoords)
	{
		DrawTriangles(vertices, normals, texCoords, addToCurrentBufferPart: true);
	}

	public abstract void DrawTriangles(Point3D[] vertices, Vector3D[] normals, Color[] colors, bool addToCurrentBufferPart = false);

	public virtual void DrawTrianglesPartial(Point3D[] vertices, Vector3D[] normals, Color[] colors)
	{
		DrawTriangles(vertices, normals, colors, addToCurrentBufferPart: true);
	}

	public abstract void DrawTrianglesPlanar(Point3D[] vertices, IndexTriangle[] triangles, Vector3D normal);

	public abstract void DrawTrianglesPlanar(Point3D[] vertices, int[] trianglesIndices, Vector3D normal);

	protected static int[] GetIndicesFromTriangles(IndexTriangle[] triangles)
	{
		int[] array = null;
		if (triangles.Length > 1)
		{
			array = new int[triangles.Length * 3];
			int num = 0;
			foreach (IndexTriangle indexTriangle in triangles)
			{
				array[num++] = indexTriangle.V1;
				array[num++] = indexTriangle.V2;
				array[num++] = indexTriangle.V3;
			}
		}
		return array;
	}

	public abstract void DrawTriangles2D(Point2D[] vertices);

	public abstract void DrawTriangles2D(float[] vertices);

	public abstract void DrawTrianglesFan2D(float[] points2D);

	public abstract void DrawTrianglesFan(Point3D[] vertices, Vector3D normal);

	public abstract void DrawQuads2D(float[] vertices);

	public abstract void DrawLines2D(float[] vertices);

	public void DrawLineLoop(Point3D[] vertices)
	{
		DrawLineLoop(vertices, 0, vertices.Length);
	}

	public void DrawLineLoop(Point2D[] vertices)
	{
		DrawLineLoop(vertices, 0, vertices.Length);
	}

	public abstract void DrawLineLoop(Point2D[] vertices, int first, int count);

	public abstract void DrawLineLoop(Point3D[] vertices, int first, int count);

	public abstract void DrawIndexLines(IList<IndexLine> lines, Point3D[] vertices);

	public abstract void DrawIndexLines(IList<IndexLine> lines, float[] vertices);

	public abstract void DrawIndexLinesWithDisplacement(IList<IndexLine> lines, Point3D[] vertices, double ampFactor, int mode, bool addToCurrentBufferPart = false);

	public abstract void DrawLinesWithDisplacement(Point3D[] vertices, double ampFactor, int mode, bool addToCurrentBufferPart = false);

	public virtual void TranslateMatrixModelView(double x, double y, double z)
	{
		MultMatrixModelView(new Translation(x, y, z));
	}

	public virtual void RotateMatrixModelView(double angleInDegrees, double axisX, double axisY, double axisZ)
	{
		MultMatrixModelView(new Rotation(Utility.DegToRad(angleInDegrees), new Vector3D(axisX, axisY, axisZ)));
	}

	[Obsolete("Call EntityGraphicsDataBase.Dispose() instead.")]
	public static void FreeEntityGraphicsData(EntityGraphicsData data)
	{
		data?.Dispose();
	}

	public void DrawQuadStrip(Point3D[] vertices, Vector3D[] normals)
	{
		DrawQuadStrip(vertices, normals, 0, vertices.Length);
	}

	protected void ThrowEntityNotCompiledError(EntityGraphicsData data)
	{
		GraphicsDataWithError = data;
		throw new GraphicsException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302663347));
	}

	public abstract void DrawQuadStrip(Point3D[] vertices, Vector3D[] normals, int first, int count);

	public abstract void DrawIndeterminateAsPoints(EntityGraphicsData data);

	public abstract void DrawIndeterminateAsLineStrip(EntityGraphicsData data);

	public abstract void DrawIndeterminateAsLineList(EntityGraphicsData data);

	public void DrawQuads(Point3D[] vertices, Vector3D[] normals)
	{
		DrawQuads(vertices, normals, 0, vertices.Length);
	}

	public abstract void DrawQuads(Point3D[] vertices, Vector3D[] normals, int first, int count);

	public virtual void DrawCurrentBuffer()
	{
	}

	public virtual void EndDrawBufferedLines()
	{
	}

	public abstract void SetBlockRefTransform(float[] blockRefrenceMatrix);

	protected bool IsCw(rasterizerStateType state)
	{
		return (int)(state & rasterizerStateType.CW_PolygonLine_NoCullFace) >> 6 == 1;
	}

	public abstract void DrawPlainTriangles(IList<IndexTriangle> triangles, IList<Point3D> vertices);

	public abstract void DrawPlainTriangles(IList<IndexTriangle> triangles, IList<Point3D> vertices, IList<Vector3D> normals);

	public abstract void DrawSmoothTriangles(IList<IndexTriangle> triangles, IList<Point3D> vertices, IList<Vector3D> normals);

	public virtual void DrawPlainTrianglesNoColors(IList<IndexTriangle> triangles, IList<Point3D> vertices, IList<Vector3D> normals)
	{
		DrawPlainTriangles(triangles, vertices, normals);
	}

	public abstract void DrawColorPlainTriangles(IList<IndexTriangle> triangles, IList<Point3D> vertices, IList<Vector3D> normals);

	public abstract void DrawColorSmoothTriangles(IList<IndexTriangle> triangles, IList<Point3D> vertices, IList<Vector3D> normals);

	public abstract void DrawMulticolorPlainTriangles(IList<IndexTriangle> triangles, IList<Point3D> vertices, IList<Vector3D> normals, byte alpha = byte.MaxValue);

	public abstract void DrawMulticolorSmoothTriangles(IList<IndexTriangle> triangles, IList<Point3D> vertices, IList<Vector3D> normals, byte alpha = byte.MaxValue);

	public abstract void DrawCurvatureMapTriangles(IList<IndexTriangle> triangles, IList<Point3D> vertices, Color[] colorMap);

	public abstract void DrawCurvatureMapInvTriangles(IList<IndexTriangle> triangles, IList<Point3D> vertices, Color[] colorMap);

	public abstract void DrawRichPlainTriangles(IList<IndexTriangle> triangles, IList<Point3D> vertices, IList<Vector3D> normals, IList<PointF> texCoords);

	public abstract void DrawRichSmoothTriangles(IList<IndexTriangle> triangles, IList<Point3D> vertices, IList<Vector3D> normals, IList<PointF> texCoords);

	public abstract void DrawRichSmoothTriangles(IList<IndexTriangle> triangles, IList<Point3D> vertices, float scaleU, float scaleV, float offsetU, float offsetV, float rotateUV);

	public abstract void DrawRichSmoothInvTriangles(IList<IndexTriangle> triangles, IList<Point3D> vertices, float scaleU, float scaleV, float offsetU, float offsetV, float rotateUV);

	public abstract void DrawSurfaceTriangles(IList<IndexTriangle> triangles, IList<Point3D> vertices);

	public abstract void DrawSurfaceInvTriangles(IList<IndexTriangle> triangles, IList<Point3D> vertices);

	public abstract void DrawIndexedTriangles(VBOParamsBase myParams);

	internal void _0023_003DzTGesRbiB0MU2(colorMaskFlags _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzcHyhEzo2jLqItkwVK39lVfo_003D = _0023_003DzPzO_0024GUk_003D;
	}

	public void SetColorMask(colorMaskFlags colorMask)
	{
		_0023_003DzTGesRbiB0MU2(colorMask);
		blendStateType blendStateType2 = _0023_003DzjgXxb7Z_0024IFvt(CurrentBlendState, colorMask);
		if (blendStateType2 != CurrentBlendState)
		{
			SetState(blendStateType2);
		}
	}

	private blendStateType _0023_003DzjgXxb7Z_0024IFvt(blendStateType _0023_003Dzv0svZZSvM84_0024, colorMaskFlags _0023_003DzgNV7Ro_ukZCJ)
	{
		return (blendStateType)((int)(_0023_003Dzv0svZZSvM84_0024 & (blendStateType)(-16)) | (int)_0023_003DzgNV7Ro_ukZCJ);
	}

	public virtual bool HasStencil()
	{
		return true;
	}

	public virtual bool HasShadow()
	{
		return true;
	}

	public virtual bool HasMultiTexture()
	{
		return true;
	}

	[Conditional("DEBUG")]
	public void PrintMatrices()
	{
		Console.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302663327));
		for (int i = 0; i < CurrentProjectionMatrix().Length; i++)
		{
			Console.Write(CurrentProjectionMatrix()[i] + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908108));
			if (i % 4 == 0)
			{
				Console.WriteLine();
			}
		}
		Console.WriteLine(string.Empty);
		Console.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302664049));
		for (int j = 0; j < CurrentModelViewMatrix().Length; j++)
		{
			Console.Write(CurrentModelViewMatrix()[j] + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908108));
			if (j % 4 == 0)
			{
				Console.WriteLine();
			}
		}
		Console.WriteLine(string.Empty);
	}

	public abstract void DrawTrianglesWithDisplacement(PointWithDisplacement[] vertices, Vector3D[] normals, Color singleColor, double ampFactor, int mode, bool addToCurrentBufferPart = false);

	public abstract void DrawTrianglesWithDisplacement(PointWithDisplacement[] vertices, Vector3D[] normals, Color[] colors, double ampFactor, int mode, bool addToCurrentBufferPart = false);

	public abstract void DrawTrianglesWithDisplacement(PointWithDisplacement[] vertices, Vector3D[] normals, double ampFactor, int mode, bool addToCurrentBufferPart = false);

	public abstract void DrawTrianglesWithDisplacement(PointWithDisplacement[] vertices, Vector3D[] normals, float[] tex1DCoords, double ampFactor, int mode, bool addToCurrentBufferPart = false);

	protected internal virtual void SetRenderTarget(TextureBase texture)
	{
	}

	protected virtual void SetRenderTarget(TextureBase texture, TextureBase depthTexture)
	{
	}

	protected internal virtual void ResetRenderTarget()
	{
	}

	protected internal abstract void BlurTexture(ref TextureBase sharpTexture, ref TextureBase blurredTexture);

	public void InitializeStates()
	{
		SetState(rasterizerStateType.CCW_PolygonFill_CullFaceBack_NoPolygonOffset, force: true);
		SetState(depthStencilStateType.DepthTestAlways, force: true);
		SetState(blendStateType.NoBlend, force: true);
	}

	public virtual void SetTexture1DWrapMode(bool clamp)
	{
	}

	public virtual void BeginDrawForSelection()
	{
	}

	public virtual void EndDrawForSelection()
	{
	}

	public virtual bool NeedsToCaptureDepth()
	{
		return false;
	}

	public virtual void ReadDepth()
	{
	}

	public virtual void LockShaders(bool lockShader)
	{
		_0023_003Dz4SjcBbKskKht = lockShader;
	}

	public virtual void LockBlendState(bool lockBlendState)
	{
		_0023_003Dzmfb0KEd0lJJt = lockBlendState;
	}

	public virtual void BeginDrawForDepth()
	{
		_0023_003DzsR1A0Vi4ASN_jC2CKg_003D_003D(_0023_003DzPzO_0024GUk_003D: true);
		PushBlendState();
		SetState(blendStateType.NoBlend);
		SetShader(shaderType.WriteDepth);
		LockShaders(lockShader: true);
		LockBlendState(lockBlendState: true);
	}

	private void _0023_003DzsR1A0Vi4ASN_jC2CKg_003D_003D(bool _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003Dzm2OyT8qCbJ7h1QCQmRf0W78_003D = _0023_003DzPzO_0024GUk_003D;
	}

	public virtual void EndDrawForDepth()
	{
		_0023_003DzsR1A0Vi4ASN_jC2CKg_003D_003D(_0023_003DzPzO_0024GUk_003D: false);
		LockShaders(lockShader: false);
		LockBlendState(lockBlendState: false);
		PopBlendState();
	}

	public virtual void EnableMultisample(bool enable)
	{
	}

	public virtual bool HasFBO()
	{
		return true;
	}

	public virtual bool HasFBBlit()
	{
		return true;
	}

	public virtual bool HasFBMultisample()
	{
		return true;
	}

	public virtual bool HasPackedDepthStencil()
	{
		return true;
	}

	public abstract void EnableThickLines();

	public abstract void EnableThickLinesInPolygonLineMode();

	public abstract void EnableThickPoints();

	public abstract void EnableThickPointsInPolygonLineMode();

	public void DrawLines(Point3D[] vertices, Color[] colors)
	{
		DrawLines(vertices, colors, 0, vertices.Length);
	}

	public abstract void DrawLines(Point3D[] vertices, Color[] colors, int first, int count);

	public void DrawLines(Point3D[] vertices, Color[] colors, float[] lineWidths)
	{
		DrawLines(vertices, colors, lineWidths, 0, vertices.Length);
	}

	public abstract void DrawLines(Point3D[] vertices, Color[] colors, float[] lineWidths, int first, int count);

	public void DrawLines(Point3D[] vertices, float[] texCoords)
	{
		DrawLines(vertices, texCoords, 0, vertices.Length);
	}

	public abstract void DrawLines(Point3D[] vertices, float[] texCoords, int first, int count);

	public abstract void SetSceneAmbient(float[] color);

	public virtual void BeginDrawMulticolorWithAmbientAndDiffuse(ShaderParameters shaderParams)
	{
		if (shaderParams != null)
		{
			shaderParams.UseColorForAmbientAndDiffuse = true;
		}
	}

	public virtual void EndDrawMulticolorWithAmbientAndDiffuse(ShaderParameters shaderParams)
	{
		if (shaderParams != null)
		{
			shaderParams.UseColorForAmbientAndDiffuse = false;
		}
	}

	public virtual void DrawLinesOnTheFly(Point3D[] lines)
	{
		DrawLinesAndPointsOnTheFly(lines, new Point3D[0]);
	}

	public virtual void DrawLinesAndPointsOnTheFly(Point3D[] lines, Point3D[] points)
	{
		DrawLinesAndPoints(lines, points);
	}

	public void DrawLinesAndPoints(Point3D[] lines, Point3D[] points)
	{
		if (lines.Length != 0)
		{
			DrawLines(lines);
		}
		if (points.Length != 0)
		{
			DrawPoints(points);
		}
	}

	public virtual void DrawPointsOnTheFly(Point3D[] points)
	{
		if (points.Length != 0)
		{
			DrawPoints(points);
		}
	}

	[CLSCompliant(false)]
	public virtual void SetLineStipple(int factor, ushort pattern, Camera camera)
	{
	}

	public virtual void EnableLineStipple(bool enable)
	{
		lineStipple = enable;
	}

	public virtual void ClearDynamicBuffers()
	{
	}

	public virtual void UpdateAntialiasing()
	{
		MakeCurrent();
		FreeCaptureTextures();
		ResizeSurfacesForCapture(ControlData.ControlSize, ControlData.isFsaaAvailable);
		FreeCompositingObjects();
		ResizeCompositingObjects(ControlData.ControlSize);
	}

	public void SetRasterizerState(rasterizerPolygonDrawingType rasterizerPolygonDrawingType, rasterizerCullFaceType rasterizerCullFaceType)
	{
		SetState((rasterizerStateType)((int)((uint)(CurrentRasterizerState & (rasterizerStateType)(-33) & (rasterizerStateType)(-25)) | (uint)((int)rasterizerPolygonDrawingType << 5)) | ((int)rasterizerCullFaceType << 3)));
	}

	public virtual void BeginCaptureZBufferOnce()
	{
	}

	public virtual void EndCaptureZBufferOnce()
	{
	}

	public void LockDepthState(bool lockState)
	{
		_0023_003DzevpTLAjaYrgv = lockState;
	}

	public abstract void DrawTextureOnScreen(Rectangle rect, TextureBase textureForRendering, TextureBase textureResolved);

	public void EnableXOR(bool enable)
	{
		if (enable)
		{
			SetColorWireframe(Color.White);
			PushBlendState();
			SetState(blendStateType.XOR);
		}
		else
		{
			PopBlendState();
		}
	}

	public void EnableXORForTexture(bool enable, ShaderParameters shaderParams)
	{
		EnableXOR(enable);
		EnableAlphaClip(enable);
		if (shaderParams != null)
		{
			shaderParams.AlphaClip = enable;
		}
		UpdateConstantBufferPerFrame(shaderParams);
	}

	public abstract bool EnableAlphaClip(bool enable);

	public void DisableShadowMap()
	{
		globalShadowMapData.Disable(this);
	}

	public abstract Color GetPixel(int x, int y);

	public virtual void SetActiveTexture(TextureBase.textureUnitType textureUnit)
	{
	}

	public abstract float[,] GetHeightmapFromGeometry(double[] transformationMatrix, int[] viewFrame, DrawPlainGeometryCallBack drawCall);

	protected internal abstract void GetTextOutlines(double chordalErr, Transformation transf, bool computeInners, bool toCurve, IWorkspace ws, Text textEntity, TextStyle textStyle, FontStyleData fsd, out ICurve[] outers, out ICurve[][] inners, Text.GetTextOutlinesDelegate getTextOutlines);

	protected internal virtual IList<Entity> GetCharMeshes(string s, string fontName, fontStyle style, double scaleToUnitSize, double chordalErr, bool isRightToLeft)
	{
		double width;
		double descend;
		Point2D[][] fpcOuters;
		Point2D[][][] fpcInners;
		return GetCharMeshes(s, fontName, style, scaleToUnitSize, chordalErr, isRightToLeft, out width, out descend, computeDataForFpc: false, out fpcOuters, out fpcInners);
	}

	protected internal abstract IList<Entity> GetCharMeshes(string s, string fontName, fontStyle style, double scaleToUnitSize, double chordalErr, bool isRightToLeft, out double width, out double descend, bool computeDataForFpc, out Point2D[][] fpcOuters, out Point2D[][][] fpcInners);

	protected internal abstract double GetQScaleFactor(string fontName, fontStyle style);

	protected internal abstract void GetCharOutlines(string s, double chordalErr, bool toCurve, bool isRightToLeft, out Point2D[][] loops, out double Descend, double fontScale);

	protected internal abstract void GetCharOutlines(string s, double chordalErr, bool toCurve, bool isRightToLeft, out Point2D[][] outers, out Point2D[][][] inners, out double Descend, double fontScale);

	protected internal abstract string GetDefaultFontFamilyName();

	internal abstract EntityGraphicsData InitCompositingData();

	protected internal abstract EntityGraphicsData CreateEntityGraphicsData();

	public abstract EntityGraphicsData CreateEntityGraphicsData(object parent);

	internal abstract ZBufferBase CreateZBuffer(ZBufferBase _0023_003DzySgeilxprQOK);

	internal abstract byte[] BitmapFromColors(Color[] _0023_003DzSTzI4Tk_003D);

	public virtual void ResolveMultisampleTexture(TextureBase multiSampleTexture, TextureBase singleSampleTexture)
	{
		throw new NotImplementedException();
	}

	internal void SetColorRenderedInternal(entityNatureType _0023_003DzL3kjwgWK1Hcy, Material _0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D, bool _0023_003DzNGLWIVQ_003D, RenderParams _0023_003DzELu0Pss_003D)
	{
		if (_0023_003DzL3kjwgWK1Hcy == entityNatureType.Polygon || _0023_003DzL3kjwgWK1Hcy == entityNatureType.RichPolygon)
		{
			SetLighting(enable: true);
			_0023_003DzAjR7yQItKV_0024s(_0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D, _0023_003DzNGLWIVQ_003D, _0023_003DzELu0Pss_003D);
		}
	}

	internal void _0023_003DzAjR7yQItKV_0024s(Material _0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D, bool _0023_003DzNGLWIVQ_003D, RenderParams _0023_003DzELu0Pss_003D)
	{
		bool texture2D = SetMaterial(_0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D, _0023_003DzNGLWIVQ_003D, _0023_003DzELu0Pss_003D);
		if (_0023_003DzELu0Pss_003D.ShaderParams != null)
		{
			_0023_003DzELu0Pss_003D.ShaderParams.Lighting = true;
			_0023_003DzELu0Pss_003D.ShaderParams.Texture2D = texture2D;
			_0023_003DzELu0Pss_003D.ShaderParams.AlphaMap = _0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D.AlphaMap != null;
			_0023_003DzELu0Pss_003D.ShaderParams.TextureOverExposure = _0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D.TextureImageOverExposure;
		}
		_0023_003DzAQu_Xko_003D(_0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D, _0023_003DzELu0Pss_003D);
	}

	internal void _0023_003DzAQu_Xko_003D(Material _0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D, RenderParams _0023_003DzELu0Pss_003D)
	{
		if (_0023_003DzELu0Pss_003D.hqrData.EnvironmentMapping)
		{
			SetEnvironment(_0023_003DzELu0Pss_003D.hqrData.EnvironmentMap, _0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D, _0023_003DzELu0Pss_003D.ShaderParams);
		}
	}

	internal bool SetMaterial(Material _0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D, bool _0023_003DzNGLWIVQ_003D, DrawParams _0023_003DzELu0Pss_003D)
	{
		return SetMaterial(_0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D, _0023_003DzG_0024lkZE0vy9Tc(_0023_003DzEwpZqac7ZyDoMIaxnA_003D_003D.Diffuse, _0023_003DzELu0Pss_003D.viewportInternal.parent.Backface, _0023_003DzNGLWIVQ_003D), _0023_003DzNGLWIVQ_003D);
	}

	internal static Color _0023_003DzG_0024lkZE0vy9Tc(Color _0023_003Dz1MMYB1g_003D, BackfaceSettings _0023_003DzHwbmr9zAs_0024_fY9J4hw_003D_003D, bool _0023_003DzNGLWIVQ_003D)
	{
		if (!_0023_003DzNGLWIVQ_003D && _0023_003DzHwbmr9zAs_0024_fY9J4hw_003D_003D.ColorMethod == backfaceColorMethodType.SingleColor)
		{
			_0023_003Dz1MMYB1g_003D = ((_0023_003Dz1MMYB1g_003D.A < byte.MaxValue) ? Color.FromArgb(_0023_003Dz1MMYB1g_003D.A, _0023_003DzHwbmr9zAs_0024_fY9J4hw_003D_003D.Color) : _0023_003DzHwbmr9zAs_0024_fY9J4hw_003D_003D.Color);
		}
		return _0023_003Dz1MMYB1g_003D;
	}

	internal void SetColorShadedInternal(entityNatureType _0023_003DzL3kjwgWK1Hcy, Color _0023_003Dz1MMYB1g_003D, bool _0023_003DzNGLWIVQ_003D, BackfaceSettings _0023_003DztwJcRjit0JQIRvuJcQ_003D_003D)
	{
		CloseEnvironment();
		CloseTexture();
		switch (_0023_003DzL3kjwgWK1Hcy)
		{
		case entityNatureType.None:
		case entityNatureType.Point:
		case entityNatureType.Wire:
			SetLighting(enable: false);
			SetColorWireframe(_0023_003Dz1MMYB1g_003D);
			break;
		case entityNatureType.Polygon:
		case entityNatureType.RichPolygon:
			SetLighting(enable: true);
			SetColorDiffuse(_0023_003Dz1MMYB1g_003D, _0023_003DzG_0024lkZE0vy9Tc(_0023_003Dz1MMYB1g_003D, _0023_003DztwJcRjit0JQIRvuJcQ_003D_003D, _0023_003DzNGLWIVQ_003D));
			break;
		}
	}

	protected virtual void evaluateShadersHqr()
	{
	}

	protected virtual void UpdateUseFBO()
	{
		UsingShadowFBO = ControlData.useFrameBufferObject;
	}

	public void InitStandardShaders(realisticShadowQualityType shadowQWuality, ref Dictionary<shaderType, IShaderTechnique> shaders, LightSettings[] lights)
	{
		MakeCurrent();
		CleanUpShaders(ref shaders);
		shaders = CreateShaders(shadowQWuality, lights);
		SetShaders(shaders, planarReflections: false);
	}

	public void CleanUpShaders(ref Dictionary<shaderType, IShaderTechnique> shaders)
	{
		if (shaders != null)
		{
			foreach (KeyValuePair<shaderType, IShaderTechnique> shader in shaders)
			{
				if (shader.Value != null)
				{
					shader.Value.Dispose();
				}
			}
		}
		shaders = null;
	}

	public static void UpdateShaders(Dictionary<shaderType, IShaderTechnique> shaders, ShaderParameters shaderParams)
	{
		foreach (KeyValuePair<shaderType, IShaderTechnique> shader in shaders)
		{
			if (shader.Value.IsCompiled)
			{
				shader.Value.SetParameters(shaderParams);
				shader.Value.Disable(shaderParams.RenderContext);
			}
		}
	}

	public void UpdateShaders(ShaderParameters shaderParams)
	{
		shaderType currentShader = CurrentShader;
		foreach (KeyValuePair<shaderType, IShaderTechnique> shader in Shaders)
		{
			if (shader.Value.IsCompiled)
			{
				shader.Value.SetParameters(shaderParams);
				shader.Value.Disable(this);
			}
		}
		SetShader(currentShader, shaderParams, force: true);
	}

	protected virtual void UpdateShadersForShadow(Dictionary<shaderType, IShaderTechnique> shaders, ShaderParameters shaderParams)
	{
		shaderType currentShader = CurrentShader;
		foreach (KeyValuePair<shaderType, IShaderTechnique> shader in shaders)
		{
			if (shader.Value.IsCompiled)
			{
				EnableShader(shader.Key, shaders);
				shader.Value.Shader.SetParametersForShadow(shaderParams);
				shader.Value.Disable(this);
			}
		}
		SetShader(currentShader, shaderParams, force: true);
	}

	public abstract int RegisterCustomShader(IShader customShader);

	public abstract bool SetCustomShader(IShader customShader, ShaderParameters shaderParameters = null);

	public abstract bool RemoveCustomShader(IShader customShader);

	public abstract bool RemoveAllCustomShaders();

	internal void DrawQuadScreenSpace(Rectangle _0023_003DzpwNEYBU_003D, ClippingPlaneBase[] _0023_003Dz6UteXW4OjphV_00246VeOw_003D_003D, float _0023_003DzvxHPuJA_003D = 1f, RectangleF? _0023_003Dz3a6VzU2Alias = null)
	{
		if (!_0023_003DzhKchaoP7bg6WEIN6qg_003D_003D())
		{
			throw new GraphicsException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302664042));
		}
		bool flag = _0023_003Dz6UteXW4OjphV_00246VeOw_003D_003D != null;
		bool[] _0023_003DzR_0024c5epA_003D = null;
		if (flag)
		{
			_0023_003DzR_0024c5epA_003D = Utility.TurnOffClippingPlanes(_0023_003Dz6UteXW4OjphV_00246VeOw_003D_003D, this);
		}
		int[] viewFrame = currViewFrame;
		float depthMin = currDepthMin;
		float depthMax = currDepthMax;
		SetViewport(new int[4] { _0023_003DzpwNEYBU_003D.Left, _0023_003DzpwNEYBU_003D.Top, _0023_003DzpwNEYBU_003D.Width, _0023_003DzpwNEYBU_003D.Height }, _0023_003DzvxHPuJA_003D, _0023_003DzvxHPuJA_003D);
		PushMatrices();
		PushRasterizerState();
		float num = 1f / (float)ControlData.ControlSize.Width;
		float num2 = 1f / (float)ControlData.ControlSize.Height;
		RectangleF rectangleF = (_0023_003Dz3a6VzU2Alias.HasValue ? new RectangleF(_0023_003Dz3a6VzU2Alias.Value.Left, _0023_003Dz3a6VzU2Alias.Value.Top, _0023_003Dz3a6VzU2Alias.Value.Width, _0023_003Dz3a6VzU2Alias.Value.Height) : new RectangleF((float)_0023_003DzpwNEYBU_003D.X * num, (float)_0023_003DzpwNEYBU_003D.Y * num2, (float)_0023_003DzpwNEYBU_003D.Width * num, (float)_0023_003DzpwNEYBU_003D.Height * num2));
		SetMatrices(Camera.myOrtho(this, rectangleF.Left, rectangleF.Right, rectangleF.Top, rectangleF.Bottom, -1.0, 1.0), null);
		SetState(rasterizerStateType.CCW_PolygonFill_NoCullFace_NoPolygonOffset);
		Draw(_0023_003DzW70aGT4iRDyqZJb7Gg_003D_003D);
		PopRasterizerState();
		PopMatrices();
		SetViewport(viewFrame, depthMin, depthMax);
		if (flag)
		{
			Utility.RestoreClippingPlanesStatus(_0023_003Dz6UteXW4OjphV_00246VeOw_003D_003D, this, _0023_003DzR_0024c5epA_003D);
		}
	}

	private bool _0023_003DzhKchaoP7bg6WEIN6qg_003D_003D()
	{
		if (_0023_003DzW70aGT4iRDyqZJb7Gg_003D_003D != null)
		{
			return true;
		}
		bool isDirect3D = IsDirect3D;
		_0023_003DzW70aGT4iRDyqZJb7Gg_003D_003D = CreateEntityGraphicsData();
		CompileVBO(_0023_003DzW70aGT4iRDyqZJb7Gg_003D_003D, delegate(RenderContextBase _0023_003Dz8If0AEk_003D, object _0023_003DzmPmPjCPqZ3T3)
		{
			_0023_003Dz8If0AEk_003D.DrawIndexedTriangles((VBOParamsTexture)_0023_003DzmPmPjCPqZ3T3);
		}, new VBOParamsTexture
		{
			vertices = new float[12]
			{
				0f, 0f, -1f, 0f, 1f, -1f, 1f, 1f, -1f, 1f,
				0f, -1f
			},
			TextureCoordinates = new float[8]
			{
				0f,
				isDirect3D ? 1f : 0f,
				0f,
				isDirect3D ? 0f : 1f,
				1f,
				isDirect3D ? 0f : 1f,
				1f,
				isDirect3D ? 1f : 0f
			},
			indices = new int[6] { 0, 1, 2, 0, 2, 3 },
			primitiveMode = primitiveType.TriangleList
		});
		return true;
	}

	private void _0023_003DzV6RJqRXq1xJpsZWH_0024Q_003D_003D()
	{
		_0023_003DzW70aGT4iRDyqZJb7Gg_003D_003D?.Dispose();
		_0023_003DzW70aGT4iRDyqZJb7Gg_003D_003D = null;
	}

	internal bool _0023_003Dzmc9vpOYLyp6N(Size _0023_003Dz14lzA48_003D, bool _0023_003DzO3nzerFTjfPE)
	{
		ClearShadowMaps();
		bool flag = true;
		if (_0023_003DzO3nzerFTjfPE)
		{
			PushCurrentFBO();
			flag = globalShadowMapData.InitFBO(this, 1, (uint)_0023_003Dz14lzA48_003D.Width, (uint)_0023_003Dz14lzA48_003D.Height);
			RestoreFBO();
		}
		else
		{
			flag &= globalShadowMapData._0023_003Dz1u4wmda3JTwv(this, 1, (uint)_0023_003Dz14lzA48_003D.Width, (uint)_0023_003Dz14lzA48_003D.Height);
		}
		return flag;
	}

	public void ClearShadowMaps()
	{
		globalShadowMapData.Clear(this);
		UpdateUseFBO();
	}

	public abstract void PushCurrentFBO();

	public abstract void RestoreFBO();

	public virtual void PrepareLightsForShadow(bool reflection)
	{
		ProcessLightAttributes(shadowPass: false, reflection);
	}

	public void UpdateActiveLights(IWorkspace workspace)
	{
		UpdateActiveLights(((IWorkspaceInternal)workspace).lights);
	}

	public void UpdateActiveLights(LightSettings[] lights)
	{
		int num = 0;
		int num2 = -1;
		for (int i = 0; i < lights.Length; i++)
		{
			if (lights[i].Active)
			{
				num++;
				if (lights[i].YieldShadow && num2 == -1)
				{
					num2 = i;
				}
			}
		}
		num = Math.Max(2, num);
		_0023_003DzJ2qPSzaJNmg9tDlZXQ_003D_003D = new LightSettings[num];
		int num3 = 0;
		if (num2 >= 0)
		{
			_0023_003DzJ2qPSzaJNmg9tDlZXQ_003D_003D[0] = lights[num2];
			num3++;
		}
		for (int j = 0; j < lights.Length; j++)
		{
			if (lights[j].Active && j != num2)
			{
				_0023_003DzJ2qPSzaJNmg9tDlZXQ_003D_003D[num3++] = lights[j];
			}
		}
		while (num3 < num)
		{
			_0023_003DzJ2qPSzaJNmg9tDlZXQ_003D_003D[num3++] = new LightSettings();
		}
	}

	public void ProcessLightAttributes(bool shadowPass, bool reflection)
	{
		float[] array = null;
		float[] specular = null;
		float num = 0f;
		if (shadowPass)
		{
			num = GetShadowAmbientFactor(ActiveLights);
		}
		bool flag = false;
		for (int i = 0; i < ActiveLights.Length; i++)
		{
			LightSettings lightSettings = ActiveLights[i];
			if (lightSettings == null)
			{
				continue;
			}
			if (!lightSettings.Active)
			{
				SetLightAttributes(i, array, _0023_003DzDd_hgOLU_0024BR_0024, specular, lightSettings);
				continue;
			}
			array = Utility.ColorToFloatArray(lightSettings.Color);
			if (shadowPass && lightSettings.YieldShadow && !flag && lightSettings.Type != lightType.Point)
			{
				for (int j = 0; j < 3; j++)
				{
					array[j] *= num;
				}
				specular = new float[4] { 0f, 0f, 0f, 1f };
				flag = !MultipleLightsWithShadows;
			}
			else
			{
				specular = Utility.ColorToFloatArray(lightSettings.Specular);
			}
			SetLightAttributes(i, array, _0023_003DzDd_hgOLU_0024BR_0024, specular, lightSettings);
		}
		if (ActiveLights.Length < 8)
		{
			LightSettings lightSettings2 = new LightSettings();
			lightSettings2.Active = false;
			for (int k = ActiveLights.Length; k < 8; k++)
			{
				SetLightAttributes(k, array, _0023_003DzDd_hgOLU_0024BR_0024, specular, lightSettings2);
			}
		}
	}

	public virtual void ProcessClippingPlanes(ClippingPlaneBase[] clippingPlanes, bool updateGraphics = false)
	{
	}

	public abstract void ProcessClippingPlanesVisibility(ClippingPlaneBase[] clippingPlanes, bool updateGraphics = false);

	public void ResizeShadowMaps(Size controlSize, realisticShadowQualityType shadowQuality, ref bool initHQR)
	{
		if (!_0023_003DzM2S3i0YLtHCMK7Gy8w_003D_003D(controlSize, shadowQuality, ActiveLights, ref initHQR) && !_0023_003Dz9Oh2ogQ_003D)
		{
			_0023_003Dz9Oh2ogQ_003D = true;
			ControlData.useFrameBufferObject = false;
			_0023_003Dz9Oh2ogQ_003D = false;
		}
	}

	private bool _0023_003DzM2S3i0YLtHCMK7Gy8w_003D_003D(Size _0023_003DzY7Qc8v8_003D, realisticShadowQualityType _0023_003DzTsvpPzU5VCSJ, LightSettings[] _0023_003DzAkC55sp_ZvsO, ref bool _0023_003DzpUayyNajZz2w)
	{
		if (GetNumberOfShadowMapSplits(_0023_003DzTsvpPzU5VCSJ, ActiveLights) == NumberOfSplits && !globalShadowMapData.Dirty && _0023_003DzkxACDv3Y64U0He6mXQ_003D_003D == _0023_003DzY7Qc8v8_003D)
		{
			return true;
		}
		_0023_003DzkxACDv3Y64U0He6mXQ_003D_003D = _0023_003DzY7Qc8v8_003D;
		bool flag = true;
		bool flag2 = false;
		ShadowMapData shadowMapData = globalShadowMapData;
		flag2 = _0023_003DzHf2cgqOoojKjr_ebgA_003D_003D(_0023_003DzTsvpPzU5VCSJ, _0023_003DzAkC55sp_ZvsO, ref _0023_003DzpUayyNajZz2w);
		uint _0023_003DzAeGRnVQ_003D = (uint)shadowMapData.Size.Width;
		uint _0023_003Dz1u2fKoI_003D = (uint)shadowMapData.Size.Height;
		if (UsingShadowFBO)
		{
			_0023_003DzAeGRnVQ_003D = (_0023_003Dz1u2fKoI_003D = shadowMapFBOSize);
		}
		else
		{
			ShadowMapData._0023_003DzKdcsfJAO5bWnlN5RtA_003D_003D(1, (uint)Math.Pow(2.0, Math.Floor(Math.Log(_0023_003DzY7Qc8v8_003D.Width, 2.0))), (uint)Math.Pow(2.0, Math.Floor(Math.Log(_0023_003DzY7Qc8v8_003D.Height, 2.0))), out _0023_003DzAeGRnVQ_003D, out _0023_003Dz1u2fKoI_003D);
		}
		if (_0023_003DzAeGRnVQ_003D != globalShadowMapData.Size.Width || _0023_003Dz1u2fKoI_003D != globalShadowMapData.Size.Height || globalShadowMapData._texture == null)
		{
			flag2 = true;
			globalShadowMapData._0023_003DztZV3CZc_003D(new Size((int)_0023_003DzAeGRnVQ_003D, (int)_0023_003Dz1u2fKoI_003D));
		}
		if (UsingShadowFBO)
		{
			if (!shadowMapData.IsValidFBO())
			{
				flag2 = true;
			}
		}
		else if (!shadowMapData._0023_003DzVBC_IOZx_0024Eqi())
		{
			flag2 = true;
		}
		if (flag2)
		{
			do
			{
				flag = _0023_003Dzmc9vpOYLyp6N(globalShadowMapData.Size, UsingShadowFBO);
				if (!flag)
				{
					if (globalShadowMapData.Size.Width > globalShadowMapData.Size.Height)
					{
						globalShadowMapData._0023_003DztZV3CZc_003D(new Size(globalShadowMapData.Size.Width / 2, globalShadowMapData.Size.Height));
					}
					else
					{
						globalShadowMapData._0023_003DztZV3CZc_003D(new Size(globalShadowMapData.Size.Width, globalShadowMapData.Size.Height / 2));
					}
					shadowMapFBOSize /= 2u;
				}
			}
			while (!flag && globalShadowMapData.Size.Width > 0 && globalShadowMapData.Size.Height > 0);
		}
		globalShadowMapData.Dirty = false;
		return flag;
	}

	private bool _0023_003DzHf2cgqOoojKjr_ebgA_003D_003D(realisticShadowQualityType _0023_003DzTsvpPzU5VCSJ, LightSettings[] _0023_003DzAkC55sp_ZvsO, ref bool _0023_003DzpUayyNajZz2w)
	{
		bool result = false;
		int numberOfShadowMapSplits = GetNumberOfShadowMapSplits(_0023_003DzTsvpPzU5VCSJ, _0023_003DzAkC55sp_ZvsO);
		if (numberOfShadowMapSplits != NumberOfSplits)
		{
			if (NumberOfSplits != 0)
			{
				_0023_003DzpUayyNajZz2w = true;
			}
			result = true;
			_0023_003DzDpDUWL3qLTQhfI3oKg_003D_003D = numberOfShadowMapSplits;
		}
		return result;
	}

	public virtual int GetNumberOfShadowMapSplits(realisticShadowQualityType shadowQuality, LightSettings[] lights)
	{
		return ShadowMapData.GetNumberOfSplits(shadowQuality, lights);
	}

	public void ComputeShaderShadowPasses(out int nPasses, out int[] lightsWithShadow)
	{
		int num = 0;
		lightsWithShadow = new int[ActiveLights.Length];
		for (int i = 0; i < lightsWithShadow.Length; i++)
		{
			lightsWithShadow[i] = -1;
		}
		int num2 = 0;
		LightSettings[] activeLights = ActiveLights;
		for (int j = 0; j < activeLights.Length; j++)
		{
			LightSettings lightSettings = activeLights[j];
			if (lightSettings.YieldShadow && lightSettings.Type != lightType.Point)
			{
				num++;
				lightsWithShadow[num2++] = j;
				if (!MultipleLightsWithShadows)
				{
					break;
				}
			}
		}
		nPasses = Math.Max(1, num);
	}

	public void PrepareShadersForShadowPass(int shadowPass, int[] lightsWithShadows, Dictionary<shaderType, IShaderTechnique> shaders, ShaderParameters shaderParams)
	{
		shaderParams.LightsEnabled = new int[8];
		if (shadowPass == 1)
		{
			ShadowMapData.EnableAdditiveBlending(this);
		}
		shaderParams.LightWithShadow = lightsWithShadows[shadowPass];
		if (shaderParams.LightWithShadow >= 0)
		{
			if (shadowPass == 0)
			{
				if (MultipleLightsWithShadows)
				{
					for (int i = 0; i < ActiveLights.Length; i++)
					{
						LightSettings lightSettings = ActiveLights[i];
						if (lightSettings.Active && !lightSettings.YieldShadow)
						{
							shaderParams.LightsEnabled[i] = 1;
						}
					}
				}
				else
				{
					for (int j = 0; j < ActiveLights.Length; j++)
					{
						shaderParams.LightsEnabled[j] = (ActiveLights[j].Active ? 1 : 0);
					}
					shaderParams.LightsEnabled[shaderParams.LightWithShadow] = 0;
				}
			}
			if (lightsWithShadows[shadowPass] >= 0)
			{
				if (!UsingShadowFBO)
				{
					globalShadowMapData.EnableForShaders(this, 0);
				}
				shaderParams.LightsEnabled[shaderParams.LightWithShadow] = 1;
			}
			UpdateShadersForShadow(shaders, shaderParams);
		}
		else
		{
			UpdateShaders(shaders, shaderParams);
		}
	}

	public void InitShadowMapData(Camera camera, Transformation sceneTransformation, int[] viewFrame)
	{
		frustumData = new FrustumData(NumberOfSplits);
		frustumData.ComputeParallelSplitData(this, camera, sceneTransformation, viewFrame);
	}

	public void EnableShadowMap(int textureIndex)
	{
		globalShadowMapData.EnableForShaders(this, textureIndex);
	}

	public double GetShadowMapSplitPosition(int split)
	{
		return frustumData.SplitPositions[split];
	}

	public float GetShadowMapSplitDepth(int split)
	{
		return (float)frustumData.DepthRanges[split];
	}

	public bool CreateShadowMap(int lightIndex, bool firstLight, ShadowMapData.GfxShadowParams gfxShadowParams, ClippingPlaneBase[] clippingPlanes, LightSettings[] lights, DrawForShadowMapDelegate drawForShadowMap, object drawForShadowMapParams)
	{
		frustumData.SpotLight = lights[lightIndex].Type == lightType.Spot;
		globalShadowMapData._0023_003DzGbMbd2EUXQd3 = false;
		bool num = globalShadowMapData.EnableFBO(this);
		int x = 0;
		int y = 0;
		if (firstLight)
		{
			ClearDepthStencil(depthBuffer: true, stencilBuffer: false, 0);
		}
		SetShader(shaderType.NoLights);
		globalShadowMapData.Create(gfxShadowParams, lightIndex, (uint)x, (uint)y, frustumData, clippingPlanes, drawForShadowMap, drawForShadowMapParams);
		if (num)
		{
			RestoreFBO();
		}
		ClearDepthStencil(depthBuffer: true, stencilBuffer: false, 0);
		return !globalShadowMapData._0023_003DzGbMbd2EUXQd3;
	}
}
