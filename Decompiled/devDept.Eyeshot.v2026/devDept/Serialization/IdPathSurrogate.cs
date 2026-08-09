using System.Collections.Generic;
using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

public class IdPathSurrogate : Surrogate<IdPath>
{
	public List<Id> Paths;

	public IdPathSurrogate(IdPath idPath)
		: base(idPath)
	{
	}

	protected override IdPath ConvertToObject()
	{
		IdPath idPath = new IdPath();
		CopyDataToObject(idPath);
		return idPath;
	}

	protected override void CopyDataToObject(IdPath idPath)
	{
		idPath.path = Paths;
	}

	protected override void CopyDataFromObject(IdPath idPath)
	{
		Paths = idPath.path;
	}

	public static implicit operator IdPath(IdPathSurrogate surrogate)
	{
		return surrogate?.ConvertToObject();
	}

	public static implicit operator IdPathSurrogate(IdPath source)
	{
		return source?.ConvertToSurrogate();
	}
}
