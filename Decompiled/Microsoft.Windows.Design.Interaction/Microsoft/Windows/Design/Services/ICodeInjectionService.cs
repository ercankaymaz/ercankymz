using System.CodeDom;

namespace Microsoft.Windows.Design.Services;

public interface ICodeInjectionService
{
	bool CreateMethod(CodeMemberMethod method);

	void AppendStatements(CodeMemberMethod method, CodeStatementCollection statements, int relativePosition);
}
