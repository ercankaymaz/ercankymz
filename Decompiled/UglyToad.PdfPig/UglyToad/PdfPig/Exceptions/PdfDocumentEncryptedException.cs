using System;
using System.Runtime.Serialization;
using UglyToad.PdfPig.Encryption;

namespace UglyToad.PdfPig.Exceptions;

[Serializable]
public class PdfDocumentEncryptedException : Exception
{
	internal EncryptionDictionary? Dictionary { get; }

	public PdfDocumentEncryptedException()
	{
	}

	public PdfDocumentEncryptedException(string message)
		: base(message)
	{
	}

	public PdfDocumentEncryptedException(string message, Exception inner)
		: base(message, inner)
	{
	}

	internal PdfDocumentEncryptedException(string message, EncryptionDictionary dictionary)
		: base(message)
	{
		Dictionary = dictionary;
	}

	internal PdfDocumentEncryptedException(string message, EncryptionDictionary dictionary, Exception inner)
		: base(message, inner)
	{
		Dictionary = dictionary;
	}

	protected PdfDocumentEncryptedException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
