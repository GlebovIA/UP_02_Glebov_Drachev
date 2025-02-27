namespace UP_02_Glebov_Drachev.Classes
{
    public static class Queries
    {
        public static string CreateConnection(string login, string password) =>
            $"SELECT * FROM Users WHERE login = '{login}' AND password = '{password}'";

        public static string TeachersLoad(int teacherId) =>
            $"SELECT TeachersLoad.id, Disciplines.name, StudGroups.name, lectureHours, " +
            $"StudPlan.PastLectureHours, practiceHours, StudPlan.PastPracticeHours, examHours " +
            $"FROM TeachersLoad, StudGroups, Disciplines, StudPlan " +
            $"WHERE disciplineId = Disciplines.id AND studGroupId = StudGroups.id " +
            $"AND StudPlan.TeachersLoad = TeachersLoad.id " +
            $"AND TeachersLoad.teacherId = {teacherId};";
    }
}
