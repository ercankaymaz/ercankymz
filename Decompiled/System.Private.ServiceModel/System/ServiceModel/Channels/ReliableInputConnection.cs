using System.Runtime;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal sealed class ReliableInputConnection
{
	private bool _isLastKnown;

	private ReliableMessagingVersion _reliableMessagingVersion;

	private InterruptibleWaitObject _shutdownWaitObject = new InterruptibleWaitObject(signaled: false);

	private bool _terminated;

	private InterruptibleWaitObject _terminateWaitObject = new InterruptibleWaitObject(signaled: false, throwTimeoutByDefault: false);

	public bool AllAdded
	{
		get
		{
			if (Ranges.Count != 1 || Ranges[0].Lower != 1 || Ranges[0].Upper != Last)
			{
				return _isLastKnown;
			}
			return true;
		}
	}

	public bool IsLastKnown
	{
		get
		{
			if (Last == 0L)
			{
				return _isLastKnown;
			}
			return true;
		}
	}

	public bool IsSequenceClosed { get; private set; }

	public long Last { get; private set; }

	public SequenceRangeCollection Ranges { get; private set; } = SequenceRangeCollection.Empty;

	public ReliableMessagingVersion ReliableMessagingVersion
	{
		set
		{
			_reliableMessagingVersion = value;
		}
	}

	public void Abort(ChannelBase channel)
	{
		_shutdownWaitObject.Abort(channel);
		_terminateWaitObject.Abort(channel);
	}

	public bool CanMerge(long sequenceNumber)
	{
		return CanMerge(sequenceNumber, Ranges);
	}

	public static bool CanMerge(long sequenceNumber, SequenceRangeCollection ranges)
	{
		if (ranges.Count < ReliableMessagingConstants.MaxSequenceRanges)
		{
			return true;
		}
		ranges = ranges.MergeWith(sequenceNumber);
		return ranges.Count <= ReliableMessagingConstants.MaxSequenceRanges;
	}

	public void Fault(ChannelBase channel)
	{
		_shutdownWaitObject.Fault(channel);
		_terminateWaitObject.Fault(channel);
	}

	public bool IsValid(long sequenceNumber, bool isLast)
	{
		if (_reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessagingFebruary2005)
		{
			if (isLast)
			{
				if (Last == 0L)
				{
					if (Ranges.Count > 0)
					{
						return sequenceNumber > Ranges[Ranges.Count - 1].Upper;
					}
					return true;
				}
				return sequenceNumber == Last;
			}
			if (Last > 0)
			{
				return sequenceNumber < Last;
			}
		}
		else if (_isLastKnown)
		{
			return Ranges.Contains(sequenceNumber);
		}
		return true;
	}

	public void Merge(long sequenceNumber, bool isLast)
	{
		Ranges = Ranges.MergeWith(sequenceNumber);
		if (isLast)
		{
			Last = sequenceNumber;
		}
		if (AllAdded)
		{
			_shutdownWaitObject.Set();
		}
	}

	public bool SetCloseSequenceLast(long last)
	{
		WsrmUtilities.AssertWsrm11(_reliableMessagingVersion);
		bool flag = last < 1 || Ranges.Count == 0 || last >= Ranges[Ranges.Count - 1].Upper;
		if (flag)
		{
			IsSequenceClosed = true;
			SetLast(last);
		}
		return flag;
	}

	private void SetLast(long last)
	{
		if (_isLastKnown)
		{
			throw Fx.AssertAndThrow("Last can only be set once.");
		}
		Last = last;
		_isLastKnown = true;
		_shutdownWaitObject.Set();
	}

	public bool SetTerminateSequenceLast(long last, out bool isLastLargeEnough)
	{
		WsrmUtilities.AssertWsrm11(_reliableMessagingVersion);
		isLastLargeEnough = true;
		if (last < 1)
		{
			return false;
		}
		int count = Ranges.Count;
		long num = ((count > 0) ? Ranges[count - 1].Upper : 0);
		if (last < num)
		{
			isLastLargeEnough = false;
			return false;
		}
		if (count > 1 || last > num)
		{
			return false;
		}
		SetLast(last);
		return true;
	}

	public bool Terminate()
	{
		if (_reliableMessagingVersion == ReliableMessagingVersion.WSReliableMessagingFebruary2005 || IsSequenceClosed)
		{
			if (!_terminated && AllAdded)
			{
				_terminateWaitObject.Set();
				_terminated = true;
			}
			return _terminated;
		}
		return _isLastKnown;
	}

	public async Task CloseAsync(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		await _shutdownWaitObject.WaitAsync(timeoutHelper.RemainingTime());
		await _terminateWaitObject.WaitAsync(timeoutHelper.RemainingTime());
	}
}
