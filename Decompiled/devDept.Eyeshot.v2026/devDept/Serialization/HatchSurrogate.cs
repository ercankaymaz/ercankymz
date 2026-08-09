using System.Collections.Generic;
using System.Linq;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public class HatchSurrogate : EntitySurrogate
{
	internal List<GEntity> ContourList_2022;

	internal List<ProtoJaggedArray<Point3D>> ContourVertices;

	public Plane Plane;

	public List<Entity> ContourList;

	public Point3D[] Vertices;

	public IndexTriangle[] Triangles;

	internal Point3D[] PatternLines;

	internal Point3D[] PatternPoints;

	public string PatternName;

	public float PatternScale;

	public double PatternAngle;

	public Point2D PatternOrigin;

	public double PatternSpacing;

	public bool PatternDouble;

	public bool IsUserDefinedPattern;

	public HatchSurrogate(Hatch hatch)
		: base(hatch)
	{
	}

	protected internal List<Entity> GetContourList()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return ContourList;
		}
		return GEntity.CreateEntitiesFromPrimitives(ContourList_2022);
	}

	protected override Entity ConvertToObject()
	{
		if (base.Content == contentType.Tessellation)
		{
			if (Triangles != null)
			{
				return CreateMeshOrGhostEntity(Vertices, Triangles, typeof(Hatch));
			}
			List<Point3D> list = new List<Point3D>();
			if (PatternLines != null)
			{
				list.AddRange(PatternLines);
			}
			if (PatternPoints != null)
			{
				Point3D[] patternPoints = PatternPoints;
				foreach (Point3D point3D in patternPoints)
				{
					list.Add(point3D);
					list.Add((Point3D)point3D.Clone());
				}
			}
			return CreatePointCloudOrGhostEntity(list.ToArray(), typeof(Hatch));
		}
		Hatch hatch = new Hatch(this);
		CopyDataToObject(hatch);
		return hatch;
	}

	protected override void CopyDataToObject(Entity entity)
	{
		if (entity is Hatch hatch)
		{
			hatch.contourList = GetContourList().Cast<ICurve>().ToList();
			if (Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
			{
				CompositeCurveSurrogate._0023_003DzRg_0024kh6sN6YXfeaJKgQ_003D_003D(hatch.ContourList, ContourVertices?.ToJaggedArray());
			}
			hatch.Vertices = Vertices;
			hatch.Triangles = Triangles;
			hatch.patternLines = PatternLines ?? new Point3D[0];
			hatch.patternPoints = PatternPoints ?? new Point3D[0];
			hatch.PatternName = PatternName;
			hatch.PatternScale = PatternScale;
			hatch.PatternAngle = PatternAngle;
			hatch.PatternOrigin = PatternOrigin;
			hatch.PatternSpacing = PatternSpacing;
			hatch.PatternDouble = PatternDouble;
			hatch.IsUserDefinedPattern = IsUserDefinedPattern;
			if (Triangles != null)
			{
				hatch.entityNature = entityNatureType.Polygon;
			}
		}
		base.CopyDataToObject(entity);
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		Hatch hatch = (Hatch)entity;
		Plane = hatch.Plane;
		ContourList = hatch.ContourList.Cast<Entity>().ToList();
		Vertices = hatch.Vertices;
		Triangles = hatch.Triangles;
		PatternLines = hatch.patternLines;
		PatternPoints = hatch.patternPoints;
		PatternName = hatch.PatternName;
		PatternScale = hatch.PatternScale;
		PatternAngle = hatch.PatternAngle;
		PatternOrigin = hatch.PatternOrigin;
		PatternSpacing = hatch.PatternSpacing;
		PatternDouble = hatch.PatternDouble;
		IsUserDefinedPattern = hatch.IsUserDefinedPattern;
		base.CopyDataFromObject(entity);
	}

	protected override bool CheckSurrogateData(string logMessage = null)
	{
		if (base.Content == contentType.Tessellation)
		{
			if (PatternName.Equals(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970485)))
			{
				if (Vertices == null || ((Vertices.Length == 0) | (Triangles == null)) || Triangles.Length == 0)
				{
					WriteLog((logMessage != null) ? logMessage : _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302671776));
					return false;
				}
			}
			else if ((PatternLines == null || PatternLines.Length == 0) && (PatternPoints == null || PatternPoints.Length == 0))
			{
				WriteLog((logMessage != null) ? logMessage : _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302671456));
				return false;
			}
		}
		return true;
	}
}
