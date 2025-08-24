using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training_Management_System.DAL.Models.Grades;
using Training_Management_System.DAL.Presistance.Repositories.Grades;
using Training_Management_System.PLL.DTOS;

namespace Training_Management_System.PLL.Services.GradeService
{

    public class GradeService : IGradeService
    {
        private readonly IGradeRepository _gradeRepository;

        public GradeService(IGradeRepository gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }

        public int Create(GradeDto gradeDto)
        {
            var grade = new Grade
            {
                Value = gradeDto.Value,
                SessionId = gradeDto.SessionId,
                TraineeId = gradeDto.TraineeId
            };

            return _gradeRepository.Add(grade);
        }

        public int Update(int id, GradeDto gradeDto)
        {
            var grade = _gradeRepository.GetById(id);
            if (grade == null)
                return 0;

            grade.Value = gradeDto.Value;
            grade.SessionId = gradeDto.SessionId;
            grade.TraineeId = gradeDto.TraineeId;

            return _gradeRepository.Update(id,grade);
        }



        public int Delete(int id)
        {
            var grade = _gradeRepository.GetById(id);
            if (grade == null)
                return 0;

            return _gradeRepository.Delete(id);
        }

        public GradeDto GetById(int id)
        {
            var grade = _gradeRepository.GetById(id);
            if (grade == null) return null;

            return new GradeDto
            {
                Id = grade.Id,
                Value = grade.Value,
                SessionId = grade.SessionId,
                TraineeId = grade.TraineeId
            };
        }

        public IEnumerable<GradeDto> GetAll()
        {
            return _gradeRepository.GetAllWithDetails().Select(g => new GradeDto
            {
                Id = g.Id,
                Value = g.Value,
                TraineeId = g.TraineeId,
                TraineeName = g.Trainee.Name,
                SessionId = g.SessionId,
               
            });
        }

        public IEnumerable<GradeDto> GetByTraineeId(int traineeId)
        {
            return _gradeRepository.GetByTraineeId(traineeId).Select(g => new GradeDto
            {
                Id = g.Id,
                Value = g.Value,
                SessionId = g.SessionId,
                TraineeId = g.TraineeId
            });
        }

        public IEnumerable<GradeDto> GetBySessionId(int sessionId)
        {
            return _gradeRepository.GetBySessionId(sessionId).Select(g => new GradeDto
            {
                Id = g.Id,
                Value = g.Value,
                SessionId = g.SessionId,
                TraineeId = g.TraineeId
            });
        }
    }
}