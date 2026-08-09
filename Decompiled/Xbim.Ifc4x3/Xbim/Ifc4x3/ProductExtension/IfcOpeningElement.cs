using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;

namespace Xbim.Ifc4x3.ProductExtension;

[ExpressType("IfcOpeningElement", 498)]
public class IfcOpeningElement : IfcFeatureElementSubtraction, IIfcOpeningElement, IIfcFeatureElementSubtraction, IIfcFeatureElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcOpeningElement>
{
	private IfcOpeningElementTypeEnum? _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcOpeningElement), 9)]
	Xbim.Ifc4.Interfaces.IfcOpeningElementTypeEnum? IIfcOpeningElement.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcOpeningElementTypeEnum.OPENING => Xbim.Ifc4.Interfaces.IfcOpeningElementTypeEnum.OPENING, 
				IfcOpeningElementTypeEnum.RECESS => Xbim.Ifc4.Interfaces.IfcOpeningElementTypeEnum.RECESS, 
				IfcOpeningElementTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcOpeningElementTypeEnum.USERDEFINED, 
				IfcOpeningElementTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcOpeningElementTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcOpeningElementTypeEnum.OPENING:
				PredefinedType = IfcOpeningElementTypeEnum.OPENING;
				break;
			case Xbim.Ifc4.Interfaces.IfcOpeningElementTypeEnum.RECESS:
				PredefinedType = IfcOpeningElementTypeEnum.RECESS;
				break;
			case Xbim.Ifc4.Interfaces.IfcOpeningElementTypeEnum.USERDEFINED:
				PredefinedType = IfcOpeningElementTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcOpeningElementTypeEnum.NOTDEFINED:
				PredefinedType = IfcOpeningElementTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	IEnumerable<IIfcRelFillsElement> IIfcOpeningElement.HasFillings => base.Model.Instances.Where((IIfcRelFillsElement e) => e.RelatingOpeningElement as IfcOpeningElement == this, "RelatingOpeningElement", this);

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 36)]
	public IfcOpeningElementTypeEnum? PredefinedType
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
			SetValue(delegate(IfcOpeningElementTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 9);
		}
	}

	[InverseProperty("RelatingOpeningElement")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 37)]
	public IEnumerable<IfcRelFillsElement> HasFillings => base.Model.Instances.Where((IfcRelFillsElement e) => Equals(e.RelatingOpeningElement), "RelatingOpeningElement", this);

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

	internal IfcOpeningElement(IModel model, int label, bool activated)
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
			_predefinedType = (IfcOpeningElementTypeEnum)Enum.Parse(typeof(IfcOpeningElementTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcOpeningElement other)
	{
		return this == other;
	}
}
