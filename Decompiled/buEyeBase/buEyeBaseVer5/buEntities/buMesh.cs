using System.Collections.Generic;
using System.Drawing;
using buClass;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.buEntities;

public class buMesh : buEntity
{
	public List<IndexTriangle> Triangles = null;

	public Mesh.natureType MeshNature = Mesh.natureType.RichSmooth;

	public Mesh.edgeStyleType EdgeStyle = Mesh.edgeStyleType.None;

	public buMesh()
	{
	}

	public buMesh(buMesh another)
	{
		if (another.Shape != null)
		{
			Shape = new EntityShapeInfo(another.Shape);
		}
		if (another.Info != null)
		{
			Info = new EntityInfo(another.Info);
		}
		if (another.Cutter != null)
		{
			Cutter = new CutterInfo(another.Cutter);
		}
		if (another.Sewing != null)
		{
			Sewing = new SewingInfo(another.Sewing);
		}
		if (another.Marble != null)
		{
			Marble = new MarbleInfo(another.Marble);
		}
		if (another.Dimension != null)
		{
			Dimension = new DimensionInfo(another.Dimension);
		}
		if (another.Vertices != null)
		{
			for (int i = 0; i <= another.Vertices.Count - 1; i++)
			{
				Vertices.Add(new Point3D(another.Vertices[i].X, another.Vertices[i].Y, another.Vertices[i].Z));
			}
		}
		BoxMin = new Point3D(another.BoxMin.X, another.BoxMin.Y, another.BoxMin.Z);
		BoxMax = new Point3D(another.BoxMax.X, another.BoxMax.Y, another.BoxMax.Z);
		sortDirection = another.sortDirection;
		typeDefination = another.typeDefination;
		Orientation = new OrientationAngle(another.Orientation);
		ToolName = another.ToolName;
		LayerName = another.LayerName;
		LayerIndex = another.LayerIndex;
		Color = another.Color;
		Thickness = another.Thickness;
		if (another.Triangles != null)
		{
			Triangles = new List<IndexTriangle>();
			for (int j = 0; j <= another.Triangles.Count - 1; j++)
			{
				Triangles.Add(new IndexTriangle(another.Triangles[j].V1, another.Triangles[j].V2, another.Triangles[j].V3));
			}
		}
	}

	public buMesh(IList<Point3D> vertices, IList<IndexTriangle> triangles)
	{
		if (Vertices != null)
		{
			for (int i = 0; i <= vertices.Count - 1; i++)
			{
				Vertices.Add(new Point3D(vertices[i].X, vertices[i].Y, vertices[i].Z));
			}
		}
		if (triangles != null)
		{
			Triangles = new List<IndexTriangle>();
			for (int j = 0; j <= triangles.Count - 1; j++)
			{
				Triangles.Add(new IndexTriangle(triangles[j].V1, triangles[j].V2, triangles[j].V3));
			}
		}
	}

	public buMesh(Mesh another)
	{
		if (another.Vertices != null)
		{
			for (int i = 0; i <= another.Vertices.Length - 1; i++)
			{
				Vertices.Add(new Point3D(another.Vertices[i].X, another.Vertices[i].Y, another.Vertices[i].Z));
			}
		}
		LayerName = another.LayerName;
		if (buCall.list_0 != null && buCall.list_0.Count > 0)
		{
			Color colorLayer = another.Color;
			if (buEyeShotFunctions.GetLayerColorFromName(another.LayerName, ref colorLayer))
			{
				Color = colorLayer;
			}
		}
		if (another.Triangles != null)
		{
			Triangles = new List<IndexTriangle>();
			for (int j = 0; j <= another.Triangles.Length - 1; j++)
			{
				Triangles.Add(new IndexTriangle(another.Triangles[j].V1, another.Triangles[j].V2, another.Triangles[j].V3));
			}
		}
	}

	public override string ToString()
	{
		string text = "Mesh ";
		if (Vertices.Count > 0)
		{
			text = text + "Ver: " + Vertices.Count;
		}
		if (typeDefination != entityTypeDefination.None)
		{
			text = text + " Type: " + typeDefination;
		}
		if (Info.CamSelected)
		{
			text = text + " CamSelected: " + Info.CamSelected;
		}
		if (Info.Calculated)
		{
			text = text + " Calculated: " + Info.Calculated;
		}
		if (Info.RefIndex >= 0)
		{
			text = text + " Ref Index: " + Info.RefIndex;
		}
		return text;
	}
}
