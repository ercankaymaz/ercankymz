using System;

namespace ODA.Publish.PdfPublish;

[Flags]
public enum OdPdfPublish_Text_Language
{
	kASCII = 0,
	kEastEuropeanRoman = 1,
	kCyrillic = 2,
	kGreek = 3,
	kTurkish = 4,
	kHebrew = 5,
	kArabic = 6,
	kBaltic = 7,
	kChineseTraditional = 8,
	kChineseSimplified = 9,
	kJapanese = 0xA,
	kKorean = 0xB,
	kDefault = 0xC
}
