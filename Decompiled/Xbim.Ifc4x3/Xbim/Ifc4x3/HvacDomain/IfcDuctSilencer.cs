using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.HvacDomain;

[ExpressType("IfcDuctSilencer", 1155)]
public class IfcDuctSilencer : IfcFlowTreatmentDevice, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcDuctSilencer>, IIfcDuctSilencer, IIfcFlowTreatmentDevice, IIfcDistributionFlowElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect
{
	private IfcDuctSilencerTypeEnum? _predefinedType;

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 37)]
	public IfcDuctSilencerTypeEnum? PredefinedType
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
			SetValue(delegate(IfcDuctSilencerTypeEnum? v)
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

	[CrossSchemaAttribute(typeof(IIfcDuctSilencer), 9)]
	Xbim.Ifc4.Interfaces.IfcDuctSilencerTypeEnum? IIfcDuctSilencer.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcDuctSilencerTypeEnum.FLATOVAL => Xbim.Ifc4.Interfaces.IfcDuctSilencerTypeEnum.FLATOVAL, 
				IfcDuctSilencerTypeEnum.RECTANGULAR => Xbim.Ifc4.Interfaces.IfcDuctSilencerTypeEnum.RECTANGULAR, 
				IfcDuctSilencerTypeEnum.ROUND => Xbim.Ifc4.Interfaces.IfcDuctSilencerTypeEnum.ROUND, 
				IfcDuctSilencerTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcDuctSilencerTypeEnum.USERDEFINED, 
				IfcDuctSilencerTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcDuctSilencerTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcDuctSilencerTypeEnum.FLATOVAL:
				PredefinedType = IfcDuctSilencerTypeEnum.FLATOVAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcDuctSilencerTypeEnum.RECTANGULAR:
				PredefinedType = IfcDuctSilencerTypeEnum.RECTANGULAR;
				break;
			case Xbim.Ifc4.Interfaces.IfcDuctSilencerTypeEnum.ROUND:
				PredefinedType = IfcDuctSilencerTypeEnum.ROUND;
				break;
			case Xbim.Ifc4.Interfaces.IfcDuctSilencerTypeEnum.USERDEFINED:
				PredefinedType = IfcDuctSilencerTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcDuctSilencerTypeEnum.NOTDEFINED:
				PredefinedType = IfcDuctSilencerTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcDuctSilencer(IModel model, int label, bool activated)
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
			_predefinedType = (IfcDuctSilencerTypeEnum)Enum.Parse(typeof(IfcDuctSilencerTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcDuctSilencer other)
	{
		return this == other;
	}
}
