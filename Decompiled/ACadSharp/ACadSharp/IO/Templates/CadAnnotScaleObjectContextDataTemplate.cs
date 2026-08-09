using ACadSharp.Objects;

namespace ACadSharp.IO.Templates;

internal class CadAnnotScaleObjectContextDataTemplate : CadNonGraphicalObjectTemplate
{
	public ulong ScaleHandle { get; internal set; }

	public CadAnnotScaleObjectContextDataTemplate(AnnotScaleObjectContextData cadObject)
		: base(cadObject)
	{
	}

	protected override void build(CadDocumentBuilder builder)
	{
		base.build(builder);
		AnnotScaleObjectContextData annotScaleObjectContextData = (AnnotScaleObjectContextData)base.CadObject;
		if (builder.TryGetCadObject<Scale>(ScaleHandle, out var value))
		{
			annotScaleObjectContextData.Scale = value;
		}
	}
}
