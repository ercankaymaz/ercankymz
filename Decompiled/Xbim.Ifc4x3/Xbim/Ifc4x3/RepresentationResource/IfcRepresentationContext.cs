using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.RepresentationResource;

[ExpressType("IfcRepresentationContext", 378)]
public abstract class IfcRepresentationContext : PersistEntity, IIfcRepresentationContext, IPersistEntity, IPersist, IEquatable<IfcRepresentationContext>
{
	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _contextIdentifier;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _contextType;

	[CrossSchemaAttribute(typeof(IIfcRepresentationContext), 1)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcRepresentationContext.ContextIdentifier
	{
		get
		{
			if (!ContextIdentifier.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(ContextIdentifier.Value);
		}
		set
		{
			ContextIdentifier = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRepresentationContext), 2)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcRepresentationContext.ContextType
	{
		get
		{
			if (!ContextType.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(ContextType.Value);
		}
		set
		{
			ContextType = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	IEnumerable<IIfcRepresentation> IIfcRepresentationContext.RepresentationsInContext => base.Model.Instances.Where((IIfcRepresentation e) => e.ContextOfItems as IfcRepresentationContext == this, "ContextOfItems", this);

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? ContextIdentifier
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_contextIdentifier = v;
			}, _contextIdentifier, value, "ContextIdentifier", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? ContextType
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
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
