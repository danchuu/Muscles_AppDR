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
    
        public class WorkoutHistoryContext : IDB<WorkoutHistory, int>
        {
            private readonly MusclesDBContext dbContext;
            public WorkoutHistoryContext(MusclesDBContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public async Task CreateAsync(WorkoutHistory item)
            {
                try
                {
                    dbContext.History.Add(item);
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
                    WorkoutHistory workoutHistoryFromDb = await ReadAsync(key, false);
                    if (workoutHistoryFromDb != null)
                    {
                        dbContext.History.Remove(workoutHistoryFromDb);
                        await dbContext.SaveChangesAsync();
                    }
                    else
                    {
                        throw new ArgumentException("This WorkoutHistory does not exist!");
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }

            public async Task<ICollection<WorkoutHistory>> ReadAllAsync(bool useNavigationalProperties = false)
            {
                try
                {
                    IQueryable<WorkoutHistory> query = dbContext.History;
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

            public async Task<WorkoutHistory> ReadAsync(int key, bool useNavigationalProperties = false)
            {
                try
                {
                    IQueryable<WorkoutHistory> query = dbContext.History;
                    if (useNavigationalProperties)
                    {
                        query = query.Include(o => o.ExerciseTypeGroups).Include(o => o.Creator);
                    }

                    return await query.FirstOrDefaultAsync(c => c.WorkoutHistoryId == key);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            public async Task UpdateAsync(WorkoutHistory item, bool useNavigationalProperties = false)
            {
                try
                {
                    WorkoutHistory workoutHistoryFromDb = await ReadAsync(item.WorkoutHistoryId, useNavigationalProperties);
                    if (workoutHistoryFromDb == null)
                    {
                        await CreateAsync(item);
                        return;
                    }
                    workoutHistoryFromDb.CreatorId = item.CreatorId;
                    workoutHistoryFromDb.Status = item.Status;

                if (useNavigationalProperties)
                {
                    List<ExerciseTypeGroup> exerciseTypeGroups = new List<ExerciseTypeGroup>();
                    foreach (ExerciseTypeGroup e in item.ExerciseTypeGroups)
                    {
                        ExerciseTypeGroup exerciseFromDb = dbContext.ExerciseTypeGroups.Find(e.ExerciseTypeGroupId);
                        if (workoutHistoryFromDb != null)
                        {
                            exerciseTypeGroups.Add(exerciseFromDb);
                        }
                        else
                        {
                            exerciseTypeGroups.Add(e);
                        }
                    }
                    workoutHistoryFromDb.ExerciseTypeGroups = exerciseTypeGroups;
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

