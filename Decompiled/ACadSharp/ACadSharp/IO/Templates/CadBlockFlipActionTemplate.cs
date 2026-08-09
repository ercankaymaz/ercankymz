using ACadSharp.Objects.Evaluations;

namespace ACadSharp.IO.Templates;

internal class CadBlockFlipActionTemplate : CadBlockActionTemplate
{
	public BlockFlipAction BlockFlipAction => base.CadObject as BlockFlipAction;

	public CadBlockFlipActionTemplate(BlockFlipAction cadObject)
		: base(cadObject)
	{
	}
}
