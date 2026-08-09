using System.Collections.Generic;

namespace ACadSharp.IO.Templates;

internal class CadViewportEntityControlTemplate : CadTemplate
{
	public class VPEntityPlaceholder : CadObject
	{
		public override ObjectType ObjectType { get; }

		public override string SubclassMarker { get; }
	}

	public HashSet<ulong> EntryHandles { get; } = new HashSet<ulong>();

	public CadViewportEntityControlTemplate()
		: base(new VPEntityPlaceholder())
	{
	}

	protected override void build(CadDocumentBuilder builder)
	{
		base.build(builder);
	}
}
