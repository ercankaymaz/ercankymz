using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;

namespace devDept.Eyeshot;

public interface IWorkspace
{
	Document Document { get; }

	RenderContextBase RenderContext { get; }

	IList<IViewport> Viewports { get; }

	IViewport ActiveViewport { get; }

	bool AccurateTransparency { get; set; }

	bool CompileWires { get; }

	actionType ActionMode { get; set; }

	Transformation CurrentTransformation { get; }

	Camera.perspectiveFitType IsInFrustumMode { get; }

	string InstanceId { get; }

	ISelectionSettings Selection { get; }

	bool AnimateCamera { get; set; }

	Type FileSerializerForExtendedFormat { get; set; }

	BlockKeyedCollection Blocks { get; }

	Block RootBlock { get; }

	LayerKeyedCollection Layers { get; }

	LineTypeKeyedCollection LineTypes { get; }

	HatchPatternKeyedCollection HatchPatterns { get; }

	TextStyleKeyedCollection TextStyles { get; }

	EntityList Entities { get; }

	IList<Entity> TempEntities { get; }

	bool IsOpenRootLevel { get; }

	Block CurrentBlock { get; }

	Block OpenBlock { get; }

	attributeReferenceVisibilityType AttributeReferenceVisibilityMode { get; set; }

	bool IsDesignMode();

	bool ScreenToPlane(System.Drawing.Point mousePos, Plane plane, out Point3D intPoint);

	bool ScreenToPlane(System.Drawing.Point mousePos, PlaneEquation pe, out Point3D intPoint);

	Point3D[] ScreenToPlane(IList<System.Drawing.Point> mousePointList, Plane plane);

	Point3D[] ScreenToPlane(IList<System.Drawing.Point> mousePointList, PlaneEquation pe);

	Point3D[] ScreenToWorld(IList<System.Drawing.Point> mousePointList);

	Point3D ScreenToWorld(System.Drawing.Point mousePos);

	Point3D WorldToScreen(Point3D point);

	Point3D WorldToScreen(double x, double y, double z);

	Point3D[] WorldToScreen(IList<Point3D> pointList);

	void Invalidate();

	void UpdateVisibleSelection();

	void AdjustNearAndFarPlanes();

	void SaveView(out Camera saved);

	void RestoreView(Camera saved);

	void ZoomFit();

	void ZoomFit(IList<Entity> entList, bool selectedOnly, int margin);

	BlockReference RemoveJittering(string blockName = null);

	void RemoveJittering(BlockReference blockReference);

	[Obsolete("Use DoWorkAsync(WorkUnit) instead.")]
	void StartWork(WorkUnit workUnit);

	Task DoWorkAsync([_0023_003DzhHWW9r0qfQtnZqjP_UUOuKc_003D] IReadOnlyList<WorkUnit> workUnits);

	void DoWork(WorkUnit workUnit);

	void UpdateBoundingBox();

	void Clear();
}
