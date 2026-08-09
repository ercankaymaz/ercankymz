using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PropertyResource;

namespace Xbim.Ifc4.MaterialResource;

[ExpressType("IfcMaterialConstituentSet", 1202)]
public class IfcMaterialConstituentSet : IfcMaterialDefinition, IInstantiableEntity, IPersistEntity, IPersist, IIfcMaterialConstituentSet, IIfcMaterialDefinition, IfcMaterialSelect, IIfcMaterialSelect, IExpressSelectType, IfcObjectReferenceSelect, IIfcObjectReferenceSelect, IfcResourceObjectSelect, IIfcResourceObjectSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcMaterialConstituentSet>
{
	private IfcLabel? _name;

	private IfcText? _description;

	private readonly OptionalItemSet<IfcMaterialConstituent> _materialConstituents;

	IfcLabel? IIfcMaterialConstituentSet.Name
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

	IfcText? IIfcMaterialConstituentSet.Description
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

	IItemSet<IIfcMaterialConstituent> IIfcMaterialConstituentSet.MaterialConstituents => new ProxyItemSet<IfcMaterialConstituent, IIfcMaterialConstituent>(MaterialConstituents);

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
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

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
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
	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 6)]
	public IOptionalItemSet<IfcMaterialConstituent> MaterialConstituents
	{
		get
		{
			if (_activated)
			{
				return _materialConstituents;
			}
			Activate();
			return _materialConstituents;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcMaterialConstituent materialConstituent in MaterialConstituents)
			{
				yield return materialConstituent;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcMaterialConstituent materialConstituent in MaterialConstituents)
			{
				yield return materialConstituent;
			}
		}
	}

	internal IfcMaterialConstituentSet(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_materialConstituents = new OptionalItemSet<IfcMaterialConstituent>(this, 0, 3);
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
			_materialConstituents.InternalAdd((IfcMaterialConstituent)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcMaterialConstituentSet other)
	{
		return this == other;
	}
}
