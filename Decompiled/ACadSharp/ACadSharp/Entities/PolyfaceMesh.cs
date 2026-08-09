using ACadSharp.Attributes;

namespace ACadSharp.Entities;

[DxfName("POLYLINE")]
[DxfSubClass("AcDbPolyFaceMesh")]
public class PolyfaceMesh : Polyline<VertexFaceMesh>
{
	public override ObjectType ObjectType => ObjectType.POLYLINE_PFACE;

	public override string ObjectName => "POLYLINE";

	public override string SubclassMarker => "AcDbPolyFaceMesh";

	public CadObjectCollection<VertexFaceRecord> Faces { get; private set; }

	public PolyfaceMesh()
	{
		Faces = new CadObjectCollection<VertexFaceRecord>(this);
	}

	public override CadObject Clone()
	{
		PolyfaceMesh polyfaceMesh = (PolyfaceMesh)base.Clone();
		polyfaceMesh.Faces = new SeqendCollection<VertexFaceRecord>(polyfaceMesh);
		foreach (VertexFaceRecord face in Faces)
		{
			polyfaceMesh.Faces.Add((VertexFaceRecord)face.Clone());
		}
		return polyfaceMesh;
	}

	internal override void AssignDocument(CadDocument doc)
	{
		base.AssignDocument(doc);
		doc.RegisterCollection(Faces);
	}

	internal override void UnassignDocument()
	{
		base.Document.UnregisterCollection(Faces);
		base.UnassignDocument();
	}
}
