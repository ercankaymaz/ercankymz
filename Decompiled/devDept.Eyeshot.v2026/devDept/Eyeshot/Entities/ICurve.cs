using System;
using System.Collections.Generic;
using devDept.Geometry;

namespace devDept.Eyeshot.Entities;

public interface ICurve : ICloneable
{
	Interval Domain { get; }

	Point3D EndPoint { get; }

	Point3D StartPoint { get; }

	bool IsClosed { get; }

	bool IsPoint { get; }

	Vector3D StartTangent { get; }

	Vector3D EndTangent { get; }

	int EdgeIndex { get; set; }

	bool FromBooleanIntersection { get; set; }

	double Length();

	void Reverse();

	bool SubCurve(double startParam, double endParam, out ICurve sub);

	bool SubCurve(Point3D startPt, Point3D endPt, out ICurve sub);

	bool SplitAt(double t, out ICurve lower, out ICurve upper);

	bool SplitBy(Point3D pt, out ICurve lower, out ICurve upper);

	bool SplitBy(IList<Point3D> points, out ICurve[] segments);

	bool TrimAt(double t, bool flipSide);

	bool TrimBy(Point3D pt, bool flipSide);

	bool ExtendAt(double t);

	bool ExtendBy(Point3D pt, bool curveEnd = true);

	bool GetParamFromLength(double length, out double t);

	bool GetParamFromLength(double length, double curveLength, out double t);

	bool GetLengthFromParam(double t, out double length);

	Point3D[] IntersectWith(ICurve C2, double maxGap = 0.0, bool computeParameters = true);

	void ClosestPointTo(Point3D point, out double t);

	bool Project(Point3D point, out double t);

	ICurve[] GetIndividualCurves();

	bool IsPlanar(double tol, out Plane plane);

	bool IsInPlane(Plane plane, double tol);

	bool IsLinear(double tol, out Segment3D line);

	Point3D PointAt(double t);

	Vector3D TangentAt(double t);

	Vector3D NormalAt(double t);

	ICurve[] Offset(double amount, Vector3D planeNormal, bool sharp = false);

	double DistanceTo(ICurve curve, out Point3D[] closestPointOnFirst, out Point3D[] closestPointOnSecond);

	Region OffsetToRegion(double amount, bool sharp);

	Point3D[] GetPointsByLength(double length);

	Point3D[] GetPointsByLengthPerSegment(double length);

	void GetTightBBox(out Point3D boxMin, out Point3D boxMax);

	void GetApproximatedBoundingBox(out Point3D boxMin, out Point3D boxMax);

	LinearPath ConvertToLinearPath(double deviation, double angle);

	Mesh ExtrudeAsMesh(Vector3D amount, double tolerance, Mesh.natureType meshNature);

	Mesh ExtrudeAsMesh(double dx, double dy, double dz, double tolerance, Mesh.natureType meshNature);

	T ExtrudeAsMesh<T>(Vector3D amount, double tolerance, Mesh.natureType meshNature) where T : Mesh, new();

	T ExtrudeAsMesh<T>(double dx, double dy, double dz, double tolerance, Mesh.natureType meshNature) where T : Mesh, new();

	Mesh RevolveAsMesh(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd, int slices, double tolerance, Mesh.natureType meshNature);

	Mesh RevolveAsMesh(double startAngle, double deltaAngle, Vector3D axis, Point3D center, int slices, double tolerance, Mesh.natureType meshNature);

	T RevolveAsMesh<T>(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd, int slices, double tolerance, Mesh.natureType meshNature) where T : Mesh, new();

	T RevolveAsMesh<T>(double startAngle, double deltaAngle, Vector3D axis, Point3D center, int slices, double tolerance, Mesh.natureType meshNature) where T : Mesh, new();

	Mesh SweepAsMesh(ICurve rail, double tol, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames, Mesh.natureType meshNature = Mesh.natureType.Smooth);

	T SweepAsMesh<T>(ICurve rail, double tol, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames, Mesh.natureType meshNature = Mesh.natureType.Smooth) where T : Mesh, new();

	Mesh[] SweepAsMesh(ICurve rail, double tol, bool merge, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames, Mesh.natureType meshNature = Mesh.natureType.Smooth);

	T[] SweepAsMesh<T>(ICurve rail, double tol, bool merge, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames, Mesh.natureType meshNature = Mesh.natureType.Smooth) where T : Mesh, new();

	Curve GetNurbsForm();

	Surface[] ExtrudeAsSurface(Line line);

	Surface[] ExtrudeAsSurface(double dx, double dy, double dz);

	Surface[] ExtrudeAsSurface(Vector3D amount);

	Surface[] ExtrudeAsSurface(Vector3D amount, double draftAngleInRadians, double tolerance);

	Brep ExtrudeAsBrep(Line line, double tolerance = 0.0);

	Brep ExtrudeAsBrep(double dx, double dy, double dz, double tolerance = 0.0);

	Brep ExtrudeAsBrep(Vector3D amount, double draftAngleInRadians = 0.0, double tolerance = 0.0);

	Surface[] RevolveAsSurface(double startAngle, double deltaAngle, Vector3D axis, Point3D center);

	Surface[] RevolveAsSurface(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd);

	Surface[] RevolveAsSurface(double startAngle, double deltaAngle, Line axis);

	Brep RevolveAsBrep(double startAngle, double deltaAngle, Vector3D axis, Point3D center, double tolerance = 0.0);

	Brep RevolveAsBrep(Interval intervalAngle, Vector3D axis, Point3D center, double tolerance = 0.0);

	Brep RevolveAsBrep(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd, double tolerance = 0.0);

	Brep RevolveAsBrep(Interval intervalAngle, Point3D axisStart, Point3D axisEnd, double tolerance = 0.0);

	Brep RevolveAsBrep(double startAngle, double deltaAngle, Line axis, double tolerance = 0.0);

	Brep RevolveAsBrep(Interval intervalAngle, Line axis, double tolerance = 0.0);

	Surface[] SweepAsSurface(ICurve rail, double tol, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames);

	Brep SweepAsBrep(ICurve rail, double tolerance, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames);

	Brep[] SweepAsBrep(ICurve rail, double tolerance, bool merge, sweepMethodType methodType = sweepMethodType.RotationMinimizingFrames);

	Solid ExtrudeAsSolid(Vector3D amount, double tolerance);

	Solid ExtrudeAsSolid(double dx, double dy, double dz, double tolerance);

	Solid RevolveAsSolid(double startAngle, double deltaAngle, Vector3D axis, Point3D center, int slices, double tolerance);

	Solid RevolveAsSolid(Interval intervalAngle, Vector3D axis, Point3D center, int slices, double tolerance);

	Solid RevolveAsSolid(double startAngle, double deltaAngle, Point3D axisStart, Point3D axisEnd, int slices, double tolerance);

	Solid RevolveAsSolid(Interval intervalAngle, Point3D axisStart, Point3D axisEnd, int slices, double tolerance);

	Solid SweepAsSolid(ICurve rail, double tol, sweepMethodType sweepMethod);

	Solid[] SweepAsSolid(ICurve rail, double tol, bool merge, sweepMethodType sweepMethod);
}
