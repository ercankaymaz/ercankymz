using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public interface ITranslatableObject
{
	ITranslatableObject Translate(ITranslationManager manager, IList<string> preferredLocales);
}
