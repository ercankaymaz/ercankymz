using devDept.Eyeshot.Entities;

namespace devDept.Eyeshot.Meshing;

public interface ICurveMesherCreator
{
	CurveMesher CreateCurveMesher(ICurve curve, SizesOnCurve sizes);
}
