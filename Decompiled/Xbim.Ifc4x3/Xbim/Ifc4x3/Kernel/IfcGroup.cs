using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.ProductExtension;

namespace Xbim.Ifc4x3.Kernel;

[ExpressType("IfcGroup", 228)]
public class IfcGroup : IfcObject, IIfcGroup, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IInstantiableEntity, IfcSpatialReferenceSelect, IContainsEntityReferences, IEquatable<IfcGroup>
{
	IEnumerable<IIfcRelAssignsToGroup> IIfcGroup.IsGroupedBy => base.Model.Instances.Where((IIfcRelAssignsToGroup e) => e.RelatingGroup as IfcGroup == this, "RelatingGroup", this);

	[InverseProperty("RelatingGroup")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 17)]
	public IEnumerable<IfcRelAssignsToGroup> IsGroupedBy => base.Model.Instances.Where((IfcRelAssignsToGroup e) => Equals(e.RelatingGroup), "RelatingGroup", this);

	[InverseProperty("RelatedElements")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 18)]
	public IEnumerable<IfcRelReferencedInSpatialStructure> ReferencedInStructures => base.Model.Instances.Where((IfcRelReferencedInSpatialStructure e) => e.RelatedElements != null && e.RelatedElements.Contains(this), "RelatedElements", this);

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

	internal IfcGroup(IModel model, int label, bool activated)
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

	public bool Equals(IfcGroup other)
	{
		return this == other;
	}
}
