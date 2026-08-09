using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.ProductExtension;

namespace Xbim.Ifc4x3.StructuralElementsDomain;

[ExpressType("IfcSurfaceFeature", 1287)]
public class IfcSurfaceFeature : IfcFeatureElement, IIfcSurfaceFeature, IIfcFeatureElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcSurfaceFeature>
{
	private IfcSurfaceFeatureTypeEnum? _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcSurfaceFeature), 9)]
	Xbim.Ifc4.Interfaces.IfcSurfaceFeatureTypeEnum? IIfcSurfaceFeature.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcSurfaceFeatureTypeEnum.DEFECT => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcSurfaceFeatureTypeEnum>(), 
				IfcSurfaceFeatureTypeEnum.HATCHMARKING => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcSurfaceFeatureTypeEnum>(), 
				IfcSurfaceFeatureTypeEnum.LINEMARKING => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcSurfaceFeatureTypeEnum>(), 
				IfcSurfaceFeatureTypeEnum.MARK => Xbim.Ifc4.Interfaces.IfcSurfaceFeatureTypeEnum.MARK, 
				IfcSurfaceFeatureTypeEnum.NONSKIDSURFACING => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcSurfaceFeatureTypeEnum>(), 
				IfcSurfaceFeatureTypeEnum.PAVEMENTSURFACEMARKING => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcSurfaceFeatureTypeEnum>(), 
				IfcSurfaceFeatureTypeEnum.RUMBLESTRIP => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcSurfaceFeatureTypeEnum>(), 
				IfcSurfaceFeatureTypeEnum.SYMBOLMARKING => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcSurfaceFeatureTypeEnum>(), 
				IfcSurfaceFeatureTypeEnum.TAG => Xbim.Ifc4.Interfaces.IfcSurfaceFeatureTypeEnum.TAG, 
				IfcSurfaceFeatureTypeEnum.TRANSVERSERUMBLESTRIP => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcSurfaceFeatureTypeEnum>(), 
				IfcSurfaceFeatureTypeEnum.TREATMENT => Xbim.Ifc4.Interfaces.IfcSurfaceFeatureTypeEnum.TREATMENT, 
				IfcSurfaceFeatureTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcSurfaceFeatureTypeEnum.USERDEFINED, 
				IfcSurfaceFeatureTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcSurfaceFeatureTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcSurfaceFeatureTypeEnum.MARK:
				PredefinedType = IfcSurfaceFeatureTypeEnum.MARK;
				break;
			case Xbim.Ifc4.Interfaces.IfcSurfaceFeatureTypeEnum.TAG:
				PredefinedType = IfcSurfaceFeatureTypeEnum.TAG;
				break;
			case Xbim.Ifc4.Interfaces.IfcSurfaceFeatureTypeEnum.TREATMENT:
				PredefinedType = IfcSurfaceFeatureTypeEnum.TREATMENT;
				break;
			case Xbim.Ifc4.Interfaces.IfcSurfaceFeatureTypeEnum.USERDEFINED:
				PredefinedType = IfcSurfaceFeatureTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcSurfaceFeatureTypeEnum.NOTDEFINED:
				PredefinedType = IfcSurfaceFeatureTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 35)]
	public IfcSurfaceFeatureTypeEnum? PredefinedType
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
			SetValue(delegate(IfcSurfaceFeatureTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 9);
		}
	}

	[InverseProperty("RelatedSurfaceFeatures")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, null, null, 36)]
	public IfcRelAdheresToElement AdheresToElement => base.Model.Instances.FirstOrDefault((IfcRelAdheresToElement e) => e.RelatedSurfaceFeatures != null && e.RelatedSurfaceFeatures.Contains(this), "RelatedSurfaceFeatures", this);

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

	internal IfcSurfaceFeature(IModel model, int label, bool activated)
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
			_predefinedType = (IfcSurfaceFeatureTypeEnum)Enum.Parse(typeof(IfcSurfaceFeatureTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSurfaceFeature other)
	{
		return this == other;
	}
}
