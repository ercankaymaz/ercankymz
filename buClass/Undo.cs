// Decompiled with JetBrains decompiler
// Type: buClass.Undo
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using buClass.Apps;
using System;
using System.Collections.Generic;

#nullable disable
namespace buClass;

[Serializable]
public class Undo : buSerilization
{
  public List<eEntities> Entities = new List<eEntities>();
  public List<eEntities> TempEntities = new List<eEntities>();
  public List<camBase> Cams = new List<camBase>();
  public DiemakerPageProp DiemakerProp = (DiemakerPageProp) null;
  public List<ProfileJob> ProfileJobs = (List<ProfileJob>) null;

  public Undo()
  {
  }

  public Undo(Undo undo)
  {
    this.Cams.Clear();
    this.Entities.Clear();
    this.TempEntities.Clear();
    for (int index = 0; index <= undo.Entities.Count - 1; ++index)
    {
      eEntities copiedEnt = new eEntities();
      eEntities.CopyEntity(undo.Entities[index], ref copiedEnt);
      this.Entities.Add(copiedEnt);
    }
    for (int index = 0; index <= undo.Cams.Count - 1; ++index)
    {
      camBase copiedCam = new camBase();
      camBase.CopyCam(undo.Cams[index], ref copiedCam);
      this.Cams.Add(copiedCam);
    }
    if (undo.DiemakerProp != null)
      this.DiemakerProp = new DiemakerPageProp(undo.DiemakerProp);
    if (undo.ProfileJobs == null)
      return;
    this.ProfileJobs = new List<ProfileJob>();
    for (int index = 0; index <= undo.ProfileJobs.Count - 1; ++index)
      this.ProfileJobs.Add(new ProfileJob(undo.ProfileJobs[index]));
  }

  public Undo(List<eEntities> Entities, List<camBase> Cams)
  {
    for (int index = 0; index <= Entities.Count - 1; ++index)
    {
      eEntities copiedEnt = new eEntities();
      eEntities.CopyEntity(Entities[index], ref copiedEnt);
      this.Entities.Add(copiedEnt);
    }
    for (int index = 0; index <= Cams.Count - 1; ++index)
    {
      camBase copiedCam = new camBase();
      camBase.CopyCam(Cams[index], ref copiedCam);
      this.Cams.Add(copiedCam);
    }
  }

  public Undo(List<eEntities> Entities, List<camBase> Cams, DiemakerPageProp Diemaker)
  {
    for (int index = 0; index <= Entities.Count - 1; ++index)
    {
      eEntities copiedEnt = new eEntities();
      eEntities.CopyEntity(Entities[index], ref copiedEnt);
      this.Entities.Add(copiedEnt);
    }
    for (int index = 0; index <= Cams.Count - 1; ++index)
    {
      camBase copiedCam = new camBase();
      camBase.CopyCam(Cams[index], ref copiedCam);
      this.Cams.Add(copiedCam);
    }
    if (Diemaker == null)
      return;
    this.DiemakerProp = new DiemakerPageProp(Diemaker);
  }

  public Undo(List<eEntities> Entities, List<camBase> Cams, List<ProfileJob> JobProfile)
  {
    for (int index = 0; index <= Entities.Count - 1; ++index)
    {
      eEntities copiedEnt = new eEntities();
      eEntities.CopyEntity(Entities[index], ref copiedEnt);
      this.Entities.Add(copiedEnt);
    }
    for (int index = 0; index <= Cams.Count - 1; ++index)
    {
      camBase copiedCam = new camBase();
      camBase.CopyCam(Cams[index], ref copiedCam);
      this.Cams.Add(copiedCam);
    }
    if (JobProfile == null)
      return;
    this.ProfileJobs = new List<ProfileJob>();
    for (int index = 0; index <= JobProfile.Count - 1; ++index)
      this.ProfileJobs.Add(new ProfileJob(JobProfile[index]));
  }
}
