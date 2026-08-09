using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot;

public interface IDesign : IWorkspace
{
	new DesignDocument Document { get; }

	MaterialKeyedCollection Materials { get; set; }

	linearUnitsType Units { get; set; }

	SketchEntity CurrentSketch { get; }
}
