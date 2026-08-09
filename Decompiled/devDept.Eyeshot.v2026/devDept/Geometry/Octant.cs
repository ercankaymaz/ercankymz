using devDept.Eyeshot.Entities;

namespace devDept.Geometry;

public class Octant : QuadEntityDataNode
{
	public Octant(Point3D boxMin, Point3D boxMax, Octree root)
		: base(boxMin, boxMax, root)
	{
	}

	public Octant(Point3D boxMin, Point3D boxMax, Octree root, int elementCount)
		: base(boxMin, boxMax, root, elementCount)
	{
	}

	protected internal override void createChildren()
	{
		QuadEntityDataNode[] array = new Octant[8];
		children = array;
		Point3D point3D = (Point3D)localMin;
		Point3D point3D2 = (Point3D)localMax;
		Point3D boxMin = point3D;
		Point3D boxMax = Point3D.MidPoint(point3D, point3D2);
		children[0] = new Octant(boxMin, boxMax, (Octree)root);
		double num = (point3D2.X - point3D.X) / 2.0;
		double num2 = (point3D2.Y - point3D.Y) / 2.0;
		double num3 = (point3D2.Z - point3D.Z) / 2.0;
		boxMin = new Point3D(point3D.X + num, point3D.Y, point3D.Z);
		boxMax = new Point3D(point3D2.X, point3D.Y + num2, point3D.Z + num3);
		children[1] = new Octant(boxMin, boxMax, (Octree)root);
		boxMin = new Point3D(point3D.X + num, point3D.Y + num2, point3D.Z);
		boxMax = new Point3D(point3D2.X, point3D2.Y, point3D.Z + num3);
		children[2] = new Octant(boxMin, boxMax, (Octree)root);
		boxMin = new Point3D(point3D.X, point3D.Y + num2, point3D.Z);
		boxMax = new Point3D(point3D.X + num, point3D2.Y, point3D.Z + num3);
		children[3] = new Octant(boxMin, boxMax, (Octree)root);
		boxMin = new Point3D(point3D.X, point3D.Y, point3D.Z + num3);
		boxMax = new Point3D(point3D.X + num, point3D.Y + num2, point3D2.Z);
		children[4] = new Octant(boxMin, boxMax, (Octree)root);
		boxMin = new Point3D(point3D.X + num, point3D.Y, point3D.Z + num3);
		boxMax = new Point3D(point3D2.X, point3D.Y + num2, point3D2.Z);
		children[5] = new Octant(boxMin, boxMax, (Octree)root);
		boxMin = Point3D.MidPoint(point3D, point3D2);
		boxMax = point3D2;
		children[6] = new Octant(boxMin, boxMax, (Octree)root);
		boxMin = new Point3D(point3D.X, point3D.Y + num2, point3D.Z + num3);
		boxMax = new Point3D(point3D.X + num, point3D2.Y, point3D2.Z);
		children[7] = new Octant(boxMin, boxMax, (Octree)root);
	}

	protected internal override bool IsElemInsideNode(int elemIndex)
	{
		Mesh mesh = (Mesh)root._0023_003DzHzDfhpY_003D;
		IndexTriangle[] triangles = mesh.Triangles;
		if (IsPointInside(mesh.Vertices[triangles[elemIndex].V1]) && IsPointInside(mesh.Vertices[triangles[elemIndex].V2]))
		{
			return IsPointInside(mesh.Vertices[triangles[elemIndex].V3]);
		}
		return false;
	}

	public bool IsPointInside(Point3D point)
	{
		if (point.X >= localMin.X && point.X <= localMax.X && point.Y >= localMin.Y && point.Y <= localMax.Y && point.Z >= ((Point3D)localMin).Z)
		{
			return point.Z <= ((Point3D)localMax).Z;
		}
		return false;
	}
}
