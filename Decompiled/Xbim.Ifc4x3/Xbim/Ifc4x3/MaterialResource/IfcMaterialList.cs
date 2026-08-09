using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MaterialResource;

namespace Xbim.Ifc4x3.MaterialResource;

[ExpressType("IfcMaterialList", 246)]
public class IfcMaterialList : PersistEntity, IIfcMaterialList, IPersistEntity, IPersist, Xbim.Ifc4.MaterialResource.IfcMaterialSelect, IIfcMaterialSelect, IExpressSelectType, IInstantiableEntity, IfcMaterialSelect, IContainsEntityReferences, IEquatable<IfcMaterialList>
{
	private readonly ItemSet<IfcMaterial> _materials;

	[CrossSchemaAttribute(typeof(IIfcMaterialList), 1)]
	IItemSet<IIfcMaterial> IIfcMaterialList.Materials => new ProxyItemSet<IfcMaterial, IIfcMaterial>(Materials);

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 1)]
	public IItemSet<IfcMaterial> Materials
	{
		get
		{
			if (_activated)
			{
				return _materials;
			}
			Activate();
			return _materials;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcMaterial material in Materials)
			{
				yield return material;
			}
		}
	}

	internal IfcMaterialList(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_materials = new ItemSet<IfcMaterial>(this, 0, 1);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			_materials.InternalAdd((IfcMaterial)value.EntityVal);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcMaterialList other)
	{
		return this == other;
	}
}
