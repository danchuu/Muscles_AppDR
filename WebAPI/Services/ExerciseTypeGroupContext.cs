using DataLayer1;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ExerciseTypeGroupContext : IDB<ExerciseTypeGroup, int>
    {
        private readonly MusclesDBContext dbContext;

        public ExerciseTypeGroupContext(MusclesDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task CreateAsync(ExerciseTypeGroup item)
        {
            try
            {
                dbContext.ExerciseTypeGroups.Add(item);
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
                ExerciseTypeGroup exerciseGroupsFromDb = await ReadAsync(key, false);
                if (exerciseGroupsFromDb != null)
                {
                    dbContext.ExerciseTypeGroups.Remove(exerciseGroupsFromDb);
                    await dbContext.SaveChangesAsync();
                }
                else
                {
                    throw new ArgumentException("This user does not exist!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ICollection<ExerciseTypeGroup>> ReadAllAsync(bool useNavigationalProperties = false)
        {
            try
            {
                IQueryable<ExerciseTypeGroup> query = dbContext.ExerciseTypeGroups;
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


        public async Task<ExerciseTypeGroup> ReadAsync(int key, bool useNavigationalProperties = false)
        {
            try
            {
                IQueryable<ExerciseTypeGroup> query = dbContext.ExerciseTypeGroups;
                if (useNavigationalProperties)
                {
                    query = query.Include(o => o.Exercises);
                }

                return await query.FirstOrDefaultAsync(c => c.ExerciseTypeGroupId == key);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateAsync(ExerciseTypeGroup item, bool useNavigationalProperties = false)
        {
            try
            {
                ExerciseTypeGroup workoutFromDb = await ReadAsync(item.ExerciseTypeGroupId, useNavigationalProperties);
                if (workoutFromDb == null)
                {
                    await CreateAsync(item);
                    return;
                }
                

                if (useNavigationalProperties)
                {
                    List<Exercise> exerciseGroups = new List<Exercise>();
                    foreach (Exercise e in item.Exercises)
                    {
                        Exercise exerciseFromDb = dbContext.Exercises.Find(e.ExerciseId);
                        if (workoutFromDb != null)
                        {
                            exerciseGroups.Add(exerciseFromDb);
                        }
                        else
                        {
                            exerciseGroups.Add(e);
                        }
                    }
                    workoutFromDb.Exercises = exerciseGroups;
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
