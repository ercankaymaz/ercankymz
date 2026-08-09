using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;

namespace Xbim.Ifc4.ProductExtension;

[ExpressType("IfcFeatureElementAddition", 385)]
public abstract class IfcFeatureElementAddition : IfcFeatureElement, IIfcFeatureElementAddition, IIfcFeatureElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IEquatable<IfcFeatureElementAddition>
{
	IIfcRelProjectsElement IIfcFeatureElementAddition.ProjectsElements => ProjectsElements;

	[InverseProperty("RelatedFeatureElement")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, null, null, 33)]
	public IfcRelProjectsElement ProjectsElements => base.Model.Instances.FirstOrDefault((IfcRelProjectsElement e) => Equals(e.RelatedFeatureElement), "RelatedFeatureElement", this);

	internal IfcFeatureElementAddition(IModel model, int label, bool activated)
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

	public bool Equals(IfcFeatureElementAddition other)
	{
		return this == other;
	}
}
