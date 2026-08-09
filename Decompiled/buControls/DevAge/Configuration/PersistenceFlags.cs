using System;

namespace DevAge.Configuration;

[Flags]
public enum PersistenceFlags
{
	None = 0,
	OnlyChanges = 1
}
