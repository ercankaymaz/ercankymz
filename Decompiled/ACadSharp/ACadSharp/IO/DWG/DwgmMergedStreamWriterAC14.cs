using System.IO;

namespace ACadSharp.IO.DWG;

internal class DwgmMergedStreamWriterAC14 : DwgMergedStreamWriter, IDwgStreamWriter
{
	public DwgmMergedStreamWriterAC14(Stream stream, IDwgStreamWriter main, IDwgStreamWriter handle)
		: base(stream, main, main, handle)
	{
	}

	public override void WriteSpearShift()
	{
		int num = (int)base.Main.PositionInBits;
		if (_savedPosition)
		{
			base.Main.WriteSpearShift();
			base.Main.SetPositionInBits(base.PositionInBits);
			base.Main.WriteRawLong(num);
			base.Main.WriteShiftValue();
			base.Main.SetPositionInBits(num);
		}
		base.HandleWriter.WriteSpearShift();
		base.Main.WriteBytes(((MemoryStream)base.HandleWriter.Stream).GetBuffer(), 0, (int)base.HandleWriter.Stream.Length);
		base.Main.WriteSpearShift();
	}
}
