using Microsoft.EntityFrameworkCore;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer1
{
    public class UserContext : IDB<User, int>
    {
        private readonly MusclesDBContext dbContext;

        public UserContext(MusclesDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task CreateAsync(User item)
        {
            try
            {
                dbContext.Users.Add(item);
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
                User userFromDb = await ReadAsync(key, false);
                if (userFromDb != null)
                {
                    dbContext.Users.Remove(userFromDb);
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
            
        public async Task<ICollection<User>> ReadAllAsync(bool useNavigationalProperties = false)
        {
            try
            {
                IQueryable<User> query = dbContext.Users;
                if (useNavigationalProperties)
                {
                    query = query.Include(o => o.Workouts).Include(o => o.History);
                }

                return await query.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<User> ReadAsync(int key, bool useNavigationalProperties = false)
        {
            try
            {
                IQueryable<User> query = dbContext.Users;
                if (useNavigationalProperties)
                {
                    query = query.Include(o => o.Workouts).Include(o => o.History);
                }

                return await query.FirstOrDefaultAsync(c => c.Id == key);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateAsync(User item, bool useNavigationalProperties = false)
        {
            try
            {
                User userFromDb = await ReadAsync(item.Id, useNavigationalProperties);
                if (userFromDb == null)
                {
                    await CreateAsync(item);
                    return;
                }
                userFromDb.Name = item.Name;
                userFromDb.Password = item.Password;
                userFromDb.Role = item.Role;

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
                    List<WorkoutHistory> history = new List<WorkoutHistory>();
                    foreach (WorkoutHistory w in item.History)
                    {
                        WorkoutHistory workoutFromDb = dbContext.History.Find(w.WorkoutHistoryId);
                        if (workoutFromDb != null)
                        {
                            history.Add(workoutFromDb);
                        }
                        else
                        {
                            history.Add(w);
                        }
                    }
                    userFromDb.History = history;
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
