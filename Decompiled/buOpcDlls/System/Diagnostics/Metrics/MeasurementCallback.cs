using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Diagnostics.Metrics;

[ComVisible(true)]
public delegate void MeasurementCallback<T>([System_002EDiagnostics_002EDiagnosticSource_002ENullable(1)] Instrument instrument, T measurement, [System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 0, 0, 1, 2 })] ReadOnlySpan<KeyValuePair<string, object>> tags, [System_002EDiagnostics_002EDiagnosticSource_002ENullable(2)] object state) where T : struct;
