using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.ProductExtension;
using Xbim.Ifc4.RepresentationResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.Kernel;

[ExpressType("IfcProject", 204)]
public class IfcProject : IfcContext, IInstantiableEntity, IPersistEntity, IPersist, IIfcProject, IIfcContext, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcProject>, IExpressValidatable
{
	public enum IfcProjectClause
	{
		HasName,
		CorrectContext,
		NoDecomposition
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.OwnerHistory != null)
			{
				yield return base.OwnerHistory;
			}
			foreach (IfcRepresentationContext representationContext in base.RepresentationContexts)
			{
				yield return representationContext;
			}
			if (base.UnitsInContext != null)
			{
				yield return base.UnitsInContext;
			}
		}
	}

	public IfcGeometricRepresentationContext ModelContext => base.RepresentationContexts.FirstOrDefault((IfcGeometricRepresentationContext r) => r.ContextType == (IfcLabel?)(IfcLabel)"Model");

	public IEnumerable<IIfcSite> Sites => base.IsDecomposedBy.SelectMany((IfcRelAggregates rel) => rel.RelatedObjects.OfType<IfcSite>());

	public IEnumerable<IIfcBuilding> Buildings
	{
		get
		{
			foreach (IfcRelAggregates item in base.IsDecomposedBy)
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

	public IEnumerable<IIfcSpatialStructureElement> SpatialStructuralElements => base.IsDecomposedBy.SelectMany((IfcRelAggregates rel) => rel.RelatedObjects.OfType<IfcSpatialStructureElement>());

	internal IfcProject(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 8u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcProject other)
	{
		return this == other;
	}

	public void Initialize(ProjectUnits units)
	{
		IModel model = base.Model;
		IfcUnitAssignment ifcUnitAssignment = model.Instances.New<IfcUnitAssignment>();
		switch (units)
		{
		case ProjectUnits.SIUnitsUK:
			ifcUnitAssignment.SetOrChangeSiUnit(IfcUnitEnum.LENGTHUNIT, IfcSIUnitName.METRE, IfcSIPrefix.MILLI);
			ifcUnitAssignment.SetOrChangeSiUnit(IfcUnitEnum.AREAUNIT, IfcSIUnitName.SQUARE_METRE, null);
			ifcUnitAssignment.SetOrChangeSiUnit(IfcUnitEnum.VOLUMEUNIT, IfcSIUnitName.CUBIC_METRE, null);
			ifcUnitAssignment.SetOrChangeSiUnit(IfcUnitEnum.MASSUNIT, IfcSIUnitName.GRAM, IfcSIPrefix.KILO);
			break;
		case ProjectUnits.ImperialUnits:
		case ProjectUnits.USCustomaryUnits:
			ifcUnitAssignment.SetOrChangeConversionUnit(IfcUnitEnum.LENGTHUNIT, ConversionBasedUnit.Foot);
			ifcUnitAssignment.SetOrChangeConversionUnit(IfcUnitEnum.AREAUNIT, ConversionBasedUnit.SquareFoot);
			ifcUnitAssignment.SetOrChangeConversionUnit(IfcUnitEnum.VOLUMEUNIT, ConversionBasedUnit.CubicFoot);
			ifcUnitAssignment.SetOrChangeConversionUnit(IfcUnitEnum.MASSUNIT, ConversionBasedUnit.Pound);
			break;
		}
		ifcUnitAssignment.SetOrChangeSiUnit(IfcUnitEnum.SOLIDANGLEUNIT, IfcSIUnitName.STERADIAN, null);
		ifcUnitAssignment.SetOrChangeSiUnit(IfcUnitEnum.PLANEANGLEUNIT, IfcSIUnitName.RADIAN, null);
		ifcUnitAssignment.SetOrChangeSiUnit(IfcUnitEnum.TIMEUNIT, IfcSIUnitName.SECOND, null);
		ifcUnitAssignment.SetOrChangeSiUnit(IfcUnitEnum.THERMODYNAMICTEMPERATUREUNIT, IfcSIUnitName.KELVIN, null);
		ifcUnitAssignment.SetOrChangeSiUnit(IfcUnitEnum.THERMODYNAMICTEMPERATUREUNIT, IfcSIUnitName.DEGREE_CELSIUS, null);
		ifcUnitAssignment.SetOrChangeSiUnit(IfcUnitEnum.POWERUNIT, IfcSIUnitName.WATT, null);
		ifcUnitAssignment.SetOrChangeSiUnit(IfcUnitEnum.FORCEUNIT, IfcSIUnitName.NEWTON, null);
		ifcUnitAssignment.SetOrChangeSiUnit(IfcUnitEnum.ILLUMINANCEUNIT, IfcSIUnitName.LUX, null);
		ifcUnitAssignment.SetOrChangeSiUnit(IfcUnitEnum.LUMINOUSFLUXUNIT, IfcSIUnitName.LUMEN, null);
		ifcUnitAssignment.SetOrChangeSiUnit(IfcUnitEnum.LUMINOUSINTENSITYUNIT, IfcSIUnitName.CANDELA, null);
		ifcUnitAssignment.SetOrChangeSiUnit(IfcUnitEnum.PRESSUREUNIT, IfcSIUnitName.PASCAL, null);
		ifcUnitAssignment.SetOrChangeSiUnit(IfcUnitEnum.ELECTRICCURRENTUNIT, IfcSIUnitName.AMPERE, null);
		ifcUnitAssignment.SetOrChangeSiUnit(IfcUnitEnum.ELECTRICVOLTAGEUNIT, IfcSIUnitName.VOLT, null);
		ifcUnitAssignment.SetOrChangeSiUnit(IfcUnitEnum.FREQUENCYUNIT, IfcSIUnitName.HERTZ, null);
		base.UnitsInContext = ifcUnitAssignment;
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
			base.RepresentationContexts.Add(item);
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
			base.RepresentationContexts.Add(item2);
		}
	}

	public void AddSite(IfcSite site)
	{
		IfcRelAggregates ifcRelAggregates = base.IsDecomposedBy.FirstOrDefault();
		if (ifcRelAggregates == null)
		{
			IfcRelAggregates ifcRelAggregates2 = base.Model.Instances.New<IfcRelAggregates>();
			ifcRelAggregates2.RelatingObject = this;
			ifcRelAggregates2.RelatedObjects.Add(site);
		}
		else
		{
			ifcRelAggregates.RelatedObjects.Add(site);
		}
	}

	public void AddBuilding(IfcBuilding building)
	{
		IfcRelAggregates ifcRelAggregates = base.IsDecomposedBy.FirstOrDefault();
		if (ifcRelAggregates == null)
		{
			IfcRelAggregates ifcRelAggregates2 = base.Model.Instances.New<IfcRelAggregates>();
			ifcRelAggregates2.RelatingObject = this;
			ifcRelAggregates2.RelatedObjects.Add(building);
		}
		else
		{
			ifcRelAggregates.RelatedObjects.Add(building);
		}
	}

	public bool ValidateClause(IfcProjectClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcProjectClause.HasName:
				result = Functions.EXISTS(base.Name);
				break;
			case IfcProjectClause.CorrectContext:
				result = !Functions.EXISTS(base.RepresentationContexts) || Functions.SIZEOF(Enumerable.Where(base.RepresentationContexts, (IfcRepresentationContext Temp) => Functions.TYPEOF(Temp).Contains("IFC4.IFCGEOMETRICREPRESENTATIONSUBCONTEXT"))) == 0;
				break;
			case IfcProjectClause.NoDecomposition:
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

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcProjectClause.HasName))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcProject.HasName",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcProjectClause.CorrectContext))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcProject.CorrectContext",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcProjectClause.NoDecomposition))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcProject.NoDecomposition",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
