namespace UglyToad.PdfPig.Encryption;

internal enum EncryptionAlgorithmCode
{
	Unrecognized,
	Rc4OrAes40BitKey,
	Rc4OrAesGreaterThan40BitKey,
	UnpublishedAlgorithm40To128BitKey,
	SecurityHandlerInDocument,
	SecurityHandlerInDocument256,
	UndocumentedDueToIso
}
