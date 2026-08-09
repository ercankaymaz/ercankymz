using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.StructuralAnalysisDomain;

[ExpressType("IfcStructuralResultGroup", 532)]
public class IfcStructuralResultGroup : Xbim.Ifc4x3.Kernel.IfcGroup, IIfcStructuralResultGroup, IIfcGroup, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcStructuralResultGroup>
{
	private IfcAnalysisTheoryTypeEnum _theoryType;

	private IfcStructuralLoadGroup _resultForLoadGroup;

	private Xbim.Ifc4x3.MeasureResource.IfcBoolean _isLinear;

	[CrossSchemaAttribute(typeof(IIfcStructuralResultGroup), 6)]
	Xbim.Ifc4.Interfaces.IfcAnalysisTheoryTypeEnum IIfcStructuralResultGroup.TheoryType
	{
		get
		{
			return TheoryType switch
			{
				IfcAnalysisTheoryTypeEnum.FIRST_ORDER_THEORY => Xbim.Ifc4.Interfaces.IfcAnalysisTheoryTypeEnum.FIRST_ORDER_THEORY, 
				IfcAnalysisTheoryTypeEnum.FULL_NONLINEAR_THEORY => Xbim.Ifc4.Interfaces.IfcAnalysisTheoryTypeEnum.FULL_NONLINEAR_THEORY, 
				IfcAnalysisTheoryTypeEnum.SECOND_ORDER_THEORY => Xbim.Ifc4.Interfaces.IfcAnalysisTheoryTypeEnum.SECOND_ORDER_THEORY, 
				IfcAnalysisTheoryTypeEnum.THIRD_ORDER_THEORY => Xbim.Ifc4.Interfaces.IfcAnalysisTheoryTypeEnum.THIRD_ORDER_THEORY, 
				IfcAnalysisTheoryTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcAnalysisTheoryTypeEnum.USERDEFINED, 
				IfcAnalysisTheoryTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcAnalysisTheoryTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcAnalysisTheoryTypeEnum.FIRST_ORDER_THEORY:
				TheoryType = IfcAnalysisTheoryTypeEnum.FIRST_ORDER_THEORY;
				break;
			case Xbim.Ifc4.Interfaces.IfcAnalysisTheoryTypeEnum.SECOND_ORDER_THEORY:
				TheoryType = IfcAnalysisTheoryTypeEnum.SECOND_ORDER_THEORY;
				break;
			case Xbim.Ifc4.Interfaces.IfcAnalysisTheoryTypeEnum.THIRD_ORDER_THEORY:
				TheoryType = IfcAnalysisTheoryTypeEnum.THIRD_ORDER_THEORY;
				break;
			case Xbim.Ifc4.Interfaces.IfcAnalysisTheoryTypeEnum.FULL_NONLINEAR_THEORY:
				TheoryType = IfcAnalysisTheoryTypeEnum.FULL_NONLINEAR_THEORY;
				break;
			case Xbim.Ifc4.Interfaces.IfcAnalysisTheoryTypeEnum.USERDEFINED:
				TheoryType = IfcAnalysisTheoryTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcAnalysisTheoryTypeEnum.NOTDEFINED:
				TheoryType = IfcAnalysisTheoryTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcStructuralResultGroup), 7)]
	IIfcStructuralLoadGroup IIfcStructuralResultGroup.ResultForLoadGroup
	{
		get
		{
			return ResultForLoadGroup;
		}
		set
		{
			ResultForLoadGroup = value as IfcStructuralLoadGroup;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcStructuralResultGroup), 8)]
	Xbim.Ifc4.MeasureResource.IfcBoolean IIfcStructuralResultGroup.IsLinear
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcBoolean(IsLinear);
		}
		set
		{
			IsLinear = new Xbim.Ifc4x3.MeasureResource.IfcBoolean(value);
		}
	}

	IEnumerable<IIfcStructuralAnalysisModel> IIfcStructuralResultGroup.ResultGroupFor => base.Model.Instances.Where((IIfcStructuralAnalysisModel e) => e.HasResults != null && e.HasResults.Contains(this), "HasResults", this);

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcAnalysisTheoryTypeEnum TheoryType
	{
		get
		{
			if (_activated)
			{
				return _theoryType;
			}
			Activate();
			return _theoryType;
		}
		set
		{
			SetValue(delegate(IfcAnalysisTheoryTypeEnum v)
			{
				_theoryType = v;
			}, _theoryType, value, "TheoryType", 6);
		}
	}

	[IndexedProperty]
	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 20)]
	public IfcStructuralLoadGroup ResultForLoadGroup
	{
		get
		{
			if (_activated)
			{
				return _resultForLoadGroup;
			}
			Activate();
			return _resultForLoadGroup;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcStructuralLoadGroup v)
			{
				_resultForLoadGroup = v;
			}, _resultForLoadGroup, value, "ResultForLoadGroup", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 21)]
	public Xbim.Ifc4x3.MeasureResource.IfcBoolean IsLinear
	{
		get
		{
			if (_activated)
			{
				return _isLinear;
			}
			Activate();
			return _isLinear;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcBoolean v)
			{
				_isLinear = v;
			}, _isLinear, value, "IsLinear", 8);
		}
	}

	[InverseProperty("HasResults")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 22)]
	public IEnumerable<IfcStructuralAnalysisModel> ResultGroupFor => base.Model.Instances.Where((IfcStructuralAnalysisModel e) => e.HasResults != null && e.HasResults.Contains(this), "HasResults", this);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.OwnerHistory != null)
			{
				yield return base.OwnerHistory;
			}
			if (ResultForLoadGroup != null)
			{
				yield return ResultForLoadGroup;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (ResultForLoadGroup != null)
			{
				yield return ResultForLoadGroup;
			}
		}
	}

	internal IfcStructuralResultGroup(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 5:
			_theoryType = (IfcAnalysisTheoryTypeEnum)Enum.Parse(typeof(IfcAnalysisTheoryTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 6:
			_resultForLoadGroup = (IfcStructuralLoadGroup)value.EntityVal;
			break;
		case 7:
			_isLinear = value.BooleanVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcStructuralResultGroup other)
	{
		return this == other;
	}
}
