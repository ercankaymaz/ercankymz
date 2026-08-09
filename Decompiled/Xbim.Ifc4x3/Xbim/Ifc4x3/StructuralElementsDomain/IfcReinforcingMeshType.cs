using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.StructuralElementsDomain;

[ExpressType("IfcReinforcingMeshType", 1247)]
public class IfcReinforcingMeshType : IfcReinforcingElementType, IIfcReinforcingMeshType, IIfcReinforcingElementType, IIfcElementComponentType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcReinforcingMeshType>
{
	private IItemSet<IIfcBendingParameterSelect> _bendingParametersIfc4;

	private IfcReinforcingMeshTypeEnum _predefinedType;

	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? _meshLength;

	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? _meshWidth;

	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? _longitudinalBarNominalDiameter;

	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? _transverseBarNominalDiameter;

	private Xbim.Ifc4x3.MeasureResource.IfcAreaMeasure? _longitudinalBarCrossSectionArea;

	private Xbim.Ifc4x3.MeasureResource.IfcAreaMeasure? _transverseBarCrossSectionArea;

	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? _longitudinalBarSpacing;

	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? _transverseBarSpacing;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _bendingShapeCode;

	private readonly OptionalItemSet<IfcBendingParameterSelect> _bendingParameters;

	[CrossSchemaAttribute(typeof(IIfcReinforcingMeshType), 10)]
	Xbim.Ifc4.Interfaces.IfcReinforcingMeshTypeEnum IIfcReinforcingMeshType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcReinforcingMeshTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcReinforcingMeshTypeEnum.USERDEFINED, 
				IfcReinforcingMeshTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcReinforcingMeshTypeEnum.NOTDEFINED, 
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
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcReinforcingMeshType), 11)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcReinforcingMeshType.MeshLength
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

	[CrossSchemaAttribute(typeof(IIfcReinforcingMeshType), 12)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcReinforcingMeshType.MeshWidth
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

	[CrossSchemaAttribute(typeof(IIfcReinforcingMeshType), 13)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcReinforcingMeshType.LongitudinalBarNominalDiameter
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

	[CrossSchemaAttribute(typeof(IIfcReinforcingMeshType), 14)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcReinforcingMeshType.TransverseBarNominalDiameter
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

	[CrossSchemaAttribute(typeof(IIfcReinforcingMeshType), 15)]
	Xbim.Ifc4.MeasureResource.IfcAreaMeasure? IIfcReinforcingMeshType.LongitudinalBarCrossSectionArea
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

	[CrossSchemaAttribute(typeof(IIfcReinforcingMeshType), 16)]
	Xbim.Ifc4.MeasureResource.IfcAreaMeasure? IIfcReinforcingMeshType.TransverseBarCrossSectionArea
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

	[CrossSchemaAttribute(typeof(IIfcReinforcingMeshType), 17)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcReinforcingMeshType.LongitudinalBarSpacing
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

	[CrossSchemaAttribute(typeof(IIfcReinforcingMeshType), 18)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcReinforcingMeshType.TransverseBarSpacing
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

	[CrossSchemaAttribute(typeof(IIfcReinforcingMeshType), 19)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcReinforcingMeshType.BendingShapeCode
	{
		get
		{
			if (!BendingShapeCode.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(BendingShapeCode.Value);
		}
		set
		{
			BendingShapeCode = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcReinforcingMeshType), 20)]
	IItemSet<IIfcBendingParameterSelect> IIfcReinforcingMeshType.BendingParameters => _bendingParametersIfc4 ?? (_bendingParametersIfc4 = new ExtendedItemSet<IfcBendingParameterSelect, IIfcBendingParameterSelect>(BendingParameters, new ItemSet<IIfcBendingParameterSelect>(this, 0, -20), BendingParametersToIfc4, BendingParametersToIfc2X3));

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcReinforcingMeshTypeEnum PredefinedType
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
			SetValue(delegate(IfcReinforcingMeshTypeEnum v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 20)]
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
			}, _meshLength, value, "MeshLength", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 21)]
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
			}, _meshWidth, value, "MeshWidth", 12);
		}
	}

	[EntityAttribute(13, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 22)]
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
			}, _longitudinalBarNominalDiameter, value, "LongitudinalBarNominalDiameter", 13);
		}
	}

	[EntityAttribute(14, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 23)]
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
			}, _transverseBarNominalDiameter, value, "TransverseBarNominalDiameter", 14);
		}
	}

	[EntityAttribute(15, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 24)]
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
			}, _longitudinalBarCrossSectionArea, value, "LongitudinalBarCrossSectionArea", 15);
		}
	}

	[EntityAttribute(16, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 25)]
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
			}, _transverseBarCrossSectionArea, value, "TransverseBarCrossSectionArea", 16);
		}
	}

	[EntityAttribute(17, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 26)]
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
			}, _longitudinalBarSpacing, value, "LongitudinalBarSpacing", 17);
		}
	}

	[EntityAttribute(18, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 27)]
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
			}, _transverseBarSpacing, value, "TransverseBarSpacing", 18);
		}
	}

	[EntityAttribute(19, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 28)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? BendingShapeCode
	{
		get
		{
			if (_activated)
			{
				return _bendingShapeCode;
			}
			Activate();
			return _bendingShapeCode;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_bendingShapeCode = v;
			}, _bendingShapeCode, value, "BendingShapeCode", 19);
		}
	}

	[EntityAttribute(20, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 29)]
	public IOptionalItemSet<IfcBendingParameterSelect> BendingParameters
	{
		get
		{
			if (_activated)
			{
				return _bendingParameters;
			}
			Activate();
			return _bendingParameters;
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
			foreach (Xbim.Ifc4x3.Kernel.IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
			{
				yield return hasPropertySet;
			}
			foreach (IfcRepresentationMap representationMap in base.RepresentationMaps)
			{
				yield return representationMap;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (Xbim.Ifc4x3.Kernel.IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
			{
				yield return hasPropertySet;
			}
		}
	}

	private static IIfcBendingParameterSelect BendingParametersToIfc4(IfcBendingParameterSelect member)
	{
		if (member == null)
		{
			return null;
		}
		string name = member.GetType().Name;
		if (!(name == "IfcLengthMeasure"))
		{
			if (name == "IfcPlaneAngleMeasure")
			{
				return new Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure((Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure)(object)member);
			}
			throw new NotSupportedException();
		}
		return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure((Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure)(object)member);
	}

	private static IfcBendingParameterSelect BendingParametersToIfc2X3(IIfcBendingParameterSelect member)
	{
		if (member == null)
		{
			return null;
		}
		string name = member.GetType().Name;
		if (!(name == "IfcLengthMeasure"))
		{
			if (name == "IfcPlaneAngleMeasure")
			{
				return new Xbim.Ifc4x3.MeasureResource.IfcPlaneAngleMeasure((Xbim.Ifc4.MeasureResource.IfcPlaneAngleMeasure)(object)member);
			}
			throw new NotSupportedException();
		}
		return new Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure((Xbim.Ifc4.MeasureResource.IfcLengthMeasure)(object)member);
	}

	internal IfcReinforcingMeshType(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_bendingParameters = new OptionalItemSet<IfcBendingParameterSelect>(this, 0, 20);
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
			_predefinedType = (IfcReinforcingMeshTypeEnum)Enum.Parse(typeof(IfcReinforcingMeshTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 10:
			_meshLength = value.RealVal;
			break;
		case 11:
			_meshWidth = value.RealVal;
			break;
		case 12:
			_longitudinalBarNominalDiameter = value.RealVal;
			break;
		case 13:
			_transverseBarNominalDiameter = value.RealVal;
			break;
		case 14:
			_longitudinalBarCrossSectionArea = value.RealVal;
			break;
		case 15:
			_transverseBarCrossSectionArea = value.RealVal;
			break;
		case 16:
			_longitudinalBarSpacing = value.RealVal;
			break;
		case 17:
			_transverseBarSpacing = value.RealVal;
			break;
		case 18:
			_bendingShapeCode = value.StringVal;
			break;
		case 19:
			_bendingParameters.InternalAdd((IfcBendingParameterSelect)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcReinforcingMeshType other)
	{
		return this == other;
	}
}
