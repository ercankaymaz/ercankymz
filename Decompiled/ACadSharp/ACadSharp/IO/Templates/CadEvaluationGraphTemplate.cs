using System.Collections.Generic;
using ACadSharp.Objects.Evaluations;

namespace ACadSharp.IO.Templates;

internal class CadEvaluationGraphTemplate : CadTemplate<EvaluationGraph>
{
	public class GraphNodeTemplate : ICadTemplate
	{
		public EvaluationGraph.Node Node { get; } = new EvaluationGraph.Node();

		public ulong? ExpressionHandle { get; set; }

		public void Build(CadDocumentBuilder builder)
		{
			if (builder.TryGetCadObject<EvaluationExpression>(ExpressionHandle, out var value))
			{
				Node.Expression = value;
			}
			else
			{
				builder.Notify($"Evaluation graph couldn't find the EvaluationExpression with handle {ExpressionHandle}", NotificationType.Warning);
			}
		}
	}

	public List<GraphNodeTemplate> NodeTemplates { get; } = new List<GraphNodeTemplate>();

	public CadEvaluationGraphTemplate()
		: base(new EvaluationGraph())
	{
	}

	public CadEvaluationGraphTemplate(EvaluationGraph evaluationGraph)
		: base(evaluationGraph)
	{
	}

	protected override void build(CadDocumentBuilder builder)
	{
		base.build(builder);
		foreach (GraphNodeTemplate nodeTemplate in NodeTemplates)
		{
			nodeTemplate.Build(builder);
			base.CadObject.Nodes.Add(nodeTemplate.Node);
		}
	}
}
