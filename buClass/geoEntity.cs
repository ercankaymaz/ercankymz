// Decompiled with JetBrains decompiler
// Type: buClass.geoEntity
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

#nullable disable
namespace buClass;

[Serializable]
public class geoEntity : buSerilization
{
  public WorkPlane Plane = new WorkPlane();
  public List<Pnt3D> Vertice = new List<Pnt3D>();
  public int Layer = 0;
  public int Mode = 0;
  public int ToolNo = 0;
  public int Index = -1;
  public int BaseEntityIndex = -1;
  public Color Color = Color.Black;
  public double Thickness = 1.0;
  public string Tag = "";
  public string LayerName = "";
  public string ToolName = "";
  public bool Visible = true;
  public bool isText = false;
  public entitySortDirection Direction = entitySortDirection.Normal;
  public entityTypeDefination TypeDefination = entityTypeDefination.None;

  public geoEntity()
  {
  }

  public geoEntity(geoEntity entity)
  {
    if (entity.GetType() == typeof (geoPoint))
      entity = (geoEntity) new geoPoint((geoPoint) entity);
    if (entity.GetType() == typeof (geoLine))
      entity = (geoEntity) new geoLine((geoLine) entity);
    if (entity.GetType() == typeof (geoArc))
      entity = (geoEntity) new geoArc((geoArc) entity);
    if (entity.GetType() == typeof (geoCircle))
      entity = (geoEntity) new geoCircle((geoCircle) entity);
    if (entity.GetType() == typeof (geoQuad))
      entity = (geoEntity) new geoQuad((geoQuad) entity);
    if (entity.GetType() == typeof (geoTriangle))
      entity = (geoEntity) new geoTriangle((geoTriangle) entity);
    if (entity.GetType() == typeof (geoText))
      entity = (geoEntity) new geoText((geoText) entity);
    if (entity.GetType() == typeof (geoEllipse))
      entity = (geoEntity) new geoEllipse((geoEllipse) entity);
    if (!(entity.GetType() == typeof (geoBSpline)))
      return;
    entity = (geoEntity) new geoBSpline((geoBSpline) entity);
  }

  public static void Copy(
    List<List<geoEntity>> RefEntities,
    ref List<List<geoEntity>> CopiedEntities)
  {
    CopiedEntities.Clear();
    for (int index1 = 0; index1 <= RefEntities.Count - 1; ++index1)
    {
      List<geoEntity> geoEntityList = new List<geoEntity>();
      for (int index2 = 0; index2 <= RefEntities[index1].Count - 1; ++index2)
      {
        geoEntity CopiedTo = new geoEntity();
        geoEntity.Copy(RefEntities[index1][index2], ref CopiedTo);
        geoEntityList.Add(CopiedTo);
      }
      CopiedEntities.Add(geoEntityList);
    }
  }

  public static void Copy(List<geoEntity> RefEntities, ref List<geoEntity> CopiedEntities)
  {
    CopiedEntities.Clear();
    for (int index = 0; index <= RefEntities.Count - 1; ++index)
    {
      geoEntity CopiedTo = new geoEntity();
      geoEntity.Copy(RefEntities[index], ref CopiedTo);
      CopiedEntities.Add(CopiedTo);
    }
  }

  public static void Copy(geoEntity RefEntity, ref geoEntity CopiedTo)
  {
    if (RefEntity.GetType() == typeof (geoPoint))
    {
      geoPoint geoPoint1 = new geoPoint();
      geoPoint geoPoint2 = (geoPoint) RefEntity;
      CopiedTo = (geoEntity) new geoPoint(geoPoint2.StartPoint);
    }
    if (RefEntity.GetType() == typeof (geoPolyline))
    {
      geoPolyline geoPolyline1 = new geoPolyline();
      geoPolyline geoPolyline2 = (geoPolyline) RefEntity;
      CopiedTo = (geoEntity) new geoPolyline(geoPolyline2.Vertice);
    }
    if (RefEntity.GetType() == typeof (geoBSpline))
    {
      geoBSpline geoBspline1 = new geoBSpline();
      geoBSpline geoBspline2 = (geoBSpline) RefEntity;
      CopiedTo = (geoEntity) new geoBSpline(geoBspline2.ControlPoints);
    }
    if (RefEntity.GetType() == typeof (geoLine))
    {
      geoLine geoLine1 = new geoLine();
      geoLine geoLine2 = (geoLine) RefEntity;
      CopiedTo = (geoEntity) new geoLine(geoLine2.StartPoint, geoLine2.EndPoint);
    }
    if (RefEntity.GetType() == typeof (geoArc))
    {
      geoArc geoArc1 = new geoArc();
      geoArc geoArc2 = (geoArc) RefEntity;
      CopiedTo = (geoEntity) new geoArc(geoArc2.CenterPoint, geoArc2.Radius, geoArc2.StartAngle, geoArc2.EndAngle, geoArc2.Plane);
    }
    if (RefEntity.GetType() == typeof (geoCircle))
    {
      geoCircle geoCircle1 = new geoCircle();
      geoCircle geoCircle2 = (geoCircle) RefEntity;
      CopiedTo = (geoEntity) new geoCircle(geoCircle2.CenterPoint, geoCircle2.Radius, geoCircle2.Plane);
    }
    if (RefEntity.GetType() == typeof (geoEllipse))
    {
      geoEllipse geoEllipse1 = new geoEllipse();
      geoEllipse geoEllipse2 = (geoEllipse) RefEntity;
      CopiedTo = (geoEntity) new geoEllipse(geoEllipse2.CenterPoint, geoEllipse2.MajorRadius, geoEllipse2.MinorRadius, geoEllipse2.Angle, geoEllipse2.Plane);
    }
    if (RefEntity.GetType() == typeof (geoQuad))
    {
      geoQuad geoQuad1 = new geoQuad();
      geoQuad geoQuad2 = (geoQuad) RefEntity;
      CopiedTo = (geoEntity) new geoQuad(geoQuad2.FirstPoint, geoQuad2.SecondPoint, geoQuad2.ThirdPoint, geoQuad2.FourthPoint);
    }
    if (RefEntity.GetType() == typeof (geoTriangle))
    {
      geoTriangle geoTriangle1 = new geoTriangle();
      geoTriangle geoTriangle2 = (geoTriangle) RefEntity;
      CopiedTo = (geoEntity) new geoTriangle(geoTriangle2.FirstPoint, geoTriangle2.SecondPoint, geoTriangle2.ThirdPoint);
    }
    if (RefEntity.GetType() == typeof (geoText))
    {
      geoText geoText1 = new geoText();
      geoText geoText2 = (geoText) RefEntity;
      CopiedTo = (geoEntity) new geoText(geoText2.StartPoint, geoText2.TextString, geoText2.TextFont, geoText2.Color, geoText2.Height, geoText2.Angle);
    }
    CopiedTo.LayerName = RefEntity.LayerName;
    CopiedTo.Layer = RefEntity.Layer;
    CopiedTo.Color = RefEntity.Color;
    CopiedTo.Thickness = RefEntity.Thickness;
    CopiedTo.Mode = RefEntity.Mode;
    CopiedTo.ToolNo = RefEntity.ToolNo;
    CopiedTo.Tag = RefEntity.Tag;
    CopiedTo.Index = RefEntity.Index;
    CopiedTo.Visible = RefEntity.Visible;
    CopiedTo.TypeDefination = RefEntity.TypeDefination;
    CopiedTo.isText = RefEntity.isText;
  }

  public static void GeoEntitiyToEEntity(geoEntity GeoEntity, ref eEntities EEntity)
  {
    if (GeoEntity.GetType() == typeof (geoPoint))
      EEntity = (eEntities) new ePoint(((geoPoint) GeoEntity).StartPoint, (float) GeoEntity.Thickness, GeoEntity.Color);
    if (GeoEntity.GetType() == typeof (geoLine))
      EEntity = (eEntities) new eLine(((geoLine) GeoEntity).StartPoint, ((geoLine) GeoEntity).EndPoint, (float) GeoEntity.Thickness, GeoEntity.Color);
    if (GeoEntity.GetType() == typeof (geoArc))
      EEntity = (eEntities) new eArc(((geoArc) GeoEntity).CenterPoint, ((geoArc) GeoEntity).Radius, ((geoArc) GeoEntity).StartAngle, ((geoArc) GeoEntity).EndAngle, GeoEntity.Plane, (float) GeoEntity.Thickness, GeoEntity.Color);
    if (GeoEntity.GetType() == typeof (geoCircle))
      EEntity = (eEntities) new eCircle(((geoCircle) GeoEntity).CenterPoint, ((geoCircle) GeoEntity).Radius, GeoEntity.Plane, (float) GeoEntity.Thickness, GeoEntity.Color);
    if (GeoEntity.GetType() == typeof (geoEllipse))
      EEntity = (eEntities) new eEllipse(((geoEllipse) GeoEntity).CenterPoint, ((geoEllipse) GeoEntity).MajorRadius, ((geoEllipse) GeoEntity).MinorRadius, ((geoEllipse) GeoEntity).Angle, GeoEntity.Plane, (float) GeoEntity.Thickness, GeoEntity.Color);
    if (GeoEntity.GetType() == typeof (geoPolyline))
      EEntity = (eEntities) new ePolyline(GeoEntity.Vertice, (float) GeoEntity.Thickness, GeoEntity.Color);
    if (GeoEntity.GetType() == typeof (geoBSpline))
      EEntity = (eEntities) new eBSpline(((geoBSpline) GeoEntity).ControlPoints, (float) GeoEntity.Thickness, GeoEntity.Color, ((geoBSpline) GeoEntity).Closed, ((geoBSpline) GeoEntity).BType);
    if (GeoEntity.GetType() == typeof (geoText))
      EEntity = (eEntities) new eText(((geoText) GeoEntity).StartPoint, ((geoText) GeoEntity).TextString, ((geoText) GeoEntity).Height, GeoEntity.Color, GeoEntity.Plane);
    EEntity.TypeDefination = GeoEntity.TypeDefination;
  }

  public static void GeoEntitiyToEEntity(List<geoEntity> GeoEntities, ref List<eEntities> EEntities)
  {
    EEntities.Clear();
    EEntities = new List<eEntities>();
    for (int index = 0; index <= GeoEntities.Count - 1; ++index)
    {
      eEntities EEntity = new eEntities();
      geoEntity.GeoEntitiyToEEntity(GeoEntities[index], ref EEntity);
      EEntities.Add(EEntity);
    }
  }

  public static void GeoEntitiyToEEntity(
    List<List<geoEntity>> GeoEntities,
    ref List<List<eEntities>> EEntities)
  {
    EEntities.Clear();
    EEntities = new List<List<eEntities>>();
    for (int index = 0; index <= GeoEntities.Count - 1; ++index)
    {
      List<eEntities> EEntities1 = new List<eEntities>();
      geoEntity.GeoEntitiyToEEntity(GeoEntities[index], ref EEntities1);
      EEntities.Add(EEntities1);
    }
  }

  public static void EEntitytoGeoEntity(eEntities EEntity, ref geoEntity GeoEntity)
  {
    if (EEntity.GetType() == typeof (ePoint))
    {
      ePoint ePoint = new ePoint(EEntity);
      GeoEntity = (geoEntity) new geoPoint(ePoint.StartPoint);
    }
    if (EEntity.GetType() == typeof (eLine))
    {
      eLine eLine = new eLine(EEntity);
      GeoEntity = (geoEntity) new geoLine(eLine.StartPoint, eLine.EndPoint);
    }
    if (EEntity.GetType() == typeof (eArc))
    {
      eArc eArc = new eArc(EEntity);
      GeoEntity = (geoEntity) new geoArc(eArc.CenterPoint, eArc.Radius, eArc.StartAngle, eArc.EndAngle, ((ePlaneEntities) EEntity).Plane);
    }
    if (EEntity.GetType() == typeof (eCircle))
    {
      eCircle eCircle = new eCircle(EEntity);
      GeoEntity = (geoEntity) new geoCircle(eCircle.CenterPoint, eCircle.Radius, eCircle.Plane);
    }
    if (EEntity.GetType() == typeof (eEllipse))
    {
      eEllipse eEllipse = new eEllipse(EEntity);
      GeoEntity = (geoEntity) new geoEllipse(eEllipse.CenterPoint, eEllipse.MajorRadius, eEllipse.MinorRadius, eEllipse.Angle, eEllipse.Plane);
    }
    if (EEntity.GetType() == typeof (ePolyline))
    {
      ePolyline ePolyline = new ePolyline(EEntity);
      GeoEntity = (geoEntity) new geoPolyline(ePolyline.Vertice);
    }
    if (EEntity.GetType() == typeof (eBSpline))
    {
      eBSpline eBspline = new eBSpline(EEntity);
      GeoEntity = (geoEntity) new geoBSpline(eBspline.ControlPoints, eBspline.bClosed, eBspline.BType);
    }
    if (EEntity.GetType() == typeof (eText))
    {
      eText eText = new eText(EEntity);
      GeoEntity = (geoEntity) new geoText(eText.StartPoint, eText.TextString, eText.TextFont, eText.dispColor, eText.Height, eText.Angle);
    }
    GeoEntity.Layer = EEntity.LayerIndex;
    GeoEntity.Mode = EEntity.Mode;
    GeoEntity.ToolNo = EEntity.camToolNo;
    GeoEntity.Index = EEntity.GroupIndex;
    GeoEntity.TypeDefination = EEntity.TypeDefination;
  }

  public static void EEntitytoGeoEntity(List<eEntities> EEntity, ref List<geoEntity> GeoEntity)
  {
    GeoEntity.Clear();
    for (int index = 0; index <= EEntity.Count - 1; ++index)
    {
      geoEntity GeoEntity1 = new geoEntity();
      geoEntity.EEntitytoGeoEntity(EEntity[index], ref GeoEntity1);
      GeoEntity1.Layer = EEntity[index].LayerIndex;
      GeoEntity1.Mode = EEntity[index].Mode;
      GeoEntity1.ToolNo = EEntity[index].camToolNo;
      GeoEntity1.Index = EEntity[index].GroupIndex;
      GeoEntity1.TypeDefination = EEntity[index].TypeDefination;
      GeoEntity.Add(GeoEntity1);
    }
  }

  public static void CopyProperties(geoEntity refEntity, ref geoEntity copiedEntity)
  {
    copiedEntity.ToolNo = refEntity.ToolNo;
    copiedEntity.isText = refEntity.isText;
    copiedEntity.BaseEntityIndex = refEntity.BaseEntityIndex;
    copiedEntity.Color = refEntity.Color;
    copiedEntity.Direction = refEntity.Direction;
    copiedEntity.Layer = refEntity.Layer;
    copiedEntity.LayerName = refEntity.LayerName;
    copiedEntity.Mode = refEntity.Mode;
    copiedEntity.Plane = new WorkPlane(refEntity.Plane);
    copiedEntity.Tag = refEntity.Tag;
    copiedEntity.Thickness = refEntity.Thickness;
  }

  public static geoEntity Copy(geoEntity RefEntity)
  {
    geoEntity CopiedTo = new geoEntity();
    geoEntity.Copy(RefEntity, ref CopiedTo);
    return CopiedTo;
  }

  public static geoEntity Decode(List<string> AL, string Char, SerilizationMode Mode)
  {
    geoEntity geoEntity = (geoEntity) null;
    if (AL.Count > 0)
    {
      string str = AL[0];
      if (str.Length > 0)
      {
        if (str.IndexOf("geoPoint") >= 0)
        {
          geoEntity = (geoEntity) new geoPoint();
          buSerilization.Decode(AL, "", SerilizationMode.MultiLine, (object) geoEntity);
        }
        if (str.IndexOf("geoLine") >= 0)
        {
          geoEntity = (geoEntity) new geoLine();
          buSerilization.Decode(AL, "", SerilizationMode.MultiLine, (object) geoEntity);
        }
        if (str.IndexOf("geoArc") >= 0)
        {
          geoEntity = (geoEntity) new geoArc();
          buSerilization.Decode(AL, "", SerilizationMode.MultiLine, (object) geoEntity);
        }
        if (str.IndexOf("geoCircle") >= 0)
        {
          geoEntity = (geoEntity) new geoCircle();
          buSerilization.Decode(AL, "", SerilizationMode.MultiLine, (object) geoEntity);
        }
        if (str.IndexOf("geoEllipse") >= 0)
        {
          geoEntity = (geoEntity) new geoEllipse();
          buSerilization.Decode(AL, "", SerilizationMode.MultiLine, (object) geoEntity);
        }
        if (str.IndexOf("geoQuad") >= 0)
        {
          geoEntity = (geoEntity) new geoQuad();
          buSerilization.Decode(AL, "", SerilizationMode.MultiLine, (object) geoEntity);
        }
        if (str.IndexOf("geoTriangle") >= 0)
        {
          geoEntity = (geoEntity) new geoTriangle();
          buSerilization.Decode(AL, "", SerilizationMode.MultiLine, (object) geoEntity);
        }
        if (str.IndexOf("geoPolyline") >= 0)
        {
          geoEntity = (geoEntity) new geoPolyline();
          buSerilization.Decode(AL, "", SerilizationMode.MultiLine, (object) geoEntity);
        }
        if (str.IndexOf("geoBSpline") >= 0)
        {
          geoEntity = (geoEntity) new geoBSpline();
          buSerilization.Decode(AL, "", SerilizationMode.MultiLine, (object) geoEntity);
        }
        if (str.IndexOf("geoText") >= 0)
        {
          geoEntity = (geoEntity) new geoText();
          buSerilization.Decode(AL, "", SerilizationMode.MultiLine, (object) geoEntity);
        }
      }
    }
    return geoEntity;
  }

  public ArrayList ToDefAll(int Space)
  {
    string str = new string(' ', Space);
    ArrayList defAll = new ArrayList();
    if (this == null)
      return new ArrayList();
    buSerilization.ExceptionalVariables.Clear();
    defAll.Add((object) (str + "<geoEntity>"));
    if (this.GetType() == typeof (geoLine))
      defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
    if (this.GetType() == typeof (geoPoint))
      defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
    if (this.GetType() == typeof (geoArc))
      defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
    if (this.GetType() == typeof (geoCircle))
      defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
    if (this.GetType() == typeof (geoEllipse))
      defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
    if (this.GetType() == typeof (geoQuad))
      defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
    if (this.GetType() == typeof (geoTriangle))
      defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
    if (this.GetType() == typeof (geoPolyline))
      defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
    if (this.GetType() == typeof (geoBSpline))
      defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
    if (this.GetType() == typeof (geoText))
      defAll.AddRange((ICollection) this.ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
    defAll.Add((object) (str + "</geoEntity>"));
    return defAll;
  }

  public override string ToString()
  {
    string str = "";
    if (this.GetType() == typeof (geoLine))
      str = $"{((geoLine) this).ToString()} , Layer : {this.Layer.ToString()} , Index : {this.Layer.ToString()}";
    if (this.GetType() == typeof (geoArc))
      str = $"{((geoArc) this).ToString()} , Layer : {this.Layer.ToString()} , Index : {this.Layer.ToString()}";
    if (this.GetType() == typeof (geoCircle))
      str = $"{((geoCircle) this).ToString()} , Layer : {this.Layer.ToString()} , Index : {this.Layer.ToString()}";
    if (this.GetType() == typeof (geoTriangle))
      str = $"{((geoTriangle) this).ToString()} , Layer : {this.Layer.ToString()} , Index : {this.Layer.ToString()}";
    if (this.GetType() == typeof (geoQuad))
      str = $"{((geoQuad) this).ToString()} , Layer : {this.Layer.ToString()} , Index : {this.Layer.ToString()}";
    if (this.GetType() == typeof (geoPolyline))
      str = $"{((geoPolyline) this).ToString()} , Layer : {this.Layer.ToString()} , Index : {this.Layer.ToString()}";
    return str;
  }
}
