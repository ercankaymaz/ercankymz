using System.Collections.Generic;

namespace System.ComponentModel.Composition;

public class ChangeRejectedException : CompositionException
{
	public override string Message => System.SR.Format(System.SR.CompositionException_ChangesRejected, base.Message);

	public ChangeRejectedException()
		: this(null, null)
	{
	}

	public ChangeRejectedException(string? message)
		: this(message, null)
	{
	}

	public ChangeRejectedException(string? message, Exception? innerException)
		: base(message, innerException, null)
	{
	}

	public ChangeRejectedException(IEnumerable<CompositionError>? errors)
		: base(null, null, errors)
	{
	}
}
