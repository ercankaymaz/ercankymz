namespace QuadTreeLib;

public interface IQuadTreeNodeDivider
{
	void CreateSubNodes(QuadTreeNode parentNode);

	QuadTreeNode CreateNewRoot(QuadTreeNode currentRoot);
}
