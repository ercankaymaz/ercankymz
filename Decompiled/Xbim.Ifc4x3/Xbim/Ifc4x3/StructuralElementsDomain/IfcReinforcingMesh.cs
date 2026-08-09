using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.StructuralElementsDomain;

[ExpressType("IfcReinforcingMesh", 531)]
public class IfcReinforcingMesh : IfcReinforcingElement, IIfcReinforcingMesh, IIfcReinforcingElement, IIfcElementComponent, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcReinforcingMesh>
{
	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? _meshLength;

	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? _meshWidth;

	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? _longitudinalBarNominalDiameter;

	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? _transverseBarNominalDiameter;

	private Xbim.Ifc4x3.MeasureResource.IfcAreaMeasure? _longitudinalBarCrossSectionArea;

	private Xbim.Ifc4x3.MeasureResource.IfcAreaMeasure? _transverseBarCrossSectionArea;

	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? _longitudinalBarSpacing;

	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? _transverseBarSpacing;

	private IfcReinforcingMeshTypeEnum? _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcReinforcingMesh), 10)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcReinforcingMesh.MeshLength
	{
		get
		{
			if (!MeshLength.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(MeshLength.Value);
		}
		set
		{
			MeshLength = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcReinforcingMesh), 11)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcReinforcingMesh.MeshWidth
	{
		get
		{
			if (!MeshWidth.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(MeshWidth.Value);
		}
		set
		{
			MeshWidth = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcReinforcingMesh), 12)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcReinforcingMesh.LongitudinalBarNominalDiameter
	{
		get
		{
			if (!LongitudinalBarNominalDiameter.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(LongitudinalBarNominalDiameter.Value);
		}
		set
		{
			LongitudinalBarNominalDiameter = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcReinforcingMesh), 13)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcReinforcingMesh.TransverseBarNominalDiameter
	{
		get
		{
			if (!TransverseBarNominalDiameter.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(TransverseBarNominalDiameter.Value);
		}
		set
		{
			TransverseBarNominalDiameter = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcReinforcingMesh), 14)]
	Xbim.Ifc4.MeasureResource.IfcAreaMeasure? IIfcReinforcingMesh.LongitudinalBarCrossSectionArea
	{
		get
		{
			if (!LongitudinalBarCrossSectionArea.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcAreaMeasure(LongitudinalBarCrossSectionArea.Value);
		}
		set
		{
			LongitudinalBarCrossSectionArea = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcAreaMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcAreaMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcAreaMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcReinforcingMesh), 15)]
	Xbim.Ifc4.MeasureResource.IfcAreaMeasure? IIfcReinforcingMesh.TransverseBarCrossSectionArea
	{
		get
		{
			if (!TransverseBarCrossSectionArea.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcAreaMeasure(TransverseBarCrossSectionArea.Value);
		}
		set
		{
			TransverseBarCrossSectionArea = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcAreaMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcAreaMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcAreaMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcReinforcingMesh), 16)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcReinforcingMesh.LongitudinalBarSpacing
	{
		get
		{
			if (!LongitudinalBarSpacing.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(LongitudinalBarSpacing.Value);
		}
		set
		{
			LongitudinalBarSpacing = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcReinforcingMesh), 17)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcReinforcingMesh.TransverseBarSpacing
	{
		get
		{
			if (!TransverseBarSpacing.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(TransverseBarSpacing.Value);
		}
		set
		{
			TransverseBarSpacing = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcReinforcingMesh), 18)]
	Xbim.Ifc4.Interfaces.IfcReinforcingMeshTypeEnum? IIfcReinforcingMesh.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcReinforcingMeshTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcReinforcingMeshTypeEnum.USERDEFINED, 
				IfcReinforcingMeshTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcReinforcingMeshTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcReinforcingMeshTypeEnum.USERDEFINED:
				PredefinedType = IfcReinforcingMeshTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcReinforcingMeshTypeEnum.NOTDEFINED:
				PredefinedType = IfcReinforcingMeshTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 36)]
	public Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? MeshLength
	{
		get
		{
			if (_activated)
			{
				return _meshLength;
			}
			Activate();
			return _meshLength;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_meshLength = v;
			}, _meshLength, value, "MeshLength", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 37)]
	public Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? MeshWidth
	{
		get
		{
			if (_activated)
			{
				return _meshWidth;
			}
			Activate();
			return _meshWidth;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_meshWidth = v;
			}, _meshWidth, value, "MeshWidth", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 38)]
	public Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? LongitudinalBarNominalDiameter
	{
		get
		{
			if (_activated)
			{
				return _longitudinalBarNominalDiameter;
			}
			Activate();
			return _longitudinalBarNominalDiameter;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_longitudinalBarNominalDiameter = v;
			}, _longitudinalBarNominalDiameter, value, "LongitudinalBarNominalDiameter", 12);
		}
	}

	[EntityAttribute(13, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 39)]
	public Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? TransverseBarNominalDiameter
	{
		get
		{
			if (_activated)
			{
				return _transverseBarNominalDiameter;
			}
			Activate();
			return _transverseBarNominalDiameter;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_transverseBarNominalDiameter = v;
			}, _transverseBarNominalDiameter, value, "TransverseBarNominalDiameter", 13);
		}
	}

	[EntityAttribute(14, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 40)]
	public Xbim.Ifc4x3.MeasureResource.IfcAreaMeasure? LongitudinalBarCrossSectionArea
	{
		get
		{
			if (_activated)
			{
				return _longitudinalBarCrossSectionArea;
			}
			Activate();
			return _longitudinalBarCrossSectionArea;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcAreaMeasure? v)
			{
				_longitudinalBarCrossSectionArea = v;
			}, _longitudinalBarCrossSectionArea, value, "LongitudinalBarCrossSectionArea", 14);
		}
	}

	[EntityAttribute(15, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 41)]
	public Xbim.Ifc4x3.MeasureResource.IfcAreaMeasure? TransverseBarCrossSectionArea
	{
		get
		{
			if (_activated)
			{
				return _transverseBarCrossSectionArea;
			}
			Activate();
			return _transverseBarCrossSectionArea;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcAreaMeasure? v)
			{
				_transverseBarCrossSectionArea = v;
			}, _transverseBarCrossSectionArea, value, "TransverseBarCrossSectionArea", 15);
		}
	}

	[EntityAttribute(16, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 42)]
	public Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? LongitudinalBarSpacing
	{
		get
		{
			if (_activated)
			{
				return _longitudinalBarSpacing;
			}
			Activate();
			return _longitudinalBarSpacing;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_longitudinalBarSpacing = v;
			}, _longitudinalBarSpacing, value, "LongitudinalBarSpacing", 16);
		}
	}

	[EntityAttribute(17, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 43)]
	public Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? TransverseBarSpacing
	{
		get
		{
			if (_activated)
			{
				return _transverseBarSpacing;
			}
			Activate();
			return _transverseBarSpacing;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_transverseBarSpacing = v;
			}, _transverseBarSpacing, value, "TransverseBarSpacing", 17);
		}
	}

	[EntityAttribute(18, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 44)]
	public IfcReinforcingMeshTypeEnum? PredefinedType
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
			SetValue(delegate(IfcReinforcingMeshTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 18);
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

	internal IfcReinforcingMesh(IModel model, int label, bool activated)
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
			_meshLength = value.RealVal;
			break;
		case 10:
			_meshWidth = value.RealVal;
			break;
		case 11:
			_longitudinalBarNominalDiameter = value.RealVal;
			break;
		case 12:
			_transverseBarNominalDiameter = value.RealVal;
			break;
		case 13:
			_longitudinalBarCrossSectionArea = value.RealVal;
			break;
		case 14:
			_transverseBarCrossSectionArea = value.RealVal;
			break;
		case 15:
			_longitudinalBarSpacing = value.RealVal;
			break;
		case 16:
			_transverseBarSpacing = value.RealVal;
			break;
		case 17:
			_predefinedType = (IfcReinforcingMeshTypeEnum)Enum.Parse(typeof(IfcReinforcingMeshTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcReinforcingMesh other)
	{
		return this == other;
	}
}
