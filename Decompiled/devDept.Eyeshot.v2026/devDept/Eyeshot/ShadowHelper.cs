using System.Collections.Generic;
using devDept.Eyeshot.Entities;

namespace devDept.Eyeshot;

internal class ShadowHelper
{
	public static void DrawTrianglesForPlanarShadow(RenderParams renderParams, IList<Entity> entList)
	{
		for (int i = 0; i < entList.Count; i++)
		{
			Entity entity = entList[i];
			if (renderParams.Layers[entity.LayerName].Visible && entity.GetVisibility(renderParams.Parents) && entity.regenMode == regenType.NotNeeded)
			{
				entity.DrawForShadow(renderParams);
			}
		}
	}
}
