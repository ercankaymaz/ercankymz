using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.ProductExtension;
using Xbim.Ifc2x3.RepresentationResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.Kernel;

[ExpressType("IfcProject", 204)]
public class IfcProject : IfcObject, IIfcProject, IIfcContext, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcProject>, IExpressValidatable
{
	public enum IfcProjectClause
	{
		WR31,
		WR32,
		WR33
	}

	private Xbim.Ifc2x3.MeasureResource.IfcLabel? _longName;

	private Xbim.Ifc2x3.MeasureResource.IfcLabel? _phase;

	private readonly ItemSet<IfcRepresentationContext> _representationContexts;

	private Xbim.Ifc2x3.MeasureResource.IfcUnitAssignment _unitsInContext;

	[CrossSchemaAttribute(typeof(IIfcProject), 5)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcContext.ObjectType
	{
		get
		{
			if (!base.ObjectType.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(base.ObjectType.Value);
		}
		set
		{
			base.ObjectType = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcProject), 6)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcContext.LongName
	{
		get
		{
			if (!LongName.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(LongName.Value);
		}
		set
		{
			LongName = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcProject), 7)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcContext.Phase
	{
		get
		{
			if (!Phase.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Phase.Value);
		}
		set
		{
			Phase = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcProject), 8)]
	IItemSet<IIfcRepresentationContext> IIfcContext.RepresentationContexts => new ProxyItemSet<IfcRepresentationContext, IIfcRepresentationContext>(RepresentationContexts);

	[CrossSchemaAttribute(typeof(IIfcProject), 9)]
	IIfcUnitAssignment IIfcContext.UnitsInContext
	{
		get
		{
			return UnitsInContext;
		}
		set
		{
			UnitsInContext = value as Xbim.Ifc2x3.MeasureResource.IfcUnitAssignment;
		}
	}

	IEnumerable<IIfcRelDefinesByProperties> IIfcContext.IsDefinedBy => base.Model.Instances.Where((IIfcRelDefinesByProperties e) => e.RelatedObjects != null && e.RelatedObjects.Contains(this), "RelatedObjects", this);

	IEnumerable<IIfcRelDeclares> IIfcContext.Declares => base.Model.Instances.Where((IIfcRelDeclares e) => e.RelatingContext as IfcProject == this, "RelatingContext", this);

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 11)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel? LongName
	{
		get
		{
			if (_activated)
			{
				return _longName;
			}
			Activate();
			return _longName;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel? v)
			{
				_longName = v;
			}, _longName, value, "LongName", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 12)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel? Phase
	{
		get
		{
			if (_activated)
			{
				return _phase;
			}
			Activate();
			return _phase;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel? v)
			{
				_phase = v;
			}, _phase, value, "Phase", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 13)]
	public IItemSet<IfcRepresentationContext> RepresentationContexts
	{
		get
		{
			if (_activated)
			{
				return _representationContexts;
			}
			Activate();
			return _representationContexts;
		}
	}

	[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 14)]
	public Xbim.Ifc2x3.MeasureResource.IfcUnitAssignment UnitsInContext
	{
		get
		{
			if (_activated)
			{
				return _unitsInContext;
			}
			Activate();
			return _unitsInContext;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcUnitAssignment v)
			{
				_unitsInContext = v;
			}, _unitsInContext, value, "UnitsInContext", 9);
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
			foreach (IfcRepresentationContext representationContext in RepresentationContexts)
			{
				yield return representationContext;
			}
			if (UnitsInContext != null)
			{
				yield return UnitsInContext;
			}
		}
	}

	public IfcGeometricRepresentationContext ModelContext => RepresentationContexts.FirstOrDefault((IfcGeometricRepresentationContext r) => r.ContextType == (Xbim.Ifc2x3.MeasureResource.IfcLabel?)(Xbim.Ifc2x3.MeasureResource.IfcLabel)"Model");

	public IEnumerable<IIfcBuilding> Buildings
	{
		get
		{
			IEnumerable<IfcRelAggregates> enumerable = base.IsDecomposedBy.OfType<IfcRelAggregates>();
			foreach (IfcRelAggregates item in enumerable)
			{
				foreach (IfcObjectDefinition definition in item.RelatedObjects)
				{
					IfcSite ifcSite = definition as IfcSite;
					if (ifcSite != null)
					{
						foreach (IIfcBuilding building in ifcSite.Buildings)
						{
							yield return building;
						}
					}
					if (definition is IfcBuilding)
					{
						yield return definition as IfcBuilding;
					}
				}
			}
		}
	}

	public IEnumerable<IIfcSpatialStructureElement> SpatialStructuralElements => base.IsDecomposedBy.OfType<IfcRelAggregates>().SelectMany((IfcRelAggregates rel) => rel.RelatedObjects.OfType<IfcSpatialStructureElement>());

	public Xbim.Ifc2x3.MeasureResource.IfcNamedUnit AreaUnit => UnitsInContext.AreaUnit;

	public IfcGeometricRepresentationContext PlanContext => RepresentationContexts.FirstOrDefault((IfcGeometricRepresentationContext r) => r.ContextType == (Xbim.Ifc2x3.MeasureResource.IfcLabel?)(Xbim.Ifc2x3.MeasureResource.IfcLabel)"Plan");

	public IEnumerable<IIfcSite> Sites => from rel in base.IsDecomposedBy.OfType<IfcRelAggregates>()
		from definition in rel.RelatedObjects.OfType<IfcSite>()
		select definition;

	internal IfcProject(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_representationContexts = new ItemSet<IfcRepresentationContext>(this, 0, 8);
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
			_longName = value.StringVal;
			break;
		case 6:
			_phase = value.StringVal;
			break;
		case 7:
			_representationContexts.InternalAdd((IfcRepresentationContext)value.EntityVal);
			break;
		case 8:
			_unitsInContext = (Xbim.Ifc2x3.MeasureResource.IfcUnitAssignment)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcProject other)
	{
		return this == other;
	}

	public void Initialize(ProjectUnits units)
	{
		IModel model = base.Model;
		Xbim.Ifc2x3.MeasureResource.IfcUnitAssignment ifcUnitAssignment = model.Instances.New<Xbim.Ifc2x3.MeasureResource.IfcUnitAssignment>();
		switch (units)
		{
		case ProjectUnits.SIUnitsUK:
			ifcUnitAssignment.SetOrChangeSiUnit(Xbim.Ifc2x3.MeasureResource.IfcUnitEnum.LENGTHUNIT, Xbim.Ifc2x3.MeasureResource.IfcSIUnitName.METRE, Xbim.Ifc2x3.MeasureResource.IfcSIPrefix.MILLI);
			ifcUnitAssignment.SetOrChangeSiUnit(Xbim.Ifc2x3.MeasureResource.IfcUnitEnum.AREAUNIT, Xbim.Ifc2x3.MeasureResource.IfcSIUnitName.SQUARE_METRE, null);
			ifcUnitAssignment.SetOrChangeSiUnit(Xbim.Ifc2x3.MeasureResource.IfcUnitEnum.VOLUMEUNIT, Xbim.Ifc2x3.MeasureResource.IfcSIUnitName.CUBIC_METRE, null);
			ifcUnitAssignment.SetOrChangeSiUnit(Xbim.Ifc2x3.MeasureResource.IfcUnitEnum.MASSUNIT, Xbim.Ifc2x3.MeasureResource.IfcSIUnitName.GRAM, Xbim.Ifc2x3.MeasureResource.IfcSIPrefix.KILO);
			break;
		case ProjectUnits.ImperialUnits:
		case ProjectUnits.USCustomaryUnits:
			ifcUnitAssignment.SetOrChangeConversionUnit(Xbim.Ifc2x3.MeasureResource.IfcUnitEnum.LENGTHUNIT, Xbim.Ifc2x3.MeasureResource.ConversionBasedUnit.Foot);
			ifcUnitAssignment.SetOrChangeConversionUnit(Xbim.Ifc2x3.MeasureResource.IfcUnitEnum.AREAUNIT, Xbim.Ifc2x3.MeasureResource.ConversionBasedUnit.SquareFoot);
			ifcUnitAssignment.SetOrChangeConversionUnit(Xbim.Ifc2x3.MeasureResource.IfcUnitEnum.VOLUMEUNIT, Xbim.Ifc2x3.MeasureResource.ConversionBasedUnit.CubicFoot);
			ifcUnitAssignment.SetOrChangeConversionUnit(Xbim.Ifc2x3.MeasureResource.IfcUnitEnum.MASSUNIT, Xbim.Ifc2x3.MeasureResource.ConversionBasedUnit.Pound);
			break;
		}
		ifcUnitAssignment.SetOrChangeSiUnit(Xbim.Ifc2x3.MeasureResource.IfcUnitEnum.SOLIDANGLEUNIT, Xbim.Ifc2x3.MeasureResource.IfcSIUnitName.STERADIAN, null);
		ifcUnitAssignment.SetOrChangeSiUnit(Xbim.Ifc2x3.MeasureResource.IfcUnitEnum.PLANEANGLEUNIT, Xbim.Ifc2x3.MeasureResource.IfcSIUnitName.RADIAN, null);
		ifcUnitAssignment.SetOrChangeSiUnit(Xbim.Ifc2x3.MeasureResource.IfcUnitEnum.TIMEUNIT, Xbim.Ifc2x3.MeasureResource.IfcSIUnitName.SECOND, null);
		ifcUnitAssignment.SetOrChangeSiUnit(Xbim.Ifc2x3.MeasureResource.IfcUnitEnum.THERMODYNAMICTEMPERATUREUNIT, Xbim.Ifc2x3.MeasureResource.IfcSIUnitName.KELVIN, null);
		ifcUnitAssignment.SetOrChangeSiUnit(Xbim.Ifc2x3.MeasureResource.IfcUnitEnum.THERMODYNAMICTEMPERATUREUNIT, Xbim.Ifc2x3.MeasureResource.IfcSIUnitName.DEGREE_CELSIUS, null);
		ifcUnitAssignment.SetOrChangeSiUnit(Xbim.Ifc2x3.MeasureResource.IfcUnitEnum.POWERUNIT, Xbim.Ifc2x3.MeasureResource.IfcSIUnitName.WATT, null);
		ifcUnitAssignment.SetOrChangeSiUnit(Xbim.Ifc2x3.MeasureResource.IfcUnitEnum.FORCEUNIT, Xbim.Ifc2x3.MeasureResource.IfcSIUnitName.NEWTON, null);
		ifcUnitAssignment.SetOrChangeSiUnit(Xbim.Ifc2x3.MeasureResource.IfcUnitEnum.ILLUMINANCEUNIT, Xbim.Ifc2x3.MeasureResource.IfcSIUnitName.LUX, null);
		ifcUnitAssignment.SetOrChangeSiUnit(Xbim.Ifc2x3.MeasureResource.IfcUnitEnum.LUMINOUSFLUXUNIT, Xbim.Ifc2x3.MeasureResource.IfcSIUnitName.LUMEN, null);
		ifcUnitAssignment.SetOrChangeSiUnit(Xbim.Ifc2x3.MeasureResource.IfcUnitEnum.LUMINOUSINTENSITYUNIT, Xbim.Ifc2x3.MeasureResource.IfcSIUnitName.CANDELA, null);
		ifcUnitAssignment.SetOrChangeSiUnit(Xbim.Ifc2x3.MeasureResource.IfcUnitEnum.PRESSUREUNIT, Xbim.Ifc2x3.MeasureResource.IfcSIUnitName.PASCAL, null);
		ifcUnitAssignment.SetOrChangeSiUnit(Xbim.Ifc2x3.MeasureResource.IfcUnitEnum.ELECTRICCURRENTUNIT, Xbim.Ifc2x3.MeasureResource.IfcSIUnitName.AMPERE, null);
		ifcUnitAssignment.SetOrChangeSiUnit(Xbim.Ifc2x3.MeasureResource.IfcUnitEnum.ELECTRICVOLTAGEUNIT, Xbim.Ifc2x3.MeasureResource.IfcSIUnitName.VOLT, null);
		ifcUnitAssignment.SetOrChangeSiUnit(Xbim.Ifc2x3.MeasureResource.IfcUnitEnum.FREQUENCYUNIT, Xbim.Ifc2x3.MeasureResource.IfcSIUnitName.HERTZ, null);
		UnitsInContext = ifcUnitAssignment;
		if (ModelContext == null)
		{
			IfcCartesianPoint origin = model.Instances.New(delegate(IfcCartesianPoint p)
			{
				p.SetXYZ(0.0, 0.0, 0.0);
			});
			IfcAxis2Placement3D axis3D = model.Instances.New(delegate(IfcAxis2Placement3D a)
			{
				a.Location = origin;
			});
			IfcGeometricRepresentationContext item = model.Instances.New(delegate(IfcGeometricRepresentationContext c)
			{
				c.ContextType = "Model";
				c.ContextIdentifier = "Building Model";
				c.CoordinateSpaceDimension = 3L;
				c.Precision = 1E-05;
				c.WorldCoordinateSystem = axis3D;
			});
			RepresentationContexts.Add(item);
			IfcCartesianPoint origin2D = model.Instances.New(delegate(IfcCartesianPoint p)
			{
				p.SetXY(0.0, 0.0);
			});
			IfcAxis2Placement2D axis2D = model.Instances.New(delegate(IfcAxis2Placement2D a)
			{
				a.Location = origin2D;
			});
			IfcGeometricRepresentationContext item2 = model.Instances.New(delegate(IfcGeometricRepresentationContext c)
			{
				c.ContextType = "Plan";
				c.ContextIdentifier = "Building Plan View";
				c.CoordinateSpaceDimension = 2L;
				c.Precision = 1E-05;
				c.WorldCoordinateSystem = axis2D;
			});
			RepresentationContexts.Add(item2);
		}
	}

	public string BuildName()
	{
		List<string> list = new List<string>();
		Xbim.Ifc2x3.MeasureResource.IfcLabel? name = base.Name;
		if (!string.IsNullOrWhiteSpace(name.HasValue ? ((string)name.GetValueOrDefault()) : null))
		{
			name = base.Name;
			list.Add(name.HasValue ? ((string)name.GetValueOrDefault()) : null);
		}
		else
		{
			name = LongName;
			if (!string.IsNullOrWhiteSpace(name.HasValue ? ((string)name.GetValueOrDefault()) : null))
			{
				name = LongName;
				list.Add(name.HasValue ? ((string)name.GetValueOrDefault()) : null);
			}
			else
			{
				Xbim.Ifc2x3.MeasureResource.IfcText? description = base.Description;
				if (!string.IsNullOrWhiteSpace(description.HasValue ? ((string)description.GetValueOrDefault()) : null))
				{
					description = base.Description;
					list.Add(description.HasValue ? ((string)description.GetValueOrDefault()) : null);
				}
			}
		}
		name = Phase;
		if (!string.IsNullOrWhiteSpace(name.HasValue ? ((string)name.GetValueOrDefault()) : null))
		{
			name = Phase;
			list.Add(name.HasValue ? ((string)name.GetValueOrDefault()) : null);
		}
		return string.Join(", ", list);
	}

	public void SetOrChangeSiUnit(Xbim.Ifc2x3.MeasureResource.IfcUnitEnum unitType, Xbim.Ifc2x3.MeasureResource.IfcSIUnitName siUnitName, Xbim.Ifc2x3.MeasureResource.IfcSIPrefix? siUnitPrefix)
	{
		if (UnitsInContext == null)
		{
			UnitsInContext = base.Model.Instances.New<Xbim.Ifc2x3.MeasureResource.IfcUnitAssignment>();
		}
		UnitsInContext.SetOrChangeSiUnit(unitType, siUnitName, siUnitPrefix);
	}

	public void SetOrChangeConversionUnit(Xbim.Ifc2x3.MeasureResource.IfcUnitEnum unitType, Xbim.Ifc2x3.MeasureResource.ConversionBasedUnit conversionUnit)
	{
		if (UnitsInContext == null)
		{
			UnitsInContext = base.Model.Instances.New<Xbim.Ifc2x3.MeasureResource.IfcUnitAssignment>();
		}
		UnitsInContext.SetOrChangeConversionUnit(unitType, conversionUnit);
	}

	public void AddSite(IfcSite site)
	{
		IfcRelDecomposes ifcRelDecomposes = base.IsDecomposedBy.FirstOrDefault();
		if (ifcRelDecomposes == null)
		{
			IfcRelAggregates ifcRelAggregates = base.Model.Instances.New<IfcRelAggregates>();
			ifcRelAggregates.RelatingObject = this;
			ifcRelAggregates.RelatedObjects.Add(site);
		}
		else
		{
			ifcRelDecomposes.RelatedObjects.Add(site);
		}
	}

	public void AddBuilding(IfcBuilding building)
	{
		IfcRelDecomposes ifcRelDecomposes = base.IsDecomposedBy.FirstOrDefault();
		if (ifcRelDecomposes == null)
		{
			IfcRelAggregates ifcRelAggregates = base.Model.Instances.New<IfcRelAggregates>();
			ifcRelAggregates.RelatingObject = this;
			ifcRelAggregates.RelatedObjects.Add(building);
		}
		else
		{
			ifcRelDecomposes.RelatedObjects.Add(building);
		}
	}

	public bool ValidateClause(IfcProjectClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcProjectClause.WR31:
				result = Functions.EXISTS(base.Name);
				break;
			case IfcProjectClause.WR32:
				result = Functions.SIZEOF(Enumerable.Where(RepresentationContexts, (IfcRepresentationContext Temp) => Functions.TYPEOF(Temp).Contains("IFC2X3.IFCGEOMETRICREPRESENTATIONSUBCONTEXT"))) == 0;
				break;
			case IfcProjectClause.WR33:
				result = Functions.SIZEOF(base.Decomposes) == 0;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcProject>()?.LogError($"Exception thrown evaluating where-clause 'IfcProject.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcProjectClause.WR31))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcProject.WR31",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcProjectClause.WR32))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcProject.WR32",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcProjectClause.WR33))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcProject.WR33",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
