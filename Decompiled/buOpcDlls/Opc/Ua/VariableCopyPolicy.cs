using System;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[Flags]
[ComVisible(true)]
public enum VariableCopyPolicy
{
	CopyOnRead = 1,
	CopyOnWrite = 2,
	Never = 0,
	Always = 3
}
