using System.Collections.Generic;
using System.Linq;
using ACadSharp.Entities;

namespace ACadSharp.IO.Templates;

internal class CadPolyLineTemplate : CadEntityTemplate, ICadOwnerTemplate, ICadObjectTemplate, ICadTemplate
{
	internal class PolyLinePlaceholder : Polyline<Vertex>
	{
		public override ObjectType ObjectType => ObjectType.INVALID;
	}

	public ulong? FirstVertexHandle { get; internal set; }

	public ulong? LastVertexHandle { get; internal set; }

	public IPolyline PolyLine => base.CadObject as IPolyline;

	public ulong? SeqendHandle { get; internal set; }

	public HashSet<ulong> OwnedObjectsHandlers { get; } = new HashSet<ulong>();

	public CadPolyLineTemplate()
		: base(new PolyLinePlaceholder())
	{
	}

	public CadPolyLineTemplate(IPolyline entity)
		: base((Entity)entity)
	{
	}

	public void SetPolyLineObject<T>(Polyline<T> polyLine) where T : Entity, IVertex
	{
		polyLine.Handle = base.CadObject.Handle;
		polyLine.Color = base.CadObject.Color;
		polyLine.LineWeight = base.CadObject.LineWeight;
		polyLine.LineTypeScale = base.CadObject.LineTypeScale;
		polyLine.IsInvisible = base.CadObject.IsInvisible;
		polyLine.Transparency = base.CadObject.Transparency;
		base.CadObject = polyLine;
	}

	protected void addVertices(CadDocumentBuilder builder, params IEnumerable<IVertex> vertices)
	{
		Entity cadObject = base.CadObject;
		if (!(cadObject is Polyline2D polyline2D))
		{
			if (!(cadObject is Polyline3D polyline3D))
			{
				if (cadObject is PolyfaceMesh polyfaceMesh)
				{
					polyfaceMesh.Vertices.AddRange(vertices.Cast<VertexFaceMesh>());
				}
				else
				{
					builder.Notify("Unknown polyline type " + base.CadObject.SubclassMarker, NotificationType.Warning);
				}
			}
			else
			{
				polyline3D.Vertices.AddRange(vertices.Cast<Vertex3D>());
			}
		}
		else
		{
			polyline2D.Vertices.AddRange(vertices.Cast<Vertex2D>());
		}
	}

	protected override void build(CadDocumentBuilder builder)
	{
		base.build(builder);
		_ = base.CadObject;
		if (builder.TryGetCadObject<Seqend>(SeqendHandle, out var value))
		{
			setSeqend(builder, value);
		}
		if (FirstVertexHandle.HasValue)
		{
			IEnumerable<Vertex> entitiesCollection = getEntitiesCollection<Vertex>(builder, FirstVertexHandle.Value, LastVertexHandle.Value);
			addVertices(builder, entitiesCollection);
			return;
		}
		if (base.CadObject is PolyfaceMesh polyfaceMesh)
		{
			buildPolyfaceMesh(polyfaceMesh, builder);
			return;
		}
		foreach (ulong ownedObjectsHandler in OwnedObjectsHandlers)
		{
			Seqend value3;
			if (builder.TryGetCadObject<Vertex>(ownedObjectsHandler, out var value2))
			{
				addVertices(builder, new _003C_003Ez__ReadOnlySingleElementList<IVertex>(value2));
			}
			else if (builder.TryGetCadObject<Seqend>(ownedObjectsHandler, out value3))
			{
				setSeqend(builder, value3);
			}
			else
			{
				builder.Notify($"Vertex {ownedObjectsHandler} not found for polyline {base.CadObject.Handle}", NotificationType.Warning);
			}
		}
	}

	protected void setSeqend(CadDocumentBuilder builder, Seqend seqend)
	{
		Entity cadObject = base.CadObject;
		if (!(cadObject is Polyline2D polyline2D))
		{
			if (!(cadObject is Polyline3D polyline3D))
			{
				if (cadObject is PolyfaceMesh polyfaceMesh)
				{
					polyfaceMesh.Vertices.Seqend = seqend;
				}
				else
				{
					builder.Notify("Unknown polyline type " + base.CadObject.SubclassMarker, NotificationType.Warning);
				}
			}
			else
			{
				polyline3D.Vertices.Seqend = seqend;
			}
		}
		else
		{
			polyline2D.Vertices.Seqend = seqend;
		}
	}

	private void buildPolyfaceMesh(PolyfaceMesh polyfaceMesh, CadDocumentBuilder builder)
	{
		foreach (ulong ownedObjectsHandler in OwnedObjectsHandlers)
		{
			if (builder.TryGetCadObject<Entity>(ownedObjectsHandler, out var value))
			{
				if (value is VertexFaceMesh item)
				{
					polyfaceMesh.Vertices.Add(item);
				}
				else if (value is VertexFaceRecord item2)
				{
					polyfaceMesh.Faces.Add(item2);
				}
				else if (value is Seqend seqend)
				{
					polyfaceMesh.Vertices.Seqend = seqend;
				}
				else
				{
					builder.Notify("Unidentified type for PolyfaceMesh " + value.GetType().FullName);
				}
			}
		}
	}
}
