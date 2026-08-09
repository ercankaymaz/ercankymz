using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc2x3.ProductExtension;

[ExpressType("IfcPort", 179)]
public abstract class IfcPort : Xbim.Ifc2x3.Kernel.IfcProduct, IIfcPort, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IEquatable<IfcPort>
{
	IEnumerable<IIfcRelConnectsPortToElement> IIfcPort.ContainedIn => base.Model.Instances.Where((IIfcRelConnectsPortToElement e) => e.RelatingPort as IfcPort == this, "RelatingPort", this);

	IEnumerable<IIfcRelConnectsPorts> IIfcPort.ConnectedFrom => base.Model.Instances.Where((IIfcRelConnectsPorts e) => e.RelatedPort as IfcPort == this, "RelatedPort", this);

	IEnumerable<IIfcRelConnectsPorts> IIfcPort.ConnectedTo => base.Model.Instances.Where((IIfcRelConnectsPorts e) => e.RelatingPort as IfcPort == this, "RelatingPort", this);

	[InverseProperty("RelatingPort")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, null, null, 14)]
	public IfcRelConnectsPortToElement ContainedIn => base.Model.Instances.FirstOrDefault((IfcRelConnectsPortToElement e) => Equals(e.RelatingPort), "RelatingPort", this);

	[InverseProperty("RelatedPort")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 15)]
	public IEnumerable<IfcRelConnectsPorts> ConnectedFrom => base.Model.Instances.Where((IfcRelConnectsPorts e) => Equals(e.RelatedPort), "RelatedPort", this);

	[InverseProperty("RelatingPort")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 16)]
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
