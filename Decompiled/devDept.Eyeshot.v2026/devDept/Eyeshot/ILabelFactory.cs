using devDept.Geometry.ConstraintSolver;

namespace devDept.Eyeshot;

internal interface ILabelFactory
{
	IStackedLabel Create(labelType type, SketchCurve curve, Constraint constraint);
}
