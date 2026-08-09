using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.RepresentationResource;

namespace Xbim.Ifc4.Kernel;

[ExpressType("IfcContext", 1138)]
public abstract class IfcContext : IfcObjectDefinition, IIfcContext, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IEquatable<IfcContext>
{
	private IfcLabel? _objectType;

	private IfcLabel? _longName;

	private IfcLabel? _phase;

	private readonly OptionalItemSet<IfcRepresentationContext> _representationContexts;

	private IfcUnitAssignment _unitsInContext;

	IfcLabel? IIfcContext.ObjectType
	{
		get
		{
			return ObjectType;
		}
		set
		{
			ObjectType = value;
		}
	}

	IfcLabel? IIfcContext.LongName
	{
		get
		{
			return LongName;
		}
		set
		{
			LongName = value;
		}
	}

	IfcLabel? IIfcContext.Phase
	{
		get
		{
			return Phase;
		}
		set
		{
			Phase = value;
		}
	}

	IItemSet<IIfcRepresentationContext> IIfcContext.RepresentationContexts => new ProxyItemSet<IfcRepresentationContext, IIfcRepresentationContext>(RepresentationContexts);

	IIfcUnitAssignment IIfcContext.UnitsInContext
	{
		get
		{
			return UnitsInContext;
		}
		set
		{
			UnitsInContext = value as IfcUnitAssignment;
		}
	}

	IEnumerable<IIfcRelDefinesByProperties> IIfcContext.IsDefinedBy => IsDefinedBy;

	IEnumerable<IIfcRelDeclares> IIfcContext.Declares => Declares;

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 12)]
	public IfcLabel? ObjectType
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
			SetValue(delegate(IfcLabel? v)
			{
				_objectType = v;
			}, _objectType, value, "ObjectType", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 13)]
	public IfcLabel? LongName
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
			SetValue(delegate(IfcLabel? v)
			{
				_longName = v;
			}, _longName, value, "LongName", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 14)]
	public IfcLabel? Phase
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
			SetValue(delegate(IfcLabel? v)
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
	public IfcUnitAssignment UnitsInContext
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
			SetValue(delegate(IfcUnitAssignment v)
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
			_unitsInContext = (IfcUnitAssignment)value.EntityVal;
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
