using System;
using System.Globalization;
using MS.Internal;
using MS.Internal.Properties;

namespace Microsoft.Windows.Design.Features;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true)]
public sealed class FeatureAttribute : Attribute
{
	private Type _featureProviderType;

	private EqualityArray _typeId;

	public Type FeatureProviderType => _featureProviderType;

	public override object TypeId
	{
		get
		{
			if (_typeId == null)
			{
				_typeId = new EqualityArray(typeof(FeatureProvider), _featureProviderType);
			}
			return _typeId;
		}
	}

	public FeatureAttribute(Type featureProviderType)
	{
		if ((object)featureProviderType == null)
		{
			throw new ArgumentNullException("featureProviderType");
		}
		if (!typeof(FeatureProvider).IsAssignableFrom(featureProviderType))
		{
			throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.Error_ArgIncorrectType, new object[2]
			{
				"featureProviderType",
				typeof(FeatureProvider).Name
			}));
		}
		_featureProviderType = featureProviderType;
	}

	public override bool Equals(object obj)
	{
		if (obj == this)
		{
			return true;
		}
		if (obj is FeatureAttribute featureAttribute)
		{
			return (object)featureAttribute._featureProviderType == _featureProviderType;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return _featureProviderType.GetHashCode();
	}
}
