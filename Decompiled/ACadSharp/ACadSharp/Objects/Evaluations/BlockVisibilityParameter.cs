using System;
using System.Collections.Generic;
using ACadSharp.Attributes;
using ACadSharp.Entities;

namespace ACadSharp.Objects.Evaluations;

[DxfName("BLOCKVISIBILITYPARAMETER")]
[DxfSubClass("AcDbBlockVisibilityParameter")]
public class BlockVisibilityParameter : Block1PtParameter
{
	public class State : ICloneable
	{
		[DxfCodeValue(new int[] { 303 })]
		public string Name { get; set; }

		[DxfCodeValue(DxfReferenceType.Count, new int[] { 94 })]
		[DxfCollectionCodeValue(DxfReferenceType.Handle, new int[] { 332 })]
		public List<Entity> Entities { get; private set; } = new List<Entity>();

		[DxfCodeValue(DxfReferenceType.Count, new int[] { 95 })]
		[DxfCollectionCodeValue(DxfReferenceType.Handle, new int[] { 333 })]
		public List<EvaluationExpression> Expressions { get; private set; } = new List<EvaluationExpression>();

		public object Clone()
		{
			State state = (State)MemberwiseClone();
			state.Entities = new List<Entity>();
			foreach (Entity entity in Entities)
			{
				state.Entities.Add((Entity)entity.Clone());
			}
			state.Expressions = new List<EvaluationExpression>();
			foreach (EvaluationExpression expression in Expressions)
			{
				state.Expressions.Add((EvaluationExpression)expression.Clone());
			}
			return state;
		}
	}

	public override string ObjectName => "BLOCKVISIBILITYPARAMETER";

	public override string SubclassMarker => "AcDbBlockVisibilityParameter";

	[DxfCodeValue(new int[] { 331 })]
	public List<Entity> Entities { get; private set; } = new List<Entity>();

	[DxfCodeValue(DxfReferenceType.Count, new int[] { 95 })]
	public List<State> States { get; private set; } = new List<State>();

	[DxfCodeValue(new int[] { 301 })]
	public string Name { get; set; }

	[DxfCodeValue(new int[] { 302 })]
	public string Description { get; set; }

	[DxfCodeValue(new int[] { 91 })]
	internal bool Value91 { get; set; }

	public override CadObject Clone()
	{
		BlockVisibilityParameter blockVisibilityParameter = (BlockVisibilityParameter)base.Clone();
		blockVisibilityParameter.Entities = new List<Entity>();
		foreach (Entity entity in Entities)
		{
			blockVisibilityParameter.Entities.Add((Entity)entity.Clone());
		}
		blockVisibilityParameter.States = new List<State>();
		foreach (State state in States)
		{
			blockVisibilityParameter.States.Add((State)state.Clone());
		}
		return blockVisibilityParameter;
	}
}
