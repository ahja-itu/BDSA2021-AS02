using System;
using Xunit;
using System.Data;

namespace Student.Tests
{
    public class ImmutableStudentTests
    {
        [Fact]
        public void ImmutableStudent_createImmutableStudent_has_nonneg_Id()
        {
            var now = DateTime.Now;
            var student = new ImmutableStudent("Harry", "Potter", now, now, now);

            var id = student.Id;

            Assert.True(id > 0);
        }

        [Fact]
        public void ImmutableStudent_twoStudentsDoesntShareId_shouldBeTrue()
        {
            var now = DateTime.Now;
            var firstStudent = new ImmutableStudent("Harry", "Potter", now, now, now);
            var secondStudent = new ImmutableStudent("Hagrid", "??", now, now, now);

            Assert.NotEqual(firstStudent.Id, secondStudent.Id);
        }

        [Fact]
        public void ImmutableStudent_updatedStudent_isNotEqualToPreviousVersion()
        {
            var now = DateTime.Now;
            var originalStudent = new ImmutableStudent("Harry", "Potter", now, now, now);

            var newStudent = originalStudent with { GivenName = "John" };
            Assert.NotEqual(originalStudent, newStudent);
            Assert.Equal(originalStudent.Id, newStudent.Id);
        }

        [Fact]
        public void ToString_graduatedStudent_shouldReportStatus_eq_Graduated()
        {
            var student = new ImmutableStudent("Harry", "Potter", new DateTime(1999, 1, 1), new DateTime(2000, 1, 1), new DateTime(2000, 1, 1));

            var toString = student.ToString();

            Assert.Contains("Graduated", toString);
        }

        [Fact]
        public void ImmutableStudent_updatedStudent_willGraduateBetweenRecordUpdate()
        {
            var student = new ImmutableStudent("Harry", "Potter", new DateTime(1999, 1, 1), new DateTime(3000, 1, 1), new DateTime(3000, 1, 1));

            var status = student.Status;

            Assert.Equal(EnrollmentStatus.Active, status);

            var updatedStudent = student with { EndDate = new DateTime(2000, 1, 1), GraduationDate = new DateTime(2000, 1, 1)};
            
            // in order to update status for immutable students, we need to do that ourselves as the 
            // clone method for immutable students is run before the actual setting of updated fields...
            updatedStudent = updatedStudent with { Status = Student.DetermineStatus(DateTime.Now, updatedStudent.StartDate, updatedStudent.EndDate, updatedStudent.GraduationDate)};

            var updatedStatus = updatedStudent.Status;

            Assert.Equal(EnrollmentStatus.Graduated, updatedStatus);
        }


    }
}
