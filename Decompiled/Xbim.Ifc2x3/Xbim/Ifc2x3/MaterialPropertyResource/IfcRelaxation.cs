using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;

namespace Xbim.Ifc2x3.MaterialPropertyResource;

[ExpressType("IfcRelaxation", 364)]
public class IfcRelaxation : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IEquatable<IfcRelaxation>
{
	private IfcNormalisedRatioMeasure _relaxationValue;

	private IfcNormalisedRatioMeasure _initialStress;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public IfcNormalisedRatioMeasure RelaxationValue
	{
		get
		{
			if (_activated)
			{
				return _relaxationValue;
			}
			Activate();
			return _relaxationValue;
		}
		set
		{
			SetValue(delegate(IfcNormalisedRatioMeasure v)
			{
				_relaxationValue = v;
			}, _relaxationValue, value, "RelaxationValue", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public IfcNormalisedRatioMeasure InitialStress
	{
		get
		{
			if (_activated)
			{
				return _initialStress;
			}
			Activate();
			return _initialStress;
		}
		set
		{
			SetValue(delegate(IfcNormalisedRatioMeasure v)
			{
				_initialStress = v;
			}, _initialStress, value, "InitialStress", 2);
		}
	}

	internal IfcRelaxation(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_relaxationValue = value.RealVal;
			break;
		case 1:
			_initialStress = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelaxation other)
	{
		return this == other;
	}
}
