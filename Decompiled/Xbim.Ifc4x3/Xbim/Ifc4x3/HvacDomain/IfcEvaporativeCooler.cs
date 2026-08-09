using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.HvacDomain;

[ExpressType("IfcEvaporativeCooler", 1166)]
public class IfcEvaporativeCooler : IfcEnergyConversionDevice, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcEvaporativeCooler>, IIfcEvaporativeCooler, IIfcEnergyConversionDevice, IIfcDistributionFlowElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect
{
	private IfcEvaporativeCoolerTypeEnum? _predefinedType;

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 37)]
	public IfcEvaporativeCoolerTypeEnum? PredefinedType
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
			SetValue(delegate(IfcEvaporativeCoolerTypeEnum? v)
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

	[CrossSchemaAttribute(typeof(IIfcEvaporativeCooler), 9)]
	Xbim.Ifc4.Interfaces.IfcEvaporativeCoolerTypeEnum? IIfcEvaporativeCooler.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcEvaporativeCoolerTypeEnum.DIRECTEVAPORATIVEAIRWASHER => Xbim.Ifc4.Interfaces.IfcEvaporativeCoolerTypeEnum.DIRECTEVAPORATIVEAIRWASHER, 
				IfcEvaporativeCoolerTypeEnum.DIRECTEVAPORATIVEPACKAGEDROTARYAIRCOOLER => Xbim.Ifc4.Interfaces.IfcEvaporativeCoolerTypeEnum.DIRECTEVAPORATIVEPACKAGEDROTARYAIRCOOLER, 
				IfcEvaporativeCoolerTypeEnum.DIRECTEVAPORATIVERANDOMMEDIAAIRCOOLER => Xbim.Ifc4.Interfaces.IfcEvaporativeCoolerTypeEnum.DIRECTEVAPORATIVERANDOMMEDIAAIRCOOLER, 
				IfcEvaporativeCoolerTypeEnum.DIRECTEVAPORATIVERIGIDMEDIAAIRCOOLER => Xbim.Ifc4.Interfaces.IfcEvaporativeCoolerTypeEnum.DIRECTEVAPORATIVERIGIDMEDIAAIRCOOLER, 
				IfcEvaporativeCoolerTypeEnum.DIRECTEVAPORATIVESLINGERSPACKAGEDAIRCOOLER => Xbim.Ifc4.Interfaces.IfcEvaporativeCoolerTypeEnum.DIRECTEVAPORATIVESLINGERSPACKAGEDAIRCOOLER, 
				IfcEvaporativeCoolerTypeEnum.INDIRECTDIRECTCOMBINATION => Xbim.Ifc4.Interfaces.IfcEvaporativeCoolerTypeEnum.INDIRECTDIRECTCOMBINATION, 
				IfcEvaporativeCoolerTypeEnum.INDIRECTEVAPORATIVECOOLINGTOWERORCOILCOOLER => Xbim.Ifc4.Interfaces.IfcEvaporativeCoolerTypeEnum.INDIRECTEVAPORATIVECOOLINGTOWERORCOILCOOLER, 
				IfcEvaporativeCoolerTypeEnum.INDIRECTEVAPORATIVEPACKAGEAIRCOOLER => Xbim.Ifc4.Interfaces.IfcEvaporativeCoolerTypeEnum.INDIRECTEVAPORATIVEPACKAGEAIRCOOLER, 
				IfcEvaporativeCoolerTypeEnum.INDIRECTEVAPORATIVEWETCOIL => Xbim.Ifc4.Interfaces.IfcEvaporativeCoolerTypeEnum.INDIRECTEVAPORATIVEWETCOIL, 
				IfcEvaporativeCoolerTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcEvaporativeCoolerTypeEnum.USERDEFINED, 
				IfcEvaporativeCoolerTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcEvaporativeCoolerTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcEvaporativeCoolerTypeEnum.DIRECTEVAPORATIVERANDOMMEDIAAIRCOOLER:
				PredefinedType = IfcEvaporativeCoolerTypeEnum.DIRECTEVAPORATIVERANDOMMEDIAAIRCOOLER;
				break;
			case Xbim.Ifc4.Interfaces.IfcEvaporativeCoolerTypeEnum.DIRECTEVAPORATIVERIGIDMEDIAAIRCOOLER:
				PredefinedType = IfcEvaporativeCoolerTypeEnum.DIRECTEVAPORATIVERIGIDMEDIAAIRCOOLER;
				break;
			case Xbim.Ifc4.Interfaces.IfcEvaporativeCoolerTypeEnum.DIRECTEVAPORATIVESLINGERSPACKAGEDAIRCOOLER:
				PredefinedType = IfcEvaporativeCoolerTypeEnum.DIRECTEVAPORATIVESLINGERSPACKAGEDAIRCOOLER;
				break;
			case Xbim.Ifc4.Interfaces.IfcEvaporativeCoolerTypeEnum.DIRECTEVAPORATIVEPACKAGEDROTARYAIRCOOLER:
				PredefinedType = IfcEvaporativeCoolerTypeEnum.DIRECTEVAPORATIVEPACKAGEDROTARYAIRCOOLER;
				break;
			case Xbim.Ifc4.Interfaces.IfcEvaporativeCoolerTypeEnum.DIRECTEVAPORATIVEAIRWASHER:
				PredefinedType = IfcEvaporativeCoolerTypeEnum.DIRECTEVAPORATIVEAIRWASHER;
				break;
			case Xbim.Ifc4.Interfaces.IfcEvaporativeCoolerTypeEnum.INDIRECTEVAPORATIVEPACKAGEAIRCOOLER:
				PredefinedType = IfcEvaporativeCoolerTypeEnum.INDIRECTEVAPORATIVEPACKAGEAIRCOOLER;
				break;
			case Xbim.Ifc4.Interfaces.IfcEvaporativeCoolerTypeEnum.INDIRECTEVAPORATIVEWETCOIL:
				PredefinedType = IfcEvaporativeCoolerTypeEnum.INDIRECTEVAPORATIVEWETCOIL;
				break;
			case Xbim.Ifc4.Interfaces.IfcEvaporativeCoolerTypeEnum.INDIRECTEVAPORATIVECOOLINGTOWERORCOILCOOLER:
				PredefinedType = IfcEvaporativeCoolerTypeEnum.INDIRECTEVAPORATIVECOOLINGTOWERORCOILCOOLER;
				break;
			case Xbim.Ifc4.Interfaces.IfcEvaporativeCoolerTypeEnum.INDIRECTDIRECTCOMBINATION:
				PredefinedType = IfcEvaporativeCoolerTypeEnum.INDIRECTDIRECTCOMBINATION;
				break;
			case Xbim.Ifc4.Interfaces.IfcEvaporativeCoolerTypeEnum.USERDEFINED:
				PredefinedType = IfcEvaporativeCoolerTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcEvaporativeCoolerTypeEnum.NOTDEFINED:
				PredefinedType = IfcEvaporativeCoolerTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcEvaporativeCooler(IModel model, int label, bool activated)
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
			_predefinedType = (IfcEvaporativeCoolerTypeEnum)Enum.Parse(typeof(IfcEvaporativeCoolerTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcEvaporativeCooler other)
	{
		return this == other;
	}
}
