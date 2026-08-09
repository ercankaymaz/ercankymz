using System;
using System.Globalization;
using MS.Internal;
using MS.Internal.Properties;

namespace Microsoft.Windows.Design.Features;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public sealed class FeatureConnectorAttribute : Attribute
{
	private Type _featureConnectorType;

	private EqualityArray _typeId;

	public Type FeatureConnectorType => _featureConnectorType;

	public override object TypeId
	{
		get
		{
			if (_typeId == null)
			{
				_typeId = new EqualityArray(typeof(FeatureConnectorAttribute), _featureConnectorType);
			}
			return _typeId;
		}
	}

	public FeatureConnectorAttribute(Type featureConnectorType)
	{
		if ((object)featureConnectorType == null)
		{
			throw new ArgumentNullException("featureConnectorType");
		}
		if (!typeof(IFeatureConnectorMarker).IsAssignableFrom(featureConnectorType))
		{
			throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.Error_ArgIncorrectType, new object[2]
			{
				"featureConnectorType",
				typeof(FeatureConnector<FeatureProvider>).GetGenericTypeDefinition().Name
			}));
		}
		_featureConnectorType = featureConnectorType;
	}

	public override bool Equals(object obj)
	{
		if (obj == this)
		{
			return true;
		}
		if (obj is FeatureConnectorAttribute featureConnectorAttribute)
		{
			return (object)featureConnectorAttribute._featureConnectorType == _featureConnectorType;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return _featureConnectorType.GetHashCode();
	}
}
