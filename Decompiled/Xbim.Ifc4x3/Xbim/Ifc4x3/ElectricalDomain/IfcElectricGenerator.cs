using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.ElectricalDomain;

[ExpressType("IfcElectricGenerator", 1160)]
public class IfcElectricGenerator : IfcEnergyConversionDevice, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcElectricGenerator>, IIfcElectricGenerator, IIfcEnergyConversionDevice, IIfcDistributionFlowElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect
{
	private IfcElectricGeneratorTypeEnum? _predefinedType;

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 37)]
	public IfcElectricGeneratorTypeEnum? PredefinedType
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
			SetValue(delegate(IfcElectricGeneratorTypeEnum? v)
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

	[CrossSchemaAttribute(typeof(IIfcElectricGenerator), 9)]
	Xbim.Ifc4.Interfaces.IfcElectricGeneratorTypeEnum? IIfcElectricGenerator.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcElectricGeneratorTypeEnum.CHP => Xbim.Ifc4.Interfaces.IfcElectricGeneratorTypeEnum.CHP, 
				IfcElectricGeneratorTypeEnum.ENGINEGENERATOR => Xbim.Ifc4.Interfaces.IfcElectricGeneratorTypeEnum.ENGINEGENERATOR, 
				IfcElectricGeneratorTypeEnum.STANDALONE => Xbim.Ifc4.Interfaces.IfcElectricGeneratorTypeEnum.STANDALONE, 
				IfcElectricGeneratorTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcElectricGeneratorTypeEnum.USERDEFINED, 
				IfcElectricGeneratorTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcElectricGeneratorTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcElectricGeneratorTypeEnum.CHP:
				PredefinedType = IfcElectricGeneratorTypeEnum.CHP;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricGeneratorTypeEnum.ENGINEGENERATOR:
				PredefinedType = IfcElectricGeneratorTypeEnum.ENGINEGENERATOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricGeneratorTypeEnum.STANDALONE:
				PredefinedType = IfcElectricGeneratorTypeEnum.STANDALONE;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricGeneratorTypeEnum.USERDEFINED:
				PredefinedType = IfcElectricGeneratorTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcElectricGeneratorTypeEnum.NOTDEFINED:
				PredefinedType = IfcElectricGeneratorTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcElectricGenerator(IModel model, int label, bool activated)
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
			_predefinedType = (IfcElectricGeneratorTypeEnum)Enum.Parse(typeof(IfcElectricGeneratorTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcElectricGenerator other)
	{
		return this == other;
	}
}
