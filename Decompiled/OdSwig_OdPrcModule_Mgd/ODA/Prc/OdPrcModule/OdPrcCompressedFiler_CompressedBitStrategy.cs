using System;

namespace ODA.Prc.OdPrcModule;

[Flags]
public enum OdPrcCompressedFiler_CompressedBitStrategy
{
	kFromStream = 0,
	kUseHuffman = 1,
	kNoCompression = 2
}
