using System;
using ServiceStack;


public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message)
    {
    }
}
