namespace PdfSharp.Pdf.Content.Objects;

public sealed class OpCode
{
	public readonly string Name;

	public readonly OpCodeName OpCodeName;

	public readonly int Operands;

	public readonly OpCodeFlags Flags;

	public readonly string Postscript;

	public readonly string Description;

	internal OpCode(string name, OpCodeName opcodeName, int operands, string postscript, OpCodeFlags flags, string description)
	{
		Name = name;
		OpCodeName = opcodeName;
		Operands = operands;
		Postscript = postscript;
		Flags = flags;
		Description = description;
	}
}
