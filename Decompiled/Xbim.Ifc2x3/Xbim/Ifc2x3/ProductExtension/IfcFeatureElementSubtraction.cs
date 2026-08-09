using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;

namespace Xbim.Ifc2x3.ProductExtension;

[ExpressType("IfcFeatureElementSubtraction", 499)]
public abstract class IfcFeatureElementSubtraction : IfcFeatureElement, IIfcFeatureElementSubtraction, IIfcFeatureElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IEquatable<IfcFeatureElementSubtraction>
{
	IIfcRelVoidsElement IIfcFeatureElementSubtraction.VoidsElements => base.Model.Instances.FirstOrDefault((IIfcRelVoidsElement e) => e.RelatedOpeningElement as IfcFeatureElementSubtraction == this, "RelatedOpeningElement", this);

	[InverseProperty("RelatedOpeningElement")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, null, null, 27)]
	public IfcRelVoidsElement VoidsElements => base.Model.Instances.FirstOrDefault((IfcRelVoidsElement e) => Equals(e.RelatedOpeningElement), "RelatedOpeningElement", this);

	internal IfcFeatureElementSubtraction(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 7u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcFeatureElementSubtraction other)
	{
		return this == other;
	}
}
