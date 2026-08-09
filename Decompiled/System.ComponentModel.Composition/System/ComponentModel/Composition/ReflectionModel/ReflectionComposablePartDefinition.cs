using System.Collections.Generic;
using System.ComponentModel.Composition.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using Microsoft.Internal.Collections;

namespace System.ComponentModel.Composition.ReflectionModel;

internal sealed class ReflectionComposablePartDefinition : ComposablePartDefinition, ICompositionElement
{
	private readonly IReflectionPartCreationInfo _creationInfo;

	private volatile ImportDefinition[] _imports;

	private volatile ExportDefinition[] _exports;

	private volatile IDictionary<string, object> _metadata;

	private volatile ConstructorInfo _constructor;

	private readonly object _lock = new object();

	private ExportDefinition[] ExportDefinitionsInternal
	{
		get
		{
			if (_exports == null)
			{
				ExportDefinition[] exports = _creationInfo.GetExports().ToArray();
				lock (_lock)
				{
					if (_exports == null)
					{
						_exports = exports;
					}
				}
			}
			return _exports;
		}
	}

	public override IEnumerable<ExportDefinition> ExportDefinitions => ExportDefinitionsInternal;

	public override IEnumerable<ImportDefinition> ImportDefinitions
	{
		get
		{
			if (_imports == null)
			{
				ImportDefinition[] imports = _creationInfo.GetImports().ToArray();
				lock (_lock)
				{
					if (_imports == null)
					{
						_imports = imports;
					}
				}
			}
			return _imports;
		}
	}

	public override IDictionary<string, object?> Metadata
	{
		get
		{
			if (_metadata == null)
			{
				IDictionary<string, object> metadata = _creationInfo.GetMetadata().AsReadOnly();
				lock (_lock)
				{
					if (_metadata == null)
					{
						_metadata = metadata;
					}
				}
			}
			return _metadata;
		}
	}

	internal bool IsDisposalRequired => _creationInfo.IsDisposalRequired;

	string ICompositionElement.DisplayName => _creationInfo.DisplayName;

	ICompositionElement? ICompositionElement.Origin => _creationInfo.Origin;

	public ReflectionComposablePartDefinition(IReflectionPartCreationInfo creationInfo)
	{
		ArgumentNullException.ThrowIfNull(creationInfo, "creationInfo");
		_creationInfo = creationInfo;
	}

	public Type GetPartType()
	{
		return _creationInfo.GetPartType();
	}

	public Lazy<Type> GetLazyPartType()
	{
		return _creationInfo.GetLazyPartType();
	}

	public ConstructorInfo? GetConstructor()
	{
		if (_constructor == null)
		{
			ConstructorInfo constructor = _creationInfo.GetConstructor();
			lock (_lock)
			{
				if ((object)_constructor == null)
				{
					_constructor = constructor;
				}
			}
		}
		return _constructor;
	}

	public override ComposablePart CreatePart()
	{
		if (IsDisposalRequired)
		{
			return new DisposableReflectionComposablePart(this);
		}
		return new ReflectionComposablePart(this);
	}

	internal override ComposablePartDefinition? GetGenericPartDefinition()
	{
		if (_creationInfo is GenericSpecializationPartCreationInfo genericSpecializationPartCreationInfo)
		{
			return genericSpecializationPartCreationInfo.OriginalPart;
		}
		return null;
	}

	internal override bool TryGetExports(ImportDefinition definition, out Tuple<ComposablePartDefinition, ExportDefinition>? singleMatch, out IEnumerable<Tuple<ComposablePartDefinition, ExportDefinition>>? multipleMatches)
	{
		if (this.IsGeneric())
		{
			singleMatch = null;
			multipleMatches = null;
			List<Tuple<ComposablePartDefinition, ExportDefinition>> list = null;
			IEnumerable<object> enumerable = ((definition.Metadata.Count > 0) ? definition.Metadata.GetValue<IEnumerable<object>>("System.ComponentModel.Composition.GenericParameters") : null);
			if (enumerable != null && TryGetGenericTypeParameters(enumerable, out var genericTypeParameters))
			{
				HashSet<ComposablePartDefinition> hashSet = null;
				ComposablePartDefinition composablePartDefinition = null;
				foreach (Type[] candidateParameter in GetCandidateParameters(genericTypeParameters))
				{
					if (!TryMakeGenericPartDefinition(candidateParameter, out ComposablePartDefinition genericPartDefinition))
					{
						continue;
					}
					bool flag = false;
					if (hashSet == null)
					{
						if (composablePartDefinition != null)
						{
							if (genericPartDefinition.Equals(composablePartDefinition))
							{
								flag = true;
							}
							else
							{
								hashSet = new HashSet<ComposablePartDefinition>();
								hashSet.Add(composablePartDefinition);
								hashSet.Add(genericPartDefinition);
							}
						}
						else
						{
							composablePartDefinition = genericPartDefinition;
						}
					}
					else
					{
						flag |= !hashSet.Add(genericPartDefinition);
					}
					if (!flag && genericPartDefinition.TryGetExports(definition, out Tuple<ComposablePartDefinition, ExportDefinition> singleMatch2, out IEnumerable<Tuple<ComposablePartDefinition, ExportDefinition>> multipleMatches2))
					{
						list = list.FastAppendToListAllowNulls(singleMatch2, multipleMatches2);
					}
				}
			}
			if (list != null)
			{
				multipleMatches = list;
				return true;
			}
			return false;
		}
		return TryGetNonGenericExports(definition, out singleMatch, out multipleMatches);
	}

	private bool TryGetNonGenericExports(ImportDefinition definition, out Tuple<ComposablePartDefinition, ExportDefinition> singleMatch, out IEnumerable<Tuple<ComposablePartDefinition, ExportDefinition>> multipleMatches)
	{
		singleMatch = null;
		multipleMatches = null;
		List<Tuple<ComposablePartDefinition, ExportDefinition>> list = null;
		Tuple<ComposablePartDefinition, ExportDefinition> tuple = null;
		bool flag = false;
		ExportDefinition[] exportDefinitionsInternal = ExportDefinitionsInternal;
		foreach (ExportDefinition exportDefinition in exportDefinitionsInternal)
		{
			if (!definition.IsConstraintSatisfiedBy(exportDefinition))
			{
				continue;
			}
			flag = true;
			if (tuple == null)
			{
				tuple = new Tuple<ComposablePartDefinition, ExportDefinition>(this, exportDefinition);
				continue;
			}
			if (list == null)
			{
				list = new List<Tuple<ComposablePartDefinition, ExportDefinition>>();
				list.Add(tuple);
			}
			list.Add(new Tuple<ComposablePartDefinition, ExportDefinition>(this, exportDefinition));
		}
		if (!flag)
		{
			return false;
		}
		if (list != null)
		{
			multipleMatches = list;
		}
		else
		{
			singleMatch = tuple;
		}
		return true;
	}

	private IEnumerable<Type[]> GetCandidateParameters(Type[] genericParameters)
	{
		ExportDefinition[] exportDefinitionsInternal = ExportDefinitionsInternal;
		foreach (ExportDefinition exportDefinition in exportDefinitionsInternal)
		{
			int[] value = exportDefinition.Metadata.GetValue<int[]>("System.ComponentModel.Composition.GenericExportParametersOrderMetadataName");
			if (value != null && value.Length == genericParameters.Length)
			{
				yield return GenericServices.Reorder(genericParameters, value);
			}
		}
	}

	private static bool TryGetGenericTypeParameters(IEnumerable<object> genericParameters, [NotNullWhen(true)] out Type[] genericTypeParameters)
	{
		genericTypeParameters = genericParameters as Type[];
		if (genericTypeParameters == null)
		{
			object[] array = genericParameters.AsArray();
			genericTypeParameters = new Type[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				genericTypeParameters[i] = array[i] as Type;
				if (genericTypeParameters[i] == null)
				{
					return false;
				}
			}
		}
		return true;
	}

	internal bool TryMakeGenericPartDefinition(Type[] genericTypeParameters, [NotNullWhen(true)] out ComposablePartDefinition? genericPartDefinition)
	{
		genericPartDefinition = null;
		if (!GenericSpecializationPartCreationInfo.CanSpecialize(Metadata, genericTypeParameters))
		{
			return false;
		}
		genericPartDefinition = new ReflectionComposablePartDefinition(new GenericSpecializationPartCreationInfo(_creationInfo, this, genericTypeParameters));
		return true;
	}

	public override string ToString()
	{
		return _creationInfo.DisplayName;
	}

	public override bool Equals(object? obj)
	{
		if (_creationInfo.IsIdentityComparison)
		{
			return this == obj;
		}
		if (obj is ReflectionComposablePartDefinition reflectionComposablePartDefinition)
		{
			return _creationInfo.Equals(reflectionComposablePartDefinition._creationInfo);
		}
		return false;
	}

	public override int GetHashCode()
	{
		if (_creationInfo.IsIdentityComparison)
		{
			return base.GetHashCode();
		}
		return _creationInfo.GetHashCode();
	}
}
