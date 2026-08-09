using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.HvacDomain;

[ExpressType("IfcDuctFitting", 1153)]
public class IfcDuctFitting : IfcFlowFitting, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcDuctFitting>, IIfcDuctFitting, IIfcFlowFitting, IIfcDistributionFlowElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect
{
	private IfcDuctFittingTypeEnum? _predefinedType;

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 37)]
	public IfcDuctFittingTypeEnum? PredefinedType
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
			SetValue(delegate(IfcDuctFittingTypeEnum? v)
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

	[CrossSchemaAttribute(typeof(IIfcDuctFitting), 9)]
	Xbim.Ifc4.Interfaces.IfcDuctFittingTypeEnum? IIfcDuctFitting.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcDuctFittingTypeEnum.BEND => Xbim.Ifc4.Interfaces.IfcDuctFittingTypeEnum.BEND, 
				IfcDuctFittingTypeEnum.CONNECTOR => Xbim.Ifc4.Interfaces.IfcDuctFittingTypeEnum.CONNECTOR, 
				IfcDuctFittingTypeEnum.ENTRY => Xbim.Ifc4.Interfaces.IfcDuctFittingTypeEnum.ENTRY, 
				IfcDuctFittingTypeEnum.EXIT => Xbim.Ifc4.Interfaces.IfcDuctFittingTypeEnum.EXIT, 
				IfcDuctFittingTypeEnum.JUNCTION => Xbim.Ifc4.Interfaces.IfcDuctFittingTypeEnum.JUNCTION, 
				IfcDuctFittingTypeEnum.OBSTRUCTION => Xbim.Ifc4.Interfaces.IfcDuctFittingTypeEnum.OBSTRUCTION, 
				IfcDuctFittingTypeEnum.TRANSITION => Xbim.Ifc4.Interfaces.IfcDuctFittingTypeEnum.TRANSITION, 
				IfcDuctFittingTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcDuctFittingTypeEnum.USERDEFINED, 
				IfcDuctFittingTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcDuctFittingTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcDuctFittingTypeEnum.BEND:
				PredefinedType = IfcDuctFittingTypeEnum.BEND;
				break;
			case Xbim.Ifc4.Interfaces.IfcDuctFittingTypeEnum.CONNECTOR:
				PredefinedType = IfcDuctFittingTypeEnum.CONNECTOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcDuctFittingTypeEnum.ENTRY:
				PredefinedType = IfcDuctFittingTypeEnum.ENTRY;
				break;
			case Xbim.Ifc4.Interfaces.IfcDuctFittingTypeEnum.EXIT:
				PredefinedType = IfcDuctFittingTypeEnum.EXIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDuctFittingTypeEnum.JUNCTION:
				PredefinedType = IfcDuctFittingTypeEnum.JUNCTION;
				break;
			case Xbim.Ifc4.Interfaces.IfcDuctFittingTypeEnum.OBSTRUCTION:
				PredefinedType = IfcDuctFittingTypeEnum.OBSTRUCTION;
				break;
			case Xbim.Ifc4.Interfaces.IfcDuctFittingTypeEnum.TRANSITION:
				PredefinedType = IfcDuctFittingTypeEnum.TRANSITION;
				break;
			case Xbim.Ifc4.Interfaces.IfcDuctFittingTypeEnum.USERDEFINED:
				PredefinedType = IfcDuctFittingTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcDuctFittingTypeEnum.NOTDEFINED:
				PredefinedType = IfcDuctFittingTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcDuctFitting(IModel model, int label, bool activated)
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
			_predefinedType = (IfcDuctFittingTypeEnum)Enum.Parse(typeof(IfcDuctFittingTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcDuctFitting other)
	{
		return this == other;
	}
}
