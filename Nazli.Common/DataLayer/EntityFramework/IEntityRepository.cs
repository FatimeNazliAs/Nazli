using Nazli.Common.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nazli.Common.DataLayer.EntityFramework
{
    //generic constraint
    //class: referans tip olabilir demek
    //where T : class,IEntity => t ientity ya da onu implemente eden bir nesne olabilir.
    //where T : class,IEntity,new() => ientity newlenemez o yuzden kendisini kullanmamıs oluruz
    public interface IEntityRepository<T> where T : class, IEntity,new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter);

        //filtre zorunlu hale geldi
       // T Get(Expression<Func<T, bool>> filter);
        int Add(T entity);
        int Update(T entity);
        int Delete(T entity);

    }
}
