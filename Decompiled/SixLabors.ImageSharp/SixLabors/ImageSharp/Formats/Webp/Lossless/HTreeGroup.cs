using System.Collections.Generic;

namespace SixLabors.ImageSharp.Formats.Webp.Lossless;

internal struct HTreeGroup(uint packedTableSize)
{
	public List<HuffmanCode[]> HTrees { get; } = new List<HuffmanCode[]>(5);

	public bool IsTrivialLiteral { get; set; } = false;

	public uint LiteralArb { get; set; } = 0u;

	public bool IsTrivialCode { get; set; } = false;

	public bool UsePackedTable { get; set; } = false;

	public HuffmanCode[] PackedTable { get; set; } = new HuffmanCode[packedTableSize];
}
