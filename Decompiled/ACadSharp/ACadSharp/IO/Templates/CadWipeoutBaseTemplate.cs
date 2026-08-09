using ACadSharp.Entities;
using ACadSharp.Objects;

namespace ACadSharp.IO.Templates;

internal class CadWipeoutBaseTemplate : CadEntityTemplate
{
	public ulong? ImgDefHandle { get; set; }

	public ulong? ImgReactorHandle { get; set; }

	public CadWipeoutBaseTemplate(CadWipeoutBase image)
		: base(image)
	{
	}

	protected override void build(CadDocumentBuilder builder)
	{
		base.build(builder);
		CadWipeoutBase cadWipeoutBase = base.CadObject as CadWipeoutBase;
		if (builder.TryGetCadObject<ImageDefinition>(ImgDefHandle, out var value))
		{
			cadWipeoutBase.Definition = value;
		}
		if (builder.TryGetCadObject<ImageDefinitionReactor>(ImgReactorHandle, out var value2))
		{
			cadWipeoutBase.DefinitionReactor = value2;
		}
	}
}
