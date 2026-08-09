using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Metadata;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc;

public static class IfcStoreCopyItemsExtensions
{
	private class CopyContext
	{
		public List<IIfcProduct> PrimaryElements { get; set; }

		public List<IIfcProduct> Decomposition { get; private set; } = new List<IIfcProduct>();

		public bool IncludeGeometry { get; set; }
	}

	public static void InsertCopy(this IModel model, IEnumerable<IIfcProduct> products, bool includeGeometry, bool keepLabels, XbimInstanceHandleMap mappings)
	{
		CopyContext context = new CopyContext
		{
			IncludeGeometry = includeGeometry
		};
		List<IPersistEntity> list = products.Cast<IPersistEntity>().ToList();
		if (!list.Any())
		{
			return;
		}
		IModel model2 = list.First().Model;
		if (model2 == model)
		{
			return;
		}
		IEnumerable<IPersistEntity> entitiesToInsert = GetEntitiesToInsert(context, model2, list);
		XbimInstanceHandleMap mappings2 = mappings ?? new XbimInstanceHandleMap(model2, model);
		foreach (IPersistEntity item in entitiesToInsert)
		{
			model.InsertCopy(item, mappings2, (ExpressMetaProperty property, object obj) => Filter(context, property, obj), includeInverses: true, keepLabels);
		}
	}

	private static IEnumerable<IPersistEntity> GetEntitiesToInsert(CopyContext context, IModel model, List<IPersistEntity> roots)
	{
		context.PrimaryElements = roots.OfType<IIfcProduct>().ToList();
		List<IIfcRelDecomposes> collection = GetAggregations(context, context.PrimaryElements.ToList(), model).ToList();
		context.PrimaryElements.AddRange(context.Decomposition);
		roots.AddRange(collection);
		List<IIfcRelContainedInSpatialStructure> list = model.Instances.Where((IIfcRelContainedInSpatialStructure r) => context.PrimaryElements.Any((IIfcProduct e) => r.RelatedElements.Contains(e))).ToList();
		List<IIfcRelReferencedInSpatialStructure> list2 = model.Instances.Where((IIfcRelReferencedInSpatialStructure r) => context.PrimaryElements.Any((IIfcProduct e) => r.RelatedElements.Contains(e))).ToList();
		List<IIfcSpatialElement> list3 = list.Select((IIfcRelContainedInSpatialStructure r) => r.RelatingStructure).Union(list2.Select((IIfcRelReferencedInSpatialStructure r) => r.RelatingStructure)).ToList();
		List<IIfcRelAggregates> list4 = GetUpstreamHierarchy(list3, model).ToList();
		context.PrimaryElements.AddRange(list3);
		context.PrimaryElements.AddRange(list4.Select((IIfcRelAggregates r) => r.RelatingObject).OfType<IIfcProduct>());
		roots.AddRange(list4);
		roots.AddRange(list);
		roots.AddRange(list2);
		List<IIfcRelVoidsElement> list5 = GetFeatureRelations(context.PrimaryElements).ToList();
		IEnumerable<IIfcFeatureElementSubtraction> collection2 = list5.Select((IIfcRelVoidsElement r) => r.RelatedOpeningElement);
		context.PrimaryElements.AddRange(collection2);
		roots.AddRange(list5);
		roots.AddRange(context.PrimaryElements.SelectMany((IIfcProduct p) => p.IsDefinedBy));
		roots.AddRange(context.PrimaryElements.SelectMany((IIfcProduct p) => p.IsTypedBy));
		roots.AddRange(context.PrimaryElements.SelectMany((IIfcProduct p) => p.HasAssignments));
		roots.AddRange(context.PrimaryElements.SelectMany((IIfcProduct p) => p.HasAssociations));
		return roots;
	}

	private static object Filter(CopyContext context, ExpressMetaProperty property, object parentObject)
	{
		if (property.IsInverse)
		{
			if (!(property.Name == "StyledByItem"))
			{
				return null;
			}
			return property.PropertyInfo.GetValue(parentObject, null);
		}
		if (context.PrimaryElements != null && context.PrimaryElements.Any())
		{
			if (typeof(IIfcProduct).IsAssignableFrom(property.PropertyInfo.PropertyType))
			{
				if (property.PropertyInfo.GetValue(parentObject, null) is IIfcProduct ifcProduct && context.PrimaryElements.Contains(ifcProduct))
				{
					return ifcProduct;
				}
				return null;
			}
			if (property.EnumerableType != null && !property.EnumerableType.IsValueType && property.EnumerableType != typeof(string) && property.PropertyInfo.GetValue(parentObject, null) is IEnumerable<IPersist> enumerable)
			{
				IList<IPersist> list = (enumerable as IList<IPersist>) ?? enumerable.ToList();
				List<IIfcProduct> list2 = (from e in list.OfType<IIfcProduct>()
					where !context.PrimaryElements.Contains(e)
					select e).ToList();
				if (list2.Any())
				{
					return list.Except(list2).ToList();
				}
			}
		}
		if (context.IncludeGeometry)
		{
			return property.PropertyInfo.GetValue(parentObject, null);
		}
		if (parentObject is IIfcProduct && (property.PropertyInfo.Name == "Representation" || property.PropertyInfo.Name == "ObjectPlacement"))
		{
			return null;
		}
		if (parentObject is IIfcTypeProduct && property.PropertyInfo.Name == "RepresentationMaps")
		{
			return null;
		}
		if (parentObject is IIfcRelSpaceBoundary && property.PropertyInfo.Name == "ConnectionGeometry")
		{
			return null;
		}
		return property.PropertyInfo.GetValue(parentObject, null);
	}

	private static IEnumerable<IIfcRelVoidsElement> GetFeatureRelations(IEnumerable<IIfcProduct> products)
	{
		List<IIfcElement> elements = products.OfType<IIfcElement>().ToList();
		if (!elements.Any())
		{
			yield break;
		}
		IEnumerable<IIfcRelVoidsElement> enumerable = elements.First().Model.Instances.Where((IIfcRelVoidsElement r) => elements.Any((IIfcElement e) => object.Equals(e, r.RelatingBuildingElement)));
		foreach (IIfcRelVoidsElement item in enumerable)
		{
			yield return item;
		}
	}

	private static IEnumerable<IIfcRelDecomposes> GetAggregations(CopyContext context, List<IIfcProduct> products, IModel model)
	{
		context.Decomposition.Clear();
		while (products.Any())
		{
			List<IIfcProduct> products2 = products;
			List<IIfcRelDecomposes> list = model.Instances.Where(delegate(IIfcRelDecomposes r)
			{
				IIfcRelAggregates aggr = r as IIfcRelAggregates;
				if (aggr != null)
				{
					return products2.Any((IIfcProduct p) => object.Equals(aggr.RelatingObject, p));
				}
				IIfcRelNests nest = r as IIfcRelNests;
				if (nest != null)
				{
					return products2.Any((IIfcProduct p) => object.Equals(nest.RelatingObject, p));
				}
				IIfcRelProjectsElement prj = r as IIfcRelProjectsElement;
				if (prj != null)
				{
					return products2.Any((IIfcProduct p) => object.Equals(prj.RelatingElement, p));
				}
				IIfcRelVoidsElement voids = r as IIfcRelVoidsElement;
				return voids != null && products2.Any((IIfcProduct p) => object.Equals(voids.RelatingBuildingElement, p));
			}).ToList();
			List<IIfcProduct> relatedProducts = (from p in list.SelectMany(delegate(IIfcRelDecomposes r)
				{
					if (r is IIfcRelAggregates ifcRelAggregates)
					{
						return ifcRelAggregates.RelatedObjects.OfType<IIfcProduct>();
					}
					if (r is IIfcRelNests ifcRelNests)
					{
						return ifcRelNests.RelatedObjects.OfType<IIfcProduct>();
					}
					if (r is IIfcRelProjectsElement ifcRelProjectsElement)
					{
						return new IIfcProduct[1] { ifcRelProjectsElement.RelatedFeatureElement };
					}
					return (r is IIfcRelVoidsElement ifcRelVoidsElement) ? new IIfcProduct[1] { ifcRelVoidsElement.RelatedOpeningElement } : null;
				})
				where p != null
				select p).ToList();
			foreach (IIfcRelDecomposes item in list)
			{
				yield return item;
			}
			products = relatedProducts;
			context.Decomposition.AddRange(products);
		}
	}

	private static IEnumerable<IIfcRelAggregates> GetUpstreamHierarchy(IEnumerable<IIfcSpatialElement> spatialStructureElements, IModel model)
	{
		while (true)
		{
			List<IIfcSpatialElement> elements = spatialStructureElements.ToList();
			if (!elements.Any())
			{
				break;
			}
			List<IIfcRelAggregates> list = model.Instances.Where((IIfcRelAggregates r) => elements.Any((IIfcSpatialElement s) => r.RelatedObjects.Contains(s))).ToList();
			IEnumerable<IIfcSpatialStructureElement> decomposing = list.Select((IIfcRelAggregates r) => r.RelatingObject).OfType<IIfcSpatialStructureElement>();
			foreach (IIfcRelAggregates item in list)
			{
				yield return item;
			}
			spatialStructureElements = decomposing;
		}
	}
}
