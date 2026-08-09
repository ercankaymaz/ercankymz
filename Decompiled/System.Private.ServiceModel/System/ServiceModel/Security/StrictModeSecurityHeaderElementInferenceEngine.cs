using System.Xml;

namespace System.ServiceModel.Security;

internal sealed class StrictModeSecurityHeaderElementInferenceEngine : SecurityHeaderElementInferenceEngine
{
	internal static StrictModeSecurityHeaderElementInferenceEngine Instance { get; } = new StrictModeSecurityHeaderElementInferenceEngine();

	private StrictModeSecurityHeaderElementInferenceEngine()
	{
	}

	public override void ExecuteProcessingPasses(ReceiveSecurityHeader securityHeader, XmlDictionaryReader reader)
	{
		securityHeader.ExecuteFullPass(reader);
	}

	public override void MarkElements(ReceiveSecurityHeaderElementManager elementManager, bool messageSecurityMode)
	{
		bool flag = false;
		for (int i = 0; i < elementManager.Count; i++)
		{
			elementManager.GetElementEntry(i, out var element);
			if (element._elementCategory == ReceiveSecurityHeaderElementCategory.Signature)
			{
				if (!messageSecurityMode || flag)
				{
					elementManager.SetBindingMode(i, ReceiveSecurityHeaderBindingModes.Endorsing);
					continue;
				}
				elementManager.SetBindingMode(i, ReceiveSecurityHeaderBindingModes.Primary);
				flag = true;
			}
		}
	}
}
