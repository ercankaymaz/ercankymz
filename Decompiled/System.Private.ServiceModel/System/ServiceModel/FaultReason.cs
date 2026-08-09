using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;

namespace System.ServiceModel;

public class FaultReason
{
	public SynchronizedReadOnlyCollection<FaultReasonText> Translations { get; private set; }

	public FaultReason(FaultReasonText translation)
	{
		if (translation == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("translation");
		}
		Init(translation);
	}

	public FaultReason(string text)
	{
		Init(new FaultReasonText(text));
	}

	internal FaultReason(string text, string xmlLang)
	{
		Init(new FaultReasonText(text, xmlLang));
	}

	internal FaultReason(string text, CultureInfo cultureInfo)
	{
		Init(new FaultReasonText(text, cultureInfo));
	}

	public FaultReason(IEnumerable<FaultReasonText> translations)
	{
		if (translations == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("translations"));
		}
		int num = 0;
		foreach (FaultReasonText translation in translations)
		{
			num++;
		}
		if (num == 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.AtLeastOneFaultReasonMustBeSpecified, "translations"));
		}
		FaultReasonText[] array = new FaultReasonText[num];
		int num2 = 0;
		foreach (FaultReasonText translation2 in translations)
		{
			array[num2++] = translation2 ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("translations", System.SR.NoNullTranslations);
		}
		Init(array);
	}

	private void Init(FaultReasonText translation)
	{
		Init(new FaultReasonText[1] { translation });
	}

	private void Init(FaultReasonText[] translations)
	{
		Translations = new SynchronizedReadOnlyCollection<FaultReasonText>(new object(), new ReadOnlyCollection<FaultReasonText>(translations));
	}

	public FaultReasonText GetMatchingTranslation()
	{
		return GetMatchingTranslation(CultureInfo.CurrentCulture);
	}

	public FaultReasonText GetMatchingTranslation(CultureInfo cultureInfo)
	{
		if (cultureInfo == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("cultureInfo"));
		}
		if (Translations.Count == 1)
		{
			return Translations[0];
		}
		for (int i = 0; i < Translations.Count; i++)
		{
			if (Translations[i].Matches(cultureInfo))
			{
				return Translations[i];
			}
		}
		if (Translations.Count == 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.NoMatchingTranslationFoundForFaultText));
		}
		string text = cultureInfo.Name;
		while (true)
		{
			int num = text.LastIndexOf('-');
			if (num == -1)
			{
				break;
			}
			text = text.Substring(0, num);
			for (int j = 0; j < Translations.Count; j++)
			{
				if (Translations[j].XmlLang == text)
				{
					return Translations[j];
				}
			}
		}
		return Translations[0];
	}

	public override string ToString()
	{
		if (Translations.Count == 0)
		{
			return string.Empty;
		}
		return GetMatchingTranslation().Text;
	}
}
