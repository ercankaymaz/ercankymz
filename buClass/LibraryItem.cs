// Decompiled with JetBrains decompiler
// Type: buClass.LibraryItem
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buClass;

[Serializable]
public class LibraryItem : buSerilization
{
  public WorkPlane Plane = new WorkPlane();
  public List<Pnt3D> Vertice = new List<Pnt3D>();
  public double Rotation = 0.0;
  public Color Color = Color.Black;
  public double Thickness = 1.0;
  public string Tag = "";
  public bool Visible = true;

  public LibraryItem()
  {
  }

  public LibraryItem(LibraryItem entity)
  {
    if (entity.GetType() == typeof (LibraryItemPoint))
      entity = (LibraryItem) new LibraryItemPoint((LibraryItemPoint) entity);
    if (entity.GetType() == typeof (LibraryItemLine))
      entity = (LibraryItem) new LibraryItemLine((LibraryItemLine) entity);
    if (entity.GetType() == typeof (LibraryItemRectangle))
      entity = (LibraryItem) new LibraryItemRectangle((LibraryItemRectangle) entity);
    if (entity.GetType() == typeof (LibraryItemCircle))
      entity = (LibraryItem) new LibraryItemCircle((LibraryItemCircle) entity);
    if (entity.GetType() == typeof (LibraryItemBarrel))
      entity = (LibraryItem) new LibraryItemBarrel((LibraryItemBarrel) entity);
    if (entity.GetType() == typeof (LibraryItemEllipse))
      entity = (LibraryItem) new LibraryItemEllipse((LibraryItemEllipse) entity);
    if (entity.GetType() == typeof (LibraryItemPolygon))
      entity = (LibraryItem) new LibraryItemPolygon((LibraryItemPolygon) entity);
    if (entity.GetType() == typeof (LibraryItemTriangleTwin))
      entity = (LibraryItem) new LibraryItemTriangleTwin((LibraryItemTriangleTwin) entity);
    if (entity.GetType() == typeof (LibraryItemText))
      entity = (LibraryItem) new LibraryItemText((LibraryItemText) entity);
    if (!(entity.GetType() == typeof (LibraryItemSlot)))
      return;
    entity = (LibraryItem) new LibraryItemSlot((LibraryItemSlot) entity);
  }

  public static void Copy(List<LibraryItem> RefEntities, ref List<LibraryItem> CopiedEntities)
  {
    CopiedEntities.Clear();
    for (int index = 0; index <= RefEntities.Count - 1; ++index)
    {
      LibraryItem CopiedTo = new LibraryItem();
      LibraryItem.Copy(RefEntities[index], ref CopiedTo);
      CopiedEntities.Add(CopiedTo);
    }
  }

  public static void Copy(LibraryItem RefEntity, ref LibraryItem CopiedTo)
  {
    if (RefEntity.GetType() == typeof (LibraryItemPoint))
      CopiedTo = (LibraryItem) new LibraryItemPoint((LibraryItemPoint) RefEntity);
    if (RefEntity.GetType() == typeof (LibraryItemLine))
      CopiedTo = (LibraryItem) new LibraryItemLine((LibraryItemLine) RefEntity);
    if (RefEntity.GetType() == typeof (LibraryItemRectangle))
      CopiedTo = (LibraryItem) new LibraryItemRectangle((LibraryItemRectangle) RefEntity);
    if (RefEntity.GetType() == typeof (LibraryItemCircle))
      CopiedTo = (LibraryItem) new LibraryItemCircle((LibraryItemCircle) RefEntity);
    if (RefEntity.GetType() == typeof (LibraryItemEllipse))
      CopiedTo = (LibraryItem) new LibraryItemEllipse((LibraryItemEllipse) RefEntity);
    if (RefEntity.GetType() == typeof (LibraryItemBarrel))
      CopiedTo = (LibraryItem) new LibraryItemBarrel((LibraryItemBarrel) RefEntity);
    if (RefEntity.GetType() == typeof (LibraryItemPolygon))
      CopiedTo = (LibraryItem) new LibraryItemPolygon((LibraryItemPolygon) RefEntity);
    if (RefEntity.GetType() == typeof (LibraryItemTriangleTwin))
      CopiedTo = (LibraryItem) new LibraryItemTriangleTwin((LibraryItemTriangleTwin) RefEntity);
    if (RefEntity.GetType() == typeof (LibraryItemText))
      CopiedTo = (LibraryItem) new LibraryItemText((LibraryItemText) RefEntity);
    if (RefEntity.GetType() == typeof (LibraryItemSlot))
      CopiedTo = (LibraryItem) new LibraryItemSlot((LibraryItemSlot) RefEntity);
    CopiedTo.Rotation = RefEntity.Rotation;
    CopiedTo.Color = RefEntity.Color;
    CopiedTo.Thickness = RefEntity.Thickness;
    CopiedTo.Plane = new WorkPlane(RefEntity.Plane);
    CopiedTo.Tag = RefEntity.Tag;
    CopiedTo.Visible = RefEntity.Visible;
  }

  public static LibraryItem Copy(LibraryItem RefEntity)
  {
    LibraryItem CopiedTo = new LibraryItem();
    LibraryItem.Copy(RefEntity, ref CopiedTo);
    return CopiedTo;
  }

  public override string ToString()
  {
    string str = "";
    if (this.GetType() == typeof (LibraryItemPoint))
      str = ((LibraryItemPoint) this).ToString();
    if (this.GetType() == typeof (LibraryItemLine))
      str = ((LibraryItemLine) this).ToString();
    if (this.GetType() == typeof (LibraryItemRectangle))
      str = ((LibraryItemRectangle) this).ToString();
    if (this.GetType() == typeof (LibraryItemCircle))
      str = ((LibraryItemCircle) this).ToString();
    if (this.GetType() == typeof (LibraryItemEllipse))
      str = ((LibraryItemEllipse) this).ToString();
    if (this.GetType() == typeof (LibraryItemPolygon))
      str = ((LibraryItemPolygon) this).ToString();
    if (this.GetType() == typeof (LibraryItemBarrel))
      str = ((LibraryItemBarrel) this).ToString();
    if (this.GetType() == typeof (LibraryItemTriangleTwin))
      str = ((LibraryItemTriangleTwin) this).ToString();
    if (this.GetType() == typeof (LibraryItemText))
      str = ((LibraryItemText) this).ToString();
    if (this.GetType() == typeof (LibraryItemSlot))
      str = ((LibraryItemSlot) this).ToString();
    return str;
  }
}
