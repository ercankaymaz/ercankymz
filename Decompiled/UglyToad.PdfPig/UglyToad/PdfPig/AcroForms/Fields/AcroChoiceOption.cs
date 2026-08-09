namespace UglyToad.PdfPig.AcroForms.Fields;

public class AcroChoiceOption
{
	public int Index { get; }

	public bool IsSelected { get; }

	public string Name { get; }

	public string? ExportValue { get; }

	public bool HasExportValue { get; }

	public AcroChoiceOption(int index, bool isSelected, string name, string? exportValue = null)
	{
		Index = index;
		IsSelected = isSelected;
		Name = name;
		ExportValue = exportValue;
		HasExportValue = exportValue != null;
	}

	public override string ToString()
	{
		return $"{Index}: {Name} ({IsSelected}).";
	}
}
