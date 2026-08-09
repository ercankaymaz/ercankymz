using System;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4.Kernel;

[ExpressType("IfcRelAssociates", 308)]
public abstract class IfcRelAssociates : IfcRelationship, IIfcRelAssociates, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist, IEquatable<IfcRelAssociates>
{
	private readonly ItemSet<IfcDefinitionSelect> _relatedObjects;

	IItemSet<IIfcDefinitionSelect> IIfcRelAssociates.RelatedObjects => new ProxyItemSet<IfcDefinitionSelect, IIfcDefinitionSelect>(RelatedObjects);

	[IndexedProperty]
	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 5)]
	public IItemSet<IfcDefinitionSelect> RelatedObjects
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

	internal IfcRelAssociates(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_relatedObjects = new ItemSet<IfcDefinitionSelect>(this, 0, 5);
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
			_relatedObjects.InternalAdd((IfcDefinitionSelect)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelAssociates other)
	{
		return this == other;
	}
}
