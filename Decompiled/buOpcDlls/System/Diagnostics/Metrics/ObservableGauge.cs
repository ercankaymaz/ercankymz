using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Diagnostics.Metrics;

[SecuritySafeCritical]
[ComVisible(true)]
public sealed class ObservableGauge<T> : ObservableInstrument<T> where T : struct
{
	private object _callback;

	internal ObservableGauge(Meter meter, string name, Func<T> observeValue, string unit, string description)
		: base(meter, name, unit, description)
	{
		if (observeValue == null)
		{
			throw new ArgumentNullException("observeValue");
		}
		_callback = observeValue;
		Publish();
	}

	internal ObservableGauge(Meter meter, string name, Func<Measurement<T>> observeValue, string unit, string description)
		: base(meter, name, unit, description)
	{
		if (observeValue == null)
		{
			throw new ArgumentNullException("observeValue");
		}
		_callback = observeValue;
		Publish();
	}

	internal ObservableGauge(Meter meter, string name, Func<IEnumerable<Measurement<T>>> observeValues, string unit, string description)
		: base(meter, name, unit, description)
	{
		if (observeValues == null)
		{
			throw new ArgumentNullException("observeValues");
		}
		_callback = observeValues;
		Publish();
	}

	[return: System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 1, 0, 0 })]
	protected override IEnumerable<Measurement<T>> Observe()
	{
		return Observe(_callback);
	}
}
