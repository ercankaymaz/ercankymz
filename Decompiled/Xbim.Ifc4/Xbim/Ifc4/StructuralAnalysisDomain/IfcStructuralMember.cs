using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc4.StructuralAnalysisDomain;

[ExpressType("IfcStructuralMember", 225)]
public abstract class IfcStructuralMember : IfcStructuralItem, IIfcStructuralMember, IIfcStructuralItem, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IEquatable<IfcStructuralMember>
{
	IEnumerable<IIfcRelConnectsStructuralMember> IIfcStructuralMember.ConnectedBy => ConnectedBy;

	[InverseProperty("RelatingStructuralMember")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 21)]
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
