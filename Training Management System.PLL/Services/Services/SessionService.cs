using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_Management_System.DAL.Models.Sessions;
using Training_Management_System.DAL.Presistance.Repositories.Sessions;
using Training_Management_System.PLL.DTOS;

namespace Training_Management_System.PLL.Services.SessionService
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository _sessionRepository;

        public SessionService(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }
        public string? Create(SessionDto sessionDto)
        {
            if (sessionDto.StartDate < DateTime.Today)
                return "Start date cannot be in the past.";

            if (sessionDto.EndDate <= sessionDto.StartDate)
                return "End date must be after Start date.";

            if (_sessionRepository.Exists(sessionDto.CourseId, sessionDto.StartDate, sessionDto.EndDate))
                return "This session overlaps with an existing session for the course.";

            var session = new Session
            {
                CourseId = sessionDto.CourseId,
                StartDate = sessionDto.StartDate,
                EndDate = sessionDto.EndDate
            };

            _sessionRepository.Add(session);
            return null;
        }


        public string? Update(SessionDto sessionDto)
        {
            if (sessionDto.StartDate < DateTime.Today)
                return "Start date cannot be in the past.";

            if (sessionDto.EndDate <= sessionDto.StartDate)
                return "End date must be after Start date.";

            var session = _sessionRepository.GetById(sessionDto.Id);
            if (session == null)
                return "Session not found.";

            if (_sessionRepository.Exists(sessionDto.CourseId, sessionDto.StartDate, sessionDto.EndDate, sessionDto.Id))
                return "This session overlaps with an existing session for the course.";

            session.CourseId = sessionDto.CourseId;
            session.StartDate = sessionDto.StartDate;
            session.EndDate = sessionDto.EndDate;

            _sessionRepository.Update(session);
            return null;
        }


        public string? Delete(int id)
        {
            var session = _sessionRepository.GetById(id);
            if (session == null)
                return "Session not found.";

            _sessionRepository.Delete(session);
            return null;
        }


        public SessionDto? GetById(int id)
        {
            var s = _sessionRepository.GetById(id);
            if (s == null) return null;

            return new SessionDto
            {
                Id = s.Id,
                CourseId = s.CourseId,
                CourseName = s.Course?.Name,
                StartDate = s.StartDate,
                EndDate = s.EndDate
            };
        }


        public IQueryable<SessionDto> GetAllWithCourseName()
        {
            return _sessionRepository.GetAll().Select(s => new SessionDto
            {
                Id = s.Id,
                CourseId = s.CourseId,
                CourseName = s.Course?.Name,
                StartDate = s.StartDate,
                EndDate = s.EndDate
            }).AsQueryable();
        }


        public IQueryable<SessionDto> SearchWithCourseName(string courseName)
        {
            return _sessionRepository.SearchByCourseName(courseName).Select(s => new SessionDto
            {
                Id = s.Id,
                CourseId = s.CourseId,
                CourseName = s.Course?.Name,
                StartDate = s.StartDate,
                EndDate = s.EndDate
            }).AsQueryable();
        }
    }
}
