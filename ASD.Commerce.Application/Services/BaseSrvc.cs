using ASD.Commerce.Domain.Contracts;
using ASD.Commerce.Domain.Contracts.Services;
using ASD.Commerce.Domain.Entities;
using Microsoft.Data.SqlClient;
using System.Linq.Expressions;

namespace ASD.Commerce.Application.Services
{
    public class BaseSrvc<T> : IBaseSrvc<T> where T : BaseEntity
    {
        protected readonly IUnitOfWork<T> _unitOfWork;
        public BaseSrvc(IUnitOfWork<T> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(T entity)
        {
            entity.CreatedOn = DateTime.UtcNow;
            await _unitOfWork.Repositories.AddAsync(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _unitOfWork.Repositories.AddRangeAsync(entities);
            await _unitOfWork.CompleteAsync();
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> expression)
        {
            return _unitOfWork.Repositories.FindAll(expression);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _unitOfWork.Repositories.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _unitOfWork.Repositories.GetByIdAsync(id);
        }

        public async Task Remove(T entity)
        {
            var dbEntity = await _unitOfWork.Repositories.GetByIdAsync(entity.Id);
            if (dbEntity == null) return;
            try
            {
                _unitOfWork.Repositories.Remove(entity);
            }
            catch (SqlException sqExec)
            {

            }
           
            await _unitOfWork.CompleteAsync();
        }

        public async Task RemoveRange(IEnumerable<T> entities)
        {
            _unitOfWork.Repositories.RemoveRange(entities);
            await _unitOfWork.CompleteAsync();
        }

        public async Task Update(T entity)
        {
            var dbEntity = await _unitOfWork.Repositories.GetByIdAsync(entity.Id);
            if (dbEntity == null) { return; }
            dbEntity = entity;
            dbEntity.UpdatedOn = DateTime.UtcNow;
            await Task.Run(() => { _unitOfWork.Repositories.Update(entity); });

            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateRange(IEnumerable<T> entities)
        {
            _unitOfWork.Repositories.UpdateRange(entities);
            await _unitOfWork.CompleteAsync();
        }
    }
}
