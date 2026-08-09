using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc4.ProductExtension;

[ExpressType("IfcPort", 179)]
public abstract class IfcPort : IfcProduct, IIfcPort, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IEquatable<IfcPort>
{
	IEnumerable<IIfcRelConnectsPortToElement> IIfcPort.ContainedIn => ContainedIn;

	IEnumerable<IIfcRelConnectsPorts> IIfcPort.ConnectedFrom => ConnectedFrom;

	IEnumerable<IIfcRelConnectsPorts> IIfcPort.ConnectedTo => ConnectedTo;

	[InverseProperty("RelatingPort")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 20)]
	public IEnumerable<IfcRelConnectsPortToElement> ContainedIn => base.Model.Instances.Where((IfcRelConnectsPortToElement e) => Equals(e.RelatingPort), "RelatingPort", this);

	[InverseProperty("RelatedPort")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 21)]
	public IEnumerable<IfcRelConnectsPorts> ConnectedFrom => base.Model.Instances.Where((IfcRelConnectsPorts e) => Equals(e.RelatedPort), "RelatedPort", this);

	[InverseProperty("RelatingPort")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 22)]
	public IEnumerable<IfcRelConnectsPorts> ConnectedTo => base.Model.Instances.Where((IfcRelConnectsPorts e) => Equals(e.RelatingPort), "RelatingPort", this);

	internal IfcPort(IModel model, int label, bool activated)
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

	public bool Equals(IfcPort other)
	{
		return this == other;
	}
}
