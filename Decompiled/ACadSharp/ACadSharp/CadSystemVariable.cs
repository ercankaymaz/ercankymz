using System.Reflection;
using ACadSharp.Attributes;
using ACadSharp.Header;

namespace ACadSharp;

public class CadSystemVariable : DxfPropertyBase<CadSystemVariableAttribute>
{
	public string Name => _attributeData.Name;

	public CadSystemVariable(PropertyInfo property)
		: base(property)
	{
	}

	public object GetSystemValue(int code, CadHeader header)
	{
		return _attributeData.ReferenceType switch
		{
			DxfReferenceType.Unprocess => _property.GetValue(header), 
			DxfReferenceType.Handle => getHandledValue(header), 
			DxfReferenceType.Name => getNamedValue(header), 
			DxfReferenceType.Count => getCounterValue(header), 
			_ => getRawValue(code, header), 
		};
	}

	public object GetValue(CadHeader header)
	{
		return _property.GetValue(header);
	}
}
