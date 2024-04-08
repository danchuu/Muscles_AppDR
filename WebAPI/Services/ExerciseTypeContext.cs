using Microsoft.EntityFrameworkCore;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer1
{
    public class ExerciseTypeContext : IDB<ExerciseType, int>
    {
        private readonly MusclesDBContext dbContext;

        public ExerciseTypeContext(MusclesDBContext dbContext)
        {
           this.dbContext = dbContext;
        }
        public async Task CreateAsync(ExerciseType item)
        {
            try
            {
                dbContext.ExerciseTypes.Add(item);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteAsync(int key)
        {
            try
            {
                ExerciseType exerciseTypeFromDb = await ReadAsync(key, false);
                if (exerciseTypeFromDb != null)
                {
                    dbContext.ExerciseTypes.Remove(exerciseTypeFromDb);
                    await dbContext.SaveChangesAsync();
                }
                else
                {
                    throw new ArgumentException("This exercise type does not exist!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ICollection<ExerciseType>> ReadAllAsync(bool useNavigationalProperties = false)
        {
            try
            {
                IQueryable<ExerciseType> query = dbContext.ExerciseTypes;
                if (useNavigationalProperties)
                {
                    query = query.Include(o => o.Exercises);
                }
                return await query.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ExerciseType> ReadAsync(int key, bool useNavigationalProperties = false)
        {
            try
            {
                IQueryable<ExerciseType> query = dbContext.ExerciseTypes;
                if (useNavigationalProperties)
                {
                    query = query.Include(o => o.Exercises);
                }


                return await query.FirstOrDefaultAsync(c => c.ExerciseTypeId == key);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateAsync(ExerciseType item, bool useNavigationalProperties = false)
        {
            try
            {
                ExerciseType exerciseTypeFromDb = await ReadAsync(item.ExerciseTypeId, useNavigationalProperties);
                if (exerciseTypeFromDb == null)
                {
                    await CreateAsync(item);
                    return;
                }
                exerciseTypeFromDb.Name = item.Name;
                exerciseTypeFromDb.Description = item.Description;
                exerciseTypeFromDb.Equipment = item.Equipment;
                exerciseTypeFromDb.TargetedMuscle = item.TargetedMuscle;

                if (useNavigationalProperties)
                {
                    List<Exercise> exercises = new List<Exercise>();
                    foreach (Exercise e in item.Exercises)
                    {
                        Exercise exerciseFromDb = dbContext.Exercises.Find(e.ExerciseId);
                        if (exerciseTypeFromDb != null)
                        {
                            exercises.Add(exerciseFromDb);
                        }
                        else
                        {
                            exercises.Add(e);
                        }
                    }
                    exerciseTypeFromDb.Exercises = exercises;
                }
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
