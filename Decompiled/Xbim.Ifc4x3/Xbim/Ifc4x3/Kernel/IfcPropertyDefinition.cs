using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc4x3.Kernel;

[ExpressType("IfcPropertyDefinition", 98)]
public abstract class IfcPropertyDefinition : IfcRoot, IIfcPropertyDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcDefinitionSelect, IEquatable<IfcPropertyDefinition>
{
	IEnumerable<IIfcRelDeclares> IIfcPropertyDefinition.HasContext => base.Model.Instances.Where((IIfcRelDeclares e) => e.RelatedDefinitions != null && e.RelatedDefinitions.Contains(this), "RelatedDefinitions", this);

	IEnumerable<IIfcRelAssociates> IIfcPropertyDefinition.HasAssociations => base.Model.Instances.Where((IIfcRelAssociates e) => e.RelatedObjects != null && e.RelatedObjects.Contains(this), "RelatedObjects", this);

	[InverseProperty("RelatedDefinitions")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 5)]
	public IEnumerable<IfcRelDeclares> HasContext => base.Model.Instances.Where((IfcRelDeclares e) => e.RelatedDefinitions != null && e.RelatedDefinitions.Contains(this), "RelatedDefinitions", this);

	[InverseProperty("RelatedObjects")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 6)]
	public IEnumerable<IfcRelAssociates> HasAssociations => base.Model.Instances.Where((IfcRelAssociates e) => e.RelatedObjects != null && e.RelatedObjects.Contains(this), "RelatedObjects", this);

	internal IfcPropertyDefinition(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 3u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcPropertyDefinition other)
	{
		return this == other;
	}
}
