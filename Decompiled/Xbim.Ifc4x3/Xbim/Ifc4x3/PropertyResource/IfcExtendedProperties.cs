using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.PropertyResource;

[ExpressType("IfcExtendedProperties", 1171)]
public abstract class IfcExtendedProperties : IfcPropertyAbstraction, IIfcExtendedProperties, IIfcPropertyAbstraction, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IEquatable<IfcExtendedProperties>
{
	private Xbim.Ifc4x3.MeasureResource.IfcIdentifier? _name;

	private Xbim.Ifc4x3.MeasureResource.IfcText? _description;

	private readonly ItemSet<IfcProperty> _properties;

	[CrossSchemaAttribute(typeof(IIfcExtendedProperties), 1)]
	Xbim.Ifc4.MeasureResource.IfcIdentifier? IIfcExtendedProperties.Name
	{
		get
		{
			if (!Name.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcIdentifier(Name.Value);
		}
		set
		{
			Name = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcIdentifier?(new Xbim.Ifc4x3.MeasureResource.IfcIdentifier(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcIdentifier?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcExtendedProperties), 2)]
	Xbim.Ifc4.MeasureResource.IfcText? IIfcExtendedProperties.Description
	{
		get
		{
			if (!Description.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcText(Description.Value);
		}
		set
		{
			Description = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcText?(new Xbim.Ifc4x3.MeasureResource.IfcText(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcText?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcExtendedProperties), 3)]
	IEnumerable<IIfcProperty> IIfcExtendedProperties.Properties => new ProxyItemSet<IfcProperty, IIfcProperty>(Properties);

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public Xbim.Ifc4x3.MeasureResource.IfcIdentifier? Name
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcIdentifier? v)
			{
				_name = v;
			}, _name, value, "Name", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc4x3.MeasureResource.IfcText? Description
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcText? v)
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
