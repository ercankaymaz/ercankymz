using ACadSharp.Objects;
using ACadSharp.Tables;

namespace ACadSharp.IO.Templates;

internal class CadLayerTemplate : CadTableEntryTemplate<Layer>
{
	public ulong LayerControlHandle { get; set; }

	public ulong PlotStyleHandle { get; set; }

	public ulong MaterialHandle { get; set; }

	public ulong? LineTypeHandle { get; set; }

	public string LineTypeName { get; set; }

	public string TrueColorName { get; set; }

	public CadLayerTemplate()
		: base(new Layer())
	{
	}

	public CadLayerTemplate(Layer entry)
		: base(entry)
	{
	}

	protected override void build(CadDocumentBuilder builder)
	{
		base.build(builder);
		builder.TryGetCadObject<Material>(MaterialHandle, out var _);
		if (getTableReference<LineType>(builder, LineTypeHandle, LineTypeName, out var reference))
		{
			base.CadObject.LineType = reference;
		}
		else
		{
			builder.Notify($"Linetype with handle {LineTypeHandle} could not be found for layer {base.CadObject.Name}", NotificationType.Warning);
		}
	}
}
