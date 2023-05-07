using System;

namespace InoversityLibrary.Application.Interfaces;

public interface IDateTimeService
{
    DateTime NowUtc { get; }
}