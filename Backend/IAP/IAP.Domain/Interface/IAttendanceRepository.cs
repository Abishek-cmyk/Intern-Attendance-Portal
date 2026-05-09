using IAP.Domain.Entity;

namespace IAP.Domain.Interface
{
    public interface IAttendanceRepository
    {
        Task<List<Attendance>> GetAllAsync();

        Task<Attendance?> GetByIdAsync(int id);

        Task<Attendance?> GetByUserAndDateAsync(int userId, DateOnly attendanceDate);

        Task<List<Attendance>> GetByUserIdAsync(int userId);

        Task<bool> IsAttendanceExistsAsync(int userId, DateOnly attendanceDate);

        Task CreateAsync(Attendance attendance);

        void Update(Attendance attendance);

        void Delete(Attendance attendance);

        Task<bool> SaveAsync();
    }
}