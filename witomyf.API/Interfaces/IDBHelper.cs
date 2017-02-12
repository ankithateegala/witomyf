using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using witomyf.API.Models;

namespace witomyf.API.Interfaces
{
    public interface IDBHelper
    {
        void InsertWitomyf(Witomyf Witomyf);
        Witomyf GetWitomyf(string day);
    }
}
