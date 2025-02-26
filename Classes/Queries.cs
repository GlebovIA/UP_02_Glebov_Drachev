namespace UP_02_Glebov_Drachev.Classes
{
    public class Queries
    {
        public static string CreateConnection(string login, string password) => $"Select * from Users where login = '{login}' and password = '{password}'";
        public static string TeachersLoad(int teacherId) => $"Select TeachersLoad.id, Disciplines.name, StudGroups.name, lectureHours, StudPlan.PastLectureHours, practiceHours, StudPlan.PastPracticeHours, examHours from TeachersLoad, StudGroups, Disciplines, StudPlan where disciplineId = Disciplines.id and studGroupId = StudGroups.id and StudPlan.TeachersLoad = TeachersLoad.id and TeachersLoad.teacherId = {teacherId};";
    }
}
