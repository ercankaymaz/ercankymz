using ACadSharp.Entities;
using ACadSharp.Tables;

namespace ACadSharp.IO.Templates;

internal class CadTextEntityTemplate : CadEntityTemplate
{
	public ulong? StyleHandle { get; set; }

	public string StyleName { get; set; }

	public CadTextEntityTemplate(Entity entity)
		: base(entity)
	{
	}

	protected override void build(CadDocumentBuilder builder)
	{
		base.build(builder);
		IText text = (IText)base.CadObject;
		if (getTableReference<TextStyle>(builder, StyleHandle, StyleName, out var reference))
		{
			text.Style = reference;
		}
	}
}
