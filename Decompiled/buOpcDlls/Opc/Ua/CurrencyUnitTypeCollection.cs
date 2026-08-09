using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfCurrencyUnitType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "CurrencyUnitType")]
[ComVisible(true)]
public class CurrencyUnitTypeCollection : List<CurrencyUnitType>, ICloneable
{
	public CurrencyUnitTypeCollection()
	{
	}

	public CurrencyUnitTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public CurrencyUnitTypeCollection(IEnumerable<CurrencyUnitType> collection)
		: base(collection)
	{
	}

	public static implicit operator CurrencyUnitTypeCollection(CurrencyUnitType[] values)
	{
		if (values != null)
		{
			return new CurrencyUnitTypeCollection(values);
		}
		return new CurrencyUnitTypeCollection();
	}

	public static explicit operator CurrencyUnitType[](CurrencyUnitTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (CurrencyUnitTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		CurrencyUnitTypeCollection currencyUnitTypeCollection = new CurrencyUnitTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			currencyUnitTypeCollection.Add((CurrencyUnitType)Utils.Clone(base[i]));
		}
		return currencyUnitTypeCollection;
	}
}
