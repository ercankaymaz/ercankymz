namespace UglyToad.PdfPig.Parser.FileStructure;

internal readonly record struct FileHeaderOffset(int Value)
{
	public override string ToString()
	{
		return Value.ToString();
	}

	public bool Equals(FileHeaderOffset other)
	{
		return Value == other.Value;
	}

	public override int GetHashCode()
	{
		return Value.GetHashCode();
	}
}
