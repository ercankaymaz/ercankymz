using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.ProductExtension;

namespace Xbim.Ifc4x3.StructuralElementsDomain;

[ExpressType("IfcVoidingFeature", 1313)]
public class IfcVoidingFeature : IfcFeatureElementSubtraction, IIfcVoidingFeature, IIfcFeatureElementSubtraction, IIfcFeatureElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcVoidingFeature>
{
	private IfcVoidingFeatureTypeEnum? _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcVoidingFeature), 9)]
	Xbim.Ifc4.Interfaces.IfcVoidingFeatureTypeEnum? IIfcVoidingFeature.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcVoidingFeatureTypeEnum.CHAMFER => Xbim.Ifc4.Interfaces.IfcVoidingFeatureTypeEnum.CHAMFER, 
				IfcVoidingFeatureTypeEnum.CUTOUT => Xbim.Ifc4.Interfaces.IfcVoidingFeatureTypeEnum.CUTOUT, 
				IfcVoidingFeatureTypeEnum.EDGE => Xbim.Ifc4.Interfaces.IfcVoidingFeatureTypeEnum.EDGE, 
				IfcVoidingFeatureTypeEnum.HOLE => Xbim.Ifc4.Interfaces.IfcVoidingFeatureTypeEnum.HOLE, 
				IfcVoidingFeatureTypeEnum.MITER => Xbim.Ifc4.Interfaces.IfcVoidingFeatureTypeEnum.MITER, 
				IfcVoidingFeatureTypeEnum.NOTCH => Xbim.Ifc4.Interfaces.IfcVoidingFeatureTypeEnum.NOTCH, 
				IfcVoidingFeatureTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcVoidingFeatureTypeEnum.USERDEFINED, 
				IfcVoidingFeatureTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcVoidingFeatureTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcVoidingFeatureTypeEnum.CUTOUT:
				PredefinedType = IfcVoidingFeatureTypeEnum.CUTOUT;
				break;
			case Xbim.Ifc4.Interfaces.IfcVoidingFeatureTypeEnum.NOTCH:
				PredefinedType = IfcVoidingFeatureTypeEnum.NOTCH;
				break;
			case Xbim.Ifc4.Interfaces.IfcVoidingFeatureTypeEnum.HOLE:
				PredefinedType = IfcVoidingFeatureTypeEnum.HOLE;
				break;
			case Xbim.Ifc4.Interfaces.IfcVoidingFeatureTypeEnum.MITER:
				PredefinedType = IfcVoidingFeatureTypeEnum.MITER;
				break;
			case Xbim.Ifc4.Interfaces.IfcVoidingFeatureTypeEnum.CHAMFER:
				PredefinedType = IfcVoidingFeatureTypeEnum.CHAMFER;
				break;
			case Xbim.Ifc4.Interfaces.IfcVoidingFeatureTypeEnum.EDGE:
				PredefinedType = IfcVoidingFeatureTypeEnum.EDGE;
				break;
			case Xbim.Ifc4.Interfaces.IfcVoidingFeatureTypeEnum.USERDEFINED:
				PredefinedType = IfcVoidingFeatureTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcVoidingFeatureTypeEnum.NOTDEFINED:
				PredefinedType = IfcVoidingFeatureTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 36)]
	public IfcVoidingFeatureTypeEnum? PredefinedType
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
			SetValue(delegate(IfcVoidingFeatureTypeEnum? v)
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

	internal IfcVoidingFeature(IModel model, int label, bool activated)
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
			_predefinedType = (IfcVoidingFeatureTypeEnum)Enum.Parse(typeof(IfcVoidingFeatureTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcVoidingFeature other)
	{
		return this == other;
	}
}
