using ROSys.Contracts;
using ROSys.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROSys.MongoDBFacade.Mappers
{
    internal class CustomersMapper : IMapper
    {
        EntityService<MongoDBEntity<Customer>> entityService;
        public CustomersMapper(EntityService<MongoDBEntity<Customer>> entityService)
        {
            this.entityService = entityService;
        }

        #region IMapper interface

        public object Get(Guid id)
        {
            var item = entityService.FindByGuid(id);
            return item == null ? null : item.Data;
        }

        public List<object> GetAll()
        {
            return entityService.FindAll();
        }

        public bool Put(object obj)
        {
            MongoDBEntity<Customer> c = new MongoDBEntity<Customer>()
            {
                Data = (Customer)obj
            };
            entityService.Create(c);
            return true;
        }
        #endregion
    }
}
