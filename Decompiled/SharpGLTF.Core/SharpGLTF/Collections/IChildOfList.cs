namespace SharpGLTF.Collections;

public interface IChildOfList<TParent> where TParent : class
{
	TParent LogicalParent { get; }

	int LogicalIndex { get; }

	void SetLogicalParent(TParent parent, int index);
}
