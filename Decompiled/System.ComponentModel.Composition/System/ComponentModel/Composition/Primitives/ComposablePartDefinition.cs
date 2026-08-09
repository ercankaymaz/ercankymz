using System.Collections.Generic;
using System.Linq;

namespace System.ComponentModel.Composition.Primitives;

public abstract class ComposablePartDefinition
{
	internal static readonly IEnumerable<Tuple<ComposablePartDefinition, ExportDefinition>> _EmptyExports = Enumerable.Empty<Tuple<ComposablePartDefinition, ExportDefinition>>();

	public abstract IEnumerable<ExportDefinition> ExportDefinitions { get; }

	public abstract IEnumerable<ImportDefinition> ImportDefinitions { get; }

	public virtual IDictionary<string, object?> Metadata => MetadataServices.EmptyMetadata;

	public abstract ComposablePart CreatePart();

	internal virtual bool TryGetExports(ImportDefinition definition, out Tuple<ComposablePartDefinition, ExportDefinition>? singleMatch, out IEnumerable<Tuple<ComposablePartDefinition, ExportDefinition>>? multipleMatches)
	{
		singleMatch = null;
		multipleMatches = null;
		List<Tuple<ComposablePartDefinition, ExportDefinition>> list = null;
		Tuple<ComposablePartDefinition, ExportDefinition> tuple = null;
		bool flag = false;
		foreach (ExportDefinition exportDefinition in ExportDefinitions)
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

	internal virtual ComposablePartDefinition? GetGenericPartDefinition()
	{
		return null;
	}
}
