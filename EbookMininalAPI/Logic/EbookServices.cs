using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbookMininalAPI.Logic
{
    public class EbookServices : IEbookServices
    {
                List<Ebook> _ebooks = new()
        {
            new(){Id = 1, Title = "Blazor Pro", Year= 2022},
            new(){Id = 2, Title = ".Net Pro", Year= 2021},
            new(){Id = 3, Title = "C# Pro", Year= 2020},
            new(){Id = 4, Title = "Developer Pro", Year= 2019},
            new(){Id = 5, Title = "Development Pro", Year= 2018},
        };

        public async Task Delete(int id)
        {
            _ebooks.Remove(_ebooks.Single(e => e.Id == id));
        }
       
       
       public async Task<List<Ebook>> GetAll()
       {
           return _ebooks;
       }
       
       public async Task<Ebook> GetById(int id)
       {
          return _ebooks.Single(e => e.Id == id);
       }

       public async Task Insert(Ebook ebook)
       {
           _ebooks.Add(ebook);
       }


    }
}