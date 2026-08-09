using devDept.Geometry;

namespace devDept.Eyeshot.Entities;

public interface IEvaluable
{
	Vector3D[] Evaluate(double u, int d);
}
