using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;

namespace Xbim.Ifc2x3.ProductExtension;

[ExpressType("IfcOpeningElement", 498)]
public class IfcOpeningElement : IfcFeatureElementSubtraction, IIfcOpeningElement, IIfcFeatureElementSubtraction, IIfcFeatureElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcOpeningElement>
{
	private IfcOpeningElementTypeEnum? _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcOpeningElement), 9)]
	IfcOpeningElementTypeEnum? IIfcOpeningElement.PredefinedType
	{
		get
		{
			return _predefinedType;
		}
		set
		{
			SetValue(delegate(IfcOpeningElementTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", -9);
		}
	}

	IEnumerable<IIfcRelFillsElement> IIfcOpeningElement.HasFillings => base.Model.Instances.Where((IIfcRelFillsElement e) => e.RelatingOpeningElement as IfcOpeningElement == this, "RelatingOpeningElement", this);

	[InverseProperty("RelatingOpeningElement")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 28)]
	public IEnumerable<IfcRelFillsElement> HasFillings => base.Model.Instances.Where((IfcRelFillsElement e) => Equals(e.RelatingOpeningElement), "RelatingOpeningElement", this);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.OwnerHistory != null)
			{
				yield return base.OwnerHistory;
			}
			if (base.ObjectPlacement != null)
			{
				yield return base.ObjectPlacement;
			}
			if (base.Representation != null)
			{
				yield return base.Representation;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (base.ObjectPlacement != null)
			{
				yield return base.ObjectPlacement;
			}
			if (base.Representation != null)
			{
				yield return base.Representation;
			}
		}
	}

	internal IfcOpeningElement(IModel model, int label, bool activated)
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

	public bool Equals(IfcOpeningElement other)
	{
		return this == other;
	}
}
