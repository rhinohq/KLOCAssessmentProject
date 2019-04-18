using System.Collections.Generic;

namespace KLOCAssessmentProject.Models.Repository
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();

        TEntity Get(int ID);

        void Add(TEntity Entity);

        void Update(TEntity DBEntity, TEntity Entity);

        void Delete(int ID);

        void Delete(TEntity Entity);
    }
}