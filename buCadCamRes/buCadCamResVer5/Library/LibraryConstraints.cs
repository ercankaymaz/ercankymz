// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Library.LibraryConstraints
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buClass;
using buEyeBaseVer5;
using devDept.Geometry;
using System.Reflection;

#nullable disable
namespace buCadCamResVer5.Library;

public class LibraryConstraints : buSerilization5
{
  public int FirstIndex = -1;
  public int SecondIndex = -1;
  public Point3D refPoint = new Point3D();
  public ConstraintsType Type = ConstraintsType.EqualLength;

  public LibraryConstraints()
  {
  }

  public LibraryConstraints(LibraryConstraints data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
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

  public override string ToString()
  {
    string str = this.Type.ToString();
    if (this.FirstIndex >= 0)
      str = $"{str} , First: {this.FirstIndex.ToString()}";
    if (this.SecondIndex >= 0)
      str = $"{str} , Second: {this.SecondIndex.ToString()}";
    if (this.refPoint.X != 0.0 | this.refPoint.Y != 0.0 | this.refPoint.Y != 0.0)
      str = $"{str} - {this.refPoint.ToString()}";
    return str;
  }
}
