namespace ACadSharp.XData;

public abstract class ExtendedDataReference<T> : ExtendedDataRecord<ulong>, IExtendedDataHandleReference where T : CadObject
{
	protected ExtendedDataReference(DxfCode code, ulong handle)
		: base(code, handle)
	{
	}

	public T ResolveReference(CadDocument document)
	{
		return document.GetCadObject<T>(base.Value);
	}

	CadObject IExtendedDataHandleReference.ResolveReference(CadDocument document)
	{
		return ResolveReference(document);
	}
}
