using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml;

namespace System.ServiceModel.Description;

public class ServiceEndpointCollection : Collection<ServiceEndpoint>
{
	internal ServiceEndpointCollection()
	{
	}

	public ServiceEndpoint Find(Type contractType)
	{
		if (contractType == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("contractType");
		}
		using (IEnumerator<ServiceEndpoint> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ServiceEndpoint current = enumerator.Current;
				if (current != null && current.Contract.ContractType == contractType)
				{
					return current;
				}
			}
		}
		return null;
	}

	public ServiceEndpoint Find(XmlQualifiedName contractName)
	{
		if (contractName == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("contractName");
		}
		using (IEnumerator<ServiceEndpoint> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ServiceEndpoint current = enumerator.Current;
				if (current != null && current.Contract.Name == contractName.Name && current.Contract.Namespace == contractName.Namespace)
				{
					return current;
				}
			}
		}
		return null;
	}

	public ServiceEndpoint Find(Type contractType, XmlQualifiedName bindingName)
	{
		if (contractType == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("contractType");
		}
		if (bindingName == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("bindingName");
		}
		using (IEnumerator<ServiceEndpoint> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ServiceEndpoint current = enumerator.Current;
				if (current != null && current.Contract.ContractType == contractType && current.Binding.Name == bindingName.Name && current.Binding.Namespace == bindingName.Namespace)
				{
					return current;
				}
			}
		}
		return null;
	}

	public ServiceEndpoint Find(XmlQualifiedName contractName, XmlQualifiedName bindingName)
	{
		if (contractName == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("contractName");
		}
		if (bindingName == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("bindingName");
		}
		using (IEnumerator<ServiceEndpoint> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ServiceEndpoint current = enumerator.Current;
				if (current != null && current.Contract.Name == contractName.Name && current.Contract.Namespace == contractName.Namespace && current.Binding.Name == bindingName.Name && current.Binding.Namespace == bindingName.Namespace)
				{
					return current;
				}
			}
		}
		return null;
	}

	public ServiceEndpoint Find(Uri address)
	{
		if (address == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("address");
		}
		using (IEnumerator<ServiceEndpoint> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				ServiceEndpoint current = enumerator.Current;
				if (current != null && current.Address.Uri == address)
				{
					return current;
				}
			}
		}
		return null;
	}

	public Collection<ServiceEndpoint> FindAll(Type contractType)
	{
		if (contractType == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("contractType");
		}
		Collection<ServiceEndpoint> collection = new Collection<ServiceEndpoint>();
		using IEnumerator<ServiceEndpoint> enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			ServiceEndpoint current = enumerator.Current;
			if (current != null && current.Contract.ContractType == contractType)
			{
				collection.Add(current);
			}
		}
		return collection;
	}

	public Collection<ServiceEndpoint> FindAll(XmlQualifiedName contractName)
	{
		if (contractName == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("contractName");
		}
		Collection<ServiceEndpoint> collection = new Collection<ServiceEndpoint>();
		using IEnumerator<ServiceEndpoint> enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			ServiceEndpoint current = enumerator.Current;
			if (current != null && current.Contract.Name == contractName.Name && current.Contract.Namespace == contractName.Namespace)
			{
				collection.Add(current);
			}
		}
		return collection;
	}

	protected override void InsertItem(int index, ServiceEndpoint item)
	{
		if (item == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("item");
		}
		base.InsertItem(index, item);
	}

	protected override void SetItem(int index, ServiceEndpoint item)
	{
		if (item == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("item");
		}
		base.SetItem(index, item);
	}
}
