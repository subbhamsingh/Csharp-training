using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SqlMapping.Models;

namespace SqlMapping.Logic
{
    public class UserLogic
    {
        private readonly ProjectJoinContext _context;

        public UserLogic(ProjectJoinContext context)
        {
            _context = context;
        }

       
        //private const string _getUsersWithDepartment = @"
        //                                                SELECT 
        //                                                    u.UserId,
        //                                                    u.UserName,
        //                                                    u.UserEmail,
        //                                                    u.UserRole,
        //                                                    u.DeptId,
        //                                                    u.CreatedAt,
        //                                                    u.UpdatedAt
        //                                                FROM Users u
        //                                                INNER JOIN Department d
        //                                                ON u.DeptId = d.DeptId";



        //  using direct sql query
      
        //public List<User> GetUsers()
        //{
        //    try
        //    {
        //        var users = _context.Users.FromSqlRaw(_getUsersWithDepartment).ToList();

        //        return users;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error while fetching users", ex);
        //    }
        //}

        //using view in ssms

        public List<User> GetUsers()
        {
            try
            {
                var users = _context.Users.FromSqlRaw("SELECT * FROM vw_GetUsersWithDepartment").ToList();

                return users;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching users", ex);
            }
        }


        //private const string _getUsersWithDepartmentDeptId = @"
        //                                                        SELECT 
        //                                                            u.UserId,
        //                                                            u.UserName,
        //                                                            u.UserEmail,
        //                                                            u.UserRole,
        //                                                            u.DeptId,
        //                                                            u.CreatedAt,
        //                                                            u.UpdatedAt
        //                                                        FROM Users u
        //                                                        INNER JOIN Department d
        //                                                        ON u.DeptId = d.DeptId
        //                                                        WHERE d.DeptId = @deptId";



        //direct query with sql parameter and value 
        //public List<User> GetUsersByDepartment(int deptId)
        //{
        //    try
        //    {
        //        var deptIdParameter = new SqlParameter("@deptId", deptId);

        //        var users = _context.Users.FromSqlRaw(_getUsersWithDepartmentDeptId, deptIdParameter).ToList();


        //        return users;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error while fetching users by department", ex);
        //    }
        //}



        // using stored procedure 
        public List<User> GetUsersByDepartment(int deptId)
        {
            try
            {
                var deptIdParameter = new SqlParameter("@deptId", deptId);

                var users = _context.Users.FromSqlRaw("EXEC sp_GetUsersByDepartment @deptId", deptIdParameter).ToList();

                return users;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching users by department", ex);
            }
        }



        // functions for sql
        public List<User> GetUsersByDepartmentFunction(int deptId)
        {
           
                var deptIdParameter = new SqlParameter("@deptId", deptId);

                var users = _context.Users.FromSqlRaw("SELECT * FROM fn_GetUsersByDepartment(@deptId)", deptIdParameter).ToList();

                return users;

   
        }



        //private static readonly string _getUserByIdQuery = @"SELECT * FROM Users WHERE UserId = @userId";
        //public User GetUserById(int userId)
        //{
        //    var userIdParameter = new SqlParameter("@userId", userId);

        //    var user = _context.Users.FromSqlRaw(_getUserByIdQuery, userIdParameter).FirstOrDefault();
        //    return user;
        //}





        // another option fromsqlinterpolated 

        //public List<User> GetUsersByDepartment(int deptId)
        //{
        //    var users = _context.Users
        //                .FromSqlInterpolated($@"
        //        SELECT *
        //        FROM Users
        //        WHERE DeptId = {deptId}")
        //                .ToList();

        //    return users;
        //}


        // linq query
        //public List<User> GetUsersByDepartment(int deptId)
        //{
        //    var users = _context.Users
        //                .Where(u => u.DeptId == deptId)
        //                .ToList();

        //    return users;
        //}



    }
}