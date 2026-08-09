using System.Collections.Generic;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Meshing;

public interface IFaceMesherCreator : ICurveMesherCreator
{
	Mesher CreateFaceMesher(Surface surface, IList<Polygon2D> trimPolylines, double[] uniqueSizes, double uScale = 1.0, double vScale = 1.0);
}
