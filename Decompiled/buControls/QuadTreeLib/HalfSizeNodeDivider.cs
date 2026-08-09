using SourceGrid;

namespace QuadTreeLib;

public class HalfSizeNodeDivider : IQuadTreeNodeDivider
{
	public QuadTreeNode CreateNewRoot(QuadTreeNode currentRoot)
	{
		return new ProportioanteSizeNodeDivider().CreateNewRoot(currentRoot);
	}

	public void CreateSubNodes(QuadTreeNode parentNode)
	{
		Range bounds = parentNode.Bounds;
		if (parentNode.Bounds.ColumnsCount * parentNode.Bounds.RowsCount > 10)
		{
			int row = bounds.Start.Row;
			int column = bounds.Start.Column;
			int num = bounds.ColumnsCount / 2;
			int num2 = bounds.RowsCount / 2;
			int depth = parentNode.Depth;
			QuadTree quadTree = parentNode.QuadTree;
			parentNode.Nodes.Add(new QuadTreeNode(Range.From(bounds.Start, num2, num), depth, quadTree));
			parentNode.Nodes.Add(new QuadTreeNode(Range.From(new Position(row, column + num), num2, num), depth, quadTree));
			parentNode.Nodes.Add(new QuadTreeNode(Range.From(new Position(row + num2, column), num2, num), depth, quadTree));
			parentNode.Nodes.Add(new QuadTreeNode(Range.From(new Position(row + num2, column + num), num2, num), depth, quadTree));
		}
	}
}
