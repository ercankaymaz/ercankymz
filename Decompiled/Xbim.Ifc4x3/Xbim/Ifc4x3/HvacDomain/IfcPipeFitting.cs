using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.HvacDomain;

[ExpressType("IfcPipeFitting", 1222)]
public class IfcPipeFitting : IfcFlowFitting, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcPipeFitting>, IIfcPipeFitting, IIfcFlowFitting, IIfcDistributionFlowElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect
{
	private IfcPipeFittingTypeEnum? _predefinedType;

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 37)]
	public IfcPipeFittingTypeEnum? PredefinedType
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
			SetValue(delegate(IfcPipeFittingTypeEnum? v)
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

	[CrossSchemaAttribute(typeof(IIfcPipeFitting), 9)]
	Xbim.Ifc4.Interfaces.IfcPipeFittingTypeEnum? IIfcPipeFitting.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcPipeFittingTypeEnum.BEND => Xbim.Ifc4.Interfaces.IfcPipeFittingTypeEnum.BEND, 
				IfcPipeFittingTypeEnum.CONNECTOR => Xbim.Ifc4.Interfaces.IfcPipeFittingTypeEnum.CONNECTOR, 
				IfcPipeFittingTypeEnum.ENTRY => Xbim.Ifc4.Interfaces.IfcPipeFittingTypeEnum.ENTRY, 
				IfcPipeFittingTypeEnum.EXIT => Xbim.Ifc4.Interfaces.IfcPipeFittingTypeEnum.EXIT, 
				IfcPipeFittingTypeEnum.JUNCTION => Xbim.Ifc4.Interfaces.IfcPipeFittingTypeEnum.JUNCTION, 
				IfcPipeFittingTypeEnum.OBSTRUCTION => Xbim.Ifc4.Interfaces.IfcPipeFittingTypeEnum.OBSTRUCTION, 
				IfcPipeFittingTypeEnum.TRANSITION => Xbim.Ifc4.Interfaces.IfcPipeFittingTypeEnum.TRANSITION, 
				IfcPipeFittingTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcPipeFittingTypeEnum.USERDEFINED, 
				IfcPipeFittingTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcPipeFittingTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcPipeFittingTypeEnum.BEND:
				PredefinedType = IfcPipeFittingTypeEnum.BEND;
				break;
			case Xbim.Ifc4.Interfaces.IfcPipeFittingTypeEnum.CONNECTOR:
				PredefinedType = IfcPipeFittingTypeEnum.CONNECTOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcPipeFittingTypeEnum.ENTRY:
				PredefinedType = IfcPipeFittingTypeEnum.ENTRY;
				break;
			case Xbim.Ifc4.Interfaces.IfcPipeFittingTypeEnum.EXIT:
				PredefinedType = IfcPipeFittingTypeEnum.EXIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcPipeFittingTypeEnum.JUNCTION:
				PredefinedType = IfcPipeFittingTypeEnum.JUNCTION;
				break;
			case Xbim.Ifc4.Interfaces.IfcPipeFittingTypeEnum.OBSTRUCTION:
				PredefinedType = IfcPipeFittingTypeEnum.OBSTRUCTION;
				break;
			case Xbim.Ifc4.Interfaces.IfcPipeFittingTypeEnum.TRANSITION:
				PredefinedType = IfcPipeFittingTypeEnum.TRANSITION;
				break;
			case Xbim.Ifc4.Interfaces.IfcPipeFittingTypeEnum.USERDEFINED:
				PredefinedType = IfcPipeFittingTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcPipeFittingTypeEnum.NOTDEFINED:
				PredefinedType = IfcPipeFittingTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcPipeFitting(IModel model, int label, bool activated)
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
			_predefinedType = (IfcPipeFittingTypeEnum)Enum.Parse(typeof(IfcPipeFittingTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPipeFitting other)
	{
		return this == other;
	}
}
