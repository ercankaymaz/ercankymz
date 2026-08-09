using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.HvacDomain;

[ExpressType("IfcCoil", 1124)]
public class IfcCoil : IfcEnergyConversionDevice, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcCoil>, IIfcCoil, IIfcEnergyConversionDevice, IIfcDistributionFlowElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect
{
	private IfcCoilTypeEnum? _predefinedType;

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 37)]
	public IfcCoilTypeEnum? PredefinedType
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
			SetValue(delegate(IfcCoilTypeEnum? v)
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

	[CrossSchemaAttribute(typeof(IIfcCoil), 9)]
	Xbim.Ifc4.Interfaces.IfcCoilTypeEnum? IIfcCoil.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcCoilTypeEnum.DXCOOLINGCOIL => Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.DXCOOLINGCOIL, 
				IfcCoilTypeEnum.ELECTRICHEATINGCOIL => Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.ELECTRICHEATINGCOIL, 
				IfcCoilTypeEnum.GASHEATINGCOIL => Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.GASHEATINGCOIL, 
				IfcCoilTypeEnum.HYDRONICCOIL => Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.HYDRONICCOIL, 
				IfcCoilTypeEnum.STEAMHEATINGCOIL => Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.STEAMHEATINGCOIL, 
				IfcCoilTypeEnum.WATERCOOLINGCOIL => Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.WATERCOOLINGCOIL, 
				IfcCoilTypeEnum.WATERHEATINGCOIL => Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.WATERHEATINGCOIL, 
				IfcCoilTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.USERDEFINED, 
				IfcCoilTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.DXCOOLINGCOIL:
				PredefinedType = IfcCoilTypeEnum.DXCOOLINGCOIL;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.ELECTRICHEATINGCOIL:
				PredefinedType = IfcCoilTypeEnum.ELECTRICHEATINGCOIL;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.GASHEATINGCOIL:
				PredefinedType = IfcCoilTypeEnum.GASHEATINGCOIL;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.HYDRONICCOIL:
				PredefinedType = IfcCoilTypeEnum.HYDRONICCOIL;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.STEAMHEATINGCOIL:
				PredefinedType = IfcCoilTypeEnum.STEAMHEATINGCOIL;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.WATERCOOLINGCOIL:
				PredefinedType = IfcCoilTypeEnum.WATERCOOLINGCOIL;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.WATERHEATINGCOIL:
				PredefinedType = IfcCoilTypeEnum.WATERHEATINGCOIL;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.USERDEFINED:
				PredefinedType = IfcCoilTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcCoilTypeEnum.NOTDEFINED:
				PredefinedType = IfcCoilTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcCoil(IModel model, int label, bool activated)
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
			_predefinedType = (IfcCoilTypeEnum)Enum.Parse(typeof(IfcCoilTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCoil other)
	{
		return this == other;
	}
}
