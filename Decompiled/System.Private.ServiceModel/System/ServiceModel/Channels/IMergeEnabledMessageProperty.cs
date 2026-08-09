namespace System.ServiceModel.Channels;

internal interface IMergeEnabledMessageProperty
{
	bool TryMergeWithProperty(object propertyToMerge);
}
