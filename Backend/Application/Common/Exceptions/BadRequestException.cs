﻿namespace Application.Common.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string name) : base(name) { }
    }
}
