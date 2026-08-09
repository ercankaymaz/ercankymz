using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.ProductExtension;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.StructuralAnalysisDomain;

[ExpressType("IfcStructuralAnalysisModel", 230)]
public class IfcStructuralAnalysisModel : IfcSystem, IInstantiableEntity, IPersistEntity, IPersist, IIfcStructuralAnalysisModel, IIfcSystem, IIfcGroup, IIfcObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcStructuralAnalysisModel>, IExpressValidatable
{
	public enum IfcStructuralAnalysisModelClause
	{
		HasObjectType
	}

	private IfcAnalysisModelTypeEnum _predefinedType;

	private IfcAxis2Placement3D _orientationOf2DPlane;

	private readonly OptionalItemSet<IfcStructuralLoadGroup> _loadedBy;

	private readonly OptionalItemSet<IfcStructuralResultGroup> _hasResults;

	private IfcObjectPlacement _sharedPlacement;

	IfcAnalysisModelTypeEnum IIfcStructuralAnalysisModel.PredefinedType
	{
		get
		{
			return PredefinedType;
		}
		set
		{
			PredefinedType = value;
		}
	}

	IIfcAxis2Placement3D IIfcStructuralAnalysisModel.OrientationOf2DPlane
	{
		get
		{
			return OrientationOf2DPlane;
		}
		set
		{
			OrientationOf2DPlane = value as IfcAxis2Placement3D;
		}
	}

	IItemSet<IIfcStructuralLoadGroup> IIfcStructuralAnalysisModel.LoadedBy => new ProxyItemSet<IfcStructuralLoadGroup, IIfcStructuralLoadGroup>(LoadedBy);

	IItemSet<IIfcStructuralResultGroup> IIfcStructuralAnalysisModel.HasResults => new ProxyItemSet<IfcStructuralResultGroup, IIfcStructuralResultGroup>(HasResults);

	IIfcObjectPlacement IIfcStructuralAnalysisModel.SharedPlacement
	{
		get
		{
			return SharedPlacement;
		}
		set
		{
			SharedPlacement = value as IfcObjectPlacement;
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcAnalysisModelTypeEnum PredefinedType
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
			SetValue(delegate(IfcAnalysisModelTypeEnum v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 20)]
	public IfcAxis2Placement3D OrientationOf2DPlane
	{
		get
		{
			if (_activated)
			{
				return _orientationOf2DPlane;
			}
			Activate();
			return _orientationOf2DPlane;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcAxis2Placement3D v)
			{
				_orientationOf2DPlane = v;
			}, _orientationOf2DPlane, value, "OrientationOf2DPlane", 7);
		}
	}

	[IndexedProperty]
	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 21)]
	public IOptionalItemSet<IfcStructuralLoadGroup> LoadedBy
	{
		get
		{
			if (_activated)
			{
				return _loadedBy;
			}
			Activate();
			return _loadedBy;
		}
	}

	[IndexedProperty]
	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 22)]
	public IOptionalItemSet<IfcStructuralResultGroup> HasResults
	{
		get
		{
			if (_activated)
			{
				return _hasResults;
			}
			Activate();
			return _hasResults;
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 23)]
	public IfcObjectPlacement SharedPlacement
	{
		get
		{
			if (_activated)
			{
				return _sharedPlacement;
			}
			Activate();
			return _sharedPlacement;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcObjectPlacement v)
			{
				_sharedPlacement = v;
			}, _sharedPlacement, value, "SharedPlacement", 10);
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
			if (OrientationOf2DPlane != null)
			{
				yield return OrientationOf2DPlane;
			}
			foreach (IfcStructuralLoadGroup item in LoadedBy)
			{
				yield return item;
			}
			foreach (IfcStructuralResultGroup hasResult in HasResults)
			{
				yield return hasResult;
			}
			if (SharedPlacement != null)
			{
				yield return SharedPlacement;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcStructuralLoadGroup item in LoadedBy)
			{
				yield return item;
			}
			foreach (IfcStructuralResultGroup hasResult in HasResults)
			{
				yield return hasResult;
			}
		}
	}

	internal IfcStructuralAnalysisModel(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_loadedBy = new OptionalItemSet<IfcStructuralLoadGroup>(this, 0, 8);
		_hasResults = new OptionalItemSet<IfcStructuralResultGroup>(this, 0, 9);
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
			_predefinedType = (IfcAnalysisModelTypeEnum)Enum.Parse(typeof(IfcAnalysisModelTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 6:
			_orientationOf2DPlane = (IfcAxis2Placement3D)value.EntityVal;
			break;
		case 7:
			_loadedBy.InternalAdd((IfcStructuralLoadGroup)value.EntityVal);
			break;
		case 8:
			_hasResults.InternalAdd((IfcStructuralResultGroup)value.EntityVal);
			break;
		case 9:
			_sharedPlacement = (IfcObjectPlacement)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcStructuralAnalysisModel other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcStructuralAnalysisModelClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcStructuralAnalysisModelClause.HasObjectType)
			{
				result = PredefinedType != IfcAnalysisModelTypeEnum.USERDEFINED || Functions.EXISTS(base.ObjectType);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcStructuralAnalysisModel>()?.LogError($"Exception thrown evaluating where-clause 'IfcStructuralAnalysisModel.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcStructuralAnalysisModelClause.HasObjectType))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcStructuralAnalysisModel.HasObjectType",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
