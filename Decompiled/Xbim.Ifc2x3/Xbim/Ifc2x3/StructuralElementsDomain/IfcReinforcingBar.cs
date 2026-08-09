using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.ProfilePropertyResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.StructuralAnalysisDomain;

namespace Xbim.Ifc2x3.StructuralElementsDomain;

[ExpressType("IfcReinforcingBar", 571)]
public class IfcReinforcingBar : IfcReinforcingElement, IIfcReinforcingBar, IIfcReinforcingElement, IIfcElementComponent, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcReinforcingBar>, IExpressValidatable
{
	public enum IfcReinforcingBarClause
	{
		WR1
	}

	private IfcReinforcingBarTypeEnum? _predefinedType;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure _nominalDiameter;

	private Xbim.Ifc2x3.MeasureResource.IfcAreaMeasure _crossSectionArea;

	private Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? _barLength;

	private Xbim.Ifc2x3.ProfilePropertyResource.IfcReinforcingBarRoleEnum _barRole;

	private Xbim.Ifc2x3.ProfilePropertyResource.IfcReinforcingBarSurfaceEnum? _barSurface;

	[CrossSchemaAttribute(typeof(IIfcReinforcingBar), 10)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcReinforcingBar.NominalDiameter
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(NominalDiameter);
		}
		set
		{
			NominalDiameter = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value.Value) : default(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcReinforcingBar), 11)]
	Xbim.Ifc4.MeasureResource.IfcAreaMeasure? IIfcReinforcingBar.CrossSectionArea
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcAreaMeasure(CrossSectionArea);
		}
		set
		{
			CrossSectionArea = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcAreaMeasure(value.Value) : default(Xbim.Ifc2x3.MeasureResource.IfcAreaMeasure));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcReinforcingBar), 12)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcReinforcingBar.BarLength
	{
		get
		{
			if (!BarLength.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(BarLength.Value);
		}
		set
		{
			BarLength = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcReinforcingBar), 13)]
	IfcReinforcingBarTypeEnum? IIfcReinforcingBar.PredefinedType
	{
		get
		{
			return _predefinedType;
		}
		set
		{
			SetValue(delegate(IfcReinforcingBarTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", -13);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcReinforcingBar), 14)]
	Xbim.Ifc4.Interfaces.IfcReinforcingBarSurfaceEnum? IIfcReinforcingBar.BarSurface
	{
		get
		{
			return BarSurface switch
			{
				Xbim.Ifc2x3.ProfilePropertyResource.IfcReinforcingBarSurfaceEnum.PLAIN => Xbim.Ifc4.Interfaces.IfcReinforcingBarSurfaceEnum.PLAIN, 
				Xbim.Ifc2x3.ProfilePropertyResource.IfcReinforcingBarSurfaceEnum.TEXTURED => Xbim.Ifc4.Interfaces.IfcReinforcingBarSurfaceEnum.TEXTURED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcReinforcingBarSurfaceEnum.PLAIN:
				BarSurface = Xbim.Ifc2x3.ProfilePropertyResource.IfcReinforcingBarSurfaceEnum.PLAIN;
				break;
			case Xbim.Ifc4.Interfaces.IfcReinforcingBarSurfaceEnum.TEXTURED:
				BarSurface = Xbim.Ifc2x3.ProfilePropertyResource.IfcReinforcingBarSurfaceEnum.TEXTURED;
				break;
			case null:
				BarSurface = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 28)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure NominalDiameter
	{
		get
		{
			if (_activated)
			{
				return _nominalDiameter;
			}
			Activate();
			return _nominalDiameter;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure v)
			{
				_nominalDiameter = v;
			}, _nominalDiameter, value, "NominalDiameter", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 29)]
	public Xbim.Ifc2x3.MeasureResource.IfcAreaMeasure CrossSectionArea
	{
		get
		{
			if (_activated)
			{
				return _crossSectionArea;
			}
			Activate();
			return _crossSectionArea;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcAreaMeasure v)
			{
				_crossSectionArea = v;
			}, _crossSectionArea, value, "CrossSectionArea", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 30)]
	public Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? BarLength
	{
		get
		{
			if (_activated)
			{
				return _barLength;
			}
			Activate();
			return _barLength;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_barLength = v;
			}, _barLength, value, "BarLength", 12);
		}
	}

	[EntityAttribute(13, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 31)]
	public Xbim.Ifc2x3.ProfilePropertyResource.IfcReinforcingBarRoleEnum BarRole
	{
		get
		{
			if (_activated)
			{
				return _barRole;
			}
			Activate();
			return _barRole;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.ProfilePropertyResource.IfcReinforcingBarRoleEnum v)
			{
				_barRole = v;
			}, _barRole, value, "BarRole", 13);
		}
	}

	[EntityAttribute(14, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 32)]
	public Xbim.Ifc2x3.ProfilePropertyResource.IfcReinforcingBarSurfaceEnum? BarSurface
	{
		get
		{
			if (_activated)
			{
				return _barSurface;
			}
			Activate();
			return _barSurface;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.ProfilePropertyResource.IfcReinforcingBarSurfaceEnum? v)
			{
				_barSurface = v;
			}, _barSurface, value, "BarSurface", 14);
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

	internal IfcReinforcingBar(IModel model, int label, bool activated)
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
			_nominalDiameter = value.RealVal;
			break;
		case 10:
			_crossSectionArea = value.RealVal;
			break;
		case 11:
			_barLength = value.RealVal;
			break;
		case 12:
			_barRole = (Xbim.Ifc2x3.ProfilePropertyResource.IfcReinforcingBarRoleEnum)Enum.Parse(typeof(Xbim.Ifc2x3.ProfilePropertyResource.IfcReinforcingBarRoleEnum), value.EnumVal, ignoreCase: true);
			break;
		case 13:
			_barSurface = (Xbim.Ifc2x3.ProfilePropertyResource.IfcReinforcingBarSurfaceEnum)Enum.Parse(typeof(Xbim.Ifc2x3.ProfilePropertyResource.IfcReinforcingBarSurfaceEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcReinforcingBar other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcReinforcingBarClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcReinforcingBarClause.WR1)
			{
				result = BarRole != Xbim.Ifc2x3.ProfilePropertyResource.IfcReinforcingBarRoleEnum.USERDEFINED || (BarRole == Xbim.Ifc2x3.ProfilePropertyResource.IfcReinforcingBarRoleEnum.USERDEFINED && Functions.EXISTS(base.ObjectType));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcReinforcingBar>()?.LogError($"Exception thrown evaluating where-clause 'IfcReinforcingBar.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcReinforcingBarClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcReinforcingBar.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
