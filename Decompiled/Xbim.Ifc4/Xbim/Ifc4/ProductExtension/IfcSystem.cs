using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc4.ProductExtension;

[ExpressType("IfcSystem", 229)]
public class IfcSystem : IfcGroup, IInstantiableEntity, IPersistEntity, IPersist, IIfcSystem, IIfcGroup, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcSystem>
{
	IEnumerable<IIfcRelServicesBuildings> IIfcSystem.ServicesBuildings => ServicesBuildings;

	[InverseProperty("RelatingSystem")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 18)]
	public IEnumerable<IfcRelServicesBuildings> ServicesBuildings => base.Model.Instances.Where((IfcRelServicesBuildings e) => Equals(e.RelatingSystem), "RelatingSystem", this);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.OwnerHistory != null)
			{
				yield return base.OwnerHistory;
			}
		}
	}

	internal IfcSystem(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 4u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcSystem other)
	{
		return this == other;
	}
}
