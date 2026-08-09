using System.IO;
using Microsoft.Extensions.Logging;
using Xbim.Common.Geometry;

namespace Xbim.Ifc4.Interfaces;

public interface IXbimGeometryEngine
{
	IXbimGeometryObject Create(IIfcGeometricRepresentationItem ifcRepresentation, ILogger logger = null);

	IXbimGeometryObject Create(IIfcGeometricRepresentationItem ifcRepresentation, IIfcAxis2Placement3D objectLocation, ILogger logger = null);

	XbimShapeGeometry CreateShapeGeometry(IXbimGeometryObject geometryObject, double precision, double deflection, double angle, XbimGeometryType storageType, ILogger logger = null);

	XbimShapeGeometry CreateShapeGeometry(IXbimGeometryObject geometryObject, double precision, double deflection, ILogger logger = null);

	XbimShapeGeometry CreateShapeGeometry(double oneMillimetre, IXbimGeometryObject geometryObject, double precision, ILogger logger = null);

	IXbimGeometryObjectSet CreateGeometryObjectSet();

	IXbimSolid CreateSolid(IIfcSweptAreaSolid ifcSolid, ILogger logger = null);

	IXbimSolid CreateSolid(IIfcExtrudedAreaSolid ifcSolid, ILogger logger = null);

	IXbimSolid CreateSolid(IIfcRevolvedAreaSolid ifcSolid, ILogger logger = null);

	IXbimSolid CreateSolid(IIfcSweptDiskSolid ifcSolid, ILogger logger = null);

	IXbimSolid CreateSolid(IIfcBoundingBox ifcSolid, ILogger logger = null);

	IXbimSolid CreateSolid(IIfcSurfaceCurveSweptAreaSolid ifcSolid, ILogger logger = null);

	IXbimSolidSet CreateSolidSet(IIfcBooleanClippingResult ifcSolid, ILogger logger = null);

	IXbimSolidSet CreateSolidSet(IIfcBooleanOperand ifcSolid, ILogger logger = null);

	IXbimSolid CreateSolid(IIfcHalfSpaceSolid ifcSolid, ILogger logger = null);

	IXbimSolid CreateSolid(IIfcPolygonalBoundedHalfSpace ifcSolid, ILogger logger = null);

	IXbimSolid CreateSolid(IIfcBoxedHalfSpace ifcSolid, ILogger logger = null);

	IXbimSolidSet CreateSolidSet(IIfcManifoldSolidBrep ifcSolid, ILogger logger = null);

	IXbimSolidSet CreateSolidSet(IIfcFacetedBrep ifcSolid, ILogger logger = null);

	IXbimSolidSet CreateSolidSet(IIfcFacetedBrepWithVoids ifcSolid, ILogger logger = null);

	IXbimSolidSet CreateSolidSet(IIfcClosedShell ifcSolid, ILogger logger = null);

	IXbimSolidSet CreateSolidSet(IIfcSweptAreaSolid ifcSolid, ILogger logger = null);

	IXbimSolid CreateSolid(IIfcCsgPrimitive3D ifcSolid, ILogger logger = null);

	IXbimSolidSet CreateSolidSet(IIfcCsgSolid ifcSolid, ILogger logger = null);

	IXbimSolid CreateSolid(IIfcSphere ifcSolid, ILogger logger = null);

	IXbimSolid CreateSolid(IIfcBlock ifcSolid, ILogger logger = null);

	IXbimSolid CreateSolid(IIfcRightCircularCylinder ifcSolid, ILogger logger = null);

	IXbimSolid CreateSolid(IIfcRightCircularCone ifcSolid, ILogger logger = null);

	IXbimSolid CreateSolid(IIfcRectangularPyramid ifcSolid, ILogger logger = null);

	IXbimSolid CreateSolid(IIfcSweptDiskSolidPolygonal ifcSolid, ILogger logger = null);

	IXbimSolid CreateSolid(IIfcRevolvedAreaSolidTapered ifcSolid, ILogger logger = null);

	IXbimSolid CreateSolid(IIfcFixedReferenceSweptAreaSolid ifcSolid, ILogger logger = null);

	IXbimSolid CreateSolid(IIfcAdvancedBrep ifcSolid, ILogger logger = null);

	IXbimSolid CreateSolid(IIfcAdvancedBrepWithVoids ifcSolid, ILogger logger = null);

	IXbimSolid CreateSolid(IIfcSectionedSpine ifcSolid, ILogger logger = null);

	IXbimShell CreateShell(IIfcOpenShell shell, ILogger logger = null);

	IXbimShell CreateShell(IIfcConnectedFaceSet shell, ILogger logger = null);

	IXbimShell CreateShell(IIfcSurfaceOfLinearExtrusion shell, ILogger logger = null);

	IXbimGeometryObjectSet CreateSurfaceModel(IIfcTessellatedFaceSet shell, ILogger logger = null);

	IXbimGeometryObjectSet CreateSurfaceModel(IIfcShellBasedSurfaceModel ifcSurface, ILogger logger = null);

	IXbimGeometryObjectSet CreateSurfaceModel(IIfcFaceBasedSurfaceModel ifcSurface, ILogger logger = null);

	IXbimSolid CreateSolid(IIfcFaceBasedSurfaceModel ifcSurface, ILogger logger = null);

	IXbimSolid CreateSolid(IIfcShellBasedSurfaceModel ifcSurface, ILogger logger = null);

	IXbimSolid CreateSolid(IIfcTriangulatedFaceSet ifcSurface, ILogger logger = null);

	IXbimSolidSet CreateSolidSet(IIfcFaceBasedSurfaceModel ifcSurface, ILogger logger = null);

	IXbimSolidSet CreateSolidSet(IIfcShellBasedSurfaceModel ifcSurface, ILogger logger = null);

	IXbimSolidSet CreateSolidSet(IIfcTriangulatedFaceSet ifcSurface, ILogger logger = null);

	IXbimSolidSet CreateSolidSet(IIfcPolygonalFaceSet ifcSurface, ILogger logger = null);

	IXbimFace CreateFace(IIfcProfileDef profileDef, ILogger logger = null);

	IXbimFace CreateFace(IIfcCompositeCurve cCurve, ILogger logger = null);

	IXbimFace CreateFace(IIfcPolyline pline, ILogger logger = null);

	IXbimFace CreateFace(IIfcPolyLoop loop, ILogger logger = null);

	IXbimFace CreateFace(IIfcSurface surface, ILogger logger = null);

	IXbimFace CreateFace(IIfcPlane plane, ILogger logger = null);

	IXbimFace CreateFace(IXbimWire wire, ILogger logger = null);

	IXbimWire CreateWire(IIfcCurve curve, ILogger logger = null);

	IXbimWire CreateWire(IIfcCompositeCurveSegment compCurveSeg, ILogger logger = null);

	IXbimCurve CreateCurve(IIfcCurve curve, ILogger logger = null);

	IXbimCurve CreateCurve(IIfcPolyline curve, ILogger logger = null);

	IXbimCurve CreateCurve(IIfcCircle curve, ILogger logger = null);

	IXbimCurve CreateCurve(IIfcEllipse curve, ILogger logger = null);

	IXbimCurve CreateCurve(IIfcLine curve, ILogger logger = null);

	IXbimCurve CreateCurve(IIfcTrimmedCurve curve, ILogger logger = null);

	IXbimCurve CreateCurve(IIfcRationalBSplineCurveWithKnots curve, ILogger logger = null);

	IXbimCurve CreateCurve(IIfcBSplineCurveWithKnots curve, ILogger logger = null);

	IXbimCurve CreateCurve(IIfcOffsetCurve3D curve, ILogger logger = null);

	IXbimCurve CreateCurve(IIfcOffsetCurve2D curve, ILogger logger = null);

	IXbimPoint CreatePoint(double x, double y, double z, double tolerance);

	IXbimPoint CreatePoint(IIfcCartesianPoint p);

	IXbimPoint CreatePoint(XbimPoint3D p, double tolerance);

	IXbimPoint CreatePoint(IIfcPoint pt);

	IXbimPoint CreatePoint(IIfcPointOnCurve p, ILogger logger = null);

	IXbimPoint CreatePoint(IIfcPointOnSurface p, ILogger logger = null);

	IXbimVertex CreateVertexPoint(XbimPoint3D point, double precision);

	IXbimSolidSet CreateSolidSet();

	IXbimSolidSet CreateSolidSet(IIfcBooleanResult boolOp, ILogger logger = null);

	IXbimSolidSet CreateGrid(IIfcGrid grid, ILogger logger = null);

	XbimMatrix3D ToMatrix3D(IIfcObjectPlacement objPlacement, ILogger logger = null);

	void WriteTriangulation(TextWriter tw, IXbimGeometryObject shape, double tolerance, double deflection, double angle);

	void WriteTriangulation(BinaryWriter bw, IXbimGeometryObject shape, double tolerance, double deflection, double angle);

	void Mesh(IXbimMeshReceiver receiver, IXbimGeometryObject geometryObject, double precision, double deflection, double angle = 0.5);

	IXbimGeometryObject Transformed(IXbimGeometryObject geometryObject, IIfcCartesianTransformationOperator transformation);

	IXbimGeometryObject Moved(IXbimGeometryObject geometryObject, IIfcPlacement placement);

	IXbimGeometryObject Moved(IXbimGeometryObject geometryObject, IIfcObjectPlacement objectPlacement, ILogger logger = null);

	IXbimGeometryObject Moved(IXbimGeometryObject geometryObject, IIfcAxis2Placement3D placement);

	IXbimGeometryObject Moved(IXbimGeometryObject geometryObject, IIfcAxis2Placement2D placement);

	IXbimGeometryObject FromBrep(string brepStr);

	string ToBrep(IXbimGeometryObject geometryObject);

	void WriteBrep(string filename, IXbimGeometryObject geomObj);

	IXbimGeometryObject ReadBrep(string filename);
}
