using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;
using Xbim.Ifc4x3.RepresentationResource;

namespace Xbim.Ifc4x3.Kernel;

[ExpressType("IfcContext", 1138)]
public abstract class IfcContext : IfcObjectDefinition, IIfcContext, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IEquatable<IfcContext>
{
	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _objectType;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _longName;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _phase;

	private readonly OptionalItemSet<IfcRepresentationContext> _representationContexts;

	private Xbim.Ifc4x3.MeasureResource.IfcUnitAssignment _unitsInContext;

	[CrossSchemaAttribute(typeof(IIfcContext), 5)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcContext.ObjectType
	{
		get
		{
			if (!ObjectType.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(ObjectType.Value);
		}
		set
		{
			ObjectType = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcContext), 6)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcContext.LongName
	{
		get
		{
			if (!LongName.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(LongName.Value);
		}
		set
		{
			LongName = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcContext), 7)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcContext.Phase
	{
		get
		{
			if (!Phase.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Phase.Value);
		}
		set
		{
			Phase = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcContext), 8)]
	IItemSet<IIfcRepresentationContext> IIfcContext.RepresentationContexts => new ProxyItemSet<IfcRepresentationContext, IIfcRepresentationContext>(RepresentationContexts);

	[CrossSchemaAttribute(typeof(IIfcContext), 9)]
	IIfcUnitAssignment IIfcContext.UnitsInContext
	{
		get
		{
			return UnitsInContext;
		}
		set
		{
			UnitsInContext = value as Xbim.Ifc4x3.MeasureResource.IfcUnitAssignment;
		}
	}

	IEnumerable<IIfcRelDefinesByProperties> IIfcContext.IsDefinedBy => base.Model.Instances.Where((IIfcRelDefinesByProperties e) => e.RelatedObjects != null && e.RelatedObjects.Contains(this), "RelatedObjects", this);

	IEnumerable<IIfcRelDeclares> IIfcContext.Declares => base.Model.Instances.Where((IIfcRelDeclares e) => e.RelatingContext as IfcContext == this, "RelatingContext", this);

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 12)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? ObjectType
	{
		get
		{
			if (_activated)
			{
				return _objectType;
			}
			Activate();
			return _objectType;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_objectType = v;
			}, _objectType, value, "ObjectType", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 13)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? LongName
	{
		get
		{
			if (_activated)
			{
				return _longName;
			}
			Activate();
			return _longName;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_longName = v;
			}, _longName, value, "LongName", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 14)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? Phase
	{
		get
		{
			if (_activated)
			{
				return _phase;
			}
			Activate();
			return _phase;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_phase = v;
			}, _phase, value, "Phase", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 15)]
	public IOptionalItemSet<IfcRepresentationContext> RepresentationContexts
	{
		get
		{
			if (_activated)
			{
				return _representationContexts;
			}
			Activate();
			return _representationContexts;
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 16)]
	public Xbim.Ifc4x3.MeasureResource.IfcUnitAssignment UnitsInContext
	{
		get
		{
			if (_activated)
			{
				return _unitsInContext;
			}
			Activate();
			return _unitsInContext;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcUnitAssignment v)
			{
				_unitsInContext = v;
			}, _unitsInContext, value, "UnitsInContext", 9);
		}
	}

	[InverseProperty("RelatedObjects")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 17)]
	public IEnumerable<IfcRelDefinesByProperties> IsDefinedBy => base.Model.Instances.Where((IfcRelDefinesByProperties e) => e.RelatedObjects != null && e.RelatedObjects.Contains(this), "RelatedObjects", this);

	[InverseProperty("RelatingContext")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 18)]
	public IEnumerable<IfcRelDeclares> Declares => base.Model.Instances.Where((IfcRelDeclares e) => Equals(e.RelatingContext), "RelatingContext", this);

	internal IfcContext(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_representationContexts = new OptionalItemSet<IfcRepresentationContext>(this, 0, 8);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
		case 2:
		case 3:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 4:
			_objectType = value.StringVal;
			break;
		case 5:
			_longName = value.StringVal;
			break;
		case 6:
			_phase = value.StringVal;
			break;
		case 7:
			_representationContexts.InternalAdd((IfcRepresentationContext)value.EntityVal);
			break;
		case 8:
			_unitsInContext = (Xbim.Ifc4x3.MeasureResource.IfcUnitAssignment)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcContext other)
	{
		return this == other;
	}
}
