// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buEntities.buUpperLine
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.Events;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;

#nullable disable
namespace buEyeBaseVer5.buEntities;

[Serializable]
public class buUpperLine : buEntity
{
  public abstract void m001765();

  public void Regen(double Deviation = 0.01)
  {
    bool flag = false;
    if (this == null)
      return;
    Entity copiedEntity = (Entity) null;
    buAngularDim.Copy((buEntity) this, ref copiedEntity);
    if (copiedEntity is Text | copiedEntity is Dimension)
      flag = true;
    if (flag)
      return;
    copiedEntity.Regen(Deviation);
    ((CustomData) this).BoxMin = new Point3D(copiedEntity.BoxMin.X, copiedEntity.BoxMin.Y, copiedEntity.BoxMin.Z);
    ((CustomData) this).BoxMax = new Point3D(copiedEntity.BoxMax.X, copiedEntity.BoxMax.Y, copiedEntity.BoxMax.Z);
    ((CustomDataSurrogate) this).Vertices.Clear();
    for (int index = 0; index <= copiedEntity.Vertices.Length - 1; ++index)
      ((CustomDataSurrogate) this).Vertices.Add(new Point3D(copiedEntity.Vertices[index].X, copiedEntity.Vertices[index].Y, copiedEntity.Vertices[index].Z));
  }

  public void Regen(Entity refEntity, double Deviation = 0.01)
  {
    bool flag = false;
    if (refEntity is Text | refEntity is Dimension)
      flag = true;
    if (!flag)
    {
      refEntity.Regen(Deviation);
      ((CustomData) this).BoxMin = new Point3D(refEntity.BoxMin.X, refEntity.BoxMin.Y, refEntity.BoxMin.Z);
      ((CustomData) this).BoxMax = new Point3D(refEntity.BoxMax.X, refEntity.BoxMax.Y, refEntity.BoxMax.Z);
      ((CustomDataSurrogate) this).Vertices.Clear();
      for (int index = 0; index <= refEntity.Vertices.Length - 1; ++index)
        ((CustomDataSurrogate) this).Vertices.Add(new Point3D(refEntity.Vertices[index].X, refEntity.Vertices[index].Y, refEntity.Vertices[index].Z));
    }
    else
    {
      if ((DrawingFinisedEventArgs.baseModel == null ? 0 : (refEntity is Text ? 1 : 0)) == 0)
        return;
      Text text = refEntity as Text;
      if ((DrawingFinisedEventArgs.baseModel.TextStyles.Count <= 0 ? 0 : (DrawingFinisedEventArgs.baseModel.TextStyles[0].Name == text.StyleName ? 1 : 0)) == 0)
        return;
      refEntity.Regen(new RegenParams(Deviation, (IWorkspace) DrawingFinisedEventArgs.baseModel));
    }
  }

  public void Update(double Deviation = 0.01, Plane plane = null)
  {
    switch (this)
    {
      case buLine _:
        this.Update((buEntityUpdateType) 2, Deviation, plane);
        break;
      case buLinearPath _:
        this.Update((buEntityUpdateType) 17, Deviation, plane);
        break;
      case buArc _:
        if (plane == (Plane) null)
        {
          this.Update((buEntityUpdateType) 4, Deviation, plane);
          break;
        }
        this.Update((buEntityUpdateType) 7, Deviation, plane);
        break;
      case buCircle _:
        if (plane == (Plane) null)
        {
          this.Update((buEntityUpdateType) 11, Deviation, plane);
          break;
        }
        this.Update((buEntityUpdateType) 12, Deviation, plane);
        break;
      case buEllipse _:
        if (plane == (Plane) null)
        {
          this.Update((buEntityUpdateType) 19, Deviation, plane);
          break;
        }
        this.Update((buEntityUpdateType) 20, Deviation, plane);
        break;
      case buCurve _:
        if (!((CustomDataSurrogate) this).isRational)
        {
          this.Update((buEntityUpdateType) 23, Deviation, plane);
          break;
        }
        this.Update((buEntityUpdateType) 24, Deviation, plane);
        break;
      case buCompositeCurve _:
        this.Update((buEntityUpdateType) 26, Deviation, plane);
        break;
      case buRegion _:
        this.Update((buEntityUpdateType) 34, Deviation, plane);
        break;
      case buMesh _:
        this.Update((buEntityUpdateType) 33, Deviation, plane);
        break;
      case buLinearDim _:
        this.Update((buEntityUpdateType) 39, Deviation, plane);
        break;
      case buAngularDim _:
        this.Update((buEntityUpdateType) 40, Deviation, plane);
        break;
      case buDiametricDim _:
        this.Update((buEntityUpdateType) 41, Deviation, plane);
        break;
      case buRadialDim _:
        this.Update((buEntityUpdateType) 43, Deviation, plane);
        break;
      case buOrdinateDim _:
        this.Update((buEntityUpdateType) 42, Deviation, plane);
        break;
      case buText _:
        this.Update((buEntityUpdateType) 44, Deviation, plane);
        break;
      case buMultilineText _:
        this.Update((buEntityUpdateType) 46, Deviation, plane);
        break;
    }
  }

  public void Update(buEntityUpdateType UpdateType, double Deviation = 0.01, Plane plane = null)
  {
    // ISSUE: unable to decompile the method.
  }

  public double Length()
  {
    double num = 0.0;
    Entity copiedEntity = (Entity) null;
    buAngularDim.Copy((buEntity) this, ref copiedEntity);
    if (copiedEntity != null && copiedEntity is ICurve)
      num = ((ICurve) copiedEntity).Length();
    return num;
  }
}
