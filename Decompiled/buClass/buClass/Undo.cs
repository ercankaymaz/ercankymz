using System;
using System.Collections.Generic;
using buClass.Apps;

namespace buClass;

[Serializable]
public class Undo : buSerilization
{
	public List<eEntities> Entities = new List<eEntities>();

	public List<eEntities> TempEntities = new List<eEntities>();

	public List<camBase> Cams = new List<camBase>();

	public DiemakerPageProp DiemakerProp = null;

	public List<ProfileJob> ProfileJobs = null;

	public Undo()
	{
	}

	public Undo(Undo undo)
	{
		Cams.Clear();
		Entities.Clear();
		TempEntities.Clear();
		for (int i = 0; i <= undo.Entities.Count - 1; i++)
		{
			eEntities copiedEnt = new eEntities();
			eEntities.CopyEntity(undo.Entities[i], ref copiedEnt);
			Entities.Add(copiedEnt);
		}
		for (int j = 0; j <= undo.Cams.Count - 1; j++)
		{
			camBase copiedCam = new camBase();
			camBase.CopyCam(undo.Cams[j], ref copiedCam);
			Cams.Add(copiedCam);
		}
		if (undo.DiemakerProp != null)
		{
			DiemakerProp = new DiemakerPageProp(undo.DiemakerProp);
		}
		if (undo.ProfileJobs != null)
		{
			ProfileJobs = new List<ProfileJob>();
			for (int k = 0; k <= undo.ProfileJobs.Count - 1; k++)
			{
				ProfileJob item = new ProfileJob(undo.ProfileJobs[k]);
				ProfileJobs.Add(item);
			}
		}
	}

	public Undo(List<eEntities> Entities, List<camBase> Cams)
	{
		for (int i = 0; i <= Entities.Count - 1; i++)
		{
			eEntities copiedEnt = new eEntities();
			eEntities.CopyEntity(Entities[i], ref copiedEnt);
			this.Entities.Add(copiedEnt);
		}
		for (int j = 0; j <= Cams.Count - 1; j++)
		{
			camBase copiedCam = new camBase();
			camBase.CopyCam(Cams[j], ref copiedCam);
			this.Cams.Add(copiedCam);
		}
	}

	public Undo(List<eEntities> Entities, List<camBase> Cams, DiemakerPageProp Diemaker)
	{
		for (int i = 0; i <= Entities.Count - 1; i++)
		{
			eEntities copiedEnt = new eEntities();
			eEntities.CopyEntity(Entities[i], ref copiedEnt);
			this.Entities.Add(copiedEnt);
		}
		for (int j = 0; j <= Cams.Count - 1; j++)
		{
			camBase copiedCam = new camBase();
			camBase.CopyCam(Cams[j], ref copiedCam);
			this.Cams.Add(copiedCam);
		}
		if (Diemaker != null)
		{
			DiemakerProp = new DiemakerPageProp(Diemaker);
		}
	}

	public Undo(List<eEntities> Entities, List<camBase> Cams, List<ProfileJob> JobProfile)
	{
		for (int i = 0; i <= Entities.Count - 1; i++)
		{
			eEntities copiedEnt = new eEntities();
			eEntities.CopyEntity(Entities[i], ref copiedEnt);
			this.Entities.Add(copiedEnt);
		}
		for (int j = 0; j <= Cams.Count - 1; j++)
		{
			camBase copiedCam = new camBase();
			camBase.CopyCam(Cams[j], ref copiedCam);
			this.Cams.Add(copiedCam);
		}
		if (JobProfile != null)
		{
			ProfileJobs = new List<ProfileJob>();
			for (int k = 0; k <= JobProfile.Count - 1; k++)
			{
				ProfileJob item = new ProfileJob(JobProfile[k]);
				ProfileJobs.Add(item);
			}
		}
	}
}
