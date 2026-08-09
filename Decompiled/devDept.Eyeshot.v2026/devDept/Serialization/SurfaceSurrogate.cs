using System.Collections.Generic;
using ProtoBuf;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public class SurfaceSurrogate : NurbsBaseSurrogate
{
	internal GSurface Primitive;

	internal List<ProtoArray<Point3D>> graphicalEdge;

	public IndexTriangle[] Triangles;

	public ProtoArray<Point4D> Pw;

	public int q;

	public double[] V;

	public Region Trimming;

	internal List<ProtoArray<Point3D>> geomIsocurves;

	public float TextureScaleU;

	public float TextureScaleV;

	public float TextureOffsetU;

	public float TextureOffsetV;

	public float TextureRotationAngle;

	public SurfaceSurrogate(Surface surf)
		: base(surf)
	{
	}

	protected internal override int GetP()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return p;
		}
		return Primitive.P;
	}

	protected internal override double[] GetU()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return U;
		}
		return Primitive.U;
	}

	protected internal int GetQ()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return q;
		}
		return Primitive.DegreeV;
	}

	protected internal double[] GetV()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return V;
		}
		return Primitive.KnotVectorV;
	}

	protected internal Point4D[,] GetPw()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return Pw.ToArray() as Point4D[,];
		}
		return Primitive.ControlPoints;
	}

	protected override Entity ConvertToObject()
	{
		if (base.Content == contentType.Tessellation)
		{
			if (!CheckSurrogateData())
			{
				return new Mesh
				{
					Vertices = new Point3D[0],
					Triangles = new IndexTriangle[0]
				};
			}
			Mesh.natureType _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D = (string.IsNullOrEmpty(MaterialName) ? Mesh.natureType.Smooth : Mesh.natureType.RichSmooth);
			Mesh mesh = new Mesh();
			mesh.ColorMethod = (colorMethodType)ColorMethod;
			mesh.Color = Color;
			mesh.MaterialName = MaterialName;
			Mesh mesh2 = Utility._0023_003DzqTukDnG3QxvA22yeWQ_003D_003D(Vertices, Triangles, _0023_003DzMvUkVakm8y_NrM0qvQ_003D_003D, TextureOffsetU, TextureScaleU, TextureOffsetV, TextureScaleV, TextureRotationAngle, mesh, null, _0023_003DzTJ4ZjnpzOkzX: false, null, null);
			CopyDataToObject(mesh2);
			return mesh2;
		}
		Surface surface = new Surface(this);
		CopyDataToObject(surface);
		return surface;
	}

	protected override void CopyDataToObject(Entity entity)
	{
		if (entity is Surface surface)
		{
			surface._triangles = Triangles;
			if (Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
			{
				surface.Pw = Primitive.ControlPoints;
				surface.q = Primitive.DegreeV;
				surface.V = Primitive.KnotVectorV;
				surface._trimming = (Region)GEntity.CreateEntityFromPrimitive(Primitive.Trimming);
				if (graphicalEdge != null)
				{
					int num = 0;
					for (int i = 0; i < surface.Trimming.ContourList.Count; i++)
					{
						ICurve[] individualCurves = surface.Trimming.ContourList[i].GetIndividualCurves();
						for (int j = 0; j < individualCurves.Length; j++)
						{
							Entity entity2 = (Entity)((TrimCurve)individualCurves[j]).Edge;
							entity2.Vertices = graphicalEdge[num++].ToArray() as Point3D[];
							if (base.Content == contentType.GeometryAndTessellation)
							{
								entity2.RegenMode = regenType.CompileOnly;
								entity2.UpdateBoundingBox(null);
							}
						}
					}
				}
				surface.TextureScaleU = Primitive.TextureScaleU;
				surface.TextureScaleV = Primitive.TextureScaleV;
				surface.TextureOffsetU = Primitive.TextureOffsetU;
				surface.TextureOffsetV = Primitive.TextureOffsetV;
			}
			else
			{
				surface.Pw = Pw.ToArray() as Point4D[,];
				surface.q = q;
				surface.V = V;
				surface._trimming = Trimming;
				surface.TextureScaleU = TextureScaleU;
				surface.TextureScaleV = TextureScaleV;
				surface.TextureOffsetU = TextureOffsetU;
				surface.TextureOffsetV = TextureOffsetV;
				surface.TextureRotationAngle = TextureRotationAngle;
			}
			surface.geomIsocurves = new List<Point3D[]>();
			if (geomIsocurves != null)
			{
				foreach (ProtoArray<Point3D> geomIsocurf in geomIsocurves)
				{
					surface.geomIsocurves.Add(geomIsocurf.ToArray() as Point3D[]);
				}
			}
		}
		base.CopyDataToObject(entity);
	}

	protected override bool CheckSurrogateData(string logMessage = null)
	{
		if (base.Content == contentType.Tessellation && (Vertices == null || Vertices.Length == 0))
		{
			WriteLog(logMessage ?? _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302672814));
			return false;
		}
		return true;
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		Surface surface = (Surface)entity;
		Triangles = surface.Triangles;
		Pw = surface.Pw.ToProtoArray<Point4D>();
		q = surface.q;
		V = surface.V;
		Trimming = surface._trimming;
		if (surface.geomIsocurves != null)
		{
			geomIsocurves = new List<ProtoArray<Point3D>>();
			foreach (Point3D[] geomIsocurf in surface.geomIsocurves)
			{
				geomIsocurves.Add(geomIsocurf.ToProtoArray<Point3D>());
			}
		}
		TextureScaleU = surface.TextureScaleU;
		TextureScaleV = surface.TextureScaleV;
		TextureOffsetU = surface.TextureOffsetU;
		TextureOffsetV = surface.TextureOffsetV;
		TextureRotationAngle = surface.TextureRotationAngle;
		base.CopyDataFromObject(entity);
	}

	protected override void AfterDeserialize(SerializationContext serializationContext)
	{
		base.AfterDeserialize(serializationContext);
		if (Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version) && Primitive?.EntityData != null)
		{
			EntityData = new ProtoObject(Primitive.EntityData);
		}
	}
}
