using System.Collections;
using System.Collections.Generic;

namespace System.ComponentModel.Composition.Registration;

public sealed class ImportBuilder
{
	private static readonly Type s_stringType = typeof(string);

	private string _contractName;

	private Type _contractType;

	private bool _asMany;

	private bool _asManySpecified;

	private bool _allowDefault;

	private bool _allowRecomposition;

	private CreationPolicy _requiredCreationPolicy;

	private ImportSource _source;

	public ImportBuilder AsContractType<T>()
	{
		return AsContractType(typeof(T));
	}

	public ImportBuilder AsContractType(Type type)
	{
		_contractType = type;
		return this;
	}

	public ImportBuilder AsContractName(string contractName)
	{
		_contractName = contractName;
		return this;
	}

	public ImportBuilder AsMany(bool isMany = true)
	{
		_asMany = isMany;
		_asManySpecified = true;
		return this;
	}

	public ImportBuilder AllowDefault()
	{
		_allowDefault = true;
		return this;
	}

	public ImportBuilder AllowRecomposition()
	{
		_allowRecomposition = true;
		return this;
	}

	public ImportBuilder RequiredCreationPolicy(CreationPolicy requiredCreationPolicy)
	{
		_requiredCreationPolicy = requiredCreationPolicy;
		return this;
	}

	public ImportBuilder Source(ImportSource source)
	{
		_source = source;
		return this;
	}

	internal void BuildAttributes(Type type, ref List<Attribute> attributes)
	{
		bool num;
		if (_asManySpecified)
		{
			num = _asMany;
		}
		else
		{
			if (!(type != s_stringType))
			{
				goto IL_0034;
			}
			num = typeof(IEnumerable).IsAssignableFrom(type);
		}
		if (!num)
		{
			goto IL_0034;
		}
		Attribute item = new ImportManyAttribute(_contractName, _contractType)
		{
			AllowRecomposition = _allowRecomposition,
			RequiredCreationPolicy = _requiredCreationPolicy,
			Source = _source
		};
		goto IL_00ae;
		IL_00ae:
		if (attributes == null)
		{
			attributes = new List<Attribute>();
		}
		attributes.Add(item);
		return;
		IL_0034:
		item = new ImportAttribute(_contractName, _contractType)
		{
			AllowDefault = _allowDefault,
			AllowRecomposition = _allowRecomposition,
			RequiredCreationPolicy = _requiredCreationPolicy,
			Source = _source
		};
		goto IL_00ae;
	}
}
