using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.GeometryResource;

namespace Xbim.Ifc2x3.PresentationAppearanceResource;

[ExpressType("IfcOneDirectionRepeatFactor", 32)]
public class IfcOneDirectionRepeatFactor : IfcGeometricRepresentationItem, IInstantiableEntity, IPersistEntity, IPersist, IfcHatchLineDistanceSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcOneDirectionRepeatFactor>
{
	private IfcVector _repeatFactor;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcVector RepeatFactor
	{
		get
		{
			if (_activated)
			{
				return _repeatFactor;
			}
			Activate();
			return _repeatFactor;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcVector v)
			{
				_repeatFactor = v;
			}, _repeatFactor, value, "RepeatFactor", 1);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (RepeatFactor != null)
			{
				yield return RepeatFactor;
			}
		}
	}

	internal IfcOneDirectionRepeatFactor(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			_repeatFactor = (IfcVector)value.EntityVal;
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcOneDirectionRepeatFactor other)
	{
		return this == other;
	}
}
