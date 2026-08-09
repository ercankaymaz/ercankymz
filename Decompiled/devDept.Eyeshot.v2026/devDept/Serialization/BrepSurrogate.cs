using System;
using System.Collections.Generic;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public class BrepSurrogate : EntitySurrogate
{
	internal GBrep Primitive;

	public LinearPath[] GraphicalEdges;

	public Entity[] TessellationFaces;

	public List<ProtoJaggedArray<Entity>> TessellationInners;

	public Point3D[] Vertices;

	public Brep.Edge[] Edges;

	public Brep.Face[] Faces;

	public List<ProtoJaggedArray<Brep.Face>> Inners;

	public double RebuildTolerance;

	public BrepSurrogate(Brep brep)
		: base(brep)
	{
	}

	protected internal Point3D[] GetVertices()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return Vertices;
		}
		return Primitive.Vertices;
	}

	protected internal Brep.Edge[] GetEdges()
	{
		Brep.Edge[] edges;
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			edges = Edges;
			if (edges == null)
			{
				return Array.Empty<Brep.Edge>();
			}
		}
		else
		{
			edges = Primitive.Edges;
		}
		return edges;
	}

	protected internal Brep.Face[] GetFaces()
	{
		Brep.Face[] faces;
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			faces = Faces;
			if (faces == null)
			{
				return Array.Empty<Brep.Face>();
			}
		}
		else
		{
			faces = Primitive.Faces;
		}
		return faces;
	}

	protected internal Brep.Face[][] GetInners()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return Inners?.ToJaggedArray();
		}
		return Primitive.Inners;
	}

	protected internal double GetRebuildTolerance()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return RebuildTolerance;
		}
		return Primitive.RebuildTolerance;
	}

	protected override Entity ConvertToObject()
	{
		Brep.Face[][] inners = GetInners();
		if (base.Content == contentType.Tessellation)
		{
			Brep brep = new Brep(GetFaces(), inners);
			CopyDataToObject(brep);
			Mesh.natureType nature = (string.IsNullOrEmpty(MaterialName) ? Mesh.natureType.Smooth : Mesh.natureType.RichSmooth);
			Mesh mesh = null;
			if (brep.Faces[0].Tessellation != null)
			{
				mesh = brep.ConvertToMesh(0.0, 0.0, nature, weld: false);
			}
			if (mesh != null)
			{
				CopyDataToObject(mesh);
				return mesh;
			}
			WriteLog(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302669348));
			return CreateGhostEntity(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302669545));
		}
		Brep brep2 = new Brep(this);
		CopyDataToObject(brep2);
		return brep2;
	}

	protected override void CopyDataToObject(Entity entity)
	{
		if (entity is Brep brep)
		{
			brep.RebuildTolerance = RebuildTolerance;
			if (Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
			{
				brep.RebuildTolerance = Primitive.RebuildTolerance;
				if (GraphicalEdges != null && Primitive.Edges != null)
				{
					for (int i = 0; i < Primitive.Edges.Length; i++)
					{
						Entity entity2 = (Entity)Primitive.Edges[i].Curve;
						LinearPath linearPath = GraphicalEdges[i];
						entity2.Vertices = linearPath.Vertices;
						if (base.Content == contentType.GeometryAndTessellation)
						{
							entity2.RegenMode = regenType.CompileOnly;
							entity2.UpdateBoundingBox(null);
						}
					}
				}
				FastMesh[] array = EntitySurrogate._0023_003Dz7cReF5XErES5a62AbKubYBSe22Kb(TessellationFaces);
				for (int j = 0; j < array.Length; j++)
				{
					brep.Faces[j].Tessellation = array[j];
					if (base.Content == contentType.GeometryAndTessellation)
					{
						brep.Faces[j].Tessellation.RegenMode = regenType.CompileOnly;
						brep.Faces[j].Tessellation.UpdateBoundingBox(null);
					}
				}
				if (TessellationInners != null)
				{
					Entity[][] array2 = TessellationInners.ToJaggedArray();
					for (int k = 0; k < array2.Length; k++)
					{
						FastMesh[] array3 = EntitySurrogate._0023_003Dz7cReF5XErES5a62AbKubYBSe22Kb(array2[k]);
						for (int l = 0; l < array3.Length; l++)
						{
							brep.Inners[k][l].Tessellation = array3[l];
							if (base.Content == contentType.GeometryAndTessellation)
							{
								brep.Inners[k][l].Tessellation.RegenMode = regenType.CompileOnly;
								brep.Inners[k][l].Tessellation.UpdateBoundingBox(null);
							}
						}
					}
				}
			}
		}
		base.CopyDataToObject(entity);
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		Vertices = entity.Vertices;
		if (entity is Brep brep)
		{
			Edges = brep.Edges;
			Faces = brep.Faces;
			Inners = brep.Inners.ToProtoJaggedArrayList();
			RebuildTolerance = brep.RebuildTolerance;
		}
		base.CopyDataFromObject(entity);
	}
}
