// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.MyFileSerializer
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Serialization;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.buEntities;

public class MyFileSerializer : FileSerializer
{
  public static byte f003871;
  public List<IndexTriangle> Triangles;

  public MyFileSerializer(Line another)
  {
    // ISSUE: unable to decompile the method.
  }

  public MyFileSerializer(Segment2D seg)
  {
    // ISSUE: reference to a compiler-generated field
    ((Router3AXItem) this).\u0001 = 50.0;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXItem) this).\u0001 = entitySortDirection.Normal;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXItem) this).\u0001 = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXCAM) this).\u0002 = -1;
    // ISSUE: explicit constructor call
    ((Line) this).\u002Ector(seg);
  }

  public MyFileSerializer(Segment3D seg)
  {
    // ISSUE: reference to a compiler-generated field
    ((Router3AXItem) this).\u0001 = 50.0;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXItem) this).\u0001 = entitySortDirection.Normal;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXItem) this).\u0001 = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXCAM) this).\u0002 = -1;
    // ISSUE: explicit constructor call
    ((Line) this).\u002Ector(seg);
  }

  public MyFileSerializer(Point3D start, Point3D end)
  {
    // ISSUE: reference to a compiler-generated field
    ((Router3AXItem) this).\u0001 = 50.0;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXItem) this).\u0001 = entitySortDirection.Normal;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXItem) this).\u0001 = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXCAM) this).\u0002 = -1;
    // ISSUE: explicit constructor call
    ((Line) this).\u002Ector(start, end);
  }

  public MyFileSerializer(Plane sketchPlane, Point2D startPoint, Point2D endPoint)
  {
    // ISSUE: reference to a compiler-generated field
    ((Router3AXItem) this).\u0001 = 50.0;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXItem) this).\u0001 = entitySortDirection.Normal;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXItem) this).\u0001 = -1;
    // ISSUE: reference to a compiler-generated field
    ((Router3AXCAM) this).\u0002 = -1;
    // ISSUE: explicit constructor call
    ((Line) this).\u002Ector(sketchPlane, startPoint, endPoint);
  }
}
