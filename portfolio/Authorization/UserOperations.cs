using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace portfolio.Authorization
{
    public class UserOperations
    {
        public static OperationAuthorizationRequirement Create = new OperationAuthorizationRequirement() { Name = "Create" };
    }
  
    public enum Constants{
        Create,
        Edit,
        Delete,
        Read,
        Promote,
        Comment,
        Approve,
        Disapprove
    }
}
