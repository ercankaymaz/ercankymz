using System.Collections.Generic;
using devDept.Geometry;

namespace buEyeBaseVer5;

public class SelectionOperation
{
	public List<SelectionEntity> Selections = new List<SelectionEntity>();

	public Point3D SelectionBoxMin = new Point3D();

	public Point3D SelectionBoxMid = new Point3D();

	public Point3D SelectionBoxMax = new Point3D();

	public List<Point3D> ClickList = new List<Point3D>();
}
