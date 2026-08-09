using System.Collections.Generic;
using System.Drawing;
using devDept.Eyeshot.Entities;
using devDept.Graphics;

namespace devDept.Eyeshot;

public class DrawEntitiesParams
{
	internal delegate bool SetHiddenLinesAttributesFunc(DrawEntitiesParams myParams, out bool sel, ref Entity ent, bool drawOpaque);

	internal delegate void SetStates(shaderPrimitiveType primitiveType, DrawParams drawParams, Color color, string materialName, Color selectionColor, bool selected, bool internalSelection);

	internal bool isDrawingSketchEntities;

	public IWorkspace Workspace;

	public IList<Entity> entList;

	public bool simplify;

	internal bool isProgressiveDrawing;

	internal bool isDrawingDynamicWithHalo;

	internal bool isDrawingStaticWithHalo;

	internal bool selectionFound;

	internal bool shouldUseSeparateBuffers;

	internal bool drawFrozen;

	internal bool isDrawingWireframeEntities;

	internal bool wireframeEntityFound;

	public DrawParams DrawParams;

	public CompileParams CompileParamsForAttributes;

	public RegenParams RegenParamsForAttributes;

	internal WorkspaceDrawTransparentEntityDelegate drawFastTransparencyEntityCallBack;

	public bool drawZBufferOnly;

	public bool transparencyFound;

	public bool frozenFound;

	internal SetStates SetStatesFunc;

	internal bool UseMaterial;

	internal WorkspaceSetMatrixAndColorFunc SetMatrixAndColorForPolygons;

	internal WorkspaceSetMatrixAndColorFunc SetMatrixAndColorForText;

	internal WorkspaceSetMatrixAndColorFunc SetMatrixAndColorForWire;

	internal SetHiddenLinesAttributesFunc SetAttributesFunc;

	internal ShaderParameters ShaderParams;

	public bool SelectableOnly;

	internal WorkspaceDrawForSelectionEntityDelegate drawCallBack;

	internal bool InScope;

	internal bool SelectInScope;

	public ShadowMapData.GfxShadowParams gfxShadowParams;

	public LayerKeyedCollection layers;

	public BlockKeyedCollection Blocks;

	public Material defaultMaterial;

	public IBoundingBoxSettings boundingBox;

	public bool animating;

	internal bool isDrawingWithHalo
	{
		get
		{
			if (!isDrawingStaticWithHalo)
			{
				return isDrawingDynamicWithHalo;
			}
			return true;
		}
	}

	public DrawEntitiesParams(IWorkspace workspace, IList<Entity> entList, DrawParams drawParams, bool simplify)
		: this((IWorkspaceInternal)workspace, entList, drawParams, simplify)
	{
	}

	internal DrawEntitiesParams(IWorkspaceInternal _0023_003DzImQx0os_003D, IList<Entity> _0023_003DzWc9WmS8VMsuA, DrawParams _0023_003DzrFXPIITH9q61, bool _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D)
	{
		entList = _0023_003DzWc9WmS8VMsuA;
		simplify = _0023_003DzNp3M9yH4utwSByKM_0024w_003D_003D;
		DrawParams = _0023_003DzrFXPIITH9q61;
		RegenParamsForAttributes = new RegenParams(0.0, _0023_003DzImQx0os_003D.Document, _0023_003DzrFXPIITH9q61.Blocks);
		CompileParamsForAttributes = new CompileParams(_0023_003DzImQx0os_003D, _0023_003DzrFXPIITH9q61.Blocks);
		Workspace = _0023_003DzImQx0os_003D;
		DrawParams._0023_003Dz4M7aapi8f26U(_0023_003DzImQx0os_003D);
	}

	internal IWorkspaceInternal _0023_003DzHwUoFCUb88ry()
	{
		return (IWorkspaceInternal)Workspace;
	}

	internal void _0023_003DzOryvhzXb10Kb()
	{
		if (!InScope)
		{
			InScope = SelectedItemBase._0023_003DzPglMnmnGOjfR(DrawParams.Parents, _0023_003DzHwUoFCUb88ry().selectionScope);
		}
	}

	public int GetFirstShadowLight()
	{
		for (int i = 0; i < gfxShadowParams.activeLights.Length; i++)
		{
			if (gfxShadowParams.activeLights[i].YieldShadow && gfxShadowParams.activeLights[i].Type != lightType.Point)
			{
				return i;
			}
		}
		return -1;
	}
}
