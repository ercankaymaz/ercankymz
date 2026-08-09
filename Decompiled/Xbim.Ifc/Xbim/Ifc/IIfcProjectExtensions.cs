using System.Collections.Generic;
using System.Linq;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4x3.ProductExtension;

namespace Xbim.Ifc;

public static class IIfcProjectExtensions
{
	public static IEnumerable<IIfcSpatialStructureElement> GetSpatialStructuralElements(this IIfcProject project)
	{
		return project.IsDecomposedBy.SelectMany((IIfcRelAggregates rel) => rel.RelatedObjects.OfType<IIfcSpatialStructureElement>());
	}

	public static void AddSite(this IIfcProject proj, IIfcSite site)
	{
		IIfcRelAggregates ifcRelAggregates = proj.IsDecomposedBy.FirstOrDefault();
		if (ifcRelAggregates == null)
		{
			new EntityCreator(proj.Model).RelAggregates(delegate(IIfcRelAggregates r)
			{
				r.RelatingObject = proj;
				r.RelatedObjects.Add(site);
			});
		}
		else
		{
			ifcRelAggregates.RelatedObjects.Add(site);
		}
	}

	public static void AddBuilding(this IIfcProject proj, IIfcBuilding building)
	{
		IIfcRelAggregates ifcRelAggregates = proj.IsDecomposedBy.FirstOrDefault();
		if (ifcRelAggregates == null)
		{
			new EntityCreator(proj.Model).RelAggregates(delegate(IIfcRelAggregates r)
			{
				r.RelatingObject = proj;
				r.RelatedObjects.Add(building);
			});
		}
		else
		{
			ifcRelAggregates.RelatedObjects.Add(building);
		}
	}

	public static void AddFacility(this IIfcProject proj, IfcFacility facility)
	{
		IIfcRelAggregates ifcRelAggregates = proj.IsDecomposedBy.FirstOrDefault();
		if (ifcRelAggregates == null)
		{
			new EntityCreator(proj.Model).RelAggregates(delegate(IIfcRelAggregates r)
			{
				r.RelatingObject = proj;
				r.RelatedObjects.Add(facility);
			});
		}
		else
		{
			ifcRelAggregates.RelatedObjects.Add(facility);
		}
	}
}
