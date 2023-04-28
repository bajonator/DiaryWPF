using DiaryWPF.Models.Domains;
using DiaryWPF.Models.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Security.Cryptography.X509Certificates;
using DiaryWPF.Models.Converters;
using System.Windows.Markup;
using DiaryWPF.Models;
using System.Runtime.Remoting.Contexts;

namespace DiaryWPF
{
    public class Repository
    {
        public List<Group> GetGroups()
        {
            using (var context = new ApplicationDBContext())
            {
                return context.Groups.ToList();
            }
        }

        public List<StudentWrapper> GetStudents(int groupId)
        {
            using(var context = new ApplicationDBContext())
            {
                var students = context
                    .Students
                    .Include(x => x.Group)
                    .Include(x => x.Ratings)
                    .AsQueryable();


                if (groupId != 0)
                    students = students.Where(x => x.GroupId == groupId);


                return students
                    .ToList()
                    .Select(x => x.ToWrapper())
                    .ToList();
            }
        }

        public void DeleteStudent(int id)
        {
            using (var context = new ApplicationDBContext())
            {
                var studentToDelete = context.Students.Find(id);
                context.Students.Remove(studentToDelete);
                context.SaveChanges();
            }
        }

        public void UpdateStudent(StudentWrapper studentWrapper)
        {
            var student = studentWrapper.ToDao();
            var ratings = studentWrapper.ToRatingDo();
            using (var context = new ApplicationDBContext())
            {
                UpdateStudentProperties(context, student);

                var studentsRatings = GetStudentsRatings(context, student);

                UpdateRate(student, ratings, context, studentsRatings, Subject.Math);
                UpdateRate(student, ratings, context, studentsRatings, Subject.Technology);
                UpdateRate(student, ratings, context, studentsRatings, Subject.Physics);
                UpdateRate(student, ratings, context, studentsRatings, Subject.ForeignLang);
                UpdateRate(student, ratings, context, studentsRatings, Subject.PolishLang);

                context.SaveChanges();
            }
        }

        private static List<Rating> GetStudentsRatings(ApplicationDBContext context, Student student)
        {
           return context
                    .Rating
                    .Where(x => x.StudentId == student.Id)
                    .ToList();
        }
         
        private void UpdateStudentProperties(ApplicationDBContext context, Student student)
        {
            var studentToUpdate = context.Students.Find(student.Id);
            studentToUpdate.Activities = student.Activities;
            studentToUpdate.Comments = student.Comments;
            studentToUpdate.FirstName = student.FirstName;
            studentToUpdate.LastName = student.LastName;
            studentToUpdate.GroupId = student.GroupId;
        }

        private static void UpdateRate(Student student, List<Rating> newRratings, ApplicationDBContext context, List<Rating> studentsRatings, Subject subject)
        {
            var subRatings = studentsRatings
                   .Where(x => x.SubjectId == (int)subject)
                   .Select(x => x.Rate);

            var newSubRatings = newRratings
                .Where(x => x.SubjectId == (int)subject)
                .Select(x => x.Rate);


            var subRatingsToDelete = subRatings.Except(newSubRatings).ToList();
            var aubRatingsToAdd = newSubRatings.Except(subRatings).ToList();

            subRatingsToDelete.ForEach(x =>
            {
                var ratingToDelete = context
                .Rating.First(y =>
                y.Rate == x &&
                y.StudentId == student.Id &&
                y.SubjectId == (int)subject);

                context.Rating.Remove(ratingToDelete);
            });

            aubRatingsToAdd.ForEach(x =>
            {
                var ratingToAdd = new Rating
                {
                    Rate = x,
                    StudentId = student.Id,
                    SubjectId = (int)subject
                };

                context.Rating.Add(ratingToAdd);
            });
        }

        public void AddStudent(StudentWrapper studentWrapper)
        {
            var student = studentWrapper.ToDao();
            var ratings = studentWrapper.ToRatingDo();

            using (var context = new ApplicationDBContext()) 
            {
                var dbStudent = context.Students.Add(student);

                ratings.ForEach(x =>
                {
                    x.StudentId = dbStudent.Id;
                    context.Rating.Add(x);
                });

                context.SaveChanges();
            }
        }
    }
}
