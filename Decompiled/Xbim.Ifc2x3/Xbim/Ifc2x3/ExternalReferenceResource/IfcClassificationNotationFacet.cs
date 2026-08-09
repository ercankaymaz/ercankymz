using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;

namespace Xbim.Ifc2x3.ExternalReferenceResource;

[ExpressType("IfcClassificationNotationFacet", 251)]
public class IfcClassificationNotationFacet : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IEquatable<IfcClassificationNotationFacet>
{
	private IfcLabel _notationValue;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public IfcLabel NotationValue
	{
		get
		{
			if (_activated)
			{
				return _notationValue;
			}
			Activate();
			return _notationValue;
		}
		set
		{
			SetValue(delegate(IfcLabel v)
			{
				_notationValue = v;
			}, _notationValue, value, "NotationValue", 1);
		}
	}

	internal IfcClassificationNotationFacet(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			_notationValue = value.StringVal;
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcClassificationNotationFacet other)
	{
		return this == other;
	}
}
