using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xbim.Common.Enumerations;
using Xbim.Common.Metadata;

namespace Xbim.Common.ExpressValidation;

public class Validator
{
	protected int _entityCount;

	protected int _resultCount;

	public ValidationFlags ValidateLevel = ValidationFlags.Properties;

	public bool CreateEntityHierarchy { get; set; }

	public int EntityCountLimit { get; set; } = -1;

	public int ResultCountLimit { get; set; } = -1;

	public bool LimitReached
	{
		get
		{
			if (EntityCountLimit < 0 || _entityCount < EntityCountLimit)
			{
				if (ResultCountLimit >= 0)
				{
					return _resultCount >= ResultCountLimit;
				}
				return false;
			}
			return true;
		}
	}

	public virtual IEnumerable<ValidationResult> Validate(IModel model)
	{
		return Validate(model.Instances);
	}

	public virtual IEnumerable<ValidationResult> Validate(IEnumerable<IPersistEntity> entities)
	{
		foreach (IPersistEntity entity in entities)
		{
			foreach (ValidationResult item in Validate(entity))
			{
				yield return item;
				if (LimitReached)
				{
					yield break;
				}
			}
		}
	}

	public virtual IEnumerable<ValidationResult> Validate(IPersistEntity entity)
	{
		foreach (ValidationResult item in PerformValidation(entity, CreateEntityHierarchy, ValidateLevel))
		{
			yield return item;
			if (LimitReached)
			{
				yield break;
			}
		}
	}

	protected IEnumerable<ValidationResult> PerformValidation(IPersistEntity ent, bool hierarchical, ValidationFlags validateLevel = ValidationFlags.Properties)
	{
		bool thisEntAdded = false;
		ValidationResult hierResult = new ValidationResult
		{
			Item = ent,
			IssueType = ValidationFlags.None
		};
		if (validateLevel == ValidationFlags.None)
		{
			yield break;
		}
		ExpressType expType = ent.ExpressType;
		if (validateLevel.HasFlag(ValidationFlags.Properties))
		{
			foreach (ExpressMetaProperty value in expType.Properties.Values)
			{
				IEnumerable<ValidationResult> schemaErrors = GetSchemaErrors(ent, value, validateLevel, hierarchical);
				foreach (ValidationResult item in schemaErrors)
				{
					item.IssueType |= ValidationFlags.Properties;
					thisEntAdded = UpdateCount(thisEntAdded);
					if (hierarchical)
					{
						hierResult.AddDetail(item);
						continue;
					}
					item.Item = ent;
					yield return item;
				}
			}
		}
		if (validateLevel.HasFlag(ValidationFlags.Inverses))
		{
			foreach (ExpressMetaProperty inverse in expType.Inverses)
			{
				IEnumerable<ValidationResult> schemaErrors2 = GetSchemaErrors(ent, inverse, validateLevel, hierarchical);
				foreach (ValidationResult item2 in schemaErrors2)
				{
					item2.IssueType |= ValidationFlags.Inverses;
					thisEntAdded = UpdateCount(thisEntAdded);
					if (hierarchical)
					{
						hierResult.AddDetail(item2);
						continue;
					}
					item2.Item = ent;
					yield return item2;
				}
			}
		}
		if (validateLevel.HasFlag(ValidationFlags.EntityWhereClauses) && ent is IExpressValidatable)
		{
			IEnumerable<ValidationResult> enumerable = ((IExpressValidatable)ent).Validate();
			foreach (ValidationResult item3 in enumerable)
			{
				thisEntAdded = UpdateCount(thisEntAdded);
				if (hierarchical)
				{
					hierResult.AddDetail(item3);
				}
				else
				{
					yield return item3;
				}
			}
		}
		if (hierarchical && hierResult.IssueType != ValidationFlags.None)
		{
			hierResult.Message = $"Entity {ent} has validation failures.";
			yield return hierResult;
		}
	}

	private bool UpdateCount(bool thisEntAdded)
	{
		if (!thisEntAdded)
		{
			_entityCount++;
		}
		_resultCount++;
		return true;
	}

	protected static IEnumerable<ValidationResult> GetSchemaErrors(IPersist instance, ExpressMetaProperty prop, ValidationFlags validateLevel, bool hierarchical)
	{
		EntityAttributeAttribute attr = prop.EntityAttribute;
		object propVal = GetPropertyValue(instance, prop);
		string propName = prop.PropertyInfo.Name;
		if (propVal is IExpressValueType)
		{
			object value = ((IExpressValueType)propVal).Value;
			Type underlyingSystemType = ((IExpressValueType)propVal).UnderlyingSystemType;
			if (attr.State == EntityAttributeState.Mandatory && value == null && underlyingSystemType != typeof(bool?))
			{
				yield return new ValidationResult
				{
					Item = instance,
					IssueType = ValidationFlags.Properties,
					IssueSource = propName,
					Message = $"{instance.GetType().Name}.{propName} is not optional."
				};
			}
			if (!validateLevel.HasFlag(ValidationFlags.TypeWhereClauses) || !(propVal is IExpressValidatable))
			{
				yield break;
			}
			ValidationResult hierResult = new ValidationResult
			{
				Item = instance,
				IssueType = ValidationFlags.None
			};
			foreach (ValidationResult item in ((IExpressValidatable)propVal).Validate())
			{
				if (hierarchical)
				{
					hierResult.AddDetail(item);
				}
				else
				{
					yield return item;
				}
			}
			if (hierarchical && hierResult.IssueType != ValidationFlags.None)
			{
				hierResult.Message = $"Property {prop.Name} has validation failures.";
				yield return hierResult;
			}
			yield break;
		}
		if (attr.State == EntityAttributeState.Mandatory && propVal == null)
		{
			yield return new ValidationResult
			{
				Item = instance,
				IssueType = ValidationFlags.Properties,
				IssueSource = propName,
				Message = $"{instance.GetType().Name}.{propName} is not optional."
			};
		}
		if ((attr.State != EntityAttributeState.Optional || propVal != null) && (attr.State != EntityAttributeState.Optional || !(propVal is IOptionalItemSet) || ((IOptionalItemSet)propVal).Initialized) && attr.IsEnumerable && ((attr.MinCardinality != null && attr.MinCardinality.Length != 0 && !attr.MinCardinality.All((int c) => c < 0)) || (attr.MaxCardinality != null && attr.MaxCardinality.Length != 0 && !attr.MaxCardinality.All((int c) => c < 1))))
		{
			if (attr.MinCardinality.Length != attr.MaxCardinality.Length)
			{
				throw new Exception("Inconsistent metadata: minimal and maximal cardinality has to have the same length.");
			}
			StringBuilder stringBuilder = new StringBuilder();
			IEnumerable items = (IEnumerable)propVal;
			CheckCardinality(attr.MinCardinality, attr.MaxCardinality, items, 0, stringBuilder);
			string text = stringBuilder.ToString();
			if (!string.IsNullOrWhiteSpace(text))
			{
				yield return new ValidationResult
				{
					Item = instance,
					IssueType = ValidationFlags.Properties,
					IssueSource = propName,
					Message = $"{instance.GetType().Name}.{prop.Name}: {text}"
				};
			}
		}
	}

	private static object GetPropertyValue(IPersist instance, ExpressMetaProperty prop)
	{
		try
		{
			return prop.PropertyInfo.GetValue(instance, null);
		}
		catch
		{
			return null;
		}
	}

	protected static void CheckCardinality(int[] minimums, int[] maximums, IEnumerable items, int depth, StringBuilder sb)
	{
		if (depth >= minimums.Length || items == null)
		{
			return;
		}
		int num = minimums[depth];
		int num2 = maximums[depth];
		if (num > 0 && num2 > 0)
		{
			int num3 = 0;
			if (items is ICollection collection)
			{
				num3 = collection.Count;
			}
			else
			{
				foreach (object item in items)
				{
					_ = item;
					num3++;
					if ((num3 >= num && num2 == -1) || (num2 > -1 && num3 > num2))
					{
						break;
					}
				}
			}
			if (num3 < num)
			{
				sb.AppendFormat("Must have at least {0} item(s). It has {1} or more.", num, num3);
				sb.AppendLine();
			}
			if (num3 > num2)
			{
				sb.AppendFormat("Must have no more than {0} item(s). It has at least {1}.", num2, num3);
				sb.AppendLine();
			}
		}
		if (depth + 1 == minimums.Length)
		{
			return;
		}
		foreach (object item2 in items)
		{
			CheckCardinality(minimums, maximums, item2 as IEnumerable, depth + 1, sb);
		}
	}
}
