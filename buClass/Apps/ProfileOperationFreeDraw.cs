// Decompiled with JetBrains decompiler
// Type: buClass.Apps.ProfileOperationFreeDraw
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

public class ProfileOperationFreeDraw : ProfileOperation
{
  public double Width = 10.0;
  public double Height = 10.0;
  public double Angle = 0.0;

  public ProfileOperationFreeDraw()
  {
  }

  public ProfileOperationFreeDraw(ProfileOperationFreeDraw data)
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
    this.SlopePlane = new Quad3D(data.SlopePlane);
    this.OperationData = new ProfileOperationData(data.OperationData);
    this.Plane = new WorkPlane(data.Plane);
    this.Depth = data.Depth;
    this.DrawPoints.Clear();
    this.DrawPoints = new List<List<Pnt3D>>();
    Pnt3D.Copy(data.DrawPoints, ref this.DrawPoints);
    this.CamPoints.Clear();
    this.CamPoints = new List<List<Pnt3D>>();
    Pnt3D.Copy(data.CamPoints, ref this.CamPoints);
    this.Tool = new ToolBase(data.Tool);
    this.CamCalculation.Clear();
    for (int index = 0; index <= data.CamCalculation.Count - 1; ++index)
      this.CamCalculation.Add(new camBase(data.CamCalculation[index]));
    this.CamParMilling = new camParameters(data.CamParMilling);
    this.CamParNotch = new camParameters(data.CamParNotch);
  }

  public override string ToString()
  {
    return $"{ProfileOperation.strFreeDraw} X: {this.OperationData.Position.X.ToString("f2")} W: {this.DrawPoints.Count.ToString("f3")} - H: {this.Height.ToString("f3")}";
  }
}
