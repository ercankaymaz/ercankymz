namespace System.ServiceModel.Channels;

internal class ChannelDemuxerBindingElement : BindingElement
{
	private class CachedBindingContextState
	{
		public bool IsStateCached;

		public BindingParameterCollection CachedBindingParameters;

		public CachedBindingContextState()
		{
			CachedBindingParameters = new BindingParameterCollection();
		}
	}

	private ChannelDemuxer _demuxer;

	private CachedBindingContextState _cachedContextState;

	private bool _cacheContextState;

	public TimeSpan PeekTimeout
	{
		get
		{
			return _demuxer.PeekTimeout;
		}
		set
		{
			if (value < TimeSpan.Zero && value != ChannelDemuxer.UseDefaultReceiveTimeout)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value"));
			}
			_demuxer.PeekTimeout = value;
		}
	}

	public int MaxPendingSessions
	{
		get
		{
			return _demuxer.MaxPendingSessions;
		}
		set
		{
			if (value < 1)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", System.SR.ValueMustBeGreaterThanZero));
			}
			_demuxer.MaxPendingSessions = value;
		}
	}

	public ChannelDemuxerBindingElement(bool cacheContextState)
	{
		_cacheContextState = cacheContextState;
		if (cacheContextState)
		{
			_cachedContextState = new CachedBindingContextState();
		}
		_demuxer = new ChannelDemuxer();
	}

	public ChannelDemuxerBindingElement(ChannelDemuxerBindingElement element)
	{
		_demuxer = element._demuxer;
		_cacheContextState = element._cacheContextState;
		_cachedContextState = element._cachedContextState;
	}

	private void SubstituteCachedBindingContextParametersIfNeeded(BindingContext context)
	{
		if (!_cacheContextState)
		{
			return;
		}
		if (!_cachedContextState.IsStateCached)
		{
			foreach (object bindingParameter in context.BindingParameters)
			{
				_cachedContextState.CachedBindingParameters.Add(bindingParameter);
			}
			_cachedContextState.IsStateCached = true;
			return;
		}
		context.BindingParameters.Clear();
		foreach (object cachedBindingParameter in _cachedContextState.CachedBindingParameters)
		{
			context.BindingParameters.Add(cachedBindingParameter);
		}
	}

	public override IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingContext context)
	{
		if (context == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("context");
		}
		SubstituteCachedBindingContextParametersIfNeeded(context);
		return context.BuildInnerChannelFactory<TChannel>();
	}

	public override bool CanBuildChannelFactory<TChannel>(BindingContext context)
	{
		if (context == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("context");
		}
		return context.CanBuildInnerChannelFactory<TChannel>();
	}

	public override BindingElement Clone()
	{
		return new ChannelDemuxerBindingElement(this);
	}

	public override T GetProperty<T>(BindingContext context)
	{
		if (_cacheContextState && _cachedContextState.IsStateCached)
		{
			for (int i = 0; i < _cachedContextState.CachedBindingParameters.Count; i++)
			{
				if (!context.BindingParameters.Contains(_cachedContextState.CachedBindingParameters[i].GetType()))
				{
					context.BindingParameters.Add(_cachedContextState.CachedBindingParameters[i]);
				}
			}
		}
		return context.GetInnerProperty<T>();
	}
}
