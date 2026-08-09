using System;
using System.Linq;

namespace ACadSharp.Attributes;

[AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
public sealed class DxfCollectionCodeValueAttribute : Attribute, ICodeValueAttribute
{
	public DxfCode[] ValueCodes { get; }

	public DxfReferenceType ReferenceType { get; }

	public DxfCollectionCodeValueAttribute(params int[] codes)
	{
		ValueCodes = codes.Select((int c) => (DxfCode)c).ToArray();
	}

	public DxfCollectionCodeValueAttribute(DxfReferenceType referenceType, params int[] codes)
		: this(codes)
	{
		ReferenceType = referenceType;
	}
}
