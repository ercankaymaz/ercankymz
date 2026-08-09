using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public interface ITranslationManager
{
	LocalizedText Translate(IList<string> preferredLocales, string key, string text, params object[] args);

	LocalizedText Translate(IList<string> preferredLocales, LocalizedText text);

	ServiceResult Translate(IList<string> preferredLocales, ServiceResult result);
}
