using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DBWork
{
    public static class DataBanks
    {
        public static int ProfessionsQuantity = 10;

        public static int DepartamentsQuantity = 10;

        public static int ProjectsQuantity = 500;

        public static int EmployeesQuantity = 700;
        
        public static int TasksQuantity = 4000;

        public static int EmployeePerformingTasksQuantity = 20000;

        public static Dictionary<int, DateTime> ProjectsStartDates = new Dictionary<int, DateTime>();

        public static List<Task> tasks = new List<Task>();

        public static List<Employee> employees = new List<Employee>();

        public static DateTime StartDate = new DateTime(2020, 1, 1);

        public static List<string> depPhones = new List<string> {
                "23-51-32",
                "23-61-23",
                "16-32-23",
                "23-34-12",
                "12-64-12",
                "63-76-86",
                "23-52-12",
                "22-53-12",
                "23-65-23",
                "26-53-47"
            };
        public static List<string> allTables = new List<string> { 
            "EmployeesPerformingTasks",
            "Tasks",
            "Employees",
            "Professions",
            "Projects",
            "Departaments" };

        public static List<string> departamentsNames = new List<string>
        {
                "Отдел ИТ",
                "Бухгалтерский отдел",
                "Юридический отдел",
                "Отдел финансов",
                "Отдел закупок",
                "Отдел HR",
                "Отдел кадров",
                "Отдел качества",
                "Отдел Public Relations",
                "Отдел развития"
        };

        public static List<string> failureReasons = new List<string> { "Сотрудник не справился с заданием",
            "Задание перестало быть актуальным","Задание невыполнимо технологически", "Работник отказался выполнять задание", "Работник отстранен от задания", "Задание оказалось слишком большим"};

        public static List<string> namesManBank = new List<string>{ "Сергей", "Алексей", "Александр", "Дмитрий", "Геннадий", "Василий", "Гордон", "Эмиль", "Мартин", "Томаш"
            , "Федор", "Леонид", "Юрий", "Денис", "Данил", "Игорь", "Квентин", "Гаврил", "Артем", "Тимофей", "Анатолий", "Архип", "Евгений", "Никита", "Владислав", "Владимир", "Добрыня"
            , "Святослав", "Елисей", "Аркадий"};

        public static List<string> surNamesManBank = new List<string>{ "Распутин", "Бондарец", "Коневский", "Орловский", "Котов", "Семенов", "Гордон", "Торвальдс", "Кнут", "Максвелл"
            , "Клир", "Мартин", "Петров", "Козлов", "Иванов", "Лютер", "Мюнцер", "Кальвин", "Чаушеску", "Ансельмо", "Родригес", "Ринго", "Депп", "Сталлоне", "ВанДамм", "МакГрегор", "Артемчик"
            , "Тарантино", "Финчер", "Линч"};

        public static List<string> fatherNamesManBank = new List<string>{  "Сергеевич", "Алексеевич", "Александрович", "Дмитриевич", "Геннадьевич", "Васильевич", "Гордонович", "Эмильевич", "Мартинович", "Томашевич"
            , "Федорович", "Леонидович", "Юрьевич", "Денисович", "Данилович", "Игоревич", "Квентинович", "Гаврилович", "Артемович", "Тимофеевич", "Анатольевич", "Архипович", "Евгеньевич", "Никитович", "Владиславович", "Владимирович", "Добрыневич"
            , "Святославович", "Елисеевич", "Аркадьевич"};

        public static List<string> namesWomanBank = new List<string>{ "Евгения", "Алиса", "Екатерина", "Алина", "Виктория", "Юлия", "Полина", "Эмилия", "Маргарита", "Гера"
            , "Анастасия", "Алёна", "Ирина"};

        public static List<string> surNamesWonamBank = new List<string>{ "Распутина", "Бондарец", "Коневская", "Орловская", "Котова", "Семенова", "Гордон", "Торвальдс", "Кнут", "Максвелл"
            , "Клир", "Мартин", "Петрова", "Козлова", "Иванова", "Родригес"};

        public static List<string> fatherNamesWomanBank = new List<string>{  "Сергеевна", "Алексеевна", "Александровна", "Дмитриевна", "Геннадьевна", "Васильевна", "Гордоновна", "Эмильевна", "Мартиновна", "Томашевна"
            , "Федоровна", "Леонидовна", "Юрьевна", "Денисовна", "Даниловна", "Игоревна", "Квентиновна", "Гавриловна", "Артемовна", "Тимофеевна"};

        public static Dictionary<string, int> qualificationsBank = new Dictionary<string, int>
                {
                    { "ИТ Специалист", 2000 },
                    { "Бухгалтер",  1200},
                    { "Юрист",  1450},
                    { "Экономист", 1100 },
                    { "Специалист По Закупкам", 1100 },
                    { "HR Специалист",  1300 },
                    { "Специалист По Кадрам",  1000 },
                    { "Специалист по проверке качества",  900 },
                    { "Специалист по Public Relations", 1600},
                    { "Менеджер", 1500},
                };

        public static Dictionary<string, double[]> gradationsBank = new Dictionary<string, double[]>
            {
                    { "Младший", new double[] {0.75, 20 }},
                    { "Средний", new double[] {1, 50 }},
                    { "Старший", new double[] {1.5, 20 }},
                    { "Главный", new double[] {2, 10 }}
            };
    }
}
