﻿using ExaminationSystemProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystemProject.Repository
{
    public class ExamRespository : IExam
    {
        private Context context;
        public ExamRespository(Context _context)
        {
            context= _context;

        }
        
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Exam> GetAll()
        {
            return context.Exams.Include(c => c.Course).Include(d=>d.Instructor).ToList();
            
        }

        public List<Exam> GetAllExamsByCourseID(int id)
        {
            throw new NotImplementedException();
        }

        public Exam GetByExamID(int id)
        {
            throw new NotImplementedException();
        }

        public Exam GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void insert(Exam exam)
        {
            context.Exams.Add(exam);
            context.SaveChanges();
        }
        public void AddQuestionsToExam(int EID, int QID)
        {
            ExamQuestions E = new ExamQuestions();
            E.ExamID = EID;
            E.QuestID = QID;
            context.ExamQuestions.Add(E);
            context.SaveChanges();
        }

        public void Update(int id, Exam exam)
        {
            throw new NotImplementedException();
        }
    }
}