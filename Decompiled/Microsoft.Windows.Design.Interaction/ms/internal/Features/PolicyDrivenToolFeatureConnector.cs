using Microsoft.Windows.Design;
using Microsoft.Windows.Design.Features;
using Microsoft.Windows.Design.Interaction;
using Microsoft.Windows.Design.Policies;

namespace MS.Internal.Features;

internal abstract class PolicyDrivenToolFeatureConnector<FeatureProviderType> : PolicyDrivenFeatureConnector<FeatureProviderType> where FeatureProviderType : FeatureProvider
{
	private Tool _currentTool;

	protected Tool CurrentTool => _currentTool;

	protected PolicyDrivenToolFeatureConnector(FeatureManager manager)
		: base(manager)
	{
		ContextItemManager items = base.Context.Items;
		SubscribeContextCallback<Tool> callback = delegate(Tool newTool)
		{
			UpdateCurrentTool(newTool);
		};
		items.Subscribe(callback);
	}

	protected virtual void UpdateCurrentTool(Tool newTool)
	{
		if (_currentTool != newTool)
		{
			_currentTool = newTool;
			UpdateFeatureProviders();
		}
	}
}
