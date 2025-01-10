using ArrowLog.Database.Models;

namespace ArrowLog.Database.Seeders
{
    public static class DbSeeder
    {
        public static async Task SeedData(AppDbContext context)
        {
            if (!context.Persons.Any())
            {
                // Add some default hit types for rulesets
                var standardHitTypes = new List<HitType>
            {
                new() { Title = "Kill", Values = new List<int> { 20, 18, 16 } },
                new() { Title = "Body", Values = new List<int> { 14, 12, 10 } },
                new() { Title = "Wound", Values = new List<int> { 8, 6, 4 } },
                new() { Title = "Miss", Values = new List<int> { 0 } }
            };

                // Add some default parcours
                var defaultParcours = new List<Parcours>
            {
                new() { Name = "Forest Trail", Location = "North Woods", AnimalCount = 28 },
                new() { Name = "Mountain Path", Location = "Alpine Heights", AnimalCount = 24 },
                new() { Name = "River Course", Location = "Valley Stream", AnimalCount = 20 },
                new() { Name = "Desert Route", Location = "Sandy Plains", AnimalCount = 22 }
            };

                await context.Parcours.AddRangeAsync(defaultParcours);
                await context.SaveChangesAsync();

                // Add some default rulesets
                var defaultRulesets = new List<Ruleset>
            {
                new() {
                    Name = "Standard 3D",
                    HitTypes = standardHitTypes,
                },
                new() {
                    Name = "Training Mode",
                    HitTypes = new List<HitType> {
                        new() { Title = "Hit", Values = new List<int> { 10, 8, 5 } },
                        new() { Title = "Miss", Values = new List<int> { 0 } }
                    }
                },
                new() {
                    Name = "Pro Rules",
                    HitTypes = new List<HitType> {
                        new() { Title = "Perfect", Values = new List<int> { 25, 20 } },
                        new() { Title = "Kill", Values = new List<int> { 18, 16, 14 } },
                        new() { Title = "Wound", Values = new List<int> { 12, 10, 8 } },
                        new() { Title = "Miss", Values = new List<int> { 0 } }
                    }
                }
            };

                await context.Rulesets.AddRangeAsync(defaultRulesets);
                await context.SaveChangesAsync();
            }
        }
    }
}
