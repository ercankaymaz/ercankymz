using System.Collections.Generic;
using ACadSharp.Entities;
using ACadSharp.Objects;
using ACadSharp.Tables;

namespace ACadSharp.IO.Templates;

internal class CadLayoutTemplate : CadTemplate<Layout>
{
	public ulong? PaperSpaceBlockHandle { get; set; }

	public ulong? ActiveViewportHandle { get; set; }

	public ulong? BaseUcsHandle { get; set; }

	public ulong? NamesUcsHandle { get; set; }

	public ulong? LasActiveViewportHandle { get; set; }

	public HashSet<ulong> ViewportHandles { get; set; } = new HashSet<ulong>();

	public CadLayoutTemplate()
		: base(new Layout())
	{
	}

	public CadLayoutTemplate(Layout layout)
		: base(layout)
	{
	}

	protected override void build(CadDocumentBuilder builder)
	{
		base.build(builder);
		if (builder.TryGetCadObject<BlockRecord>(PaperSpaceBlockHandle, out var value))
		{
			base.CadObject.AssociatedBlock = value;
		}
		if (builder.TryGetCadObject<Viewport>(ActiveViewportHandle, out var value2))
		{
			base.CadObject.Viewport = value2;
		}
		if (builder.TryGetCadObject<UCS>(BaseUcsHandle, out var value3))
		{
			base.CadObject.BaseUCS = value3;
		}
		if (builder.TryGetCadObject<UCS>(NamesUcsHandle, out var value4))
		{
			base.CadObject.UCS = value4;
		}
		foreach (ulong viewportHandle in ViewportHandles)
		{
			builder.TryGetCadObject<Viewport>(viewportHandle, out var _);
		}
	}
}
