
using Microsoft.EntityFrameworkCore;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataLayer1
{
    public class WorkoutContext : IDB<Workout, int>
    {
        private readonly MusclesDBContext dbContext;
        public WorkoutContext(MusclesDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task CreateAsync(Workout item)
        {
            try
            {
                dbContext.Workouts.Add(item);
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
                Workout workoutFromDb = await ReadAsync(key, false);
                if (workoutFromDb != null)
                {
                    dbContext.Workouts.Remove(workoutFromDb);
                    await dbContext.SaveChangesAsync();
                }
                else
                {
                    throw new ArgumentException("This workout does not exist!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ICollection<Workout>> ReadAllAsync(bool useNavigationalProperties = false)
        {
            try
            {
                IQueryable<Workout> query = dbContext.Workouts;
                if (useNavigationalProperties)
                {
                    query = query.Include(o => o.ExerciseTypeGroups).Include(o => o.Creator);
                }

                return await query.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Workout> ReadAsync(int key, bool useNavigationalProperties = false)
        {
            try
            {
                IQueryable<Workout> query = dbContext.Workouts;
                if (useNavigationalProperties)
                {
                    query = query.Include(o => o.ExerciseTypeGroups).Include(o=>o.Creator);
                }

                return await query.FirstOrDefaultAsync(c => c.WorkoutId == key);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateAsync(Workout item, bool useNavigationalProperties = false)
        {
            try
            {
                Workout workoutFromDb = await ReadAsync(item.WorkoutId, useNavigationalProperties);
                if (workoutFromDb == null)
                {
                    await CreateAsync(item);
                    return;
                }
                workoutFromDb.CreatorId = item.CreatorId;
                workoutFromDb.Status = item.Status;

                if (useNavigationalProperties)
                {
                    List<ExerciseTypeGroup> exerciseTypeGroups = new List<ExerciseTypeGroup>();
                    foreach (ExerciseTypeGroup e in item.ExerciseTypeGroups)
                    {
                        ExerciseTypeGroup exerciseFromDb = dbContext.ExerciseTypeGroups.Find(e.ExerciseTypeGroupId);
                        if (workoutFromDb != null)
                        {
                            exerciseTypeGroups.Add(exerciseFromDb); 
                        }
                        else
                        {
                            exerciseTypeGroups.Add(e);
                        }
                    }
                    workoutFromDb.ExerciseTypeGroups = exerciseTypeGroups;
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
