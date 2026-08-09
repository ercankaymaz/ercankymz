using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using System.ServiceModel.Channels;
using System.Threading;
using System.Threading.Tasks;

namespace System.ServiceModel;

internal class ServiceChannelManager : LifetimeManager
{
	internal class ChannelCollection : ICollection<IChannel>, IEnumerable<IChannel>, IEnumerable
	{
		private ServiceChannelManager _channelManager;

		private object _syncRoot;

		private HashSet<IChannel> _hashSet = new HashSet<IChannel>();

		public bool IsReadOnly => false;

		public int Count
		{
			get
			{
				lock (_syncRoot)
				{
					return _hashSet.Count;
				}
			}
		}

		public ChannelCollection(ServiceChannelManager channelManager, object syncRoot)
		{
			_channelManager = channelManager;
			_syncRoot = syncRoot ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("syncRoot"));
		}

		public void Add(IChannel channel)
		{
			lock (_syncRoot)
			{
				if (_hashSet.Add(channel))
				{
					_channelManager.ChannelAdded(channel);
				}
			}
		}

		public void Clear()
		{
			lock (_syncRoot)
			{
				foreach (IChannel item in _hashSet)
				{
					_channelManager.ChannelRemoved(item);
				}
				_hashSet.Clear();
			}
		}

		public bool Contains(IChannel channel)
		{
			lock (_syncRoot)
			{
				if (channel != null)
				{
					return _hashSet.Contains(channel);
				}
				return false;
			}
		}

		public void CopyTo(IChannel[] array, int arrayIndex)
		{
			lock (_syncRoot)
			{
				_hashSet.CopyTo(array, arrayIndex);
			}
		}

		public bool Remove(IChannel channel)
		{
			lock (_syncRoot)
			{
				bool flag = false;
				if (channel != null)
				{
					flag = _hashSet.Remove(channel);
					if (flag)
					{
						_channelManager.ChannelRemoved(channel);
					}
				}
				return flag;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			lock (_syncRoot)
			{
				return _hashSet.GetEnumerator();
			}
		}

		IEnumerator<IChannel> IEnumerable<IChannel>.GetEnumerator()
		{
			lock (_syncRoot)
			{
				return _hashSet.GetEnumerator();
			}
		}
	}

	private ICommunicationWaiter _activityWaiter;

	private int _activityWaiterCount;

	private IChannel _firstIncomingChannel;

	private ChannelCollection _incomingChannels;

	private ChannelCollection _outgoingChannels;

	public int ActivityCount { get; private set; }

	public ICollection<IChannel> IncomingChannels
	{
		get
		{
			EnsureIncomingChannelCollection();
			return _incomingChannels;
		}
	}

	public ICollection<IChannel> OutgoingChannels
	{
		get
		{
			if (_outgoingChannels == null)
			{
				lock (base.ThisLock)
				{
					if (_outgoingChannels == null)
					{
						_outgoingChannels = new ChannelCollection(this, base.ThisLock);
					}
				}
			}
			return _outgoingChannels;
		}
	}

	public ServiceChannelManager(InstanceContext instanceContext)
		: base(instanceContext.ThisLock)
	{
	}

	private void ChannelAdded(IChannel channel)
	{
		base.IncrementBusyCount();
		channel.Closed += OnChannelClosed;
	}

	private void ChannelRemoved(IChannel channel)
	{
		channel.Closed -= OnChannelClosed;
		DecrementBusyCount();
	}

	public void CloseInput(TimeSpan timeout)
	{
		AsyncCommunicationWaiter asyncCommunicationWaiter = null;
		lock (base.ThisLock)
		{
			if (ActivityCount > 0)
			{
				asyncCommunicationWaiter = (AsyncCommunicationWaiter)(_activityWaiter = new AsyncCommunicationWaiter(base.ThisLock));
				Interlocked.Increment(ref _activityWaiterCount);
			}
		}
		if (asyncCommunicationWaiter != null)
		{
			CommunicationWaitResult communicationWaitResult = asyncCommunicationWaiter.Wait(timeout, aborting: false);
			if (Interlocked.Decrement(ref _activityWaiterCount) == 0)
			{
				asyncCommunicationWaiter.Dispose();
				_activityWaiter = null;
			}
			switch (communicationWaitResult)
			{
			case CommunicationWaitResult.Expired:
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new TimeoutException(System.SR.SfxCloseTimedOutWaitingForDispatchToComplete));
			case CommunicationWaitResult.Aborted:
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ObjectDisposedException(GetType().ToString()));
			}
		}
	}

	public async Task CloseInputAsync(TimeSpan timeout)
	{
		AsyncCommunicationWaiter activityWaiter = null;
		lock (base.ThisLock)
		{
			if (ActivityCount > 0)
			{
				activityWaiter = (AsyncCommunicationWaiter)(_activityWaiter = new AsyncCommunicationWaiter(base.ThisLock));
				Interlocked.Increment(ref _activityWaiterCount);
			}
		}
		if (activityWaiter != null)
		{
			CommunicationWaitResult communicationWaitResult = await activityWaiter.WaitAsync(timeout, aborting: false);
			if (Interlocked.Decrement(ref _activityWaiterCount) == 0)
			{
				activityWaiter.Dispose();
				_activityWaiter = null;
			}
			switch (communicationWaitResult)
			{
			case CommunicationWaitResult.Expired:
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new TimeoutException(System.SR.SfxCloseTimedOutWaitingForDispatchToComplete));
			case CommunicationWaitResult.Aborted:
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ObjectDisposedException(GetType().ToString()));
			}
		}
	}

	public void DecrementActivityCount()
	{
		ICommunicationWaiter communicationWaiter = null;
		bool flag = false;
		lock (base.ThisLock)
		{
			if (--ActivityCount == 0)
			{
				if (_activityWaiter != null)
				{
					communicationWaiter = _activityWaiter;
					Interlocked.Increment(ref _activityWaiterCount);
				}
				if (base.BusyCount == 0)
				{
					flag = true;
				}
			}
		}
		if (communicationWaiter != null)
		{
			communicationWaiter.Signal();
			if (Interlocked.Decrement(ref _activityWaiterCount) == 0)
			{
				communicationWaiter.Dispose();
				_activityWaiter = null;
			}
		}
		if (flag && base.State == LifetimeState.Opened)
		{
			OnEmpty();
		}
	}

	private void EnsureIncomingChannelCollection()
	{
		lock (base.ThisLock)
		{
			if (_incomingChannels == null)
			{
				_incomingChannels = new ChannelCollection(this, base.ThisLock);
				if (_firstIncomingChannel != null)
				{
					_incomingChannels.Add(_firstIncomingChannel);
					ChannelRemoved(_firstIncomingChannel);
					_firstIncomingChannel = null;
				}
			}
		}
	}

	public void IncrementActivityCount()
	{
		lock (base.ThisLock)
		{
			if (base.State == LifetimeState.Closed)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ObjectDisposedException(GetType().ToString()));
			}
			ActivityCount++;
		}
	}

	protected override void IncrementBusyCount()
	{
		base.IncrementBusyCount();
	}

	protected override void OnAbort()
	{
		IChannel[] array = SnapshotChannels();
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Abort();
		}
		ICommunicationWaiter communicationWaiter = null;
		lock (base.ThisLock)
		{
			if (_activityWaiter != null)
			{
				communicationWaiter = _activityWaiter;
				Interlocked.Increment(ref _activityWaiterCount);
			}
		}
		if (communicationWaiter != null)
		{
			communicationWaiter.Signal();
			if (Interlocked.Decrement(ref _activityWaiterCount) == 0)
			{
				communicationWaiter.Dispose();
				_activityWaiter = null;
			}
		}
		base.OnAbort();
	}

	protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
	{
		return OnCloseAsync(timeout).ToApm(callback, state);
	}

	protected override void OnClose(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		CloseInput(timeoutHelper.RemainingTime());
		base.OnClose(timeoutHelper.RemainingTime());
	}

	protected override async Task OnCloseAsync(TimeSpan timeout)
	{
		TimeoutHelper timeoutHelper = new TimeoutHelper(timeout);
		await CloseInputAsync(timeoutHelper.RemainingTime());
		await base.OnCloseAsync(timeoutHelper.RemainingTime());
	}

	protected override void OnEndClose(IAsyncResult result)
	{
		result.ToApmEnd();
	}

	private void OnChannelClosed(object sender, EventArgs args)
	{
		RemoveChannel((IChannel)sender);
	}

	public bool RemoveChannel(IChannel channel)
	{
		lock (base.ThisLock)
		{
			if (_firstIncomingChannel == channel)
			{
				_firstIncomingChannel = null;
				ChannelRemoved(channel);
				return true;
			}
			if (_incomingChannels != null && _incomingChannels.Contains(channel))
			{
				_incomingChannels.Remove(channel);
				return true;
			}
			if (_outgoingChannels != null && _outgoingChannels.Contains(channel))
			{
				_outgoingChannels.Remove(channel);
				return true;
			}
		}
		return false;
	}

	public IChannel[] SnapshotChannels()
	{
		lock (base.ThisLock)
		{
			int num = ((_outgoingChannels != null) ? _outgoingChannels.Count : 0);
			if (_firstIncomingChannel != null)
			{
				IChannel[] array = new IChannel[1 + num];
				array[0] = _firstIncomingChannel;
				if (num > 0)
				{
					_outgoingChannels.CopyTo(array, 1);
				}
				return array;
			}
			if (_incomingChannels != null)
			{
				IChannel[] array2 = new IChannel[_incomingChannels.Count + num];
				_incomingChannels.CopyTo(array2, 0);
				if (num > 0)
				{
					_outgoingChannels.CopyTo(array2, _incomingChannels.Count);
				}
				return array2;
			}
			if (num > 0)
			{
				IChannel[] array3 = new IChannel[num];
				_outgoingChannels.CopyTo(array3, 0);
				return array3;
			}
		}
		return Array.Empty<IChannel>();
	}
}
