using ACadSharp.Entities;

namespace ACadSharp.IO.Templates;

internal class CadVertexTemplate : CadEntityTemplate
{
	public class VertexPlaceholder : Vertex
	{
		public override ObjectType ObjectType => ObjectType.INVALID;
	}

	public Vertex Vertex => base.CadObject as Vertex;

	public CadVertexTemplate()
		: base(new VertexPlaceholder())
	{
	}

	public CadVertexTemplate(Vertex vertex)
		: base(vertex)
	{
	}

	internal void SetVertexObject(Vertex vertex)
	{
		vertex.Handle = base.CadObject.Handle;
		vertex.Owner = base.CadObject.Owner;
		vertex.XDictionary = base.CadObject.XDictionary;
		vertex.Color = base.CadObject.Color;
		vertex.LineWeight = base.CadObject.LineWeight;
		vertex.LineTypeScale = base.CadObject.LineTypeScale;
		vertex.IsInvisible = base.CadObject.IsInvisible;
		vertex.Transparency = base.CadObject.Transparency;
		Vertex vertex2 = base.CadObject as Vertex;
		vertex.Location = vertex2.Location;
		vertex.StartWidth = vertex2.StartWidth;
		vertex.EndWidth = vertex2.EndWidth;
		vertex.Bulge = vertex2.Bulge;
		vertex.Flags = vertex2.Flags;
		vertex.CurveTangent = vertex2.CurveTangent;
		vertex.Id = vertex2.Id;
		base.CadObject = vertex;
	}
}
