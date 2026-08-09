using System;
using devDept.Geometry.Blink.Message;

namespace devDept.Geometry.Blink;

internal class BlinkServerArgs : EventArgs
{
	public BlinkMsg[] Messages;

	public Exception Exception;

	public BlinkServerArgs(BlinkMsg[] messages)
	{
		Messages = messages;
	}

	public BlinkServerArgs(Exception ex)
	{
		Exception = ex;
	}
}
