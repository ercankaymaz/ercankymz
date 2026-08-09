using System;
using Xbim.Common;
using Xbim.Common.Metadata;

namespace Xbim.Ifc2x3.Interfaces.Conversions;

internal abstract class PersistEntityTransient : IPersistEntity, IPersist
{
	public int EntityLabel => -1;

	public virtual IModel Model => null;

	public bool Activated => true;

	public ExpressType ExpressType
	{
		get
		{
			if (Model == null)
			{
				return null;
			}
			return Model.Metadata.ExpressType(this);
		}
	}

	[Obsolete("Use Model instead.")]
	public IModel ModelOf => Model;

	public void Parse(int propIndex, IPropertyValue value, int[] nested)
	{
		throw new NotSupportedException("Transient object");
	}

	public string WhereRule()
	{
		return "";
	}
}
