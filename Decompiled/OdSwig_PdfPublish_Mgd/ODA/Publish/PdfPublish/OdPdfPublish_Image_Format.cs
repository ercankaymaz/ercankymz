using System;

namespace ODA.Publish.PdfPublish;

[Flags]
public enum OdPdfPublish_Image_Format
{
	kUnknown = -1,
	kBMP = 0,
	kICO = 1,
	kJPEG = 2,
	kJNG = 3,
	kKOALA = 4,
	kLBM = 5,
	kIFF = 6,
	kMNG = 7,
	kPBM = 8,
	kPBMRAW = 9,
	kPCD = 0xA,
	kPCX = 0xB,
	kPGM = 0xC,
	kPGMRAW = 0xD,
	kPNG = 0xE,
	kPPM = 0xF,
	kPPMRAW = 0x10,
	kRAS = 0x11,
	kTARGA = 0x12,
	kTIFF = 0x13,
	kWBMP = 0x14,
	kPSD = 0x15,
	kCUT = 0x16,
	kXBM = 0x17,
	kXPM = 0x18,
	kDDS = 0x19,
	kGIF = 0x1A,
	kHDR = 0x1B,
	kFAXG3 = 0x1C,
	kSGI = 0x1D,
	kEXR = 0x1E,
	kJ2K = 0x1F,
	kJP2 = 0x20,
	kPFM = 0x21,
	kPICT = 0x22,
	kRAW = 0x23
}
