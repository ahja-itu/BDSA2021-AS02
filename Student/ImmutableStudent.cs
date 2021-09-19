using System;

namespace Student
{
    public record ImmutableStudent
    {
        public int Id { get; init; }
        public string GivenName { get; init; }
        public string Surname { get; init; }
        public EnrollmentStatus Status { get; init; }
        public DateTime StartDate { get; init; }
        public DateTime EndDate { get; init; }
        public DateTime GraduationDate { get; init; }


        public ImmutableStudent(string givenname, string surname, DateTime startDate, DateTime endDate, DateTime gradDate)
        {
            this.Id = (new Random()).Next(1, 2000000000);
            GivenName = givenname;    
            Surname = surname;
            StartDate = startDate;
            EndDate = endDate;
            GraduationDate = GraduationDate;
            this.Status = Student.DetermineStatus(DateTime.Now, this.StartDate, this.EndDate, this.GraduationDate);
        }

        protected ImmutableStudent(ImmutableStudent original)
        {
            Console.WriteLine("clone!");
            this.Id = original.Id;
            this.GivenName = original.GivenName;
            this.Surname = original.Surname;
            this.StartDate = original.StartDate;
            this.EndDate = original.EndDate;
            this.GraduationDate = original.GraduationDate;
            this.Status = Student.DetermineStatus(DateTime.Now, this.StartDate, this.EndDate, this.GraduationDate);
        }
    }
}