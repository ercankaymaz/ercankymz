// Decompiled with JetBrains decompiler
// Type: buClass.UserFiles.buCad.setEntities
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Drawing;
using System.Reflection;

#nullable disable
namespace buClass.UserFiles.buCad;

public class setEntities : buSerilization
{
  public EntityResolution DynamicEntityResolution = new EntityResolution();
  public double EntityCatchRatio = 2.0;
  public double DimensionTextHeight = 5.0;
  public double PointVisibleThicknessOffset = 4.0;
  public double RegenDeviation = 0.01;
  public double RegenMaxLen = 0.0;
  public double RegenAngle = 0.0;
  public double SmallSizeRatio = 0.01;
  public bool DimensionDrawingPropertiesFromLayer = false;
  public bool ExplodeEntitiesAsNewEntity = false;
  public bool FinishPolylineIfClosed = true;
  public drawPropertiesType DimensionDrawing = new drawPropertiesType(Color.DimGray, 1f, new drawingPattern());
  public bool ContinuesTrim = true;
  public bool ContinuesExtend = true;
  public ScaleType ScaleMode = ScaleType.Size;
  public InsertEntitiesTYpe InsertEntititesMode = InsertEntitiesTYpe.ByMouse;
  public double MinVerticesDistance = 0.0;

  public setEntities()
  {
  }

  public setEntities(setEntities data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
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
}
