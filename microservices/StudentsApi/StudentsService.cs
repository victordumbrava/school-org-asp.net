using StudentsApi;

public class StudentsService : IStudentsService
{
    private readonly StudentsDbContext _dbContext;
    
    public StudentsService(StudentsDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public IQueryable<Student> GetAll()
    {
        return _dbContext.Students.AsQueryable();
    }
}