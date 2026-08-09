using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.ProductExtension;

namespace Xbim.Ifc4x3.SharedBldgElements;

[ExpressType("IfcCovering", 382)]
public class IfcCovering : IfcBuiltElement, IIfcCovering, IIfcBuildingElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcCovering>
{
	private IfcCoveringTypeEnum? _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcCovering), 9)]
	Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum? IIfcCovering.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcCoveringTypeEnum.CEILING => Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.CEILING, 
				IfcCoveringTypeEnum.CLADDING => Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.CLADDING, 
				IfcCoveringTypeEnum.COPING => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum>(), 
				IfcCoveringTypeEnum.FLOORING => Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.FLOORING, 
				IfcCoveringTypeEnum.INSULATION => Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.INSULATION, 
				IfcCoveringTypeEnum.MEMBRANE => Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.MEMBRANE, 
				IfcCoveringTypeEnum.MOLDING => Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.MOLDING, 
				IfcCoveringTypeEnum.ROOFING => Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.ROOFING, 
				IfcCoveringTypeEnum.SKIRTINGBOARD => Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.SKIRTINGBOARD, 
				IfcCoveringTypeEnum.SLEEVING => Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.SLEEVING, 
				IfcCoveringTypeEnum.TOPPING => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum>(), 
				IfcCoveringTypeEnum.WRAPPING => Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.WRAPPING, 
				IfcCoveringTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.USERDEFINED, 
				IfcCoveringTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.CEILING:
				PredefinedType = IfcCoveringTypeEnum.CEILING;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.FLOORING:
				PredefinedType = IfcCoveringTypeEnum.FLOORING;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.CLADDING:
				PredefinedType = IfcCoveringTypeEnum.CLADDING;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.ROOFING:
				PredefinedType = IfcCoveringTypeEnum.ROOFING;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.MOLDING:
				PredefinedType = IfcCoveringTypeEnum.MOLDING;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.SKIRTINGBOARD:
				PredefinedType = IfcCoveringTypeEnum.SKIRTINGBOARD;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.INSULATION:
				PredefinedType = IfcCoveringTypeEnum.INSULATION;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.MEMBRANE:
				PredefinedType = IfcCoveringTypeEnum.MEMBRANE;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.SLEEVING:
				PredefinedType = IfcCoveringTypeEnum.SLEEVING;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.WRAPPING:
				PredefinedType = IfcCoveringTypeEnum.WRAPPING;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.USERDEFINED:
				PredefinedType = IfcCoveringTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoveringTypeEnum.NOTDEFINED:
				PredefinedType = IfcCoveringTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	IEnumerable<IIfcRelCoversSpaces> IIfcCovering.CoversSpaces => base.Model.Instances.Where((IIfcRelCoversSpaces e) => e.RelatedCoverings != null && e.RelatedCoverings.Contains(this), "RelatedCoverings", this);

	IEnumerable<IIfcRelCoversBldgElements> IIfcCovering.CoversElements => base.Model.Instances.Where((IIfcRelCoversBldgElements e) => e.RelatedCoverings != null && e.RelatedCoverings.Contains(this), "RelatedCoverings", this);

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 35)]
	public IfcCoveringTypeEnum? PredefinedType
	{
		get
		{
			if (_activated)
			{
				return _predefinedType;
			}
			Activate();
			return _predefinedType;
		}
		set
		{
			SetValue(delegate(IfcCoveringTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 9);
		}
	}

	[InverseProperty("RelatedCoverings")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 36)]
	public IEnumerable<IfcRelCoversSpaces> CoversSpaces => base.Model.Instances.Where((IfcRelCoversSpaces e) => e.RelatedCoverings != null && e.RelatedCoverings.Contains(this), "RelatedCoverings", this);

	[InverseProperty("RelatedCoverings")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 37)]
	public IEnumerable<IfcRelCoversBldgElements> CoversElements => base.Model.Instances.Where((IfcRelCoversBldgElements e) => e.RelatedCoverings != null && e.RelatedCoverings.Contains(this), "RelatedCoverings", this);

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

	internal IfcCovering(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
		case 2:
		case 3:
		case 4:
		case 5:
		case 6:
		case 7:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 8:
			_predefinedType = (IfcCoveringTypeEnum)Enum.Parse(typeof(IfcCoveringTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCovering other)
	{
		return this == other;
	}
}
