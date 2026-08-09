using System.Linq;
using ACadSharp.Entities;

namespace ACadSharp.IO.DXF;

internal class DxfEntitiesSectionWriter : DxfSectionWriterBase
{
	public override string SectionName => "ENTITIES";

	public DxfEntitiesSectionWriter(IDxfStreamWriter writer, CadDocument document, CadObjectHolder objectHolder, DxfWriterConfiguration configuration)
		: base(writer, document, objectHolder, configuration)
	{
	}

	protected override void writeSection()
	{
		while (base.Holder.Entities.Any())
		{
			Entity entity = base.Holder.Entities.Dequeue();
			writeEntity(entity);
		}
	}
}
