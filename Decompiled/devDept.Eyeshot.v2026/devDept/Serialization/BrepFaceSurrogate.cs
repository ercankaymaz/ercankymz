using System;
using System.Drawing;
using ProtoBuf;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public class BrepFaceSurrogate : Surrogate<Brep.Face>
{
	public int? ARGB;

	public AnalyticSurf Surface;

	public Brep.Loop[] Loops;

	public bool Sense;

	public Color? Color;

	public string MaterialName;

	public Entity[] Tessellation;

	public float TextureOffsetU;

	public float TextureScaleU;

	public float TextureOffsetV;

	public float TextureScaleV;

	public float TextureRotationAngle;

	public ProtoObject FaceData;

	protected contentType DeserializationContent;

	public BrepFaceSurrogate(Brep.Face face)
		: base(face)
	{
	}

	protected internal Color? GetColor()
	{
		if (Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			if (ARGB.HasValue)
			{
				return System.Drawing.Color.FromArgb(ARGB.Value);
			}
			return null;
		}
		return Color;
	}

	protected override Brep.Face ConvertToObject()
	{
		Brep.Face face = new Brep.Face(this);
		CopyDataToObject(face);
		return face;
	}

	protected override void CopyDataToObject(Brep.Face face)
	{
		face.Sense = Sense;
		face.Color = GetColor();
		face.MaterialName = MaterialName;
		if (Tessellation != null)
		{
			if (base.Version <= 9)
			{
				Mesh mesh = ((!(Tessellation[0] is Ghost)) ? ((Mesh)Tessellation[0]) : new Mesh(0, 0, Mesh.natureType.Undefined));
				if (Tessellation.Length > 1)
				{
					mesh = new Mesh(mesh.Vertices, mesh.Triangles);
					for (int i = 1; i < Tessellation.Length; i++)
					{
						Mesh mesh2 = ((!(Tessellation[i] is Ghost)) ? ((Mesh)Tessellation[i]) : new Mesh(0, 0, Mesh.natureType.Undefined));
						mesh.MergeWith(new Mesh(mesh2.Vertices, mesh2.Triangles), weldNow: false, recomputeEdges: false);
					}
				}
				face.Tessellation = mesh.ConvertToFastMesh();
				if (Tessellation[0] is Brep.TessellationMesh tessellationMesh)
				{
					face.TextureOffsetU = tessellationMesh.TextureOffsetU;
					face.TextureScaleU = tessellationMesh.TextureScaleU;
					face.TextureOffsetV = tessellationMesh.TextureOffsetV;
					face.TextureScaleV = tessellationMesh.TextureScaleV;
				}
			}
			else
			{
				face.Tessellation = EntitySurrogate._0023_003Dz7cReF5XErES5a62AbKubYBSe22Kb(Tessellation)[0];
			}
		}
		face.TextureOffsetU = TextureOffsetU;
		face.TextureScaleU = TextureScaleU;
		face.TextureOffsetV = TextureOffsetV;
		face.TextureScaleV = TextureScaleV;
		face.TextureRotationAngle = TextureRotationAngle;
		if (FaceData != null)
		{
			face.FaceData = FaceData.Object;
		}
	}

	protected override void CopyDataFromObject(Brep.Face face)
	{
		Surface = face.Surface;
		Loops = face.Loops;
		Sense = face.Sense;
		Color = face.Color;
		MaterialName = face.MaterialName;
		Tessellation = new Entity[1] { face.Tessellation };
		TextureOffsetU = face.TextureOffsetU;
		TextureScaleU = face.TextureScaleU;
		TextureOffsetV = face.TextureOffsetV;
		TextureScaleV = face.TextureScaleV;
		TextureRotationAngle = face.TextureRotationAngle;
		if (face.FaceData != null)
		{
			FaceData = new ProtoObject(face.FaceData);
		}
	}

	[CLSCompliant(false)]
	protected override void BeforeDeserialize(SerializationContext serializationContext)
	{
		base.BeforeDeserialize(serializationContext);
		if (!(serializationContext.Context is FileSerializer fileSerializer))
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302669432));
		}
		DeserializationContent = fileSerializer.Content;
	}

	public static implicit operator Brep.Face(BrepFaceSurrogate surrogate)
	{
		return surrogate?.ConvertToObject();
	}

	public static implicit operator BrepFaceSurrogate(Brep.Face source)
	{
		return source?.ConvertToSurrogate();
	}
}
