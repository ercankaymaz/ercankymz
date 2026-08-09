using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.GeometryResource;

[ExpressType("IfcMappedItem", 333)]
public class IfcMappedItem : IfcRepresentationItem, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcMappedItem>, IIfcMappedItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType
{
	private IfcRepresentationMap _mappingSource;

	private IfcCartesianTransformationOperator _mappingTarget;

	[IndexedProperty]
	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcRepresentationMap MappingSource
	{
		get
		{
			if (_activated)
			{
				return _mappingSource;
			}
			Activate();
			return _mappingSource;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcRepresentationMap v)
			{
				_mappingSource = v;
			}, _mappingSource, value, "MappingSource", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcCartesianTransformationOperator MappingTarget
	{
		get
		{
			if (_activated)
			{
				return _mappingTarget;
			}
			Activate();
			return _mappingTarget;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCartesianTransformationOperator v)
			{
				_mappingTarget = v;
			}, _mappingTarget, value, "MappingTarget", 2);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (MappingSource != null)
			{
				yield return MappingSource;
			}
			if (MappingTarget != null)
			{
				yield return MappingTarget;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (MappingSource != null)
			{
				yield return MappingSource;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcMappedItem), 1)]
	IIfcRepresentationMap IIfcMappedItem.MappingSource
	{
		get
		{
			return MappingSource;
		}
		set
		{
			MappingSource = value as IfcRepresentationMap;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcMappedItem), 2)]
	IIfcCartesianTransformationOperator IIfcMappedItem.MappingTarget
	{
		get
		{
			return MappingTarget;
		}
		set
		{
			MappingTarget = value as IfcCartesianTransformationOperator;
		}
	}

	internal IfcMappedItem(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_mappingSource = (IfcRepresentationMap)value.EntityVal;
			break;
		case 1:
			_mappingTarget = (IfcCartesianTransformationOperator)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcMappedItem other)
	{
		return this == other;
	}
}
