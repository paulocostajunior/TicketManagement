using System;
using TicketManagement.Application.Contracts;

namespace TicketManagement.Api.Services
{
    public class LoggedInUserService : ILoggedInUserService
    {
        public string UserId => throw new NotImplementedException();
    }
}

