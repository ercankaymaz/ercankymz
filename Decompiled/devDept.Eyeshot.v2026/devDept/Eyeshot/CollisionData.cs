using System.Collections.Generic;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot;

public struct CollisionData
{
	public Transformation Transformation;

	public string ParentName;

	public Stack<BlockReference> Parents;

	public Entity Entity;
}
