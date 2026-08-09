using System.Collections.Generic;
using buEyeBaseVer5.buEntities;

namespace buEyeBaseVer5;

public class SelectionEntityTypes
{
	public List<buEntity> entitiesPoint = null;

	public List<buEntity> entitiesCurve = null;

	public List<buEntity> entitiesText = null;

	public List<buEntity> entitiesSolid = null;

	public List<buEntity> entitiesDimension = null;

	public List<buEntity> entitiesImage = null;

	public SelectionEntityTypes()
	{
		entitiesPoint = new List<buEntity>();
		entitiesCurve = new List<buEntity>();
		entitiesText = new List<buEntity>();
		entitiesSolid = new List<buEntity>();
		entitiesDimension = new List<buEntity>();
		entitiesImage = new List<buEntity>();
	}
}
