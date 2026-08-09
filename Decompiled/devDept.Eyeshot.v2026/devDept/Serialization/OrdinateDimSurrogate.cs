using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public class OrdinateDimSurrogate : DimensionSurrogate
{
	public Point3D DefiningPoint;

	public bool IsVertical;

	public double ExtLineOffset;

	public OrdinateDimSurrogate(OrdinateDim ordinateDim)
		: base(ordinateDim)
	{
	}

	protected override Entity ConvertToObject()
	{
		OrdinateDim ordinateDim = new OrdinateDim(this);
		CopyDataToObject(ordinateDim);
		return ordinateDim;
	}

	protected override void CopyDataToObject(Entity entity)
	{
		OrdinateDim obj = entity as OrdinateDim;
		obj.DefiningPoint = DefiningPoint;
		obj._0023_003Dzde_LaNn_Kpwh(IsVertical);
		obj.ExtLineOffset = ExtLineOffset;
		base.CopyDataToObject(entity);
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		OrdinateDim ordinateDim = entity as OrdinateDim;
		DefiningPoint = ordinateDim.DefiningPoint;
		IsVertical = ordinateDim.IsVertical;
		ExtLineOffset = ordinateDim.ExtLineOffset;
		base.CopyDataFromObject(entity);
	}
}
