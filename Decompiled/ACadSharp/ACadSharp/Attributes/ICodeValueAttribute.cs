namespace ACadSharp.Attributes;

public interface ICodeValueAttribute
{
	DxfCode[] ValueCodes { get; }

	DxfReferenceType ReferenceType { get; }
}
