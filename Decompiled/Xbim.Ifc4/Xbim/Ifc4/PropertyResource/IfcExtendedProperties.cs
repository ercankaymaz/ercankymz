using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.PropertyResource;

[ExpressType("IfcExtendedProperties", 1171)]
public abstract class IfcExtendedProperties : IfcPropertyAbstraction, IIfcExtendedProperties, IIfcPropertyAbstraction, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IEquatable<IfcExtendedProperties>
{
	private IfcIdentifier? _name;

	private IfcText? _description;

	private readonly ItemSet<IfcProperty> _properties;

	IfcIdentifier? IIfcExtendedProperties.Name
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

	IfcText? IIfcExtendedProperties.Description
	{
		get
		{
			return Description;
		}
		set
		{
			Description = value;
		}
	}

	IEnumerable<IIfcProperty> IIfcExtendedProperties.Properties => new ProxyItemSet<IfcProperty, IIfcProperty>(Properties);

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public IfcIdentifier? Name
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
			SetValue(delegate(IfcIdentifier? v)
			{
				_name = v;
			}, _name, value, "Name", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
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
			}, _description, value, "Description", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 4)]
	public IItemSet<IfcProperty> Properties
	{
		get
		{
			if (_activated)
			{
				return _properties;
			}
			Activate();
			return _properties;
		}
	}

	internal IfcExtendedProperties(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_properties = new ItemSet<IfcProperty>(this, 0, 3);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_name = value.StringVal;
			break;
		case 1:
			_description = value.StringVal;
			break;
		case 2:
			_properties.InternalAdd((IfcProperty)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcExtendedProperties other)
	{
		return this == other;
	}
}
