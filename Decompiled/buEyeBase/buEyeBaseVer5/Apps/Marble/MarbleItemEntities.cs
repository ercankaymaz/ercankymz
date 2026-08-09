using System;
using System.Collections.Generic;
using System.Reflection;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleItemEntities : buSerilization5
{
	public List<Entity> SolidEntity = null;

	public List<Entity> SolidInsideEntity = null;

	public List<buEntity> TextEntities = null;

	public List<buEntity> DrawWireEntities = null;

	public List<buEntity> SourceEntities = null;

	public List<List<buEntity>> WireEntities = null;

	public List<buEntity> ExtensionEntities = null;

	public List<buEntity> EdgeEntities = null;

	public List<buEntity> EngravingEntities = null;

	public List<buEntity> BaseEntities = null;

	public List<buEntity> BorderEntities = null;

	public List<buEntity> DrillEntities = null;

	public List<buEntitiesGroup> SurfaceEntities = null;

	public List<buEntitiesGroup> GroupEntities = null;

	public List<List<buEntity>> ConcaveEntities = null;

	public List<List<buEntity>> ConvexEntities = null;

	public List<List<buEntity>> CamEntities = null;

	public List<List<buEntityList>> SawEntities = null;

	public List<List<buEntityList>> MillingEntities = null;

	public List<List<buEntityList>> WaterJetEntities = null;

	public List<List<buEntityList>> MillingHeadEntities = null;

	public MarbleItemEntities()
	{
	}

	public MarbleItemEntities(MarbleItemEntities data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null))
		{
			return;
		}
		if (GetType() == CopiedClass.GetType())
		{
			FieldInfo[] fields = GetType().GetFields();
			if (fields != null)
			{
				for (int i = 0; i <= fields.Length - 1; i++)
				{
					_ = fields[i].Name;
					object value = fields[i].GetValue(CopiedClass);
					fields[i].SetValue(this, value);
				}
			}
		}
		if (data.SurfaceEntities != null)
		{
			SurfaceEntities = new List<buEntitiesGroup>();
			buEntitiesGroup.Copy(data.SurfaceEntities, ref SurfaceEntities);
		}
		if (data.GroupEntities != null)
		{
			GroupEntities = new List<buEntitiesGroup>();
			buEntitiesGroup.Copy(data.GroupEntities, ref GroupEntities);
		}
		if (data.ExtensionEntities != null)
		{
			ExtensionEntities = new List<buEntity>();
			buEntity.Copy(data.ExtensionEntities, ref ExtensionEntities);
		}
		if (data.BorderEntities != null)
		{
			BorderEntities = new List<buEntity>();
			buEntity.Copy(data.BorderEntities, ref BorderEntities);
		}
		if (data.WireEntities != null)
		{
			WireEntities = new List<List<buEntity>>();
			buEntity.Copy(data.WireEntities, ref WireEntities);
		}
		if (data.TextEntities != null)
		{
			TextEntities = new List<buEntity>();
			buEntity.Copy(data.TextEntities, ref TextEntities);
		}
		if (data.EdgeEntities != null)
		{
			EdgeEntities = new List<buEntity>();
			buEntity.Copy(data.EdgeEntities, ref EdgeEntities);
		}
		if (data.EngravingEntities != null)
		{
			EngravingEntities = new List<buEntity>();
			buEntity.Copy(data.EngravingEntities, ref EngravingEntities);
		}
		if (data.ConcaveEntities != null)
		{
			ConcaveEntities = new List<List<buEntity>>();
			buEntity.Copy(data.ConcaveEntities, ref ConcaveEntities);
		}
		if (data.ConvexEntities != null)
		{
			ConvexEntities = new List<List<buEntity>>();
			buEntity.Copy(data.ConvexEntities, ref ConvexEntities);
		}
		if (data.CamEntities != null)
		{
			CamEntities = new List<List<buEntity>>();
			buEntity.Copy(data.CamEntities, ref CamEntities);
		}
		if (data.DrillEntities != null)
		{
			DrillEntities = new List<buEntity>();
			buEntity.Copy(data.DrillEntities, ref DrillEntities);
		}
		if (data.SourceEntities != null)
		{
			SourceEntities = new List<buEntity>();
			buEntity.Copy(data.SourceEntities, ref SourceEntities);
		}
		if (data.DrawWireEntities != null)
		{
			DrawWireEntities = new List<buEntity>();
			buEntity.Copy(data.DrawWireEntities, ref DrawWireEntities);
		}
		if (data.BaseEntities != null)
		{
			BaseEntities = new List<buEntity>();
			buEntity.Copy(data.BaseEntities, ref BaseEntities);
		}
		if (data.SolidEntity != null)
		{
			SolidEntity = new List<Entity>();
			SolidEntity = buVector5.CopyEntities(data.SolidEntity);
		}
		if (data.SolidInsideEntity != null)
		{
			SolidInsideEntity = new List<Entity>();
			SolidInsideEntity = buVector5.CopyEntities(data.SolidInsideEntity);
		}
		if (data.SawEntities != null)
		{
			buEntityList.Copy(data.SawEntities, ref SawEntities);
		}
		if (data.MillingEntities != null)
		{
			buEntityList.Copy(data.MillingEntities, ref MillingEntities);
		}
		if (data.WaterJetEntities != null)
		{
			buEntityList.Copy(data.WaterJetEntities, ref WaterJetEntities);
		}
		if (data.MillingHeadEntities != null)
		{
			buEntityList.Copy(data.MillingHeadEntities, ref MillingHeadEntities);
		}
	}

	public static void Copy(MarbleItemSettings refCam, ref MarbleItemSettings copiedCam)
	{
		if (refCam != null)
		{
			copiedCam = new MarbleItemSettings(refCam);
		}
	}

	public override string ToString()
	{
		string text = "";
		if (WireEntities != null)
		{
			text = "Wire: " + WireEntities.Count + " ";
		}
		if (BorderEntities != null)
		{
			text = text + "Border: " + BorderEntities.Count + " ";
		}
		if (ConcaveEntities != null)
		{
			text = text + "Concave: " + ConcaveEntities.Count + " ";
		}
		if (EngravingEntities != null)
		{
			text = text + "Engrave: " + EngravingEntities.Count + " ";
		}
		if (DrillEntities != null)
		{
			text = text + "Drill: " + DrillEntities.Count + " ";
		}
		return text;
	}
}
