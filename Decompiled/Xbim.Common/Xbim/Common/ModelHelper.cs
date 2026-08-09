using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Logging;
using Xbim.Common.Configuration;
using Xbim.Common.Exceptions;
using Xbim.Common.Metadata;
using Xbim.IO;
using Xbim.IO.Parser;
using Xbim.IO.Step21;

namespace Xbim.Common;

public class ModelHelper
{
	private struct ReferingType
	{
		public ExpressType Type;

		public List<ExpressMetaProperty> SingleReferences;

		public List<ExpressMetaProperty> ListReferences;

		public List<ExpressMetaProperty> NestedListReferences;
	}

	private static readonly ConcurrentDictionary<Type, List<ReferingType>> ReferingTypesListsCache = new ConcurrentDictionary<Type, List<ReferingType>>();

	public static void Delete(IModel model, IPersistEntity entity, Func<IPersistEntity, bool> instanceRemoval)
	{
		foreach (ReferingType referingType in GetReferingTypes(model, entity.GetType()))
		{
			ReplaceReferences<IPersistEntity, IPersistEntity>(model, entity, referingType, null);
		}
		instanceRemoval(entity);
	}

	public static void Delete(IModel model, IPersistEntity[] entities, Action<IPersistEntity[]> instanceRemoval)
	{
		foreach (ReferingType item in new HashSet<ReferingType>(new HashSet<Type>(entities.Select((IPersistEntity e) => e.GetType())).SelectMany((Type t) => GetReferingTypes(model, t))))
		{
			ReplaceReferences<IPersistEntity, IPersistEntity>(model, entities, item, null);
		}
		instanceRemoval(entities);
	}

	public static void Replace<TEntity, TReplacement>(IModel model, TEntity entity, TReplacement replacement, Func<IPersistEntity, bool> instanceRemoval = null) where TEntity : IPersistEntity where TReplacement : TEntity
	{
		if (!entity.Model.Equals(replacement.Model))
		{
			throw new XbimException("It isn't possible to replace entities from different models. Insert copy of the entity first.");
		}
		foreach (ReferingType referingType in GetReferingTypes(model, entity.GetType()))
		{
			ReplaceReferences(model, (IPersistEntity)entity, referingType, (IPersistEntity)replacement);
		}
		instanceRemoval?.Invoke(entity);
	}

	private static IEnumerable<ReferingType> GetReferingTypes(IModel model, Type entityType)
	{
		if (ReferingTypesListsCache.TryGetValue(entityType, out var value))
		{
			return value;
		}
		value = new List<ReferingType>();
		if (!ReferingTypesListsCache.TryAdd(entityType, value))
		{
			return ReferingTypesListsCache[entityType];
		}
		foreach (ExpressType item2 in from t in model.Metadata.Types()
			where typeof(IInstantiableEntity).GetTypeInfo().IsAssignableFrom(t.Type)
			select t)
		{
			List<ExpressMetaProperty> list = item2.Properties.Values.Where((ExpressMetaProperty p) => p.EntityAttribute != null && p.EntityAttribute.Order > 0 && p.PropertyInfo.PropertyType.GetTypeInfo().IsAssignableFrom(entityType)).ToList();
			List<ExpressMetaProperty> list2 = item2.Properties.Values.Where((ExpressMetaProperty p) => p.EntityAttribute != null && p.EntityAttribute.Order > 0 && p.PropertyInfo.PropertyType.GetTypeInfo().IsGenericType && p.PropertyInfo.PropertyType.GenericTypeArgumentIsAssignableFrom(entityType)).ToList();
			List<ExpressMetaProperty> list3 = item2.Properties.Values.Where((ExpressMetaProperty p) => p.EntityAttribute != null && p.EntityAttribute.Order > 0 && p.PropertyInfo.PropertyType.GetTypeInfo().IsGenericType && p.PropertyInfo.PropertyType.GetItemTypeFromGenericType().IsGenericType && p.PropertyInfo.PropertyType.GetItemTypeFromGenericType().GenericTypeArgumentIsAssignableFrom(entityType)).ToList();
			if (list.Any() || list2.Any() || list3.Any())
			{
				ReferingType item = new ReferingType
				{
					Type = item2,
					SingleReferences = list,
					ListReferences = list2,
					NestedListReferences = list3
				};
				value.Add(item);
			}
		}
		return value;
	}

	private static void ReplaceReferences<TEntity, TReplacement>(IModel model, TEntity entity, ReferingType referingType, TReplacement replacement) where TEntity : IPersistEntity where TReplacement : TEntity
	{
		if (entity == null)
		{
			return;
		}
		foreach (IPersistEntity item in model.Instances.OfType(referingType.Type.Type.Name, activate: true))
		{
			foreach (PropertyInfo item2 in referingType.SingleReferences.Select((ExpressMetaProperty p) => p.PropertyInfo))
			{
				if (item2.GetValue(item) is IPersistEntity persistEntity && persistEntity.EntityLabel == entity.EntityLabel)
				{
					item2.SetValue(item, replacement);
				}
			}
			foreach (PropertyInfo item3 in referingType.ListReferences.Select((ExpressMetaProperty p) => p.PropertyInfo))
			{
				object value = item3.GetValue(item);
				if (value == null || value is IOptionalItemSet { Initialized: false })
				{
					continue;
				}
				if (value is IList list)
				{
					if (list.Contains(entity))
					{
						list.Remove(entity);
						if (replacement != null)
						{
							list.Add(replacement);
						}
					}
				}
				else
				{
					FallBackOperation(item, item3);
				}
			}
			foreach (PropertyInfo item4 in referingType.NestedListReferences.Select((ExpressMetaProperty p) => p.PropertyInfo))
			{
				object value2 = item4.GetValue(item);
				if (value2 == null || value2 is IOptionalItemSet { Initialized: false } || !(value2 is IList list2) || list2 == null)
				{
					continue;
				}
				for (int num = 0; num < list2.Count; num++)
				{
					if (!(list2[num] is IList list3) || list3 == null)
					{
						continue;
					}
					for (int num2 = 0; num2 < list3.Count; num2++)
					{
						if (list3.Contains(entity))
						{
							list3.RemoveAt(num2);
							if (replacement != null)
							{
								list3.Insert(num2, replacement);
							}
							else
							{
								num2--;
							}
						}
					}
				}
			}
		}
		void FallBackOperation(IPersistEntity toCheck, PropertyInfo pInfo)
		{
			MethodInfo? method = pInfo.PropertyType.GetTypeInfo().GetMethod("Contains");
			object value3 = pInfo.GetValue(toCheck);
			if (method == null)
			{
				throw new XbimException($"It wasn't possible to check containment of entity {entity.GetType().Name} in property {pInfo.Name} of {toCheck.GetType().Name}. No suitable method found.");
			}
			if ((bool)method.Invoke(value3, new object[1] { entity }))
			{
				MethodInfo? method2 = pInfo.PropertyType.GetTypeInfo().GetMethod("Remove");
				if (method2 == null)
				{
					throw new XbimException($"It wasn't possible to remove reference to entity {entity.GetType().Name} in property {pInfo.Name} of {toCheck.GetType().Name}. No suitable method found.");
				}
				method2.Invoke(value3, new object[1] { entity });
				if (replacement != null)
				{
					MethodInfo? method3 = pInfo.PropertyType.GetTypeInfo().GetMethod("Add");
					if (method3 == null)
					{
						throw new XbimException($"It wasn't possible to add reference to entity {entity.GetType().Name} in property {pInfo.Name} of {toCheck.GetType().Name}. No suitable method found.");
					}
					method3.Invoke(value3, new object[1] { replacement });
				}
			}
		}
	}

	private static void ReplaceReferences<TEntity, TReplacement>(IModel model, IEnumerable<TEntity> entities, ReferingType referingType, TReplacement replacement) where TEntity : IPersistEntity where TReplacement : TEntity
	{
		if (entities == null || !entities.Any())
		{
			return;
		}
		HashSet<object> hashSet = new HashSet<object>(entities.Cast<object>());
		foreach (IPersistEntity item3 in model.Instances.OfType(referingType.Type.Type.Name, activate: true))
		{
			foreach (PropertyInfo item4 in referingType.SingleReferences.Select((ExpressMetaProperty p) => p.PropertyInfo))
			{
				object value = item4.GetValue(item3);
				if ((value != null || replacement != null) && hashSet.Contains(value))
				{
					item4.SetValue(item3, replacement);
				}
			}
			foreach (PropertyInfo item5 in referingType.ListReferences.Select((ExpressMetaProperty p) => p.PropertyInfo))
			{
				object value2 = item5.GetValue(item3);
				if (value2 == null || value2 is IOptionalItemSet { Initialized: false })
				{
					continue;
				}
				if (!(value2 is IList list))
				{
					throw new XbimException("Unable to remove items from " + referingType.Type.Name + "." + item5.Name + ". No IList implementation.");
				}
				for (int num = 0; num < list.Count; num++)
				{
					object item = list[num];
					if (hashSet.Contains(item))
					{
						list.RemoveAt(num);
						if (replacement != null)
						{
							list.Insert(num, replacement);
						}
						else
						{
							num--;
						}
					}
				}
			}
			foreach (PropertyInfo item6 in referingType.NestedListReferences.Select((ExpressMetaProperty p) => p.PropertyInfo))
			{
				object value3 = item6.GetValue(item3);
				if (value3 == null || value3 is IOptionalItemSet { Initialized: false })
				{
					continue;
				}
				if (!(value3 is IList list2))
				{
					throw new XbimException("Unable to remove items from " + referingType.Type.Name + "." + item6.Name + ". No IList implementation.");
				}
				for (int num2 = 0; num2 < list2.Count; num2++)
				{
					if (!(list2[num2] is IList list3))
					{
						throw new XbimException("Unable to remove items from " + referingType.Type.Name + "." + item6.Name + ". No IList implementation.");
					}
					for (int num3 = 0; num3 < list3.Count; num3++)
					{
						object item2 = list3[num3];
						if (hashSet.Contains(item2))
						{
							list3.RemoveAt(num3);
							if (replacement != null)
							{
								list3.Insert(num3, replacement);
							}
							else
							{
								num3--;
							}
						}
					}
				}
			}
		}
	}

	public static void Expand<IParentEntity, IUniqueEntity>(IModel model, Func<IParentEntity, ICollection<IUniqueEntity>> accessor) where IParentEntity : IPersistEntity where IUniqueEntity : IPersistEntity
	{
		Dictionary<IUniqueEntity, List<IParentEntity>> dictionary = new Dictionary<IUniqueEntity, List<IParentEntity>>();
		foreach (IParentEntity item2 in model.Instances.OfType<IParentEntity>())
		{
			foreach (IUniqueEntity item3 in accessor(item2))
			{
				if (!dictionary.TryGetValue(item3, out var value))
				{
					value = new List<IParentEntity>();
					dictionary.Add(item3, value);
				}
				value.Add(item2);
			}
		}
		IEnumerable<KeyValuePair<IUniqueEntity, List<IParentEntity>>> enumerable = dictionary.Where((KeyValuePair<IUniqueEntity, List<IParentEntity>> a) => a.Value.Count > 1);
		XbimInstanceHandleMap xbimInstanceHandleMap = new XbimInstanceHandleMap(model, model);
		foreach (KeyValuePair<IUniqueEntity, List<IParentEntity>> item4 in enumerable)
		{
			IUniqueEntity key = item4.Key;
			List<IParentEntity> value2 = item4.Value;
			for (int num = 1; num < value2.Count; num++)
			{
				xbimInstanceHandleMap.Clear();
				IUniqueEntity item = model.InsertCopy(key, xbimInstanceHandleMap, null, includeInverses: false, keepLabels: false);
				IParentEntity arg = value2[num];
				ICollection<IUniqueEntity> collection = accessor(arg);
				collection.Remove(key);
				collection.Add(item);
			}
		}
	}

	public static T InsertCopy<T>(IModel model, T toCopy, XbimInstanceHandleMap mappings, PropertyTranformDelegate propTransform, bool includeInverses, bool keepLabels, Func<Type, int, IPersistEntity> getLabeledEntity) where T : IPersistEntity
	{
		try
		{
			int entityLabel = toCopy.EntityLabel;
			XbimInstanceHandle key = new XbimInstanceHandle(toCopy);
			if (mappings.TryGetValue(key, out var value))
			{
				return (T)value.GetEntity();
			}
			ExpressType expressType = model.Metadata.ExpressType(toCopy);
			IPersistEntity persistEntity = (keepLabels ? getLabeledEntity(toCopy.GetType(), entityLabel) : model.Instances.New(toCopy.GetType()));
			value = new XbimInstanceHandle(persistEntity);
			mappings.Add(key, value);
			IEnumerable<ExpressMetaProperty> enumerable = expressType.Properties.Values.Where((ExpressMetaProperty p) => !p.EntityAttribute.IsDerived);
			if (includeInverses)
			{
				enumerable = enumerable.Union(expressType.Inverses);
			}
			foreach (ExpressMetaProperty item in enumerable)
			{
				object obj = ((propTransform != null) ? propTransform(item, toCopy) : item.PropertyInfo.GetValue(toCopy, null));
				if (obj == null)
				{
					continue;
				}
				bool flag = item.EntityAttribute.Order == -1;
				Type type = obj.GetType();
				if (type.GetTypeInfo().IsValueType || typeof(ExpressType).GetTypeInfo().IsAssignableFrom(type) || type == typeof(string))
				{
					item.PropertyInfo.SetValue(persistEntity, obj, null);
				}
				else if (!flag && typeof(IPersistEntity).GetTypeInfo().IsAssignableFrom(type))
				{
					item.PropertyInfo.SetValue(persistEntity, InsertCopy(model, (IPersistEntity)obj, mappings, propTransform, includeInverses, keepLabels, getLabeledEntity), null);
				}
				else if (!flag && typeof(IList).GetTypeInfo().IsAssignableFrom(type))
				{
					Type itemTypeFromGenericType = type.GetItemTypeFromGenericType();
					if (!(item.PropertyInfo.GetValue(persistEntity, null) is IList list))
					{
						throw new Exception($"Unexpected collection type ({itemTypeFromGenericType.Name}) found");
					}
					foreach (object item2 in (IList)obj)
					{
						Type type2 = item2.GetType();
						if (type2.GetTypeInfo().IsValueType || typeof(ExpressType).GetTypeInfo().IsAssignableFrom(type2))
						{
							list.Add(item2);
							continue;
						}
						if (typeof(IPersistEntity).GetTypeInfo().IsAssignableFrom(type2))
						{
							IPersistEntity value2 = InsertCopy(model, (IPersistEntity)item2, mappings, propTransform, includeInverses, keepLabels, getLabeledEntity);
							list.Add(value2);
							continue;
						}
						if (typeof(IList).GetTypeInfo().IsAssignableFrom(type2))
						{
							IList list2 = (IList)item2;
							MethodInfo? method = list.GetType().GetTypeInfo().GetMethod("GetAt");
							if (method == null)
							{
								throw new Exception($"GetAt Method not found on ({list.GetType().Name}) found");
							}
							if (!(method.Invoke(list, new object[1] { list.Count }) is IList list3))
							{
								throw new XbimException("Collection can't be used as IList");
							}
							foreach (object item3 in list2)
							{
								Type type3 = item3.GetType();
								if (type3.GetTypeInfo().IsValueType || typeof(ExpressType).GetTypeInfo().IsAssignableFrom(type3))
								{
									list3.Add(item3);
									continue;
								}
								if (typeof(IPersistEntity).GetTypeInfo().IsAssignableFrom(type3))
								{
									IPersistEntity value3 = InsertCopy(model, (IPersistEntity)item3, mappings, propTransform, includeInverses, keepLabels, getLabeledEntity);
									list3.Add(value3);
									continue;
								}
								throw new Exception($"Unexpected collection item type ({itemTypeFromGenericType.Name}) found");
							}
							continue;
						}
						throw new Exception($"Unexpected collection item type ({itemTypeFromGenericType.Name}) found");
					}
				}
				else if (flag && obj is IEnumerable<IPersistEntity>)
				{
					foreach (IPersistEntity item4 in (IEnumerable<IPersistEntity>)obj)
					{
						InsertCopy(model, item4, mappings, propTransform, includeInverses, keepLabels, getLabeledEntity);
					}
				}
				else
				{
					if (!flag || !(obj is IPersistEntity))
					{
						throw new Exception($"Unexpected item type ({type.Name})  found");
					}
					InsertCopy(model, (IPersistEntity)obj, mappings, propTransform, includeInverses, keepLabels, getLabeledEntity);
				}
			}
			return (T)persistEntity;
		}
		catch (Exception ex)
		{
			throw new XbimException($"General failure in InsertCopy ({ex.Message})", ex);
		}
	}

	public static void WritePartialFile(IModel model, IPersistEntity root, TextWriter writer, HashSet<int> written)
	{
		WriteEntityRecursive(root, model.Metadata, writer, written);
	}

	private static void WriteEntityRecursive(IPersistEntity entity, ExpressMetaData metadata, TextWriter writer, HashSet<int> written)
	{
		if (written.Contains(entity.EntityLabel))
		{
			return;
		}
		Part21Writer.WriteEntity(entity, writer, metadata);
		written.Add(entity.EntityLabel);
		if (!(entity is IContainsEntityReferences containsEntityReferences))
		{
			return;
		}
		foreach (IPersistEntity reference in containsEntityReferences.References)
		{
			WriteEntityRecursive(reference, metadata, writer, written);
		}
	}

	public static List<string> GetStepFileSchemaVersion(Stream stream)
	{
		ILoggerFactory loggerFactory = XbimServices.Current.GetLoggerFactory();
		Scanner scanner = new Scanner(stream, loggerFactory);
		int num = scanner.yylex();
		int num2 = 68;
		int num3 = 64;
		int num4 = 73;
		int num5 = 76;
		List<string> list = new List<string>();
		while (num != num2 && num != num3)
		{
			if (num != num4)
			{
				num = scanner.yylex();
				continue;
			}
			if (!string.Equals(scanner.yylval.strVal, "FILE_SCHEMA", StringComparison.OrdinalIgnoreCase))
			{
				num = scanner.yylex();
				continue;
			}
			num = scanner.yylex();
			while (num != 41)
			{
				if (num != num5)
				{
					num = scanner.yylex();
					continue;
				}
				list.Add(scanner.yylval.strVal.Trim(new char[1] { '\'' }));
				num = scanner.yylex();
			}
			break;
		}
		return list;
	}
}
