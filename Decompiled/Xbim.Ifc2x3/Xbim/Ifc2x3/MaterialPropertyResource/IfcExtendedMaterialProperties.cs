using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.PropertyResource;

namespace Xbim.Ifc2x3.MaterialPropertyResource;

[ExpressType("IfcExtendedMaterialProperties", 585)]
public class IfcExtendedMaterialProperties : IfcMaterialProperties, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcExtendedMaterialProperties>
{
	private readonly ItemSet<IfcProperty> _extendedProperties;

	private IfcText? _description;

	private IfcLabel _name;

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 2)]
	public IItemSet<IfcProperty> ExtendedProperties
	{
		get
		{
			if (_activated)
			{
				return _extendedProperties;
			}
			Activate();
			return _extendedProperties;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcText? Description
	{
		get
		{
			if (_activated)
			{
				return _description;
			}
			Activate();
			return _description;
		}
		set
		{
			SetValue(delegate(IfcText? v)
			{
				_description = v;
			}, _description, value, "Description", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcLabel Name
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
			SetValue(delegate(IfcLabel v)
			{
				_name = v;
			}, _name, value, "Name", 4);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.Material != null)
			{
				yield return base.Material;
			}
			foreach (IfcProperty extendedProperty in ExtendedProperties)
			{
				yield return extendedProperty;
			}
		}
	}

	internal IfcExtendedMaterialProperties(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_extendedProperties = new ItemSet<IfcProperty>(this, 0, 2);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 1:
			_extendedProperties.InternalAdd((IfcProperty)value.EntityVal);
			break;
		case 2:
			_description = value.StringVal;
			break;
		case 3:
			_name = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcExtendedMaterialProperties other)
	{
		return this == other;
	}
}
