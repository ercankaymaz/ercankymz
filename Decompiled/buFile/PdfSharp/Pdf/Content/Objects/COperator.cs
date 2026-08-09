using System.Diagnostics;

namespace PdfSharp.Pdf.Content.Objects;

[DebuggerDisplay("({Name}, operands={Operands.Count})")]
public class COperator : CObject
{
	private CSequence _seqence;

	private readonly OpCode _opcode;

	public virtual string Name => _opcode.Name;

	public CSequence Operands => _seqence ?? (_seqence = new CSequence());

	public OpCode OpCode => _opcode;

	protected COperator()
	{
	}

	internal COperator(OpCode opcode)
	{
		_opcode = opcode;
	}

	public new COperator Clone()
	{
		return (COperator)Copy();
	}

	protected override CObject Copy()
	{
		return base.Copy();
	}

	public override string ToString()
	{
		if (_opcode.OpCodeName == OpCodeName.Dictionary)
		{
			return " ";
		}
		return Name;
	}

	internal override void WriteObject(ContentWriter writer)
	{
		int num = ((_seqence != null) ? _seqence.Count : 0);
		for (int i = 0; i < num; i++)
		{
			_seqence[i].WriteObject(writer);
		}
		writer.WriteLineRaw(ToString());
	}
}
