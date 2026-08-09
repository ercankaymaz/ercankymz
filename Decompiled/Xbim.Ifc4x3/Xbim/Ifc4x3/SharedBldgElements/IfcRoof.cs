using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.ProductExtension;

namespace Xbim.Ifc4x3.SharedBldgElements;

[ExpressType("IfcRoof", 347)]
public class IfcRoof : IfcBuiltElement, IIfcRoof, IIfcBuildingElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRoof>
{
	private IfcRoofTypeEnum? _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcRoof), 9)]
	Xbim.Ifc4.Interfaces.IfcRoofTypeEnum? IIfcRoof.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcRoofTypeEnum.BARREL_ROOF => Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.BARREL_ROOF, 
				IfcRoofTypeEnum.BUTTERFLY_ROOF => Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.BUTTERFLY_ROOF, 
				IfcRoofTypeEnum.DOME_ROOF => Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.DOME_ROOF, 
				IfcRoofTypeEnum.FLAT_ROOF => Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.FLAT_ROOF, 
				IfcRoofTypeEnum.FREEFORM => Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.FREEFORM, 
				IfcRoofTypeEnum.GABLE_ROOF => Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.GABLE_ROOF, 
				IfcRoofTypeEnum.GAMBREL_ROOF => Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.GAMBREL_ROOF, 
				IfcRoofTypeEnum.HIPPED_GABLE_ROOF => Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.HIPPED_GABLE_ROOF, 
				IfcRoofTypeEnum.HIP_ROOF => Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.HIP_ROOF, 
				IfcRoofTypeEnum.MANSARD_ROOF => Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.MANSARD_ROOF, 
				IfcRoofTypeEnum.PAVILION_ROOF => Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.PAVILION_ROOF, 
				IfcRoofTypeEnum.RAINBOW_ROOF => Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.RAINBOW_ROOF, 
				IfcRoofTypeEnum.SHED_ROOF => Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.SHED_ROOF, 
				IfcRoofTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.USERDEFINED, 
				IfcRoofTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.FLAT_ROOF:
				PredefinedType = IfcRoofTypeEnum.FLAT_ROOF;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.SHED_ROOF:
				PredefinedType = IfcRoofTypeEnum.SHED_ROOF;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.GABLE_ROOF:
				PredefinedType = IfcRoofTypeEnum.GABLE_ROOF;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.HIP_ROOF:
				PredefinedType = IfcRoofTypeEnum.HIP_ROOF;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.HIPPED_GABLE_ROOF:
				PredefinedType = IfcRoofTypeEnum.HIPPED_GABLE_ROOF;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.GAMBREL_ROOF:
				PredefinedType = IfcRoofTypeEnum.GAMBREL_ROOF;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.MANSARD_ROOF:
				PredefinedType = IfcRoofTypeEnum.MANSARD_ROOF;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.BARREL_ROOF:
				PredefinedType = IfcRoofTypeEnum.BARREL_ROOF;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.RAINBOW_ROOF:
				PredefinedType = IfcRoofTypeEnum.RAINBOW_ROOF;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.BUTTERFLY_ROOF:
				PredefinedType = IfcRoofTypeEnum.BUTTERFLY_ROOF;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.PAVILION_ROOF:
				PredefinedType = IfcRoofTypeEnum.PAVILION_ROOF;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.DOME_ROOF:
				PredefinedType = IfcRoofTypeEnum.DOME_ROOF;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.FREEFORM:
				PredefinedType = IfcRoofTypeEnum.FREEFORM;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.USERDEFINED:
				PredefinedType = IfcRoofTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcRoofTypeEnum.NOTDEFINED:
				PredefinedType = IfcRoofTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 35)]
	public IfcRoofTypeEnum? PredefinedType
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
			SetValue(delegate(IfcRoofTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 9);
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

	internal IfcRoof(IModel model, int label, bool activated)
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
			_predefinedType = (IfcRoofTypeEnum)Enum.Parse(typeof(IfcRoofTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRoof other)
	{
		return this == other;
	}
}
