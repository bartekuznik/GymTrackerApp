namespace GymTrackerAPI.Data.Enums
{
    public enum MuscleGroup
    {
        // Klatka
        Chest = 1,
        UpperChest = 2,

        // Barki
        AnteriorDeltoid = 3,   // przedni akton barku
        LateralDeltoid = 4,    // środkowy akton barku
        PosteriorDeltoid = 5,  // tylny akton barku

        // Plecy
        Lats = 6,              // najszerszy grzbietu
        UpperBack = 7,         // górny grzbiet (rhomboidy, trap mid)
        LowerBack = 8,         // erectory / prostowniki grzbietu
        Trapezius = 9,         // kaptury

        // Ramiona
        Biceps = 10,
        Triceps = 11,
        Forearms = 12,         // mięśnie przedramion

        // Nogi
        Quadriceps = 13,       // quady
        Hamstrings = 14,
        Glutes = 15,
        Calves = 16,           // łydki
        Adductors = 17,
        Abductors = 18,

        // Core
        Abs = 19,
        Obliques = 20,         // skośne
        HipFlexors = 21        // zginacze bioder
    }

}
