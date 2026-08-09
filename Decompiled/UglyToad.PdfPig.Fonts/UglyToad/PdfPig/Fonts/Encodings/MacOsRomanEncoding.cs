using System;

namespace UglyToad.PdfPig.Fonts.Encodings;

public sealed class MacOsRomanEncoding : MacRomanEncoding
{
	private static readonly (int, string)[] EncodingTable = new(int, string)[16]
	{
		(255, "notequal"),
		(260, "infinity"),
		(262, "lessequal"),
		(263, "greaterequal"),
		(266, "partialdiff"),
		(267, "summation"),
		(270, "product"),
		(271, "pi"),
		(272, "integral"),
		(275, "Omega"),
		(303, "radical"),
		(305, "approxequal"),
		(306, "Delta"),
		(327, "lozenge"),
		(333, "Euro"),
		(360, "apple")
	};

	public new static MacOsRomanEncoding Instance { get; } = new MacOsRomanEncoding();

	private MacOsRomanEncoding()
	{
		(int, string)[] encodingTable = EncodingTable;
		for (int i = 0; i < encodingTable.Length; i++)
		{
			(int, string) tuple = encodingTable[i];
			int item = tuple.Item1;
			string item2 = tuple.Item2;
			int code = Convert.ToInt32($"{item}", 8);
			Add(code, item2);
		}
	}
}
