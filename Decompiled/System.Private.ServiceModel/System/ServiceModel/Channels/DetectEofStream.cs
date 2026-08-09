using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal abstract class DetectEofStream : DelegatingStream
{
	protected bool IsAtEof { get; private set; }

	protected DetectEofStream(Stream stream)
		: base(stream)
	{
		IsAtEof = false;
	}

	public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
	{
		if (IsAtEof)
		{
			return 0;
		}
		int num = await base.ReadAsync(buffer, offset, count, cancellationToken);
		if (num == 0)
		{
			ReceivedEof();
		}
		return num;
	}

	public override int ReadByte()
	{
		int num = base.ReadByte();
		if (num == -1)
		{
			ReceivedEof();
		}
		return num;
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		if (IsAtEof)
		{
			return 0;
		}
		int num = base.Read(buffer, offset, count);
		if (num == 0)
		{
			ReceivedEof();
		}
		return num;
	}

	private void ReceivedEof()
	{
		if (!IsAtEof)
		{
			IsAtEof = true;
			OnReceivedEof();
		}
	}

	protected virtual void OnReceivedEof()
	{
	}
}
