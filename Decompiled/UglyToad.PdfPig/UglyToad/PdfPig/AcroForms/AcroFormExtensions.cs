using System.Collections.Generic;
using System.Linq;
using UglyToad.PdfPig.AcroForms.Fields;

namespace UglyToad.PdfPig.AcroForms;

public static class AcroFormExtensions
{
	public static IEnumerable<AcroFieldBase> GetFields(this AcroForm form)
	{
		return form.Fields.SelectMany((AcroFieldBase f) => f.GetFields());
	}

	public static IEnumerable<AcroFieldBase> GetFields(this AcroFieldBase fieldBase)
	{
		if (fieldBase.FieldType != AcroFieldType.Unknown)
		{
			yield return fieldBase;
		}
		if (!(fieldBase is AcroNonTerminalField acroNonTerminalField))
		{
			yield break;
		}
		foreach (AcroFieldBase child in acroNonTerminalField.Children)
		{
			foreach (AcroFieldBase field in child.GetFields())
			{
				yield return field;
			}
		}
	}

	public static KeyValuePair<string?, string?> GetFieldValue(this AcroFieldBase fieldBase)
	{
		if (!(fieldBase is AcroTextField acroTextField))
		{
			if (fieldBase is AcroCheckboxField acroCheckboxField)
			{
				return new KeyValuePair<string, string>(acroCheckboxField.Information.PartialName, acroCheckboxField.IsChecked.ToString());
			}
			return new KeyValuePair<string, string>(fieldBase.Information.PartialName, "");
		}
		return new KeyValuePair<string, string>(acroTextField.Information.PartialName, acroTextField.Value);
	}
}
