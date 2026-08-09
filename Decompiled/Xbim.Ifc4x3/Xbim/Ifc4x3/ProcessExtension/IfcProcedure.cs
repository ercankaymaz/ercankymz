using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.Kernel;

namespace Xbim.Ifc4x3.ProcessExtension;

[ExpressType("IfcProcedure", 294)]
public class IfcProcedure : Xbim.Ifc4x3.Kernel.IfcProcess, IIfcProcedure, IIfcProcess, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProcessSelect, IIfcProcessSelect, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcProcedure>
{
	private IfcProcedureTypeEnum? _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcProcedure), 8)]
	Xbim.Ifc4.Interfaces.IfcProcedureTypeEnum? IIfcProcedure.PredefinedType
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
				null => null, 
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
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 22)]
	public IfcProcedureTypeEnum? PredefinedType
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
			SetValue(delegate(IfcProcedureTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 8);
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
		}
	}

	internal IfcProcedure(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 7:
			_predefinedType = (IfcProcedureTypeEnum)Enum.Parse(typeof(IfcProcedureTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcProcedure other)
	{
		return this == other;
	}
}
