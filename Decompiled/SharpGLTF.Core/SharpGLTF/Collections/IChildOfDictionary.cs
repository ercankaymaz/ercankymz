namespace SharpGLTF.Collections;

public interface IChildOfDictionary<TParent> where TParent : class
{
	TParent LogicalParent { get; }

	string LogicalKey { get; }

	void SetLogicalParent(TParent parent, string key);
}
