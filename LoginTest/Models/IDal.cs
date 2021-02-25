using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginTest.Models
{
   public interface IDal : IDisposable
    {
        Task<bool> Register(Account account);


    //    nouvelle methode
   
    }
}
