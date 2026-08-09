using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.MeasureResource;
using Xbim.Ifc4x3.RepresentationResource;

namespace Xbim.Ifc4x3.Kernel;

[ExpressType("IfcProject", 204)]
public class IfcProject : IfcContext, IIfcProject, IIfcContext, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcProject>
{
	public IEnumerable<IIfcSite> Sites => base.IsDecomposedBy.SelectMany((IfcRelAggregates rel) => rel.RelatedObjects.OfType<IIfcSite>());

	public IEnumerable<IIfcSpatialStructureElement> SpatialStructuralElements => base.IsDecomposedBy.SelectMany((IfcRelAggregates rel) => rel.RelatedObjects.OfType<IIfcSpatialStructureElement>());

	public IEnumerable<IIfcBuilding> Buildings
	{
		get
		{
			foreach (IfcRelAggregates item in base.IsDecomposedBy)
			{
				foreach (IfcObjectDefinition definition in item.RelatedObjects)
				{
					if (definition is IIfcSite ifcSite)
					{
						foreach (IIfcBuilding building in ifcSite.Buildings)
						{
							yield return building;
						}
					}
					if (definition is IIfcBuilding)
					{
						yield return definition as IIfcBuilding;
					}
				}
			}
		}
	}

	public IfcGeometricRepresentationContext ModelContext => base.RepresentationContexts.FirstOrDefault((IfcGeometricRepresentationContext r) => r.ContextType == (IfcLabel?)(IfcLabel)"Model");

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

	public void Initialize(ProjectUnits units)
	{
		IModel model = base.Model;
		if (units == ProjectUnits.SIUnitsUK)
		{
			IfcUnitAssignment ifcUnitAssignment = model.Instances.New<IfcUnitAssignment>();
			ifcUnitAssignment.Units.Add(model.Instances.New(delegate(IfcSIUnit s)
			{
				s.UnitType = Xbim.Ifc4x3.MeasureResource.IfcUnitEnum.LENGTHUNIT;
				s.Name = Xbim.Ifc4x3.MeasureResource.IfcSIUnitName.METRE;
				s.Prefix = Xbim.Ifc4x3.MeasureResource.IfcSIPrefix.MILLI;
			}));
			ifcUnitAssignment.Units.Add(model.Instances.New(delegate(IfcSIUnit s)
			{
				s.UnitType = Xbim.Ifc4x3.MeasureResource.IfcUnitEnum.AREAUNIT;
				s.Name = Xbim.Ifc4x3.MeasureResource.IfcSIUnitName.SQUARE_METRE;
			}));
			ifcUnitAssignment.Units.Add(model.Instances.New(delegate(IfcSIUnit s)
			{
				s.UnitType = Xbim.Ifc4x3.MeasureResource.IfcUnitEnum.VOLUMEUNIT;
				s.Name = Xbim.Ifc4x3.MeasureResource.IfcSIUnitName.CUBIC_METRE;
			}));
			ifcUnitAssignment.Units.Add(model.Instances.New(delegate(IfcSIUnit s)
			{
				s.UnitType = Xbim.Ifc4x3.MeasureResource.IfcUnitEnum.SOLIDANGLEUNIT;
				s.Name = Xbim.Ifc4x3.MeasureResource.IfcSIUnitName.STERADIAN;
			}));
			ifcUnitAssignment.Units.Add(model.Instances.New(delegate(IfcSIUnit s)
			{
				s.UnitType = Xbim.Ifc4x3.MeasureResource.IfcUnitEnum.PLANEANGLEUNIT;
				s.Name = Xbim.Ifc4x3.MeasureResource.IfcSIUnitName.RADIAN;
			}));
			ifcUnitAssignment.Units.Add(model.Instances.New(delegate(IfcSIUnit s)
			{
				s.UnitType = Xbim.Ifc4x3.MeasureResource.IfcUnitEnum.MASSUNIT;
				s.Name = Xbim.Ifc4x3.MeasureResource.IfcSIUnitName.GRAM;
			}));
			ifcUnitAssignment.Units.Add(model.Instances.New(delegate(IfcSIUnit s)
			{
				s.UnitType = Xbim.Ifc4x3.MeasureResource.IfcUnitEnum.TIMEUNIT;
				s.Name = Xbim.Ifc4x3.MeasureResource.IfcSIUnitName.SECOND;
			}));
			ifcUnitAssignment.Units.Add(model.Instances.New(delegate(IfcSIUnit s)
			{
				s.UnitType = Xbim.Ifc4x3.MeasureResource.IfcUnitEnum.THERMODYNAMICTEMPERATUREUNIT;
				s.Name = Xbim.Ifc4x3.MeasureResource.IfcSIUnitName.DEGREE_CELSIUS;
			}));
			ifcUnitAssignment.Units.Add(model.Instances.New(delegate(IfcSIUnit s)
			{
				s.UnitType = Xbim.Ifc4x3.MeasureResource.IfcUnitEnum.LUMINOUSINTENSITYUNIT;
				s.Name = Xbim.Ifc4x3.MeasureResource.IfcSIUnitName.LUMEN;
			}));
			base.UnitsInContext = ifcUnitAssignment;
		}
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
}
