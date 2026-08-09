using System.Collections.Generic;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot;

internal class ComputeEntitiesVisibilityParams
{
	public int viewportIndex;

	public IBoundingBoxSettings boundingBox;

	public IList<Entity> entities;

	public Point3D entityGlobalMin;

	public Point3D entityGlobalMax;

	public LayerKeyedCollection layers;

	public bool animating;
}
