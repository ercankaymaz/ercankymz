using devDept.Geometry.ConstraintSolver;

namespace devDept.Eyeshot.Entities;

public static class SketchEntityExtensions
{
	public static bool IsSketchEntity(this Entity entity)
	{
		return entity._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() != null;
	}

	public static bool IsConstruction(this Entity entity)
	{
		return (entity._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchCurve)?.Construction ?? false;
	}

	public static bool IsFixed(this Entity entity)
	{
		return (entity._0023_003Dz4_p8PI92bM5mIBqRCQ_003D_003D() as SketchCurve)?.Fixed ?? false;
	}
}
