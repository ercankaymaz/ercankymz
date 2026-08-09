using System;
using System.Runtime.Serialization;

namespace MathNet.Numerics;

[Serializable]
public class MemoryAllocationException : NativeInterfaceException
{
	public MemoryAllocationException()
		: base("Unable to allocate native memory.")
	{
	}

	public MemoryAllocationException(Exception innerException)
		: base("Unable to allocate native memory.", innerException)
	{
	}

	protected MemoryAllocationException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
