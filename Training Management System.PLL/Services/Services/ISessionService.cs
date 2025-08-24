using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_Management_System.PLL.DTOS;

namespace Training_Management_System.PLL.Services.SessionService
{
    public interface ISessionService
    {

        string? Create(SessionDto sessionDto);

        string? Update(SessionDto sessionDto);


        string? Delete(int id);

        SessionDto? GetById(int id);


        IQueryable<SessionDto> GetAllWithCourseName();


        IQueryable<SessionDto> SearchWithCourseName(string courseName);
    }
}
