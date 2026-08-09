using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;

namespace devDept.Eyeshot;

public class DrawParams : GraphicsEnvironmentParams, IIsolateParams
{
	public GfxAttributes Attributes;

	public bool IsDesignMode;

	public bool IsDrawingForHaloDynamic;

	public bool IsDrawingForHaloStatic;

	public backfaceColorMethodType BackFaceColorMethod;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003Dzsj3MdDYCLW3m;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal double _0023_003DzSabNiMHUjaJJ = 1.0;

	public bool ShowVertices;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IViewport _0023_003DzEwH_JIQ08EfYJPcWmA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int[] _0023_003DzqzgLb0X4VKkkNYzJXQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Vector3D _0023_003DzSuzk8RdZ1ClO99Dfxg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzUH1SmPpx4w3CYYhFmA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzmUexJ7R0ClZPPU74mw_003D_003D;

	public Color SelectionColor;

	public Color WireSelectionColor;

	public Material SelectionMaterial;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float _0023_003DzDiiUILCzc3uQ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float _0023_003DzJSoRFnDsYPnQ1EnDnCF1PzxZMF2M;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float _0023_003Dz97_0024xnf1Oh9OJ6gHp2cgtH8vMW9r_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private FontDataDictionary _0023_003Dz_0024Ekcyz8XarhVGNlWulSmjgI_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextStyleKeyedCollection _0023_003DzOdpS5s330wsiSi_tbQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private LineTypeKeyedCollection _0023_003DzDuFrfh82AJ9_0024N05F5w_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float _0023_003DzO36PKpaF4knnuUUxHLXY5y8_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Transformation _0023_003DzoAj2Rl9rKafIe4ahgQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ShaderParameters _0023_003Dzr4bvVQZYjdDH6CbnXLzl7Ak_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private BlockKeyedCollection _0023_003DzF97WMq_0024wP8gY4FUd3g_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private LayerKeyedCollection _0023_003DzSolg7xy8nvImQawkYg_003D_003D;

	public bool ParentForceGray;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzNWNpdH8jGVF45lnXjhHtMio_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float _0023_003DzDjFdQKKSNOzLM55KNOmkHVF39p5nsGTPKg_003D_003D;

	internal bool shouldUseSeparateBuffers;

	public bool ParentSelected;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzgsXHsipRVMh_YZvUQQ_003D_003D;

	public bool ParentClippable = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz0jqNni3Ap6OFE6_u7_0024NhMGiytbyu;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz50VRPkSu_0024n1vXaGi4A_003D_003D;

	public colorType ColorMode;

	public Color InsideColor;

	public Color InsideSelectionColor;

	public Material InsideSelectionMaterial;

	public Material InsideMaterial;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private selectionStatusType _0023_003Dz_0024FnYBD96k5ZEEsvwBw_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private actionType _0023_003DzskRwMqsfk9307wWLkw_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzotzLth3XnnKr_0024TWFT_0024nXi8bHyYzBB6xpZFqPKVg_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Stack<BlockReference> _0023_003DzVFEljva0ZbIneo8XbQ_003D_003D = new Stack<BlockReference>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Stack<BlockReference> _0023_003DzXFUdGLDUyZkU8Gamfb18gbg_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzZmbEmprIYLPjWqGdoVAcDelTcyen;

	public float LineWeightFactor;

	public float SelectionLineWeightScaleFactor;

	public float EdgeThickness = 1f;

	public static Point3D[] DirectionArrowPoints = new Point3D[3]
	{
		new Point3D(-6.0, -3.0, 0.0),
		new Point3D(0.0, 0.0, 0.0),
		new Point3D(-6.0, 3.0, 0.0)
	};

	public bool IsDrawingForHalo
	{
		get
		{
			if (!IsDrawingForHaloDynamic)
			{
				return IsDrawingForHaloStatic;
			}
			return true;
		}
	}

	public IViewport Viewport
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzEwH_JIQ08EfYJPcWmA_003D_003D;
		}
	}

	internal IViewportInternal viewportInternal => (IViewportInternal)Viewport;

	public int[] ViewFrame
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzqzgLb0X4VKkkNYzJXQ_003D_003D;
		}
	}

	public Vector3D ViewNormal
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzSuzk8RdZ1ClO99Dfxg_003D_003D;
		}
	}

	public int Height
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzUH1SmPpx4w3CYYhFmA_003D_003D;
		}
	}

	public double Width
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzmUexJ7R0ClZPPU74mw_003D_003D;
		}
	}

	public float ScreenToWorld
	{
		get
		{
			return _0023_003DzDiiUILCzc3uQ;
		}
		set
		{
			_0023_003DzDiiUILCzc3uQ = value;
			int num = ((!IsDesignMode) ? 4 : 0);
			_0023_003DzAr5aLw9IQq6hAfyrsA_003D_003D((float)num * value);
			_0023_003DziAAs7hKOigArQaagLQ_003D_003D(13f * value);
		}
	}

	public float ScreenToWorld4Times
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzJSoRFnDsYPnQ1EnDnCF1PzxZMF2M;
		}
	}

	public FontDataDictionary FontDefs
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz_0024Ekcyz8XarhVGNlWulSmjgI_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz_0024Ekcyz8XarhVGNlWulSmjgI_003D = value;
		}
	}

	public TextStyleKeyedCollection TextStyles
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzOdpS5s330wsiSi_tbQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzOdpS5s330wsiSi_tbQ_003D_003D = value;
		}
	}

	public LineTypeKeyedCollection LineTypes
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzDuFrfh82AJ9_0024N05F5w_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzDuFrfh82AJ9_0024N05F5w_003D_003D = value;
		}
	}

	public float LineTypeScale
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzO36PKpaF4knnuUUxHLXY5y8_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzO36PKpaF4knnuUUxHLXY5y8_003D = value;
		}
	}

	public Transformation Transformation
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzoAj2Rl9rKafIe4ahgQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzoAj2Rl9rKafIe4ahgQ_003D_003D = value;
		}
	}

	public ShaderParameters ShaderParams
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzr4bvVQZYjdDH6CbnXLzl7Ak_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzr4bvVQZYjdDH6CbnXLzl7Ak_003D = value;
		}
	}

	public BlockKeyedCollection Blocks
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzF97WMq_0024wP8gY4FUd3g_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzF97WMq_0024wP8gY4FUd3g_003D_003D = value;
		}
	}

	public LayerKeyedCollection Layers
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzSolg7xy8nvImQawkYg_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzSolg7xy8nvImQawkYg_003D_003D = value;
		}
	}

	public bool ForceGray
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzNWNpdH8jGVF45lnXjhHtMio_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzNWNpdH8jGVF45lnXjhHtMio_003D = value;
		}
	}

	public float RasterViewForceGrayAlpha
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzDjFdQKKSNOzLM55KNOmkHVF39p5nsGTPKg_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzDjFdQKKSNOzLM55KNOmkHVF39p5nsGTPKg_003D_003D = value;
		}
	}

	public bool Selected
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzgsXHsipRVMh_YZvUQQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzgsXHsipRVMh_YZvUQQ_003D_003D = value;
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

	public bool ParentIsolated
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz50VRPkSu_0024n1vXaGi4A_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz50VRPkSu_0024n1vXaGi4A_003D_003D = value;
		}
	}

	public selectionStatusType SelectionStatus
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz_0024FnYBD96k5ZEEsvwBw_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz_0024FnYBD96k5ZEEsvwBw_003D_003D = value;
		}
	}

	public actionType ActionMode
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzskRwMqsfk9307wWLkw_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzskRwMqsfk9307wWLkw_003D_003D = value;
		}
	}

	public bool PlanarReflections
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzotzLth3XnnKr_0024TWFT_0024nXi8bHyYzBB6xpZFqPKVg_003D;
		}
		[CompilerGenerated]
		internal set
		{
			_0023_003DzotzLth3XnnKr_0024TWFT_0024nXi8bHyYzBB6xpZFqPKVg_003D = value;
		}
	}

	public Stack<BlockReference> Parents
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzVFEljva0ZbIneo8XbQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzVFEljva0ZbIneo8XbQ_003D_003D = value;
		}
	}

	public Stack<BlockReference> FullParents
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzXFUdGLDUyZkU8Gamfb18gbg_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzXFUdGLDUyZkU8Gamfb18gbg_003D = value;
		}
	}

	public bool Isocurves
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzZmbEmprIYLPjWqGdoVAcDelTcyen;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzZmbEmprIYLPjWqGdoVAcDelTcyen = value;
		}
	}

	public DrawParams(IViewport viewport, BlockKeyedCollection blocks, ShaderParameters shaderParams = null)
		: this((IViewportInternal)viewport, blocks, shaderParams)
	{
	}

	internal DrawParams(IViewportInternal _0023_003DzqkfbPc0_003D, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, ShaderParameters _0023_003Dzfhte6waclh6c = null)
		: base(_0023_003DzqkfbPc0_003D.parent.RenderContext, _0023_003DzqkfbPc0_003D.parent.Document.MaxPatternRepetitions, _0023_003DzqkfbPc0_003D.parent.CompileWires)
	{
		IWorkspaceInternal parent = _0023_003DzqkfbPc0_003D.parent;
		base.RenderContext = parent.RenderContext;
		_0023_003DzBEcDMzq6J80l(parent.MyHeight);
		_0023_003DzUBcyrssJEGAK(parent.MyWidth);
		IsDesignMode = parent.IsDesignMode();
		Blocks = _0023_003DzJO1FWlQ_003D;
		Layers = parent.Layers;
		TextStyles = parent.TextStyles;
		LineTypes = parent.LineTypes;
		LineTypeScale = parent.Document.LineTypeScale;
		FontDefs = parent.Document.fontDefs;
		ActionMode = parent.ActionMode;
		FullParents = parent.Parents;
		BackFaceColorMethod = parent.Backface.ColorMethod;
		Transformation = parent.CurrentTransformation;
		SelectionLineWeightScaleFactor = parent.Selection.LineWeightScaleFactor;
		_0023_003Dzg7_0024B61WbcUp2(_0023_003DzqkfbPc0_003D);
		_0023_003DzTLoQoHtAefnm(_0023_003DzqkfbPc0_003D.GetViewFrame());
		_0023_003Dzvr5pe2gCFn4_0024(_0023_003DzqkfbPc0_003D.Camera.ViewNormal);
		ScreenToWorld = _0023_003DzqkfbPc0_003D.screenToWorld;
		InsideMaterial = parent.DefaultMaterial;
		InsideSelectionMaterial = parent.DefaultMaterial;
		ForceGray = false;
		if (_0023_003Dzfhte6waclh6c != null)
		{
			ShaderParams = _0023_003Dzfhte6waclh6c;
		}
		else
		{
			ShaderParams = new ShaderParameters(base.RenderContext)
			{
				ViewFrame = ViewFrame,
				Camera = _0023_003DzqkfbPc0_003D.Camera,
				ShadowMode = parent.Rendered.ShadowMode,
				ShadowQuality = parent.Rendered.RealisticShadowQuality,
				Background = _0023_003DzqkfbPc0_003D.Background,
				Backface = parent.Backface
			};
		}
		SelectionStatus = selectionStatusType.Permanent;
		if (parent is IDesign design && (_0023_003Dzsj3MdDYCLW3m = design.CurrentSketch != null))
		{
			_0023_003DzSabNiMHUjaJJ = design.CurrentSketch.TextScaleFactor * design.CurrentSketch.screenToWorldInvariantFactor;
		}
	}

	private void _0023_003Dzg7_0024B61WbcUp2(IViewport _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzEwH_JIQ08EfYJPcWmA_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	private void _0023_003DzTLoQoHtAefnm(int[] _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzqzgLb0X4VKkkNYzJXQ_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	private void _0023_003Dzvr5pe2gCFn4_0024(Vector3D _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzSuzk8RdZ1ClO99Dfxg_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	private void _0023_003DzBEcDMzq6J80l(int _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzUH1SmPpx4w3CYYhFmA_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	private void _0023_003DzUBcyrssJEGAK(double _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzmUexJ7R0ClZPPU74mw_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	internal void _0023_003Dz4M7aapi8f26U(IWorkspaceInternal _0023_003DzFM3KC0w_003D)
	{
		WireSelectionColor = (SelectionColor = ((SelectionStatus == selectionStatusType.Temporary) ? _0023_003DzFM3KC0w_003D.Selection.ColorDynamic : _0023_003DzFM3KC0w_003D.Selection.Color));
		if (Viewport.DisplayMode == displayType.Flat || Viewport.DisplayMode == displayType.HiddenLines)
		{
			SelectionColor = _0023_003DzFM3KC0w_003D.MakeDarkerColor(SelectionColor);
		}
		if ((SelectionStatus == selectionStatusType.Temporary && _0023_003DzFM3KC0w_003D.ShouldDrawDynamicWithHalo(viewportInternal)) || (SelectionStatus == selectionStatusType.Permanent && _0023_003DzFM3KC0w_003D.ShouldDrawStaticWithHalo(viewportInternal)))
		{
			SelectionColor = RenderContextBase.selectionWithThickHaloColor;
			WireSelectionColor = RenderContextBase.selectionWithHaloColor;
		}
		SelectionMaterial = _0023_003DzFM3KC0w_003D.DefaultMaterial.SoftClone();
		SelectionMaterial.Diffuse = SelectionColor;
		SelectionMaterial.Environment = 0f;
	}

	private void _0023_003DzAr5aLw9IQq6hAfyrsA_003D_003D(float _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzJSoRFnDsYPnQ1EnDnCF1PzxZMF2M = _0023_003DzPzO_0024GUk_003D;
	}

	internal float _0023_003DzWyuTTljMwrxwShKMYA_003D_003D()
	{
		return _0023_003Dz97_0024xnf1Oh9OJ6gHp2cgtH8vMW9r_;
	}

	private void _0023_003DziAAs7hKOigArQaagLQ_003D_003D(float _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003Dz97_0024xnf1Oh9OJ6gHp2cgtH8vMW9r_ = _0023_003DzPzO_0024GUk_003D;
	}
}
