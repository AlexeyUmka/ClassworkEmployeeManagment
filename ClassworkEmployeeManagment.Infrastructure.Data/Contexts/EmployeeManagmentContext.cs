using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ClassworkEmployeeManagment.Domain.Core.Basic_Models;

namespace ClassworkEmployeeManagment.Infrastructure.Data.Contexts
{
    public class EmployeeManagmentContext : DbContext
    {
        static EmployeeManagmentContext()
        {
            Database.SetInitializer(new ProgrammerInitializer());
        }
        public DbSet<Programmer> Programmers { get; set; }
        public DbSet<ProgrammersTeam> ProgrammersTeams { get; set; }
        public DbSet<ProjectForProgrammers> ProjectsForProgrammers { get; set; }
    }
    class ProgrammerInitializer : DropCreateDatabaseAlways<EmployeeManagmentContext>
    {
        protected override void Seed(EmployeeManagmentContext context)
        {
            context.Configuration.ValidateOnSaveEnabled = false;
            context.SaveChanges();
            context.Programmers.AddRange(new List<Programmer>() {
                new Programmer(){Name="Valera", SurName="Dubov", Patronymic="Alexandrovich", BirthDay=new DateTime(1990, 5, 12), SalaryPerMonth=500, LevelOfSkill=1},
                new Programmer(){Name="Stepan", SurName="Vlasov", Patronymic="Maksimovich", BirthDay=new DateTime(1992, 5, 12), SalaryPerMonth=1500, LevelOfSkill=3},
                new Programmer(){Name="Stas", SurName="Zubin", Patronymic="Alexeyevich", BirthDay=new DateTime(1980, 5, 12), SalaryPerMonth=550, LevelOfSkill=2},
                new Programmer(){Name="Nikita", SurName="Krashev", Patronymic="Tarasovich", BirthDay=new DateTime(1993, 5, 12), SalaryPerMonth=600, LevelOfSkill=1},
                new Programmer(){Name="Alexey", SurName="Kovalyov", Patronymic="Stanislavovich", BirthDay=new DateTime(1986, 5, 12), SalaryPerMonth=670, LevelOfSkill=1},
                new Programmer(){Name="Vladimir", SurName="Vakulenko", Patronymic="Alexandrovich", BirthDay=new DateTime(1992, 5, 12), SalaryPerMonth=607, LevelOfSkill=1},
                new Programmer(){Name="Sergey", SurName="Domnich", Patronymic="Alexandrovich", BirthDay=new DateTime(1970, 5, 12), SalaryPerMonth=700, LevelOfSkill=2},
                new Programmer(){Name="Misha", SurName="Kayika", Patronymic="Maximovich", BirthDay=new DateTime(1975, 5, 12), SalaryPerMonth=1400, LevelOfSkill=3},
                new Programmer(){Name="Vladimir", SurName="Sushko", Patronymic="Muhmedich", BirthDay=new DateTime(1957, 5, 12), SalaryPerMonth=1200, LevelOfSkill=2},
                new Programmer(){Name="Alexander", SurName="Lipovetski", Patronymic="Kirilovich", BirthDay=new DateTime(1990, 5, 12), SalaryPerMonth=1100, LevelOfSkill=3},
                new Programmer(){Name="Stas", SurName="Voyajer", Patronymic="Vladimirovich", BirthDay=new DateTime(1998, 5, 12), SalaryPerMonth=1500, LevelOfSkill=3},
                new Programmer(){Name="Andrey", SurName="Drozdov", Patronymic="Alexandrovich", BirthDay=new DateTime(1995, 5, 12), SalaryPerMonth=1630, LevelOfSkill=3},
                new Programmer(){Name="Dmitry", SurName="Kranich", Patronymic="Stanislavovich", BirthDay=new DateTime(1991, 5, 12), SalaryPerMonth=1120, LevelOfSkill=3},
                new Programmer(){Name="Ahmed", SurName="Berezov", Patronymic="Alexandrovich", BirthDay=new DateTime(1993, 5, 12), SalaryPerMonth=500, LevelOfSkill=2},
                new Programmer(){Name="Mahmud", SurName="Mishkin", Patronymic="Stanislavovich", BirthDay=new DateTime(1996, 5, 12), SalaryPerMonth=450, LevelOfSkill=1},
                new Programmer(){Name="Nastya", SurName="Kolousova", Patronymic="Alexeyevna", BirthDay=new DateTime(1977, 5, 12), SalaryPerMonth=520, LevelOfSkill=2},
                new Programmer(){Name="Marina", SurName="Kalinchuk", Patronymic="Alexeyevna", BirthDay=new DateTime(1966, 5, 12), SalaryPerMonth=430, LevelOfSkill=2},
                new Programmer(){Name="Svetlana", SurName="Shlyapik", Patronymic="Alexeyevna", BirthDay=new DateTime(1967, 5, 12), SalaryPerMonth=340, LevelOfSkill=1},
                new Programmer(){Name="Kirill", SurName="Polevich", Patronymic="Tarasovich", BirthDay=new DateTime(1976, 5, 12), SalaryPerMonth=500, LevelOfSkill=1},
                new Programmer(){Name="Tanya", SurName="Lipova", Patronymic="Tarasovna", BirthDay=new DateTime(1974, 5, 12), SalaryPerMonth=500, LevelOfSkill=1},
            });
        }
    }
}
