using System.Collections.Generic;
using ACadSharp.Entities;
using ACadSharp.Tables;

namespace ACadSharp.IO.Templates;

internal class CadViewportTemplate : CadEntityTemplate<Viewport>
{
	public ulong? ViewportHeaderHandle { get; set; }

	public ulong? BoundaryHandle { get; set; }

	public ulong? NamedUcsHandle { get; set; }

	public ulong? BaseUcsHandle { get; set; }

	public ulong? VisualStyleHandle { get; set; }

	public short? ViewportId { get; set; }

	public ulong? BlockHandle { get; set; }

	public HashSet<ulong> FrozenLayerHandles { get; set; } = new HashSet<ulong>();

	public CadViewportTemplate()
		: base(new Viewport())
	{
	}

	public CadViewportTemplate(Viewport entity)
		: base(entity)
	{
	}

	protected override void build(CadDocumentBuilder builder)
	{
		base.build(builder);
		if (builder.TryGetCadObject<Entity>(BoundaryHandle, out var value))
		{
			base.CadObject.Boundary = value;
		}
		else if (BoundaryHandle.HasValue && BoundaryHandle > 0)
		{
			builder.Notify($"Boundary {BoundaryHandle} not found for viewport {base.CadObject.Handle}", NotificationType.Warning);
		}
		if (NamedUcsHandle.HasValue && NamedUcsHandle > 0)
		{
			builder.Notify($"Named ucs not implemented for Viewport, handle {NamedUcsHandle}");
		}
		if (BaseUcsHandle.HasValue && BaseUcsHandle > 0)
		{
			builder.Notify($"Base ucs not implemented for Viewport, handle {BaseUcsHandle}");
		}
		foreach (ulong frozenLayerHandle in FrozenLayerHandles)
		{
			if (builder.TryGetCadObject<Layer>(frozenLayerHandle, out var value2))
			{
				base.CadObject.FrozenLayers.Add(value2);
			}
			else
			{
				builder.Notify($"Frozen layer {frozenLayerHandle} not found for viewport {base.CadObject.Handle}", NotificationType.Warning);
			}
		}
	}
}
