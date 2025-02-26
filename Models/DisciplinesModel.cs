﻿namespace UP_02_Glebov_Drachev.Models
{
    public class DisciplinesModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }

        public DisciplinesModel(int id, string name, int teacherId)
        {
            Id = id;
            Name = name;
            TeacherId = teacherId;
        }
    }

}
