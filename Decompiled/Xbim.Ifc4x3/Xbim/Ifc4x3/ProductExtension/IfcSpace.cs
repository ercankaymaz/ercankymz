using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.ProductExtension;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.MeasureResource;
using Xbim.Ifc4x3.SharedBldgElements;

namespace Xbim.Ifc4x3.ProductExtension;

[ExpressType("IfcSpace", 454)]
public class IfcSpace : IfcSpatialStructureElement, IIfcSpace, IIfcSpatialStructureElement, IIfcSpatialElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect, Xbim.Ifc4.ProductExtension.IfcSpaceBoundarySelect, IIfcSpaceBoundarySelect, IInstantiableEntity, IfcSpaceBoundarySelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcSpace>
{
	private IfcSpaceTypeEnum? _predefinedType;

	private Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure? _elevationWithFlooring;

	[CrossSchemaAttribute(typeof(IIfcSpace), 10)]
	Xbim.Ifc4.Interfaces.IfcSpaceTypeEnum? IIfcSpace.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcSpaceTypeEnum.BERTH => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcSpaceTypeEnum>(), 
				IfcSpaceTypeEnum.EXTERNAL => Xbim.Ifc4.Interfaces.IfcSpaceTypeEnum.EXTERNAL, 
				IfcSpaceTypeEnum.GFA => Xbim.Ifc4.Interfaces.IfcSpaceTypeEnum.GFA, 
				IfcSpaceTypeEnum.INTERNAL => Xbim.Ifc4.Interfaces.IfcSpaceTypeEnum.INTERNAL, 
				IfcSpaceTypeEnum.PARKING => Xbim.Ifc4.Interfaces.IfcSpaceTypeEnum.PARKING, 
				IfcSpaceTypeEnum.SPACE => Xbim.Ifc4.Interfaces.IfcSpaceTypeEnum.SPACE, 
				IfcSpaceTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcSpaceTypeEnum.USERDEFINED, 
				IfcSpaceTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcSpaceTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcSpaceTypeEnum.SPACE:
				PredefinedType = IfcSpaceTypeEnum.SPACE;
				break;
			case Xbim.Ifc4.Interfaces.IfcSpaceTypeEnum.PARKING:
				PredefinedType = IfcSpaceTypeEnum.PARKING;
				break;
			case Xbim.Ifc4.Interfaces.IfcSpaceTypeEnum.GFA:
				PredefinedType = IfcSpaceTypeEnum.GFA;
				break;
			case Xbim.Ifc4.Interfaces.IfcSpaceTypeEnum.INTERNAL:
				PredefinedType = IfcSpaceTypeEnum.INTERNAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcSpaceTypeEnum.EXTERNAL:
				PredefinedType = IfcSpaceTypeEnum.EXTERNAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcSpaceTypeEnum.USERDEFINED:
				PredefinedType = IfcSpaceTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcSpaceTypeEnum.NOTDEFINED:
				PredefinedType = IfcSpaceTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSpace), 11)]
	Xbim.Ifc4.MeasureResource.IfcLengthMeasure? IIfcSpace.ElevationWithFlooring
	{
		get
		{
			if (!ElevationWithFlooring.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(ElevationWithFlooring.Value);
		}
		set
		{
			ElevationWithFlooring = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure?)null));
		}
	}

	IEnumerable<IIfcRelCoversSpaces> IIfcSpace.HasCoverings => base.Model.Instances.Where((IIfcRelCoversSpaces e) => e.RelatingSpace as IfcSpace == this, "RelatingSpace", this);

	IEnumerable<IIfcRelSpaceBoundary> IIfcSpace.BoundedBy => base.Model.Instances.Where((IIfcRelSpaceBoundary e) => e.RelatingSpace as IfcSpace == this, "RelatingSpace", this);

	public IEnumerable<IIfcSpace> Spaces => base.IsDecomposedBy.SelectMany((Xbim.Ifc4x3.Kernel.IfcRelAggregates s) => s.RelatedObjects).OfType<IIfcSpace>();

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 29)]
	public IfcSpaceTypeEnum? PredefinedType
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
			SetValue(delegate(IfcSpaceTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 30)]
	public Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure? ElevationWithFlooring
	{
		get
		{
			if (_activated)
			{
				return _elevationWithFlooring;
			}
			Activate();
			return _elevationWithFlooring;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure? v)
			{
				_elevationWithFlooring = v;
			}, _elevationWithFlooring, value, "ElevationWithFlooring", 11);
		}
	}

	[InverseProperty("RelatingSpace")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 31)]
	public IEnumerable<IfcRelCoversSpaces> HasCoverings => base.Model.Instances.Where((IfcRelCoversSpaces e) => Equals(e.RelatingSpace), "RelatingSpace", this);

	[InverseProperty("RelatingSpace")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 32)]
	public IEnumerable<IfcRelSpaceBoundary> BoundedBy => base.Model.Instances.Where((IfcRelSpaceBoundary e) => Equals(e.RelatingSpace), "RelatingSpace", this);

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

	internal IfcSpace(IModel model, int label, bool activated)
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
			_predefinedType = (IfcSpaceTypeEnum)Enum.Parse(typeof(IfcSpaceTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 10:
			_elevationWithFlooring = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSpace other)
	{
		return this == other;
	}
}
