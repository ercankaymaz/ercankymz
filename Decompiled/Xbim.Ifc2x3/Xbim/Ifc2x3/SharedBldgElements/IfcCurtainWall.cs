using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.ProductExtension;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;

namespace Xbim.Ifc2x3.SharedBldgElements;

[ExpressType("IfcCurtainWall", 456)]
public class IfcCurtainWall : IfcBuildingElement, IIfcCurtainWall, IIfcBuildingElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcCurtainWall>
{
	private Xbim.Ifc4.Interfaces.IfcCurtainWallTypeEnum? _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcCurtainWall), 9)]
	Xbim.Ifc4.Interfaces.IfcCurtainWallTypeEnum? IIfcCurtainWall.PredefinedType
	{
		get
		{
			return _predefinedType;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4.Interfaces.IfcCurtainWallTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", -9);
		}
	}

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

	internal IfcCurtainWall(IModel model, int label, bool activated)
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

	public bool Equals(IfcCurtainWall other)
	{
		return this == other;
	}
}
