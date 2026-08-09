using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot;

internal interface IWorkspaceInternal : IWorkspace
{
	IBoundingBoxSettings BoundingBox { get; }

	MaterialKeyedCollection Materials { get; }

	Material DefaultMaterial { get; }

	Stack<BlockReference> Parents { get; }

	BlockKeyedCollection ParentBlocks { get; }

	BlockKeyedCollection HiddenBlocks { get; }

	Stack<Block> OpenParents { get; }

	int OpenBlocksDataCount { get; }

	IEnvironment EnvironmentMap { get; }

	bool IsAnimationRunning { get; }

	bool SuspendSetColorForSelection { get; set; }

	int MyHeight { get; }

	int MyWidth { get; }

	BackfaceSettings Backface { get; }

	Transformation CurrentTransformationInverse { get; }

	bool skipMoveTo { get; }

	BlockReference BlockReferenceForObjectManipulator { get; }

	IObjectManipulator ObjectManipulator { get; }

	BlockReference CurrentBlockReference { get; }

	IHiddenLinesSettings HiddenLines { get; }

	IDisplayModeSettings Wireframe { get; }

	IDisplayModeSettingsRendered Rendered { get; }

	IDisplayModeSettings Flat { get; }

	IDisplayModeSettings Shaded { get; }

	Stack<BlockReference> selectionScope { get; }

	ClippingPlane ClippingPlane1 { get; set; }

	ClippingPlaneBase[] clippingPlanes { get; }

	LightSettings[] lights { get; }

	Color ambientLight { get; }

	new Type FileSerializerForExtendedFormat { get; }

	zoomFitType ZoomFitMode { get; }

	bool IsHardwareAccelerated { get; }

	BlockKeyedCollection GetAllBlocks();

	void RaiseCameraMoveBegin(IViewport viewport);

	void RaiseOnViewChanged(IViewport viewport, viewType view);

	Color ComputeNonCurrentEntityColor(Entity entity, Color color, bool edge = false, bool forBlending = false);

	bool IsRenderingContextValid();

	bool IsRenderingContextValid(RenderContextBase renderContext);

	IDisplayModeSettings GetDisplayModeSettings(displayType displayMode);

	void FireSelectionChanged(SelectionChangedEventArgs eventArgs);

	Color MakeDarkerColor(Color color, double factor = 0.8);

	bool ShouldDrawDynamicWithHalo(IViewportInternal viewport);

	bool ShouldDrawStaticWithHalo(IViewportInternal viewport);

	BlockReference BuildRootEntity();

	void ResetAllConvexHulls(IReadOnlyList<Block> blocks, bool needStop = true);

	IList<Entity> GetAllEntities();

	bool IsSelected<T>(bool parentSelected, T drawParams, Entity ent) where T : DrawParams;

	bool ShouldDrawAsSelected<T>(bool selected, T drawParams) where T : DrawParams;

	bool DrawTrianglesForShadowMap(DrawEntitiesParams data);

	void ResetNeededConvexHull();

	void InitializeRootBlock();

	void DestroyFlattenedTree(bool clearFlattenRepresentation);

	void UpdateLayerNameForInternalElements(string name);

	SizeF GetScalingLevel();

	byte[] GetMachiningLabelImage(string label, Color white, Color color, IntPtr zero, out Size size);

	bool IsCloserVertex(Point3D projectedPt, double squareDistance, double currentMinimumSquareDistance);

	ICursorContainer SetWaitCursor();

	void RestoreCursor(ICursorContainer prev);

	void SetColorDrawForSelectionAndUpdateIdItemsMap<T>(DrawForSelectionParams data, ISelectableItem item, int partIndex = -1, int shellIndex = -1) where T : SelectedItem, new();

	object GetClipboardData(string format);

	void SetClipboardData(string format, object data);

	bool IsRightToLeft();

	void PreSaveOpenFile(bool clear = false);

	void PostSaveOpenFile();

	SelectedItem GetItemUnderMouseCursor(System.Drawing.Point mousePos, bool selectableOnly = true);

	byte[] GetThumbnailBytes(int thumbnailSize, Color backgroundColor);

	void UpdateThumbnails(WriteMultiFile writeMultiFile, FileSerializer fileSerializer, List<string> writtenFiles, IViewport viewportForThumbnails, bool updateThubmnails, Color thumbnailBackgroundColor, StringBuilder log, IProgress<WorkUnit.ProgressChangedEventArgs> progress, CancellationToken ct);

	void SuspendUpdate(bool suspend);

	void UpdateWorkspace();

	bool IsIsolated(IIsolateParams data, Entity ent);

	bool IsSelectableForIsolation(IIsolateParams data, Entity ent);
}
