using System;
using System.Data;

namespace Student
{
    public class Student
    {

        private static int _IdCounter;
        
        public int Id { get; init; }
        public string GivenName { get; }
        public string Surname { get; }
        
        private EnrollmentStatus _status;
        public EnrollmentStatus Status 
        {
            get { return _status; }
            set { throw new ReadOnlyException(); }
        }

        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public DateTime GraduationDate { get; }

        public Student(string name, string surname)
        {
            _IdCounter++;
            Id = _IdCounter;
            GivenName = name;
            Surname = surname;

            // setup date stuff
            StartDate = DateTime.Now;
            GraduationDate = DateTime.Now;
            EndDate = DateTime.Now;

            _status = _setStudentStatus(DateTime.Now);
        }
        public Student(string name, string surname, DateTime startDate, DateTime gradDate, DateTime endDate)
        {
            _IdCounter++;
            Id = _IdCounter;
            GivenName = name;
            Surname = surname;

            // setup date stuff
            StartDate = startDate;
            GraduationDate = gradDate;
            EndDate = endDate;

            _status = _setStudentStatus(DateTime.Now);
        }

        private EnrollmentStatus _setStudentStatus(DateTime now) => 
            DateTime.Compare(EndDate, GraduationDate) switch
            {
                <0 => EnrollmentStatus.Dropout,
                0 => DateTime.Compare(now, StartDate) switch
                {
                    <0 => EnrollmentStatus.New,
                    _ => DateTime.Compare(now, EndDate) switch
                    {
                        <0 => EnrollmentStatus.Active,
                        _ => EnrollmentStatus.Graduated
                    }
                },
                _ => EnrollmentStatus.Graduated
            };   


        public override string ToString() {
            return $"<Student name: {GivenName}, surname: {Surname}, Status: {Status},\nStudies start date: {StartDate},\nStudies end date: {EndDate},\nGraduation date: {GraduationDate}>";
        }
    }
}
