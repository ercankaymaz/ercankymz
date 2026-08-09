using ACadSharp.Entities;
using ACadSharp.Tables;

namespace ACadSharp.IO.Templates;

internal class CadLeaderTemplate : CadEntityTemplate<Leader>
{
	public double Dimasz { get; set; }

	public ulong DIMSTYLEHandle { get; set; }

	public string DIMSTYLEName { get; set; }

	public ulong AnnotationHandle { get; set; }

	public CadLeaderTemplate()
		: base(new Leader())
	{
	}

	public CadLeaderTemplate(Leader entity)
		: base(entity)
	{
	}

	protected override void build(CadDocumentBuilder builder)
	{
		base.build(builder);
		Leader cadObject = base.CadObject;
		if (getTableReference<DimensionStyle>(builder, DIMSTYLEHandle, DIMSTYLEName, out var reference))
		{
			cadObject.Style = reference;
		}
		if (builder.TryGetCadObject<Entity>(AnnotationHandle, out var value))
		{
			cadObject.AssociatedAnnotation = value;
		}
	}
}
