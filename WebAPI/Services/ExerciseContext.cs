
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
    public class ExerciseContext : IDB<Exercise, int>
    {
        private readonly MusclesDBContext dbContext;

        public ExerciseContext(MusclesDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task CreateAsync(Exercise item)
        {
            try
            {
                dbContext.Exercises.Add(item);
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
                Exercise exerciseFromDb = await ReadAsync(key, false);
                if (exerciseFromDb != null)
                {
                    dbContext.Exercises.Remove(exerciseFromDb);
                    await dbContext.SaveChangesAsync();
                }
                else
                {
                    throw new ArgumentException("This exercise does not exist!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ICollection<Exercise>> ReadAllAsync(bool useNavigationalProperties = false)
        {
            try
            {
                IQueryable<Exercise> query = dbContext.Exercises;
                if (useNavigationalProperties)
                {
                    query = query.Include(o => o.Workouts);
                }
            
                return await query.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Exercise> ReadAsync(int key, bool useNavigationalProperties = false)
        {
            try
            {
                IQueryable<Exercise> query = dbContext.Exercises;
                if (useNavigationalProperties)
                {
                    query = query.Include(o => o.Workouts);
                }


                return await query.FirstOrDefaultAsync(c => c.ExerciseId == key);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateAsync(Exercise item, bool useNavigationalProperties = false)
        {
            try
            {
                Exercise exerciseFromDb = await ReadAsync(item.ExerciseId, useNavigationalProperties);
                if (exerciseFromDb == null)
                {
                    await CreateAsync(item);
                    return;
                }
                exerciseFromDb.Weight = item.Weight;
                exerciseFromDb.Sets = item.Sets;
                exerciseFromDb.Reps = item.Reps;

                if (useNavigationalProperties)
                {
                    List<Workout> workouts = new List<Workout>();
                    foreach (Workout w in item.Workouts)
                    {
                        Workout workoutFromDb = dbContext.Workouts.Find(w.WorkoutId);
                        if (workoutFromDb != null)
                        {
                            workouts.Add(workoutFromDb);
                        }
                        else
                        {
                            workouts.Add(w);
                        }
                    }
                    exerciseFromDb.Workouts = workouts;
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
