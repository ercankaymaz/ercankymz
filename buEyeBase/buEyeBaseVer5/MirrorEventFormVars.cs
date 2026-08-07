// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.MirrorEventFormVars
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Geometry;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

public class MirrorEventFormVars : buSerilization5
{
  public ContentAlignment Alignment;
  public Point3D CatchPoint;
  public bool ShowZ;
  public bool ShowAligment;

  public MirrorEventFormVars(ToolPositions5 data)
  {
    ((MoveEventFormVars) this).Position = new Pnt6D();
    ((MoveEventFormVars) this).Offset = new Pnt6D();
    ((MoveEventFormVars) this).CommonOffset = new Pnt6D();
    ((MoveEventFormVars) this).AngularPosition = 0.0;
    ((ScaleEventFormVars) this).Location = ToolLocationType.None;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
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

  public MirrorEventFormVars(ToolPositions data)
  {
    ((MoveEventFormVars) this).Position = new Pnt6D();
    ((MoveEventFormVars) this).Offset = new Pnt6D();
    ((MoveEventFormVars) this).CommonOffset = new Pnt6D();
    ((MoveEventFormVars) this).AngularPosition = 0.0;
    ((ScaleEventFormVars) this).Location = ToolLocationType.None;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
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
}
