using ACadSharp.Entities;
using ACadSharp.Tables;

namespace ACadSharp.IO.Templates;

internal class CadToleranceTemplate : CadEntityTemplate<Tolerance>
{
	public ulong? DimensionStyleHandle { get; set; }

	public string DimensionStyleName { get; set; }

	public CadToleranceTemplate()
		: base(new Tolerance())
	{
	}

	public CadToleranceTemplate(Tolerance tolerance)
		: base(tolerance)
	{
	}

	protected override void build(CadDocumentBuilder builder)
	{
		base.build(builder);
		if (getTableReference<DimensionStyle>(builder, DimensionStyleHandle, DimensionStyleName, out var reference))
		{
			base.CadObject.Style = reference;
		}
	}
}
