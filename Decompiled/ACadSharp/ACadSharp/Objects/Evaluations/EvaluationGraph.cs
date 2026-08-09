using System;
using System.Collections.Generic;
using ACadSharp.Attributes;

namespace ACadSharp.Objects.Evaluations;

[DxfName("ACAD_EVALUATION_GRAPH")]
[DxfSubClass("AcDbEvalGraph")]
public class EvaluationGraph : NonGraphicalObject
{
	public class Edge
	{
	}

	public class Node : ICloneable
	{
		[DxfCodeValue(new int[] { 91 })]
		public int Index { get; set; }

		[DxfCodeValue(new int[] { 95 })]
		internal int NextNodeIndex { get; set; }

		[Obsolete("Next reference may not be needed if the reference is the index.")]
		public Node Next { get; internal set; }

		[DxfCodeValue(new int[] { 93 })]
		public int Flags { get; set; }

		[DxfCodeValue(new int[] { 92 })]
		public int Data1 { get; internal set; }

		[DxfCodeValue(new int[] { 92 })]
		public int Data2 { get; internal set; }

		[DxfCodeValue(new int[] { 92 })]
		public int Data3 { get; internal set; }

		[DxfCodeValue(new int[] { 92 })]
		public int Data4 { get; internal set; }

		[DxfCodeValue(new int[] { 360 })]
		public EvaluationExpression Expression { get; internal set; }

		public object Clone()
		{
			Node obj = (Node)MemberwiseClone();
			obj.Next = (Node)(Next?.Clone());
			obj.Expression = (EvaluationExpression)(Expression?.Clone());
			return obj;
		}
	}

	public const string DictionaryEntryName = "ACAD_ENHANCEDBLOCK";

	public override ObjectType ObjectType => ObjectType.UNLISTED;

	public override string ObjectName => "ACAD_EVALUATION_GRAPH";

	public override string SubclassMarker => "AcDbEvalGraph";

	[DxfCodeValue(new int[] { 96 })]
	public int Value96 { get; set; }

	[DxfCodeValue(new int[] { 97 })]
	public int Value97 { get; set; }

	public IList<Node> Nodes { get; private set; } = new List<Node>();

	public IList<Edge> Edges { get; private set; } = new List<Edge>();

	public override CadObject Clone()
	{
		EvaluationGraph evaluationGraph = (EvaluationGraph)base.Clone();
		evaluationGraph.Nodes = new List<Node>();
		foreach (Node node in Nodes)
		{
			evaluationGraph.Nodes.Add((Node)node.Clone());
		}
		return evaluationGraph;
	}
}
