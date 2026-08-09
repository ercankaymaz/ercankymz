using System.Globalization;
using System.ServiceModel.Description;
using System.Text;

namespace System.ServiceModel.Channels;

public class BindingContext
{
	private BindingElementCollection _remainingBindingElements;

	public CustomBinding Binding { get; private set; }

	public BindingParameterCollection BindingParameters { get; private set; }

	public Uri ListenUriBaseAddress { get; set; }

	public ListenUriMode ListenUriMode { get; set; }

	public string ListenUriRelativeAddress { get; set; }

	public BindingElementCollection RemainingBindingElements => _remainingBindingElements;

	public BindingContext(CustomBinding binding, BindingParameterCollection parameters)
	{
		if (binding == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("binding");
		}
		Initialize(binding, binding.Elements, parameters);
	}

	private BindingContext(CustomBinding binding, BindingElementCollection remainingBindingElements, BindingParameterCollection parameters)
	{
		Initialize(binding, remainingBindingElements, parameters);
	}

	private void Initialize(CustomBinding binding, BindingElementCollection remainingBindingElements, BindingParameterCollection parameters)
	{
		Binding = binding;
		_remainingBindingElements = new BindingElementCollection(remainingBindingElements);
		BindingParameters = new BindingParameterCollection(parameters);
	}

	public IChannelFactory<TChannel> BuildInnerChannelFactory<TChannel>()
	{
		return RemoveNextElement().BuildChannelFactory<TChannel>(this);
	}

	public bool CanBuildInnerChannelFactory<TChannel>()
	{
		BindingContext bindingContext = Clone();
		return bindingContext.RemoveNextElement().CanBuildChannelFactory<TChannel>(bindingContext);
	}

	public T GetInnerProperty<T>() where T : class
	{
		if (_remainingBindingElements.Count == 0)
		{
			return null;
		}
		BindingContext bindingContext = Clone();
		return bindingContext.RemoveNextElement().GetProperty<T>(bindingContext);
	}

	public BindingContext Clone()
	{
		return new BindingContext(Binding, _remainingBindingElements, BindingParameters);
	}

	private BindingElement RemoveNextElement()
	{
		BindingElement bindingElement = _remainingBindingElements.Remove<BindingElement>();
		if (bindingElement != null)
		{
			return bindingElement;
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.NoChannelBuilderAvailable, Binding.Name, Binding.Namespace)));
	}

	internal void ValidateBindingElementsConsumed()
	{
		if (RemainingBindingElements.Count == 0)
		{
			return;
		}
		StringBuilder stringBuilder = new StringBuilder();
		foreach (BindingElement remainingBindingElement in RemainingBindingElements)
		{
			if (stringBuilder.Length > 0)
			{
				stringBuilder.Append(CultureInfo.CurrentCulture.TextInfo.ListSeparator);
				stringBuilder.Append(" ");
			}
			string text = remainingBindingElement.GetType().ToString();
			stringBuilder.Append(text.Substring(text.LastIndexOf('.') + 1));
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.NotAllBindingElementsBuilt, stringBuilder.ToString())));
	}
}
