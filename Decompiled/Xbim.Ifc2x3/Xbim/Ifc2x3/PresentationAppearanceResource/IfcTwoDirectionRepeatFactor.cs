using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.GeometryResource;

namespace Xbim.Ifc2x3.PresentationAppearanceResource;

[ExpressType("IfcTwoDirectionRepeatFactor", 315)]
public class IfcTwoDirectionRepeatFactor : IfcOneDirectionRepeatFactor, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcTwoDirectionRepeatFactor>
{
	private IfcVector _secondRepeatFactor;

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcVector SecondRepeatFactor
	{
		get
		{
			if (_activated)
			{
				return _secondRepeatFactor;
			}
			Activate();
			return _secondRepeatFactor;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcVector v)
			{
				_secondRepeatFactor = v;
			}, _secondRepeatFactor, value, "SecondRepeatFactor", 2);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.RepeatFactor != null)
			{
				yield return base.RepeatFactor;
			}
			if (SecondRepeatFactor != null)
			{
				yield return SecondRepeatFactor;
			}
		}
	}

	internal IfcTwoDirectionRepeatFactor(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 1:
			_secondRepeatFactor = (IfcVector)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTwoDirectionRepeatFactor other)
	{
		return this == other;
	}
}
