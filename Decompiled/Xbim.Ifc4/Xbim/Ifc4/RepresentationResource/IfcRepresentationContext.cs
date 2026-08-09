using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.RepresentationResource;

[ExpressType("IfcRepresentationContext", 378)]
public abstract class IfcRepresentationContext : PersistEntity, IIfcRepresentationContext, IPersistEntity, IPersist, IEquatable<IfcRepresentationContext>
{
	private IfcLabel? _contextIdentifier;

	private IfcLabel? _contextType;

	IfcLabel? IIfcRepresentationContext.ContextIdentifier
	{
		get
		{
			return ContextIdentifier;
		}
		set
		{
			ContextIdentifier = value;
		}
	}

	IfcLabel? IIfcRepresentationContext.ContextType
	{
		get
		{
			return ContextType;
		}
		set
		{
			ContextType = value;
		}
	}

	IEnumerable<IIfcRepresentation> IIfcRepresentationContext.RepresentationsInContext => RepresentationsInContext;

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public IfcLabel? ContextIdentifier
	{
		get
		{
			if (_activated)
			{
				return _contextIdentifier;
			}
			Activate();
			return _contextIdentifier;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_contextIdentifier = v;
			}, _contextIdentifier, value, "ContextIdentifier", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public IfcLabel? ContextType
	{
		get
		{
			if (_activated)
			{
				return _contextType;
			}
			Activate();
			return _contextType;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_contextType = v;
			}, _contextType, value, "ContextType", 2);
		}
	}

	[InverseProperty("ContextOfItems")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 3)]
	public IEnumerable<IfcRepresentation> RepresentationsInContext => base.Model.Instances.Where((IfcRepresentation e) => Equals(e.ContextOfItems), "ContextOfItems", this);

	internal IfcRepresentationContext(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_contextIdentifier = value.StringVal;
			break;
		case 1:
			_contextType = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRepresentationContext other)
	{
		return this == other;
	}
}
