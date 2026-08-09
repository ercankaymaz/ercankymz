using System.Collections.Generic;
using ACadSharp.Entities;

namespace ACadSharp.IO.Templates;

internal class CadPolyfaceMeshTemplate : CadEntityTemplate
{
	public ulong? FirstVerticeHandle { get; set; }

	public ulong? LastVerticeHandle { get; set; }

	public HashSet<ulong> VerticesHandles { get; set; } = new HashSet<ulong>();

	public ulong? SeqendHandle { get; set; }

	public CadPolyfaceMeshTemplate(PolyfaceMesh polyfaceMesh)
		: base(polyfaceMesh)
	{
	}

	protected override void build(CadDocumentBuilder builder)
	{
		base.build(builder);
		PolyfaceMesh polyfaceMesh = (PolyfaceMesh)base.CadObject;
		if (builder.TryGetCadObject<Seqend>(SeqendHandle, out var value))
		{
			polyfaceMesh.Vertices.Seqend = value;
		}
		if (FirstVerticeHandle.HasValue)
		{
			foreach (Entity item in getEntitiesCollection<Entity>(builder, FirstVerticeHandle.Value, LastVerticeHandle.Value))
			{
				addItemToPolyface(item, builder);
			}
			return;
		}
		foreach (ulong verticesHandle in VerticesHandles)
		{
			if (builder.TryGetCadObject<CadObject>(verticesHandle, out var value2))
			{
				addItemToPolyface(value2, builder);
			}
		}
	}

	private void addItemToPolyface(CadObject item, CadDocumentBuilder builder)
	{
		PolyfaceMesh polyfaceMesh = (PolyfaceMesh)base.CadObject;
		if (item is VertexFaceMesh item2)
		{
			polyfaceMesh.Vertices.Add(item2);
		}
		else if (item is VertexFaceRecord item3)
		{
			polyfaceMesh.Faces.Add(item3);
		}
		else
		{
			builder.Notify("Unidentified type for PolyfaceMesh " + item.GetType().FullName);
		}
	}
}
