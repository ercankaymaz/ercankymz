using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.SharedComponentElements;

namespace Xbim.Ifc4x3.HvacDomain;

[ExpressType("IfcVibrationIsolator", 1312)]
public class IfcVibrationIsolator : IfcElementComponent, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcVibrationIsolator>, IIfcVibrationIsolator, IIfcElementComponent, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect
{
	private IfcVibrationIsolatorTypeEnum? _predefinedType;

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 35)]
	public IfcVibrationIsolatorTypeEnum? PredefinedType
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
			SetValue(delegate(IfcVibrationIsolatorTypeEnum? v)
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

	[CrossSchemaAttribute(typeof(IIfcVibrationIsolator), 9)]
	Xbim.Ifc4.Interfaces.IfcVibrationIsolatorTypeEnum? IIfcVibrationIsolator.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcVibrationIsolatorTypeEnum.BASE => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcVibrationIsolatorTypeEnum>(), 
				IfcVibrationIsolatorTypeEnum.COMPRESSION => Xbim.Ifc4.Interfaces.IfcVibrationIsolatorTypeEnum.COMPRESSION, 
				IfcVibrationIsolatorTypeEnum.SPRING => Xbim.Ifc4.Interfaces.IfcVibrationIsolatorTypeEnum.SPRING, 
				IfcVibrationIsolatorTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcVibrationIsolatorTypeEnum.USERDEFINED, 
				IfcVibrationIsolatorTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcVibrationIsolatorTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcVibrationIsolatorTypeEnum.COMPRESSION:
				PredefinedType = IfcVibrationIsolatorTypeEnum.COMPRESSION;
				break;
			case Xbim.Ifc4.Interfaces.IfcVibrationIsolatorTypeEnum.SPRING:
				PredefinedType = IfcVibrationIsolatorTypeEnum.SPRING;
				break;
			case Xbim.Ifc4.Interfaces.IfcVibrationIsolatorTypeEnum.USERDEFINED:
				PredefinedType = IfcVibrationIsolatorTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcVibrationIsolatorTypeEnum.NOTDEFINED:
				PredefinedType = IfcVibrationIsolatorTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcVibrationIsolator(IModel model, int label, bool activated)
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
			_predefinedType = (IfcVibrationIsolatorTypeEnum)Enum.Parse(typeof(IfcVibrationIsolatorTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcVibrationIsolator other)
	{
		return this == other;
	}
}
