using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc4x3.Kernel;

[ExpressType("IfcPropertyTemplate", 1233)]
public abstract class IfcPropertyTemplate : IfcPropertyTemplateDefinition, IIfcPropertyTemplate, IIfcPropertyTemplateDefinition, IIfcPropertyDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IEquatable<IfcPropertyTemplate>
{
	IEnumerable<IIfcComplexPropertyTemplate> IIfcPropertyTemplate.PartOfComplexTemplate => base.Model.Instances.Where((IIfcComplexPropertyTemplate e) => e.HasPropertyTemplates != null && e.HasPropertyTemplates.Contains(this), "HasPropertyTemplates", this);

	IEnumerable<IIfcPropertySetTemplate> IIfcPropertyTemplate.PartOfPsetTemplate => base.Model.Instances.Where((IIfcPropertySetTemplate e) => e.HasPropertyTemplates != null && e.HasPropertyTemplates.Contains(this), "HasPropertyTemplates", this);

	[InverseProperty("HasPropertyTemplates")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 7)]
	public IEnumerable<IfcComplexPropertyTemplate> PartOfComplexTemplate => base.Model.Instances.Where((IfcComplexPropertyTemplate e) => e.HasPropertyTemplates != null && e.HasPropertyTemplates.Contains(this), "HasPropertyTemplates", this);

	[InverseProperty("HasPropertyTemplates")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 8)]
	public IEnumerable<IfcPropertySetTemplate> PartOfPsetTemplate => base.Model.Instances.Where((IfcPropertySetTemplate e) => e.HasPropertyTemplates != null && e.HasPropertyTemplates.Contains(this), "HasPropertyTemplates", this);

	internal IfcPropertyTemplate(IModel model, int label, bool activated)
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

	public bool Equals(IfcPropertyTemplate other)
	{
		return this == other;
	}
}
