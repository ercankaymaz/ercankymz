namespace System.ServiceModel.Channels;

[Flags]
internal enum MaskingMode
{
	None = 0,
	Handled = 1,
	Unhandled = 2,
	All = 3
}
