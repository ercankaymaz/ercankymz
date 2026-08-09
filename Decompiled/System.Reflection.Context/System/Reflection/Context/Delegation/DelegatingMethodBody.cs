using System.Collections.Generic;

namespace System.Reflection.Context.Delegation;

internal class DelegatingMethodBody : MethodBody
{
	private readonly MethodBody _body;

	public override IList<ExceptionHandlingClause> ExceptionHandlingClauses => _body.ExceptionHandlingClauses;

	public override bool InitLocals => _body.InitLocals;

	public override int LocalSignatureMetadataToken => _body.LocalSignatureMetadataToken;

	public override IList<LocalVariableInfo> LocalVariables => _body.LocalVariables;

	public override int MaxStackSize => _body.MaxStackSize;

	public DelegatingMethodBody(MethodBody body)
	{
		_body = body;
	}

	public override byte[] GetILAsByteArray()
	{
		return _body.GetILAsByteArray();
	}

	public override string ToString()
	{
		return _body.ToString();
	}
}
