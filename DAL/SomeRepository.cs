using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DAL
{
    public class SomeRepository : ISomeRepositroy
    {
        private readonly List<SomeModel> someModelContext;
        public SomeRepository()
        {
            someModelContext = new List<SomeModel>();
            for (int i = 0; i < 50; i++)
            {
                someModelContext.Add(new SomeModel { Id = i, Name = $"name{i}", Age = i });
            }
        }
        public int Add(SomeModel model)
        {
            var id = someModelContext.Max(x => x.Id) + 1;
            model.Id = id;
            someModelContext.Add(model);
            return id;
        }

        public SomeModel Get(int id)
{
            return someModelContext.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<SomeModel> GetAll()
        {
            return someModelContext;
        }

        public void Remove(int id)
        {
            var model = someModelContext.FirstOrDefault(x => x.Id == id);
            someModelContext.Remove(model);
        }

        public void Update(SomeModel inputModel)
        {
            var model = someModelContext.FirstOrDefault(x => x.Id == inputModel.Id);
            var index = someModelContext.IndexOf(model);
            someModelContext[index] = inputModel;
        }
    }
}
