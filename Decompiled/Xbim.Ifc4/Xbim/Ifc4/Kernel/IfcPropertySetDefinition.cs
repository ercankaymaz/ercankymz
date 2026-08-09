using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4.Kernel;

[ExpressType("IfcPropertySetDefinition", 97)]
public abstract class IfcPropertySetDefinition : IfcPropertyDefinition, IIfcPropertySetDefinition, IIfcPropertyDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcPropertySetDefinitionSelect, IIfcPropertySetDefinitionSelect, IEquatable<IfcPropertySetDefinition>
{
	IEnumerable<IIfcTypeObject> IIfcPropertySetDefinition.DefinesType => DefinesType;

	IEnumerable<IIfcRelDefinesByTemplate> IIfcPropertySetDefinition.IsDefinedBy => IsDefinedBy;

	IEnumerable<IIfcRelDefinesByProperties> IIfcPropertySetDefinition.DefinesOccurrence => DefinesOccurrence;

	[InverseProperty("HasPropertySets")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 7)]
	public IEnumerable<IfcTypeObject> DefinesType => base.Model.Instances.Where((IfcTypeObject e) => e.HasPropertySets != null && e.HasPropertySets.Contains(this), "HasPropertySets", this);

	[InverseProperty("RelatedPropertySets")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 8)]
	public IEnumerable<IfcRelDefinesByTemplate> IsDefinedBy => base.Model.Instances.Where((IfcRelDefinesByTemplate e) => e.RelatedPropertySets != null && e.RelatedPropertySets.Contains(this), "RelatedPropertySets", this);

	[InverseProperty("RelatingPropertyDefinition")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 9)]
	public IEnumerable<IfcRelDefinesByProperties> DefinesOccurrence => base.Model.Instances.Where((IfcRelDefinesByProperties e) => Equals(e.RelatingPropertyDefinition), "RelatingPropertyDefinition", this);

	public IEnumerable<IIfcPropertySetDefinition> PropertySetDefinitions => new IIfcPropertySetDefinition[1] { this };

	internal IfcPropertySetDefinition(IModel model, int label, bool activated)
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

	public bool Equals(IfcPropertySetDefinition other)
	{
		return this == other;
	}
}
