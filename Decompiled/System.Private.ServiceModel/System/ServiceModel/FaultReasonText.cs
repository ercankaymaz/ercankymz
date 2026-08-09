using System.Globalization;

namespace System.ServiceModel;

public class FaultReasonText
{
	private string _text;

	public string XmlLang { get; }

	public string Text => _text;

	public FaultReasonText(string text)
	{
		_text = text ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("text"));
		XmlLang = CultureInfo.CurrentCulture.Name;
	}

	public FaultReasonText(string text, string xmlLang)
	{
		_text = text ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("text"));
		XmlLang = xmlLang ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("xmlLang"));
	}

	public FaultReasonText(string text, CultureInfo cultureInfo)
	{
		if (cultureInfo == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("cultureInfo"));
		}
		_text = text ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("text"));
		XmlLang = cultureInfo.Name;
	}

	public bool Matches(CultureInfo cultureInfo)
	{
		if (cultureInfo == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("cultureInfo"));
		}
		return XmlLang == cultureInfo.Name;
	}
}
