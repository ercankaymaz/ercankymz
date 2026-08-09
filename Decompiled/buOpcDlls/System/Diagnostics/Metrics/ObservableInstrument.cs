using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Diagnostics.Metrics;

[SecuritySafeCritical]
[ComVisible(true)]
public abstract class ObservableInstrument<T> : Instrument where T : struct
{
	public override bool IsObservable => true;

	[System_002EDiagnostics_002EDiagnosticSource_002ENullableContext(1)]
	protected ObservableInstrument(Meter meter, string name, [System_002EDiagnostics_002EDiagnosticSource_002ENullable(2)] string unit, [System_002EDiagnostics_002EDiagnosticSource_002ENullable(2)] string description)
		: base(meter, name, unit, description)
	{
		Instrument.ValidateTypeParameter<T>();
	}

	[return: System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 1, 0, 0 })]
	protected abstract IEnumerable<Measurement<T>> Observe();

	[SecuritySafeCritical]
	internal override void Observe(MeterListener listener)
	{
		object subscriptionState = GetSubscriptionState(listener);
		IEnumerable<Measurement<T>> enumerable = Observe();
		if (enumerable == null)
		{
			return;
		}
		foreach (Measurement<T> item in enumerable)
		{
			listener.NotifyMeasurement(this, item.Value, item.Tags, subscriptionState);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal IEnumerable<Measurement<T>> Observe(object callback)
	{
		if (callback is Func<T> func)
		{
			return new Measurement<T>[1]
			{
				new Measurement<T>(func())
			};
		}
		if (callback is Func<Measurement<T>> func2)
		{
			return new Measurement<T>[1] { func2() };
		}
		if (callback is Func<IEnumerable<Measurement<T>>> func3)
		{
			return func3();
		}
		return null;
	}
}
