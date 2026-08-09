using System.Collections.Generic;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5;

public class SelectionEntity
{
	public int Index = -1;

	public int SubIndex = -1;

	public Entity SelectedEntity = null;

	public Entity SelectedSubEntity = null;

	public List<Entity> SelectedLinearPaths = null;

	public List<List<Point3D>> SelectedVertices = new List<List<Point3D>>();

	public Point3D BoxMin = new Point3D();

	public Point3D BoxMax = new Point3D();

	public Point3D pntClick = new Point3D();

	public Point3D pntClickEntityOver = null;

	public List<Point3D> EntitiesBoxPointList = new List<Point3D>();

	public SelectionAlingmentPoints AlingPoints = new SelectionAlingmentPoints();

	public SelectionEntity()
	{
	}

	public SelectionEntity(int index)
	{
		Index = index;
	}

	public override string ToString()
	{
		return "Index: " + Index;
	}
}
