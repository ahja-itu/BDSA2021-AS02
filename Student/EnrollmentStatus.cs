namespace Student
{
    public enum EnrollmentStatus
    {
        New,
        Active,
        Dropout,
        Graduated
    }

    public static class ExtensionMethods
    {
        public static string ToString (this EnrollmentStatus status) => status switch
        {
            EnrollmentStatus.New => "New",
            EnrollmentStatus.Active => "Active",
            EnrollmentStatus.Graduated => "Graduated",
            EnrollmentStatus.Dropout => "Dropout"
        };
        
    }

    
}