using System;
using System.Collections.Generic;
using buEyeBaseVer5.buEntities;

namespace buEyeBaseVer5;

[Serializable]
public class EntitiesList : buSerilization5
{
	public List<buEntity> Entities = new List<buEntity>();

	public EntitiesList()
	{
	}

	public EntitiesList(EntitiesList contourpoints)
	{
		for (int i = 0; i <= contourpoints.Entities.Count - 1; i++)
		{
			buEntity copiedEntity = null;
			buEntity.Copy(contourpoints.Entities[i], ref copiedEntity);
			if (copiedEntity != null)
			{
				Entities.Add(copiedEntity);
			}
		}
	}

	public override string ToString()
	{
		string text = "";
		return "Entities Count: " + Entities.Count;
	}
}
