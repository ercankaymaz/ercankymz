using System.Collections.Generic;

namespace System.ServiceModel.Channels;

public class CustomBinding : Binding
{
	public BindingElementCollection Elements { get; } = new BindingElementCollection();

	public override string Scheme
	{
		get
		{
			TransportBindingElement transportBindingElement = Elements.Find<TransportBindingElement>();
			if (transportBindingElement == null)
			{
				return string.Empty;
			}
			return transportBindingElement.Scheme;
		}
	}

	public CustomBinding()
	{
	}

	public CustomBinding(params BindingElement[] bindingElementsInTopDownChannelStackOrder)
	{
		if (bindingElementsInTopDownChannelStackOrder == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("bindingElementsInTopDownChannelStackOrder");
		}
		foreach (BindingElement item in bindingElementsInTopDownChannelStackOrder)
		{
			Elements.Add(item);
		}
	}

	public CustomBinding(string name, string ns, params BindingElement[] bindingElementsInTopDownChannelStackOrder)
		: base(name, ns)
	{
		if (bindingElementsInTopDownChannelStackOrder == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("bindingElementsInTopDownChannelStackOrder");
		}
		foreach (BindingElement item in bindingElementsInTopDownChannelStackOrder)
		{
			Elements.Add(item);
		}
	}

	public CustomBinding(IEnumerable<BindingElement> bindingElementsInTopDownChannelStackOrder)
	{
		if (bindingElementsInTopDownChannelStackOrder == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("bindingElementsInTopDownChannelStackOrder");
		}
		foreach (BindingElement item in bindingElementsInTopDownChannelStackOrder)
		{
			Elements.Add(item);
		}
	}

	internal CustomBinding(BindingElementCollection bindingElements)
	{
		if (bindingElements == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("bindingElements");
		}
		for (int i = 0; i < bindingElements.Count; i++)
		{
			Elements.Add(bindingElements[i]);
		}
	}

	public CustomBinding(Binding binding)
		: this(binding, SafeCreateBindingElements(binding))
	{
	}

	private static BindingElementCollection SafeCreateBindingElements(Binding binding)
	{
		if (binding == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("binding");
		}
		return binding.CreateBindingElements();
	}

	internal CustomBinding(Binding binding, BindingElementCollection elements)
	{
		if (binding == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("binding");
		}
		if (elements == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("elements");
		}
		base.Name = binding.Name;
		base.Namespace = binding.Namespace;
		base.CloseTimeout = binding.CloseTimeout;
		base.OpenTimeout = binding.OpenTimeout;
		base.ReceiveTimeout = binding.ReceiveTimeout;
		base.SendTimeout = binding.SendTimeout;
		for (int i = 0; i < elements.Count; i++)
		{
			Elements.Add(elements[i]);
		}
	}

	public override BindingElementCollection CreateBindingElements()
	{
		return Elements.Clone();
	}
}
