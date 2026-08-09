using System;
using devDept.Eyeshot.Fem;
using devDept.Geometry;

namespace devDept.Eyeshot.Entities;

[Obsolete("Use FemMesh.CreateRectangle instead.")]
public class RectangularFemMesh : FemMesh
{
	public RectangularFemMesh(double width, double height)
		: this(0.0, 0.0, width, height)
	{
	}

	public RectangularFemMesh(double x, double y, double width, double height)
		: base(4, 1)
	{
		Vertices = new Point3D[4]
		{
			new Node(x, y),
			new Node(x + width, y),
			new Node(x + width, y + height),
			new Node(x, y + height)
		};
		base.Elements = new Element[1]
		{
			new Quad4(0, 1, 2, 3, Material.StructuralSteel)
		};
	}
}
