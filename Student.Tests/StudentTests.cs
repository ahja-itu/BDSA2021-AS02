using System;
using Xunit;
using System.Data;

namespace Student.Tests
{
    public class StudentTests
    {
        [Fact]
        public void Student_newStudentWillHaveIdSet_shouldBeTrue()
        {
            var student = new Student("Harry", "Potter");

            var id = student.Id;

            Assert.True(id > 0, "Student ID should be larger than 0");
        }

        [Fact]
        public void Student_studentsHaveDifferentIds_shouldBeTrue()
        {
            var firstStudent = new Student("Harry", "Potter");
            var secondStudent = new Student("Ron", "Weasley");

            var firstStudentId = firstStudent.Id;
            var secondStudentId = secondStudent.Id;

            Assert.NotEqual(firstStudent, secondStudent);
        }

        [Fact]
        public void Status_statusIsReadOnly_shouldThrowExceptionWhenChanged()
        {
            var student = new Student("Harry", "Potter");

            Assert.Throws<ReadOnlyException>(() => student.Status = EnrollmentStatus.Dropout);
        }

        [Fact]
        public void Status_studyEndsOnSameDayAsGraduation_shouldBeStatusGraduated()
        {
            var student = new Student("Harry", "Potter", new DateTime(1999, 1, 1), new DateTime(2000, 1, 1), new DateTime(2000, 1, 1));

            var status = student.Status;

            Assert.Equal(EnrollmentStatus.Graduated, status);
        }

        [Fact]
        public void Status_studyEndsBeforeGraduationDate_shouldBeStatusDropout()
        {
            var student = new Student("Harry", "Potter", new DateTime(1999, 1, 1), new DateTime(2001, 1, 1), new DateTime(2000, 1, 1));

            var status = student.Status;

            Assert.Equal(EnrollmentStatus.Dropout, status);
        }

        [Fact]
        public void Status_studyHasNotStartedYet_shouldBeStatusNew()
        {
            var student = new Student("Harry", "Potter", new DateTime(3000, 1, 1), new DateTime(3001, 1, 1), new DateTime(3001, 1, 1));

            var status = student.Status;

            Assert.Equal(EnrollmentStatus.New, status);
        }

        [Fact]
        public void testsss()
        {
            var student = new Student("Harry", "Potter", new DateTime(1999, 1, 1), new DateTime(2000, 1, 1), new DateTime(2000, 1, 1));

            var description = student.ToString();
            Console.WriteLine(description);

            Assert.Contains("Graduated", description);
        }
    }
}
