using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;

namespace devDept.Eyeshot;

public class DrawSceneParams
{
	internal bool isDepthPrepass;

	internal bool isSketchActive;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IList<Entity> _0023_003DzirHP2g6iDbM7YBocSw_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private BlockKeyedCollection _0023_003DzF97WMq_0024wP8gY4FUd3g_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IWorkspace _0023_003DzCD7X4841bsdB_yy03g_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int[] _0023_003DzqlbijOf8URlt;

	internal IUserInterfaceElementBase UserInterfaceElement;

	public bool ClearDepthBuffer = true;

	public bool DrawAllUIElements;

	public float DrawScale;

	public float ViewportScaleRatio;

	public float LineWeightFactor;

	public RectangleF ZoomRect;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzLgDwPvB_0024_ePvIHKwzSwjdV_44NwO = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzsPFBIXN1SZKfmBB0EeqG8sk_003D = true;

	public PointF startZoomPt;

	public bool DrawOverlay;

	internal bool SkipSsao;

	internal bool ssaoEnabled;

	internal bool SkipImageBasedSilho;

	internal bool Thumbnail;

	internal bool SwapBuffer;

	internal bool IsDesignMode;

	internal bool CaptureSurface;

	public bool ZBufferOnly;

	internal bool isDrawingDynamicWithHalo;

	internal bool isDrawingStaticWithHalo;

	internal bool selectionFound;

	internal bool transparencyFound;

	public bool Simplify;

	internal bool isProgressiveDrawing;

	internal bool shouldUseSeparateBuffers;

	internal bool isLastBatch;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IViewport _0023_003Dz3BW3eaE_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Size _0023_003DzsGcL5XEyZIot;

	internal RectangleF Rectangle;

	internal bool IsUIElement;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private CameraEyePosType _0023_003DzWgjVai0Rqm3_0024X6Fl6gVJfQI_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz2lMDxgbYjdQx_39sVjoOPLY_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzotzLth3XnnKr_0024TWFT_0024nXi8bHyYzBB6xpZFqPKVg_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Plane _0023_003DzW1yWXdAz5UJN6kjHWVWJ0mu0pf_0024XqXJ_3ZTEOtKodp4k;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ShaderParameters _0023_003Dzr4bvVQZYjdDH6CbnXLzl7Ak_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz_Am_0024q96pTyTzA_0024hCCGEKGDwVyp_vt21ihWDZrOw_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzyKKM9MCZNjydS43Acw2lmIW9erXTcRzdhNgywXY_003D;

	public selectionStatusType SelectionStatus;

	public RenderContextBase RenderContext;

	public int Bpp = 3;

	public IList<Entity> Entities
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzirHP2g6iDbM7YBocSw_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzirHP2g6iDbM7YBocSw_003D_003D = value;
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
		internal set
		{
			_0023_003DzF97WMq_0024wP8gY4FUd3g_003D_003D = value;
		}
	}

	public IWorkspace Workspace
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzCD7X4841bsdB_yy03g_003D_003D;
		}
	}

	internal IWorkspaceInternal workspaceInternal => (IWorkspaceInternal)Workspace;

	internal IViewportInternal viewportInternal => (IViewportInternal)_0023_003Dz3BW3eaE_003D;

	public IViewport Viewport
	{
		get
		{
			return _0023_003Dz3BW3eaE_003D;
		}
		set
		{
			_0023_003Dz3BW3eaE_003D = value;
			if (value != null)
			{
				_0023_003DzomTbHzy20T_0024O(viewportInternal.parent);
				UpdateViewFrame();
				isSketchActive = viewportInternal.parent is IDesign design && design.CurrentSketch != null;
			}
			else
			{
				_0023_003DzomTbHzy20T_0024O(null);
				_0023_003DzqlbijOf8URlt = null;
				isSketchActive = false;
			}
			_0023_003DzIX6n4Uk8NTDx();
		}
	}

	public int[] ViewFrame => _0023_003DzqlbijOf8URlt;

	public Size ViewportSize
	{
		get
		{
			if (!_0023_003DzsGcL5XEyZIot.IsEmpty)
			{
				return _0023_003DzsGcL5XEyZIot;
			}
			return Viewport.Size;
		}
		set
		{
			_0023_003DzsGcL5XEyZIot = value;
		}
	}

	internal bool DrawLegends
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzLgDwPvB_0024_ePvIHKwzSwjdV_44NwO;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzLgDwPvB_0024_ePvIHKwzSwjdV_44NwO = value;
		}
	}

	internal bool DrawLabels
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzsPFBIXN1SZKfmBB0EeqG8sk_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzsPFBIXN1SZKfmBB0EeqG8sk_003D = value;
		}
	}

	public CameraEyePosType CameraEyePos
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzWgjVai0Rqm3_0024X6Fl6gVJfQI_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzWgjVai0Rqm3_0024X6Fl6gVJfQI_003D = value;
		}
	}

	public bool DoShadows
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz2lMDxgbYjdQx_39sVjoOPLY_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz2lMDxgbYjdQx_39sVjoOPLY_003D = value;
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
		set
		{
			_0023_003DzotzLth3XnnKr_0024TWFT_0024nXi8bHyYzBB6xpZFqPKVg_003D = value;
		}
	}

	public Plane PlanarReflectionsPlane
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzW1yWXdAz5UJN6kjHWVWJ0mu0pf_0024XqXJ_3ZTEOtKodp4k;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzW1yWXdAz5UJN6kjHWVWJ0mu0pf_0024XqXJ_3ZTEOtKodp4k = value;
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

	public bool ObjectManipulatorDrawPreview
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz_Am_0024q96pTyTzA_0024hCCGEKGDwVyp_vt21ihWDZrOw_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz_Am_0024q96pTyTzA_0024hCCGEKGDwVyp_vt21ihWDZrOw_003D = value;
		}
	}

	public bool ShowObjectManipulatorPreviewInScene
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzyKKM9MCZNjydS43Acw2lmIW9erXTcRzdhNgywXY_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzyKKM9MCZNjydS43Acw2lmIW9erXTcRzdhNgywXY_003D = value;
		}
	}

	public DrawSceneParams()
	{
		DrawScale = 1f;
		LineWeightFactor = 1f;
		CameraEyePos = CameraEyePosType.Center;
		ViewportScaleRatio = 1f;
		SelectionStatus = selectionStatusType.Permanent;
	}

	private void _0023_003DzomTbHzy20T_0024O(IWorkspace _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzCD7X4841bsdB_yy03g_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	private void _0023_003DzIX6n4Uk8NTDx()
	{
		if (TransparentBackground())
		{
			Bpp = 4;
		}
		else
		{
			Bpp = 3;
		}
	}

	internal bool IsCurrentViewport()
	{
		return IsCurrentViewport(Workspace, Viewport);
	}

	internal static bool IsCurrentViewport(IWorkspace _0023_003DzImQx0os_003D, IViewport _0023_003DzqkfbPc0_003D)
	{
		return _0023_003DzqkfbPc0_003D == _0023_003DzImQx0os_003D.ActiveViewport;
	}

	public void UpdateViewFrame()
	{
		_0023_003DzqlbijOf8URlt = Viewport.GetViewFrame();
	}

	public bool TransparentBackground()
	{
		if (Viewport != null)
		{
			return Viewport.Background.StyleMode == backgroundStyleType.None;
		}
		return false;
	}
}
