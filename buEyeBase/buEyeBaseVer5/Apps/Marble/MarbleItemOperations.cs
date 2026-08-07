// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.MarbleItemOperations
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleItemOperations : buSerilization5
{
  public bool ChangeCwCCWDirForRightRefProfile;
  public bool RightProfileActive;
  public bool NotchOperationAlwaysFirst;
  public bool NotchHorizontalUseMilling;
  public bool OperationEditChangeWithoutOk;
  public bool InsertOperationIfSamePositionAndSmallSize;
  public bool ShowBottomReferanceEntity;
  public bool ShowBackReferanceEntity;
  public bool LeftToRightCopyRotateKeyHole;
  public bool LeftToRightCopyChangeCamDirection;
  public bool NotchAlwaysSafeZ;

  public static void Copy(
    ProfileLengthClamperCount RefClamper,
    ref ProfileLengthClamperCount CopiedClamper)
  {
    CopiedClamper = (ProfileLengthClamperCount) new MarbleItemExtend(RefClamper);
  }

  public abstract void m001E8F();

  public MarbleItemOperations()
  {
    // ISSUE: reference to a compiler-generated field
    ((buMarbleCalc.\u0001) this).SolidEntity = (Entity) null;
    ((MarbleJob) this).OutterEntitites = new List<buEntity>();
    ((MarbleJob) this).InnerEntities = new List<List<buEntity>>();
    ((MarbleJob) this).OutterPoints = new List<Point3D>();
    ((MarbleJob) this).InnerPoints = new List<List<Point3D>>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public MarbleItemOperations(ProfileDrawings data)
  {
    // ISSUE: reference to a compiler-generated field
    ((buMarbleCalc.\u0001) this).SolidEntity = (Entity) null;
    ((MarbleJob) this).OutterEntitites = new List<buEntity>();
    ((MarbleJob) this).InnerEntities = new List<List<buEntity>>();
    ((MarbleJob) this).OutterPoints = new List<Point3D>();
    ((MarbleJob) this).InnerPoints = new List<List<Point3D>>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    if (data == null)
      return;
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (this != null & CopiedClass != null && this.GetType() == CopiedClass.GetType())
    {
      FieldInfo[] fields = this.GetType().GetFields();
      if (fields != null)
      {
        for (int index = 0; index <= fields.Length - 1; ++index)
        {
          string name = fields[index].Name;
          object obj = fields[index].GetValue(CopiedClass);
          fields[index].SetValue((object) this, obj);
        }
      }
    }
    // ISSUE: reference to a compiler-generated field
    if (((buMarbleCalc.\u0001) data).SolidEntity != null)
    {
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      ((buMarbleCalc.\u0001) this).SolidEntity = buVector5.CopyEntities(((buMarbleCalc.\u0001) data).SolidEntity);
    }
    if (((MarbleJob) data).OutterPoints != null)
    {
      ((MarbleJob) this).OutterPoints.Clear();
      ((MarbleJob) this).OutterPoints = new List<Point3D>();
      F_AnalyseResult.ToPoint3D(((MarbleJob) data).OutterPoints, ref ((MarbleJob) this).OutterPoints);
    }
    if (((MarbleJob) data).InnerPoints != null)
    {
      ((MarbleJob) this).InnerPoints.Clear();
      ((MarbleJob) this).InnerPoints = new List<List<Point3D>>();
      F_AnalyseResult.ToPoint3D(((MarbleJob) data).InnerPoints, ref ((MarbleJob) this).InnerPoints);
    }
    if (((MarbleJob) data).OutterEntitites != null)
    {
      ((MarbleJob) this).OutterEntitites.Clear();
      ((MarbleJob) this).OutterEntitites = new List<buEntity>();
      buRadialDim.Copy(((MarbleJob) data).OutterEntitites, ref ((MarbleJob) this).OutterEntitites);
    }
    if (((MarbleJob) data).InnerEntities == null)
      return;
    ((MarbleJob) this).InnerEntities.Clear();
    ((MarbleJob) this).InnerEntities = new List<List<buEntity>>();
    buRadialDim.Copy(((MarbleJob) data).InnerEntities, ref ((MarbleJob) this).InnerEntities);
  }
}
