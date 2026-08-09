using System;
using devDept.Eyeshot.Entities;

namespace devDept.Eyeshot;

public struct CollisionResult
{
	public Tuple<CollisionData, CollisionData> CollidedEntities;

	public Entity[] CollisionItems;
}
