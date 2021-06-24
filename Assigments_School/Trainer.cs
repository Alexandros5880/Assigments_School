using System;
using System.Collections.Generic;

namespace Assigments_School
{
    class Trainer : People
    {

        public List<Course> courses = new List<Course>();
        public static List<Trainer> trainers = new List<Trainer>();

        public Trainer(String firstname, String lastname,
                            int age, String gender, DateTime startdate) :
                            base(firstname, lastname, age, gender, startdate)
        {
            Trainer.trainers.Add(this);
        }
        ~Trainer()
        {
            Trainer.trainers.Remove(this);
        }


    }
}
