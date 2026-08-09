using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ACadSharp.Attributes;
using ACadSharp.XData;

namespace ACadSharp;

public class DxfProperty : DxfPropertyBase<DxfCodeValueAttribute>
{
	public DxfProperty(PropertyInfo property)
		: base(property)
	{
	}

	public DxfProperty(int code, PropertyInfo property)
		: this(property)
	{
		if (!_attributeData.ValueCodes.Contains((DxfCode)code))
		{
			throw new ArgumentException(string.Format("The {0} does not have match with the code {1}", "DxfCodeValueAttribute", code), "property");
		}
		_assignedCode = code;
	}

	public DxfCode[] GetCollectionCodes()
	{
		return _property.GetCustomAttribute<DxfCollectionCodeValueAttribute>()?.ValueCodes;
	}

	public object GetValue<TCadObject>(TCadObject obj) where TCadObject : CadObject
	{
		return _property.GetValue(obj);
	}

	public IEnumerable<ExtendedDataRecord> ToXDataRecords()
	{
		List<ExtendedDataRecord> list = new List<ExtendedDataRecord>();
		if (base.StoredValue == null)
		{
			return list;
		}
		list.Add(new ExtendedDataInteger16((short)base.AssignedCode));
		list.Add(ExtendedDataRecord.Create(base.GroupCode, base.StoredValue));
		return list;
	}

	public override string ToString()
	{
		string text = string.Empty;
		int[] dxfCodes = base.DxfCodes;
		foreach (int num in dxfCodes)
		{
			text += $"{num}:";
		}
		return text + _property.Name;
	}
}
