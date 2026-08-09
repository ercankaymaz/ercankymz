using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;

namespace Xbim.Ifc4x3.SharedBldgServiceElements;

[ExpressType("IfcDistributionChamberElement", 180)]
public class IfcDistributionChamberElement : IfcDistributionFlowElement, IIfcDistributionChamberElement, IIfcDistributionFlowElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcDistributionChamberElement>
{
	private IfcDistributionChamberElementTypeEnum? _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcDistributionChamberElement), 9)]
	Xbim.Ifc4.Interfaces.IfcDistributionChamberElementTypeEnum? IIfcDistributionChamberElement.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcDistributionChamberElementTypeEnum.FORMEDDUCT => Xbim.Ifc4.Interfaces.IfcDistributionChamberElementTypeEnum.FORMEDDUCT, 
				IfcDistributionChamberElementTypeEnum.INSPECTIONCHAMBER => Xbim.Ifc4.Interfaces.IfcDistributionChamberElementTypeEnum.INSPECTIONCHAMBER, 
				IfcDistributionChamberElementTypeEnum.INSPECTIONPIT => Xbim.Ifc4.Interfaces.IfcDistributionChamberElementTypeEnum.INSPECTIONPIT, 
				IfcDistributionChamberElementTypeEnum.MANHOLE => Xbim.Ifc4.Interfaces.IfcDistributionChamberElementTypeEnum.MANHOLE, 
				IfcDistributionChamberElementTypeEnum.METERCHAMBER => Xbim.Ifc4.Interfaces.IfcDistributionChamberElementTypeEnum.METERCHAMBER, 
				IfcDistributionChamberElementTypeEnum.SUMP => Xbim.Ifc4.Interfaces.IfcDistributionChamberElementTypeEnum.SUMP, 
				IfcDistributionChamberElementTypeEnum.TRENCH => Xbim.Ifc4.Interfaces.IfcDistributionChamberElementTypeEnum.TRENCH, 
				IfcDistributionChamberElementTypeEnum.VALVECHAMBER => Xbim.Ifc4.Interfaces.IfcDistributionChamberElementTypeEnum.VALVECHAMBER, 
				IfcDistributionChamberElementTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcDistributionChamberElementTypeEnum.USERDEFINED, 
				IfcDistributionChamberElementTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcDistributionChamberElementTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcDistributionChamberElementTypeEnum.FORMEDDUCT:
				PredefinedType = IfcDistributionChamberElementTypeEnum.FORMEDDUCT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionChamberElementTypeEnum.INSPECTIONCHAMBER:
				PredefinedType = IfcDistributionChamberElementTypeEnum.INSPECTIONCHAMBER;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionChamberElementTypeEnum.INSPECTIONPIT:
				PredefinedType = IfcDistributionChamberElementTypeEnum.INSPECTIONPIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionChamberElementTypeEnum.MANHOLE:
				PredefinedType = IfcDistributionChamberElementTypeEnum.MANHOLE;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionChamberElementTypeEnum.METERCHAMBER:
				PredefinedType = IfcDistributionChamberElementTypeEnum.METERCHAMBER;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionChamberElementTypeEnum.SUMP:
				PredefinedType = IfcDistributionChamberElementTypeEnum.SUMP;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionChamberElementTypeEnum.TRENCH:
				PredefinedType = IfcDistributionChamberElementTypeEnum.TRENCH;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionChamberElementTypeEnum.VALVECHAMBER:
				PredefinedType = IfcDistributionChamberElementTypeEnum.VALVECHAMBER;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionChamberElementTypeEnum.USERDEFINED:
				PredefinedType = IfcDistributionChamberElementTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcDistributionChamberElementTypeEnum.NOTDEFINED:
				PredefinedType = IfcDistributionChamberElementTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 37)]
	public IfcDistributionChamberElementTypeEnum? PredefinedType
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
			SetValue(delegate(IfcDistributionChamberElementTypeEnum? v)
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

	internal IfcDistributionChamberElement(IModel model, int label, bool activated)
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
			_predefinedType = (IfcDistributionChamberElementTypeEnum)Enum.Parse(typeof(IfcDistributionChamberElementTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcDistributionChamberElement other)
	{
		return this == other;
	}
}
