using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.PropertyResource;

namespace Xbim.Ifc4x3.Kernel;

[ExpressType("IfcPropertySet", 666)]
public class IfcPropertySet : IfcPropertySetDefinition, IIfcPropertySet, IIfcPropertySetDefinition, IIfcPropertyDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcPropertySetDefinitionSelect, IIfcPropertySetDefinitionSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcPropertySet>
{
	private readonly ItemSet<IfcProperty> _hasProperties;

	[CrossSchemaAttribute(typeof(IIfcPropertySet), 5)]
	IItemSet<IIfcProperty> IIfcPropertySet.HasProperties => new ProxyItemSet<IfcProperty, IIfcProperty>(HasProperties);

	[IndexedProperty]
	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 10)]
	public IItemSet<IfcProperty> HasProperties
	{
		get
		{
			if (_activated)
			{
				return _hasProperties;
			}
			Activate();
			return _hasProperties;
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
			foreach (IfcProperty hasProperty in HasProperties)
			{
				yield return hasProperty;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcProperty hasProperty in HasProperties)
			{
				yield return hasProperty;
			}
		}
	}

	internal IfcPropertySet(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_hasProperties = new ItemSet<IfcProperty>(this, 0, 5);
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
			_hasProperties.InternalAdd((IfcProperty)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPropertySet other)
	{
		return this == other;
	}
}
