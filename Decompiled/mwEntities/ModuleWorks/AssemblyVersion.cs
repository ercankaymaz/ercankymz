using System;

namespace ModuleWorks;

[AttributeUsage(AttributeTargets.Assembly)]
public class AssemblyVersion : Attribute
{
	public string CommitHash { get; }

	public string BranchName { get; }

	[Obsolete("Deprecated since Release 2022.12. Please use CommitHash or CommitAuthorTime instead.")]
	public int Revision => CommitAuthorTime;

	public int CommitAuthorTime { get; }

	public AssemblyVersion(string commitHash, string branchName, int commitAuthorTime)
	{
		CommitHash = commitHash;
		BranchName = branchName;
		CommitAuthorTime = commitAuthorTime;
	}
}
