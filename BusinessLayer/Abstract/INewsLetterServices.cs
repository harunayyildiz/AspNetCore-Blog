using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface INewsLetterServices:IGenericService<NewsLetter>
    {
        void AddNewLetter(NewsLetter newsLetter); //Yeni abonelik * Genericten farklı yapıda spesifict
    }
}
