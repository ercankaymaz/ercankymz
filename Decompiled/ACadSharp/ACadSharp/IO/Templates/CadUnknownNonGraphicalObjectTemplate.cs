using ACadSharp.Objects;

namespace ACadSharp.IO.Templates;

internal class CadUnknownNonGraphicalObjectTemplate : CadNonGraphicalObjectTemplate
{
	public CadUnknownNonGraphicalObjectTemplate(UnknownNonGraphicalObject obj)
		: base(obj)
	{
	}
}
