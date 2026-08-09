using System;
using System.Linq;

namespace ACadSharp.Attributes;

[AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
public sealed class CadSystemVariableAttribute : Attribute, ICodeValueAttribute
{
	public string Name { get; }

	public DxfCode[] ValueCodes { get; }

	public DxfReferenceType ReferenceType { get; }

	public bool IsName { get; }

	public CadSystemVariableAttribute(string variable, bool isName, params int[] codes)
	{
		Name = variable;
		IsName = isName;
		ValueCodes = codes.Select((int c) => (DxfCode)c).ToArray();
	}

	public CadSystemVariableAttribute(string variable, params int[] codes)
	{
		Name = variable;
		ValueCodes = codes.Select((int c) => (DxfCode)c).ToArray();
	}

	public CadSystemVariableAttribute(string variable, params DxfCode[] codes)
	{
		Name = variable;
		ValueCodes = codes;
	}

	public CadSystemVariableAttribute(DxfReferenceType referenceType, string variable, params int[] codes)
	{
		ReferenceType = referenceType;
		Name = variable;
		ValueCodes = codes.Select((int c) => (DxfCode)c).ToArray();
	}
}
