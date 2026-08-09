using ACadSharp.Tables;

namespace ACadSharp.IO.Templates;

internal class CadTableEntryTemplate<T> : CadTemplate<T>, ICadTableEntryTemplate, ICadObjectTemplate, ICadTemplate where T : TableEntry
{
	public string Type => typeof(T).Name;

	public string Name => base.CadObject.Name;

	public CadTableEntryTemplate(T entry)
		: base(entry)
	{
	}

	protected override void build(CadDocumentBuilder builder)
	{
		base.build(builder);
	}
}
