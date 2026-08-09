using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.HvacDomain;

[ExpressType("IfcCondenser", 1132)]
public class IfcCondenser : IfcEnergyConversionDevice, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcCondenser>, IIfcCondenser, IIfcEnergyConversionDevice, IIfcDistributionFlowElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect
{
	private IfcCondenserTypeEnum? _predefinedType;

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 37)]
	public IfcCondenserTypeEnum? PredefinedType
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
			SetValue(delegate(IfcCondenserTypeEnum? v)
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

	[CrossSchemaAttribute(typeof(IIfcCondenser), 9)]
	Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum? IIfcCondenser.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcCondenserTypeEnum.AIRCOOLED => Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.AIRCOOLED, 
				IfcCondenserTypeEnum.EVAPORATIVECOOLED => Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.EVAPORATIVECOOLED, 
				IfcCondenserTypeEnum.WATERCOOLED => Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.WATERCOOLED, 
				IfcCondenserTypeEnum.WATERCOOLEDBRAZEDPLATE => Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.WATERCOOLEDBRAZEDPLATE, 
				IfcCondenserTypeEnum.WATERCOOLEDSHELLCOIL => Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.WATERCOOLEDSHELLCOIL, 
				IfcCondenserTypeEnum.WATERCOOLEDSHELLTUBE => Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.WATERCOOLEDSHELLTUBE, 
				IfcCondenserTypeEnum.WATERCOOLEDTUBEINTUBE => Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.WATERCOOLEDTUBEINTUBE, 
				IfcCondenserTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.USERDEFINED, 
				IfcCondenserTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.AIRCOOLED:
				PredefinedType = IfcCondenserTypeEnum.AIRCOOLED;
				break;
			case Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.EVAPORATIVECOOLED:
				PredefinedType = IfcCondenserTypeEnum.EVAPORATIVECOOLED;
				break;
			case Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.WATERCOOLED:
				PredefinedType = IfcCondenserTypeEnum.WATERCOOLED;
				break;
			case Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.WATERCOOLEDBRAZEDPLATE:
				PredefinedType = IfcCondenserTypeEnum.WATERCOOLEDBRAZEDPLATE;
				break;
			case Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.WATERCOOLEDSHELLCOIL:
				PredefinedType = IfcCondenserTypeEnum.WATERCOOLEDSHELLCOIL;
				break;
			case Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.WATERCOOLEDSHELLTUBE:
				PredefinedType = IfcCondenserTypeEnum.WATERCOOLEDSHELLTUBE;
				break;
			case Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.WATERCOOLEDTUBEINTUBE:
				PredefinedType = IfcCondenserTypeEnum.WATERCOOLEDTUBEINTUBE;
				break;
			case Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.USERDEFINED:
				PredefinedType = IfcCondenserTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcCondenserTypeEnum.NOTDEFINED:
				PredefinedType = IfcCondenserTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcCondenser(IModel model, int label, bool activated)
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
			_predefinedType = (IfcCondenserTypeEnum)Enum.Parse(typeof(IfcCondenserTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCondenser other)
	{
		return this == other;
	}
}
