using System;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4x3.Kernel;

[ExpressType("IfcRelAssigns", 10)]
public abstract class IfcRelAssigns : IfcRelationship, IIfcRelAssigns, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist, IEquatable<IfcRelAssigns>
{
	private readonly ItemSet<IfcObjectDefinition> _relatedObjects;

	private IfcStrippedOptional? _relatedObjectsType;

	[CrossSchemaAttribute(typeof(IIfcRelAssigns), 5)]
	IItemSet<IIfcObjectDefinition> IIfcRelAssigns.RelatedObjects => new ProxyItemSet<IfcObjectDefinition, IIfcObjectDefinition>(RelatedObjects);

	[CrossSchemaAttribute(typeof(IIfcRelAssigns), 6)]
	IfcObjectTypeEnum? IIfcRelAssigns.RelatedObjectsType
	{
		get
		{
			return IfcObjectTypeEnum.NOTDEFINED;
		}
		set
		{
		}
	}

	[IndexedProperty]
	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 5)]
	public IItemSet<IfcObjectDefinition> RelatedObjects
	{
		get
		{
			if (_activated)
			{
				return _relatedObjects;
			}
			Activate();
			return _relatedObjects;
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcStrippedOptional? RelatedObjectsType
	{
		get
		{
			if (_activated)
			{
				return _relatedObjectsType;
			}
			Activate();
			return _relatedObjectsType;
		}
		set
		{
			SetValue(delegate(IfcStrippedOptional? v)
			{
				_relatedObjectsType = v;
			}, _relatedObjectsType, value, "RelatedObjectsType", 6);
		}
	}

	internal IfcRelAssigns(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_relatedObjects = new ItemSet<IfcObjectDefinition>(this, 0, 5);
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
			_relatedObjects.InternalAdd((IfcObjectDefinition)value.EntityVal);
			break;
		case 5:
			_relatedObjectsType = value.BooleanVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelAssigns other)
	{
		return this == other;
	}
}
