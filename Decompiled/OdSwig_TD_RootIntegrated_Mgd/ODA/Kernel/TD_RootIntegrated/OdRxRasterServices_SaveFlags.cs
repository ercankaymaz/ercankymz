using System;

namespace ODA.Kernel.TD_RootIntegrated;

[Flags]
public enum OdRxRasterServices_SaveFlags
{
	kTransparentColor = 0x524C4354,
	kJpegQuality = 0x5954514A,
	kTiffCompression = 0x504D4354,
	kTiffCompressionDeflate = 0x2050495A,
	kTiffCompressionLzw = 0x20575A4C,
	kTiffCompressionJpeg = 0x4745504A,
	kTiffCompressionCCITTFax3 = 0x33584146,
	kTiffCompressionCCITTFax4 = 0x34584146,
	kTiffCompressionEmbedded = 0x44424D45,
	kDithering = 0x48544944,
	kDitheringFS = 0x53465444,
	kDitheringBayer4x4 = 0x34525942,
	kDitheringBayer8x8 = 0x38525942,
	kDitheringBayer16x16 = 0x36315242,
	kDitheringCluster6x6 = 0x36524C43,
	kDitheringCluster8x8 = 0x38524C43,
	kDitheringCluster16x16 = 0x36314C43,
	kRescale = 0x4C435352,
	kRescaleBox = 0x20584F42,
	kRescaleBicubic = 0x43424342,
	kRescaleBilinear = 0x524E4C42,
	kRescaleBspline = 0x4C505342,
	kRescaleCatmullrom = 0x4C4D5443,
	kRescaleLanczos3 = 0x5A434E4C,
	kRescaleWidth = 0x48544457,
	kRescaleHeight = 0x54484748,
	kQuantizeNone = 0x384F5443,
	kQuantizeWU = 0x51435557,
	kQuantizeNN = 0x20514E4E,
	kQuantizeLFP = 0x5150464C
}
