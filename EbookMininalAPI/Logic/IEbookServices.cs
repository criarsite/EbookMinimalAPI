using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbookMininalAPI.Logic
{
    public interface IEbookServices
    {

        Task Delete(int id);
        Task< List<Ebook> >GetAll();
         Task <Ebook>  GetById(int id);
        Task Insert (Ebook ebook);
        
    }
}