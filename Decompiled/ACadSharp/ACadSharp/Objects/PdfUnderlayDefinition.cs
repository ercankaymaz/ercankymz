using ACadSharp.Attributes;

namespace ACadSharp.Objects;

[DxfName("PDFDEFINITION")]
[DxfSubClass("AcDbUnderlayDefinition")]
public class PdfUnderlayDefinition : UnderlayDefinition
{
	private string _page;

	public override string ObjectName => "PDFDEFINITION";

	[DxfCodeValue(new int[] { 2 })]
	public string Page
	{
		get
		{
			return _page;
		}
		set
		{
			_page = (string.IsNullOrEmpty(value) ? string.Empty : value);
		}
	}
}
