using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Serialization;

[Newtonsoft_002EJson_002ENullableContext(1)]
public interface ITraceWriter
{
	TraceLevel LevelFilter { get; }

	void Trace(TraceLevel level, string message, [Newtonsoft_002EJson_002ENullable(2)] Exception ex);
}
