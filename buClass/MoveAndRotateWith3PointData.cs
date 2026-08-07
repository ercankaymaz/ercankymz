// Decompiled with JetBrains decompiler
// Type: buClass.MoveAndRotateWith3PointData
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Reflection;

#nullable disable
namespace buClass;

public class MoveAndRotateWith3PointData
{
  public Pnt3D PntMoveSelected = new Pnt3D();
  public Pnt3D PntMoveNew = new Pnt3D();
  public Pnt3D PntRotateASelected = new Pnt3D();
  public Pnt3D PntRotateANew = new Pnt3D();
  public Pnt3D PntRotateCSelected = new Pnt3D();
  public Pnt3D PntRotateCNew = new Pnt3D();

  public MoveAndRotateWith3PointData()
  {
  }

  public MoveAndRotateWith3PointData(MoveAndRotateWith3PointData data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
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
    this.PntMoveSelected = new Pnt3D(data.PntMoveSelected);
    this.PntMoveNew = new Pnt3D(data.PntMoveNew);
    this.PntRotateASelected = new Pnt3D(data.PntRotateASelected);
    this.PntRotateANew = new Pnt3D(data.PntRotateANew);
    this.PntRotateCSelected = new Pnt3D(data.PntRotateCSelected);
    this.PntRotateCNew = new Pnt3D(data.PntRotateCNew);
  }
}
