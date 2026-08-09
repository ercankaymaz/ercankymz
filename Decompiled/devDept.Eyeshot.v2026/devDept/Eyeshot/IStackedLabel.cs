using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot;

internal interface IStackedLabel : ILabel
{
	VisualConstraint Constraint { get; set; }

	bool Visible { get; set; }

	void UpdateAnchorPoint(Transformation t);

	void ResetPos();

	void IncrementPos();
}
