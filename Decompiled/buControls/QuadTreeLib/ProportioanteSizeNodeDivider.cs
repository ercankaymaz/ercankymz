using SourceGrid;
using ns27;

namespace QuadTreeLib;

public class ProportioanteSizeNodeDivider : IQuadTreeNodeDivider
{
	private HalfSizeNodeDivider halfSizeNodeDivider_0 = new HalfSizeNodeDivider();

	public QuadTreeNode CreateNewRoot(QuadTreeNode currentRoot)
	{
		Range bounds = currentRoot.Bounds;
		int row = bounds.Start.Row;
		int column = bounds.Start.Column;
		int columnsCount = bounds.ColumnsCount;
		int rowsCount = bounds.RowsCount;
		int depth = currentRoot.Depth;
		QuadTree quadTree = currentRoot.QuadTree;
		QuadTreeNode quadTreeNode = new QuadTreeNode(new Range(row, column, columnsCount * 2, rowsCount * 2), currentRoot.Depth, currentRoot.QuadTree);
		quadTreeNode.Nodes.Add(currentRoot);
		quadTreeNode.Nodes.Add(new QuadTreeNode(Range.From(new Position(row, column + columnsCount), rowsCount, columnsCount), depth, quadTree));
		quadTreeNode.Nodes.Add(new QuadTreeNode(Range.From(new Position(row + rowsCount, column), rowsCount, columnsCount), depth, quadTree));
		quadTreeNode.Nodes.Add(new QuadTreeNode(Range.From(new Position(row + rowsCount, column + columnsCount), rowsCount, columnsCount), depth, quadTree));
		return quadTreeNode;
	}

	public bool IsProportionate(QuadTreeNode node)
	{
		if (node.Bounds.ColumnsCount * 2 >= node.Bounds.RowsCount)
		{
			return true;
		}
		return false;
	}

	public void CreateSubNodes(QuadTreeNode parentNode)
	{
		if (parentNode.Bounds.ColumnsCount * parentNode.Bounds.RowsCount > 10)
		{
			if (IsProportionate(parentNode))
			{
				Class76.smethod_115(this, parentNode);
			}
			else
			{
				Class76.smethod_7(parentNode, this);
			}
		}
	}
}
