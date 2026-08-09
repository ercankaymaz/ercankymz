using System;
using Xbim.Common;
using Xbim.Ifc4.DateTimeResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.Interfaces.Conversions;

internal class IfcLagTimeTransient : PersistEntityTransient, IIfcLagTime, IIfcSchedulingTime, IPersistEntity, IPersist
{
	private readonly IIfcTimeOrRatioSelect _lagValue;

	private readonly IfcTaskDurationEnum _durationType;

	public IIfcTimeOrRatioSelect LagValue
	{
		get
		{
			return _lagValue;
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public IfcTaskDurationEnum DurationType
	{
		get
		{
			return _durationType;
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public IfcLabel? Name
	{
		get
		{
			return null;
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public IfcDataOriginEnum? DataOrigin
	{
		get
		{
			return null;
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public IfcLabel? UserDefinedDataOrigin
	{
		get
		{
			return null;
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public IfcLagTimeTransient(string isoDate)
	{
		_durationType = IfcTaskDurationEnum.NOTDEFINED;
		_lagValue = new IfcDuration(isoDate);
	}
}
