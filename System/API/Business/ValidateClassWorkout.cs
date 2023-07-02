using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Business
{
    public class ValidateClassWorkout
    {
        public void isValidRoutine(Models.Request.WorkoutRoutineRequest req){

                if(string.IsNullOrEmpty(req.routinename))
                    throw new ArgumentException("The Routinename field is invalid");

                if(string.IsNullOrEmpty(req.duration))
                    throw new ArgumentException("The Duration field is invalid");
                
                if(req.exercise.Count == 0)
                    throw new ArgumentException("You need to add at least exercise");

            foreach(Models.Request.ExercisesRequest i in req.exercise){

                isValidExercise(i);
            }
        }

        public void isValidExercise(Models.Request.ExercisesRequest exerciseReq){

            Database.WeekDayDatabase daysDb = new Database.WeekDayDatabase();

            if(string.IsNullOrEmpty(exerciseReq.exercise.Trim()))
                throw new Models.Custom.CustomExeceptionExercise("The Exercise field is invalid", exerciseReq);
        
            if(string.IsNullOrEmpty(exerciseReq.seriesandrepeats.Trim()))
                throw new Models.Custom.CustomExeceptionExercise("The Seriesandrepeats field is invalid", exerciseReq);
        
            if(string.IsNullOrEmpty(exerciseReq.restTime.Trim()))
                throw new Models.Custom.CustomExeceptionExercise("The RestTime field is invalid", exerciseReq);
        
            if(string.IsNullOrEmpty(exerciseReq.warmingLoad.Trim()))
                throw new Models.Custom.CustomExeceptionExercise("The WarmingLoad field is invalid", exerciseReq);
        
            if(string.IsNullOrEmpty(exerciseReq.maximumLoad.Trim()))
                throw new Models.Custom.CustomExeceptionExercise("The MaximumLoad field is invalid", exerciseReq);

            if(daysDb.getWeekDay(exerciseReq.idweekDay) == null)
                throw new Models.Custom.CustomExeceptionExercise("This WeekDay was not found", exerciseReq);
        }
    }
}