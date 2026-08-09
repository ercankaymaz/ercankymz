using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public interface OdGiConveyorGeometry
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	HandleRef GetInterfaceCPtr();

	void plineProc(OdGiPolyline polyline, OdGeMatrix3d pXfm, uint fromIndex, uint numSegs);

	void polylineProc(OdGePoint3d[] numPoints, OdGeVector3d pNormal, OdGeVector3d pExtrusion, IntPtr baseSubEntMarker);

	void polylineProc(int arg0, OdGePoint3d arg1, OdGeVector3d arg2, OdGeVector3d arg3, int arg4);

	void polygonProc(OdGePoint3d[] numPoints, OdGeVector3d pNormal, OdGeVector3d pExtrusion);

	void xlineProc(OdGePoint3d firstPoint, OdGePoint3d secondPoint);

	void rayProc(OdGePoint3d basePoint, OdGePoint3d throughPoint);

	void meshProc(MeshData numRows);

	void shellProc(ShellData numVertices);

	void circleProc(OdGePoint3d center, double radius, OdGeVector3d normal, OdGeVector3d pExtrusion);

	void circleProc2(OdGePoint3d center, double radius, OdGeVector3d normal, OdGeVector3d arg3, OdGeVector3d pExtrusion);

	void circleProc2(OdGePoint3d center, double radius, OdGeVector3d normal, OdGeVector3d arg3);

	void circleProc(OdGePoint3d firstPoint, OdGePoint3d secondPoint, OdGePoint3d thirdPoint, OdGeVector3d pExtrusion);

	void circularArcProc(OdGePoint3d center, double radius, OdGeVector3d normal, OdGeVector3d startVector, double sweepAngle, OdGiArcType arcType, OdGeVector3d pExtrusion);

	void circularArcProc(OdGePoint3d firstPoint, OdGePoint3d secondPoint, OdGePoint3d thirdPoint, OdGiArcType arcType, OdGeVector3d pExtrusion);

	void ellipArcProc(OdGeEllipArc3d ellipArc, OdGePoint3d[] endPointOverrides, OdGiArcType arcType, OdGeVector3d pExtrusion);

	void nurbsProc(OdGeNurbCurve3d nurbsCurve);

	void textProc(OdGePoint3d position, OdGeVector3d direction, OdGeVector3d upVector, string msg, bool raw, OdGiTextStyle pTextStyle, OdGeVector3d pExtrusion);

	void textProc2(OdGePoint3d position, OdGeVector3d direction, OdGeVector3d upVector, string msg, bool raw, OdGiTextStyle pTextStyle, OdGeVector3d pExtrusion, OdGeExtents3d arg8);

	void shapeProc(OdGePoint3d position, OdGeVector3d direction, OdGeVector3d upVector, int shapeNumber, OdGiTextStyle pTextStyle, OdGeVector3d pExtrusion);

	void shapeProc(OdGePoint3d position, OdGeVector3d direction, OdGeVector3d upVector, int shapeNumber, OdGiTextStyle pTextStyle);

	void rasterImageProc(OdGePoint3d origin, OdGeVector3d u, OdGeVector3d v, OdGiRasterImage pImage, OdGePoint2d[] uvBoundary, bool transparency, double brightness, double contrast, double fade);

	void metafileProc(OdGePoint3d origin, OdGeVector3d u, OdGeVector3d v, OdGiMetafile pMetafile, bool dcAligned, bool allowClipping);

	void metafileProc(OdGePoint3d origin, OdGeVector3d u, OdGeVector3d v, OdGiMetafile pMetafile, bool dcAligned);

	void metafileProc(OdGePoint3d origin, OdGeVector3d u, OdGeVector3d v, OdGiMetafile pMetafile);

	void xlineProc2(OdGePoint3d basePoint, OdGeVector3d direction);

	void rayProc2(OdGePoint3d basePoint, OdGeVector3d direction);

	void setExtentsProc(OdGePoint3d arg0, bool arg1);

	void setExtentsProc(OdGePoint3d arg0);

	int ttfCharProcFlags();

	bool ttfCharProc(char arg0, bool arg1, OdGePoint3d arg2, OdGeBoundBlock3d arg3);

	void ttfPolyDrawProc(OdGePoint3d[] numVertices, int[] faceListSize, byte[] arg2, OdGiFaceData pFaceData);

	void ttfPolyDrawProc(OdGePoint3d[] numVertices, int[] faceListSize, byte[] arg2);

	void conveyorBoundaryInfoProc(OdGeBoundBlock3d arg0, out uint arg1);

	void polypointProc2(OdGiConveyorContext pContext, OdGePoint3d[] numPoints, OdCmEntityColor pColors, OdCmTransparency pTransparency, OdGeVector3d pNormals, OdGeVector3d pExtrusions, IntPtr[] pSubEntMarkers, int nPointSize);

	void polypointProc2(OdGiConveyorContext pContext, OdGePoint3d[] numPoints, OdCmEntityColor pColors, OdCmTransparency pTransparency, OdGeVector3d pNormals, OdGeVector3d pExtrusions, IntPtr[] pSubEntMarkers);

	void polypointProc2(OdGiConveyorContext pContext, OdGePoint3d[] numPoints, OdCmEntityColor pColors, OdCmTransparency pTransparency, OdGeVector3d pNormals, OdGeVector3d pExtrusions);

	void polypointProc2(OdGiConveyorContext pContext, OdGePoint3d[] numPoints, OdCmEntityColor pColors, OdCmTransparency pTransparency, OdGeVector3d pNormals);

	void polypointProc2(OdGiConveyorContext pContext, OdGePoint3d[] numPoints, OdCmEntityColor pColors, OdCmTransparency pTransparency);

	void polypointProc2(OdGiConveyorContext pContext, OdGePoint3d[] numPoints, OdCmEntityColor pColors);

	void polypointProc2(OdGiConveyorContext pContext, OdGePoint3d[] numPoints);

	void rowOfDotsProc2(int numPoints, OdGePoint3d startPoint, OdGeVector3d dirToNextPoint);

	void polypointProc(OdGePoint3d[] numPoints, OdCmEntityColor pColors, OdCmTransparency pTransparency, OdGeVector3d pNormals, OdGeVector3d pExtrusions, IntPtr[] pSubEntMarkers, int nPointSize);

	void polypointProc(OdGePoint3d[] numPoints, OdCmEntityColor pColors, OdCmTransparency pTransparency, OdGeVector3d pNormals, OdGeVector3d pExtrusions, IntPtr[] pSubEntMarkers);

	void polypointProc(OdGePoint3d[] numPoints, OdCmEntityColor pColors, OdCmTransparency pTransparency, OdGeVector3d pNormals, OdGeVector3d pExtrusions);

	void polypointProc(OdGePoint3d[] numPoints, OdCmEntityColor pColors, OdCmTransparency pTransparency, OdGeVector3d pNormals);

	void polypointProc(OdGePoint3d[] numPoints, OdCmEntityColor pColors, OdCmTransparency pTransparency);

	void polypointProc(OdGePoint3d[] numPoints, OdCmEntityColor pColors);

	void polyPolygonProc2(OdGiConveyorContext pContext, uint numIndices, ref uint pNumPositions, OdGePoint3d pPositions, ref uint pNumPoints, OdGePoint3d pPoints, OdCmEntityColor pOutlineColors, ref uint pOutlinePsLinetypes, OdCmEntityColor pFillColors, OdCmTransparency pFillTransparencies);

	void polyPolygonProc2(OdGiConveyorContext pContext, uint numIndices, ref uint pNumPositions, OdGePoint3d pPositions, ref uint pNumPoints, OdGePoint3d pPoints, OdCmEntityColor pOutlineColors, ref uint pOutlinePsLinetypes, OdCmEntityColor pFillColors);

	void polyPolygonProc2(OdGiConveyorContext pContext, uint numIndices, ref uint pNumPositions, OdGePoint3d pPositions, ref uint pNumPoints, OdGePoint3d pPoints, OdCmEntityColor pOutlineColors, ref uint pOutlinePsLinetypes);

	void polyPolygonProc2(OdGiConveyorContext pContext, uint numIndices, ref uint pNumPositions, OdGePoint3d pPositions, ref uint pNumPoints, OdGePoint3d pPoints, OdCmEntityColor pOutlineColors);

	void polyPolygonProc2(OdGiConveyorContext pContext, uint numIndices, ref uint pNumPositions, OdGePoint3d pPositions, ref uint pNumPoints, OdGePoint3d pPoints);

	void rowOfDotsProc(int numPoints, OdGePoint3d startPoint, OdGeVector3d dirToNextPoint);

	void pointCloudProc2(OdGiConveyorContext pContext, OdGiPointCloud pCloud, OdGiPointCloudFilter pFilter);

	void pointCloudProc(OdGiPointCloud pCloud, OdGiPointCloudFilter pFilter);

	void pointCloudProc(OdGiPointCloud pCloud);

	void edgeProc(OdGeCurve2dArray edges, OdGeMatrix3d pXform);

	void edgeProc(OdGeCurve2dArray edges);
}
