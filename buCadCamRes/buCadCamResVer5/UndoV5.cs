// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.UndoV5
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buClass;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;

#nullable disable
namespace buCadCamResVer5;

[Serializable]
public class UndoV5 : buSerilization
{
  public List<Block> Blocks = new List<Block>();
  public EntityList Entities = new EntityList();
  public List<camTp> Cams = new List<camTp>();
  public List<OsnapPoint> Osnaps = new List<OsnapPoint>();
  public ProfileBase Profiles = (ProfileBase) null;

  public UndoV5()
  {
  }

  public UndoV5(UndoV5 undo)
  {
    this.Cams.Clear();
    this.Entities.Clear();
    this.Blocks.Clear();
    this.Osnaps.Clear();
    for (int index = 0; index <= undo.Entities.Count - 1; ++index)
    {
      Entity entity = buVector5.CopyEntities(undo.Entities[index]);
      if (entity.EntityData == null)
      {
        CustomData customData = new CustomData();
        entity.EntityData = (object) customData;
      }
      this.Entities.Add(entity);
    }
    for (int index = 0; index <= undo.Blocks.Count - 1; ++index)
      this.Blocks.Add((Block) undo.Blocks[index].Clone());
    for (int index = 0; index <= undo.Cams.Count - 1; ++index)
    {
      camTp copiedCam = new camTp();
      camTp.CopyCam(undo.Cams[index], ref copiedCam);
      this.Cams.Add(copiedCam);
    }
    for (int index = 0; index <= undo.Osnaps.Count - 1; ++index)
      this.Osnaps.Add(new OsnapPoint((Point3D) undo.Osnaps[index], undo.Osnaps[index].Type, undo.Osnaps[index].EntName, undo.Osnaps[index].LayerName, undo.Osnaps[index].OtherEntName));
    if (undo.Profiles == null)
      return;
    this.Profiles = new ProfileBase(undo.Profiles);
  }

  public UndoV5(EntityList Entities, List<camTp> Cams)
  {
    for (int index = 0; index <= Entities.Count - 1; ++index)
    {
      Entity entity = buVector5.CopyEntities(Entities[index]);
      if (entity.EntityData == null)
      {
        CustomData customData = new CustomData();
        entity.EntityData = (object) customData;
      }
      this.Entities.Add(entity);
    }
    for (int index = 0; index <= Cams.Count - 1; ++index)
    {
      camTp copiedCam = new camTp();
      camTp.CopyCam(Cams[index], ref copiedCam);
      this.Cams.Add(copiedCam);
    }
  }

  public UndoV5(
    EntityList Entities,
    List<camTp> Cams,
    List<OsnapPoint> osnaps,
    ProfileBase profiles)
  {
    try
    {
      for (int index = 0; index <= Entities.Count - 1; ++index)
      {
        Entity entity = buVector5.CopyEntities(Entities[index]);
        if (entity.EntityData == null)
        {
          CustomData customData = new CustomData();
          entity.EntityData = (object) customData;
        }
        this.Entities.Add(entity);
      }
      for (int index = 0; index <= Cams.Count - 1; ++index)
      {
        camTp copiedCam = new camTp();
        camTp.CopyCam(Cams[index], ref copiedCam);
        this.Cams.Add(copiedCam);
      }
      for (int index = 0; index <= osnaps.Count - 1; ++index)
      {
        if ((Point3D) osnaps[index] != (Point3D) null)
          this.Osnaps.Add(new OsnapPoint((Point3D) osnaps[index], osnaps[index].Type, osnaps[index].EntName, osnaps[index].LayerName, osnaps[index].OtherEntName));
      }
      if (profiles == null)
        return;
      this.Profiles = new ProfileBase(profiles);
    }
    catch (Exception ex)
    {
    }
  }
}
