namespace SharpGLTF.Collections;

public interface IChildOf<TParent> where TParent : class
{
	TParent LogicalParent { get; }

	void SetLogicalParent(TParent parent);
}
