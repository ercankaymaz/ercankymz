using System.Collections.Generic;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

public class KryptonGalleryRangeCollection : TypedCollection<KryptonGalleryRange>
{
	public override KryptonGalleryRange this[string heading]
	{
		get
		{
			using (IEnumerator<KryptonGalleryRange> enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KryptonGalleryRange current = enumerator.Current;
					if (current.Heading == heading)
					{
						return current;
					}
				}
			}
			return base[heading];
		}
	}
}
