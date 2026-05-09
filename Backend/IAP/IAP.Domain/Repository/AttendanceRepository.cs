using IAP.Domain.Data;
using IAP.Domain.Entity;
using IAP.Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace IAP.Domain.Repository
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AttendanceRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Attendance>> GetAllAsync()
        {
            return await _dbContext.Attendances
                .Include(x => x.User)
                .ToListAsync();
        }

        public async Task<Attendance?> GetByIdAsync(int id)
        {
            return await _dbContext.Attendances
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Attendance?> GetByUserAndDateAsync(int userId, DateOnly attendanceDate)
        {
            return await _dbContext.Attendances
                .FirstOrDefaultAsync(x =>
                    x.UserId == userId &&
                    x.AttendanceDate == attendanceDate);
        }

        public async Task<List<Attendance>> GetByUserIdAsync(int userId)
        {
            return await _dbContext.Attendances
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }

        public async Task<bool> IsAttendanceExistsAsync(int userId, DateOnly attendanceDate)
        {
            return await _dbContext.Attendances
                .AnyAsync(x =>
                    x.UserId == userId &&
                    x.AttendanceDate == attendanceDate);
        }

        public async Task CreateAsync(Attendance attendance)
        {
            await _dbContext.Attendances.AddAsync(attendance);
        }

        public void Update(Attendance attendance)
        {
            _dbContext.Attendances.Update(attendance);
        }

        public void Delete(Attendance attendance)
        {
            _dbContext.Attendances.Remove(attendance);
        }

        public async Task<bool> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}