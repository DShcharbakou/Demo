using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BLL
{
    public class SomeService : ISomeService
    {
        private readonly ISomeRepositroy _someRepository;
        public SomeService(ISomeRepositroy someRepository)
        {
            _someRepository = someRepository;
        }
        public int AddAdultPerson(SomeModel inputModel)
        {
            if (inputModel.Age < 18)
            {
                throw new ValidationException($"Must be over 18 years old.");
            }

            return _someRepository.Add(inputModel);
        }

        public IEnumerable<SomeModel> GetModelsWithAgeLessThen18()
        {
            return _someRepository.GetAll().Where(x => x.Age < 18);
        }

        public IEnumerable<SomeModel> GetModelsWithAgeMoreThen18()
        {
            return _someRepository.GetAll().Where(x => x.Age > 18);
        }
    }
}
