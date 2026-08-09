using System;
using System.Diagnostics;
using System.Drawing;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.UIAutomation;
using devDept.Geometry;
using devDept.Graphics;

internal sealed class _0023_003DzzO4Z6lTYD_0024NCCyyJkZj4H4gV_yAeKNSUMQ_003D_003D : IDisposable
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Workspace _0023_003DzKG5_0024Fug_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly Design _0023_003DzFTkuCaE_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzSoymlAQxSqRBdRrPfw_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzWEZVRs4_003D;

	public _0023_003DzzO4Z6lTYD_0024NCCyyJkZj4H4gV_yAeKNSUMQ_003D_003D(Workspace _0023_003DzU0f5_qE_003D)
	{
		_0023_003DzKG5_0024Fug_003D = _0023_003DzU0f5_qE_003D;
		_0023_003DzKG5_0024Fug_003D.SelectionChanged += _0023_003DztTdMKuhs3p8H;
		_0023_003DzFTkuCaE_003D = _0023_003DzU0f5_qE_003D as Design;
	}

	public int _0023_003Dzbk5BdqldevpO()
	{
		return _0023_003DzSoymlAQxSqRBdRrPfw_003D_003D;
	}

	private void _0023_003DzePmT6HDfGszc(int _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzSoymlAQxSqRBdRrPfw_003D_003D = _0023_003DzsLHxXyo_003D;
	}

	private void _0023_003DztTdMKuhs3p8H(object _0023_003DzxwGby4M_003D, SelectionChangedEventArgs _0023_003Dz1SmHC4c_003D)
	{
		_0023_003DzePmT6HDfGszc(_0023_003Dzbk5BdqldevpO() + (_0023_003Dz1SmHC4c_003D.AddedItems.Count - _0023_003Dz1SmHC4c_003D.RemovedItems.Count));
	}

	public string _0023_003Dzt_0024trzXE_003D()
	{
		return _0023_003DzWEZVRs4_003D;
	}

	public void _0023_003DztWrPwvo_003D(string _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzWEZVRs4_003D = _0023_003DzsLHxXyo_003D;
		_0023_003Dz8RtH8f0_003D();
	}

	private void _0023_003Dz8RtH8f0_003D()
	{
		Enum.TryParse<Actions>(_0023_003DzWEZVRs4_003D, out var result);
		switch (result)
		{
		case Actions.GetDisplayMode:
			_0023_003DzWEZVRs4_003D = _0023_003DzKG5_0024Fug_003D._0023_003DzipBYly6zFKAp().DisplayMode.ToString();
			break;
		case Actions.SetDisplayModeRendered:
			_0023_003DzKG5_0024Fug_003D._0023_003DzipBYly6zFKAp().DisplayMode = displayType.Rendered;
			break;
		case Actions.SetDisplayModeWireframe:
			_0023_003DzKG5_0024Fug_003D._0023_003DzipBYly6zFKAp().DisplayMode = displayType.Wireframe;
			break;
		case Actions.SetDisplayModeFlat:
			_0023_003DzKG5_0024Fug_003D._0023_003DzipBYly6zFKAp().DisplayMode = displayType.Flat;
			break;
		case Actions.SetDisplayModeHiddenLines:
			_0023_003DzKG5_0024Fug_003D._0023_003DzipBYly6zFKAp().DisplayMode = displayType.HiddenLines;
			break;
		case Actions.SetDisplayModeShaded:
			_0023_003DzKG5_0024Fug_003D._0023_003DzipBYly6zFKAp().DisplayMode = displayType.Shaded;
			break;
		case Actions.GetShadowMode:
			switch (_0023_003DzKG5_0024Fug_003D._0023_003DzipBYly6zFKAp().DisplayMode)
			{
			case displayType.Rendered:
				_0023_003DzWEZVRs4_003D = _0023_003DzKG5_0024Fug_003D._0023_003DznKkOfo8_003D.ShadowMode.ToString();
				break;
			case displayType.Shaded:
				_0023_003DzWEZVRs4_003D = _0023_003DzKG5_0024Fug_003D._0023_003DzAv2OMNy7DJ5L.ShadowMode.ToString();
				break;
			default:
				_0023_003DzWEZVRs4_003D = shadowType.None.ToString();
				break;
			}
			break;
		case Actions.SetShadowModeRealistic:
			switch (_0023_003DzKG5_0024Fug_003D._0023_003DzipBYly6zFKAp().DisplayMode)
			{
			case displayType.Rendered:
				_0023_003DzKG5_0024Fug_003D._0023_003DznKkOfo8_003D.ShadowMode = shadowType.Realistic;
				break;
			case displayType.Shaded:
				_0023_003DzKG5_0024Fug_003D._0023_003DzAv2OMNy7DJ5L.ShadowMode = shadowType.Realistic;
				break;
			}
			break;
		case Actions.SetShadowModePlanar:
			switch (_0023_003DzKG5_0024Fug_003D._0023_003DzipBYly6zFKAp().DisplayMode)
			{
			case displayType.Rendered:
				_0023_003DzKG5_0024Fug_003D._0023_003DznKkOfo8_003D.ShadowMode = shadowType.Planar;
				break;
			case displayType.Shaded:
				_0023_003DzKG5_0024Fug_003D._0023_003DzAv2OMNy7DJ5L.ShadowMode = shadowType.Planar;
				break;
			}
			break;
		case Actions.SetShadowModeNone:
			switch (_0023_003DzKG5_0024Fug_003D._0023_003DzipBYly6zFKAp().DisplayMode)
			{
			case displayType.Rendered:
				_0023_003DzKG5_0024Fug_003D._0023_003DznKkOfo8_003D.ShadowMode = shadowType.None;
				break;
			case displayType.Shaded:
				_0023_003DzKG5_0024Fug_003D._0023_003DzAv2OMNy7DJ5L.ShadowMode = shadowType.None;
				break;
			}
			break;
		case Actions.GetSilhouettesDrawingMode:
			switch (_0023_003DzKG5_0024Fug_003D._0023_003DzipBYly6zFKAp().DisplayMode)
			{
			case displayType.Wireframe:
				_0023_003DzWEZVRs4_003D = _0023_003DzKG5_0024Fug_003D._0023_003DzAdpXPj_0024l7nqBsSXydw_003D_003D.SilhouettesDrawingMode.ToString();
				break;
			case displayType.Flat:
				_0023_003DzWEZVRs4_003D = _0023_003DzKG5_0024Fug_003D._0023_003Dzipe8ch4_003D.SilhouettesDrawingMode.ToString();
				break;
			case displayType.HiddenLines:
				_0023_003DzWEZVRs4_003D = _0023_003DzKG5_0024Fug_003D._0023_003DzP6FAuV4Dwq24.SilhouettesDrawingMode.ToString();
				break;
			case displayType.Shaded:
				_0023_003DzWEZVRs4_003D = _0023_003DzKG5_0024Fug_003D._0023_003DzAv2OMNy7DJ5L.SilhouettesDrawingMode.ToString();
				break;
			case displayType.Rendered:
				_0023_003DzWEZVRs4_003D = _0023_003DzKG5_0024Fug_003D._0023_003DznKkOfo8_003D.SilhouettesDrawingMode.ToString();
				break;
			}
			break;
		case Actions.SetSilhouettesDrawingModeNever:
		case Actions.SetSilhouettesDrawingModeAlways:
		case Actions.SetSilhouettesDrawingModeLastFrame:
		case Actions.SetSilhouettesDrawingModeImageBased:
		{
			silhouettesDrawingType silhouettesDrawingMode = silhouettesDrawingType.LastFrame;
			switch (result)
			{
			case Actions.SetSilhouettesDrawingModeNever:
				silhouettesDrawingMode = silhouettesDrawingType.Never;
				break;
			case Actions.SetSilhouettesDrawingModeAlways:
				silhouettesDrawingMode = silhouettesDrawingType.Always;
				break;
			case Actions.SetSilhouettesDrawingModeLastFrame:
				silhouettesDrawingMode = silhouettesDrawingType.LastFrame;
				break;
			case Actions.SetSilhouettesDrawingModeImageBased:
				silhouettesDrawingMode = silhouettesDrawingType.ImageBased;
				break;
			}
			switch (_0023_003DzKG5_0024Fug_003D._0023_003DzipBYly6zFKAp().DisplayMode)
			{
			case displayType.Wireframe:
				_0023_003DzKG5_0024Fug_003D._0023_003DzAdpXPj_0024l7nqBsSXydw_003D_003D.SilhouettesDrawingMode = silhouettesDrawingMode;
				break;
			case displayType.Flat:
				_0023_003DzKG5_0024Fug_003D._0023_003Dzipe8ch4_003D.SilhouettesDrawingMode = silhouettesDrawingMode;
				break;
			case displayType.HiddenLines:
				_0023_003DzKG5_0024Fug_003D._0023_003DzP6FAuV4Dwq24.SilhouettesDrawingMode = silhouettesDrawingMode;
				break;
			case displayType.Shaded:
				_0023_003DzKG5_0024Fug_003D._0023_003DzAv2OMNy7DJ5L.SilhouettesDrawingMode = silhouettesDrawingMode;
				break;
			case displayType.Rendered:
				_0023_003DzKG5_0024Fug_003D._0023_003DznKkOfo8_003D.SilhouettesDrawingMode = silhouettesDrawingMode;
				break;
			}
			break;
		}
		case Actions.EnableAmbientOcclusion:
			_0023_003DzKG5_0024Fug_003D.AmbientOcclusion.Enabled = true;
			break;
		case Actions.DisableAmbientOcclusion:
			_0023_003DzKG5_0024Fug_003D.AmbientOcclusion.Enabled = false;
			break;
		case Actions.GetActionMode:
			_0023_003DzWEZVRs4_003D = _0023_003DzKG5_0024Fug_003D.ActionMode.ToString();
			break;
		case Actions.SetActionModeNone:
			_0023_003DzKG5_0024Fug_003D.ActionMode = actionType.None;
			break;
		case Actions.SetActionModeZoom:
			_0023_003DzKG5_0024Fug_003D.ActionMode = actionType.Zoom;
			break;
		case Actions.SetActionModePan:
			_0023_003DzKG5_0024Fug_003D.ActionMode = actionType.Pan;
			break;
		case Actions.SetActionModeRotate:
			_0023_003DzKG5_0024Fug_003D.ActionMode = actionType.Rotate;
			break;
		case Actions.SetActionModeZoomWindow:
			_0023_003DzKG5_0024Fug_003D.ActionMode = actionType.ZoomWindow;
			break;
		case Actions.SetActionModeMagnifyingGlass:
			_0023_003DzKG5_0024Fug_003D.ActionMode = actionType.MagnifyingGlass;
			break;
		case Actions.SetActionModeSelectByPick:
			_0023_003DzKG5_0024Fug_003D.ActionMode = actionType.SelectByPick;
			break;
		case Actions.SetActionModeSelectByBox:
			_0023_003DzKG5_0024Fug_003D.ActionMode = actionType.SelectByBox;
			break;
		case Actions.SetActionModeSelectByPolygon:
			_0023_003DzKG5_0024Fug_003D.ActionMode = actionType.SelectByPolygon;
			break;
		case Actions.SetActionModeSelectVisibleByPick:
			_0023_003DzKG5_0024Fug_003D.ActionMode = actionType.SelectVisibleByPick;
			break;
		case Actions.SetActionModeSelectVisibleByPickDynamic:
			_0023_003DzKG5_0024Fug_003D.ActionMode = actionType.SelectVisibleByPickDynamic;
			break;
		case Actions.SetActionModeSelectVisibleByBox:
			_0023_003DzKG5_0024Fug_003D.ActionMode = actionType.SelectVisibleByBox;
			break;
		case Actions.SetActionModeSelectVisibleByPolygon:
			_0023_003DzKG5_0024Fug_003D.ActionMode = actionType.SelectVisibleByPolygon;
			break;
		case Actions.SetActionModeSelectByBoxEnclosed:
			_0023_003DzKG5_0024Fug_003D.ActionMode = actionType.SelectByBoxEnclosed;
			break;
		case Actions.SetActionModeSelectByPolygonEnclosed:
			_0023_003DzKG5_0024Fug_003D.ActionMode = actionType.SelectByPolygonEnclosed;
			break;
		case Actions.SetActionModeSelectVisibleByPickLabel:
			_0023_003DzKG5_0024Fug_003D.ActionMode = actionType.SelectVisibleByPickLabel;
			break;
		case Actions.GetSelectionFilterMode:
			_0023_003DzWEZVRs4_003D = _0023_003DzKG5_0024Fug_003D._0023_003Dz28QCun7pbbWH.ToString();
			break;
		case Actions.SetSelectionFilterTypeEntity:
			_0023_003DzKG5_0024Fug_003D._0023_003Dz28QCun7pbbWH = selectionFilterType.Entity;
			break;
		case Actions.SetSelectionFilterTypeVertex:
			_0023_003DzKG5_0024Fug_003D._0023_003Dz28QCun7pbbWH = selectionFilterType.Vertex;
			break;
		case Actions.SetSelectionFilterTypeEdge:
			_0023_003DzKG5_0024Fug_003D._0023_003Dz28QCun7pbbWH = selectionFilterType.Edge;
			break;
		case Actions.SetSelectionFilterTypeFace:
			_0023_003DzKG5_0024Fug_003D._0023_003Dz28QCun7pbbWH = selectionFilterType.Face;
			break;
		case Actions.SetSelectionFilterTypeVertexFace:
			_0023_003DzKG5_0024Fug_003D._0023_003Dz28QCun7pbbWH = selectionFilterType.Vertex | selectionFilterType.Face;
			break;
		case Actions.SetSelectionFilterTypeVertexEdge:
			_0023_003DzKG5_0024Fug_003D._0023_003Dz28QCun7pbbWH = selectionFilterType.Vertex | selectionFilterType.Edge;
			break;
		case Actions.SetSelectionFilterTypeEdgeFace:
			_0023_003DzKG5_0024Fug_003D._0023_003Dz28QCun7pbbWH = selectionFilterType.Edge | selectionFilterType.Face;
			break;
		case Actions.SetSelectionFilterTypeVertexEdgeFace:
			_0023_003DzKG5_0024Fug_003D._0023_003Dz28QCun7pbbWH = selectionFilterType.Vertex | selectionFilterType.Edge | selectionFilterType.Face;
			break;
		case Actions.SetSelectionFilterSubCurve:
			_0023_003DzKG5_0024Fug_003D._0023_003Dz28QCun7pbbWH = selectionFilterType.SubCurve;
			break;
		case Actions.SetSelectionFilterContour:
			_0023_003DzKG5_0024Fug_003D._0023_003Dz28QCun7pbbWH = selectionFilterType.Contour;
			break;
		case Actions.SetSelectionFilterSketchPoint:
			_0023_003DzKG5_0024Fug_003D._0023_003Dz28QCun7pbbWH = selectionFilterType.SketchPoint;
			break;
		case Actions.SetSelectionFilterSketchCurves:
			_0023_003DzKG5_0024Fug_003D._0023_003Dz28QCun7pbbWH = selectionFilterType.SketchCurve;
			break;
		case Actions.SetSelectionFilterSketchPointAndCurves:
			_0023_003DzKG5_0024Fug_003D._0023_003Dz28QCun7pbbWH = selectionFilterType.SketchPoint | selectionFilterType.SketchCurve;
			break;
		case Actions.GetMultipleSelection:
			_0023_003DzWEZVRs4_003D = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589094) + (_0023_003DzKG5_0024Fug_003D.MultipleSelection ? _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589121) : _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589131));
			break;
		case Actions.SetMultipleSelectionOn:
			_0023_003DzKG5_0024Fug_003D.MultipleSelection = true;
			break;
		case Actions.SetMultipleSelectionOff:
			_0023_003DzKG5_0024Fug_003D.MultipleSelection = false;
			break;
		case Actions.GetAssemblySelectionMode:
			_0023_003DzWEZVRs4_003D = _0023_003DzKG5_0024Fug_003D._0023_003DznugYzyWkU3Do.ToString();
			break;
		case Actions.SetAssemblySelectionModeLeaf:
			_0023_003DzKG5_0024Fug_003D._0023_003DznugYzyWkU3Do = Workspace.assemblySelectionType.Leaf;
			break;
		case Actions.SetAssemblySelectionModeBranch:
			_0023_003DzKG5_0024Fug_003D._0023_003DznugYzyWkU3Do = Workspace.assemblySelectionType.Branch;
			break;
		case Actions.GetLayoutMode:
			_0023_003DzWEZVRs4_003D = ((_0023_003DzFTkuCaE_003D != null) ? _0023_003DzFTkuCaE_003D.LayoutMode.ToString() : viewportLayoutType.SingleViewport.ToString());
			break;
		case Actions.SetLayoutModeSingleViewport:
			if (_0023_003DzFTkuCaE_003D != null)
			{
				_0023_003DzipYjlDuekE5SXqPamVfYpy4_003D(_0023_003DzFTkuCaE_003D, viewportLayoutType.SingleViewport);
			}
			break;
		case Actions.SetLayoutModeTwoViewportsVertical:
			if (_0023_003DzFTkuCaE_003D != null)
			{
				_0023_003DzipYjlDuekE5SXqPamVfYpy4_003D(_0023_003DzFTkuCaE_003D, viewportLayoutType.TwoViewportsVertical);
			}
			break;
		case Actions.SetLayoutModeTwoViewportsHorizontal:
			if (_0023_003DzFTkuCaE_003D != null)
			{
				_0023_003DzipYjlDuekE5SXqPamVfYpy4_003D(_0023_003DzFTkuCaE_003D, viewportLayoutType.TwoViewportsHorizontal);
			}
			break;
		case Actions.SetLayoutModeThreeViewportsWithOneOnLeft:
			if (_0023_003DzFTkuCaE_003D != null)
			{
				_0023_003DzipYjlDuekE5SXqPamVfYpy4_003D(_0023_003DzFTkuCaE_003D, viewportLayoutType.ThreeViewportsWithOneOnLeft);
			}
			break;
		case Actions.SetLayoutModeThreeViewportsWithOneOnTop:
			if (_0023_003DzFTkuCaE_003D != null)
			{
				_0023_003DzipYjlDuekE5SXqPamVfYpy4_003D(_0023_003DzFTkuCaE_003D, viewportLayoutType.ThreeViewportsWithOneOnTop);
			}
			break;
		case Actions.SetLayoutModeThreeViewportsWithOneOnRight:
			if (_0023_003DzFTkuCaE_003D != null)
			{
				_0023_003DzipYjlDuekE5SXqPamVfYpy4_003D(_0023_003DzFTkuCaE_003D, viewportLayoutType.ThreeViewportsWithOneOnRight);
			}
			break;
		case Actions.SetLayoutModeThreeViewportsWithOneOnBottom:
			if (_0023_003DzFTkuCaE_003D != null)
			{
				_0023_003DzipYjlDuekE5SXqPamVfYpy4_003D(_0023_003DzFTkuCaE_003D, viewportLayoutType.ThreeViewportsWithOneOnBottom);
			}
			break;
		case Actions.SetLayoutModeFourViewports:
			if (_0023_003DzFTkuCaE_003D != null)
			{
				_0023_003DzipYjlDuekE5SXqPamVfYpy4_003D(_0023_003DzFTkuCaE_003D, viewportLayoutType.FourViewports);
			}
			break;
		case Actions.SetLayoutModeStacked:
			if (_0023_003DzFTkuCaE_003D != null)
			{
				_0023_003DzipYjlDuekE5SXqPamVfYpy4_003D(_0023_003DzFTkuCaE_003D, viewportLayoutType.Stacked);
			}
			break;
		case Actions.GetCameraProjectionMode:
			_0023_003DzWEZVRs4_003D = _0023_003DzKG5_0024Fug_003D._0023_003DzipBYly6zFKAp().Camera.ProjectionMode.ToString();
			break;
		case Actions.SetCameraProjectionModeOrthographic:
			_0023_003DzKG5_0024Fug_003D._0023_003DzipBYly6zFKAp().Camera.ProjectionMode = projectionType.Orthographic;
			break;
		case Actions.SetCameraProjectionModePerspective:
			_0023_003DzKG5_0024Fug_003D._0023_003DzipBYly6zFKAp().Camera.ProjectionMode = projectionType.Perspective;
			break;
		case Actions.AdjustNearAndFarPlanes:
			_0023_003DzKG5_0024Fug_003D.AdjustNearAndFarPlanes();
			break;
		case Actions.ZoomFit:
			_0023_003DzKG5_0024Fug_003D.ZoomFit();
			break;
		case Actions.ObjectManipulatorEnable:
			_0023_003DzFTkuCaE_003D?.ObjectManipulator.Enable(new Identity(), centerOnEntities: true);
			break;
		case Actions.ObjectManipulatorApply:
			_0023_003DzFTkuCaE_003D?.ObjectManipulator.Apply();
			break;
		case Actions.ObjectManipulatorCancel:
			_0023_003DzFTkuCaE_003D?.ObjectManipulator.Cancel();
			break;
		case Actions.ObjectManipulatorShowTransformationLabelTrue:
			_0023_003DzFTkuCaE_003D.ObjectManipulator.ShowTransformationLabel = true;
			break;
		case Actions.ObjectManipulatorShowTransformationLabelFalse:
			_0023_003DzFTkuCaE_003D.ObjectManipulator.ShowTransformationLabel = false;
			break;
		case Actions.ObjectManipulatorShowDraggedItemOnlyTrue:
			_0023_003DzFTkuCaE_003D.ObjectManipulator.ShowDraggedItemOnly = true;
			break;
		case Actions.ObjectManipulatorShowDraggedItemOnlyFalse:
			_0023_003DzFTkuCaE_003D.ObjectManipulator.ShowDraggedItemOnly = false;
			break;
		case Actions.ObjectManipulatorShowOriginalWhileEditingTrue:
			_0023_003DzFTkuCaE_003D.ObjectManipulator.ShowOriginalWhileEditing = true;
			break;
		case Actions.ObjectManipulatorShowOriginalWhileEditingFalse:
			_0023_003DzFTkuCaE_003D.ObjectManipulator.ShowOriginalWhileEditing = false;
			break;
		case Actions.ObjectManipulatorBallActionModeTranslate:
			_0023_003DzFTkuCaE_003D.ObjectManipulator.BallActionMode = ObjectManipulator.ballActionType.Translate;
			break;
		case Actions.ObjectManipulatorBallActionModeRotate:
			_0023_003DzFTkuCaE_003D.ObjectManipulator.BallActionMode = ObjectManipulator.ballActionType.Rotate;
			break;
		case Actions.ObjectManipulatorBallActionModeScale:
			_0023_003DzFTkuCaE_003D.ObjectManipulator.BallActionMode = ObjectManipulator.ballActionType.Scale;
			break;
		case Actions.ObjectManipulatorTranslateVisibleTrue:
			_0023_003DzFTkuCaE_003D.ObjectManipulator.TranslateX.Visible = true;
			_0023_003DzFTkuCaE_003D.ObjectManipulator.TranslateY.Visible = true;
			_0023_003DzFTkuCaE_003D.ObjectManipulator.TranslateZ.Visible = true;
			break;
		case Actions.ObjectManipulatorTranslateVisibleFalse:
			_0023_003DzFTkuCaE_003D.ObjectManipulator.TranslateX.Visible = false;
			_0023_003DzFTkuCaE_003D.ObjectManipulator.TranslateY.Visible = false;
			_0023_003DzFTkuCaE_003D.ObjectManipulator.TranslateZ.Visible = false;
			break;
		case Actions.ObjectManipulatorRotateVisibleTrue:
			_0023_003DzFTkuCaE_003D.ObjectManipulator.RotateX.Visible = true;
			_0023_003DzFTkuCaE_003D.ObjectManipulator.RotateY.Visible = true;
			_0023_003DzFTkuCaE_003D.ObjectManipulator.RotateZ.Visible = true;
			break;
		case Actions.ObjectManipulatorRotateVisibleFalse:
			_0023_003DzFTkuCaE_003D.ObjectManipulator.RotateX.Visible = false;
			_0023_003DzFTkuCaE_003D.ObjectManipulator.RotateY.Visible = false;
			_0023_003DzFTkuCaE_003D.ObjectManipulator.RotateZ.Visible = false;
			break;
		case Actions.ObjectManipulatorScaleVisibleTrue:
			_0023_003DzFTkuCaE_003D.ObjectManipulator.ScaleX.Visible = true;
			_0023_003DzFTkuCaE_003D.ObjectManipulator.ScaleY.Visible = true;
			_0023_003DzFTkuCaE_003D.ObjectManipulator.ScaleZ.Visible = true;
			break;
		case Actions.ObjectManipulatorScaleVisibleFalse:
			_0023_003DzFTkuCaE_003D.ObjectManipulator.ScaleX.Visible = false;
			_0023_003DzFTkuCaE_003D.ObjectManipulator.ScaleY.Visible = false;
			_0023_003DzFTkuCaE_003D.ObjectManipulator.ScaleZ.Visible = false;
			break;
		case Actions.ObjectManipulatorSetStyleModeStandard:
			_0023_003DzFTkuCaE_003D.ObjectManipulator.StyleMode = ObjectManipulator.styleType.Standard;
			break;
		case Actions.ObjectManipulatorSetStyleModeRings:
			_0023_003DzFTkuCaE_003D.ObjectManipulator.StyleMode = ObjectManipulator.styleType.Rings;
			break;
		case Actions.ObjectManipulatorSetStyleModeLarge:
			_0023_003DzFTkuCaE_003D.ObjectManipulator.StyleMode = ObjectManipulator.styleType.Large;
			break;
		case Actions.ClippingPlane1Edit:
			_0023_003DzFTkuCaE_003D?.ClippingPlane1.Edit(null);
			break;
		case Actions.ClippingPlane1Apply:
			_0023_003DzFTkuCaE_003D?.ClippingPlane1.Apply();
			break;
		case Actions.ClippingPlane1Cancel:
			_0023_003DzFTkuCaE_003D?.ClippingPlane1.Cancel();
			break;
		case Actions.ClippingPlane1CappingTrue:
			if (_0023_003DzFTkuCaE_003D != null)
			{
				_0023_003DzFTkuCaE_003D.ClippingPlane1.CappingMode = ClippingPlane.cappingType.SingleColor;
			}
			break;
		case Actions.ClippingPlane1CappingFalse:
			if (_0023_003DzFTkuCaE_003D != null)
			{
				_0023_003DzFTkuCaE_003D.ClippingPlane1.CappingMode = ClippingPlane.cappingType.None;
			}
			break;
		case Actions.ClippingPlane1ShowPlaneTrue:
			if (_0023_003DzFTkuCaE_003D != null)
			{
				_0023_003DzFTkuCaE_003D.ClippingPlane1.ShowPlane = true;
			}
			break;
		case Actions.ClippingPlane1ShowPlaneFalse:
			if (_0023_003DzFTkuCaE_003D != null)
			{
				_0023_003DzFTkuCaE_003D.ClippingPlane1.ShowPlane = false;
			}
			break;
		case Actions.ClippingPlane2Edit:
			_0023_003DzFTkuCaE_003D?.ClippingPlane2.Edit(null);
			break;
		case Actions.ClippingPlane2Apply:
			_0023_003DzFTkuCaE_003D?.ClippingPlane2.Apply();
			break;
		case Actions.ClippingPlane2Cancel:
			_0023_003DzFTkuCaE_003D?.ClippingPlane2.Cancel();
			break;
		case Actions.ClippingPlane2CappingTrue:
			if (_0023_003DzFTkuCaE_003D != null)
			{
				_0023_003DzFTkuCaE_003D.ClippingPlane2.CappingMode = ClippingPlane.cappingType.SingleColor;
			}
			break;
		case Actions.ClippingPlane2CappingFalse:
			if (_0023_003DzFTkuCaE_003D != null)
			{
				_0023_003DzFTkuCaE_003D.ClippingPlane2.CappingMode = ClippingPlane.cappingType.None;
			}
			break;
		case Actions.ClippingPlane2ShowPlaneTrue:
			if (_0023_003DzFTkuCaE_003D != null)
			{
				_0023_003DzFTkuCaE_003D.ClippingPlane2.ShowPlane = true;
			}
			break;
		case Actions.ClippingPlane2ShowPlaneFalse:
			if (_0023_003DzFTkuCaE_003D != null)
			{
				_0023_003DzFTkuCaE_003D.ClippingPlane2.ShowPlane = false;
			}
			break;
		case Actions.ClippingPlane3Edit:
			_0023_003DzFTkuCaE_003D?.ClippingPlane3.Edit(null);
			break;
		case Actions.ClippingPlane3Apply:
			_0023_003DzFTkuCaE_003D?.ClippingPlane3.Apply();
			break;
		case Actions.ClippingPlane3Cancel:
			_0023_003DzFTkuCaE_003D?.ClippingPlane3.Cancel();
			break;
		case Actions.ClippingPlane3CappingTrue:
			if (_0023_003DzFTkuCaE_003D != null)
			{
				_0023_003DzFTkuCaE_003D.ClippingPlane3.CappingMode = ClippingPlane.cappingType.SingleColor;
			}
			break;
		case Actions.ClippingPlane3CappingFalse:
			if (_0023_003DzFTkuCaE_003D != null)
			{
				_0023_003DzFTkuCaE_003D.ClippingPlane3.CappingMode = ClippingPlane.cappingType.None;
			}
			break;
		case Actions.ClippingPlane3ShowPlaneTrue:
			if (_0023_003DzFTkuCaE_003D != null)
			{
				_0023_003DzFTkuCaE_003D.ClippingPlane3.ShowPlane = true;
			}
			break;
		case Actions.ClippingPlane3ShowPlaneFalse:
			if (_0023_003DzFTkuCaE_003D != null)
			{
				_0023_003DzFTkuCaE_003D.ClippingPlane3.ShowPlane = false;
			}
			break;
		case Actions.ClippingPlane4Edit:
			_0023_003DzFTkuCaE_003D?.ClippingPlane4.Edit(null);
			break;
		case Actions.ClippingPlane4Apply:
			_0023_003DzFTkuCaE_003D?.ClippingPlane4.Apply();
			break;
		case Actions.ClippingPlane4Cancel:
			_0023_003DzFTkuCaE_003D?.ClippingPlane4.Cancel();
			break;
		case Actions.ClippingPlane4CappingTrue:
			if (_0023_003DzFTkuCaE_003D != null)
			{
				_0023_003DzFTkuCaE_003D.ClippingPlane4.CappingMode = ClippingPlane.cappingType.SingleColor;
			}
			break;
		case Actions.ClippingPlane4CappingFalse:
			if (_0023_003DzFTkuCaE_003D != null)
			{
				_0023_003DzFTkuCaE_003D.ClippingPlane4.CappingMode = ClippingPlane.cappingType.None;
			}
			break;
		case Actions.ClippingPlane4ShowPlaneTrue:
			if (_0023_003DzFTkuCaE_003D != null)
			{
				_0023_003DzFTkuCaE_003D.ClippingPlane4.ShowPlane = true;
			}
			break;
		case Actions.ClippingPlane4ShowPlaneFalse:
			if (_0023_003DzFTkuCaE_003D != null)
			{
				_0023_003DzFTkuCaE_003D.ClippingPlane4.ShowPlane = false;
			}
			break;
		case Actions.ClippingPlane5Edit:
			_0023_003DzFTkuCaE_003D?.ClippingPlane5.Edit(null);
			break;
		case Actions.ClippingPlane5Apply:
			_0023_003DzFTkuCaE_003D?.ClippingPlane5.Apply();
			break;
		case Actions.ClippingPlane5Cancel:
			_0023_003DzFTkuCaE_003D?.ClippingPlane5.Cancel();
			break;
		case Actions.ClippingPlane5CappingTrue:
			if (_0023_003DzFTkuCaE_003D != null)
			{
				_0023_003DzFTkuCaE_003D.ClippingPlane5.CappingMode = ClippingPlane.cappingType.SingleColor;
			}
			break;
		case Actions.ClippingPlane5CappingFalse:
			if (_0023_003DzFTkuCaE_003D != null)
			{
				_0023_003DzFTkuCaE_003D.ClippingPlane5.CappingMode = ClippingPlane.cappingType.None;
			}
			break;
		case Actions.ClippingPlane5ShowPlaneTrue:
			if (_0023_003DzFTkuCaE_003D != null)
			{
				_0023_003DzFTkuCaE_003D.ClippingPlane5.ShowPlane = true;
			}
			break;
		case Actions.ClippingPlane5ShowPlaneFalse:
			if (_0023_003DzFTkuCaE_003D != null)
			{
				_0023_003DzFTkuCaE_003D.ClippingPlane5.ShowPlane = false;
			}
			break;
		case Actions.ClippingPlane6Edit:
			_0023_003DzFTkuCaE_003D?.ClippingPlane6.Edit(null);
			break;
		case Actions.ClippingPlane6Apply:
			_0023_003DzFTkuCaE_003D?.ClippingPlane6.Apply();
			break;
		case Actions.ClippingPlane6Cancel:
			_0023_003DzFTkuCaE_003D?.ClippingPlane6.Cancel();
			break;
		case Actions.ClippingPlane6CappingTrue:
			if (_0023_003DzFTkuCaE_003D != null)
			{
				_0023_003DzFTkuCaE_003D.ClippingPlane6.CappingMode = ClippingPlane.cappingType.SingleColor;
			}
			break;
		case Actions.ClippingPlane6CappingFalse:
			if (_0023_003DzFTkuCaE_003D != null)
			{
				_0023_003DzFTkuCaE_003D.ClippingPlane6.CappingMode = ClippingPlane.cappingType.None;
			}
			break;
		case Actions.ClippingPlane6ShowPlaneTrue:
			if (_0023_003DzFTkuCaE_003D != null)
			{
				_0023_003DzFTkuCaE_003D.ClippingPlane6.ShowPlane = true;
			}
			break;
		case Actions.ClippingPlane6ShowPlaneFalse:
			if (_0023_003DzFTkuCaE_003D != null)
			{
				_0023_003DzFTkuCaE_003D.ClippingPlane6.ShowPlane = false;
			}
			break;
		case Actions.GetEntitiesCount:
			_0023_003DzWEZVRs4_003D = _0023_003DzKG5_0024Fug_003D.Entities.Count.ToString();
			break;
		case Actions.GetSelectedEntitiesCount:
			_0023_003DzWEZVRs4_003D = _0023_003Dzbk5BdqldevpO().ToString();
			break;
		case Actions.ClearSelectedEntities:
			_0023_003DzKG5_0024Fug_003D.Entities.ClearSelection();
			break;
		case Actions.SetViewCubeIconVisibleTrue:
			_0023_003DzKG5_0024Fug_003D._0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D[0].ViewCubeIcon.Visible = true;
			break;
		case Actions.SetViewCubeIconVisibleFalse:
			_0023_003DzKG5_0024Fug_003D._0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D[0].ViewCubeIcon.Visible = false;
			break;
		case Actions.SetToolBarVisibleTrue:
			_0023_003DzKG5_0024Fug_003D._0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D[0].ToolBars[0].Visible = true;
			break;
		case Actions.SetToolBarVisibleFalse:
			_0023_003DzKG5_0024Fug_003D._0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D[0].ToolBars[0].Visible = false;
			break;
		case Actions.SetToolBarsVisibleTrue:
		{
			ToolBar[] toolBars = _0023_003DzKG5_0024Fug_003D._0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D[0].ToolBars;
			for (int i = 0; i < toolBars.Length; i++)
			{
				toolBars[i].Visible = true;
			}
			break;
		}
		case Actions.SetToolBarsVisibleFalse:
		{
			ToolBar[] toolBars = _0023_003DzKG5_0024Fug_003D._0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D[0].ToolBars;
			for (int i = 0; i < toolBars.Length; i++)
			{
				toolBars[i].Visible = false;
			}
			break;
		}
		case Actions.SetCoordinateSystemIconVisibleTrue:
			if (_0023_003DzFTkuCaE_003D != null)
			{
				_0023_003DzFTkuCaE_003D.Viewports[0].CoordinateSystemIcon.Visible = true;
			}
			break;
		case Actions.SetCoordinateSystemIconVisibleFalse:
			if (_0023_003DzFTkuCaE_003D != null)
			{
				_0023_003DzFTkuCaE_003D.Viewports[0].CoordinateSystemIcon.Visible = false;
			}
			break;
		case Actions.SetOriginSymbolVisibleTrue:
			if (_0023_003DzFTkuCaE_003D != null)
			{
				_0023_003DzFTkuCaE_003D.Viewports[0].OriginSymbol.Visible = true;
			}
			break;
		case Actions.SetOriginSymbolVisibleFalse:
			if (_0023_003DzFTkuCaE_003D != null)
			{
				_0023_003DzFTkuCaE_003D.Viewports[0].OriginSymbol.Visible = false;
			}
			break;
		case Actions.SetGridVisibleTrue:
			if (_0023_003DzFTkuCaE_003D != null)
			{
				_0023_003DzFTkuCaE_003D.Viewports[0].Grid.Visible = true;
			}
			break;
		case Actions.SetGridVisibleFalse:
			if (_0023_003DzFTkuCaE_003D != null)
			{
				_0023_003DzFTkuCaE_003D.Viewports[0].Grid.Visible = false;
			}
			break;
		case Actions.SetGridsVisibleTrue:
			if (_0023_003DzFTkuCaE_003D != null)
			{
				Grid[] grids = _0023_003DzFTkuCaE_003D.Viewports[0].Grids;
				for (int i = 0; i < grids.Length; i++)
				{
					grids[i].Visible = true;
				}
			}
			break;
		case Actions.SetGridsVisibleFalse:
			if (_0023_003DzFTkuCaE_003D != null)
			{
				Grid[] grids = _0023_003DzFTkuCaE_003D.Viewports[0].Grids;
				for (int i = 0; i < grids.Length; i++)
				{
					grids[i].Visible = false;
				}
			}
			break;
		case Actions.ShowAllUIElements:
		case Actions.HideAllUIElements:
		{
			bool visible = result == Actions.ShowAllUIElements;
			_0023_003DzKG5_0024Fug_003D._0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D[0].ViewCubeIcon.Visible = visible;
			ToolBar[] toolBars = _0023_003DzKG5_0024Fug_003D._0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D[0].ToolBars;
			for (int i = 0; i < toolBars.Length; i++)
			{
				toolBars[i].Visible = visible;
			}
			if (_0023_003DzFTkuCaE_003D != null)
			{
				_0023_003DzFTkuCaE_003D.Viewports[0].CoordinateSystemIcon.Visible = visible;
				_0023_003DzFTkuCaE_003D.Viewports[0].OriginSymbol.Visible = visible;
				Grid[] grids = _0023_003DzFTkuCaE_003D.Viewports[0].Grids;
				for (int i = 0; i < grids.Length; i++)
				{
					grids[i].Visible = visible;
				}
			}
			break;
		}
		case Actions.Invalidate:
			_0023_003DzKG5_0024Fug_003D.Invalidate();
			break;
		case Actions.Refresh:
			_0023_003DzKG5_0024Fug_003D.Refresh();
			break;
		case Actions.Regen:
			_0023_003DzKG5_0024Fug_003D.Entities.Regen();
			break;
		case Actions.CompileUserInterfaceElements:
			_0023_003DzKG5_0024Fug_003D.CompileUserInterfaceElements();
			break;
		case Actions.UpdateViewportsSizeAndLocation:
			_0023_003DzFTkuCaE_003D?.UpdateViewportsSizeAndLocation();
			break;
		case Actions.SetSelectionColorDynamic0xFFFF4500:
			_0023_003DzKG5_0024Fug_003D.Selection.ColorDynamic = Color.FromArgb(255, Color.OrangeRed);
			break;
		case Actions.SetSelectionColorDynamic0x50FF4500:
			_0023_003DzKG5_0024Fug_003D.Selection.ColorDynamic = Color.FromArgb(80, Color.OrangeRed);
			break;
		case Actions.GetSelectionColorDynamic:
			_0023_003DzWEZVRs4_003D = _0023_003DzKG5_0024Fug_003D.Selection.ColorDynamic.ToArgb().ToString(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589185));
			break;
		case Actions.SetSelectionColor0xFFFFD700:
			_0023_003DzKG5_0024Fug_003D.Selection.Color = Color.FromArgb(255, Color.Gold);
			break;
		case Actions.SetSelectionColor0x50FFD700:
			_0023_003DzKG5_0024Fug_003D.Selection.Color = Color.FromArgb(80, Color.Gold);
			break;
		case Actions.GetSelectionColor:
			_0023_003DzWEZVRs4_003D = _0023_003DzKG5_0024Fug_003D.Selection.Color.ToArgb().ToString(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589185));
			break;
		case Actions.GetCurrentBlockName:
			_0023_003DzWEZVRs4_003D = _0023_003DzKG5_0024Fug_003D.CurrentBlock?.Name;
			break;
		case Actions.SetSelectionAsCurrent:
			_0023_003DzKG5_0024Fug_003D.SetSelectionAsCurrent();
			break;
		case Actions.OpenCurrentBlock:
			_0023_003DzKG5_0024Fug_003D.OpenCurrentBlock();
			break;
		case Actions.ResetOpenBlocks:
			_0023_003DzKG5_0024Fug_003D.ResetOpenBlocks();
			break;
		case Actions.CloseOpenBlock:
			_0023_003DzKG5_0024Fug_003D.CloseOpenBlock();
			break;
		case Actions.SetNavigationModeExamine:
			_0023_003DzKG5_0024Fug_003D._0023_003DzipBYly6zFKAp().Navigation.Mode = Camera.navigationType.Examine;
			break;
		case Actions.SetNavigationModeWalk:
			_0023_003DzKG5_0024Fug_003D._0023_003DzipBYly6zFKAp().Navigation.Mode = Camera.navigationType.Walk;
			break;
		case Actions.SetNavigationModeFly:
			_0023_003DzKG5_0024Fug_003D._0023_003DzipBYly6zFKAp().Navigation.Mode = Camera.navigationType.Fly;
			break;
		case Actions.GetNavigationMode:
			_0023_003DzWEZVRs4_003D = _0023_003DzKG5_0024Fug_003D._0023_003DzipBYly6zFKAp().Navigation.Mode.ToString();
			break;
		default:
			_0023_003DzWEZVRs4_003D = null;
			throw new ArgumentOutOfRangeException();
		}
	}

	private void _0023_003DzipYjlDuekE5SXqPamVfYpy4_003D(Design _0023_003DzFjK2_0024i0_003D, viewportLayoutType _0023_003DzVzeUT9E_003D)
	{
		int num = _0023_003DzFjK2_0024i0_003D.Viewports.Count;
		switch (_0023_003DzVzeUT9E_003D)
		{
		case viewportLayoutType.SingleViewport:
			num = 1;
			break;
		case viewportLayoutType.TwoViewportsVertical:
		case viewportLayoutType.TwoViewportsHorizontal:
			num = 2;
			break;
		case viewportLayoutType.ThreeViewportsWithOneOnLeft:
		case viewportLayoutType.ThreeViewportsWithOneOnTop:
		case viewportLayoutType.ThreeViewportsWithOneOnRight:
		case viewportLayoutType.ThreeViewportsWithOneOnBottom:
			num = 3;
			break;
		case viewportLayoutType.FourViewports:
			num = 4;
			break;
		}
		if (_0023_003DzFjK2_0024i0_003D.Viewports.Count > num)
		{
			while (_0023_003DzFjK2_0024i0_003D.Viewports.Count > num)
			{
				_0023_003DzFjK2_0024i0_003D.Viewports.RemoveAt(_0023_003DzFjK2_0024i0_003D.Viewports.Count - 1);
			}
		}
		else
		{
			Viewport viewport = _0023_003DzFjK2_0024i0_003D.Viewports[0];
			while (_0023_003DzFjK2_0024i0_003D.Viewports.Count < num)
			{
				Viewport viewport2 = new Viewport();
				viewport2.DisplayMode = viewport.DisplayMode;
				if (viewport.ViewCubeIcon != null)
				{
					viewport2.ViewCubeIcon = (ViewCubeIcon)viewport.ViewCubeIcon.Clone();
				}
				if (viewport.CoordinateSystemIcon != null)
				{
					viewport2.CoordinateSystemIcon = (CoordinateSystemIcon)viewport.CoordinateSystemIcon.Clone();
				}
				viewport2.OriginSymbols = new OriginSymbol[viewport.OriginSymbols.Length];
				for (int i = 0; i < viewport.OriginSymbols.Length; i++)
				{
					viewport2.OriginSymbols[i] = (OriginSymbol)viewport.OriginSymbols[i].Clone();
				}
				viewport2.ToolBars = new ToolBar[viewport.ToolBars.Length];
				for (int j = 0; j < viewport.ToolBars.Length; j++)
				{
					viewport2.ToolBars[j] = (ToolBar)viewport.ToolBars[j].Clone();
				}
				viewport2.Grids = new Grid[viewport.Grids.Length];
				for (int k = 0; k < viewport.Grids.Length; k++)
				{
					viewport2.Grids[k] = (Grid)viewport.Grids[k].Clone();
				}
				viewport2.Legends = new Legend[viewport.Legends.Length];
				for (int l = 0; l < viewport.Legends.Length; l++)
				{
					viewport2.Legends[l] = (Legend)viewport.Legends[l].Clone();
				}
				_0023_003DzFjK2_0024i0_003D.Viewports.Add(viewport2);
			}
		}
		_0023_003DzFjK2_0024i0_003D.LayoutMode = _0023_003DzVzeUT9E_003D;
	}

	public void Dispose()
	{
		if (_0023_003DzKG5_0024Fug_003D != null)
		{
			_0023_003DzKG5_0024Fug_003D.SelectionChanged -= _0023_003DztTdMKuhs3p8H;
			_0023_003DzKG5_0024Fug_003D = null;
		}
	}
}
