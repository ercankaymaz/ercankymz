using System;

namespace PdfSharp.SharpZipLib;

[Serializable]
internal class SharpZipBaseException : ApplicationException
{
	public SharpZipBaseException()
	{
	}

	public SharpZipBaseException(string message)
		: base(message)
	{
	}

	public SharpZipBaseException(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}
