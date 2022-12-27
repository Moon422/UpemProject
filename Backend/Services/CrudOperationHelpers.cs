using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;

public static class CrudOperationHelpers
{
    public static async Task<TModel> GetOneByIdOperation<TModel, TModelId>(TModelId id, DbContext dbContext, DbSet<TModel> dbSet) where TModel : class
    {
        var model = await dbSet.FindAsync(id);

        if (model == null)
        {
            throw new KeyNotFoundException($"Entity with id {id} not found");
        }

        return model;
    }

    public static async Task CreateOpeartion<TModel>(TModel model, DbContext dbContext, DbSet<TModel> dbSet) where TModel : class
    {
        await dbSet.AddAsync(model);
        await dbContext.SaveChangesAsync();
    }

    public static async Task DeleteOperation<TModel, TModelId>(TModelId id, DbContext dbContext, DbSet<TModel> dbSet) where TModel : class
    {
        var model = await GetOneByIdOperation(id, dbContext, dbSet);

        dbSet.Remove(model);
        await dbContext.SaveChangesAsync();
    }
}
