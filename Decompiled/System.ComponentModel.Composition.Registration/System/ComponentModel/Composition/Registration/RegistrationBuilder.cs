using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Context;
using System.Threading;

namespace System.ComponentModel.Composition.Registration;

public class RegistrationBuilder : CustomReflectionContext
{
	internal sealed class InnerRC : ReflectionContext
	{
		public override TypeInfo MapType(TypeInfo t)
		{
			return t;
		}

		public override Assembly MapAssembly(Assembly a)
		{
			return a;
		}
	}

	private static readonly ReflectionContext s_inner = new InnerRC();

	private static readonly List<object> s_emptyList = new List<object>();

	private readonly Lock _lock = new Lock();

	private readonly List<PartBuilder> _conventions = new List<PartBuilder>();

	private readonly Dictionary<MemberInfo, List<Attribute>> _memberInfos = new Dictionary<MemberInfo, List<Attribute>>();

	private readonly Dictionary<ParameterInfo, List<Attribute>> _parameters = new Dictionary<ParameterInfo, List<Attribute>>();

	public RegistrationBuilder()
		: base(s_inner)
	{
	}

	public PartBuilder<T> ForTypesDerivedFrom<T>()
	{
		PartBuilder<T> partBuilder = new PartBuilder<T>((Type t) => typeof(T) != t && typeof(T).IsAssignableFrom(t));
		_conventions.Add(partBuilder);
		return partBuilder;
	}

	public PartBuilder ForTypesDerivedFrom(Type type)
	{
		if ((object)type == null)
		{
			throw new ArgumentNullException("type");
		}
		PartBuilder partBuilder = new PartBuilder((Type t) => type != t && type.IsAssignableFrom(t));
		_conventions.Add(partBuilder);
		return partBuilder;
	}

	public PartBuilder<T> ForType<T>()
	{
		PartBuilder<T> partBuilder = new PartBuilder<T>((Type t) => t == typeof(T));
		_conventions.Add(partBuilder);
		return partBuilder;
	}

	public PartBuilder ForType(Type type)
	{
		if ((object)type == null)
		{
			throw new ArgumentNullException("type");
		}
		PartBuilder partBuilder = new PartBuilder((Type t) => t == type);
		_conventions.Add(partBuilder);
		return partBuilder;
	}

	public PartBuilder<T> ForTypesMatching<T>(Predicate<Type> typeFilter)
	{
		if (typeFilter == null)
		{
			throw new ArgumentNullException("typeFilter");
		}
		PartBuilder<T> partBuilder = new PartBuilder<T>(typeFilter);
		_conventions.Add(partBuilder);
		return partBuilder;
	}

	public PartBuilder ForTypesMatching(Predicate<Type> typeFilter)
	{
		if (typeFilter == null)
		{
			throw new ArgumentNullException("typeFilter");
		}
		PartBuilder partBuilder = new PartBuilder(typeFilter);
		_conventions.Add(partBuilder);
		return partBuilder;
	}

	private List<Tuple<object, List<Attribute>>> EvaluateThisTypeAgainstTheConvention(Type type)
	{
		List<Attribute> list = new List<Attribute>();
		List<Tuple<object, List<Attribute>>> configuredMembers = new List<Tuple<object, List<Attribute>>>();
		bool flag = false;
		bool flag2 = false;
		foreach (PartBuilder item in _conventions.Where((PartBuilder c) => c.SelectType(type.UnderlyingSystemType)))
		{
			list.AddRange(item.BuildTypeAttributes(type));
			flag |= item.BuildConstructorAttributes(type, ref configuredMembers);
			item.BuildPropertyAttributes(type, ref configuredMembers);
			flag2 = true;
		}
		if (flag2 && !flag)
		{
			PartBuilder.BuildDefaultConstructorAttributes(type, ref configuredMembers);
		}
		configuredMembers.Add(Tuple.Create((object)type, list));
		return configuredMembers;
	}

	protected override IEnumerable<object> GetCustomAttributes(MemberInfo member, IEnumerable<object> declaredAttributes)
	{
		IEnumerable<object> customAttributes = base.GetCustomAttributes(member, declaredAttributes);
		List<Attribute> value = null;
		if (member.MemberType == MemberTypes.TypeInfo || member.MemberType == MemberTypes.NestedType)
		{
			MemberInfo underlyingSystemType = ((Type)member).UnderlyingSystemType;
			using (new ReadLock(_lock))
			{
				_memberInfos.TryGetValue(underlyingSystemType, out value);
			}
			if (value == null)
			{
				using (new WriteLock(_lock))
				{
					if (!_memberInfos.TryGetValue(underlyingSystemType, out value))
					{
						foreach (Tuple<object, List<Attribute>> item2 in EvaluateThisTypeAgainstTheConvention((Type)member))
						{
							List<Attribute> item = item2.Item2;
							if (item == null)
							{
								continue;
							}
							if (item2.Item1 is MemberInfo)
							{
								List<Attribute> value2;
								switch (((MemberInfo)item2.Item1).MemberType)
								{
								case MemberTypes.Constructor:
									if (!_memberInfos.TryGetValue((MemberInfo)item2.Item1, out value2))
									{
										_memberInfos.Add((MemberInfo)item2.Item1, item2.Item2);
									}
									else
									{
										value2.AddRange(item);
									}
									break;
								case MemberTypes.Property:
								case MemberTypes.TypeInfo:
								case MemberTypes.NestedType:
									if (!_memberInfos.TryGetValue((MemberInfo)item2.Item1, out value2))
									{
										_memberInfos.Add((MemberInfo)item2.Item1, item2.Item2);
									}
									else
									{
										value2.AddRange(item);
									}
									break;
								}
							}
							else
							{
								if (!(item2.Item1 is ParameterInfo))
								{
									throw new Exception(System.SR.Diagnostic_InternalExceptionMessage);
								}
								if (!_parameters.TryGetValue((ParameterInfo)item2.Item1, out var value3))
								{
									_parameters.Add((ParameterInfo)item2.Item1, item2.Item2);
								}
								else
								{
									value3.AddRange(value);
								}
							}
						}
					}
					_memberInfos.TryGetValue(underlyingSystemType, out value);
				}
			}
		}
		else if (member.MemberType == MemberTypes.Constructor || member.MemberType == MemberTypes.Property)
		{
			value = ReadMemberCustomAttributes(member);
		}
		if (value != null)
		{
			return customAttributes.Concat(value);
		}
		return customAttributes;
	}

	protected override IEnumerable<object> GetCustomAttributes(ParameterInfo parameter, IEnumerable<object> declaredAttributes)
	{
		IEnumerable<object> customAttributes = base.GetCustomAttributes(parameter, declaredAttributes);
		List<Attribute> list = ReadParameterCustomAttributes(parameter);
		if (list != null)
		{
			return customAttributes.Concat(list);
		}
		return customAttributes;
	}

	private List<Attribute> ReadMemberCustomAttributes(MemberInfo member)
	{
		List<Attribute> value = null;
		bool flag = false;
		using (new ReadLock(_lock))
		{
			if (!_memberInfos.TryGetValue(member, out value))
			{
				if (!_memberInfos.TryGetValue(member.DeclaringType.UnderlyingSystemType, out value))
				{
					flag = true;
				}
				value = null;
			}
		}
		if (flag)
		{
			GetCustomAttributes(member.DeclaringType, s_emptyList);
			using (new ReadLock(_lock))
			{
				_memberInfos.TryGetValue(member, out value);
			}
		}
		return value;
	}

	private List<Attribute> ReadParameterCustomAttributes(ParameterInfo parameter)
	{
		List<Attribute> value = null;
		bool flag = false;
		using (new ReadLock(_lock))
		{
			if (!_parameters.TryGetValue(parameter, out value))
			{
				if (!_memberInfos.TryGetValue(parameter.Member.DeclaringType, out value))
				{
					flag = true;
				}
				value = null;
			}
		}
		if (flag)
		{
			GetCustomAttributes(parameter.Member.DeclaringType, s_emptyList);
			using (new ReadLock(_lock))
			{
				_parameters.TryGetValue(parameter, out value);
			}
		}
		return value;
	}
}
