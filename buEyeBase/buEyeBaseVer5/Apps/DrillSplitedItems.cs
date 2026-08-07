// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.DrillSplitedItems
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace buEyeBaseVer5.Apps;

public class DrillSplitedItems
{
  public Point3D MinPoint;
  public Point3D MaxPoint;
  public Entity entOriginal;
  public Entity entTessellenation;
  public List<Printer3DLayer> Layers;
  public static byte f003CF3;
  public bool Enable;

  public static ArrayList ToDef(List<PipeBendDiskBlocks> Items, string Char, int Space)
  {
    ArrayList def = new ArrayList();
    for (int index = 0; index <= Items.Count - 1; ++index)
      def.AddRange((ICollection) DrillSplitedItems.ToDef(Items[index], Char, Space + 2));
    return def;
  }

  public static ArrayList ToDef(PipeBendDiskBlocks Item, string Char, int Space)
  {
    ArrayList def = new ArrayList();
    def.Add((object) (buImage5.SpaceChar(Space) + "<DiskBlocks>"));
    string str = buImage5.SpaceChar(Space + 2) + buSerilization5.ClassToString((object) Item);
    def.Add((object) str);
    def.Add((object) (buImage5.SpaceChar(Space) + "</DiskBlocks>"));
    return def;
  }
}
