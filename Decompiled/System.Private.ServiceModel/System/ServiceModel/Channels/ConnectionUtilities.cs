namespace System.ServiceModel.Channels;

internal static class ConnectionUtilities
{
	internal static void CloseNoThrow(IConnection connection, TimeSpan timeout)
	{
		bool flag = false;
		try
		{
			connection.Close(timeout, asyncAndLinger: false);
			flag = true;
		}
		catch (TimeoutException)
		{
		}
		catch (CommunicationException)
		{
		}
		finally
		{
			if (!flag)
			{
				connection.Abort();
			}
		}
	}

	internal static void ValidateBufferBounds(ArraySegment<byte> buffer)
	{
		ValidateBufferBounds(buffer.Array, buffer.Offset, buffer.Count);
	}

	internal static void ValidateBufferBounds(byte[] buffer, int offset, int size)
	{
		if (buffer == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("buffer");
		}
		ValidateBufferBounds(buffer.Length, offset, size);
	}

	internal static void ValidateBufferBounds(int bufferSize, int offset, int size)
	{
		if (offset < 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("offset", offset, System.SR.ValueMustBeNonNegative));
		}
		if (offset > bufferSize)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("offset", offset, System.SR.Format(System.SR.OffsetExceedsBufferSize, bufferSize)));
		}
		if (size <= 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("size", size, System.SR.ValueMustBePositive));
		}
		int num = bufferSize - offset;
		if (size > num)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("size", size, System.SR.Format(System.SR.SizeExceedsRemainingBufferSpace, num)));
		}
	}
}
