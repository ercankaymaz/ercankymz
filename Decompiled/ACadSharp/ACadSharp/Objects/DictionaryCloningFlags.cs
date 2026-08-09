using System;

namespace ACadSharp.Objects;

[Flags]
public enum DictionaryCloningFlags : short
{
	NotApplicable = 0,
	KeepExisting = 1,
	UseClone = 2,
	XrefName = 3,
	Name = 4,
	UnmangleName = 5
}
