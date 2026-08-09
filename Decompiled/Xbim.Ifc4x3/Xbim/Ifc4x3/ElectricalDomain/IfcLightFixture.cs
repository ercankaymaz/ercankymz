using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.SharedBldgServiceElements;

namespace Xbim.Ifc4x3.ElectricalDomain;

[ExpressType("IfcLightFixture", 1199)]
public class IfcLightFixture : IfcFlowTerminal, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcLightFixture>, IIfcLightFixture, IIfcFlowTerminal, IIfcDistributionFlowElement, IIfcDistributionElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect
{
	private IfcLightFixtureTypeEnum? _predefinedType;

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 37)]
	public IfcLightFixtureTypeEnum? PredefinedType
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
			SetValue(delegate(IfcLightFixtureTypeEnum? v)
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

	[CrossSchemaAttribute(typeof(IIfcLightFixture), 9)]
	Xbim.Ifc4.Interfaces.IfcLightFixtureTypeEnum? IIfcLightFixture.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcLightFixtureTypeEnum.DIRECTIONSOURCE => Xbim.Ifc4.Interfaces.IfcLightFixtureTypeEnum.DIRECTIONSOURCE, 
				IfcLightFixtureTypeEnum.POINTSOURCE => Xbim.Ifc4.Interfaces.IfcLightFixtureTypeEnum.POINTSOURCE, 
				IfcLightFixtureTypeEnum.SECURITYLIGHTING => Xbim.Ifc4.Interfaces.IfcLightFixtureTypeEnum.SECURITYLIGHTING, 
				IfcLightFixtureTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcLightFixtureTypeEnum.USERDEFINED, 
				IfcLightFixtureTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcLightFixtureTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcLightFixtureTypeEnum.POINTSOURCE:
				PredefinedType = IfcLightFixtureTypeEnum.POINTSOURCE;
				break;
			case Xbim.Ifc4.Interfaces.IfcLightFixtureTypeEnum.DIRECTIONSOURCE:
				PredefinedType = IfcLightFixtureTypeEnum.DIRECTIONSOURCE;
				break;
			case Xbim.Ifc4.Interfaces.IfcLightFixtureTypeEnum.SECURITYLIGHTING:
				PredefinedType = IfcLightFixtureTypeEnum.SECURITYLIGHTING;
				break;
			case Xbim.Ifc4.Interfaces.IfcLightFixtureTypeEnum.USERDEFINED:
				PredefinedType = IfcLightFixtureTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcLightFixtureTypeEnum.NOTDEFINED:
				PredefinedType = IfcLightFixtureTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	internal IfcLightFixture(IModel model, int label, bool activated)
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
			_predefinedType = (IfcLightFixtureTypeEnum)Enum.Parse(typeof(IfcLightFixtureTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcLightFixture other)
	{
		return this == other;
	}
}
