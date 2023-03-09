using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleRegister.Domain.Services.Exceptions
{
    public class IdCanNotBeZero : Exception
    {
        public IdCanNotBeZero(): base("Id can not be zero") { }

    }
}
