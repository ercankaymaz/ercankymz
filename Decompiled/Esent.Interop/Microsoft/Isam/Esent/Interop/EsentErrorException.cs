using System;
using System.Runtime.Serialization;

namespace Microsoft.Isam.Esent.Interop;

[Serializable]
public class EsentErrorException : EsentException
{
	private JET_err errorCode;

	public JET_err Error => errorCode;

	internal EsentErrorException(string message, JET_err err)
		: base(message)
	{
		errorCode = err;
	}

	protected EsentErrorException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		errorCode = (JET_err)info.GetInt32("errorCode");
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info?.AddValue("errorCode", errorCode, typeof(int));
	}
}
