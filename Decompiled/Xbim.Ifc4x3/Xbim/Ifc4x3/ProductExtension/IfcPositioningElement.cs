using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.Kernel;

namespace Xbim.Ifc4x3.ProductExtension;

[ExpressType("IfcPositioningElement", 1331)]
public abstract class IfcPositioningElement : Xbim.Ifc4x3.Kernel.IfcProduct, IIfcPositioningElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect, IEquatable<IfcPositioningElement>
{
	IEnumerable<IIfcRelContainedInSpatialStructure> IIfcPositioningElement.ContainedInStructure => base.Model.Instances.Where((IIfcRelContainedInSpatialStructure e) => e.RelatedElements != null && e.RelatedElements.Contains(this), "RelatedElements", this);

	[InverseProperty("RelatedElements")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 22)]
	public IEnumerable<IfcRelContainedInSpatialStructure> ContainedInStructure => base.Model.Instances.Where((IfcRelContainedInSpatialStructure e) => e.RelatedElements != null && e.RelatedElements.Contains(this), "RelatedElements", this);

	[InverseProperty("RelatingPositioningElement")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 23)]
	public IEnumerable<IfcRelPositions> Positions => base.Model.Instances.Where((IfcRelPositions e) => Equals(e.RelatingPositioningElement), "RelatingPositioningElement", this);

	internal IfcPositioningElement(IModel model, int label, bool activated)
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

	public bool Equals(IfcPositioningElement other)
	{
		return this == other;
	}
}
