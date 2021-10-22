using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ISomeRepositroy
    {
        SomeModel Get(int id);
        IEnumerable<SomeModel> GetAll();
        int Add(SomeModel model);
        void Remove(int id);
        void Update(SomeModel model);
    }
}
