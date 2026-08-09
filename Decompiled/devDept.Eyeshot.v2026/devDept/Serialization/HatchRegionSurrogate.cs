using System.Collections.Generic;
using System.Linq;
using devDept.Eyeshot.Entities;

namespace devDept.Serialization;

internal class HatchRegionSurrogate : RegionSurrogate
{
	public string HatchName;

	public double HatchScale;

	public double HatchAngle;

	public HatchRegionSurrogate(Region hatchRegion)
		: base(hatchRegion)
	{
	}

	protected override Entity ConvertToObject()
	{
		if (base.Content == contentType.Tessellation)
		{
			return CreateMeshOrGhostEntity(Vertices, Triangles, typeof(Hatch));
		}
		Hatch hatch = new Hatch(string.IsNullOrEmpty(HatchName) ? _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970485) : HatchName, new List<ICurve>(), Plane);
		CopyDataToObject(hatch);
		return hatch;
	}

	protected override void CopyDataToObject(Entity entity)
	{
		if (entity is Hatch hatch)
		{
			hatch.contourList = ContourList.Cast<ICurve>().ToList();
			hatch.Vertices = Vertices;
			hatch.Triangles = Triangles;
			hatch.PatternScale = (float)HatchScale;
			hatch.PatternAngle = HatchAngle;
		}
		base.CopyDataToObject(entity);
	}
}
