using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.Kernel;

namespace Xbim.Ifc4x3.ProcessExtension;

[ExpressType("IfcProcedureType", 1228)]
public class IfcProcedureType : Xbim.Ifc4x3.Kernel.IfcTypeProcess, IIfcProcedureType, IIfcTypeProcess, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProcessSelect, IIfcProcessSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcProcedureType>
{
	private IfcProcedureTypeEnum _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcProcedureType), 10)]
	Xbim.Ifc4.Interfaces.IfcProcedureTypeEnum IIfcProcedureType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcProcedureTypeEnum.ADVICE_CAUTION => Xbim.Ifc4.Interfaces.IfcProcedureTypeEnum.ADVICE_CAUTION, 
				IfcProcedureTypeEnum.ADVICE_NOTE => Xbim.Ifc4.Interfaces.IfcProcedureTypeEnum.ADVICE_NOTE, 
				IfcProcedureTypeEnum.ADVICE_WARNING => Xbim.Ifc4.Interfaces.IfcProcedureTypeEnum.ADVICE_WARNING, 
				IfcProcedureTypeEnum.CALIBRATION => Xbim.Ifc4.Interfaces.IfcProcedureTypeEnum.CALIBRATION, 
				IfcProcedureTypeEnum.DIAGNOSTIC => Xbim.Ifc4.Interfaces.IfcProcedureTypeEnum.DIAGNOSTIC, 
				IfcProcedureTypeEnum.SHUTDOWN => Xbim.Ifc4.Interfaces.IfcProcedureTypeEnum.SHUTDOWN, 
				IfcProcedureTypeEnum.STARTUP => Xbim.Ifc4.Interfaces.IfcProcedureTypeEnum.STARTUP, 
				IfcProcedureTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcProcedureTypeEnum.USERDEFINED, 
				IfcProcedureTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcProcedureTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcProcedureTypeEnum.ADVICE_CAUTION:
				PredefinedType = IfcProcedureTypeEnum.ADVICE_CAUTION;
				break;
			case Xbim.Ifc4.Interfaces.IfcProcedureTypeEnum.ADVICE_NOTE:
				PredefinedType = IfcProcedureTypeEnum.ADVICE_NOTE;
				break;
			case Xbim.Ifc4.Interfaces.IfcProcedureTypeEnum.ADVICE_WARNING:
				PredefinedType = IfcProcedureTypeEnum.ADVICE_WARNING;
				break;
			case Xbim.Ifc4.Interfaces.IfcProcedureTypeEnum.CALIBRATION:
				PredefinedType = IfcProcedureTypeEnum.CALIBRATION;
				break;
			case Xbim.Ifc4.Interfaces.IfcProcedureTypeEnum.DIAGNOSTIC:
				PredefinedType = IfcProcedureTypeEnum.DIAGNOSTIC;
				break;
			case Xbim.Ifc4.Interfaces.IfcProcedureTypeEnum.SHUTDOWN:
				PredefinedType = IfcProcedureTypeEnum.SHUTDOWN;
				break;
			case Xbim.Ifc4.Interfaces.IfcProcedureTypeEnum.STARTUP:
				PredefinedType = IfcProcedureTypeEnum.STARTUP;
				break;
			case Xbim.Ifc4.Interfaces.IfcProcedureTypeEnum.USERDEFINED:
				PredefinedType = IfcProcedureTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcProcedureTypeEnum.NOTDEFINED:
				PredefinedType = IfcProcedureTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcProcedureTypeEnum PredefinedType
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
			SetValue(delegate(IfcProcedureTypeEnum v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 10);
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
			foreach (Xbim.Ifc4x3.Kernel.IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
			{
				yield return hasPropertySet;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (Xbim.Ifc4x3.Kernel.IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
			{
				yield return hasPropertySet;
			}
		}
	}

	internal IfcProcedureType(IModel model, int label, bool activated)
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
		case 8:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 9:
			_predefinedType = (IfcProcedureTypeEnum)Enum.Parse(typeof(IfcProcedureTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcProcedureType other)
	{
		return this == other;
	}
}
