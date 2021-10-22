using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface ISomeService
    {
        IEnumerable<SomeModel> GetModelsWithAgeMoreThen18();
        IEnumerable<SomeModel> GetModelsWithAgeLessThen18();
        int AddAdultPerson(SomeModel inputModel);
    }
}
