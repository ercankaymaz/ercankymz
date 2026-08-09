using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc4.StructuralAnalysisDomain;

[ExpressType("IfcStructuralItem", 226)]
public abstract class IfcStructuralItem : IfcProduct, IIfcStructuralItem, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IEquatable<IfcStructuralItem>
{
	IEnumerable<IIfcRelConnectsStructuralActivity> IIfcStructuralItem.AssignedStructuralActivity => AssignedStructuralActivity;

	[InverseProperty("RelatingElement")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 20)]
	public IEnumerable<IfcRelConnectsStructuralActivity> AssignedStructuralActivity => base.Model.Instances.Where((IfcRelConnectsStructuralActivity e) => Equals(e.RelatingElement), "RelatingElement", this);

	internal IfcStructuralItem(IModel model, int label, bool activated)
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

	public bool Equals(IfcStructuralItem other)
	{
		return this == other;
	}
}
