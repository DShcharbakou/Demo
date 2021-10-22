using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class FakeRepository : ISomeRepositroy
    {
        private List<SomeModel> someFakeContext;
        public FakeRepository()
        {
            someFakeContext = new List<SomeModel>();
            for (int i = 0; i < 50; i++)
            {
                someFakeContext.Add(new SomeModel { Id = i, Name = $"fakeName{i}", Age = i });
            }
        }

        public int Add(SomeModel model)
        {
            var id = someFakeContext.Max(x => x.Id) + 1;
            model.Id = id;
            someFakeContext.Add(model);
            return id;
        }

        public SomeModel Get(int id)
        {
            return someFakeContext.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<SomeModel> GetAll()
        {
            return someFakeContext;
        }

        public void Remove(int id)
        {
            var model = someFakeContext.FirstOrDefault(x => x.Id == id);
            someFakeContext.Remove(model);
        }

        public void Update(SomeModel inputModel)
        {
            var model = someFakeContext.FirstOrDefault(x => x.Id == inputModel.Id);
            var index = someFakeContext.IndexOf(model);
            someFakeContext[index] = inputModel;
        }
    }
}
