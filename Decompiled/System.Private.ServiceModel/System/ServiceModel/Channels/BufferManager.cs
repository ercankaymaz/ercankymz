using System.Runtime;

namespace System.ServiceModel.Channels;

public abstract class BufferManager
{
	internal class WrappingBufferManager : BufferManager
	{
		public InternalBufferManager InternalBufferManager { get; }

		public WrappingBufferManager(InternalBufferManager innerBufferManager)
		{
			InternalBufferManager = innerBufferManager;
		}

		public override byte[] TakeBuffer(int bufferSize)
		{
			if (bufferSize < 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("bufferSize", bufferSize, System.SR.ValueMustBeNonNegative));
			}
			return InternalBufferManager.TakeBuffer(bufferSize);
		}

		public override void ReturnBuffer(byte[] buffer)
		{
			if (buffer == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("buffer");
			}
			InternalBufferManager.ReturnBuffer(buffer);
		}

		public override void Clear()
		{
			InternalBufferManager.Clear();
		}
	}

	internal class WrappingInternalBufferManager : InternalBufferManager
	{
		private BufferManager _innerBufferManager;

		public WrappingInternalBufferManager(BufferManager innerBufferManager)
		{
			_innerBufferManager = innerBufferManager;
		}

		public override void Clear()
		{
			_innerBufferManager.Clear();
		}

		public override void ReturnBuffer(byte[] buffer)
		{
			_innerBufferManager.ReturnBuffer(buffer);
		}

		public override byte[] TakeBuffer(int bufferSize)
		{
			return _innerBufferManager.TakeBuffer(bufferSize);
		}
	}

	public abstract byte[] TakeBuffer(int bufferSize);

	public abstract void ReturnBuffer(byte[] buffer);

	public abstract void Clear();

	public static BufferManager CreateBufferManager(long maxBufferPoolSize, int maxBufferSize)
	{
		if (maxBufferPoolSize < 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("maxBufferPoolSize", maxBufferPoolSize, System.SR.ValueMustBeNonNegative));
		}
		if (maxBufferSize < 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("maxBufferSize", maxBufferSize, System.SR.ValueMustBeNonNegative));
		}
		return new WrappingBufferManager(InternalBufferManager.Create(maxBufferPoolSize, maxBufferSize));
	}

	internal static InternalBufferManager GetInternalBufferManager(BufferManager bufferManager)
	{
		if (bufferManager is WrappingBufferManager)
		{
			return ((WrappingBufferManager)bufferManager).InternalBufferManager;
		}
		return new WrappingInternalBufferManager(bufferManager);
	}
}
