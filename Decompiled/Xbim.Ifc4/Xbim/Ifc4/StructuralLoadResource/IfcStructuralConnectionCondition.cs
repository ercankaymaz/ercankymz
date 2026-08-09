using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.StructuralLoadResource;

[ExpressType("IfcStructuralConnectionCondition", 639)]
public abstract class IfcStructuralConnectionCondition : PersistEntity, IIfcStructuralConnectionCondition, IPersistEntity, IPersist, IEquatable<IfcStructuralConnectionCondition>
{
	private IfcLabel? _name;

	IfcLabel? IIfcStructuralConnectionCondition.Name
	{
		get
		{
			return Name;
		}
		set
		{
			Name = value;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public IfcLabel? Name
	{
		get
		{
			if (_activated)
			{
				return _name;
			}
			Activate();
			return _name;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_name = v;
			}, _name, value, "Name", 1);
		}
	}

	internal IfcStructuralConnectionCondition(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			_name = value.StringVal;
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcStructuralConnectionCondition other)
	{
		return this == other;
	}
}
