using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.ElectricalDomain;

[ExpressType("IfcAudioVisualAppliance", 1099)]
public class IfcAudioVisualAppliance : IfcFlowTerminal, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcAudioVisualAppliance>, IIfcAudioVisualAppliance, IIfcFlowTerminal, IIfcDistributionFlowElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect
{
	private IfcAudioVisualApplianceTypeEnum? _predefinedType;

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 37)]
	public IfcAudioVisualApplianceTypeEnum? PredefinedType
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
			SetValue(delegate(IfcAudioVisualApplianceTypeEnum? v)
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

	[CrossSchemaAttribute(typeof(IIfcAudioVisualAppliance), 9)]
	Xbim.Ifc4.Interfaces.IfcAudioVisualApplianceTypeEnum? IIfcAudioVisualAppliance.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcAudioVisualApplianceTypeEnum.AMPLIFIER => Xbim.Ifc4.Interfaces.IfcAudioVisualApplianceTypeEnum.AMPLIFIER, 
				IfcAudioVisualApplianceTypeEnum.CAMERA => Xbim.Ifc4.Interfaces.IfcAudioVisualApplianceTypeEnum.CAMERA, 
				IfcAudioVisualApplianceTypeEnum.COMMUNICATIONTERMINAL => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcAudioVisualApplianceTypeEnum>(), 
				IfcAudioVisualApplianceTypeEnum.DISPLAY => Xbim.Ifc4.Interfaces.IfcAudioVisualApplianceTypeEnum.DISPLAY, 
				IfcAudioVisualApplianceTypeEnum.MICROPHONE => Xbim.Ifc4.Interfaces.IfcAudioVisualApplianceTypeEnum.MICROPHONE, 
				IfcAudioVisualApplianceTypeEnum.PLAYER => Xbim.Ifc4.Interfaces.IfcAudioVisualApplianceTypeEnum.PLAYER, 
				IfcAudioVisualApplianceTypeEnum.PROJECTOR => Xbim.Ifc4.Interfaces.IfcAudioVisualApplianceTypeEnum.PROJECTOR, 
				IfcAudioVisualApplianceTypeEnum.RECEIVER => Xbim.Ifc4.Interfaces.IfcAudioVisualApplianceTypeEnum.RECEIVER, 
				IfcAudioVisualApplianceTypeEnum.RECORDINGEQUIPMENT => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcAudioVisualApplianceTypeEnum>(), 
				IfcAudioVisualApplianceTypeEnum.SPEAKER => Xbim.Ifc4.Interfaces.IfcAudioVisualApplianceTypeEnum.SPEAKER, 
				IfcAudioVisualApplianceTypeEnum.SWITCHER => Xbim.Ifc4.Interfaces.IfcAudioVisualApplianceTypeEnum.SWITCHER, 
				IfcAudioVisualApplianceTypeEnum.TELEPHONE => Xbim.Ifc4.Interfaces.IfcAudioVisualApplianceTypeEnum.TELEPHONE, 
				IfcAudioVisualApplianceTypeEnum.TUNER => Xbim.Ifc4.Interfaces.IfcAudioVisualApplianceTypeEnum.TUNER, 
				IfcAudioVisualApplianceTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcAudioVisualApplianceTypeEnum.USERDEFINED, 
				IfcAudioVisualApplianceTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcAudioVisualApplianceTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcAudioVisualApplianceTypeEnum.AMPLIFIER:
				PredefinedType = IfcAudioVisualApplianceTypeEnum.AMPLIFIER;
				break;
			case Xbim.Ifc4.Interfaces.IfcAudioVisualApplianceTypeEnum.CAMERA:
				PredefinedType = IfcAudioVisualApplianceTypeEnum.CAMERA;
				break;
			case Xbim.Ifc4.Interfaces.IfcAudioVisualApplianceTypeEnum.DISPLAY:
				PredefinedType = IfcAudioVisualApplianceTypeEnum.DISPLAY;
				break;
			case Xbim.Ifc4.Interfaces.IfcAudioVisualApplianceTypeEnum.MICROPHONE:
				PredefinedType = IfcAudioVisualApplianceTypeEnum.MICROPHONE;
				break;
			case Xbim.Ifc4.Interfaces.IfcAudioVisualApplianceTypeEnum.PLAYER:
				PredefinedType = IfcAudioVisualApplianceTypeEnum.PLAYER;
				break;
			case Xbim.Ifc4.Interfaces.IfcAudioVisualApplianceTypeEnum.PROJECTOR:
				PredefinedType = IfcAudioVisualApplianceTypeEnum.PROJECTOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcAudioVisualApplianceTypeEnum.RECEIVER:
				PredefinedType = IfcAudioVisualApplianceTypeEnum.RECEIVER;
				break;
			case Xbim.Ifc4.Interfaces.IfcAudioVisualApplianceTypeEnum.SPEAKER:
				PredefinedType = IfcAudioVisualApplianceTypeEnum.SPEAKER;
				break;
			case Xbim.Ifc4.Interfaces.IfcAudioVisualApplianceTypeEnum.SWITCHER:
				PredefinedType = IfcAudioVisualApplianceTypeEnum.SWITCHER;
				break;
			case Xbim.Ifc4.Interfaces.IfcAudioVisualApplianceTypeEnum.TELEPHONE:
				PredefinedType = IfcAudioVisualApplianceTypeEnum.TELEPHONE;
				break;
			case Xbim.Ifc4.Interfaces.IfcAudioVisualApplianceTypeEnum.TUNER:
				PredefinedType = IfcAudioVisualApplianceTypeEnum.TUNER;
				break;
			case Xbim.Ifc4.Interfaces.IfcAudioVisualApplianceTypeEnum.USERDEFINED:
				PredefinedType = IfcAudioVisualApplianceTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcAudioVisualApplianceTypeEnum.NOTDEFINED:
				PredefinedType = IfcAudioVisualApplianceTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcAudioVisualAppliance(IModel model, int label, bool activated)
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
			_predefinedType = (IfcAudioVisualApplianceTypeEnum)Enum.Parse(typeof(IfcAudioVisualApplianceTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcAudioVisualAppliance other)
	{
		return this == other;
	}
}
