using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc2x3.Kernel;

[ExpressType("IfcRelDefinesByProperties", 247)]
public class IfcRelDefinesByProperties : IfcRelDefines, IIfcRelDefinesByProperties, IIfcRelDefines, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelDefinesByProperties>
{
	private IItemSet<IIfcObjectDefinition> _relatedObjectsIfc4;

	private IIfcPropertySetDefinitionSelect _relatingPropertyDefinition4;

	private IfcPropertySetDefinition _relatingPropertyDefinition;

	[CrossSchemaAttribute(typeof(IIfcRelDefinesByProperties), 5)]
	IItemSet<IIfcObjectDefinition> IIfcRelDefinesByProperties.RelatedObjects => _relatedObjectsIfc4 ?? (_relatedObjectsIfc4 = new ExtendedItemSet<IfcObject, IIfcObjectDefinition>(base.RelatedObjects, new ItemSet<IIfcObjectDefinition>(this, 0, -5), RelatedObjectsToIfc4, RelatedObjectsToIfc2X3));

	[CrossSchemaAttribute(typeof(IIfcRelDefinesByProperties), 6)]
	IIfcPropertySetDefinitionSelect IIfcRelDefinesByProperties.RelatingPropertyDefinition
	{
		get
		{
			return _relatingPropertyDefinition4 ?? RelatingPropertyDefinition;
		}
		set
		{
			if (value == null)
			{
				RelatingPropertyDefinition = null;
				if (_relatingPropertyDefinition4 != null)
				{
					SetValue(delegate(IIfcPropertySetDefinitionSelect v)
					{
						_relatingPropertyDefinition4 = v;
					}, _relatingPropertyDefinition4, null, "RelatingPropertyDefinition", -6);
				}
				return;
			}
			IfcPropertySetDefinition ifcPropertySetDefinition = value as IfcPropertySetDefinition;
			if (ifcPropertySetDefinition != null)
			{
				RelatingPropertyDefinition = ifcPropertySetDefinition;
				if (_relatingPropertyDefinition4 != null)
				{
					SetValue(delegate(IIfcPropertySetDefinitionSelect v)
					{
						_relatingPropertyDefinition4 = v;
					}, _relatingPropertyDefinition4, null, "RelatingPropertyDefinition", -6);
				}
			}
			else
			{
				if (RelatingPropertyDefinition != null)
				{
					RelatingPropertyDefinition = null;
				}
				SetValue(delegate(IIfcPropertySetDefinitionSelect v)
				{
					_relatingPropertyDefinition4 = v;
				}, _relatingPropertyDefinition4, value, "RelatingPropertyDefinition", -6);
			}
		}
	}

	[IndexedProperty]
	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public IfcPropertySetDefinition RelatingPropertyDefinition
	{
		get
		{
			if (_activated)
			{
				return _relatingPropertyDefinition;
			}
			Activate();
			return _relatingPropertyDefinition;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcPropertySetDefinition v)
			{
				_relatingPropertyDefinition = v;
			}, _relatingPropertyDefinition, value, "RelatingPropertyDefinition", 6);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.OwnerHistory != null)
			{
				yield return base.OwnerHistory;
			}
			foreach (IfcObject relatedObject in base.RelatedObjects)
			{
				yield return relatedObject;
			}
			if (RelatingPropertyDefinition != null)
			{
				yield return RelatingPropertyDefinition;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcObject relatedObject in base.RelatedObjects)
			{
				yield return relatedObject;
			}
			if (RelatingPropertyDefinition != null)
			{
				yield return RelatingPropertyDefinition;
			}
		}
	}

	private static IIfcObjectDefinition RelatedObjectsToIfc4(IfcObject member)
	{
		return member;
	}

	private static IfcObject RelatedObjectsToIfc2X3(IIfcObjectDefinition member)
	{
		return member as IfcObject;
	}

	internal IfcRelDefinesByProperties(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
		case 2:
		case 3:
		case 4:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 5:
			_relatingPropertyDefinition = (IfcPropertySetDefinition)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelDefinesByProperties other)
	{
		return this == other;
	}
}
