using System.Collections.Generic;

namespace System.ComponentModel.Composition.Registration;

public sealed class ExportBuilder
{
	private bool _isInherited;

	private string _contractName;

	private Type _contractType;

	private List<Tuple<string, object>> _metadataItems;

	private List<Tuple<string, Func<Type, object>>> _metadataItemFuncs;

	public ExportBuilder AsContractType<T>()
	{
		return AsContractType(typeof(T));
	}

	public ExportBuilder AsContractType(Type type)
	{
		_contractType = type;
		return this;
	}

	public ExportBuilder AsContractName(string contractName)
	{
		_contractName = contractName;
		return this;
	}

	public ExportBuilder Inherited()
	{
		_isInherited = true;
		return this;
	}

	public ExportBuilder AddMetadata(string name, object value)
	{
		if (_metadataItems == null)
		{
			_metadataItems = new List<Tuple<string, object>>();
		}
		_metadataItems.Add(Tuple.Create(name, value));
		return this;
	}

	public ExportBuilder AddMetadata(string name, Func<Type, object> itemFunc)
	{
		if (_metadataItemFuncs == null)
		{
			_metadataItemFuncs = new List<Tuple<string, Func<Type, object>>>();
		}
		_metadataItemFuncs.Add(Tuple.Create(name, itemFunc));
		return this;
	}

	internal void BuildAttributes(Type type, ref List<Attribute> attributes)
	{
		if (attributes == null)
		{
			attributes = new List<Attribute>();
		}
		if (_isInherited)
		{
			attributes.Add(new InheritedExportAttribute(_contractName, _contractType));
		}
		else
		{
			attributes.Add(new ExportAttribute(_contractName, _contractType));
		}
		if (_metadataItems != null)
		{
			foreach (Tuple<string, object> metadataItem in _metadataItems)
			{
				attributes.Add(new ExportMetadataAttribute(metadataItem.Item1, metadataItem.Item2));
			}
		}
		if (_metadataItemFuncs == null)
		{
			return;
		}
		foreach (Tuple<string, Func<Type, object>> metadataItemFunc in _metadataItemFuncs)
		{
			string item = metadataItemFunc.Item1;
			object value = ((metadataItemFunc.Item2 != null) ? metadataItemFunc.Item2(type.UnderlyingSystemType) : null);
			attributes.Add(new ExportMetadataAttribute(item, value));
		}
	}
}
