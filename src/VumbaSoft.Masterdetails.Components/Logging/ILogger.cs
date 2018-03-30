using System;

namespace VumbaSoft.Masterdetails.Components.Logging
{
    public interface ILogger
    {
        void Log(String message);
        void Log(Exception exception);
    }
}
