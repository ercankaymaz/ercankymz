using System.Threading.Tasks;

namespace System.ServiceModel.Security;

internal interface ISecurityCommunicationObject
{
	TimeSpan DefaultOpenTimeout { get; }

	TimeSpan DefaultCloseTimeout { get; }

	void OnAbort();

	Task OnCloseAsync(TimeSpan timeout);

	void OnClosed();

	void OnClosing();

	void OnFaulted();

	Task OnOpenAsync(TimeSpan timeout);

	void OnOpened();

	void OnOpening();
}
