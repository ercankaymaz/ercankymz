using System.Collections.Generic;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buCadCamResVer5.Spinning;

public class SpinCalculatedData
{
	public List<Entity> CalculatedEntities = new List<Entity>();

	public Point3D StartPoint = new Point3D();

	public bool ReturnSameWay = false;

	public bool isFinished = false;

	public bool isMoveSafe = false;

	public double YOffset = 0.0;
}
