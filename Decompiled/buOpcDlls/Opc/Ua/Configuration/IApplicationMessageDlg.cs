using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Opc.Ua.Configuration;

[ComVisible(true)]
public abstract class IApplicationMessageDlg
{
	public abstract void Message(string text, bool ask = false);

	public abstract Task<bool> ShowAsync();
}
