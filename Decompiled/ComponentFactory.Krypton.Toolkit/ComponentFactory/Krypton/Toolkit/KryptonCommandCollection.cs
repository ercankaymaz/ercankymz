using System.Collections.Generic;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonCommandCollection : TypedCollection<KryptonCommand>
{
	public override KryptonCommand this[string name]
	{
		get
		{
			if (!string.IsNullOrEmpty(name))
			{
				using IEnumerator<KryptonCommand> enumerator = GetEnumerator();
				while (enumerator.MoveNext())
				{
					KryptonCommand current = enumerator.Current;
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
