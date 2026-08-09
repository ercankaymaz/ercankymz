namespace System.ServiceModel.Dispatcher;

internal class SharedRuntimeState
{
	private bool _isImmutable;

	private bool _validateMustUnderstand = true;

	internal bool EnableFaults { get; set; } = true;

	internal bool IsOnServer { get; }

	internal bool ManualAddressing { get; set; }

	internal bool ValidateMustUnderstand
	{
		get
		{
			return _validateMustUnderstand;
		}
		set
		{
			_validateMustUnderstand = value;
		}
	}

	internal SharedRuntimeState(bool isOnServer)
	{
		IsOnServer = isOnServer;
	}

	internal void LockDownProperties()
	{
		_isImmutable = true;
	}

	internal void ThrowIfImmutable()
	{
		if (_isImmutable)
		{
			if (IsOnServer)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.SFxImmutableServiceHostBehavior0));
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.SFxImmutableChannelFactoryBehavior0));
		}
	}
}
