// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.SortbuFoundItems
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Forms;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

public class SortbuFoundItems : buSerilization5
{
  public int Index;
  public camPathDirectionType Direction;
  public Point3D RefPoint;
  public Point3D StartPoint;
  public Point3D NextPoint;
  public Entity Entity;
  public static byte f00072E;

  public SortbuFoundItems(ObjectSize3D box)
  {
    ((ViewportDrawOptions) this).MinPoint = new Point3D();
    ((ViewportDrawOptions) this).MidPoint = new Point3D();
    ((ViewportDrawOptions) this).MaxPoint = new Point3D();
    ((ViewportDrawOptions) this).Width = 0.0;
    ((ViewportDrawOptions) this).Height = 0.0;
    ((ViewportDrawOptions) this).Depth = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) box, ref CopiedClass);
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

  public SortbuFoundItems(Point3D PMin, Point3D PMax)
  {
    ((ViewportDrawOptions) this).MinPoint = new Point3D();
    ((ViewportDrawOptions) this).MidPoint = new Point3D();
    ((ViewportDrawOptions) this).MaxPoint = new Point3D();
    ((ViewportDrawOptions) this).Width = 0.0;
    ((ViewportDrawOptions) this).Height = 0.0;
    ((ViewportDrawOptions) this).Depth = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((ViewportDrawOptions) this).MinPoint = F_NotchEdit.ToPoint3D(PMin);
    ((ViewportDrawOptions) this).MaxPoint = F_NotchEdit.ToPoint3D(PMax);
    ((ViewportDrawOptions) this).MidPoint = new Point3D((PMin.X + PMax.X) / 2.0, (PMin.Y + PMax.Y) / 2.0, (PMin.Z + PMax.Z) / 2.0);
    ((ViewportDrawOptions) this).Width = PMax.X - PMin.X;
    ((ViewportDrawOptions) this).Height = PMax.Y - PMin.Y;
    ((ViewportDrawOptions) this).Depth = PMax.Z - PMin.Z;
  }

  public static void CalculateSize(ref ObjectSize3D Obj, int Round = 5)
  {
    if (Round > 0)
    {
      ((ViewportDrawOptions) Obj).MinPoint.X = Math.Round(((ViewportDrawOptions) Obj).MinPoint.X, Round);
      ((ViewportDrawOptions) Obj).MinPoint.Y = Math.Round(((ViewportDrawOptions) Obj).MinPoint.Y, Round);
      ((ViewportDrawOptions) Obj).MinPoint.Z = Math.Round(((ViewportDrawOptions) Obj).MinPoint.Z, Round);
      ((ViewportDrawOptions) Obj).MaxPoint.X = Math.Round(((ViewportDrawOptions) Obj).MaxPoint.X, Round);
      ((ViewportDrawOptions) Obj).MaxPoint.Y = Math.Round(((ViewportDrawOptions) Obj).MaxPoint.Y, Round);
      ((ViewportDrawOptions) Obj).MaxPoint.Z = Math.Round(((ViewportDrawOptions) Obj).MaxPoint.Z, Round);
      ((ViewportDrawOptions) Obj).Width = Math.Round(((ViewportDrawOptions) Obj).MaxPoint.X - ((ViewportDrawOptions) Obj).MinPoint.X, Round);
      ((ViewportDrawOptions) Obj).Height = Math.Round(((ViewportDrawOptions) Obj).MaxPoint.Y - ((ViewportDrawOptions) Obj).MinPoint.Y, Round);
      ((ViewportDrawOptions) Obj).Depth = Math.Round(((ViewportDrawOptions) Obj).MaxPoint.Z - ((ViewportDrawOptions) Obj).MinPoint.Z, Round);
      ((ViewportDrawOptions) Obj).MidPoint.X = Math.Round((((ViewportDrawOptions) Obj).MinPoint.X + ((ViewportDrawOptions) Obj).MaxPoint.X) / 2.0, Round);
      ((ViewportDrawOptions) Obj).MidPoint.Y = Math.Round((((ViewportDrawOptions) Obj).MinPoint.Y + ((ViewportDrawOptions) Obj).MaxPoint.Y) / 2.0, Round);
      ((ViewportDrawOptions) Obj).MidPoint.Z = Math.Round((((ViewportDrawOptions) Obj).MinPoint.Z + ((ViewportDrawOptions) Obj).MaxPoint.Z) / 2.0, Round);
    }
    else
    {
      ((ViewportDrawOptions) Obj).Width = ((ViewportDrawOptions) Obj).MaxPoint.X - ((ViewportDrawOptions) Obj).MinPoint.X;
      ((ViewportDrawOptions) Obj).Height = ((ViewportDrawOptions) Obj).MaxPoint.Y - ((ViewportDrawOptions) Obj).MinPoint.Y;
      ((ViewportDrawOptions) Obj).Depth = ((ViewportDrawOptions) Obj).MaxPoint.Z - ((ViewportDrawOptions) Obj).MinPoint.Z;
      ((ViewportDrawOptions) Obj).MidPoint.X = (((ViewportDrawOptions) Obj).MinPoint.X + ((ViewportDrawOptions) Obj).MaxPoint.X) / 2.0;
      ((ViewportDrawOptions) Obj).MidPoint.Y = (((ViewportDrawOptions) Obj).MinPoint.Y + ((ViewportDrawOptions) Obj).MaxPoint.Y) / 2.0;
      ((ViewportDrawOptions) Obj).MidPoint.Z = (((ViewportDrawOptions) Obj).MinPoint.Z + ((ViewportDrawOptions) Obj).MaxPoint.Z) / 2.0;
    }
  }
}
