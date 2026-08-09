using System;
using Xbim.Common.Metadata;

namespace Xbim.Common;

public interface IPersistEntity : IPersist
{
	int EntityLabel { get; }

	IModel Model { get; }

	bool Activated { get; }

	ExpressType ExpressType { get; }

	[Obsolete("This property is deprecated and likely to be removed. Use just 'Model' instead.")]
	IModel ModelOf { get; }
}
