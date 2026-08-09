using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.ProductExtension;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc2x3.StructuralAnalysisDomain;

[ExpressType("IfcStructuralAnalysisModel", 230)]
public class IfcStructuralAnalysisModel : IfcSystem, IIfcStructuralAnalysisModel, IIfcSystem, IIfcGroup, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcStructuralAnalysisModel>
{
	private IIfcObjectPlacement _sharedPlacement;

	private IfcAnalysisModelTypeEnum _predefinedType;

	private IfcAxis2Placement3D _orientationOf2DPlane;

	private readonly OptionalItemSet<IfcStructuralLoadGroup> _loadedBy;

	private readonly OptionalItemSet<IfcStructuralResultGroup> _hasResults;

	[CrossSchemaAttribute(typeof(IIfcStructuralAnalysisModel), 6)]
	Xbim.Ifc4.Interfaces.IfcAnalysisModelTypeEnum IIfcStructuralAnalysisModel.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcAnalysisModelTypeEnum.IN_PLANE_LOADING_2D => Xbim.Ifc4.Interfaces.IfcAnalysisModelTypeEnum.IN_PLANE_LOADING_2D, 
				IfcAnalysisModelTypeEnum.OUT_PLANE_LOADING_2D => Xbim.Ifc4.Interfaces.IfcAnalysisModelTypeEnum.OUT_PLANE_LOADING_2D, 
				IfcAnalysisModelTypeEnum.LOADING_3D => Xbim.Ifc4.Interfaces.IfcAnalysisModelTypeEnum.LOADING_3D, 
				IfcAnalysisModelTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcAnalysisModelTypeEnum.USERDEFINED, 
				IfcAnalysisModelTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcAnalysisModelTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcAnalysisModelTypeEnum.IN_PLANE_LOADING_2D:
				PredefinedType = IfcAnalysisModelTypeEnum.IN_PLANE_LOADING_2D;
				break;
			case Xbim.Ifc4.Interfaces.IfcAnalysisModelTypeEnum.OUT_PLANE_LOADING_2D:
				PredefinedType = IfcAnalysisModelTypeEnum.OUT_PLANE_LOADING_2D;
				break;
			case Xbim.Ifc4.Interfaces.IfcAnalysisModelTypeEnum.LOADING_3D:
				PredefinedType = IfcAnalysisModelTypeEnum.LOADING_3D;
				break;
			case Xbim.Ifc4.Interfaces.IfcAnalysisModelTypeEnum.USERDEFINED:
				PredefinedType = IfcAnalysisModelTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcAnalysisModelTypeEnum.NOTDEFINED:
				PredefinedType = IfcAnalysisModelTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcStructuralAnalysisModel), 7)]
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

	[CrossSchemaAttribute(typeof(IIfcStructuralAnalysisModel), 8)]
	IItemSet<IIfcStructuralLoadGroup> IIfcStructuralAnalysisModel.LoadedBy => new ProxyItemSet<IfcStructuralLoadGroup, IIfcStructuralLoadGroup>(LoadedBy);

	[CrossSchemaAttribute(typeof(IIfcStructuralAnalysisModel), 9)]
	IItemSet<IIfcStructuralResultGroup> IIfcStructuralAnalysisModel.HasResults => new ProxyItemSet<IfcStructuralResultGroup, IIfcStructuralResultGroup>(HasResults);

	[CrossSchemaAttribute(typeof(IIfcStructuralAnalysisModel), 10)]
	IIfcObjectPlacement IIfcStructuralAnalysisModel.SharedPlacement
	{
		get
		{
			return _sharedPlacement;
		}
		set
		{
			SetValue(delegate(IIfcObjectPlacement v)
			{
				_sharedPlacement = v;
			}, _sharedPlacement, value, "SharedPlacement", -10);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 13)]
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

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 14)]
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
	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 15)]
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
	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 16)]
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
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcStructuralAnalysisModel other)
	{
		return this == other;
	}
}
