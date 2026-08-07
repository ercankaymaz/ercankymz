// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntitiesGroup
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class buEntitiesGroup : buSerilization5
{
  public Length3D ScreenSize;
  public List<Entity> Outside;
  public List<List<Entity>> Inside;
  public buEntityList Outside;
  public List<buEntityList> Inside;
  public List<buEntityList> OpenEntities;

  public buEntitiesGroup(screenInfo Data)
  {
    ((screenInfo) this).pntMin = new Point3D();
    ((EntitiesGroup) this).pntMax = new Point3D();
    ((EntitiesGroup) this).pntCurrent = new Point3D();
    this.ScreenSize = new Length3D();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) Data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public buEntitiesGroup()
  {
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    this.Outside = new List<Entity>();
    this.Inside = new List<List<Entity>>();
  }

  public buEntitiesGroup(EntitiesGroup data)
  {
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null))
      return;
    if (this.GetType() == CopiedClass.GetType())
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
    this.Outside = new List<Entity>();
    this.Inside = new List<List<Entity>>();
    buVector5.CopyEntities(((buEntitiesGroup) data).Outside, ref this.Outside);
    buVector5.CopyEntities(((buEntitiesGroup) data).Inside, ref this.Inside);
  }

  public buEntitiesGroup()
  {
    ((DimensionGroup) this).TempEntities = (List<buEntityList>) null;
    ((DimensionGroup) this).Text = (buEntityList) null;
    ((DimensionGroup) this).Solid = (buEntityList) null;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    this.Outside = (buEntityList) new buArcCam();
    this.Inside = new List<buEntityList>();
  }

  public buEntitiesGroup(buEntitiesGroup data)
  {
    ((DimensionGroup) this).TempEntities = (List<buEntityList>) null;
    ((DimensionGroup) this).Text = (buEntityList) null;
    ((DimensionGroup) this).Solid = (buEntityList) null;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object obj = new object();
    if (!(this != null & data != null))
      return;
    if (data.Outside != null)
    {
      this.Outside = (buEntityList) new buArcCam(data.Outside);
      if (((\u0084.\u0001) data.Outside).Points != null)
      {
        ((\u0084.\u0001) this.Outside).Points = new List<Point3D>();
        buVector5.Copy(((\u0084.\u0001) data.Outside).Points, ref ((\u0084.\u0001) this.Outside).Points);
      }
    }
    if (((DimensionGroup) data).Text != null)
    {
      ((DimensionGroup) this).Text = (buEntityList) new buArcCam(((DimensionGroup) data).Text);
      if (((\u0084.\u0001) ((DimensionGroup) data).Text).Points != null)
      {
        ((\u0084.\u0001) ((DimensionGroup) this).Text).Points = new List<Point3D>();
        buVector5.Copy(((\u0084.\u0001) ((DimensionGroup) data).Text).Points, ref ((\u0084.\u0001) ((DimensionGroup) this).Text).Points);
      }
    }
    if (((DimensionGroup) data).Solid != null)
    {
      ((DimensionGroup) this).Solid = (buEntityList) new buArcCam(((DimensionGroup) data).Solid);
      if (((\u0084.\u0001) ((DimensionGroup) data).Solid).Points != null)
      {
        ((\u0084.\u0001) ((DimensionGroup) this).Solid).Points = new List<Point3D>();
        buVector5.Copy(((\u0084.\u0001) ((DimensionGroup) data).Solid).Points, ref ((\u0084.\u0001) ((DimensionGroup) this).Solid).Points);
      }
    }
    if (data.Inside != null)
    {
      this.Inside = new List<buEntityList>();
      for (int index = 0; index <= data.Inside.Count - 1; ++index)
      {
        buEntityList buEntityList = (buEntityList) new buArcCam(data.Inside[index]);
        if (((\u0084.\u0001) data.Inside[index]).Points != null)
        {
          ((\u0084.\u0001) buEntityList).Points = new List<Point3D>();
          buVector5.Copy(((\u0084.\u0001) data.Inside[index]).Points, ref ((\u0084.\u0001) buEntityList).Points);
        }
        this.Inside.Add(buEntityList);
      }
    }
    if (data.OpenEntities != null)
    {
      this.OpenEntities = new List<buEntityList>();
      for (int index = 0; index <= data.OpenEntities.Count - 1; ++index)
      {
        buEntityList buEntityList = (buEntityList) new buArcCam(data.OpenEntities[index]);
        if (((\u0084.\u0001) data.OpenEntities[index]).Points != null)
        {
          ((\u0084.\u0001) buEntityList).Points = new List<Point3D>();
          buVector5.Copy(((\u0084.\u0001) data.OpenEntities[index]).Points, ref ((\u0084.\u0001) buEntityList).Points);
        }
        this.OpenEntities.Add(buEntityList);
      }
    }
    if (((DimensionGroup) data).TempEntities == null)
      return;
    ((DimensionGroup) this).TempEntities = new List<buEntityList>();
    for (int index = 0; index <= ((DimensionGroup) data).TempEntities.Count - 1; ++index)
    {
      buEntityList buEntityList = (buEntityList) new buArcCam(((DimensionGroup) data).TempEntities[index]);
      if (((\u0084.\u0001) ((DimensionGroup) data).TempEntities[index]).Points != null)
      {
        ((\u0084.\u0001) buEntityList).Points = new List<Point3D>();
        buVector5.Copy(((\u0084.\u0001) ((DimensionGroup) data).TempEntities[index]).Points, ref ((\u0084.\u0001) buEntityList).Points);
      }
      ((DimensionGroup) this).TempEntities.Add(buEntityList);
    }
  }

  public void Translate(double dX, double dY, double dZ = 0.0)
  {
    if (this.Outside != null)
      ((buArcCam) this.Outside).Translate(dX, dY, dZ);
    if (this.Inside != null)
    {
      for (int index = 0; index <= this.Inside.Count - 1; ++index)
        ((buArcCam) this.Inside[index]).Translate(dX, dY, dZ);
    }
    if (this.OpenEntities != null)
    {
      for (int index = 0; index <= this.OpenEntities.Count - 1; ++index)
        ((buArcCam) this.OpenEntities[index]).Translate(dX, dY, dZ);
    }
    if (((DimensionGroup) this).TempEntities != null)
    {
      for (int index = 0; index <= ((DimensionGroup) this).TempEntities.Count - 1; ++index)
        ((buArcCam) ((DimensionGroup) this).TempEntities[index]).Translate(dX, dY, dZ);
    }
    if (((DimensionGroup) this).Text != null)
      ((buArcCam) ((DimensionGroup) this).Text).Translate(dX, dY, dZ);
    if (((DimensionGroup) this).Solid == null)
      return;
    ((buArcCam) ((DimensionGroup) this).Solid).Translate(dX, dY, dZ);
  }

  public void Rotate(double Angle, Vector3D axis, Point3D center)
  {
    if (this.Outside != null)
      ((buArcCam) this.Outside).Rotate(Angle, axis, center);
    if (this.Inside != null)
    {
      for (int index = 0; index <= this.Inside.Count - 1; ++index)
        ((buArcCam) this.Inside[index]).Rotate(Angle, axis, center);
    }
    if (this.OpenEntities != null)
    {
      for (int index = 0; index <= this.OpenEntities.Count - 1; ++index)
        ((buArcCam) this.OpenEntities[index]).Rotate(Angle, axis, center);
    }
    if (((DimensionGroup) this).TempEntities != null)
    {
      for (int index = 0; index <= ((DimensionGroup) this).TempEntities.Count - 1; ++index)
        ((buArcCam) ((DimensionGroup) this).TempEntities[index]).Rotate(Angle, axis, center);
    }
    if (((DimensionGroup) this).Text != null)
      ((buArcCam) ((DimensionGroup) this).Text).Rotate(Angle, axis, center);
    if (((DimensionGroup) this).Solid == null)
      return;
    ((buArcCam) ((DimensionGroup) this).Solid).Rotate(Angle, axis, center);
  }

  public static void Copy(List<buEntitiesGroup> refGroup, ref List<buEntitiesGroup> copiesGroup)
  {
    copiesGroup = new List<buEntitiesGroup>();
    for (int index = 0; index <= refGroup.Count - 1; ++index)
    {
      if (refGroup[index] != null)
        copiesGroup.Add(new buEntitiesGroup(refGroup[index]));
    }
  }

  public static void ToDefGroup(
    buEntitiesGroup Group,
    int Space,
    ref ArrayList AL,
    string refChar = "")
  {
    AL = new ArrayList();
    AL.Add((object) $"{buImage5.SpaceChar(Space)}<buEntitiesGroupData{refChar}>");
    AL.Add((object) (buImage5.SpaceChar(Space + 2) + "<buEntitiesGroupOutside>"));
    AL.AddRange((ICollection) buArcCam.ToDefEntity(Group.Outside, Space + 4));
    AL.Add((object) (buImage5.SpaceChar(Space + 2) + "</buEntitiesGroupOutside>"));
    if ((Group.Inside == null ? 0 : (Group.Inside.Count > 0 ? 1 : 0)) != 0)
    {
      AL.Add((object) (buImage5.SpaceChar(Space + 2) + "<buEntitiesGroupInside>"));
      for (int index = 0; index <= Group.Inside.Count - 1; ++index)
      {
        AL.Add((object) (buImage5.SpaceChar(Space + 4) + "<buEntitiesGroupInsideItem>"));
        AL.AddRange((ICollection) buArcCam.ToDefEntity(Group.Inside[index], Space + 6));
        AL.Add((object) (buImage5.SpaceChar(Space + 4) + "</buEntitiesGroupInsideItem>"));
      }
      AL.Add((object) (buImage5.SpaceChar(Space + 2) + "</buEntitiesGroupInside>"));
    }
    if ((Group.OpenEntities == null ? 0 : (Group.OpenEntities.Count > 0 ? 1 : 0)) != 0)
    {
      AL.Add((object) (buImage5.SpaceChar(Space + 2) + "<buEntitiesGroupOpenEntities>"));
      for (int index = 0; index <= Group.OpenEntities.Count - 1; ++index)
      {
        AL.Add((object) (buImage5.SpaceChar(Space + 4) + "<buEntitiesGroupOpenEntitiesItem>"));
        AL.AddRange((ICollection) buArcCam.ToDefEntity(Group.OpenEntities[index], Space + 6));
        AL.Add((object) (buImage5.SpaceChar(Space + 4) + "</buEntitiesGroupOpenEntitiesItem>"));
      }
      AL.Add((object) (buImage5.SpaceChar(Space + 2) + "</buEntitiesGroupOpenEntities>"));
    }
    if ((((DimensionGroup) Group).Text == null ? 0 : (((\u0084.\u0001) ((DimensionGroup) Group).Text).Entities.Count > 0 ? 1 : 0)) != 0)
    {
      AL.Add((object) (buImage5.SpaceChar(Space + 2) + "<buEntitiesGroupText>"));
      AL.AddRange((ICollection) buArcCam.ToDefEntity(((DimensionGroup) Group).Text, Space + 4));
      AL.Add((object) (buImage5.SpaceChar(Space + 2) + "</buEntitiesGroupText>"));
    }
    AL.Add((object) $"{buImage5.SpaceChar(Space)}</buEntitiesGroupData{refChar}>");
  }
}
