using System;

namespace PdfSharp.Pdf.Content.Objects;

public abstract class CObject : ICloneable
{
	object ICloneable.Clone()
	{
		return Copy();
	}

	public CObject Clone()
	{
		return Copy();
	}

	protected virtual CObject Copy()
	{
		return (CObject)MemberwiseClone();
	}

	internal abstract void WriteObject(ContentWriter writer);
}
