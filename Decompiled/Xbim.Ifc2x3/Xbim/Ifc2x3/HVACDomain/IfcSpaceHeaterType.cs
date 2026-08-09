using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.SharedBldgServiceElements;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.HVACDomain;

[ExpressType("IfcSpaceHeaterType", 59)]
public class IfcSpaceHeaterType : IfcEnergyConversionDeviceType, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcSpaceHeaterType>, IIfcSpaceHeaterType, IIfcFlowTerminalType, IIfcDistributionFlowElementType, IIfcDistributionElementType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IExpressValidatable
{
	public enum IfcSpaceHeaterTypeClause
	{
		WR1
	}

	private IfcSpaceHeaterTypeEnum _predefinedType;

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcSpaceHeaterTypeEnum PredefinedType
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
			SetValue(delegate(IfcSpaceHeaterTypeEnum v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 10);
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
			foreach (Xbim.Ifc2x3.Kernel.IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
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
			foreach (Xbim.Ifc2x3.Kernel.IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
			{
				yield return hasPropertySet;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSpaceHeaterType), 10)]
	Xbim.Ifc4.Interfaces.IfcSpaceHeaterTypeEnum IIfcSpaceHeaterType.PredefinedType
	{
		get
		{
			switch (PredefinedType)
			{
			case IfcSpaceHeaterTypeEnum.SECTIONALRADIATOR:
				return Xbim.Ifc4.Interfaces.IfcSpaceHeaterTypeEnum.USERDEFINED;
			case IfcSpaceHeaterTypeEnum.PANELRADIATOR:
				return Xbim.Ifc4.Interfaces.IfcSpaceHeaterTypeEnum.USERDEFINED;
			case IfcSpaceHeaterTypeEnum.TUBULARRADIATOR:
				return Xbim.Ifc4.Interfaces.IfcSpaceHeaterTypeEnum.USERDEFINED;
			case IfcSpaceHeaterTypeEnum.CONVECTOR:
				return Xbim.Ifc4.Interfaces.IfcSpaceHeaterTypeEnum.CONVECTOR;
			case IfcSpaceHeaterTypeEnum.BASEBOARDHEATER:
				return Xbim.Ifc4.Interfaces.IfcSpaceHeaterTypeEnum.USERDEFINED;
			case IfcSpaceHeaterTypeEnum.FINNEDTUBEUNIT:
				return Xbim.Ifc4.Interfaces.IfcSpaceHeaterTypeEnum.USERDEFINED;
			case IfcSpaceHeaterTypeEnum.UNITHEATER:
				return Xbim.Ifc4.Interfaces.IfcSpaceHeaterTypeEnum.USERDEFINED;
			case IfcSpaceHeaterTypeEnum.USERDEFINED:
			{
				if (base.ElementType.HasValue && Enum.TryParse<Xbim.Ifc4.Interfaces.IfcSpaceHeaterTypeEnum>(base.ElementType.Value, ignoreCase: false, out var result))
				{
					return result;
				}
				return Xbim.Ifc4.Interfaces.IfcSpaceHeaterTypeEnum.USERDEFINED;
			}
			case IfcSpaceHeaterTypeEnum.NOTDEFINED:
				return Xbim.Ifc4.Interfaces.IfcSpaceHeaterTypeEnum.NOTDEFINED;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcSpaceHeaterTypeEnum.CONVECTOR:
				PredefinedType = IfcSpaceHeaterTypeEnum.CONVECTOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcSpaceHeaterTypeEnum.RADIATOR:
				base.ElementType = value.ToString();
				PredefinedType = IfcSpaceHeaterTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcSpaceHeaterTypeEnum.USERDEFINED:
				PredefinedType = IfcSpaceHeaterTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcSpaceHeaterTypeEnum.NOTDEFINED:
				PredefinedType = IfcSpaceHeaterTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcElementType.ElementType
	{
		get
		{
			switch (PredefinedType)
			{
			case IfcSpaceHeaterTypeEnum.BASEBOARDHEATER:
				return new Xbim.Ifc4.MeasureResource.IfcLabel("BASEBOARDHEATER");
			case IfcSpaceHeaterTypeEnum.FINNEDTUBEUNIT:
				return new Xbim.Ifc4.MeasureResource.IfcLabel("FINNEDTUBEUNIT");
			case IfcSpaceHeaterTypeEnum.PANELRADIATOR:
				return new Xbim.Ifc4.MeasureResource.IfcLabel("PANELRADIATOR");
			case IfcSpaceHeaterTypeEnum.SECTIONALRADIATOR:
				return new Xbim.Ifc4.MeasureResource.IfcLabel("SECTIONALRADIATOR");
			case IfcSpaceHeaterTypeEnum.TUBULARRADIATOR:
				return new Xbim.Ifc4.MeasureResource.IfcLabel("TUBULARRADIATOR");
			case IfcSpaceHeaterTypeEnum.UNITHEATER:
				return new Xbim.Ifc4.MeasureResource.IfcLabel("UNITHEATER");
			default:
			{
				Xbim.Ifc4.MeasureResource.IfcLabel value;
				if (!base.ElementType.HasValue)
				{
					value = null;
				}
				else
				{
					Xbim.Ifc2x3.MeasureResource.IfcLabel? elementType = base.ElementType;
					value = new Xbim.Ifc4.MeasureResource.IfcLabel(elementType.HasValue ? ((string)elementType.GetValueOrDefault()) : null);
				}
				return value;
			}
			}
		}
		set
		{
			if (!value.HasValue)
			{
				base.ElementType = null;
				return;
			}
			string text = value.Value.ToString();
			base.ElementType = text;
			switch (text.ToUpperInvariant())
			{
			case "BASEBOARDHEATER":
				PredefinedType = IfcSpaceHeaterTypeEnum.BASEBOARDHEATER;
				base.ElementType = null;
				break;
			case "FINNEDTUBEUNIT":
				PredefinedType = IfcSpaceHeaterTypeEnum.FINNEDTUBEUNIT;
				base.ElementType = null;
				break;
			case "PANELRADIATOR":
				PredefinedType = IfcSpaceHeaterTypeEnum.PANELRADIATOR;
				base.ElementType = null;
				break;
			case "SECTIONALRADIATOR":
				PredefinedType = IfcSpaceHeaterTypeEnum.SECTIONALRADIATOR;
				base.ElementType = null;
				break;
			case "TUBULARRADIATOR":
				PredefinedType = IfcSpaceHeaterTypeEnum.TUBULARRADIATOR;
				base.ElementType = null;
				break;
			case "UNITHEATER":
				PredefinedType = IfcSpaceHeaterTypeEnum.UNITHEATER;
				base.ElementType = null;
				break;
			}
		}
	}

	internal IfcSpaceHeaterType(IModel model, int label, bool activated)
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
			_predefinedType = (IfcSpaceHeaterTypeEnum)Enum.Parse(typeof(IfcSpaceHeaterTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSpaceHeaterType other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcSpaceHeaterTypeClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcSpaceHeaterTypeClause.WR1)
			{
				result = PredefinedType != IfcSpaceHeaterTypeEnum.USERDEFINED || (PredefinedType == IfcSpaceHeaterTypeEnum.USERDEFINED && Functions.EXISTS(base.ElementType));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcSpaceHeaterType>()?.LogError($"Exception thrown evaluating where-clause 'IfcSpaceHeaterType.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcSpaceHeaterTypeClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcSpaceHeaterType.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
