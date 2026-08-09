using System;
using System.Collections.Generic;
using buClass;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;

namespace buCadCamResVer5;

[Serializable]
public class UndoV5 : buSerilization
{
	public List<Block> Blocks = new List<Block>();

	public EntityList Entities = new EntityList();

	public List<camTp> Cams = new List<camTp>();

	public List<OsnapPoint> Osnaps = new List<OsnapPoint>();

	public ProfileBase Profiles = null;

	public UndoV5()
	{
	}

	public UndoV5(UndoV5 undo)
	{
		Cams.Clear();
		Entities.Clear();
		Blocks.Clear();
		Osnaps.Clear();
		for (int i = 0; i <= undo.Entities.Count - 1; i++)
		{
			Entity entity = buVector5.CopyEntities(undo.Entities[i]);
			if (entity.EntityData == null)
			{
				CustomData entityData = new CustomData();
				entity.EntityData = entityData;
			}
			Entities.Add(entity);
		}
		for (int j = 0; j <= undo.Blocks.Count - 1; j++)
		{
			Block item = (Block)undo.Blocks[j].Clone();
			Blocks.Add(item);
		}
		for (int k = 0; k <= undo.Cams.Count - 1; k++)
		{
			camTp copiedCam = new camTp();
			camTp.CopyCam(undo.Cams[k], ref copiedCam);
			Cams.Add(copiedCam);
		}
		for (int l = 0; l <= undo.Osnaps.Count - 1; l++)
		{
			OsnapPoint item2 = new OsnapPoint(undo.Osnaps[l], undo.Osnaps[l].Type, undo.Osnaps[l].EntName, undo.Osnaps[l].LayerName, undo.Osnaps[l].OtherEntName);
			Osnaps.Add(item2);
		}
		if (undo.Profiles != null)
		{
			Profiles = new ProfileBase(undo.Profiles);
		}
	}

	public UndoV5(EntityList Entities, List<camTp> Cams)
	{
		for (int i = 0; i <= Entities.Count - 1; i++)
		{
			Entity entity = buVector5.CopyEntities(Entities[i]);
			if (entity.EntityData == null)
			{
				CustomData entityData = new CustomData();
				entity.EntityData = entityData;
			}
			this.Entities.Add(entity);
		}
		for (int j = 0; j <= Cams.Count - 1; j++)
		{
			camTp copiedCam = new camTp();
			camTp.CopyCam(Cams[j], ref copiedCam);
			this.Cams.Add(copiedCam);
		}
	}

	public UndoV5(EntityList Entities, List<camTp> Cams, List<OsnapPoint> osnaps, ProfileBase profiles)
	{
		try
		{
			for (int i = 0; i <= Entities.Count - 1; i++)
			{
				Entity entity = buVector5.CopyEntities(Entities[i]);
				if (entity.EntityData == null)
				{
					CustomData entityData = new CustomData();
					entity.EntityData = entityData;
				}
				this.Entities.Add(entity);
			}
			for (int j = 0; j <= Cams.Count - 1; j++)
			{
				camTp copiedCam = new camTp();
				camTp.CopyCam(Cams[j], ref copiedCam);
				this.Cams.Add(copiedCam);
			}
			for (int k = 0; k <= osnaps.Count - 1; k++)
			{
				if (osnaps[k] != null)
				{
					OsnapPoint item = new OsnapPoint(osnaps[k], osnaps[k].Type, osnaps[k].EntName, osnaps[k].LayerName, osnaps[k].OtherEntName);
					Osnaps.Add(item);
				}
			}
			if (profiles != null)
			{
				Profiles = new ProfileBase(profiles);
			}
		}
		catch (Exception)
		{
		}
	}
}
