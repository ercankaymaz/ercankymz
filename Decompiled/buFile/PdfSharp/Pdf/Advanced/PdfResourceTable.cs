using System;

namespace PdfSharp.Pdf.Advanced;

public class PdfResourceTable
{
	private readonly PdfDocument _owner;

	protected PdfDocument Owner => _owner;

	public PdfResourceTable(PdfDocument owner)
	{
		if (owner == null)
		{
			throw new ArgumentNullException("owner");
		}
		_owner = owner;
	}
}
