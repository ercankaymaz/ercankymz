using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

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
		if (entity.GetType() == typeof(geoPoint))
		{
			entity = new geoPoint((geoPoint)entity);
		}
		if (entity.GetType() == typeof(geoLine))
		{
			entity = new geoLine((geoLine)entity);
		}
		if (entity.GetType() == typeof(geoArc))
		{
			entity = new geoArc((geoArc)entity);
		}
		if (entity.GetType() == typeof(geoCircle))
		{
			entity = new geoCircle((geoCircle)entity);
		}
		if (entity.GetType() == typeof(geoQuad))
		{
			entity = new geoQuad((geoQuad)entity);
		}
		if (entity.GetType() == typeof(geoTriangle))
		{
			entity = new geoTriangle((geoTriangle)entity);
		}
		if (entity.GetType() == typeof(geoText))
		{
			entity = new geoText((geoText)entity);
		}
		if (entity.GetType() == typeof(geoEllipse))
		{
			entity = new geoEllipse((geoEllipse)entity);
		}
		if (entity.GetType() == typeof(geoBSpline))
		{
			entity = new geoBSpline((geoBSpline)entity);
		}
	}

	public static void Copy(List<List<geoEntity>> RefEntities, ref List<List<geoEntity>> CopiedEntities)
	{
		CopiedEntities.Clear();
		for (int i = 0; i <= RefEntities.Count - 1; i++)
		{
			List<geoEntity> list = new List<geoEntity>();
			for (int j = 0; j <= RefEntities[i].Count - 1; j++)
			{
				geoEntity CopiedTo = new geoEntity();
				Copy(RefEntities[i][j], ref CopiedTo);
				list.Add(CopiedTo);
			}
			CopiedEntities.Add(list);
		}
	}

	public static void Copy(List<geoEntity> RefEntities, ref List<geoEntity> CopiedEntities)
	{
		CopiedEntities.Clear();
		for (int i = 0; i <= RefEntities.Count - 1; i++)
		{
			geoEntity CopiedTo = new geoEntity();
			Copy(RefEntities[i], ref CopiedTo);
			CopiedEntities.Add(CopiedTo);
		}
	}

	public static void Copy(geoEntity RefEntity, ref geoEntity CopiedTo)
	{
		if (RefEntity.GetType() == typeof(geoPoint))
		{
			geoPoint geoPoint2 = new geoPoint();
			geoPoint2 = (geoPoint)RefEntity;
			CopiedTo = new geoPoint(geoPoint2.StartPoint);
		}
		if (RefEntity.GetType() == typeof(geoPolyline))
		{
			geoPolyline geoPolyline2 = new geoPolyline();
			geoPolyline2 = (geoPolyline)RefEntity;
			CopiedTo = new geoPolyline(geoPolyline2.Vertice);
		}
		if (RefEntity.GetType() == typeof(geoBSpline))
		{
			geoBSpline geoBSpline2 = new geoBSpline();
			geoBSpline2 = (geoBSpline)RefEntity;
			CopiedTo = new geoBSpline(geoBSpline2.ControlPoints);
		}
		if (RefEntity.GetType() == typeof(geoLine))
		{
			geoLine geoLine2 = new geoLine();
			geoLine2 = (geoLine)RefEntity;
			CopiedTo = new geoLine(geoLine2.StartPoint, geoLine2.EndPoint);
		}
		if (RefEntity.GetType() == typeof(geoArc))
		{
			geoArc geoArc2 = new geoArc();
			geoArc2 = (geoArc)RefEntity;
			CopiedTo = new geoArc(geoArc2.CenterPoint, geoArc2.Radius, geoArc2.StartAngle, geoArc2.EndAngle, geoArc2.Plane);
		}
		if (RefEntity.GetType() == typeof(geoCircle))
		{
			geoCircle geoCircle2 = new geoCircle();
			geoCircle2 = (geoCircle)RefEntity;
			CopiedTo = new geoCircle(geoCircle2.CenterPoint, geoCircle2.Radius, geoCircle2.Plane);
		}
		if (RefEntity.GetType() == typeof(geoEllipse))
		{
			geoEllipse geoEllipse2 = new geoEllipse();
			geoEllipse2 = (geoEllipse)RefEntity;
			CopiedTo = new geoEllipse(geoEllipse2.CenterPoint, geoEllipse2.MajorRadius, geoEllipse2.MinorRadius, geoEllipse2.Angle, geoEllipse2.Plane);
		}
		if (RefEntity.GetType() == typeof(geoQuad))
		{
			geoQuad geoQuad2 = new geoQuad();
			geoQuad2 = (geoQuad)RefEntity;
			CopiedTo = new geoQuad(geoQuad2.FirstPoint, geoQuad2.SecondPoint, geoQuad2.ThirdPoint, geoQuad2.FourthPoint);
		}
		if (RefEntity.GetType() == typeof(geoTriangle))
		{
			geoTriangle geoTriangle2 = new geoTriangle();
			geoTriangle2 = (geoTriangle)RefEntity;
			CopiedTo = new geoTriangle(geoTriangle2.FirstPoint, geoTriangle2.SecondPoint, geoTriangle2.ThirdPoint);
		}
		if (RefEntity.GetType() == typeof(geoText))
		{
			geoText geoText2 = new geoText();
			geoText2 = (geoText)RefEntity;
			CopiedTo = new geoText(geoText2.StartPoint, geoText2.TextString, geoText2.TextFont, geoText2.Color, geoText2.Height, geoText2.Angle);
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
		if (GeoEntity.GetType() == typeof(geoPoint))
		{
			EEntity = new ePoint(((geoPoint)GeoEntity).StartPoint, (float)((geoPoint)GeoEntity).Thickness, ((geoPoint)GeoEntity).Color);
		}
		if (GeoEntity.GetType() == typeof(geoLine))
		{
			EEntity = new eLine(((geoLine)GeoEntity).StartPoint, ((geoLine)GeoEntity).EndPoint, (float)((geoLine)GeoEntity).Thickness, ((geoLine)GeoEntity).Color);
		}
		if (GeoEntity.GetType() == typeof(geoArc))
		{
			EEntity = new eArc(((geoArc)GeoEntity).CenterPoint, ((geoArc)GeoEntity).Radius, ((geoArc)GeoEntity).StartAngle, ((geoArc)GeoEntity).EndAngle, ((geoArc)GeoEntity).Plane, (float)((geoArc)GeoEntity).Thickness, ((geoArc)GeoEntity).Color);
		}
		if (GeoEntity.GetType() == typeof(geoCircle))
		{
			EEntity = new eCircle(((geoCircle)GeoEntity).CenterPoint, ((geoCircle)GeoEntity).Radius, ((geoCircle)GeoEntity).Plane, (float)((geoCircle)GeoEntity).Thickness, ((geoCircle)GeoEntity).Color);
		}
		if (GeoEntity.GetType() == typeof(geoEllipse))
		{
			EEntity = new eEllipse(((geoEllipse)GeoEntity).CenterPoint, ((geoEllipse)GeoEntity).MajorRadius, ((geoEllipse)GeoEntity).MinorRadius, ((geoEllipse)GeoEntity).Angle, ((geoEllipse)GeoEntity).Plane, (float)((geoCircle)GeoEntity).Thickness, ((geoCircle)GeoEntity).Color);
		}
		if (GeoEntity.GetType() == typeof(geoPolyline))
		{
			EEntity = new ePolyline(((geoPolyline)GeoEntity).Vertice, (float)((geoPolyline)GeoEntity).Thickness, ((geoPolyline)GeoEntity).Color);
		}
		if (GeoEntity.GetType() == typeof(geoBSpline))
		{
			EEntity = new eBSpline(((geoBSpline)GeoEntity).ControlPoints, (float)((geoBSpline)GeoEntity).Thickness, ((geoBSpline)GeoEntity).Color, ((geoBSpline)GeoEntity).Closed, ((geoBSpline)GeoEntity).BType);
		}
		if (GeoEntity.GetType() == typeof(geoText))
		{
			EEntity = new eText(((geoText)GeoEntity).StartPoint, ((geoText)GeoEntity).TextString, ((geoText)GeoEntity).Height, ((geoText)GeoEntity).Color, ((geoText)GeoEntity).Plane);
		}
		EEntity.TypeDefination = GeoEntity.TypeDefination;
	}

	public static void GeoEntitiyToEEntity(List<geoEntity> GeoEntities, ref List<eEntities> EEntities)
	{
		EEntities.Clear();
		EEntities = new List<eEntities>();
		for (int i = 0; i <= GeoEntities.Count - 1; i++)
		{
			eEntities EEntity = new eEntities();
			GeoEntitiyToEEntity(GeoEntities[i], ref EEntity);
			EEntities.Add(EEntity);
		}
	}

	public static void GeoEntitiyToEEntity(List<List<geoEntity>> GeoEntities, ref List<List<eEntities>> EEntities)
	{
		EEntities.Clear();
		EEntities = new List<List<eEntities>>();
		for (int i = 0; i <= GeoEntities.Count - 1; i++)
		{
			List<eEntities> EEntities2 = new List<eEntities>();
			GeoEntitiyToEEntity(GeoEntities[i], ref EEntities2);
			EEntities.Add(EEntities2);
		}
	}

	public static void EEntitytoGeoEntity(eEntities EEntity, ref geoEntity GeoEntity)
	{
		if (EEntity.GetType() == typeof(ePoint))
		{
			ePoint ePoint2 = new ePoint(EEntity);
			GeoEntity = new geoPoint(ePoint2.StartPoint);
		}
		if (EEntity.GetType() == typeof(eLine))
		{
			eLine eLine2 = new eLine(EEntity);
			GeoEntity = new geoLine(eLine2.StartPoint, eLine2.EndPoint);
		}
		if (EEntity.GetType() == typeof(eArc))
		{
			eArc eArc2 = new eArc(EEntity);
			GeoEntity = new geoArc(eArc2.CenterPoint, eArc2.Radius, eArc2.StartAngle, eArc2.EndAngle, ((eArc)EEntity).Plane);
		}
		if (EEntity.GetType() == typeof(eCircle))
		{
			eCircle eCircle2 = new eCircle(EEntity);
			GeoEntity = new geoCircle(eCircle2.CenterPoint, eCircle2.Radius, eCircle2.Plane);
		}
		if (EEntity.GetType() == typeof(eEllipse))
		{
			eEllipse eEllipse2 = new eEllipse(EEntity);
			GeoEntity = new geoEllipse(eEllipse2.CenterPoint, eEllipse2.MajorRadius, eEllipse2.MinorRadius, eEllipse2.Angle, eEllipse2.Plane);
		}
		if (EEntity.GetType() == typeof(ePolyline))
		{
			ePolyline ePolyline2 = new ePolyline(EEntity);
			GeoEntity = new geoPolyline(ePolyline2.Vertice);
		}
		if (EEntity.GetType() == typeof(eBSpline))
		{
			eBSpline eBSpline2 = new eBSpline(EEntity);
			GeoEntity = new geoBSpline(eBSpline2.ControlPoints, eBSpline2.bClosed, eBSpline2.BType);
		}
		if (EEntity.GetType() == typeof(eText))
		{
			eText eText2 = new eText(EEntity);
			GeoEntity = new geoText(eText2.StartPoint, eText2.TextString, eText2.TextFont, eText2.dispColor, eText2.Height, eText2.Angle);
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
		for (int i = 0; i <= EEntity.Count - 1; i++)
		{
			geoEntity GeoEntity2 = new geoEntity();
			EEntitytoGeoEntity(EEntity[i], ref GeoEntity2);
			GeoEntity2.Layer = EEntity[i].LayerIndex;
			GeoEntity2.Mode = EEntity[i].Mode;
			GeoEntity2.ToolNo = EEntity[i].camToolNo;
			GeoEntity2.Index = EEntity[i].GroupIndex;
			GeoEntity2.TypeDefination = EEntity[i].TypeDefination;
			GeoEntity.Add(GeoEntity2);
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
		Copy(RefEntity, ref CopiedTo);
		return CopiedTo;
	}

	public static geoEntity Decode(List<string> AL, string Char, SerilizationMode Mode)
	{
		geoEntity geoEntity2 = null;
		string text = "";
		if (AL.Count > 0)
		{
			text = AL[0];
			if (text.Length > 0)
			{
				if (text.IndexOf("geoPoint") >= 0)
				{
					geoEntity2 = new geoPoint();
					buSerilization.Decode(AL, "", SerilizationMode.MultiLine, geoEntity2);
				}
				if (text.IndexOf("geoLine") >= 0)
				{
					geoEntity2 = new geoLine();
					buSerilization.Decode(AL, "", SerilizationMode.MultiLine, geoEntity2);
				}
				if (text.IndexOf("geoArc") >= 0)
				{
					geoEntity2 = new geoArc();
					buSerilization.Decode(AL, "", SerilizationMode.MultiLine, geoEntity2);
				}
				if (text.IndexOf("geoCircle") >= 0)
				{
					geoEntity2 = new geoCircle();
					buSerilization.Decode(AL, "", SerilizationMode.MultiLine, geoEntity2);
				}
				if (text.IndexOf("geoEllipse") >= 0)
				{
					geoEntity2 = new geoEllipse();
					buSerilization.Decode(AL, "", SerilizationMode.MultiLine, geoEntity2);
				}
				if (text.IndexOf("geoQuad") >= 0)
				{
					geoEntity2 = new geoQuad();
					buSerilization.Decode(AL, "", SerilizationMode.MultiLine, geoEntity2);
				}
				if (text.IndexOf("geoTriangle") >= 0)
				{
					geoEntity2 = new geoTriangle();
					buSerilization.Decode(AL, "", SerilizationMode.MultiLine, geoEntity2);
				}
				if (text.IndexOf("geoPolyline") >= 0)
				{
					geoEntity2 = new geoPolyline();
					buSerilization.Decode(AL, "", SerilizationMode.MultiLine, geoEntity2);
				}
				if (text.IndexOf("geoBSpline") >= 0)
				{
					geoEntity2 = new geoBSpline();
					buSerilization.Decode(AL, "", SerilizationMode.MultiLine, geoEntity2);
				}
				if (text.IndexOf("geoText") >= 0)
				{
					geoEntity2 = new geoText();
					buSerilization.Decode(AL, "", SerilizationMode.MultiLine, geoEntity2);
				}
			}
		}
		return geoEntity2;
	}

	public ArrayList ToDefAll(int Space)
	{
		string text = new string(' ', Space);
		ArrayList arrayList = new ArrayList();
		if (this == null)
		{
			return new ArrayList();
		}
		buSerilization.ExceptionalVariables.Clear();
		arrayList.Add(text + "<geoEntity>");
		if (GetType() == typeof(geoLine))
		{
			arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
		}
		if (GetType() == typeof(geoPoint))
		{
			arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
		}
		if (GetType() == typeof(geoArc))
		{
			arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
		}
		if (GetType() == typeof(geoCircle))
		{
			arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
		}
		if (GetType() == typeof(geoEllipse))
		{
			arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
		}
		if (GetType() == typeof(geoQuad))
		{
			arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
		}
		if (GetType() == typeof(geoTriangle))
		{
			arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
		}
		if (GetType() == typeof(geoPolyline))
		{
			arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
		}
		if (GetType() == typeof(geoBSpline))
		{
			arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
		}
		if (GetType() == typeof(geoText))
		{
			arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
		}
		arrayList.Add(text + "</geoEntity>");
		return arrayList;
	}

	public override string ToString()
	{
		string result = "";
		if (GetType() == typeof(geoLine))
		{
			result = ((geoLine)this).ToString() + " , Layer : " + Layer + " , Index : " + Layer;
		}
		if (GetType() == typeof(geoArc))
		{
			result = ((geoArc)this).ToString() + " , Layer : " + Layer + " , Index : " + Layer;
		}
		if (GetType() == typeof(geoCircle))
		{
			result = ((geoCircle)this).ToString() + " , Layer : " + Layer + " , Index : " + Layer;
		}
		if (GetType() == typeof(geoTriangle))
		{
			result = ((geoTriangle)this).ToString() + " , Layer : " + Layer + " , Index : " + Layer;
		}
		if (GetType() == typeof(geoQuad))
		{
			result = ((geoQuad)this).ToString() + " , Layer : " + Layer + " , Index : " + Layer;
		}
		if (GetType() == typeof(geoPolyline))
		{
			result = ((geoPolyline)this).ToString() + " , Layer : " + Layer + " , Index : " + Layer;
		}
		return result;
	}
}
