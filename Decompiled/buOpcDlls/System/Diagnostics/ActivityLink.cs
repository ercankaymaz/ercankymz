using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Diagnostics;

[System_002EDiagnostics_002EDiagnosticSource_002EIsReadOnly]
[ComVisible(true)]
public struct ActivityLink(ActivityContext context, ActivityTagsCollection tags = null) : IEquatable<ActivityLink>
{
	public ActivityContext Context { get; } = context;

	[System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 2, 0, 1, 2 })]
	public IEnumerable<KeyValuePair<string, object>> Tags
	{
		[return: System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 2, 0, 1, 2 })]
		get;
	} = tags;

	[System_002EDiagnostics_002EDiagnosticSource_002ENullableContext(2)]
	public override bool Equals([System_002EDiagnostics_002EDiagnosticSource3462135_002ENotNullWhen(true)] object obj)
	{
		if (obj is ActivityLink value)
		{
			return Equals(value);
		}
		return false;
	}

	public bool Equals(ActivityLink value)
	{
		if (Context == value.Context)
		{
			return value.Tags == Tags;
		}
		return false;
	}

	public static bool operator ==(ActivityLink left, ActivityLink right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(ActivityLink left, ActivityLink right)
	{
		return !left.Equals(right);
	}

	public override int GetHashCode()
	{
		if (this == default(ActivityLink))
		{
			return 0;
		}
		int num = 5381;
		num = (num << 5) + num + Context.GetHashCode();
		if (Tags != null)
		{
			foreach (KeyValuePair<string, object> tag in Tags)
			{
				num = (num << 5) + num + tag.Key.GetHashCode();
				if (tag.Value != null)
				{
					num = (num << 5) + num + tag.Value.GetHashCode();
				}
			}
		}
		return num;
	}
}
