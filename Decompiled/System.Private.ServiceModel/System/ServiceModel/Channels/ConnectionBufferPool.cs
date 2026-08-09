using System.Runtime;

namespace System.ServiceModel.Channels;

internal class ConnectionBufferPool : QueuedObjectPool<byte[]>
{
	private const int SingleBatchSize = 131072;

	private const int MaxBatchCount = 16;

	private const int MaxFreeCountFactor = 4;

	public int BufferSize { get; private set; }

	public ConnectionBufferPool(int bufferSize)
	{
		int num = ComputeBatchCount(bufferSize);
		Initialize(bufferSize, num, num * 4);
	}

	public ConnectionBufferPool(int bufferSize, int maxFreeCount)
	{
		Initialize(bufferSize, ComputeBatchCount(bufferSize), maxFreeCount);
	}

	private void Initialize(int bufferSize, int batchCount, int maxFreeCount)
	{
		BufferSize = bufferSize;
		if (maxFreeCount < batchCount)
		{
			maxFreeCount = batchCount;
		}
		Initialize(batchCount, maxFreeCount);
	}

	protected override byte[] Create()
	{
		return Fx.AllocateByteArray(BufferSize);
	}

	private static int ComputeBatchCount(int bufferSize)
	{
		int num;
		if (bufferSize != 0)
		{
			num = (131072 + bufferSize - 1) / bufferSize;
			if (num > 16)
			{
				num = 16;
			}
		}
		else
		{
			num = 16;
		}
		return num;
	}
}
