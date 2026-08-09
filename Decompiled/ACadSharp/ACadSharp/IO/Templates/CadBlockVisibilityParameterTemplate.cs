using System.Collections.Generic;
using System.Linq;
using ACadSharp.Entities;
using ACadSharp.Objects.Evaluations;

namespace ACadSharp.IO.Templates;

internal class CadBlockVisibilityParameterTemplate : CadBlock1PtParameterTemplate
{
	public class StateTemplate
	{
		public BlockVisibilityParameter.State State { get; } = new BlockVisibilityParameter.State();

		public HashSet<ulong> SubSet1 { get; } = new HashSet<ulong>();

		public HashSet<ulong> SubSet2 { get; } = new HashSet<ulong>();

		public void Build(CadDocumentBuilder builder, IEnumerable<ulong> entityHandles)
		{
			setEntities(builder, State.Entities, SubSet1, entityHandles);
			setEntities(builder, State.Expressions, SubSet2);
		}

		private void setEntities<T>(CadDocumentBuilder builder, List<T> subset, IEnumerable<ulong> handles, IEnumerable<ulong> entities = null) where T : CadObject
		{
			foreach (ulong handle in handles)
			{
				if (entities != null && !entities.Contains(handle))
				{
					builder.Notify($"[{State.ToString()}] parent does not contain handle {handle}.");
				}
				if (builder.TryGetCadObject<T>(handle, out var value))
				{
					subset.Add(value);
				}
				else
				{
					builder.Notify($"[{State.ToString()}] {typeof(T).FullName} with handle {handle} not found.");
				}
			}
		}
	}

	public List<ulong> EntityHandles { get; } = new List<ulong>();

	public List<StateTemplate> StateTemplates { get; } = new List<StateTemplate>();

	public CadBlockVisibilityParameterTemplate(BlockVisibilityParameter cadObject)
		: base(cadObject)
	{
	}

	protected override void build(CadDocumentBuilder builder)
	{
		base.build(builder);
		BlockVisibilityParameter blockVisibilityParameter = base.CadObject as BlockVisibilityParameter;
		foreach (ulong entityHandle in EntityHandles)
		{
			if (builder.TryGetCadObject<Entity>(entityHandle, out var value))
			{
				blockVisibilityParameter.Entities.Add(value);
			}
			else
			{
				builder.Notify($"[{blockVisibilityParameter.ToString()}] entity with handle {entityHandle} not found.");
			}
		}
		foreach (StateTemplate stateTemplate in StateTemplates)
		{
			stateTemplate.Build(builder, EntityHandles);
			blockVisibilityParameter.States.Add(stateTemplate.State);
		}
	}
}
