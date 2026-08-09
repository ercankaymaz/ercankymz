using System;

namespace MS.Internal.Metadata;

internal class AttributeData
{
	private Type _attributeType;

	private bool? _isInheritable;

	private bool? _allowsMultiple;

	internal Type AttributeType => _attributeType;

	internal bool AllowsMultiple
	{
		get
		{
			if (!_allowsMultiple.HasValue)
			{
				ParseUsageAttributes();
			}
			return _allowsMultiple.Value;
		}
	}

	internal bool IsInheritable
	{
		get
		{
			if (!_isInheritable.HasValue)
			{
				ParseUsageAttributes();
			}
			return _isInheritable.Value;
		}
	}

	internal AttributeData(Type attributeType)
	{
		_attributeType = attributeType;
	}

	private void ParseUsageAttributes()
	{
		_isInheritable = false;
		_allowsMultiple = false;
		object[] customAttributes = _attributeType.GetCustomAttributes(typeof(AttributeUsageAttribute), inherit: true);
		if (customAttributes != null && customAttributes.Length > 0)
		{
			for (int i = 0; i < customAttributes.Length; i++)
			{
				AttributeUsageAttribute attributeUsageAttribute = (AttributeUsageAttribute)customAttributes[i];
				_isInheritable = attributeUsageAttribute.Inherited;
				_allowsMultiple = attributeUsageAttribute.AllowMultiple;
			}
		}
	}
}
