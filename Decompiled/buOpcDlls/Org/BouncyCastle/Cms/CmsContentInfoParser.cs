using System;
using System.IO;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cms;

namespace Org.BouncyCastle.Cms;

public class CmsContentInfoParser : IDisposable
{
	protected ContentInfoParser contentInfo;

	protected Stream data;

	protected CmsContentInfoParser(Stream data)
	{
		if (data == null)
		{
			throw new ArgumentNullException("data");
		}
		this.data = data;
		try
		{
			Asn1StreamParser asn1StreamParser = new Asn1StreamParser(data);
			contentInfo = new ContentInfoParser((Asn1SequenceParser)asn1StreamParser.ReadObject());
		}
		catch (IOException innerException)
		{
			throw new CmsException("IOException reading content.", innerException);
		}
		catch (InvalidCastException innerException2)
		{
			throw new CmsException("Unexpected object reading content.", innerException2);
		}
	}

	[Obsolete("Dispose instead")]
	public void Close()
	{
		Dispose();
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing)
		{
			data.Dispose();
		}
	}
}
