using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.ProductExtension;

namespace Xbim.Ifc2x3.SharedComponentElements;

[ExpressType("IfcEdgeFeature", 764)]
public abstract class IfcEdgeFeature : IfcFeatureElementSubtraction, IEquatable<IfcEdgeFeature>
{
	private IfcPositiveLengthMeasure? _featureLength;

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 28)]
	public IfcPositiveLengthMeasure? FeatureLength
	{
		get
		{
			if (_activated)
			{
				return _featureLength;
			}
			Activate();
			return _featureLength;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure? v)
			{
				_featureLength = v;
			}, _featureLength, value, "FeatureLength", 9);
		}
	}

	internal IfcEdgeFeature(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
		case 2:
		case 3:
		case 4:
		case 5:
		case 6:
		case 7:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 8:
			_featureLength = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcEdgeFeature other)
	{
		return this == other;
	}
}
