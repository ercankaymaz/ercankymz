using System;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.RepresentationResource;

[ExpressType("IfcProductRepresentation", 1)]
public abstract class IfcProductRepresentation : PersistEntity, IIfcProductRepresentation, IPersistEntity, IPersist, IEquatable<IfcProductRepresentation>
{
	private IfcLabel? _name;

	private IfcText? _description;

	private readonly ItemSet<IfcRepresentation> _representations;

	IfcLabel? IIfcProductRepresentation.Name
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

	IfcText? IIfcProductRepresentation.Description
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

	IItemSet<IIfcRepresentation> IIfcProductRepresentation.Representations => new ProxyItemSet<IfcRepresentation, IIfcRepresentation>(Representations);

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

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
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

	[IndexedProperty]
	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 3)]
	public IItemSet<IfcRepresentation> Representations
	{
		get
		{
			if (_activated)
			{
				return _representations;
			}
			Activate();
			return _representations;
		}
	}

	internal IfcProductRepresentation(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_representations = new ItemSet<IfcRepresentation>(this, 0, 3);
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
			_representations.InternalAdd((IfcRepresentation)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcProductRepresentation other)
	{
		return this == other;
	}
}
