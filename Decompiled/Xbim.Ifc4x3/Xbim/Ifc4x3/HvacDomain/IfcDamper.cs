using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.HvacDomain;

[ExpressType("IfcDamper", 1148)]
public class IfcDamper : IfcFlowController, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcDamper>, IIfcDamper, IIfcFlowController, IIfcDistributionFlowElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect
{
	private IfcDamperTypeEnum? _predefinedType;

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 37)]
	public IfcDamperTypeEnum? PredefinedType
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
			SetValue(delegate(IfcDamperTypeEnum? v)
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

	[CrossSchemaAttribute(typeof(IIfcDamper), 9)]
	Xbim.Ifc4.Interfaces.IfcDamperTypeEnum? IIfcDamper.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcDamperTypeEnum.BACKDRAFTDAMPER => Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.BACKDRAFTDAMPER, 
				IfcDamperTypeEnum.BALANCINGDAMPER => Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.BALANCINGDAMPER, 
				IfcDamperTypeEnum.BLASTDAMPER => Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.BLASTDAMPER, 
				IfcDamperTypeEnum.CONTROLDAMPER => Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.CONTROLDAMPER, 
				IfcDamperTypeEnum.FIREDAMPER => Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.FIREDAMPER, 
				IfcDamperTypeEnum.FIRESMOKEDAMPER => Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.FIRESMOKEDAMPER, 
				IfcDamperTypeEnum.FUMEHOODEXHAUST => Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.FUMEHOODEXHAUST, 
				IfcDamperTypeEnum.GRAVITYDAMPER => Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.GRAVITYDAMPER, 
				IfcDamperTypeEnum.GRAVITYRELIEFDAMPER => Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.GRAVITYRELIEFDAMPER, 
				IfcDamperTypeEnum.RELIEFDAMPER => Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.RELIEFDAMPER, 
				IfcDamperTypeEnum.SMOKEDAMPER => Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.SMOKEDAMPER, 
				IfcDamperTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.USERDEFINED, 
				IfcDamperTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.BACKDRAFTDAMPER:
				PredefinedType = IfcDamperTypeEnum.BACKDRAFTDAMPER;
				break;
			case Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.BALANCINGDAMPER:
				PredefinedType = IfcDamperTypeEnum.BALANCINGDAMPER;
				break;
			case Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.BLASTDAMPER:
				PredefinedType = IfcDamperTypeEnum.BLASTDAMPER;
				break;
			case Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.CONTROLDAMPER:
				PredefinedType = IfcDamperTypeEnum.CONTROLDAMPER;
				break;
			case Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.FIREDAMPER:
				PredefinedType = IfcDamperTypeEnum.FIREDAMPER;
				break;
			case Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.FIRESMOKEDAMPER:
				PredefinedType = IfcDamperTypeEnum.FIRESMOKEDAMPER;
				break;
			case Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.FUMEHOODEXHAUST:
				PredefinedType = IfcDamperTypeEnum.FUMEHOODEXHAUST;
				break;
			case Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.GRAVITYDAMPER:
				PredefinedType = IfcDamperTypeEnum.GRAVITYDAMPER;
				break;
			case Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.GRAVITYRELIEFDAMPER:
				PredefinedType = IfcDamperTypeEnum.GRAVITYRELIEFDAMPER;
				break;
			case Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.RELIEFDAMPER:
				PredefinedType = IfcDamperTypeEnum.RELIEFDAMPER;
				break;
			case Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.SMOKEDAMPER:
				PredefinedType = IfcDamperTypeEnum.SMOKEDAMPER;
				break;
			case Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.USERDEFINED:
				PredefinedType = IfcDamperTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcDamperTypeEnum.NOTDEFINED:
				PredefinedType = IfcDamperTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcDamper(IModel model, int label, bool activated)
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
			_predefinedType = (IfcDamperTypeEnum)Enum.Parse(typeof(IfcDamperTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcDamper other)
	{
		return this == other;
	}
}
