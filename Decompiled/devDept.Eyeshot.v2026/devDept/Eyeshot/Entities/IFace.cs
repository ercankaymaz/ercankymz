using System;
using System.Collections.Generic;
using devDept.Geometry;

namespace devDept.Eyeshot.Entities;

public interface IFace : ICloneable
{
	double GetArea(out Point3D centroid);

	double GetVolume(out Point3D centroid);

	double GetMass(Material material, linearUnitsType linearUnits, massUnitsType massUnits, out double convertedDensity);

	void FlipNormal();

	Mesh[] GetTessellation();

	IList<HitTriangle> FindClosestTriangle(Transformation transf, Segment3D seg);

	ICurve[] Section(Plane pln, double tol);

	Mesh ConvertToMesh(double deviation, double angle, Mesh.natureType nature, bool weld);

	Brep ConvertToBrep(bool mergeFaces, bool mergeEdges);

	void GetTightBBox(out Point3D boxMin, out Point3D boxMax);

	void GetPrincipalAxes(out Vector3D axisX, out Vector3D axisY, out Vector3D axisZ, out double ix, out double iy, out double iz);
}
