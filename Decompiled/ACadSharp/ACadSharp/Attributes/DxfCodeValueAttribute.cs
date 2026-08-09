using System;
using System.Linq;

namespace ACadSharp.Attributes;

[AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
public sealed class DxfCodeValueAttribute : Attribute, ICodeValueAttribute
{
	public DxfCode[] ValueCodes { get; }

	public DxfReferenceType ReferenceType { get; }

	public DxfCodeValueAttribute(params int[] codes)
	{
		ValueCodes = codes.Select((int c) => (DxfCode)c).ToArray();
	}

	public DxfCodeValueAttribute(DxfReferenceType referenceType, params int[] codes)
		: this(codes)
	{
		ReferenceType = referenceType;
	}
}
