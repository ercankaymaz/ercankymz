using System;
using System.Collections.Generic;
using System.Drawing;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot;

public interface IViewport : ICloneable
{
	Camera Camera { get; set; }

	IRotateSettings Rotate { get; }

	displayType DisplayMode { get; set; }

	IBackgroundSettings Background { get; }

	Size Size { get; set; }

	int VertexSize { get; set; }

	System.Drawing.Point Location { get; set; }

	Point3D CenterOfRotation { get; }

	int[] GetViewFrame();

	void AdjustNearAndFarPlanes();

	void Dispose();

	Point3D[] ScreenToWorld(IList<System.Drawing.Point> mousePointList);

	Point3D ScreenToWorld(System.Drawing.Point mousePos);

	void SaveView(out Camera saved);

	void RestoreView(Camera saved);

	PlaneEquation[] GetCameraFrustum();

	bool Contains(System.Drawing.Point mousePos);

	void SetView(viewType view);

	void SetView(viewType view, bool fit, bool animate);

	void SetView(Quaternion rotation, bool fit, bool animate);

	void SetView(viewType view, bool fit, bool animate, int margin, bool selectedOnly = false, int duration = 0);

	void SetView(Quaternion rotation, bool fit, bool animate, int margin, bool selectedOnly = false, int duration = 0);

	void SetView(Quaternion rotation, Point3D target, double distance, double zoomFactor);

	void SetView(Quaternion rotation, Point3D target, double distance, double zoomFactor, bool animate);

	void SetView(Vector3D direction, bool fit = false, int margin = 10, bool selectedOnly = false);

	void SetView(Vector3D direction, bool fit, bool animate, int margin = 10, bool selectedOnly = false);

	void SetView(Vector3D direction, Vector3D upVector, bool fit = false, int margin = 10, bool selectedOnly = false);

	void SetView(Vector3D direction, Vector3D upVector, bool fit, bool animate, int margin = 10, bool selectedOnly = false, IList<Entity> entList = null);

	bool IsCameraAnimating();

	Quaternion GetCameraRotation(viewType view, Quaternion initialRotation = null);

	System.Drawing.Point ScreenToViewport(System.Drawing.Point pt);

	PointF ScreenToViewport(PointF pt);

	System.Drawing.Point ViewportToScreen(System.Drawing.Point pt);

	System.Drawing.Point ViewportToCameraScreen(System.Drawing.Point pt);

	bool Project(int controlHeight, double objx, double objy, double objz, out double winx, out double winy, out double winz);

	Point2D[] Project(IList<Point3D> points, int controlHeight);

	bool UnProject(int controlHeight, double winx, double winy, double winz, out double objx, out double objy, out double objz);

	Point3D[] UnProject(IList<Point3D> points, int controlHeight);

	bool ScreenToPlane(System.Drawing.Point mousePos, Plane plane, out Point3D intPoint);

	bool ScreenToPlane(System.Drawing.Point mousePos, PlaneEquation pe, out Point3D intPoint);

	Point3D[] ScreenToPlane(IList<System.Drawing.Point> mousePointList, Plane pe);

	Point3D[] ScreenToPlane(IList<System.Drawing.Point> mousePointList, PlaneEquation pe);

	Point3D WorldToScreen(Point3D point);

	Point3D WorldToScreen(double x, double y, double z);

	Point3D[] WorldToScreen(IList<Point3D> pointList);

	void Invalidate();

	Rectangle GetBounds();

	void CompileUserInterfaceElements();

	void ZoomCamera(int dy);

	void ZoomCamera(int dy, bool animate);

	void ZoomCamera(System.Drawing.Point mousePos, int dy);

	void ZoomCamera(System.Drawing.Point mousePos, int dy, bool animate);

	void ZoomCamera(int dy, double zoomSpeed);

	void ZoomCamera(int dy, double zoomSpeed, bool animate);

	void ZoomWindow(System.Drawing.Point p1, System.Drawing.Point p2);

	void ZoomFit();

	void ZoomFit(int margin);

	void ZoomFit(bool selectedOnly, Camera.perspectiveFitType perspectiveFitMode);

	void ZoomFit(bool selectedOnly, Camera.perspectiveFitType perspectiveFitMode, int margin);

	void ZoomFit(IList<Entity> entList, bool selectedOnly, Camera.perspectiveFitType perspectiveFitMode);

	void ZoomFit(IList<Entity> entList, bool selectedOnly, Camera.perspectiveFitType perspectiveFitMode, int margin, bool fitLabels = false);

	void ZoomFit(IList<SelectedItem> items);

	void ZoomFit(IList<SelectedItem> items, int margin);

	void ZoomFit(IList<SelectedItem> items, int margin, Camera.perspectiveFitType perspectiveFitMode);

	void PanCamera(System.Drawing.Point from, System.Drawing.Point to);

	void PanCamera(System.Drawing.Point from, System.Drawing.Point to, bool animate);

	void RotateCamera(int dx, int dy);

	void RotateCamera(int dx, int dy, bool animate);

	void RotateCamera(System.Drawing.Point mousePos1, System.Drawing.Point mousePos2);

	void RotateCamera(System.Drawing.Point mousePos1, System.Drawing.Point mousePos2, bool animate);

	void RotateCamera(Vector3D axis, double rotAngleInDegrees, bool trackBall);

	void RotateCamera(Vector3D axis, double rotAngleInDegrees, bool trackBall, bool animate);

	void RotateCamera(Vector3D last, Vector3D current);

	void RotateCamera(Vector3D last, Vector3D current, bool animate);

	void RotateCamera(System.Drawing.Point mouseLocation);

	void OrientCamera(Point3D location, Point3D target);
}
