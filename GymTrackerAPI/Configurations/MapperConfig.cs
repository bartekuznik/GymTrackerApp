using AutoMapper;
using GymTrackerAPI.Data;
using GymTrackerAPI.Models.BodyMeasurementLog;
using GymTrackerAPI.Models.Exercise;
using GymTrackerAPI.Models.NutritionLog;
using GymTrackerAPI.Models.User;
using GymTrackerAPI.Models.WaterLog;
using GymTrackerAPI.Models.Workout;
using GymTrackerAPI.Models.WorkoutExercise;
using GymTrackerAPI.Models.WorkoutSet;

namespace GymTrackerAPI.Configurations
{
    public class MapperConfig : Profile
    {

        public MapperConfig() 
        {
            CreateMap<BodyMeasurementLog, BodyMeasurementLogDto>().ReverseMap();
            CreateMap<BodyMeasurementLog, CreateBodyMeasurementLogDto>().ReverseMap();
            CreateMap<BodyMeasurementLog, UpdateBodyMeasurementLogDto>().ReverseMap();

            CreateMap<Exercise, ExerciseDto>().ReverseMap();
            CreateMap<Exercise, CreateExerciseDto>().ReverseMap();
            CreateMap<Exercise, UpdateExerciseDto>().ReverseMap();

            CreateMap<NutritionLog, NutritionLogDto>().ReverseMap();
            CreateMap<NutritionLog, CreateNutritionLogDto>().ReverseMap();
            CreateMap<NutritionLog, UpdateNutritionLogDto>().ReverseMap();

            // Wyjątek, IdentityUser potrzebuje UserName
            CreateMap<CreateUserDto, User>()
                .ForMember(d => d.UserName, o => o.MapFrom(s => s.Email))
                .ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();

            CreateMap<WaterLog, WaterLogDto>().ReverseMap();
            CreateMap<WaterLog, CreateWaterLogDto>().ReverseMap();
            CreateMap<WaterLog, UpdateWaterLogDto>().ReverseMap();

            CreateMap<Workout, WorkoutDto>()
                .ForMember(dest => dest.WorkoutExerciseDto, opt => opt.MapFrom(src => src.WorkoutExercise));
            CreateMap<Workout, CreateWorkoutDto>().ReverseMap();
            CreateMap<Workout, UpdateWorkoutDto>().ReverseMap();

            CreateMap<WorkoutExercise, WorkoutExerciseDto>().ReverseMap();
            CreateMap<WorkoutExercise, CreateWorkoutExerciseDto>().ReverseMap();
            CreateMap<WorkoutExercise, UpdateWorkoutExerciseDto>().ReverseMap();

            CreateMap<WorkoutSet, WorkoutSetDto>().ReverseMap();
            CreateMap<WorkoutSet, CreateWorkoutSetDto>().ReverseMap();
            CreateMap<WorkoutSet, UpdateWorkoutSetDto>().ReverseMap();
            CreateMap<WorkoutSet, WorkoutSetPreviewDto>().ReverseMap();
        }
        
    }
}
