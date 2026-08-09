using ACadSharp.Tables;

namespace ACadSharp.IO.Templates;

internal class CadVPortTemplate : CadTableEntryTemplate<VPort>
{
	public ulong VportControlHandle { get; set; }

	public ulong? BackgroundHandle { get; set; }

	public ulong? StyleHandle { get; set; }

	public ulong? SunHandle { get; set; }

	public ulong? NamedUcsHandle { get; set; }

	public ulong? BaseUcsHandle { get; set; }

	public CadVPortTemplate()
		: base(new VPort())
	{
	}

	public CadVPortTemplate(VPort cadObject)
		: base(cadObject)
	{
	}

	protected override void build(CadDocumentBuilder builder)
	{
		base.build(builder);
		if (builder.TryGetCadObject<UCS>(BaseUcsHandle, out var value))
		{
			base.CadObject.BaseUcs = value;
		}
		else if (BaseUcsHandle.HasValue && BaseUcsHandle > 0)
		{
			builder.Notify($"Boundary {BaseUcsHandle} not found for viewport {base.CadObject.Handle}", NotificationType.Warning);
		}
		if (builder.TryGetCadObject<UCS>(NamedUcsHandle, out var value2))
		{
			base.CadObject.BaseUcs = value2;
		}
		else if (NamedUcsHandle.HasValue && NamedUcsHandle > 0)
		{
			builder.Notify($"Boundary {BaseUcsHandle} not found for viewport {base.CadObject.Handle}", NotificationType.Warning);
		}
		builder.TryGetCadObject<CadObject>(StyleHandle, out var _);
	}
}
