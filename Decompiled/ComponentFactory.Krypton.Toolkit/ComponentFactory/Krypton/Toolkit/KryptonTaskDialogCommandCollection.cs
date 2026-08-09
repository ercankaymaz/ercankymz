using System.Collections.Generic;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonTaskDialogCommandCollection : TypedCollection<KryptonTaskDialogCommand>
{
	public override KryptonTaskDialogCommand this[string name]
	{
		get
		{
			if (!string.IsNullOrEmpty(name))
			{
				using IEnumerator<KryptonTaskDialogCommand> enumerator = GetEnumerator();
				while (enumerator.MoveNext())
				{
					KryptonTaskDialogCommand current = enumerator.Current;
					string text = current.Text;
					if (!string.IsNullOrEmpty(text) && text == name)
					{
						return current;
					}
					text = current.ExtraText;
					if (!string.IsNullOrEmpty(text) && text == name)
					{
						return current;
					}
				}
			}
			return null;
		}
	}
}
