using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.ElectricalDomain;

[ExpressType("IfcMotorConnection", 1216)]
public class IfcMotorConnection : IfcEnergyConversionDevice, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcMotorConnection>, IIfcMotorConnection, IIfcEnergyConversionDevice, IIfcDistributionFlowElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect
{
	private IfcMotorConnectionTypeEnum? _predefinedType;

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 37)]
	public IfcMotorConnectionTypeEnum? PredefinedType
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
			SetValue(delegate(IfcMotorConnectionTypeEnum? v)
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

	[CrossSchemaAttribute(typeof(IIfcMotorConnection), 9)]
	Xbim.Ifc4.Interfaces.IfcMotorConnectionTypeEnum? IIfcMotorConnection.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcMotorConnectionTypeEnum.BELTDRIVE => Xbim.Ifc4.Interfaces.IfcMotorConnectionTypeEnum.BELTDRIVE, 
				IfcMotorConnectionTypeEnum.COUPLING => Xbim.Ifc4.Interfaces.IfcMotorConnectionTypeEnum.COUPLING, 
				IfcMotorConnectionTypeEnum.DIRECTDRIVE => Xbim.Ifc4.Interfaces.IfcMotorConnectionTypeEnum.DIRECTDRIVE, 
				IfcMotorConnectionTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcMotorConnectionTypeEnum.USERDEFINED, 
				IfcMotorConnectionTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcMotorConnectionTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcMotorConnectionTypeEnum.BELTDRIVE:
				PredefinedType = IfcMotorConnectionTypeEnum.BELTDRIVE;
				break;
			case Xbim.Ifc4.Interfaces.IfcMotorConnectionTypeEnum.COUPLING:
				PredefinedType = IfcMotorConnectionTypeEnum.COUPLING;
				break;
			case Xbim.Ifc4.Interfaces.IfcMotorConnectionTypeEnum.DIRECTDRIVE:
				PredefinedType = IfcMotorConnectionTypeEnum.DIRECTDRIVE;
				break;
			case Xbim.Ifc4.Interfaces.IfcMotorConnectionTypeEnum.USERDEFINED:
				PredefinedType = IfcMotorConnectionTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcMotorConnectionTypeEnum.NOTDEFINED:
				PredefinedType = IfcMotorConnectionTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcMotorConnection(IModel model, int label, bool activated)
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
			_predefinedType = (IfcMotorConnectionTypeEnum)Enum.Parse(typeof(IfcMotorConnectionTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcMotorConnection other)
	{
		return this == other;
	}
}
