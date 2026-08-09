using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;

namespace Xbim.Ifc2x3.StructuralAnalysisDomain;

[ExpressType("IfcStructuralMember", 225)]
public abstract class IfcStructuralMember : IfcStructuralItem, IIfcStructuralMember, IIfcStructuralItem, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, Xbim.Ifc4.StructuralAnalysisDomain.IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IEquatable<IfcStructuralMember>
{
	IEnumerable<IIfcRelConnectsStructuralMember> IIfcStructuralMember.ConnectedBy => base.Model.Instances.Where((IIfcRelConnectsStructuralMember e) => e.RelatingStructuralMember as IfcStructuralMember == this, "RelatingStructuralMember", this);

	[InverseProperty("RelatedStructuralMember")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 15)]
	public IEnumerable<IfcRelConnectsStructuralElement> ReferencesElement => base.Model.Instances.Where((IfcRelConnectsStructuralElement e) => Equals(e.RelatedStructuralMember), "RelatedStructuralMember", this);

	[InverseProperty("RelatingStructuralMember")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 16)]
	public IEnumerable<IfcRelConnectsStructuralMember> ConnectedBy => base.Model.Instances.Where((IfcRelConnectsStructuralMember e) => Equals(e.RelatingStructuralMember), "RelatingStructuralMember", this);

	internal IfcStructuralMember(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 6u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcStructuralMember other)
	{
		return this == other;
	}
}
