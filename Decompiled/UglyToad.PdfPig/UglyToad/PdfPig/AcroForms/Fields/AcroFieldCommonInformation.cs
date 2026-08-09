using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.AcroForms.Fields;

public class AcroFieldCommonInformation
{
	public IndirectReference? Parent { get; set; }

	public string? PartialName { get; }

	public string? AlternateName { get; }

	public string? MappingName { get; }

	public AcroFieldCommonInformation(IndirectReference? parent, string? partialName, string? alternateName, string? mappingName)
	{
		Parent = parent;
		PartialName = partialName;
		AlternateName = alternateName;
		MappingName = mappingName;
	}

	public override string ToString()
	{
		string text = string.Empty;
		if (Parent.HasValue)
		{
			text += $"Parent: {Parent}.";
		}
		text = AppendIfNotNull(PartialName, "Partial Name", text);
		text = AppendIfNotNull(AlternateName, "Alternate Name", text);
		return AppendIfNotNull(MappingName, "Mapping Name", text);
		static string AppendIfNotNull(string? val, string label, string result)
		{
			if (val == null)
			{
				return result;
			}
			if (result.Length > 0)
			{
				result += " ";
			}
			result = result + label + ": " + val + ".";
			return result;
		}
	}
}
