using devDept.Eyeshot.Entities;

namespace devDept.Serialization;

public class BrepEdgeSurrogate : Surrogate<Brep.Edge>
{
	internal GEntity curve_2022;

	public int StartPointIndex;

	public int EndPointIndex;

	public Entity Curve;

	public int ShellIndex;

	public int[] Parents;

	public ProtoObject EdgeData;

	public BrepEdgeSurrogate(Brep.Edge edge)
		: base(edge)
	{
	}

	protected internal Entity GetCurve()
	{
		if (!Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.Version))
		{
			return Curve;
		}
		return GEntity.CreateEntityFromPrimitive(curve_2022);
	}

	protected override Brep.Edge ConvertToObject()
	{
		Brep.Edge edge = new Brep.Edge(this);
		CopyDataToObject(edge);
		return edge;
	}

	protected override void CopyDataToObject(Brep.Edge edge)
	{
		edge.ShellIndex = ShellIndex;
		edge.Parents = Parents;
		if (EdgeData != null)
		{
			edge.EdgeData = EdgeData.Object;
		}
	}

	protected override void CopyDataFromObject(Brep.Edge edge)
	{
		StartPointIndex = edge.StartPointIndex;
		EndPointIndex = edge.EndPointIndex;
		Curve = (Entity)edge.Curve;
		ShellIndex = edge.ShellIndex;
		Parents = edge.Parents;
		if (edge.EdgeData != null)
		{
			EdgeData = new ProtoObject(edge.EdgeData);
		}
	}

	public static implicit operator Brep.Edge(BrepEdgeSurrogate surrogate)
	{
		return surrogate?.ConvertToObject();
	}

	public static implicit operator BrepEdgeSurrogate(Brep.Edge source)
	{
		return source?.ConvertToSurrogate();
	}
}
