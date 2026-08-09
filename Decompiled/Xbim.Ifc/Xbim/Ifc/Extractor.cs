using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Metadata;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc;

public class Extractor
{
	private enum ProcessingType
	{
		Pass,
		Remove,
		Entity,
		List
	}

	private bool _siteGeometryExists;

	private static string[] ignoreNamespaces = new string[6] { "GeometricConstraintResource", "GeometricModelResource", "GeometryResource", "ProfileResource", "TopologyResource", "RepresentationResource" };

	private Dictionary<int, IIfcStyledItem> _inverseStyleLookup;

	public Extractor(IModel source)
	{
		BuildInverseStyleLookup(source);
		List<IIfcElement> source2 = (from i in source.Instances.OfType<IIfcElement>()
			where !(i is IIfcOpeningElement)
			select i).ToList();
		List<IIfcProduct> list = new List<IIfcProduct>();
		GetAggregations(new HashSet<int>(source2.Select((IIfcElement element) => element.EntityLabel)), source, list);
		new HashSet<int>(list.Select((IIfcProduct d) => d.EntityLabel));
	}

	public void InsertCopy(IModel target, IEnumerable<IIfcProduct> products, bool includeGeometry, bool keepLabels, IProgress<double> progress = null)
	{
		List<IIfcProduct> primaryElements = new List<IIfcProduct>();
		List<IPersistEntity> list = products.Cast<IPersistEntity>().ToList();
		if (!list.Any())
		{
			progress?.Report(1.0);
			return;
		}
		IModel model = list.First().Model;
		if (model == target)
		{
			return;
		}
		List<IPersistEntity> entitiesToInsert = GetEntitiesToInsert(model, list, out primaryElements);
		IIfcProject ifcProject = model.Instances.FirstOrDefault<IIfcProject>();
		if (ifcProject != null)
		{
			entitiesToInsert.Add(ifcProject);
		}
		double num = entitiesToInsert.Count;
		XbimInstanceHandleMap mappings = new XbimInstanceHandleMap(model, target);
		bool includeSiteGeometry = false;
		if (!_siteGeometryExists)
		{
			lock (model)
			{
				if (!_siteGeometryExists && entitiesToInsert.OfType<IIfcRelAggregates>().Any((IIfcRelAggregates e) => e.RelatingObject is IIfcSite))
				{
					includeSiteGeometry = true;
					_siteGeometryExists = true;
				}
			}
		}
		PropertyTranformDelegate filter = GetFilter(primaryElements, includeGeometry, includeSiteGeometry, target.Metadata);
		int num2 = 0;
		foreach (IPersistEntity item in entitiesToInsert)
		{
			target.InsertCopy(item, mappings, filter, includeInverses: true, keepLabels);
			num2++;
			if (num2 % 20 == 0)
			{
				progress?.Report((double)num2 / num);
			}
		}
		progress?.Report(1.0);
	}

	private List<IPersistEntity> GetEntitiesToInsert(IModel source, List<IPersistEntity> roots, out List<IIfcProduct> primaryElements)
	{
		List<IIfcProduct> primary = roots.OfType<IIfcProduct>().ToList();
		List<IIfcProduct> list = new List<IIfcProduct>();
		HashSet<int> primaryIds = new HashSet<int>(primary.Select((IIfcProduct p) => p.EntityLabel));
		List<IIfcRelDecomposes> collection = GetAggregations(primaryIds, source, list).ToList();
		list.ForEach(delegate(IIfcProduct d)
		{
			if (primaryIds.Add(d.EntityLabel))
			{
				primary.Add(d);
			}
		});
		roots.AddRange(collection);
		List<IIfcRelContainedInSpatialStructure> list2 = source.Instances.Where((IIfcRelContainedInSpatialStructure r) => r.RelatedElements.Any((IIfcProduct e) => primaryIds.Contains(e.EntityLabel))).ToList();
		List<IIfcRelReferencedInSpatialStructure> list3 = source.Instances.Where((IIfcRelReferencedInSpatialStructure r) => r.RelatedElements.Any((IIfcProduct e) => primaryIds.Contains(e.EntityLabel))).ToList();
		List<IIfcSpatialElement> list4 = list2.Select((IIfcRelContainedInSpatialStructure r) => r.RelatingStructure).Union(list3.Select((IIfcRelReferencedInSpatialStructure r) => r.RelatingStructure)).ToList();
		List<IIfcRelAggregates> list5 = GetUpstreamHierarchy(list4, source).ToList();
		primary.AddRange(list4);
		primary.AddRange(list5.Select((IIfcRelAggregates r) => r.RelatingObject).OfType<IIfcProduct>());
		roots.AddRange(list5);
		roots.AddRange(list2);
		roots.AddRange(list3);
		List<IIfcRelVoidsElement> list6 = GetFeatureRelations(primary).ToList();
		IEnumerable<IIfcFeatureElementSubtraction> collection2 = list6.Select((IIfcRelVoidsElement r) => r.RelatedOpeningElement);
		primary.AddRange(collection2);
		roots.AddRange(list6);
		roots.AddRange(primary.SelectMany((IIfcProduct p) => p.IsDefinedBy));
		roots.AddRange(primary.SelectMany((IIfcProduct p) => p.IsTypedBy));
		roots.AddRange(primary.SelectMany((IIfcProduct p) => p.HasAssignments));
		roots.AddRange(primary.SelectMany((IIfcProduct p) => p.HasAssociations));
		primaryElements = primary;
		return roots;
	}

	private static HashSet<Type> GetIgnoredTypes(ExpressMetaData metaData)
	{
		return new HashSet<Type>(from t in metaData.Types()
			where !t.Type.IsAbstract && ignoreNamespaces.Any((string ns) => t.Type.Namespace.EndsWith(ns))
			select t.Type);
	}

	private static Type GetImplementation<T>(ExpressMetaData metadata)
	{
		List<ExpressType> source = metadata.TypesImplementing(typeof(T)).ToList();
		HashSet<short> ids = new HashSet<short>(source.Select((ExpressType i) => i.TypeId));
		return source.AsQueryable().FirstOrDefault((ExpressType i) => !ids.Contains(i.SuperType.TypeId)).Type;
	}

	private static Dictionary<Type, Dictionary<ExpressMetaProperty, ProcessingType>> GetProcessingInstructions(ExpressMetaData metaData, bool includeGeometry, bool includeSiteGeometry)
	{
		Type implementation = GetImplementation<IIfcProduct>(metaData);
		List<ExpressType> list = (from t in metaData.Types()
			where !t.Type.IsAbstract && !ignoreNamespaces.Any((string ns) => t.Type.Namespace.EndsWith(ns))
			select t).ToList();
		Dictionary<Type, Dictionary<ExpressMetaProperty, ProcessingType>> dictionary = new Dictionary<Type, Dictionary<ExpressMetaProperty, ProcessingType>>();
		foreach (ExpressType item in list)
		{
			Dictionary<ExpressMetaProperty, ProcessingType> dictionary2 = new Dictionary<ExpressMetaProperty, ProcessingType>(item.Properties.Count);
			foreach (KeyValuePair<int, ExpressMetaProperty> property in item.Properties)
			{
				_ = property.Key;
				ExpressMetaProperty value = property.Value;
				if (value.EnumerableType == null)
				{
					Type propertyType = value.PropertyInfo.PropertyType;
					if (propertyType.IsValueType || propertyType == typeof(string))
					{
						dictionary2.Add(value, ProcessingType.Pass);
					}
					else if (propertyType.IsAssignableFrom(implementation) || implementation.IsAssignableFrom(propertyType))
					{
						dictionary2.Add(value, ProcessingType.Entity);
					}
					else if (includeGeometry && (!typeof(IIfcSite).IsAssignableFrom(item.Type) || includeSiteGeometry))
					{
						dictionary2.Add(value, ProcessingType.Pass);
					}
					else if (typeof(IIfcProduct).IsAssignableFrom(item.Type) && (value.PropertyInfo.Name == "Representation" || value.PropertyInfo.Name == "ObjectPlacement"))
					{
						dictionary2.Add(value, ProcessingType.Remove);
					}
					else if (typeof(IIfcTypeProduct).IsAssignableFrom(item.Type) && value.PropertyInfo.Name == "RepresentationMaps")
					{
						dictionary2.Add(value, ProcessingType.Remove);
					}
					else if (typeof(IIfcRelSpaceBoundary).IsAssignableFrom(item.Type) && value.PropertyInfo.Name == "ConnectionGeometry")
					{
						dictionary2.Add(value, ProcessingType.Remove);
					}
					else
					{
						dictionary2.Add(value, ProcessingType.Pass);
					}
				}
				else
				{
					Type enumerableType = value.EnumerableType;
					if (enumerableType.IsValueType || enumerableType == typeof(string))
					{
						dictionary2.Add(value, ProcessingType.Pass);
					}
					else if (enumerableType.IsAssignableFrom(implementation) || implementation.IsAssignableFrom(enumerableType))
					{
						dictionary2.Add(value, ProcessingType.List);
					}
					else
					{
						dictionary2.Add(value, ProcessingType.Pass);
					}
				}
			}
			dictionary.Add(item.Type, dictionary2);
		}
		return dictionary;
	}

	private void BuildInverseStyleLookup(IModel source)
	{
		_inverseStyleLookup = new Dictionary<int, IIfcStyledItem>();
		foreach (IIfcStyledItem item in source.Instances.OfType<IIfcStyledItem>())
		{
			if (item.Item != null && !_inverseStyleLookup.ContainsKey(item.Item.EntityLabel))
			{
				_inverseStyleLookup.Add(item.Item.EntityLabel, item);
			}
		}
	}

	private PropertyTranformDelegate GetFilter(List<IIfcProduct> primaryElements, bool includeGeometry, bool includeSiteGeometry, ExpressMetaData metadata)
	{
		HashSet<int> primaryIds = new HashSet<int>(primaryElements.Select((IIfcProduct e) => e.EntityLabel));
		HashSet<Type> ignoredTypes = GetIgnoredTypes(metadata);
		Dictionary<Type, Dictionary<ExpressMetaProperty, ProcessingType>> instructions = GetProcessingInstructions(metadata, includeGeometry, includeSiteGeometry);
		return delegate(ExpressMetaProperty property, object parentObject)
		{
			if (property.IsInverse)
			{
				if (property.Name[0] == 'S' && property.Name == "StyledByItem")
				{
					int entityLabel = (parentObject as IPersistEntity).EntityLabel;
					if (_inverseStyleLookup.TryGetValue(entityLabel, out var value))
					{
						return value;
					}
					return (object)null;
				}
				return (object)null;
			}
			object value2 = property.PropertyInfo.GetValue(parentObject, null);
			if (property.PropertyInfo.PropertyType.IsValueType)
			{
				return value2;
			}
			Type type = parentObject.GetType();
			if (ignoredTypes.Contains(type))
			{
				return value2;
			}
			if (!instructions.TryGetValue(type, out var value3))
			{
				return value2;
			}
			switch (value3[property])
			{
			case ProcessingType.Pass:
				return value2;
			case ProcessingType.Remove:
				return (object)null;
			case ProcessingType.Entity:
				if (value2 is IIfcProduct ifcProduct && !primaryIds.Contains(ifcProduct.EntityLabel))
				{
					return (object)null;
				}
				return value2;
			case ProcessingType.List:
				if (value2 is IEnumerable<IPersist> source)
				{
					return source.Where((IPersist entity) => !(entity is IIfcProduct ifcProduct2) || primaryIds.Contains(ifcProduct2.EntityLabel)).ToList();
				}
				return value2;
			default:
				return value2;
			}
		};
	}

	private static IEnumerable<IIfcRelVoidsElement> GetFeatureRelations(IEnumerable<IIfcProduct> products)
	{
		HashSet<int> elementIds = new HashSet<int>(from e in products.OfType<IIfcElement>()
			select e.EntityLabel);
		if (elementIds.Count == 0)
		{
			return Enumerable.Empty<IIfcRelVoidsElement>();
		}
		return products.First().Model.Instances.Where((IIfcRelVoidsElement r) => elementIds.Contains(r.RelatingBuildingElement.EntityLabel));
	}

	private IEnumerable<IIfcRelDecomposes> GetAggregations(HashSet<int> productIds, IModel source, List<IIfcProduct> decomposition)
	{
		decomposition.Clear();
		List<IIfcRelDecomposes> list = new List<IIfcRelDecomposes>();
		while (productIds.Any())
		{
			List<IIfcRelDecomposes> list2 = source.Instances.Where(delegate(IIfcRelDecomposes r)
			{
				if (r is IIfcRelAggregates ifcRelAggregates)
				{
					return productIds.Contains(ifcRelAggregates.RelatingObject.EntityLabel);
				}
				if (r is IIfcRelNests ifcRelNests)
				{
					return productIds.Contains(ifcRelNests.RelatingObject.EntityLabel);
				}
				if (r is IIfcRelProjectsElement ifcRelProjectsElement)
				{
					return productIds.Contains(ifcRelProjectsElement.RelatingElement.EntityLabel);
				}
				return r is IIfcRelVoidsElement ifcRelVoidsElement && productIds.Contains(ifcRelVoidsElement.RelatingBuildingElement.EntityLabel);
			}).ToList();
			List<IIfcProduct> list3 = (from p in list2.SelectMany(delegate(IIfcRelDecomposes r)
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
			list.AddRange(list2);
			decomposition.AddRange(list3);
			productIds = new HashSet<int>(list3.Select((IIfcProduct p) => p.EntityLabel));
		}
		return list;
	}

	private static IEnumerable<IIfcRelAggregates> GetUpstreamHierarchy(IEnumerable<IIfcSpatialElement> spatialStructureElements, IModel model)
	{
		IEnumerable<IIfcRelAggregates> enumerable = model.Instances.Where((IIfcRelAggregates r) => r.RelatingObject is IIfcSpatialStructureElement || r.RelatedObjects.Any((IIfcObjectDefinition o) => o is IIfcSpatialStructureElement));
		Dictionary<int, HashSet<IIfcRelAggregates>> lookUp = new Dictionary<int, HashSet<IIfcRelAggregates>>();
		foreach (IIfcRelAggregates item in enumerable)
		{
			foreach (IIfcSpatialStructureElement item2 in item.RelatedObjects.OfType<IIfcSpatialStructureElement>())
			{
				if (lookUp.TryGetValue(item2.EntityLabel, out var value))
				{
					value.Add(item);
					continue;
				}
				value = new HashSet<IIfcRelAggregates>(new IIfcRelAggregates[1] { item });
				lookUp.Add(item2.EntityLabel, value);
			}
		}
		while (spatialStructureElements.Any())
		{
			HashSet<IIfcRelAggregates> hashSet = new HashSet<IIfcRelAggregates>();
			foreach (int item3 in spatialStructureElements.Select((IIfcSpatialElement s) => s.EntityLabel))
			{
				if (!lookUp.TryGetValue(item3, out var value2))
				{
					continue;
				}
				foreach (IIfcRelAggregates item4 in value2)
				{
					hashSet.Add(item4);
				}
			}
			spatialStructureElements = hashSet.Select((IIfcRelAggregates r) => r.RelatingObject).OfType<IIfcSpatialStructureElement>();
			foreach (IIfcRelAggregates item5 in hashSet)
			{
				yield return item5;
			}
		}
	}
}
